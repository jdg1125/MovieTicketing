using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;

namespace Boundary
{
    public partial class Homepage : IForm
    {
        private string _token;
        public Homepage(string token)
        {
            InitializeComponent();
            _token = token;
            
        }
    }
}
