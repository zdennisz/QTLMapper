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

namespace QTLProject
{
    public partial class ViewResults : UserControl
    {
        public event EventHandler<EventArgsViewResults> backButtonClicked;
        private SoftwareStep prevStep;
        public ViewResults()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.btnBack.MouseClick += BtnBack_MouseClick;
           
        }

        public void updateInternalstate(SoftwareStep step)
        {
            this.prevStep = step;
        }
        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            EventArgsViewResults args = new EventArgsViewResults();
            args.PrevoiusStep = prevStep;
            backButtonClicked?.Invoke(this, args);
        }

        public class EventArgsViewResults : EventArgs
        {
            public SoftwareStep PrevoiusStep { get; set; }
        }

       
    }
}
