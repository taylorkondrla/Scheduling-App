using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Oliver
{
    // Connect to database
    public static class DBConnection
    {
        public static MySqlConnection connection;

        // Get the connection instance
        public static MySqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Connection has not been initialized.");
                }
                return connection;
            }
        }

        // Open connection
        public static void OpenConnection()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                // Log or throw the exception for better error handling
                throw new Exception("Failed to open database connection.", ex);
            }
        }

        // Close connection
        public static void CloseConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                // Log or throw the exception for better error handling
                throw new Exception("Failed to close database connection.", ex);
            }
        }
    }
}
