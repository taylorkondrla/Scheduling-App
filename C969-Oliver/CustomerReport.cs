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
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
            LoadEventHandlers(); // Load event handlers for radio buttons
        }

        private void LoadEventHandlers()
        {
            // Add event handlers for radio buttons
            rdbtnJanCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnFebCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnMarCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnAprCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnMayCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnJunCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnJulCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnAugCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnSepCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnOctCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnNovCR.CheckedChanged += RadioButton_CheckedChanged;
            rdbtnDecCR.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked && radioButton.Text.Length >= 7) // Check if text has at least 7 characters
            {
                string month = radioButton.Text.Substring(6);
                // Populate the data grid with customer report data for the selected month
                PopulateCustomerReportDataGrid(month);
            }
        }

        private void PopulateCustomerReportDataGrid(string month)
        {
            DataTable dataTable = DataManager.GetCustomerReportDataForMonth(month);
            customerReportDataGrid.DataSource = dataTable;
        }

        private void btnCloseCustomerReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}
