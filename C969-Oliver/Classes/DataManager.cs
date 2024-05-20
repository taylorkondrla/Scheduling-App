using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            SELECT c.customerId, COUNT(a.appointmentId) AS AppointmentCount
            FROM customer c
            LEFT JOIN appointment a ON c.customerId = a.customerId
            WHERE MONTH(a.start) = @Month
            GROUP BY c.customerId";

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
            string qry = @"
        SELECT appointmentId, customerId, userId, title, description, location, contact, type, url, start, end 
        FROM appointment 
        WHERE start >= @StartDate AND start <= @EndDate";

            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddDays(7);

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(qry, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

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
            string qry = @"
        SELECT appointmentId, customerId, userId, title, description, location, contact, type, url, start, end 
        FROM appointment 
        WHERE MONTH(start) = MONTH(CURDATE()) AND YEAR(start) = YEAR(CURDATE())";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(qry, connection))
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
            string query = "SELECT Type, COUNT(*) AS Count FROM Appointment WHERE MONTH(start) = @Month GROUP BY Type";

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
            string query = "SELECT userId, userName FROM User";

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

        public static DataTable GetAppointmentsForConsultant(int userId)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Appointment WHERE userId = @userId";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
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

       
    }
}


