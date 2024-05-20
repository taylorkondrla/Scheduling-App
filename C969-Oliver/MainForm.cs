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
    public partial class MainForm : Form
    {
        public LogIn LogInForm;

        public MainForm()
        {
            InitializeComponent();
            //Populate appointment data
            refreshAppointmentDataGrid();

            refreshCustomerDataGrid();

        }

        //reminder appointment within 15 minutes
        public void AppointmentReminder()
        {
            foreach (DataGridViewRow row in mainApptDataGrid.Rows)
            {
                DateTime now = DateTime.Now;
                DateTime start = Convert.ToDateTime(row.Cells["start"].Value);
                TimeSpan timeLeft = start - now;
                if (timeLeft.TotalMinutes >= 0 && timeLeft.TotalMinutes <= 15)
                {
                    string startTime = start.ToString();
                    MessageBox.Show($"Reminder: You have an appointment at {startTime}.");
                }
            }
        }

        //refresh customer data grid
        public void refreshCustomerDataGrid()
        {
            Customer.customers.Clear();
            mainCustomersDataGrid.DataSource = Customer.GetCustomerInfo();
        }
        //refresh appointments data grid
        public void refreshAppointmentDataGrid()
        {
            Appointments.appointmentsData.Clear();
            mainApptDataGrid.DataSource = Appointments.GetAllAppointments();
        }


        //add appointment
        private void btnAddAppt_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Show();
        }

        //opens modify appointment form
        private void btnModifyAppt_Click(object sender, EventArgs e)
        {
            
            if (mainApptDataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = mainApptDataGrid.SelectedRows[0];

                // Retrieve cell values directly and convert them to appropriate types
                int appointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);
                int userId = Convert.ToInt32(selectedRow.Cells["userId"].Value);
                int customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
                string title = selectedRow.Cells["title"].Value.ToString();
                string description = selectedRow.Cells["description"].Value.ToString();
                string location = selectedRow.Cells["location"].Value.ToString();
                string type = selectedRow.Cells["type"].Value.ToString();
                string contact = selectedRow.Cells["contact"].Value.ToString();
                string url = selectedRow.Cells["url"].Value.ToString();
                
                DateTime start = Convert.ToDateTime(selectedRow.Cells["start"].Value);
                DateTime end = Convert.ToDateTime(selectedRow.Cells["end"].Value);

                // Show the ModifyAppointment form and pass the retrieved values directly to its constructor
                new ModifyAppointment(appointmentId, userId, customerId, title, description, location, type, contact, url, start, end).ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.");
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
        }

        //opens modify customer form
        private void btnModifyCustomer_Click(object sender, EventArgs e)
        {
            
            if (mainCustomersDataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = mainCustomersDataGrid.SelectedRows[0];

                
                int customerId = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
                string customerName = selectedRow.Cells["customerName"].Value.ToString();
                string address = selectedRow.Cells["address"].Value.ToString();
                string address2 = selectedRow.Cells["address2"].Value.ToString();
                string city = selectedRow.Cells["city"].Value.ToString();
                string country = selectedRow.Cells["country"].Value.ToString();
                string postalCode = selectedRow.Cells["postalCode"].Value.ToString(); 
                string phone = selectedRow.Cells["phone"].Value.ToString();

                // Show the ModifyCustomer form and pass the values directly to its constructor
                new ModifyCustomer(customerId, customerName, address, address2, city, country, postalCode, phone).ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }
        //open appointments report
        private void btnViewAppts_Click(object sender, EventArgs e)
        {
            AppointmentsReport appointmentReport = new AppointmentsReport();
            appointmentReport.Show();
        }

        private void btnConsultantReport_Click(object sender, EventArgs e)
        {
            ConsultantReport consultantReport = new ConsultantReport();
            consultantReport.Show();
        }

        private void btnApptType_Click(object sender, EventArgs e)
        {
            AppointmentType appointmentType = new AppointmentType();
            appointmentType.Show();
        }

        private void btnCustomerReport_Click(object sender, EventArgs e)
        {
            CustomerReport customerReport = new CustomerReport();
            customerReport.Show();
        }


        //delete selected appointment
        private void btnDeleteAppt_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (mainApptDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }

            // Get the appointment ID from the selected row
            int appointmentId;
            if (!int.TryParse(mainApptDataGrid.CurrentRow.Cells["appointmentId"].Value.ToString(), out appointmentId))
            {
                MessageBox.Show("Invalid appointment ID.");
                return;
            }

            // Delete the appointment
            if (Appointments.DeleteAppointment(appointmentId))
            {
                // If deletion is successful, refresh the appointment data
                refreshAppointmentDataGrid();
                MessageBox.Show("Appointment deleted successfully.");
            }
            else
            {
                // If deletion fails, show an error message
                MessageBox.Show("Failed to delete appointment.");
            }
        }
        //delete customer
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (mainCustomersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            // Get the customer ID from the selected row
            int customerId;
            if (!int.TryParse(mainCustomersDataGrid.CurrentRow.Cells["customerId"].Value.ToString(), out customerId))
            {
                MessageBox.Show("Invalid customer ID.");
                return;
            }

            // Confirm deletion with user
            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Attempt to delete the customer
                if (Customer.DeleteCustomer(customerId))
                {
                    MessageBox.Show("Customer deleted successfully.");

                    // Refresh customer and appointment data
                    refreshCustomerDataGrid();
                    refreshAppointmentDataGrid();
                }
                else
                {
                    MessageBox.Show("Failed to delete customer. Please try again.");
                }
            }
        }
        //log out
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
