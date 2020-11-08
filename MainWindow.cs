using QTLProject;
using System;
using System.Drawing;
using System.Windows.Forms;
using static QTLProject.Types;

namespace QTLbyRegression
{
    public partial class MainWindow : Form
    {
        #region Fields
        #endregion Fields

        #region Constructor
        
        public MainWindow()
        {
           
            InitializeComponent();
            SetupUI();
       
        }
        #endregion Constructor

        #region Private Methods

        

        /// <summary>
        /// Basic set up for the UI
        /// </summary>
        private void SetupUI()
        {
            //Set the background color 
            this.BackColor = Color.FromArgb(239, 252, 255);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.contentPanel.BackColor = Color.White;
            this.contentPanel.Paint += ContentPanel_Paint;
            updateButtons(SoftwareStep.None);



        }

        private void ContentPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

      
        /// <summary>
        /// Applies the selected button effect
        /// </summary>
        /// <param name="ss"></param>
        private void updateButtons(SoftwareStep ss)
        {
            //enables only the selected button
            if (ss != SoftwareStep.None)
            {
                this.btnCalculateQTL.BackColor = Color.FromArgb(239, 252, 255);
                this.btnInputData.BackColor = Color.FromArgb(239, 252, 255);
                this.btnSimulateData.BackColor = Color.FromArgb(239, 252, 255);
                this.btnViewResults.BackColor = Color.FromArgb(239, 252, 255);
            }
            switch (ss)
            {
                case SoftwareStep.CalculateData:
                    this.btnCalculateQTL.BackColor = Color.FromArgb(255, 255, 255);
                    this.btnCalculateQTL.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                    break;
                case SoftwareStep.InputData:
                    this.btnInputData.BackColor = Color.FromArgb(255, 255, 255);
                    this.btnInputData.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                    break;

                case SoftwareStep.SimulateData:
                    this.btnSimulateData.BackColor = Color.FromArgb(255, 255, 255);
                    this.btnSimulateData.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                    break;

                case SoftwareStep.ViewResults:
                    this.btnViewResults.BackColor = Color.FromArgb(255, 255, 255);
                    this.btnViewResults.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                    break;

                case SoftwareStep.None:
                    this.btnCalculateQTL.BackColor = Color.FromArgb(239, 252, 255);
                    this.btnInputData.BackColor = Color.FromArgb(239, 252, 255);
                    this.btnSimulateData.BackColor = Color.FromArgb(239, 252, 255);
                    this.btnViewResults.BackColor = Color.FromArgb(239, 252, 255);
                    break;
            }
        }

        private void btnSimulateData_Click(object sender, EventArgs e)
        {

            updateButtons(SoftwareStep.SimulateData);

            SimulateData simData = new SimulateData();

            this.contentPanel.Controls.Clear();
            this.contentPanel.Controls.Add(simData);




        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
          
            updateButtons(SoftwareStep.ViewResults);
            ViewResults vr = new ViewResults();
            
                this.contentPanel.Controls.Clear();
                this.contentPanel.Controls.Add(vr);

            
            
        
        }

        private void btnInputData_Click(object sender, EventArgs e)
        {
           
            updateButtons(SoftwareStep.InputData);
            InputData inputData = new InputData();
            
                this.contentPanel.Controls.Clear();
                this.contentPanel.Controls.Add(inputData);
            

        }

        private void btnCalculateQTL_Click(object sender, EventArgs e)
        {
            
            updateButtons(SoftwareStep.CalculateData);
            CalculateQTL calclQTL = new CalculateQTL();
            
                this.contentPanel.Controls.Clear();
                this.contentPanel.Controls.Add(calclQTL);
            
       
        }
        #endregion Private Methods
    }
}
