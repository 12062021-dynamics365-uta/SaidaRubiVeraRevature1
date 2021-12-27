using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Storage;

namespace Domain
{
    public class ShoppingLogic : IShoppingLogic

    {
        private readonly IDataBaseConnection _dbContext;
        public Customer CurrentCustomer { get; set; }
        public Store CurrentStore { get; set; }

        public ShoppingLogic(IDataBaseConnection dba)
        {
            this._dbContext = dba;
        }

        /// <summary>
        /// Logging in
        /// </summary>
        /// <param name="firstName">Users username</param>
        /// <param name="email">Users password</param>
        /// <returns>bool</returns>
        public bool Login(string firstName, string email)
        {
            Customer customer = _dbContext.GetCustomer(firstName, email);

            if (customer != null)
            {
                CurrentCustomer = customer;
                InitializeStores();
                return true;
            }
            else
            {
                CurrentCustomer = null;
                return false;
            }
        }

        /// <summary>
        /// New Customer
        /// </summary>
        /// <param name="firstName">Users first name</param>
        /// <param name="lastName">Users last name</param>
        /// <param name="email">Users email</param>
        public void Register(string firstName, string lastName, string email)
        {
            int id = _dbContext.AddCustomer(firstName, lastName, email);
            CurrentCustomer = new Customer(id, firstName, lastName);
            InitializeStores();
        }

        /// <summary>
        /// Store Locations
        /// </summary>
        public void InitializeStores()
        {
            CurrentCustomer.StoreLocations = _dbContext.GetStores();
        }

        /// <summary>
        /// Validates input for the main menu
        /// </summary>
        /// <param name="userInput">Users Input string</param>
        /// <returns>int</returns>
        public int ValidateMainMenuChoice(string userInput)
        {
            int userChoice = ConvertInputToInt(userInput);
            int numOfChoices = 3;

            if (userChoice > numOfChoices)
                userChoice = 0;

            return userChoice;
        }

        /// <summary>
        /// Validates input for store location options
        /// </summary>
        /// <param name="userInput">Users Input string</param>
        /// <returns>int</returns>
        public int ValidateStoreListMenuChoice(string userInput)
        {
            int userChoice = ConvertInputToInt(userInput);
            int numOfChoices = CurrentCustomer.StoreLocations.Count;

            if (userChoice > numOfChoices + 1 || userChoice == 0)
                userChoice = 0;
            else if (userChoice != numOfChoices + 1)
            {
                CurrentStore = CurrentCustomer.StoreLocations.Find(x => x.StoreId == userChoice);
                InitializeCurrentStoreProducts();
                InitializePreviousStoreOrders();
            }

            return userChoice;
        }

        /// <summary>
        /// Respective stores inventory
        /// </summary>
        public void InitializeCurrentStoreProducts()
        {
            CurrentStore.Products = _dbContext.GetStoreProducts();
        }


        /// <summary>
        /// Customers order history
        /// </summary>
        public void InitializePreviousStoreOrders()
        {
           
        }

        /// <summary>
        /// Validates input with store Menu
        /// </summary>
        /// <param name="userInput">Users Input string</param>
        /// <returns>int</returns>
        public int ValidateStoreMenuChoice(string userInput)
        {
            int userChoice = ConvertInputToInt(userInput);
            int numOfChoices = CurrentCustomer.StoreLocations.Count;

            if (userChoice > numOfChoices)
                userChoice = 0;

            return userChoice;
        }

        /// <summary>
        /// Validates input for shopping
        /// </summary>
        /// <param name="userInput">Users Input string</param>
        /// <param name="numOfChoices"></param>
        /// <returns> int</returns>
        public int ValidateShoppingMenuChoice(string userInput, int numOfChoices)
        {
            int userChoice = ConvertInputToInt(userInput);

            if (userChoice > numOfChoices)
                userChoice = 0;

            return userChoice;
        }

        /// <summary>
        /// Converts input into int
        /// </summary>
        /// <param name="userInput">Users Input string</param>
        /// <returns>int</returns>
        public int ConvertInputToInt(string userInput)
        {
            bool conversionBool = Int32.TryParse(userInput, out int convertedNumber);

            if (!conversionBool)
                convertedNumber = 0;

            return convertedNumber;
        }
        

        /// <summary>
        /// Order history
        /// </summary>
        /// <returns>List<Order></Order></returns>
        public List<Order> GetListOfOrders()
        {
            return CurrentCustomer.PastOrders;
        }

        /// <summary>
        /// Adding products to cart
        /// </summary>
        /// <param name="product"></param>
        /// <returns>bool</returns>
        public bool AddProductToCart(Product product)
        {
            if (CurrentCustomer.Order.TotalCost + product.Price < 500 &&
                CurrentCustomer.Cart.Count < 50)
            {
                CurrentCustomer.Cart.Add(product);
                CurrentCustomer.Order.Products.Add(product);
                CurrentCustomer.Order.TotalCost += product.Price;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Product and how many 
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<KeyValuePair<(string Name, int Price), int>> ConvertCartToIEnum()
        {
            var y = CurrentCustomer.Cart
                .GroupBy(x => (x.Name, x.Price))
                .Select(group => new KeyValuePair<(string Name, int Price), int>((group.Key.Name, group.Key.Price), group.Count()));

            return y;
        }

        /// <summary>
        /// Order history: what and how much
        /// </summary>
        /// <param name="i">Past Orders index</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<KeyValuePair<(string Name, int Price), int>> ConvertOrdersToIEnum(int i)
        {

            var y = CurrentCustomer.PastOrders[i].Products
                .GroupBy(x => (x.Name, x.Price))
                .Select(group => new KeyValuePair<(string Name, int Price), int>((group.Key.Name, group.Key.Price), group.Count()));

            return y;
        }

        public void Checkout()
        {

        }

        /// <summary>
        /// Canceling order :(
        /// </summary>
        public void CancelOrder()
        {
            CurrentCustomer.Cart = new List<Product>();
            CurrentCustomer.Order = new Order();
        }

        /// <summary>
        /// Closes database connection
        /// </summary>
        public void Exit()
        {
            _dbContext.CloseDataBaseConnection();
        }
    }
}
