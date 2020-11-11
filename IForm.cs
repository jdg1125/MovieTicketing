using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;

namespace Boundary
{
    public abstract partial class IForm : Form
    {
        protected IController _ctrl;
        //public abstract void Close();
        public abstract void Display(string s);
    }
}
