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
    public partial class AppointmentsReport : Form
    {
        private DataGridView mainApptDataGrid;

        //constructor with data gird view parameter
        public AppointmentsReport(DataGridView mainApptDataGrid)
        {
            InitializeComponent();
            this.mainApptDataGrid = mainApptDataGrid;
        }

        //shows appointments based on what radio button is selected
        public void LoadAppointmentData()
        {
            if (rdbtnAllAppts.Checked)
            {
                mainApptDataGrid.DataSource = Appointments.GetAllAppointments();
            }
            if (rdbtnWeekly.Checked)
            {
                mainApptDataGrid.DataSource = Appointments.WeeklyAppointments();
            }
            if (rdbtnMonthly.Checked)
            {
                mainApptDataGrid.DataSource = Appointments.MonthlyAppointments();
            }
        }

        private void btnCloseApptReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
