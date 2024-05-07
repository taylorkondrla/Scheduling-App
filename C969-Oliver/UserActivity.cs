using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Oliver
{
    internal class UserActivity
    {
        public static void UserLogInToLog(string username)
        {
            string path = "log.text";
            string log = $"User with username of {username} logged in at {DataManager.createTimeStamp()}" + Environment.NewLine;
            File.AppendAllText(path, log); 
        }
    }
}
