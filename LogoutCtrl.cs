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

        //SHA256 mySHA256 = SHA256.Create();
        //byte[] hashvalue = mySHA256.ComputeHash(Encoding.ASCII.GetBytes("p@ssword"));
        //StringBuilder sb = new StringBuilder();
        //    foreach (byte b in hashvalue)
        //        sb.AppendFormat("{0:X2}", b);
        //    MessageBox.Show(sb.ToString());
    }
}
