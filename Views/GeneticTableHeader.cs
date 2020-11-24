using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTLProject.Views
{
    public partial class GeneticTableHeader : UserControl
    {
        public GeneticTableHeader()
        {
            InitializeComponent();
        }
       
        public void InitHeaderNames(List<string> names)
        {
            this.label1Col.Text = names[0];
            this.label2Col.Text = names[1];
            this.label3Col.Text = names[2];
            this.label4Col.Text = names[3];
            this.label5Col.Text = names[4];
            this.label6Col.Text = names[5];
        }
       
    }
}
