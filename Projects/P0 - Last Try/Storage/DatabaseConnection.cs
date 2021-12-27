using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Models;
using Storage;

namespace Client
{
    public class DatabaseConnection : IDataBaseConnection
    {
        string str = "Data source = DESKTOP-7JH34M9\\SQLEXPRESS;initial Catalog = REIApp; integrated security = true";
        private readonly SqlConnection _con;
        private readonly IMapper _mapper;

        //Constructor
        public DatabaseConnection(IMapper mapper)
        {
            this._con = new SqlConnection(str);
            _con.Open();
            this._mapper = mapper;
        }

        /// <summary>
        /// Chcking if customer exists
        /// </summary>
        /// <param name="firstName">Users first name</param>
        /// <param name="email">Users email</param>
        /// <returns>Customer</returns>
        public Customer GetCustomer(string firstName, string email)
        {
            string queryString = ($"SELECT * FROM Customers WHERE FirstName = '{firstName}' AND Email = '{email}';");

            Customer customer;
            using (SqlCommand cmd = new SqlCommand(queryString, this._con))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                customer = this._mapper.EntityToCustomer(dr);
                dr.Close();
            }
            return customer;
        }

        /// <summary>
        /// Store Locations from db
        /// </summary>
        /// <returns>List<Store></Store></returns>
        public List<Store> GetStores()
        {
            string queryString = "SELECT * FROM Store;";
            List<Store> stores = new List<Store>();
            using (SqlCommand cmd = new SqlCommand(queryString, this._con))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                stores = this._mapper.EntityToStoreLocations(dr);
                dr.Close();
            }
            return stores;
        }

        /// <summary>
        /// Products at stores
        /// </summary>
        /// <param name="storeId">Stores ID</param>
        /// <returns></returns>
        public List<Product> GetStoreProducts()
        {
            string queryString = "SELECT * FROM Products";
            List<Product> products = new List<Product>();
            using (SqlCommand cmd = new SqlCommand(queryString, this._con))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                products = this._mapper.EntityToProductList(dr);
                dr.Close();
            }
            return products;
        }

        /// <summary>
        /// Adding a customer to db
        /// </summary>
        /// <param name="firstName">Users first name</param>
        /// <param name="lastName">Users last name</param>
        /// <param name="email">Users email</param>
        public int AddCustomer(string firstName, string lastName, string email)
        {
            int newId;

            string queryString = ($"INSERT INTO Customers (FirstName, LastName, Email) OUTPUT INSERTED.CustomerID VALUES ('{firstName}', '{lastName}', '{email}');");

            using SqlCommand cmd = new SqlCommand(queryString, this._con);
            newId = (int)cmd.ExecuteScalar();
            return newId;
        }

        /// <summary>
        /// New order to db
        /// </summary>
        /// <param name="customerId">Customers Id</param>
        /// <param name="total">Order Total</param>
        /// <returns>New Order Id</returns>
        public int AddOrder(int customerId, int total)
        {
            int newId;
            string queryString = ($"INSERT INTO Orders (CustomerID, Total) OUTPUT INSERTED.OrderId VALUES ({customerId}, {total});");

            using SqlCommand cmd = new SqlCommand(queryString, this._con);
            newId = (int)cmd.ExecuteScalar();
            return newId;
        }

        /// <summary>
        /// Closes database connection
        /// </summary>
        public void CloseDataBaseConnection()
        {
            this._con.Close();
        }

    }
}
