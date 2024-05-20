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
            LoadMonths();
        }

        private void LoadMonths()
        {
            // Add event handlers for radio buttons using lambda expressions
            AddRadioButtonHandler(rdbtnJanCR);
            AddRadioButtonHandler(rdbtnFebCR);
            AddRadioButtonHandler(rdbtnMarCR);
            AddRadioButtonHandler(rdbtnAprCR);
            AddRadioButtonHandler(rdbtnMayCR);
            AddRadioButtonHandler(rdbtnJunCR);
            AddRadioButtonHandler(rdbtnJulCR);
            AddRadioButtonHandler(rdbtnAugCR);
            AddRadioButtonHandler(rdbtnSepCR);
            AddRadioButtonHandler(rdbtnOctCR);
            AddRadioButtonHandler(rdbtnNovCR);
            AddRadioButtonHandler(rdbtnDecCR);
        }

        // Lambda expression to handle RadioButton CheckedChanged event
        private void AddRadioButtonHandler(RadioButton radioButton)
        {
            radioButton.CheckedChanged += (sender, e) =>
            {
                RadioButton_CheckedChanged(sender, e, radioButton.Tag.ToString());
            };
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e, string month)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
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
