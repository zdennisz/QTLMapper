using QTLProject;
using QTLProject.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;
using static QTLProject.Types;

namespace QTLbyRegression
{
    public partial class MainWindow : Form
    {
        #region Fields

        private State internalState = new State();
        SimulateData simData = new SimulateData();
        ViewResults vResults = new ViewResults();
        InputData inputData = new InputData();
        CalculateQTL calcQTL = new CalculateQTL();
        Introduction introPage = new Introduction();
        Label bottomBorder = new Label() { Height = 2, Dock = DockStyle.Bottom, BackColor = Color.LightGray };
        Label topBorder = new Label() { Height = 1, Dock = DockStyle.Top, BackColor = Color.Black };
        #endregion Fields

        #region Constructor

        public MainWindow()
        {

            InitializeComponent();
            SetupUI();
            internalState.StateChange += InternalState_StateChange;
            inputData.nextButtonClicked += InputData_nextButtonClicked;
            inputData.backButtonClicked += InputData_backButtonClicked;
            simData.backButtonClicked += SimData_backButtonClicked;
            calcQTL.nextButtonClicked += CalcQTL_nextButtonClicked;
            calcQTL.backButtonClicked += CalcQTL_backButtonClicked;
            vResults.backButtonClicked += VResults_backButtonClicked2;
        }
        #endregion Constructor

        #region Events
        private void VResults_backButtonClicked2(object sender, ViewResults.EventArgsViewResults e)
        {
            if (e.PrevoiusStep == SoftwareStep.SimulateData)
            {
                internalState.UpdateState(SoftwareStep.SimulateData, SoftwareStep.ViewResults, false);
            }
            else if (e.PrevoiusStep == SoftwareStep.CalculateData)
            {
                internalState.UpdateState(SoftwareStep.CalculateData, SoftwareStep.ViewResults, false);
            }
            else
            {
                internalState.UpdateState(SoftwareStep.None, SoftwareStep.ViewResults, false);
            }
        }


        private void CalcQTL_backButtonClicked(object sender, EventArgs e)
        {
            internalState.UpdateState(SoftwareStep.InputData, SoftwareStep.CalculateData, false);
        }

        private void CalcQTL_nextButtonClicked(object sender, EventArgs e)
        {
            internalState.UpdateState(SoftwareStep.ViewResults, SoftwareStep.CalculateData, true);
        }

        private void SimData_backButtonClicked(object sender, EventArgs e)
        {
            internalState.UpdateState(SoftwareStep.None, SoftwareStep.SimulateData, false);
        }


        private void InputData_backButtonClicked(object sender, EventArgs e)
        {
            internalState.UpdateState(SoftwareStep.None, SoftwareStep.InputData, false);
        }

        private void InputData_nextButtonClicked(object sender, EventArgs e)
        {
            internalState.UpdateState(SoftwareStep.CalculateData, SoftwareStep.InputData, true);
        }

        #endregion Events



        #region Private Methods

        private void InternalState_StateChange(object sender, State.StateUpdate e)
        {
            //this is the if statment that indicates that we are going forward
            if (e.GoingForward)
            {
                if (e.PrevoiusStep == SoftwareStep.None && e.CurrentStep == SoftwareStep.InputData)
                {
                    //disable the simulate and view and calc
                    updateButtons(SoftwareStep.InputData);
                    updateView(SoftwareStep.InputData);
                }
                else if (e.PrevoiusStep == SoftwareStep.InputData && e.CurrentStep == SoftwareStep.CalculateData)
                {
                    //disable simulate view 
                    updateButtons(SoftwareStep.CalculateData);
                    updateView(SoftwareStep.CalculateData);
                }
                else if (e.PrevoiusStep == SoftwareStep.CalculateData && e.CurrentStep == SoftwareStep.ViewResults)
                {
                    //disable the simulate and calc
                    vResults.updateInternalstate(SoftwareStep.CalculateData);
                    updateButtons(SoftwareStep.ViewResults);
                    updateView(SoftwareStep.ViewResults);
                }
                else if (e.PrevoiusStep == SoftwareStep.None && e.CurrentStep == SoftwareStep.SimulateData)
                {
                    updateButtons(SoftwareStep.SimulateData);
                    updateView(SoftwareStep.SimulateData);
                }
                else if (e.PrevoiusStep == SoftwareStep.SimulateData && e.CurrentStep == SoftwareStep.ViewResults)
                {
                    vResults.updateInternalstate(SoftwareStep.SimulateData);
                    updateButtons(SoftwareStep.ViewResults);
                    updateView(SoftwareStep.ViewResults);
                }
                else if (e.PrevoiusStep == SoftwareStep.None && e.CurrentStep == SoftwareStep.ViewResults)
                {
                    vResults.updateInternalstate(SoftwareStep.None);
                    updateButtons(SoftwareStep.ViewResults);
                    updateView(SoftwareStep.ViewResults);
                }
            }
            else
            {
                //this is the if statment that indicates that we are going backwards
                if (e.PrevoiusStep == SoftwareStep.ViewResults && e.CurrentStep == SoftwareStep.CalculateData)
                {
                    updateButtons(SoftwareStep.CalculateData);
                    updateView(SoftwareStep.CalculateData);
                }
                else if (e.PrevoiusStep == SoftwareStep.CalculateData && e.CurrentStep == SoftwareStep.InputData)
                {
                    updateButtons(SoftwareStep.InputData);
                    updateView(SoftwareStep.InputData);
                }
                else if (e.PrevoiusStep == SoftwareStep.ViewResults && e.CurrentStep == SoftwareStep.SimulateData)
                {
                    updateButtons(SoftwareStep.SimulateData);
                    updateView(SoftwareStep.SimulateData);
                }
                else if (e.PrevoiusStep == SoftwareStep.InputData && e.CurrentStep == SoftwareStep.None)
                {
                    updateButtons(SoftwareStep.None);
                    updateView(SoftwareStep.None);

                }
                else if (e.PrevoiusStep == SoftwareStep.SimulateData && e.CurrentStep == SoftwareStep.None)
                {
                    updateButtons(SoftwareStep.None);
                    updateView(SoftwareStep.None);
                }
                else if (e.PrevoiusStep == SoftwareStep.ViewResults && e.CurrentStep == SoftwareStep.None)
                {
                    updateButtons(SoftwareStep.None);
                    updateView(SoftwareStep.None);
                }


            }

        }

