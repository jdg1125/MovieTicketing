﻿using System;
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
    public partial class LogoutForm : IForm
    {
        private Button yes;
        private Label message;

        public LogoutForm(LogoutCtrl ctrl)
        {
            InitializeComponent();
            _ctrl = ctrl;
            LogoutForm_Load();
        }
    }
}
