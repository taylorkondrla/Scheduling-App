using C969_Oliver;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Oliver
{
    public class Appointments
    {
        //create attributes
        public int appointmentId { get; set; }
        public int userId { get; set; }
        public int customerId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string contact { get; set; } 
        
        public DateTime date { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }


        //Create DataTable to Hold Appointment Data for mainApptDataGrid
        public static DataTable appointmentsData = new DataTable();

        //Create Constructors

        public Appointments() { }

        public Appointments(int appointmentId, int userId, int customerId, string title, string description, string location, string type, string contact, DateTime start, DateTime end)
        {
            this.appointmentId = appointmentId;
            this.userId = userId;
            this.customerId = customerId;
            this.title = title;
            this.description = description;
            this.location = location;
            this.type = type;
            this.contact = contact;
            this.start = start;
            this.end = end;
        }

        //Methods for Appointment DataTable

        //get all appointments
        public static DataTable GetAllAppointments()
        {
            string connectionString = DBConnection.connection.ConnectionString; // Get the connection string
            string qry = "SELECT appointmentId, userId, customerId, title, description, location, type, contact, start, end " +
                         "FROM appointment";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(qry, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable appointmentsData = new DataTable();
                        adapter.Fill(appointmentsData);

                        foreach (DataRow row in appointmentsData.Rows)
                        {
                            row["start"] = ((DateTime)row["start"]).ToLocalTime();
                            row["end"] = ((DateTime)row["end"]).ToLocalTime();
                        }

                        return appointmentsData;
                    }
                }
            }
        }
        //create new appointments id
        public static int NewAppointmentID()
        {
            int newId = 0;

            string query = "SELECT MAX(appointmentId) AS 'newId' FROM appointmentd";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                newId = Convert.ToInt32(reader["newId"]) + 1;
            }
            reader.Close();

            return newId;
        }


        //create appointment
        public static void CreateAppointment(Appointments appointments)
        {
            string qry = $"INSERT INTO appointment " +
                $"VALUES ('{appointments.appointmentId}', '{appointments.userId}', '{appointments.customerId}', '{appointments.title}', '{appointments.description}', '{appointments.location}', '{appointments.type}', '{appointments.contact}', '{appointments.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{appointments.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser.userName}')";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            cmd.ExecuteNonQuery();
        }

        //Method to Delete Appointment

        public static bool DeleteAppointment(int appointmentId)
        {
            string qry = $"DELETE FROM appointment WHERE appointmentId = '{appointmentId}'";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            int rowsAffected = cmd.ExecuteNonQuery();

            // Check if any rows were affected (i.e., if the deletion was successful)
            return rowsAffected > 0;
        }

        //Method to Update Appointment
        public static void UpdateAppointment(Appointments appointments)
        {
            string qry =
                $"UPDATE appointment " +
                $"SET " +
                $"customerId = '{appointments.userId}', " +
                $"userId = '{appointments.customerId}', " +
                $"title = '{appointments.title}', " +
                $"description = '{appointments.description}', " +
                $"location = '{appointments.location}', " +
                $"contact = '{appointments.type}', " +
                $"type = '{appointments.contact}', " +
                $"start = '{appointments.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', " +
                $"end = '{appointments.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', " +
                $"lastUpdate = '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', " +
                $"lastUpdateBy = '{LogIn.currentUser.userName}' " +
                $"WHERE appointmentId = '{appointments.appointmentId}'";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            cmd.ExecuteNonQuery();
        }


        //Confirm New Appointments

        public static bool ConfirmBusinessHours(Appointments appointments)
        {
            DateTime businessStart = DateTime.Today.AddHours(8);
            DateTime businessEnd = DateTime.Today.AddHours(18);

            DateTime appointmentStart = DateTime.Parse(appointments.start.ToString());
            DateTime appointmentEnd = DateTime.Parse(appointments.end.ToString());

            if (appointmentStart.TimeOfDay >= businessStart.TimeOfDay && appointmentStart.TimeOfDay <= businessEnd.TimeOfDay && appointmentEnd.TimeOfDay > businessStart.TimeOfDay && appointmentEnd.TimeOfDay <= businessEnd.TimeOfDay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Confirm no conflict
        public static bool ConfirmNoConflict(Appointments appointments)
        {
            string qry = $"SELECT * FROM appointment WHERE userId = '{appointments.userId}' and ((start >= '{appointments.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' and start <= '{appointments.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}') or (end >= '{appointments.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' and end <= '{appointments.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}'))";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                return true;
            }
        }


        //get weekly appointments
        public static DataTable WeeklyAppointments()
        {
            // Create a new DataTable to store appointments
            DataTable appointmentsData = new DataTable();

            // Get the current date and the start of the current week (Sunday)
            DateTime currentDate = DateTime.Today;
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);

            // Construct SQL query to select appointments for the current week
            string qry = "SELECT appointmentId, customerId, userId, title, description, location, contact, type, date, start, end " +
                         "FROM appointment " +
                         $"WHERE start >= '{startOfWeek:yyyy-MM-dd}' " +
                         $"AND start < '{startOfWeek.AddDays(7):yyyy-MM-dd}'";

            // Execute the query and fill the DataTable
            using (MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(appointmentsData);
                }
            }

            // Convert start and end times to local timezone
            foreach (DataRow row in appointmentsData.Rows)
            {
                row["start"] = ((DateTime)row["start"]).ToLocalTime();
                row["end"] = ((DateTime)row["end"]).ToLocalTime();
            }

            // Return the DataTable containing appointments for the current week
            return appointmentsData;
        }

        //get monthly appointments
        public static DataTable MonthlyAppointments()
        {
            // Create a new DataTable to store appointments
            DataTable appointmentsData = new DataTable();

            // Construct SQL query to select appointments for the current month
            string qry = "SELECT appointmentId, customerId, userId, title, description, location, contact, type, date, start, end " +
                         "FROM appointment " +
                         $"WHERE start >= '{DateTime.Now:yyyy-MM-01}' " + // Start of current month
                         $"AND start < '{DateTime.Now.AddMonths(1):yyyy-MM-01}'"; // Start of next month

            // Execute the query and fill the DataTable
            using (MySqlCommand cmd = new MySqlCommand(qry, DBConnection.connection))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(appointmentsData);
                }
            }

            // Convert start and end times to local timezone
            foreach (DataRow row in appointmentsData.Rows)
            {
                row["start"] = ((DateTime)row["start"]).ToLocalTime();
                row["end"] = ((DateTime)row["end"]).ToLocalTime();
            }

            // Return the DataTable containing appointments for the current month
            return appointmentsData;
        }

    }
}
