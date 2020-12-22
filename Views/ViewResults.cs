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
using QTLProject.Enums;
using System.Collections;
using QTLProject.Utils;

namespace QTLProject
{
    public partial class ViewResults : UserControl
    {
        public event EventHandler<EventArgsViewResults> backButtonClicked;
        private SoftwareStep prevStep;
        private string testType = "";

        public ViewResults()
        {

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            setupUI();
            setupEvents();
            setupCombobox();


        }

        private void setupUI()
        {

            this.btnBack.BackColor = ColorConstants.toolbarButtonsColor;
            this.btnBack.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;

            this.btnShowResutls.BackColor = ColorConstants.toolbarButtonsColor;
            this.btnShowResutls.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;

            this.btnOpenFolder.BackColor = ColorConstants.toolbarButtonsColor;
            this.btnOpenFolder.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
            this.btnOpenFolder.Size = new Size(60, 30);
            this.btnOpenFolder.Image = (Image)(new Bitmap(btnOpenFolder.Image, new Size(18, 18)));


            this.txtOpenFolder.BackColor = Color.White;
            this.txtOpenFolder.BorderStyle = BorderStyle.None;
            this.txtOpenFolder.Controls.Add(new Label()
            { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnBack, Constants.GoToPrevStage);
           

        }
        private void setupEvents()
        {
            this.btnBack.MouseClick += BtnBack_MouseClick;
            this.btnShowResutls.MouseClick += BtnShowResutls_MouseClick;
            this.btnOpenFolder.MouseClick += BtnOpenFolder_MouseClick;
            this.comboBoxFuncs.SelectedIndexChanged += ComboBoxFuncs_SelectedIndexChanged;
            this.ToggleButtonDisplayGraph.SliderValueChanged += ToggleButtonDisplayGraph_SliderValueChanged;
            this.ToggleButtonInDepthReport.SliderValueChanged += ToggleButtonInDepthReport_SliderValueChanged;
        }

        private void ToggleButtonInDepthReport_SliderValueChanged(object sender, EventArgs e)
        {
            bool buttonValue = (sender as CustomToggleButton).IsOn;
        }

        private void ToggleButtonDisplayGraph_SliderValueChanged(object sender, EventArgs e)
        {
            bool buttonValue = (sender as CustomToggleButton).IsOn;
        }

        private void setupCombobox()
        {

            ArrayList tests = new ArrayList() { Constants.DistributionTest, Constants.SingleMarkerTest, Constants.QTLPosition, Constants.QTLsEffect, Constants.TraitDistributionforQTLalleles, Constants.ModelComparison, Constants.Power };
            this.comboBoxFuncs.Items.AddRange(tests.ToArray());
            this.comboBoxFuncs.SelectedIndex = 0;
        }
     

        private void BtnOpenFolder_MouseClick(object sender, MouseEventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtOpenFolder.Text = fbd.SelectedPath;
        }

        private void ComboBoxFuncs_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.testType = (sender as ComboBox).Text.ToString();

        }

        private void BtnShowResutls_MouseClick(object sender, MouseEventArgs e)
        {
            if (!(this.testType.Equals(string.Empty)))
            {
                ShowResults sr = new ShowResults();
                sr.Show();
            }

        }

        public void updateInternalstate(SoftwareStep step)
        {
            this.prevStep = step;
            if (this.prevStep != SoftwareStep.None)
            {
                this.btnOpenFolder.Enabled = false;
              
            }
            else
            {
                this.btnOpenFolder.Enabled = true;

            }
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

        private void ViewResults_Load(object sender, EventArgs e)
        {

        }






    }
}
