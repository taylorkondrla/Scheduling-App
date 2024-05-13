using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Oliver
{
    class DataManager
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

        public static string createTimeStamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static DataTable GetCustomerReportDataForMonth(string month)
        {
            DataTable dataTable = new DataTable();
            string query = @"
                SELECT c.CustomerID, COUNT(a.AppointmentID) AS AppointmentCount
                FROM Customer c
                LEFT JOIN Appointment a ON c.CustomerID = a.CustomerID
                WHERE MONTH(a.createDate) = @Month
                GROUP BY c.CustomerID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Month", GetMonthNumber(month));
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public static DataTable GetAllAppointments()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Appointment";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public static DataTable GetWeeklyAppointments()
        {
            DataTable dataTable = new DataTable();
            string query = @"
        SELECT * 
        FROM Appointment 
        WHERE WEEK(createDate) = WEEK(CURDATE()) 
        ORDER BY createDate"; // Changed "Date" to "createDate"

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching weekly appointments: " + ex.Message);
            }

            return dataTable;
        }

        public static DataTable GetMonthlyAppointments()
        {
            DataTable dataTable = new DataTable();
            string query = @"
        SELECT * 
        FROM Appointment 
        WHERE MONTH(createDate) = MONTH(CURDATE()) 
        ORDER BY createDate"; // Changed "Date" to "createDate"

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching monthly appointments: " + ex.Message);
            }

            return dataTable;
        }

        public static DataTable GetAppointmentTypesForMonth(string month)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT Type, COUNT(*) AS Count FROM Appointment WHERE MONTH(createDate) = @Month GROUP BY Type";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Month", GetMonthNumber(month));
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private static int GetMonthNumber(string month)
        {
            try
            {
                return DateTime.ParseExact(month, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1; // Or handle the error in another appropriate way
            }
        }

        public static DataTable GetConsultants()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT userName FROM User";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while querying the database: " + ex.Message);
            }

            return dataTable;
        }

        public static DataTable GetAppointmentsForConsultant(string userName)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Appointment WHERE userName = @userName";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userName", userName);
                        connection.Open();
                        Console.WriteLine("Executing SQL query: " + query); // Debug statement
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while querying the database: " + ex.Message);
            }

            return dataTable;
        }
    }
}


