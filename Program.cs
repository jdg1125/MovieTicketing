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
            Startup context = new Startup();
            Homepage testform = new Homepage("E");
            Application.Run(testform);
            
        }
    

    }


}
