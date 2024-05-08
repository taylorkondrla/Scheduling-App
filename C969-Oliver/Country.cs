using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
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
            int newCountryID = getNewCountryID();

            Country newCountry = new Country(newCountryID, countryName);

            string qry = $"INSERT INTO country " +
                $"VALUES ('{newCountryID}', '{countryName}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}')";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            cmd.ExecuteNonQuery();

            return newCountry;
        }

        // Method to get a country by name
        public static Country getCountry(string countryName)
        {
            Country country = null;

            // Query to retrieve country by name
            string query = $"SELECT countryId, country FROM country WHERE country = @countryName";

            // Execute the query
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
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

            return country;
        }
    }
}
