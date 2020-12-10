using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTLProject
{
    public partial class HelpWindow : Form
    {
        public HelpWindow()
        {
            InitializeComponent();
            this.tabPage1.Text = "About";
            TextBox tb1 = new TextBox();
            tb1.Text = "QTL mapper tool..";
            this.tabPage1.Controls.Add(tb1);
            

            this.tabPage2.Text = "Contact";
            TextBox tb2 = new TextBox();
            tb2.Text = "Braude College";
            this.tabPage2.Controls.Add(tb2);
        }
    }
}
