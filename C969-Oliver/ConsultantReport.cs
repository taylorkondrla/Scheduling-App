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
            PopulateConsultantsDropDown();
            comboConsultant.SelectedIndexChanged += comboConsultant_SelectedIndexChanged;

        }

        private void PopulateConsultantsDropDown()
        {
            DataTable consultants = DataManager.GetConsultants();

            if (consultants != null && consultants.Rows.Count > 0)
            {
                foreach (DataRow row in consultants.Rows)
                {
                    comboConsultant.Items.Add(new KeyValuePair<int, string>((int)row["userId"], row["userName"].ToString()));
                }
            }
            else
            {
                MessageBox.Show("No consultants found. Please add consultants.");
            }
        }

        private void comboConsultant_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAppointmentsForConsultant();
        }

        private void LoadAppointmentsForConsultant()
        {
            if (comboConsultant.SelectedItem != null)
            {
                KeyValuePair<int, string> selectedConsultant = (KeyValuePair<int, string>)comboConsultant.SelectedItem;
                int userId = selectedConsultant.Key;

                DataTable appointments = DataManager.GetAppointmentsForConsultant(userId);

                if (appointments != null && appointments.Rows.Count > 0)
                {
                    userReportDataGrid.DataSource = appointments;
                }
                else
                {
                    MessageBox.Show("No appointments found for the selected consultant.");
                }
            }
            else
            {
                MessageBox.Show("Please select a consultant.");
            }
        }

        // Close button event handler
        private void btnCloseConsultantReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}




