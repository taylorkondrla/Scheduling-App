using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Oliver
{
    class City
    {
        // Properties
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        // Constructor
        public City() { }

        public City(int cityId, string name, int countryId)
        {
            CityId = cityId;
            Name = name;
            CountryId = countryId;
        }

        // Method to get new city ID
        public static int getNewCityID()
        {
            int newCityId = 0;
            using (MySqlCommand cmd = new MySqlCommand("SELECT MAX(cityId) FROM city", DBConnection.connection))
            {
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    newCityId = Convert.ToInt32(result) + 1;
                }
            }
            return newCityId;
        }

        // Method to create new city
        public static City addNewCity(string name, int countryId)
        {
            int newCityId = getNewCityID();
            DateTime currentTime = DateTime.UtcNow;
            string currentUser = LogIn.currentUser.userName;

            string query = $"INSERT INTO city (cityId, city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                           $"VALUES (@cityId, @name, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@cityId", newCityId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@countryId", countryId);
                cmd.Parameters.AddWithValue("@createDate", currentTime);
                cmd.Parameters.AddWithValue("@createdBy", currentUser);
                cmd.Parameters.AddWithValue("@lastUpdate", currentTime);
                cmd.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                cmd.ExecuteNonQuery();
            }

            return new City(newCityId, name, countryId);
        }

        // Method to get a city by name and country ID
        public static City getCity(string name, int countryId)
        {
            City city = null;

            string query = $"SELECT cityId, city, countryId FROM city WHERE city = @name AND countryId = @countryId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@countryId", countryId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        city = new City
                        {
                            CityId = reader.GetInt32("cityId"),
                            Name = reader.GetString("city"),
                            CountryId = reader.GetInt32("countryId")
                        };
                    }
                }
            }

            if (city == null)
            {
                city = addNewCity(name, countryId);
            }

            return city;
        }
    }
}
