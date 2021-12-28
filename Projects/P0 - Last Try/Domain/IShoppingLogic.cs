using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Domain
{
    public interface IShoppingLogic
    {
        Customer CurrentCustomer { get; set; }
        Store CurrentStore { get; set; }


        bool AddProductToCart(Product product);
        void CancelOrder();
        void Checkout();
        void Exit();
        void InitializeCurrentStoreProducts();
        void InitializePreviousStoreOrders();
        void InitializeStores();
        List<Order> GetListOfOrders();
        bool Login(string firstName, string email);
        void Register(string firstName, string lastName, string email);
        int ConvertInputToInt(string userInput);
        int ValidateMainMenuChoice(string userInput);
        int ValidateShoppingMenuChoice(string userInput, int numOfChoices);
        int ValidateStoreListMenuChoice(string userInput);
        int ValidateStoreMenuChoice(string userInput);
        IEnumerable<KeyValuePair<(string Name, int Price), int>> ConvertCartToIEnum();
        IEnumerable<KeyValuePair<(string Name, int Price), int>> ConvertOrdersToIEnum(int i);
    }
}
