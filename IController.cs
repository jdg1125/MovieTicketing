﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms;

namespace Controllers
{
    public abstract class IController
    {
        protected IForm _form;
        protected DBConnector _dbConn;

        public abstract void Initiate(string s);

        
    }
}
