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
            RefreshAppointmentData();
        }

        //add appointment
        private void btnAddAppt_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Show();
        }

        private void btnModifyAppt_Click(object sender, EventArgs e)
        {
            ModifyAppointment modifyAppointment = new ModifyAppointment();
            modifyAppointment.Show();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
        }

        private void btnModifyCustomer_Click(object sender, EventArgs e)
        {
            ModifyCustomer modifyCustomer = new ModifyCustomer();
            modifyCustomer.Show();
        }

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
    }
}
