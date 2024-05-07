using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Oliver
{
    public class Customer
    {
        // Attributes
        public int customerId { get; set; }
        public string customerName { get; set; }
        public int addressId { get; set; }
        public int active { get; set; }

        // DataTable to hold customer info
        private static DataTable customers = new DataTable();

        // Constructor
        public Customer() { }

        // Methods

        // Retrieve a new unique customer ID
        public static int GetNewCustomerID()
        {
            int newID = 0;
            string queryString = "SELECT MAX(customerId) AS 'newId' FROM customer";
            MySqlCommand cmd = new MySqlCommand(queryString, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                newID = Convert.ToInt32(rdr[0]);
                newID += 1;
            }
            reader.Close();
            return newID;
        }

        //Add new customer
        public static void AddCustomer(string customerName, int addressId, int active)
        {
            int newCustomerId = GetNewCustomerID();
            string timestamp = DataManager.createTimeStamp();
            string uname = DataManager.getCurrentUserName();

            string qry = $"INSERT INTO customer " +
                         $"VALUES ('{newCustomerId}', '{customerName}', '{addressId}', '{active}', '{timestamp}', '{uname}', '{timestamp}', '{uname}')";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            cmd.ExecuteNonQuery();
        }

        //Get customer by name
        public static Customer GetCustomerByName(string customerName)
        {
            Customer customer = new Customer();
            string qry = $"SELECT customerId, customerName, addressId, active FROM customer WHERE customerName = '{customerName}'";
            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    customer.customerId = Convert.ToInt32(reader["customerId"]);
                    customer.customerName = reader["customerName"].ToString();
                    customer.addressId = Convert.ToInt32(reader["addressId"]);
                    customer.active = Convert.ToInt32(reader["active"]);
                }
            }
            reader.Close();
            return customer;
        }

        //Geta customer by ID
        public static Customer GetCustomerById(int customerId)
        {
            Customer customer = new Customer();
            string qry = $"SELECT customerId, customerName, addressId, active FROM customer WHERE customerId = '{customerId}'";
            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (rdr.HasRows)
                {
                    customer.customerId = Convert.ToInt32(reader["customerId"]);
                    customer.customerName = reader["customerName"].ToString();
                    customer.addressId = Convert.ToInt32(reader["addressId"]);
                    customer.active = Convert.ToInt32(reader["active"]);
                }
            }
            reader.Close();
            return customer;
        }

        //Get list of all customers
        public static List<Customer> GetListCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            string query = "SELECT * FROM customer;";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.customerId = Convert.ToInt32(reader["customerId"]);
                customer.customerName = reader["customerName"].ToString();
                customer.addressId = Convert.ToInt32(reader["addressId"]);
                customer.active = Convert.ToInt32(reader["active"]);
                customerList.Add(customer);
            }
            reader.Close();
            return customerList;
        }

        //Confirm customer doesn't already exist
        public static bool ConfirmCustomer(string customerName)
        {
            bool customerExists = false;
            string qry = $"SELECT customerId, customerName, addressId, active FROM customer WHERE customerName = '{customerName}'";
            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    customerExists = true;
                    MessageBox.Show("Customer already exists. Please update customer record.");
                }
            }
            reader.Close();
            return customerExists;
        }

        //Update  customer
        public static void UpdateCustomer(int customerId, string customerName, int addressId, int active)
        {
            string timestamp = DataManager.createTimeStamp();
            string qry = $"UPDATE customer " +
                         $"SET customerName = '{customerName}', " +
                         $"addressId = '{addressId}', " +
                         $"active = '{active}', " +
                         $"lastUpdate = '{timestamp}', " +
                         $"lastUpdateBy = '{DataManager.getCurrentUserName()}' " +
                         $"WHERE customerId = '{customerId}'";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            cmd.ExecuteNonQuery();
        }

        //Delete  customer
        public static void DeleteCustomer(int customerId)
        {
            string qry = $"DELETE FROM appointment WHERE customerId = '{customerId}'";
            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            cmd.ExecuteNonQuery();

            qry = $"DELETE FROM customer WHERE customerId = '{customerId}'";
            cmd = new MySqlCommand(qry, DBConnection.connection);
            cmd.ExecuteNonQuery();
        }

        //Get customer information from the database
        public static DataTable GetCustomerInfo()
        {
            string qry = "SELECT customerId, customerName, address, address2, city, country, postalCode, phone " +
                         "FROM customer " +
                         "INNER JOIN address " +
                         "ON customer.addressId = address.addressId " +
                         "INNER JOIN city " +
                         "ON address.cityId = city.cityId " +
                         "INNER JOIN country " +
                         "ON city.countryId = country.countryId";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(customers);
            return customers;
        }
    }
}
