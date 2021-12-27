using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// View past sales; store locations
    /// extra - manage product inventory
    /// </summary>
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreLocation { get; set; }
        public List<Product> Products { get; set; }

        public Store()
        {
            Products = new List<Product>();
        }

        public Store(int storeId, string storeLocation)
        {
            this.StoreId = storeId;
            this.StoreLocation = storeLocation;
            Products = new List<Product>();
        }
    }
}
