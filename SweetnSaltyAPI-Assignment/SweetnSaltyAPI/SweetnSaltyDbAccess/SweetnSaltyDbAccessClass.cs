using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyDbAccess
{
    public class SweetnSaltyDbAccessClass : ISweetnSaltyDbAccessClass
    {
        private readonly string str = "Data source = DESKTOP-7JH34M9\\SQLEXPRESS;initial Catalog = SweetnSalty; integrated security = true";
        private readonly SqlConnection _con;

        //constructor
        public SweetnSaltyDbAccessClass()
        {
            this._con = new SqlConnection(this.str);
            _con.Open();
        }

        public async Task<SqlDataReader> PostFlavor(string flavor)
        {
            string sql = $"INSERT INTO Flavors VALUES (@flavortype);";
            using (SqlCommand cmd = new SqlCommand(sql, this._con))
            {
                cmd.Parameters.AddWithValue("@flavortype", flavor);
                await cmd.ExecuteNonQueryAsync();
                string retrieveFlavor = "SELECT TOP 1 * FROM Flavors ORDER BY FlavorId DESC;";
                using (SqlCommand cmd1 = new SqlCommand(retrieveFlavor, this._con))
                {
                    SqlDataReader dr = await cmd1.ExecuteReaderAsync();
                    return dr;
                }
               
            }
        }

        public async Task<SqlDataReader> PostPerson(string fname, string lname)
        {
            string sql = $"INSERT INTO Persons VALUES ('@FirstsName', '@LastName');";
            using (SqlCommand cmd = new SqlCommand(sql, this._con))
            {
                cmd.Parameters.AddWithValue("@FirstsName", fname);
                cmd.Parameters.AddWithValue("@LastName", lname);
                await cmd.ExecuteNonQueryAsync();
                string retrievePerson = "SELECT TOP 1 * FROM Persons ORDER BY PersonId DESC;";
                using (SqlCommand cmd1 = new SqlCommand(retrievePerson, this._con))
                {
                   SqlDataReader dr = await cmd1.ExecuteReaderAsync();
                   return dr;
                }
            }
        }

        public async Task<SqlDataReader> GetPerson(string fname, string lname)
        {
            string sql = $"SELECT * FROM Persons WHERE FirstName = '@FirstName' AND LastName = '@LastName';";
            using (SqlCommand cmd = new SqlCommand(sql, this._con))
            {
                cmd.Parameters.AddWithValue("@FirstName", fname);
                cmd.Parameters.AddWithValue("@LastName", lname);
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }

        }

        public async Task<SqlDataReader> FindPerson(int personId)
        {
            string sql = $"SELECT * FROM Persons WHERE PersonId = @personId;";
            using (SqlCommand cmd = new SqlCommand(sql, this._con))
            {
                cmd.Parameters.AddWithValue("@personId", personId);
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }

        }

        public async void LikesFlavor(int personId, int flavorId)
        {
            string sql = $"INSERT INTO PersonFlavorJunction VALUES (@personId, @flavorId);";
            using (SqlCommand cmd = new SqlCommand(sql, this._con))
            {
                cmd.Parameters.AddWithValue("@personId", personId);
                cmd.Parameters.AddWithValue("@flavorId", flavorId);
                await cmd.ExecuteNonQueryAsync();
            }

        }


        public async Task<SqlDataReader> FindFlavor(string flavor)
        {
            string sql = $"SELECT * FROM Flavors WHERE Flaver = '@flavortype';";
            using (SqlCommand cmd = new SqlCommand(sql, this._con))
            {
                cmd.Parameters.AddWithValue("@flavor", flavor);
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
               
            }
        }

        public async Task<SqlDataReader> GetPersonAndFlavors(int personId)
        {
            string sql = $"SELECT Flavors.FlavorId, Flavors.Flaver FROM Flavor JOIN PersonFlavorJunction " +
                $"ON Flavors.FlavorId = PersonFlavorJunction.FlavorId AND PersonFlavorJunction.PersonId = @personId;";
            using (SqlCommand cmd = new SqlCommand(sql, this._con))
            {
                cmd.Parameters.AddWithValue("@personId", personId);
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
        }

        public async Task<SqlDataReader> GetFlavors()
        {
            string sql = $"SELECT * FROM Flavors;";
            using (SqlCommand cmd = new SqlCommand(sql, this._con))
            {
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return dr;
            }
        }

    }
}