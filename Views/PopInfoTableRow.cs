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
    public partial class PopInfoTableRow : UserControl
    {
        public event EventHandler<EventArgsRowsAmount> AmountOfRows;
        public string textVal;
        public PopInfoTableRow()
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
            if (verifyNumber(this.rowTextBox.Text.ToString()))
            {
                EventArgsRowsAmount args = new EventArgsRowsAmount();
                args.AmountOfRows = Convert.ToInt32(this.rowTextBox.Text.ToString());
                AmountOfRows?.Invoke(this, args);
            }

        }

        private bool verifyNumber(string value)
        {
            int valueToConvert;

            return int.TryParse(value, out valueToConvert);
        }

        public void setTextBoxBackgroundColor(Color c1)
        {
           
        }

        public class EventArgsRowsAmount : EventArgs
        {
            public int AmountOfRows { get; set; }
        }
       
    }
}
