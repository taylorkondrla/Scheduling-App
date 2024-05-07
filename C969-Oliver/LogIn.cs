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

namespace C969_Oliver
{
    public partial class LogIn : Form
    {
        private static User currentUser;
        public string message = "The username and password did not match.";
        public LogIn()
        {
            InitializeComponent();
            if (CultureInfo.CurrentUICulture.LCID == 1034 ) //1034 spanish lcid
            {
                this.Text = "Acceso";
                usernameLabel.Text = "Nombre de usuario";
                passwordLabel.Text = "Contraseña";
                btnLogIn.Text = "Acceso";
                btnCloseLogin.Text = "Cerca";
                message = "Nombre de usuario y contraseña no coinciden.";
            }
        }
        public static User GetCurrentUSer()
        { 
            return currentUser;
        }
        //find user in database
        static public int FindUser(string userName, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
            {
                connection.Open();
                string query = $"SELECT userID FROM user WHERE userName = '{userName}' AND password = '{password}'";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            int userID = reader.GetInt32(0);
                            DataManager.setCurrentUserID(userID);
                            DataManager.setCurrentUsername(userName);
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (FindUser(textUserName.Text, textPassword.Text) == 1)
            { 
                this.Hide();
                MainForm MainForm = new MainForm();
                MainForm.LogInForm = this;
                UserActivity.UserLogInToLog(textUserName.Text);
                MainForm.Show();
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
