using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPracticum5.Model
{
    public class User
    {
        int _userID;
        string _username;
        string _password;
        float _money;

        public int UserID { get => _userID; set => _userID = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public float Money { get => _money; set => _money = value; }
    }
}
