using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Control;

namespace Boundary
{
    public class LoginCtrl : IController
    { 
        public override void Initiate(string token)
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
