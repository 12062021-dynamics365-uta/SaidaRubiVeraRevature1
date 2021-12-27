using System;
using System.Collections.Generic;
using System.Linq;
using Client;
using Domain;
using Models;
using Storage;


namespace Project0___StoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Options opts = Options.MainMenu;
            Mapper mapper = new Mapper();
            DatabaseConnection dbAccess = new DatabaseConnection(mapper);
            ShoppingLogic shopping = new ShoppingLogic(dbAccess);

            do
            {
                switch (opts)
                {
                    case Options.MainMenu:
                        opts = MainMenu(shopping);
                        break;
                    case Options.LoginMenu:
                        opts = LoginMenu(shopping);
                        break;
                    case Options.RegisteringMenu:
                        opts = RegisteringMenu(shopping);
                        break;
                    case Options.StoreLocationsMenu:
                        opts = StoreLocationsMenu(shopping);
                        break;
                    case Options.StoreMenu:
                        opts = StoreMenu(shopping);
                        break;
                    case Options.ShoppingMenu:
                        opts = ShoppingMenu(shopping);
                        break;
                    case Options.OrderSuccsessMenu:
                        opts = OrderSuccessMenu(shopping);
                        break;
                }
            } while (opts != Options.Exit);

            //Close database connection
            shopping.Exit();
        }

        /// <summary>
        /// Main Menu: login, create account, or exit
        /// </summary>
        /// <param name="shopping">ShoppingLogic Object</param>
        /// <returns>Options</returns>
        public static Options MainMenu(ShoppingLogic shopping)
        {
            int userChoice = 0;
            Options opts = Options.MainMenu;

            do
            {
                Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Console.WriteLine("░░░░░░░█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Console.WriteLine("░░░░░░███▄░░░░░░░░░░░▄░░░░░░░░░░░░░░░░░░░░░░░");
                Console.WriteLine("░░░░▄██████▄░░░░░░░░██▀▄░░░░░▄▄░░░░░░░░░░░░░░");
                Console.WriteLine("░░░██████████░░░░░░██░░░▀█░▄██▀██░░░░░░░░░░░░");
                Console.WriteLine("░░░▀▀██████▀▀░░░░░██░░░░░░██░░░░░▀██▄░░░░░░░░");
                Console.WriteLine("░░░░████████░░░░████░░░░░░░░░░░░░░░░░▀▄░░░░░░");
                Console.WriteLine("░░░███████████░███████████░░░█████░░▐█░▀█░░░░");
                Console.WriteLine("░░▀▀▀███████████▀░██░░░░░█░░░█░░░░░░▐█░░░░░░░");
                Console.WriteLine("░░░░███████████▀░░██░░░░░█░░░█░░░░░░▐█░░░░░░░");
                Console.WriteLine("░░░███████████▌░░░████████░░░███░░░░▐█░░░░░░░");
                Console.WriteLine("░░▐█████████████░░██░░░██░░░░█░░░░░░▐█░░░░░░░");
                Console.WriteLine("░░░░░░░░▀▀▀▀████████░░░░░██░░█░░░░░░▐█░░░░░░░");
                Console.WriteLine("░░░░░░░░░░░░░░░░░▀██░░░░░░██░██████░▐█░░░░░░░");
                Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▀░░░░░░░");
                Console.WriteLine("Welcome! Thanks for shopping with REI!\nPlease select one of the following:");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1: Returning Customer");
                Console.WriteLine("2: New Customer");
                Console.WriteLine("3: Exit");
                userChoice = shopping.ValidateMainMenuChoice(Console.ReadLine());

                switch (userChoice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Invalid input.\n");
                        break;
                    case 1: //Go to login
                        opts = Options.LoginMenu;
                        break;
                    case 2://create new customer
                        opts = Options.RegisteringMenu;
                        break;
                    case 3://exit app
                        opts = Options.Exit;
                        break;
                }
            } while (userChoice == 0);
            Console.Clear();
            return opts;
        }

        /// <summary>
        /// Shows the user the Login Menu
        /// </summary>
        /// <param name="shopping">ShoppingLogic Object</param>
        /// <returns>Options</returns>
        public static Options LoginMenu(ShoppingLogic shopping)
        {
            bool loggedIn;

            //loop until logged in
            do
            {
                Console.WriteLine("Please enter your first name and e-mail to login");
                Console.WriteLine("----------------------------------------------------------");
                Console.Write("First name: ");
                string firstName = Console.ReadLine();
                Console.Write("E-mail: ");
                string email = Console.ReadLine();

                Console.Clear();
                if (shopping.Login(firstName, email))
                {
                    loggedIn = true;
                    Console.WriteLine($"Welcome back {shopping.CurrentCustomer.Firstname}\n");
                }
                else
                {
                    loggedIn = false;
                    Console.WriteLine("Incorrect Name or Email, Please try again\n");
                }
            } while (!loggedIn);

            return Options.StoreLocationsMenu;
        }

        /// <summary>
        /// Registering a new customer
        /// </summary>
        /// <param name="shopping">ShoppingLogic Object</param>
        /// <returns>Options</returns>
        public static Options RegisteringMenu(ShoppingLogic shopping)
        {
            string firstName, lastName, email;

            Console.WriteLine("Howdy new friend! Please provide the bellow information to create an account");
            Console.WriteLine("----------------------------------------------------------");
            Console.Write("First Name: ");
            firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            lastName = Console.ReadLine();
            Console.Write("E-mail: ");
            email = Console.ReadLine();


            shopping.Register(firstName, lastName, email);
            Console.Clear();
            Console.WriteLine($"Account was created! Let's gear you up {firstName}");

            return Options.StoreLocationsMenu;
        }

        /// <summary>
        /// Avaliable Store Locations or sign out
        /// </summary>
        /// <param name="shopping">ShoppingLogic Object</param>
        /// <returns>Options</returns>
        public static Options StoreLocationsMenu(ShoppingLogic shopping)
        {
            int userChoice = 0;

            Options opts = Options.MainMenu;

            do
            {
                Console.WriteLine("Select your store");
                Console.WriteLine("--------------------");

                List<Store> storeLocations = shopping.CurrentCustomer.StoreLocations;
                foreach (Store s in storeLocations)
                    Console.WriteLine($"{s.StoreId}: {s.StoreLocation}");

                Console.WriteLine("4: Sign Off");
                userChoice = shopping.ValidateStoreListMenuChoice(Console.ReadLine());

                Console.Clear();
                if (userChoice == 0)
                    Console.WriteLine("Invalid input.\n");

                else if (userChoice == 4)
                {
                    Console.WriteLine("Thanks for shopping, enjoy the outdoors!");
                }
                else
                {
                    Console.WriteLine($"Your store is {storeLocations.Find(x => x.StoreId == userChoice).StoreLocation}\n");
                    opts = Options.StoreMenu;
                }

            } while (userChoice == 0);

            return opts;
        }

        /// <summary>
        /// Buy, View Previous Orders, Changing Ctore, or log out
        /// </summary>
        /// <param name="shopping">ShoppingLogic Object</param>
        /// <returns>Options</returns>
        public static Options StoreMenu(ShoppingLogic shopping)
        {
            int userChoice;

            Options opts = Options.ShoppingMenu;

            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1: Start Shopping!!");
                Console.WriteLine("2: View Previous Orders");
                Console.WriteLine("3: Select Other Location");
                Console.WriteLine("4: Sign Off");
                userChoice = shopping.ValidateStoreMenuChoice(Console.ReadLine());

                switch (userChoice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Invalid input.\n");
                        break;
                    case 2:
                        break;
                    case 3:
                        opts = Options.StoreLocationsMenu;
                        break;
                    case 4:
                        if (userChoice == 4)
                        {
                            Console.WriteLine("Thanks for shopping, enjoy the outdoors!");
                            opts = Options.MainMenu;
                        }
                        else
                            opts = Options.MainMenu;
                        break;
                }

            } while (userChoice == 0 || userChoice == 2);

            Console.Clear();

            return opts;
        }

        /// <summary>
        /// Shopping time!! Add to cart, change cart, or signing off
        /// </summary>
        /// <param name="shopping">ShoppingLogic Object</param>
        /// <returns>Options</returns>
        public static Options ShoppingMenu(ShoppingLogic shopping)
        {
            List<Product> products = shopping.CurrentStore.Products;
            List<Product> cart;
            Options opts = Options.ShoppingMenu;
            int userChoice = 0;

            do
            {
                int maxNum = products.Count + 1;
                cart = shopping.CurrentCustomer.Cart;

                //int counter = 0;

                if (cart.Count != 0)
                    PrintCart(shopping);

                Console.WriteLine($"Products available at {shopping.CurrentStore.StoreLocation}");
                Console.WriteLine("Enter product number to add to cart or go checkout. If you're ready for the outdoors feel free to sign off!");
                Console.WriteLine($"{maxNum}: Checkout");
                Console.WriteLine($"{++maxNum}: Cancel Order");
                Console.WriteLine("----------------------------------------------------------");
                PrintProduct(products);

                userChoice = shopping.ValidateShoppingMenuChoice(Console.ReadLine(), maxNum);

                if (userChoice == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input.\n");

                }
                else if (userChoice == maxNum)
                {
                    Console.Clear();
                    shopping.CancelOrder();
                    Console.WriteLine("Order was Canceled\n");
                    opts = Options.StoreMenu;
                }
                else if (userChoice == maxNum - 1)
                {
                    Console.Clear();
                    opts = Options.OrderSuccsessMenu;
                    shopping.Checkout();
                }
                else
                {
                    Product p = products[userChoice - 1];
                    Console.Clear();
                    if (shopping.AddProductToCart(p))
                        Console.WriteLine($"{p.Name} added to cart\n");
                    else
                        Console.WriteLine($"{p.Name} cannot be added, $500 or 50 item limit was reached\n");
                }

            } while (userChoice == 0 || (userChoice >= 1 && cart.Count > 1));

            return opts;
        }

        /// <summary>
        /// Order was placed
        /// </summary>
        /// <param name="shopping">ShoppingLogic Object</param>
        /// <returns>Options</returns>
        public static Options OrderSuccessMenu(ShoppingLogic shopping)
        {

            Console.Clear();
            Console.WriteLine($"Order was placed, enjoy your new gear!");
            return Options.StoreMenu;
        }

        /// <summary>
        /// Available products at store
        /// </summary>
        /// <param name="products">ShoppingLogic Object</param>
        public static void PrintProduct(List<Product> products)
        {
            int index = 1;
            foreach (Product p in products)
            {
                Console.WriteLine($"{index}: ${p.Name}  {p.Price}\n      {p.Description}");
                index++;
            }
        }

        
        /// <summary>
        /// Customers Cart
        /// </summary>
        /// <param name="cart">List of Product</param>
        public static void PrintCart(ShoppingLogic shopping)
        {
            int total = 0;

            var y = shopping.ConvertCartToIEnum();

            Console.WriteLine("Current gear in cart:");

            foreach (var x in y)
            {
                Console.WriteLine(string.Format("{0, 8}x {1, -25}{2, 7}", x.Value, x.Key.Name, (x.Value * x.Key.Price)));
                total += x.Key.Price * x.Value;
            }
            Console.WriteLine(string.Format("{0, 35}{1,7}\n", "Total:", ($"${total}")));
        }
        
    }
}
