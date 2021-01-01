using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.model
{
    public enum Role
    {
        ADMIN, EMPLOYEE
    }
    public class Account
    {
        private string username;
        private string password;
        private Role role;

        public Account(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public Role Role { get => role; set => role = value; }
    }
}
