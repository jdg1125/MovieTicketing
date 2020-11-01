using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms;

namespace Controllers
{
    public class LogoutCtrl : IController
    {

        public override void Initiate(string s)
        {
            
        }

        public LogoutCtrl(DBConnector db)
        {
            _dbConn = db;
        }
    }
}
