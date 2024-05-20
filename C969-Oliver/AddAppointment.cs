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
    public partial class AddAppointment : Form
    {
        //create instance of mainform that will refresh datagrid
        MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];

        public AddAppointment()
        {
            InitializeComponent();

            // Appointment ID textbox - new appointment ID
            textApptIDAddAppt.Text = Appointments.NewAppointmentID().ToString();

            // Populate combo boxes with user IDs and customer IDs from appointments table
            PopulateUserComboBox();
            PopulateCustomerComboBox();
        }

        // Method to populate the user combo box
        private void PopulateUserComboBox()
        {
            
            comboBoxUser.Items.Clear();

            
            List<int> userIds = Appointments.GetDistinctUserIds();

            // Lambda expression to add each user ID to the combo box for clarity, readability and conciseness
            userIds.ForEach(userId => comboBoxUser.Items.Add(userId));
        }

        // Method to populate the customer combo box
        private void PopulateCustomerComboBox()
        {
            
            comboBoxCustomer.Items.Clear();

            
            List<int> customerIds = Appointments.GetDistinctCustomerIds();

            // Lambda expression to add each customer ID to the combo box for clarity, readability and conciseness
            customerIds.ForEach(customerId => comboBoxCustomer.Items.Add(customerId));
        }

        // Confirm fields are not empty
        private bool confirmFields()
        {
            if (comboBoxCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Customer.");
                return true;
            }
            if (comboBoxUser.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a User.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textTitleAddAppt.Text))
            {
                MessageBox.Show("Please enter a Title.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textDescriptionAddAppt.Text))
            {
                MessageBox.Show("Please enter a Description.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textLocationAddAppt.Text))
            {
                MessageBox.Show("Please enter a Location.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textTypeAddAppt.Text))
            {
                MessageBox.Show("Please enter a Type.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textContactAddAppt.Text))
            {
                MessageBox.Show("Please enter a Contact.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textURLAddAppt.Text))
            {
                MessageBox.Show("Please enter a URL.");
            }
            return false;
        }
        //combine date and time
        public DateTime CombineDateAndTime(DateTimePicker datePicker, DateTimePicker timePicker)
        {
            DateTime date = datePicker.Value.Date;
            DateTime time = timePicker.Value;
            return date.Add(time.TimeOfDay);
        }

        // Save new appointment
        private void btnSaveAddAppt_Click(object sender, EventArgs e)
        {
            try
            {
                if (confirmFields())
                {
                    // Fields are not valid, do nothing
                    return;
                }

                
                int userId = Convert.ToInt32(comboBoxUser.SelectedItem);
                int customerId = Convert.ToInt32(comboBoxCustomer.SelectedItem);

                
                DateTime startDateTime = CombineDateAndTime(dateAddAppt, startTimeAddAppt);
                DateTime endDateTime = CombineDateAndTime(dateAddAppt, endTimeAddAppt);

                
                if (endDateTime <= startDateTime)
                {
                    MessageBox.Show("End time must be after start time.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Appointments newAppointment = new Appointments(
                    Convert.ToInt32(textApptIDAddAppt.Text),
                    customerId,
                    userId,
                    textTitleAddAppt.Text,
                    textDescriptionAddAppt.Text,
                    textLocationAddAppt.Text,
                    textTypeAddAppt.Text,
                    textContactAddAppt.Text,
                    textURLAddAppt.Text,
                    startDateTime,
                    endDateTime
                );

                try
                {
                    if (!Appointments.ConfirmBusinessHours(newAppointment))
                    {
                        throw new Exception("Oops! Appointment is scheduled outside of business hours 8 AM to 6 PM.");
                    }

                    if (!Appointments.ConfirmNoConflict(newAppointment))
                    {
                        throw new Exception("Oops! Appointment times conflict with another appointment for this user.");
                    }

                    Appointments.CreateAppointment(newAppointment);

                    mainForm.refreshAppointmentDataGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Close add appointment form
        private void btnCloseAddAppt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
