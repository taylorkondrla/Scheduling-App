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
        public ModifyAppointment(int appointmentId, int userId, int customerId, string title, string description, string location, string type, string contact, DateTime date, DateTime start, DateTime end)
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
            dateModAppt.Value = date;
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
            
            return false;
        }

        private void btnSaveModAppt_Click(object sender, EventArgs e)
        {
            try
            {
                if (confirmFields())
                {
                    // Fields are not valid, do nothing
                    return;
                }

                Customer customer = Customer.GetCustomerByName(textCustomerIDModAppt.Text);
                User user = User.GetUserByName(textUserIDModAppt.Text);
                Appointments newAppointment = new Appointments(
                    Convert.ToInt32(textApptIDModAppt.Text),
                    customer.customerId,
                    user.userId,
                    textTitleModAppt.Text,
                    textDescriptionModAppt.Text,
                    textLocationModAppt.Text,
                    textTypeModAppt.Text,
                    textContactModAppt.Text,
                    startTimeModAppt.Value,
                    endTimeModAppt.Value
                );

                try
                {
                    if (!Appointments.ConfirmBusinessHours(newAppointment))
                    {
                        throw new Exception("Oops! Appointment is scheduled outside of business hours 8 AM to 6 PM.");
                    }

                    if (!Appointments.ConfirmNoConflict(newAppointment))
                    {
                        throw new Exception("Oops! Appointment times conflict another appointment for this user.");
                    }

                    Appointments.CreateAppointment(newAppointment);


                    MainForm.RefreshAppointmentData();
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
