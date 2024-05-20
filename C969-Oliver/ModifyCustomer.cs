using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace C969_Oliver
{
    public partial class ModifyCustomer : Form
    {
        //refresh customer data grid

        MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
        public ModifyCustomer(int customerId, string customerName, string address, string address2, string city, string country, string zipCode, string phone)
        {
            InitializeComponent();

            textCustIDModCust.Text = customerId.ToString();
            textCustIDModCust.ReadOnly = true;
            textCustNameModCust.Text = customerName;
            textAddressModCust.Text = address;
            textBaddress2ModCust.Text = address2;
            textCityModCust.Text = city;
            textCountryModCust.Text = country;
            textZipModCust.Text = zipCode;
            textPhoneModCust.Text = phone;
            textPhoneModCust.KeyPress += textPhoneAddCust_KeyPress;
        }
        //confirm no blank fields
        private bool confirmFields()
        {
            if (string.IsNullOrWhiteSpace(textCustNameModCust.Text))
            {
                MessageBox.Show("Please enter a Customer Name.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textAddressModCust.Text))
            {
                MessageBox.Show("Please enter an Address.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textCityModCust.Text))
            {
                MessageBox.Show("Please enter a City.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textCountryModCust.Text))
            {
                MessageBox.Show("Please enter a Country.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textZipModCust.Text))
            {
                MessageBox.Show("Please enter a Postal Code.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textPhoneModCust.Text))
            {
                MessageBox.Show("Please enter a Phone Number.");
                return true;
            }
            else
            {
                return false;
            }
        }

        //save modify customer
        private void btnSaveModCust_Click(object sender, EventArgs e)
        {
            // Check if fields are valid
            if (confirmFields())
            {

                return;
            }

            // Retrieve or create country, city, and address
            Country country = Country.GetCountry(textCountryModCust.Text);
            City city = City.GetCity(textCityModCust.Text, country.CountryId);
            Address address = Address.GetAddress(textAddressModCust.Text, textBaddress2ModCust.Text, city.cityId, textZipModCust.Text, textPhoneModCust.Text);

            if (address == null)
            {
                MessageBox.Show("An error occurred while processing the address data.");
                return;
            }

            // Update the customer
            int customerId = Convert.ToInt32(textCustIDModCust.Text);
            string customerName = textCustNameModCust.Text;
            Customer.ModifyCustomer(customerId, customerName, address.addressID, 1);

            // Refresh the customer grid in the main form
            mainForm.refreshCustomerDataGrid();

            // Close the modify customer form
            this.Close();
        }
        private void textPhoneAddCust_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits (0-9), backspace, and dashes (-)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '-')
            {
                e.Handled = true; // Ignore the character
                MessageBox.Show("Only digits and dashes are allowed in the phone number.");
            }
        }
        //close
        private void btnCloseModCust_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
