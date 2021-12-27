using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Customer must be able to:
    /// view order history
    /// see store locations
    /// make purchases
    /// view cart
    /// checkout
    /// cancel order
    /// </summary>
    public class Customer
    {
        public Order Order { get; set; }
        public int CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Product> Cart { get; set; }
        public List<Store> StoreLocations { get; set; }
        public List<Order> PastOrders { get; set; }

        public Customer()
        {
            Order = new Order();
            Cart = new List<Product>();
            StoreLocations = new List<Store>();
            PastOrders = new List<Order>();
        }
        public Customer(int customerId, string firstName, string lastName)
        {
            this.CustomerId = customerId;
            this.Firstname = firstName;
            this.Lastname = lastName;
            Order = new Order();
            Cart = new List<Product>();
            StoreLocations = new List<Store>();
            PastOrders = new List<Order>();
        }
    }
}
