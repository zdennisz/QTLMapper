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
    public partial class TraitTableRow : UserControl
    {
        public string textVal;
        public TraitTableRow()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.rowTextBox.BorderStyle = BorderStyle.None;
            this.rowTextBox.Controls.Add(new Label()
            { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
            this.rowTextBox.TextChanged += RowTextBox_TextChanged;

        }

        private void RowTextBox_TextChanged(object sender, EventArgs e)
        {
            textVal = this.rowTextBox.Text;
        }
    }
}
