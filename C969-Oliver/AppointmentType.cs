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
    public partial class AppointmentType : Form
    {
        public AppointmentType()
        {
            InitializeComponent();
            // Load appointment types when the form is initialized
            LoadAppointmentTypes();
        }

        // Add event handlers for radio buttons
        private void LoadAppointmentTypes()
        {
            // Use lambda expression to attach event handlers for radio buttons
            foreach (RadioButton radioButton in new RadioButton[] { rdbtnJan, rdbtnFeb, rdbtnMar, rdbtnApr, rdbtnMay, rdbtnJun, rdbtnJul, rdbtnAug, rdbtnSep, rdbtnOct, rdbtnNov, rdbtnDec })
            {
                radioButton.CheckedChanged += (sender, e) => RadioButton_CheckedChanged(sender, e, radioButton.Text);
            }
        }

        // Populate the data grid with appointment types by month
        private void RadioButton_CheckedChanged(object sender, EventArgs e, string month)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                PopulateAppointmentTypeDataGrid(month);
            }
        }

        private void PopulateAppointmentTypeDataGrid(string month)
        {
            DataTable dataTable = DataManager.GetAppointmentTypesForMonth(month);
            apptTypeDataGrid.DataSource = dataTable;
        }

        private void btnCloseApptType_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

