﻿using C969_Oliver;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string url { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }


        //Create DataTable to Hold Appointment Data for mainApptDataGrid
        public static DataTable appointmentsData = new DataTable();

        //Create Constructors

        public Appointments() { }

        public Appointments(int appointmentId, int userId, int customerId, string title, string description, string location, string type, string contact, string url, DateTime start, DateTime end)
        {
            this.appointmentId = appointmentId;
            this.userId = userId;
            this.customerId = customerId;
            this.title = title;
            this.description = description;
            this.location = location;
            this.type = type;
            this.contact = contact;
            this.url = url;

            this.start = start;
            this.end = end;
        }

        //Methods for Appointment DataTable

        //get all appointments
        public static DataTable GetAllAppointments()
        {
            DBConnection.OpenConnection();
            appointmentsData.Clear();

            string qry = "SELECT appointmentId, customerId, userId, title, description, location, contact, type, url, start, end " +
                "FROM appointment";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

            adp.Fill(appointmentsData);

            for (int i = 0; i < appointmentsData.Rows.Count; i++)
            {
                DateTime start = (DateTime)appointmentsData.Rows[i]["start"];
                appointmentsData.Rows[i]["start"] = start.ToLocalTime();

                DateTime end = (DateTime)appointmentsData.Rows[i]["end"];
                appointmentsData.Rows[i]["end"] = end.ToLocalTime();

            }

            return appointmentsData;
        }
        //create new appointments id
        public static int NewAppointmentID()
        {
            int newId = 0;

            string query = "SELECT MAX(appointmentId) AS 'newId' FROM appointment";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.Connection);
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
            try
            {
                string qry = $"INSERT INTO appointment " +
                    $"VALUES ('{appointments.appointmentId}', '{appointments.userId}', '{appointments.customerId}', '{appointments.title}', '{appointments.description}', '{appointments.location}', '{appointments.type}', '{appointments.contact}', '{appointments.url}', '{appointments.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{appointments.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser?.userName ?? "Unknown"}', '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', '{LogIn.currentUser?.userName ?? "Unknown"}')";

                MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               //exception handling
                MessageBox.Show($"Error occurred while creating appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delete Appointment

        public static bool DeleteAppointment(int appointmentId)
        {
            try
            {
                string qry = $"DELETE FROM appointment WHERE appointmentId = '{appointmentId}'";
                MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                //exception handling
                MessageBox.Show($"Error occurred while deleting appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Method to Update Appointment
        public static void UpdateAppointment(Appointments appointments)
        {
            try
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
                    $"url = '{appointments.url}', " +
                    $"start = '{appointments.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', " +
                    $"end = '{appointments.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', " +
                    $"lastUpdate = '{DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}', " +
                    $"lastUpdateBy = '{LogIn.currentUser.userName}' " +
                    $"WHERE appointmentId = '{appointments.appointmentId}'";

                MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //exception handling
                MessageBox.Show($"Error occurred while updating appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Confirm New Appointments

        public static bool ConfirmBusinessHours(Appointments appointments)
        {
            // Convert appointment start and end times to EST
            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            // Specify the time zone for the input DateTime objects 
            DateTimeOffset appointmentStartOffset = new DateTimeOffset(appointments.start, TimeZoneInfo.Local.GetUtcOffset(appointments.start));
            DateTimeOffset appointmentEndOffset = new DateTimeOffset(appointments.end, TimeZoneInfo.Local.GetUtcOffset(appointments.end));

            // Convert the input DateTime objects to EST
            DateTimeOffset appointmentStartEst = TimeZoneInfo.ConvertTime(appointmentStartOffset, estTimeZone);
            DateTimeOffset appointmentEndEst = TimeZoneInfo.ConvertTime(appointmentEndOffset, estTimeZone);

            // Check if appointment falls within business hours 
            if (appointmentStartEst.DayOfWeek >= DayOfWeek.Monday && appointmentStartEst.DayOfWeek <= DayOfWeek.Friday &&
                appointmentStartEst.TimeOfDay >= new TimeSpan(9, 0, 0) && appointmentEndEst.TimeOfDay <= new TimeSpan(17, 0, 0))
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
            string qry = $"SELECT * FROM appointment WHERE userId = '{appointments.userId}' " +
                     $"AND appointmentId != '{appointments.appointmentId}' " +
                     $"AND ((start >= '{appointments.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' AND start <= '{appointments.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}') " +
                     $"OR (end >= '{appointments.start.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' AND end <= '{appointments.end.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}'))";

            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            bool hasConflict = reader.HasRows;
            reader.Close();

            return !hasConflict;
        }


        //get weekly appointments
        public static DataTable WeeklyAppointments()
        {
            // Create a new DataTable to store appointments
            DataTable appointmentsData = new DataTable();

            
            DateTime currentDate = DateTime.Today;
            DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);

            
            string qry = "SELECT appointmentId, customerId, userId, title, description, location, contact, type, date, start, end " +
                         "FROM appointment " +
                         $"WHERE start >= '{startOfWeek:yyyy-MM-dd}' " +
                         $"AND start < '{startOfWeek.AddDays(7):yyyy-MM-dd}'";

            
            using (MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection))
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

            
            return appointmentsData;
        }

        //get monthly appointments
        public static DataTable MonthlyAppointments()
        {
            
            DataTable appointmentsData = new DataTable();

            
            string qry = "SELECT appointmentId, customerId, userId, title, description, location, contact, type, date, start, end " +
                         "FROM appointment " +
                         $"WHERE start >= '{DateTime.Now:yyyy-MM-01}' " + 
                         $"AND start < '{DateTime.Now.AddMonths(1):yyyy-MM-01}'"; 

            
            using (MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection))
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

            
            return appointmentsData;
        }
        // Get distinct user IDs from the appointments table
        public static List<int> GetDistinctUserIds()
        {
            List<int> userIds = new List<int>();

            
            string query = "SELECT DISTINCT userId FROM appointment";

            
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32("userId");
                        userIds.Add(userId);
                    }
                }
            }

            return userIds;
        }

        // Get distinct customer IDs from the customer table
        public static List<int> GetDistinctCustomerIds()
        {
            List<int> customerIds = new List<int>();

            
            string query = "SELECT DISTINCT customerId FROM customer";

            
            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        int customerId = reader.GetInt32("customerId");
                        customerIds.Add(customerId);
                    }
                }
            }

            return customerIds;
        }

    }
}
