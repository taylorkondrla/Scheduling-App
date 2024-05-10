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

        //refresh customer data grid
        MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
        public AddCustomer()
        {
            InitializeComponent();

            textCustomerIDAddCust.Text = Customer.GetNewCustomerID().ToString();
        }


        //confirm all fields are not blank
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
            else
            {
                return false;
            }
        }
        //save add customer
        private void btnSaveAddCust_Click(object sender, EventArgs e)
        {
            if (ConfirmFields()) { }

            //checks if customer is already in database
            else
            {
                bool customerFound = Customer.ConfirmCustomer(textCustomerNameAddCust.Text);

                //if customer is not found add new customer
                if (!customerFound)
                {
                    //If customer does not exist, get or create country, city, address and create a new customer
                    Country country = Country.getCountry(textCountryAddCust.Text);
                    City city = City.getCity(textCityAddCust.Text, country.CountryId);
                    Address address = Address.GetAddress(textAddressAddCust.Text, city.CityId, textZipAddCust.Text, textPhoneAddCust.Text);
                    Customer.AddCustomer(textCustomerNameAddCust.Text, address.addressID, 1);

                    mainForm.RefreshCustomerGrid();
                    this.Close();
                }
            }
        }

        private void btnCloseAddCust_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
