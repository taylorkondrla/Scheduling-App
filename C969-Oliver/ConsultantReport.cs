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
    public partial class ConsultantReport : Form
    {
        public ConsultantReport()
        {
            InitializeComponent();
            // Populate the dropdown with consultant names
            PopulateConsultantsDropDown();
        }

        private void PopulateConsultantsDropDown()
        {
            // Fetch the list of consultants from the database
            DataTable consultants = GetConsultantsFromDatabase();

            // Clear existing items and add the consultants to the dropdown
            consultantDropDown.Items.Clear();
            foreach (DataRow row in consultants.Rows)
            {
                consultantDropDown.Items.Add(row["ConsultantName"].ToString());
            }
        }
        //query the database to get the list of consultants
        private DataTable GetConsultantsFromDatabase()
        {
            
            DataTable dataTable = new DataTable();
            string query = "SELECT userName FROM Users";

            using (MySqlConnection connection = new MySqlConnection("YourConnectionString"))
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

        private void consultantDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When a consultant is selected from the dropdown, load appointments for that consultant
            LoadAppointmentsForConsultant();
        }

        private void LoadAppointmentsForConsultant()
        {
            // Get the selected consultant from the dropdown
            string selectedConsultant = consultantDropDown.SelectedItem.ToString();

            // Fetch appointments for the selected consultant from the database
            DataTable appointments = GetAppointmentsForConsultantFromDatabase(selectedConsultant);

            // Populate the DataGridView with the fetched appointments
            consultantReportDataGrid.DataSource = appointments;
        }


        //query the database to get teh appointments for the selected consultant
        private DataTable GetAppointmentsForConsultantFromDatabase(string userName)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM Appointments WHERE userName = @userName";

            using (MySqlConnection connection = new MySqlConnection("YourConnectionString"))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userName", userName);
                    connection.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void btnCloseConsultantReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
