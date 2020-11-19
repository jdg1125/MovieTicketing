using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;
using Boundary;

namespace MovieTicketing
{
    public class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginCtrl loginCtrl = new LoginCtrl();
            loginCtrl.Initiate(null);

            //EntryCtrl res = new EntryCtrl("s");
            //Application.Run(new SetMovieForm(res, "s"));
            ////DBConnector db = new DBConnector();
            //logoutctrl ctrl = new logoutctrl("squash");
            // Application.Run(new Homepage("e"));
        }
    

    }


}
