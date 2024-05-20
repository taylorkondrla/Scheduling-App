using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace C969_Oliver
{
    public class Customer
    {
        // Attributes
        public int customerId { get; set; }
        public string customerName { get; set; }

        public string address { get; set; }

        public string address2 { get; set; }

        public string city { get; set; }

        public string country { get; set; }

        public string zipCode { get; set; }

        public string phone { get; set; }
        public int addressId { get; set; }
        public int active { get; set; }

        // Data table holding customer info
        public static DataTable customers = new DataTable();

        // Constructor
        public Customer() { }


        //get a new customer ID
        public static int GetNewCustomerID()
        {
            int newID = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    connection.Open();

                    string queryString = "SELECT MAX(customerId) AS 'newId' FROM customer";

                    using (MySqlCommand cmd = new MySqlCommand(queryString, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                newID = Convert.ToInt32(reader["newId"]);
                                newID += 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("An error occurred while fetching a new customer ID: " + ex.Message);
            }

            return newID;
        }

        //Add new customer
        public static void AddCustomer(string customerName, int addressId, int active)
        {
            try
            {
                // Open the database connection
                DBConnection.OpenConnection();

                int newCustomerId = GetNewCustomerID();
                string timestamp = DataManager.createTimeStamp();
                string uname = User.GetUserByName(customerName).userName; 

                string qry = $"INSERT INTO customer " +
                             $"VALUES ('{newCustomerId}', '{customerName}', '{addressId}', '{active}', '{timestamp}', '{uname}', '{timestamp}', '{uname}')";

                MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding a new customer: {ex.Message}");
            }
            finally
            {
                // Close the database connection
                DBConnection.CloseConnection();
            }
        }

        //Get customer by name
        public static Customer GetCustomerByName(string customerName)
        {
            Customer customer = new Customer();
            string qry = $"SELECT customerId, customerName, addressId, active FROM customer WHERE customerName = '{customerName}'";
            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
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

        //Gets customer by ID
        public static Customer GetCustomerById(int customerId)
        {
            Customer customer = new Customer();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    connection.Open();

                    string qry = $"SELECT customerId, customerName, addressId, active FROM customer WHERE customerId = '{customerId}'";

                    using (MySqlCommand cmd = new MySqlCommand(qry, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching customer data: " + ex.Message);
            }

            return customer;
        }

        //Get list of all customers
        public static List<Customer> GetListCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            string query = "SELECT * FROM customer;";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.Connection);
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

            try
            {
               
                DBConnection.OpenConnection();

                string qry = $"SELECT customerId FROM customer WHERE customerName = '{customerName}'";
                MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if any rows are returned
                    if (reader.HasRows)
                    {
                        customerExists = true;
                        MessageBox.Show("Customer already exists. Please update customer record.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while confirming customer existence: " + ex.Message);
            }
            finally
            {
                DBConnection.CloseConnection();
            }

            return customerExists;
        }

        //modify  customer
        public static void ModifyCustomer(int customerId, string customerName, int addressId, int active)
        {
            string timestamp = DataManager.createTimeStamp();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    connection.Open();

                    // Fetch the lastUpdateBy value from the database
                    string uname = User.GetUserByName(customerName).userName;

                    string qry = $"UPDATE customer " +
                                 $"SET customerName = '{customerName}', " +
                                 $"addressId = '{addressId}', " +
                                 $"active = '{active}', " +
                                 $"lastUpdate = '{timestamp}', " +
                                 $"lastUpdateBy = '{uname}' " + // uname is declared and assigned
                                 $"WHERE customerId = '{customerId}'";

                    using (MySqlCommand cmd = new MySqlCommand(qry, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while modifying customer: " + ex.Message);
            }
        }

        //Delete  customer
        public static bool DeleteCustomer(int customerId)
        {
            try
            {
                // Open the database connection
                DBConnection.OpenConnection();

                // Delete appointments associated with the customer
                string appointmentQuery = $"DELETE FROM appointment WHERE customerId = '{customerId}'";
                MySqlCommand appointmentCmd = new MySqlCommand(appointmentQuery, DBConnection.Connection);
                appointmentCmd.ExecuteNonQuery();

                // Delete the customer
                string customerQuery = $"DELETE FROM customer WHERE customerId = '{customerId}'";
                MySqlCommand customerCmd = new MySqlCommand(customerQuery, DBConnection.Connection);
                customerCmd.ExecuteNonQuery();

                // Close the database connection
                DBConnection.CloseConnection();

                return true; // Deletion successful
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete customer: {ex.Message}");
                return false; // Deletion failed
            }
            finally
            {
                // Make sure to close the connection in case of an exception
                DBConnection.CloseConnection();
            }
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

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(customers);
            return customers;
        }
    }
}
