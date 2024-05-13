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
        }

        private void PopulateConsultantsDropDown()
        {
            DataTable consultants = DataManager.GetConsultants();

            consultantDropDown.Items.Clear();
            foreach (DataRow row in consultants.Rows)
            {
                consultantDropDown.Items.Add(row["userName"].ToString());
            }
        }

        private void consultantDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAppointmentsForConsultant();
        }

        private void LoadAppointmentsForConsultant()
        {
            string selectedConsultant = consultantDropDown.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedConsultant))
            {
                DataTable appointments = DataManager.GetAppointmentsForConsultant(selectedConsultant);
                consultantReportDataGrid.DataSource = appointments;
            }
            else
            {
                MessageBox.Show("Please select a consultant.");
            }
        }

        //close
        private void btnCloseConsultantReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


