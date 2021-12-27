using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Storage
{
    public interface IDataBaseConnection
    {
        int AddCustomer(string firstName, string lastName, string email);
        int AddOrder(int customerId, int total);
        void CloseDataBaseConnection();
        Customer GetCustomer(string firstName, string email);
        List<Product> GetStoreProducts();
        List<Store> GetStores();
    }
}