        private void updateView(SoftwareStep stepToAddToMainWindow)
        {
            //clear all other views
            this.contentPanel.Controls.Clear();
            UserControl refrence = null;
            switch (stepToAddToMainWindow)
            {
                case SoftwareStep.None:
                    refrence = introPage;
                    break;
                case SoftwareStep.InputData:
                    refrence = inputData;
                    break;
                case SoftwareStep.CalculateData:
                    refrence = calcQTL;
                    break;
                case SoftwareStep.ViewResults:
                    refrence = vResults;
                    break;
                case SoftwareStep.SimulateData:
                    refrence = simData;
                    break;
            }

            //add only the selected view
            this.contentPanel.Controls.Add(refrence);
        }

        /// <summary>
        /// Basic set up for the UI
        /// </summary>
        private void SetupUI()
        {
            //Set the background color 
            this.BackColor = ColorConstants.backgroundColor;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.contentPanel.BackColor = Color.White;
            this.contentPanel.Paint += ContentPanel_Paint;
            this.btnCalculateQTL.Click += BtnCalculateQTL_Click;
            this.menuPanel.Controls.Add(topBorder);
            this.btnCalculateQTL.Text = "Calculate QTL location && P-Value";
            this.btnCalculateQTL.Font = new Font("Arial", 12, FontStyle.Regular);

            updateButtons(SoftwareStep.None);
            updateView(SoftwareStep.None);
        }

        private void BtnCalculateQTL_Click(object sender, EventArgs e)
        {
            //TO DO :
            // need to prevent the ability to click this button without changing the color 
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
                this.btnCalculateQTL.BackColor = ColorConstants.backgroundColor;
                this.btnInputData.BackColor = ColorConstants.backgroundColor;
                this.btnSimulateData.BackColor = ColorConstants.backgroundColor;
                this.btnViewResults.BackColor = ColorConstants.backgroundColor;

                this.btnCalculateQTL.Controls.Remove(bottomBorder);
                this.btnInputData.Controls.Remove(bottomBorder);
                this.btnSimulateData.Controls.Remove(bottomBorder);
                this.btnViewResults.Controls.Remove(bottomBorder);
            }
            switch (ss)
            {
                case SoftwareStep.CalculateData:
                    this.btnCalculateQTL.BackColor = ColorConstants.backgroundContrastColor;
                    this.btnCalculateQTL.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                    this.btnCalculateQTL.Controls.Add(bottomBorder);
                    break;
                case SoftwareStep.InputData:
                    this.btnInputData.BackColor = ColorConstants.backgroundContrastColor;
                    this.btnInputData.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                    this.btnInputData.Controls.Add(bottomBorder);
                    break;

                case SoftwareStep.SimulateData:
                    this.btnSimulateData.BackColor = ColorConstants.backgroundContrastColor;
                    this.btnSimulateData.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                    this.btnSimulateData.Controls.Add(bottomBorder);
                    break;

                case SoftwareStep.ViewResults:
                    this.btnViewResults.BackColor = ColorConstants.backgroundContrastColor;
                    this.btnViewResults.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
                    this.btnViewResults.Controls.Add(bottomBorder);
                    break;

                case SoftwareStep.None:
                    this.btnCalculateQTL.BackColor = ColorConstants.backgroundColor;
                    this.btnInputData.BackColor = ColorConstants.backgroundColor;
                    this.btnSimulateData.BackColor = ColorConstants.backgroundColor;
                    this.btnViewResults.BackColor = ColorConstants.backgroundColor;

                    this.btnCalculateQTL.Controls.Remove(bottomBorder);
                    this.btnInputData.Controls.Remove(bottomBorder);
                    this.btnSimulateData.Controls.Remove(bottomBorder);
                    this.btnViewResults.Controls.Remove(bottomBorder);

                    break;
            }
        }

        private void btnSimulateData_Click(object sender, EventArgs e)
        {
            internalState.UpdateState(SoftwareStep.SimulateData, SoftwareStep.None, true);

        }

        private void btnInputData_Click(object sender, EventArgs e)
        {
            internalState.UpdateState(SoftwareStep.InputData, SoftwareStep.None, true);

        }

        #endregion Private Methods
    }
}
