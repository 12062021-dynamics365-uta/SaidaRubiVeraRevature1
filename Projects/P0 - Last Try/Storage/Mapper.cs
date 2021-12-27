using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace Storage
{
    public class Mapper : IMapper
    {
        /// <summary>
        /// Database to Customer
        /// </summary>
        /// <param name="dr">Sql data reader</param>
        /// <returns>Customer</returns>
        public Customer EntityToCustomer(SqlDataReader dr)
        {
            Customer customer = null;

            while (dr.Read())
            {
                customer = new Customer()
                {
                    CustomerId = dr.GetInt32(0),
                    Firstname = dr.GetString(1),
                    Lastname = dr.GetString(2)
                };
            }
            return customer;
        }

        /// <summary>
        /// Database to Store Locations
        /// </summary>
        /// <param name="dr">Sql data reader</param>
        /// <returns>List of store locations</returns>
        public List<Store> EntityToStoreLocations(SqlDataReader dr)
        {
            List<Store> stores = new List<Store>();

            while (dr.Read())
            {
                Store s = new Store()
                {
                    StoreId = dr.GetInt32(0),
                    StoreLocation = dr.GetString(1)
                };
                stores.Add(s);
            }
            return stores;
        }

        /// <summary>
        /// Database to Products
        /// </summary>
        /// <param name="dr">Sql data reader</param>
        /// <returns>List of products</returns>
        public List<Product> EntityToProductList(SqlDataReader dr)
        {
            List<Product> products = new List<Product>();

            while (dr.Read())
            {
                Product p = new Product()
                {
                    ProductId = dr.GetInt32(0),
                    Name = dr.GetString(1),
                    Price = dr.GetInt32(2),
                    Description = dr.GetString(3)
                };
                products.Add(p);
            }
            return products;
        }

        /// <summary>
        /// Databse to orders
        /// </summary>
        /// <param name="dr">Sql data reader</param>
        /// <returns>List of orders</returns>
        public List<Order> EntityToOrderList(SqlDataReader dr)
        {
            List<Order> orders = new List<Order>();

            while (dr.Read())
            {
                Order order = new Order()
                {
                    OrderId = dr.GetInt32(0),
                    TotalCost = dr.GetInt32(6),
                    Products = new List<Product>()
                };

                if (!orders.Exists(x => x.OrderId == dr.GetInt32(0)))
                    orders.Add(order);
                foreach (Order o in orders)
                {
                    if (o.OrderId == dr.GetInt32(0))
                    {
                        Product p = new Product()
                        {
                            ProductId = dr.GetInt32(2),
                            Name = dr.GetString(3),
                            Price = dr.GetInt32(4),
                            Description = dr.GetString(5)
                        };
                        o.Products.Add(p);
                    }
                }
            }
            return orders;
        }
    }
}
