using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Boundary;

namespace Control
{
    public class LogoutCtrl : IController
    {
        private string _token;

        public LogoutCtrl(string token)
        {
            _dbConn = new DBConnector();
            _token = token;
            _form = new LogoutForm(this);
        }
        public override void Initiate(IForm sender)
        {
            sender.Close();
            _form.Show();
        }

        public void Submit()
        {
            _dbConn.RecordLogout(_token);
            (_form as LogoutForm).Display("You have successfully logged out");
            _form.Close();
            LoginForm loginform = new LoginForm();

        }
    }
}

