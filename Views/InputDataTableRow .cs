using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QTLProject.Types;

namespace QTLProject.Views
{
    public partial class InputDataTableRow : UserControl
    {
        public Dictionary<int, string> tableRow = new Dictionary<int, string>();
        public int rowIndex;
        public event EventHandler RowChecked;
        public InputDataTableRow(int rowIndex)
        {
            this.rowIndex = rowIndex;
            InitializeComponent();
            foreach (var tb in this.Controls.OfType<TextBox>())
            {

                tb.BorderStyle = BorderStyle.None;
                tb.Controls.Add(new Label()
                { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
                tb.BackColor = this.BackColor;

            }

            this.textBox1.TextChanged += TextBox1_TextChanged;
            this.textBox2.TextChanged += TextBox2_TextChanged;
            
            this.textBox4.TextChanged += TextBox4_TextChanged;
            this.selectedRow.CheckedChanged += SelectedRow_CheckedChanged;
        }

        private void SelectedRow_CheckedChanged(object sender, EventArgs e)
        {
            RowChecked?.Invoke(this, e);
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            tableRow[2] = this.textBox4.Text;
        }


        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            tableRow[1] = this.textBox2.Text;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            tableRow[0] = this.textBox1.Text;
        }

        public void setTextBoxBackgroundColor(Color backColor)
        {

            foreach (var tb in this.Controls.OfType<TextBox>())
            {
                tb.BackColor = backColor;
            }

        }

     
    }
}
