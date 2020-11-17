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
            this.tabPage1.Text = "I love Banans";
            TextBox tb1 = new TextBox();
            tb1.Text = "I love nuts too";
            tb1.Name = "hey";
            this.tabPage1.Controls.Add(tb1);
            

            this.tabPage2.Text = "I love Apples";
            TextBox tb2 = new TextBox();
            tb2.Text = "I love Grains too";
            this.tabPage2.Controls.Add(tb2);
        }
    }
}
