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
    public partial class InputDataTableHeader : UserControl
    {
        List<Label> labels = new List<Label>();
       
        public InputDataTableHeader()
        {
            InitializeComponent();

            initLabels();
            
        }



        private void initLabels()
        {
            foreach (Label l in this.Controls)
            {
                labels.Add(l);
            }
        }

        public void InitHeaderNames(List<string> names)
        {
            int i=0; 
           
            while (i < names.Count)
            {
                labels[i].Text = names[i];
                i++;
            }


        }

    }
}
