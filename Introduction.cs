﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTLProject
{
    public partial class Introduction : UserControl
    {
        public Introduction()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.btnHelp.Click += BtnHelp_Click;
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            //To Do
            //open help window and  explain what does the app do with screen shots.
        }
    }
}
