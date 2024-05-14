using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Oliver
{
    public class User
    {
        //create Attributes

        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int active { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }

        public User() { }

        //confirm user exist in database
        public static User ConfirmUser(string userName, string password)
        {
            User currentUser = new User();

            string qry = $"SELECT * FROM user WHERE userName = '{userName}' and password = '{password}'";
            MySqlCommand cmd = new MySqlCommand(qry, DBConnection.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                if (reader.HasRows)
                {
                    currentUser.userId = Convert.ToInt32(reader["userId"]);
                    currentUser.userName = reader["username"].ToString();
                    currentUser.password = reader["password"].ToString();
                    currentUser.active = Convert.ToInt32(reader["active"]);
                    currentUser.createDate = Convert.ToDateTime(reader["createDate"]);
                    currentUser.createdBy = reader["createdBy"].ToString();
                    currentUser.lastUpdate = Convert.ToDateTime(reader["lastUpdate"]);
                    currentUser.lastUpdateBy = reader["lastUpdatedBy"].ToString();
                }
            }
            reader.Close();
            return currentUser;
        }
        //get data from user table
        public static List<User> GetUserList()
        {
            List<User> userList = new List<User>();

            string query = "SELECT * FROM user;";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                User user = new User();

                user.userId = Convert.ToInt32(reader["userId"]);
                user.userName = reader["username"].ToString();
                user.password = reader["password"].ToString();
                user.active = Convert.ToInt32(reader["active"]);

                userList.Add(user);
            }
            reader.Close();
            return userList;
        }
        //get user by id
        public static User GetUserByID(int userId)
        {
            User user = new User();
            string query = $"SELECT userID, userName FROM user WHERE userId = '{userId}'";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                user.userId= Convert.ToInt32(reader["userId"]);
                user.userName= reader["username"].ToString();
            }
            reader.Close();
            return user;
        }
        //get user by name
        public static User GetUserByName(string userName)
        {
            User user = new User();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT userID, userName FROM user WHERE userName = '{userName}'";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.userId = Convert.ToInt32(reader["userId"]);
                                user.userName = reader["userName"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            
            }

            return user;
        }
    }
}