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
    public partial class GeneticTableRow : UserControl
    {
        public Dictionary<int, string> tableRow = new Dictionary<int, string>();
        public GeneticTableRow( )
        {
            
            InitializeComponent();
            foreach(TextBox tb in this.Controls)
            {
                tb.BorderStyle = BorderStyle.None;
                tb.Controls.Add(new Label()
                { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
                tb.BackColor = this.BackColor;
            }
            this.textBox1.TextChanged += TextBox1_TextChanged;
            this.textBox2.TextChanged += TextBox2_TextChanged;
            this.textBox3.TextChanged += TextBox3_TextChanged;


        }


        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            this.tableRow[2]= this.textBox3.Text;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            this.tableRow[1]= this.textBox2.Text;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            this.tableRow[0]= this.textBox1.Text;
        }

        public void setTextBoxBackgroundColor(Color backColor)
        {

            foreach(TextBox tb in this.Controls)
            {
                tb.BackColor = backColor;
            }
        }

     

    }
}
