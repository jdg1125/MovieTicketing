using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Boundary;

namespace Control
{
    public class LoginCtrl : IController
    { 
        public override void Initiate(IForm sender, string token)
        {
            
        }
        public LoginCtrl(Startup context, DBConnector db)
        {
            _form = context.MakeLoginForm();
            _dbConn = db;
        }

        public LoginForm GetLoginForm()
        {
            return _form as LoginForm;
        }
        
    }
}
