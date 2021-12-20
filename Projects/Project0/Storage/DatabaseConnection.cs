using System;
using System.Data.SqlClient;

namespace Storage
{
    public class DatabaseConnection
    {
        static void Main(string[] args)
        {
            //Creating connection to SQL
            SqlConnection connection = new SqlConnection("Data source = DESKTOP-7JH34M9\\SQLEXPRESS;initial Catalog = REIAppDB; integrated security = true");

            //My Query
            string querystring = "SELECT * FROM Customer;";

            //Open connection
            connection.Open();

            //Input query string to the query command line
            SqlCommand sqlCommand = new SqlCommand(querystring, connection);

            //Reads the query command
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Show result in console
            while (sqlDataReader.Read())
            {
                for (int i = 0; i >= 0; i++)
                {
                    Console.WriteLine(sqlDataReader[i].ToString());
                }
            }
            //Close connection
            connection.Close();

        }
    }
}
