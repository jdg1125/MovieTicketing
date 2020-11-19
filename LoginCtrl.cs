using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using Control;

namespace Boundary
{
    public class LoginCtrl : IController
    {

        public override void Initiate(IForm sender)
        {
            Application.Run(_form);
        }
        public LoginCtrl()
        {
            _form = new LoginForm(this);
            _dbConn = new DBConnector();
        }

        public void Submit(string username, string password)
        {
            string hashpw = Hash(password);

            bool isValid = Sanitize(username, hashpw);
            string _token = null;

            if (isValid)
            {
                _token = _dbConn.Authenticate(username, hashpw);

                if (_token == "")
                    _form.Display("Authentication failed");
                else
                {
                    _form.Close();
                    Homepage homepage = new Homepage(_token);
                    homepage.Show();
                }
            }
            else
                _form.Display("       Invalid input");
        }

        private bool Sanitize(string username, string password)
        {
            bool isValid = username != "" && Char.IsLetter(username[0]);
            int len = username.Length;
            isValid = isValid && len==5;
            HashSet<char> forbidden = new HashSet<char>() { '*', ';', '|', '&', '=', '.', '%', '#', '\\', '/', '-', '+', '!', '`', '\'', ':', ',', '@', '^', '<', '>', '?', '{', '}', '[', ']', '(', ')', '$', '\"'};

            for (int i = 0; isValid && i < len; i++)
                if (forbidden.Contains(username[i]))
                    isValid = false;

            if (isValid)
                if (password.Length < 100)
                    return true;
          
            return false;
        }

        private string Hash(string password)
        {
            SHA256 mySHA256 = SHA256.Create();
            byte[] hashvalue = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashvalue)
                sb.AppendFormat("{0:X2}", b);

            return sb.ToString();
        }

    }
}
