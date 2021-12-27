using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace Storage
{
    public interface IMapper
    {
        Customer EntityToCustomer(SqlDataReader dr);
        List<Store> EntityToStoreLocations(SqlDataReader dr);
        List<Product> EntityToProductList(SqlDataReader dr);
        List<Order> EntityToOrderList(SqlDataReader dr);
    }
}

