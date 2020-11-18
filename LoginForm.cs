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
        private Button submitBtn;
        private TextBox usernameBox, passwordBox;
        private Label message;

        public LoginForm(LoginCtrl ctrl)
        {
            InitializeComponent();
            _ctrl = ctrl;
            LoginForm_Load();
        }
    }
}
