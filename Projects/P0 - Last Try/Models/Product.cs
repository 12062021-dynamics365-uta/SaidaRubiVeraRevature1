using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Products: name, price, and description
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }

        public Product()
        {

        }
    }
}
