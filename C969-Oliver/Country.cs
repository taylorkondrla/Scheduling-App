using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Oliver
{
    class Country
    {
        // Properties
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        // Constructors
        public Country() { }

        public Country(int countryId, string countryName)
        {
            CountryId = countryId;
            CountryName = countryName;
        }

        // Method to retrieve a new country ID
        public static int getNewCountryID()
        {
            int newCountryID = 0;

            // Query to retrieve the maximum country ID
            string query = "SELECT MAX(countryId) AS 'newCountryID' FROM country";

            // Execute the query
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Connection))
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        newCountryID = Convert.ToInt32(rdr["newCountryID"]) + 1;
                    }
                }
            }

            return newCountryID;
        }

        // Method to add new country
        public static Country addNewCountry(string countryName)
        {
            try
            {
                // Ensure the database connection is opened before executing the query
                DBConnection.OpenConnection();

                int newCountryID = getNewCountryID();

                Country newCountry = new Country(newCountryID, countryName);

                string currentUser = LogIn.currentUser != null ? LogIn.currentUser.userName : "Unknown";

                string qry = $"INSERT INTO country " +
                             $"VALUES ('{newCountryID}', '{countryName}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{currentUser}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{currentUser}')";

                MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
                cmd.ExecuteNonQuery();

                return newCountry;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log or display error message)
                MessageBox.Show("An error occurred while trying to add a new country: " + ex.Message);
                return null; // Return null to indicate failure
            }
            finally
            {
                // Always ensure the connection is properly closed after use
                DBConnection.CloseConnection();
            }
        }

        // Method to get a country by name
        public static Country getCountry(string countryName)
        {
            Country country = null;

            try
            {
                // Ensure the database connection is opened before executing the query
                DBConnection.OpenConnection();

                // Query to retrieve country by name
                string query = $"SELECT countryId, country FROM country WHERE country = @countryName";

                // Execute the query
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Connection))
                {
                    cmd.Parameters.AddWithValue("@countryName", countryName);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            country = new Country
                            {
                                CountryId = Convert.ToInt32(rdr["countryId"]),
                                CountryName = rdr["country"].ToString()
                            };
                        }
                    }
                }

                // If country doesn't exist, create a new one
                if (country == null)
                {
                    country = addNewCountry(countryName);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log or display error message)
                MessageBox.Show("An error occurred while trying to retrieve country data: " + ex.Message);
            }
            finally
            {
                // Always ensure the connection is properly closed after use
                DBConnection.CloseConnection();
            }

            return country;
        }
    }
}
