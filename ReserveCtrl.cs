using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boundary;
using Entity;

namespace Control
{
    public class ReserveCtrl : IController
    {
        public override void Initiate(IForm sender, string token)
        {
            
        }

        public ReserveCtrl(DBConnector db)
        {
            _dbConn = db;
        }
    }
}
