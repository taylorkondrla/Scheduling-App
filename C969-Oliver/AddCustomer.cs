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
    public partial class AddCustomer : Form
    {
        // Refresh customer data grid
        MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];

        public AddCustomer()
        {
            InitializeComponent();
            textCustomerIDAddCust.Text = Customer.GetNewCustomerID().ToString();
        }

        // Confirm all fields are not blank
        private bool ConfirmFields()
        {
            if (string.IsNullOrWhiteSpace(textCustomerNameAddCust.Text))
            {
                MessageBox.Show("Please enter a Customer Name.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textAddressAddCust.Text))
            {
                MessageBox.Show("Please enter an Address.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textCityAddCust.Text))
            {
                MessageBox.Show("Please enter a City.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textCountryAddCust.Text))
            {
                MessageBox.Show("Please enter a Country.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textZipAddCust.Text))
            {
                MessageBox.Show("Please enter a Zip Code.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(textPhoneAddCust.Text))
            {
                MessageBox.Show("Please enter a Phone Number.");
                return true;
            }
            return false;
        }

        // Save add customer
        private void btnSaveAddCust_Click(object sender, EventArgs e)
        {
            if (ConfirmFields()) { }

            //checks if customer is already in database
            else
            {
                bool customerFound = Customer.ConfirmCustomer(textCustomerNameAddCust.Text);

                if (!customerFound)
                {
                    Country country = Country.GetCountry(textCountryAddCust.Text);
                    City city = City.GetCity(textCityAddCust.Text, country.CountryId);

                    if (city == null)
                    {
                        // If the city doesn't exist, create a new city
                        city = City.CreateNewCity(textCityAddCust.Text, country.CountryId);
                    }

                    // Now, city should not be null
                    if (city != null)
                    {
                        Address address = Address.CreateNewAddress(textAddressAddCust.Text, textAddress2AddCust.Text, city.cityId, textZipAddCust.Text, textPhoneAddCust.Text);
                        Customer.AddCustomer(textCustomerNameAddCust.Text, address.addressID, 1);
                        mainForm.refreshCustomerDataGrid();
                        this.Close();
                    }
                    else
                    {
                        // Handle case where city creation failed
                        MessageBox.Show("Failed to create the city.");
                    }
                }
            }
        }

        private void btnCloseAddCust_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
