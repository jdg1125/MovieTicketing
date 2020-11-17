using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boundary;

namespace Control
{
    public class LogoutCtrl : IController
    {
        private string _token;

        public LogoutCtrl(DBConnector db)
        {
            _dbConn = db;
        }
        public override void Initiate(IForm sender, string token)
        {
            _token = token;
            sender.Close();
            _form = new LogoutForm();
        }

        public void Submit()
        {
            _dbConn.RecordLogout(_token);
            (_form as LogoutForm).Display("You have successfully logged out");
            _form.Close();
            LoginForm loginform = new LoginForm();

        }
<<<<<<< HEAD
        
=======

        //SHA256 mySHA256 = SHA256.Create();
        //byte[] hashvalue = mySHA256.ComputeHash(Encoding.ASCII.GetBytes("p@ssword"));
        //StringBuilder sb = new StringBuilder();
        //    foreach (byte b in hashvalue)
        //        sb.AppendFormat("{0:X2}", b);
        //    MessageBox.Show(sb.ToString());
>>>>>>> master
    }
}

