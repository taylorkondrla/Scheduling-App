using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace C969_Oliver
{
    public partial class LogIn : Form
    {
        private MainForm mainForm; // Store reference to MainForm

        public LogIn(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm; 
                                      
        }
        //create instance of datamanger 
        private static DataManager dataManager = new DataManager();
        public static User currentUser;
        public string message = "The username and password did not match.";

        public LogIn()
        {
            InitializeComponent();
            if (CultureInfo.CurrentUICulture.LCID == 1034) //1034 Spanish lcid
            {
                this.Text = "Acceso";
                usernameLabel.Text = "Nombre de usuario";
                passwordLabel.Text = "Contraseña";
                btnLogIn.Text = "Acceso";
                btnCloseLogin.Text = "Cerca";
                message = "Nombre de usuario y contraseña no coinciden.";
            }
        }

        public static User GetCurrentUser()
        {
            return currentUser;
        }

        //find user in database
        static public int FindUser(string userName, string password)
        {
            try
            {
                //the database connection is opened before querying
                DBConnection.OpenConnection();

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    connection.Open(); // Open connection here as well
                    string query = $"SELECT userID FROM user WHERE userName = '{userName}' AND password = '{password}'";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                int userID = reader.GetInt32(0);
                                currentUser = User.GetUserByID(userID); // Assign the retrieved user object to currentUser
                                return 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("An error occurred while trying to find the user: " + ex.Message);
            }
            finally
            {
                
                DBConnection.CloseConnection();
            }

            return 0;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (FindUser(textUserName.Text, textPassword.Text) == 1)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.LogInForm = this;
                UserActivity.UserLogInToLog(textUserName.Text);
                mainForm.Show();

                // Trigger appointment reminder in the MainForm
                mainForm.AppointmentReminder(); 
            }
            else
            {
                MessageBox.Show(message);
                textPassword.Text = "";
            }
        }

        private void btnCloseLogin_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
