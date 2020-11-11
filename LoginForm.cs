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
    public partial class LoginForm : IForm 
    {
        public LoginForm(Startup context)
        {
            InitializeComponent();
            _ctrl = context.GetLoginCtrl();
            tb = new TextBox();
            btn = new Button();
            tb.Location = new Point(Top);
            btn.Location = new Point(Bottom);
            btn.Text = "Click me";
            Controls.Add(tb);
            Controls.Add(btn);
            btn.Click += new EventHandler(BtnEventHandler);
        }

    }
}
