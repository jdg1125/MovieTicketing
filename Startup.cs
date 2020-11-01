using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms;

namespace Controllers
{
    public class Startup
    {
        private LoginCtrl LoginCtrl { get; set; }
        public LoginForm Form { get; set; }

        private DBConnector DBConn { get; set; }

        private EntryCtrl EntryCtrl { get; set; }
        private ReserveCtrl ReserveCtrl { get; set; }

        private LogoutCtrl LogoutCtrl { get; set; }

        public Startup()
        {
            DBConn = new DBConnector();
            LoginCtrl = new LoginCtrl(this, DBConn);
            EntryCtrl = new EntryCtrl(DBConn);
            ReserveCtrl = new ReserveCtrl(DBConn);
            LogoutCtrl = new LogoutCtrl(DBConn);
        }
        public LoginCtrl GetLoginCtrl()
        {
            return LoginCtrl;
        }

        public LoginForm MakeLoginForm()
        {
            return (Form = new LoginForm(this));
        }
    }
}
