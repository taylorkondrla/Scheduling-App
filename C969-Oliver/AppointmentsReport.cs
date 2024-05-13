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
        public AppointmentsReport()
        {
            InitializeComponent();
            LoadEventHandlers();
        }

        private void LoadEventHandlers()
        {
            rdbtnWeekly.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnMonthly.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnAllAppts.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                if (radioButton == rdbtnWeekly)
                {
                    PopulateAppointmentsGrid(DataManager.GetWeeklyAppointments());
                }
                else if (radioButton == rdbtnMonthly)
                {
                    PopulateAppointmentsGrid(DataManager.GetMonthlyAppointments());
                }
                else if (radioButton == rdbtnAllAppts)
                {
                    PopulateAppointmentsGrid(DataManager.GetAllAppointments());
                }
            }
        }

        private void PopulateAppointmentsGrid(DataTable dataTable)
        {
            if (dataTable != null)
            {
                apptReportDataGrid.DataSource = dataTable;
            }
            else
            {
                // Handle null DataTable
            }
        }
        //close
        private void btnCloseApptReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}
