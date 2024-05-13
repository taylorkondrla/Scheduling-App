using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            string query = "SELECT MAX(addressId) AS 'newAddressID' FROM address";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                newAddressID = Convert.ToInt32(reader["newAddressID"]) + 1;
            }
            reader.Close();
            return newAddressID;
        }
        public static Address GetAddress(string address, string address2, int cityId, string postalCode, string phone)
        {
            Address getAddress = new Address();
            string query = $"SELECT addressId, address, cityId, postalCode, phone " +
                $"FROM address " +
                $"WHERE address = '{address}' " +
                $"and address2 = '{address2}' " +
                $"and cityId = '{cityId}' " +
                $"and postalCode = '{postalCode}' " +
                $"and phone = '{phone}' ";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

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
            reader.Close();

            if (getAddress.addressID == 0)
            {
                getAddress = CreateNewAddress(address, address2, cityId, postalCode, phone);
            }
            return getAddress;

        }
        //create a new address
        public static Address CreateNewAddress(string address, string address2, int cityId, string postalCode, string phone)
        {
            Address newAddress = new Address(NewAddressId(), address, address2, cityId, postalCode, phone);

            string qry = "INSERT INTO address " +
                $"VALUES ('{newAddress.addressID}', '{newAddress.address}', '{newAddress.address2}', '{newAddress.cityId}', '{newAddress.postalCode}', '{newAddress.phone}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}')";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
            cmd.ExecuteNonQuery();

            return newAddress;
        }
    }
}

