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

            //appointment id text box new appointment id
            textApptIDAddAppt.Text = Appointments.NewAppointmentID().ToString();

            // Add customer names
            List<Customer> customers = Customer.GetListCustomers();
            StringBuilder customerNames = new StringBuilder();
            // Lambda expression used here
            customers.ForEach(customer => customerNames.AppendLine(customer.customerName));
            textCustomerIDAddAppt.Text = customerNames.ToString();

            // Add user names
            List<User> users = User.GetUserList();
            StringBuilder userNames = new StringBuilder();
            // Lambda expression used here 
            users.ForEach(user => userNames.AppendLine(user.userName));
            textUserIDAddAppt.Text = userNames.ToString();
        }

        //confirm fields are not empty
        private bool confirmFields()
        {
            if (string.IsNullOrWhiteSpace(textCustomerIDAddAppt.Text))
            {
                MessageBox.Show("Please enter a Customer.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textUserIDAddAppt.Text))
            {
                MessageBox.Show("Please enter a User.");
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
            return false;
        }

        //save new appointment
        private void btnSaveAddAppt_Click(object sender, EventArgs e)
        {
            try
            {
                if (confirmFields())
                {
                    // Fields are not valid, do nothing
                    return;
                }

                Customer customer = Customer.GetCustomerByName(textCustomerIDAddAppt.Text);
                User user = User.GetUserByName(textUserIDAddAppt.Text);
                Appointments newAppointment = new Appointments(
                    Convert.ToInt32(textApptIDAddAppt.Text),
                    customer.customerId,
                    user.userId,
                    textTitleAddAppt.Text,
                    textDescriptionAddAppt.Text,
                    textLocationAddAppt.Text,
                    textTypeAddAppt.Text,
                    textContactAddAppt.Text,
                    startTimeAddAppt.Value,
                    endTimeAddAppt.Value
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
        //close add appointment form
        private void btnCloseAddAppt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
