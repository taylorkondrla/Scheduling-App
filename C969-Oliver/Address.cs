using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Oliver
{
    class Address
    {
        //attributes
        public int addressID { get; set; }
        public string address {  get; set; }   
        public int cityId { get; set; }
        public string zipCode { get; set; }
        public string phone { get; set; }


        //constructors
        public Address() { }

        public Address(int addressID, string address, int cityId, string zipCode, string phone)
        {
            this.addressID = addressID;
            this.address = address;
            this.cityId = cityId;
            this.zipCode = zipCode;
            this.phone = phone;
        }
        //method get data from address table
        public static int NewAddressId()
        {
            int newAddressID = 0;
            string query = "SELECT MAX(addressId) AS 'newAdressID' FROM address";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                newAddressID = Convert.ToInt32(reader["newAddressID"]) + 1;
            }
            reader.Close();
            return newAddressID;
        }
        public static Address GetAddress(string address, int cityId, string zipCode, string phone)
        {
            Address getAddress = new Address();
            string query = $"SELECT addressId, address, cityId, zipCode, phone " +
                $"FROM address " +
                $"WHERE address = '{address}' " +
                $"and cityId = '{cityId}' " +
                $"and zipCode = '{zipCode}' " +
                $"and phone = '{phone}' ";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    getAddress.addressID = Convert.ToInt32(reader["addressId"]);
                    getAddress.address = reader["address"].ToString();
                    getAddress.cityId = Convert.ToInt32(reader["cityId"]);
                    getAddress.zipCode = reader["zipCode"].ToString();
                    getAddress.phone = reader["phone"].ToString();
                }
            }
            reader.Close();

            if (getAddress.addressID == 0)
            {
                getAddress = CreateNewAddress(address, cityId, zipCode, phone);
            }
            return getAddress;

        }
        //create a new address
        public static Address CreateNewAddress(string address, int cityId, string zipCode, string phone)
        {
            User currentUser = LogIn.GetCurrentUser(); // Retrieve the currentUser object
            Address newAddress = new Address(NewAddressId(), address, cityId, zipCode, phone);
            string query = "INSERT INTO address " +
                $"VALUES ('{newAddress.addressID}', '{newAddress.address}', '{newAddress.cityId}', '{newAddress.zipCode}', '{newAddress.phone}', '{DateTime.Now.ToUniversalTime().ToString("yyy-MM-dd HH:mm:ss")}', '{currentUser.userName}', '{DateTime.Now.ToUniversalTime().ToString("yyy-MM-dd HH:mm:ss")}', '{currentUser.userName}')";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection);
            cmd.ExecuteNonQuery();
            return newAddress;
        }










    }
}
