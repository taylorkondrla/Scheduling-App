using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Oliver
{
    class City
    {
     
    //Setup Attributes

        public int cityId { get; set; }
        public string city { get; set; }
        public int countryId { get; set; }

        //Setup Constructors

        public City() { }

        public City(int cityId, string city, int countryId)
        {
            this.cityId = cityId;
            this.city = city;
            this.countryId = countryId;
        }

        //Methods to Create a New City

        public static int GetNewCityID()
        {
            int newCityId = 0;

            DBConnection.OpenConnection(); // Open the database connection

            try
            {
                string qry = "SELECT MAX(cityId) AS newCityId FROM city";
                MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    newCityId = rdr.GetInt32(0) + 1;
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to fetch the new city ID: " + ex.Message);
            }

            return newCityId;
        }

        public static City CreateNewCity(string city, int countryId)
        {
            City newCity = new City(GetNewCityID(), city, countryId);

            string qry = $"INSERT INTO city " +
                $"VALUES ('{newCity.cityId}', '{newCity.city}', '{newCity.countryId}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}')";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
            cmd.ExecuteNonQuery();

            return newCity;
        }

        //Method to get data from City table

        public static City GetCity(string city, int countryId)
        {
            City getCity = new City();

            DBConnection.OpenConnection(); // Open the database connection

            try
            {
                string qry = $"SELECT cityId, city, countryId FROM city WHERE city = '{city}' AND countryId = '{countryId}'";
                MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    getCity.cityId = rdr.GetInt32(0);
                    getCity.city = rdr.GetString(1);
                    getCity.countryId = rdr.GetInt32(2);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to fetch city data: " + ex.Message);
            }

            return getCity;
        }
    }
}
