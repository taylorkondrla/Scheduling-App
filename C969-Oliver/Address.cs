using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Oliver
{
   class Address
   {
        //attributes
        public int addressID { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public int cityId { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }


        //constructors
        public Address() { }

        public Address(int addressID, string address, string address2, int cityId, string postalCode, string phone)
        {
            this.addressID = addressID;
            this.address = address;
            this.address2 = address2;
            this.cityId = cityId;
            this.postalCode = postalCode;
            this.phone = phone;
        }
        //method get data from address table
        public static int NewAddressId()
        {
            int newAddressID = 0;

            try
            {
                // Ensure the database connection is open
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT MAX(addressId) AS 'newAddressID' FROM address";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                newAddressID = reader.IsDBNull(0) ? 1 : Convert.ToInt32(reader["newAddressID"]) + 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (log, display error message, etc.)
                MessageBox.Show("An error occurred while fetching the new address ID: " + ex.Message);
            }

            return newAddressID;
        }

        //get address
        public static Address GetAddress(string address, string address2, int cityId, string postalCode, string phone)
        {
            Address getAddress = new Address();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT addressId, address, cityId, postalCode, phone " +
                                   $"FROM address " +
                                   $"WHERE address = '{address}' " +
                                   $"and address2 = '{address2}' " +
                                   $"and cityId = '{cityId}' " +
                                   $"and postalCode = '{postalCode}' " +
                                   $"and phone = '{phone}' ";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.HasRows)
                                {
                                    getAddress.addressID = Convert.ToInt32(reader["addressId"]);
                                    getAddress.address = reader["address"].ToString();
                                    getAddress.address2 = reader["address2"].ToString();
                                    getAddress.cityId = Convert.ToInt32(reader["cityId"]);
                                    getAddress.postalCode = reader["postalCode"].ToString();
                                    getAddress.phone = reader["phone"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to fetch address data: " + ex.Message);
            }

            if (getAddress.addressID == 0)
            {
                getAddress = CreateNewAddress(address, address2, cityId, postalCode, phone);
            }

            return getAddress;

        }

        //create a new address
        public static Address CreateNewAddress(string address, string address2, int cityId, string postalCode, string phone)
        {
            try
            {
                // Ensure the database connection is open
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    connection.Open();

                    Address newAddress = new Address(NewAddressId(), address, address2, cityId, postalCode, phone);

                    string qry = "INSERT INTO address " +
                        $"VALUES ('{newAddress.addressID}', '{newAddress.address}', '{newAddress.address2}', '{newAddress.cityId}', '{newAddress.postalCode}', '{newAddress.phone}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}')";

                    using (MySqlCommand cmd = new MySqlCommand(qry, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    return newAddress;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (log, display error message, etc.)
                MessageBox.Show("An error occurred while creating a new address: " + ex.Message);
                return null;
            }
        }
    }
}

