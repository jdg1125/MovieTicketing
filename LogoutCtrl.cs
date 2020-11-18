using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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
            if(_dbConn.RecordLogout(_token))   //this should always be true - inside if to check that assumption
                (_form as LogoutForm).Display("You have successfully logged out");

            _form.Close();

            Form loginForm = Application.OpenForms[0];
            Label oneToErase;

            foreach (var field in loginForm.Controls)
                if (field is TextBox)
                    (field as TextBox).Text = null;
                else if (field is Label && (oneToErase = (field as Label)).ForeColor==Color.Red)  //hide error messages 
                    oneToErase.Text = null;

            loginForm.Show();
        }
    }
}

