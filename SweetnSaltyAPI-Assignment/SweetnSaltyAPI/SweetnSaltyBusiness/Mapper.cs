using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public class Mapper : IMapper
    {
        public Person EntitytoPerson(SqlDataReader dr)
        {
            return new Person()
            {
                PersonId = dr.GetInt32(0),
                Fname = dr.GetString(1),
                Lname = dr.GetString(2)
            };
        }

        public Flavor EntitytoFlavor(SqlDataReader dr)
        {
            return new Flavor()
            {
                FlavorId = dr.GetInt32(0),
                FlavorType = dr[1].ToString()
            };
        }
    }
}