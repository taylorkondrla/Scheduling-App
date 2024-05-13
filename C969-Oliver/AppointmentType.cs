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
            //Load appointment types when the form is initialized
            LoadAppointmentTypes();
        }

        // Add event handlers for radio buttons
        private void LoadAppointmentTypes()
        {
            // Add event handlers for radio buttons
            rdbtnJan.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnFeb.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnMar.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnApr.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnMay.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnJun.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnJul.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnAug.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnSep.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnOct.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnNov.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnDec.CheckedChanged += RadioButton_CheckedChanged;
        }

        // Populate the data grid with appointment types by month
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                string month = radioButton.Text;
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

