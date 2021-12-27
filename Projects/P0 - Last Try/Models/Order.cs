using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Orders should have:
    /// total cost
    /// 50 - 1 product limits
    /// $500 max
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }
        public int TotalCost { get; set; }

        public Order()
        {
            this.OrderId = 0;
            this.Products = new List<Product>();
            this.TotalCost = 0;
        }
    }
}
