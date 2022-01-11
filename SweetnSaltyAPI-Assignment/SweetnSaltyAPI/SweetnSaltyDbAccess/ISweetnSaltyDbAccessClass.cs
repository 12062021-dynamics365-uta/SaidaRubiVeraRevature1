using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetnSaltyDbAccess
{
    public interface ISweetnSaltyDbAccessClass
    {
        Task<SqlDataReader> PostFlavor(string flavor);
        Task<SqlDataReader> PostPerson(string fname, string lname);
        Task<SqlDataReader> GetFlavors();
        Task<SqlDataReader> GetPerson(string fname, string lname);
        Task<SqlDataReader> FindFlavor(string flavor);
        Task<SqlDataReader> FindPerson(int personId);
        Task<SqlDataReader> GetPersonAndFlavors(int personId);
        void LikesFlavor(int personId, int flavorId);
    }
}
