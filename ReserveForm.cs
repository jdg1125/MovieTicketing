﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Control;

namespace Boundary
{
    public partial class ReserveForm : IForm
    {
        public ReserveForm(ReserveCtrl ctrl)
        {
            InitializeComponent();
            _ctrl = ctrl;
            ReserveForm_Load();
        }
    }
}
