using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms;
using Entity;

namespace Controllers
{
    public class EntryCtrl: IController
    {
        public override void Initiate(string s)
        {
            
        }
        public EntryCtrl(DBConnector db)
        {
            _dbConn = db;
        }
    }
}
