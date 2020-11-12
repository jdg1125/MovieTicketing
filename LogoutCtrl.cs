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

        public override void Initiate(IForm sender, string token)
        {
            
        }

        public LogoutCtrl(DBConnector db)
        {
            _dbConn = db;
        }
    }
}
