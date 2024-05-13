using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Oliver
{
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
            LoadEventHandlers(); // Load event handlers for radio buttons
        }

        private void LoadEventHandlers()
        {
            //add event handlers for radio buttons
            rdbtnJanCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnFebCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnMarCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnAprCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnMayCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnJunCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnJulCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnAugCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnSepCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnOctCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnNovCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnDecCR.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                string month = radioButton.Text.Substring(6);
                //populate the data grid with customer report data for the selected month
                PopulateCustomerReportDataGrid(month); 
            }
        }

        private void PopulateCustomerReportDataGrid(string month)
        {
            DataTable dataTable = GetCustomerReportDataForMonth(month);
            customerReportDataGrid.DataSource = dataTable; 
        }

        private DataTable GetCustomerReportDataForMonth(string month)
        {
            DataTable dataTable = new DataTable(); 
            string query = @"
                SELECT c.CustomerID, COUNT(a.AppointmentID) AS AppointmentCount
                FROM Customers c
                LEFT JOIN Appointments a ON c.CustomerID = a.CustomerID
                WHERE MONTH(a.Date) = @Month
                GROUP BY c.CustomerID";

            //execute the SQL query
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connection.ConnectionString))
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

            return dataTable; // Return the populated DataTable
        }

        private int GetMonthNumber(string month)
        {
            return DateTime.ParseExact(month, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;
        }
    }   
}
