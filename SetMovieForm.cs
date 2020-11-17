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
using Entity;

namespace Boundary
{
    public partial class SetMovieForm : IForm
    {
        public SetMovieForm(EntryCtrl ctrl)
        {
            InitializeComponent();
            _ctrl = ctrl;
            Setmovieform_Load();
        }
       
    }
}
