using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Oliver
{
    public partial class ModifyAppointment : Form
    {
        //create instance of mainform that will refresh datagrid
        MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
        public ModifyAppointment(int appointmentId, int userId, int customerId, string title, string description, string location, string type, string contact, string url, DateTime start, DateTime end)
        {
            InitializeComponent();

            // Retrieve customer and user details based on appointment
            Customer customer = Customer.GetCustomerById(customerId);
            User user = User.GetUserByID(userId);

            // Populate the text boxes with appointment details
            // Set values in the form controls
            textApptIDModAppt.Text = appointmentId.ToString();
            textUserIDModAppt.Text = userId.ToString();
            textCustomerIDModAppt.Text = customerId.ToString();
            textTitleModAppt.Text = title;
            textDescriptionModAppt.Text = description;
            textLocationModAppt.Text = location;
            textTypeModAppt.Text = type;
            textContactModAppt.Text = contact;
            textURLModAppt.Text = url;
            startTimeModAppt.Value = start;
            endTimeModAppt.Value = end;

            // Set the ReadOnly property for AppointmentId, CustomerId, and UserId text boxes
            textApptIDModAppt.ReadOnly = true;
            textCustomerIDModAppt.ReadOnly = true;
            textUserIDModAppt.ReadOnly = true;
        }
        private bool confirmFields()
        {
            if (string.IsNullOrWhiteSpace(textTitleModAppt.Text))
            {
                MessageBox.Show("Please enter a Title.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textDescriptionModAppt.Text))
            {
                MessageBox.Show("Please enter a Description.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textLocationModAppt.Text))
            {
                MessageBox.Show("Please enter a Location.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textTypeModAppt.Text))
            {
                MessageBox.Show("Please enter a Type.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textContactModAppt.Text))
            {
                MessageBox.Show("Please enter a Contact.");
                return true;
            }
            if (string.IsNullOrEmpty(textURLModAppt.Text))
            {
                MessageBox.Show("Please enter a URL.");
            }
            
            return false;
        }

        //combine date and time
        private DateTime CombineDateAndTime(DateTimePicker datePicker, DateTimePicker timePicker)
        {
            DateTime date = datePicker.Value.Date;
            DateTime time = timePicker.Value;
            return date.Add(time.TimeOfDay);
        }

        //save
        private void btnSaveModAppt_Click(object sender, EventArgs e)
        {
            try
            {
                if (confirmFields())
                {
                    return;
                }

                // Retrieve user ID and customer ID
                int userId = Convert.ToInt32(textUserIDModAppt.Text);
                int customerId = Convert.ToInt32(textCustomerIDModAppt.Text);

                // Combine the date and time from the DateTimePicker controls
                DateTime startDateTime = CombineDateAndTime(dateModAppt, startTimeModAppt);
                DateTime endDateTime = CombineDateAndTime(dateModAppt, endTimeModAppt);

                // Validate the date and time
                if (endDateTime <= startDateTime)
                {
                    MessageBox.Show("End time must be after start time.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Appointments newAppointment = new Appointments(
                    Convert.ToInt32(textApptIDModAppt.Text),
                    customerId,
                    userId,
                    textTitleModAppt.Text,
                    textDescriptionModAppt.Text,
                    textLocationModAppt.Text,
                    textTypeModAppt.Text,
                    textContactModAppt.Text,
                    textURLModAppt.Text,
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

                    Appointments.UpdateAppointment(newAppointment);

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

        private void btnCloseModAppt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
