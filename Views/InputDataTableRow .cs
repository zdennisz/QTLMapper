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
    public partial class InputDataTableRow : UserControl
    {
      
        public InputDataTableRow( )
        {
           
            InitializeComponent();
            foreach(TextBox tb in this.Controls)
            {
                tb.BorderStyle = BorderStyle.None;
                tb.Controls.Add(new Label()
                { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
                tb.BackColor = this.BackColor;
            }
            

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
