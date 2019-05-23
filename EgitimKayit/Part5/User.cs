using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Part5
{
    public class User
    {
        private string _password;
        public string Username { get; }
        SHA1 passwordHash = new SHA1CryptoServiceProvider();
        public string Password
        {
            get
            {
                string pass = "";
                for (int i = 0; i < Password.Length; i++)
                {
                    pass += "*";
                }
                return pass;
            }
            private set { _password = value; }
        }
        public string PasswordHash
        {
            get
            {
                return Convert.ToBase64String(passwordHash.ComputeHash(Encoding.UTF8.GetBytes(_password)));
            }
        }


        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
