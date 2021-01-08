using QTLProject.Enums;
using QTLProject.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QTLProject
{
    public partial class InputData : UserControl
    {
        #region Fields
        public event EventHandler nextButtonClicked;
        public event EventHandler backButtonClicked;

        InputDataPresentor inputDataPresentor;
        #endregion Fields

        #region Constructor
        public InputData()
        {

            InitializeComponent();
            SetupUI();

            inputDataPresentor = new InputDataPresentor(this.inputDataTable);
        }

        #endregion Constructor

        #region Private Methods

        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.Size = new Size(732, 601);

            foreach (Button button in this.flowLayoutPanel1.Controls)
            {
                button.BackColor = ColorConstants.toolbarButtonsColor;
                button.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
                button.Size = new Size(48, 48);
                button.Image = (Image)(new Bitmap(button.Image, new Size(28, 28)));
            }
            btnBack.BackColor = ColorConstants.toolbarButtonsColor;
            btnBack.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
            btnNext.BackColor = ColorConstants.toolbarButtonsColor;
            btnNext.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;

            this.btnSaveData.Enabled = false;
            this.btnPasteData.Enabled = false;
            this.btnInsrData.Enabled = false;
            this.btnDelData.Enabled = false;
            this.btnCopyData.Enabled = false;

            setupEvents();
            setupToolTips();
        }
        /// <summary>
        /// Initializes the tool tips
        /// </summary>
        private void setupToolTips()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnOpenData, Constants.LoadFile);
            toolTip.SetToolTip(btnSaveData, Constants.SaveFile);
            toolTip.SetToolTip(btnCopyData, Constants.CopiesRows);
            toolTip.SetToolTip(btnPasteData, Constants.PasteRows);
            toolTip.SetToolTip(btnInsrData, Constants.InsertRows);
            toolTip.SetToolTip(btnDelData, Constants.RemoveRows);
            toolTip.SetToolTip(btnNext, Constants.GoToNextStage);
            toolTip.SetToolTip(btnBack, Constants.GoToPrevStage);
        }
        /// <summary>
        /// Signs up for all the events
        /// </summary>
        private void setupEvents()
        {
            this.btnBack.MouseClick += BtnBack_MouseClick;
            this.btnNext.MouseClick += BtnNext_MouseClick;
            this.btnOpenData.MouseClick += BtnOpenData_MouseClick;
            this.btnSaveData.MouseClick += BtnSaveData_MouseClick;
            this.btnCopyData.MouseClick += BtnCopyData_MouseClick;
            this.btnCutData.MouseClick += BtnCutData_MouseClick;
            this.btnPasteData.MouseClick += BtnPasteData_MouseClick;
            this.btnDelData.MouseClick += BtnDelData_MouseClick;
            this.btnInsrData.MouseClick += BtnInsrData_MouseClick;
        }
        private void BtnDelData_MouseClick(object sender, MouseEventArgs e)
        {


            inputDataPresentor.DeleteTableRow();

        }

        private void BtnPasteData_MouseClick(object sender, MouseEventArgs e)
        {

            inputDataPresentor.PasteTableRows();
        }


        private void BtnCutData_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void BtnCopyData_MouseClick(object sender, MouseEventArgs e)
        {


            inputDataPresentor.CopyTableRow();
        }

        private void BtnSaveData_MouseClick(object sender, MouseEventArgs e)
        {

            //save the tabledata to new folder

            inputDataPresentor.SaveDataToNewFile(notifyInputDataSaved);
            
        }

        private void BtnOpenData_MouseClick(object sender, MouseEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.Title = "Load Genetic Map data";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    inputDataPresentor.ReadDataFromFile(filePath);
                    this.btnSaveData.Enabled = true;
                    this.btnPasteData.Enabled = true;
                    this.btnInsrData.Enabled = true;
                    this.btnDelData.Enabled = true;
                    this.btnCopyData.Enabled = true;
                }
            }


        }

        private void BtnInsrData_MouseClick(object sender, MouseEventArgs e)
        {
            inputDataPresentor.AddTableRow();
        }

        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            inputDataPresentor.SaveTableData();
            if (inputDataPresentor.CheckDataAviliablity())
            {
                
                nextButtonClicked?.Invoke(this, e);
            }
            else
            {
                MessageBox.Show("Please load genetic map", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            backButtonClicked?.Invoke(this, e);
        }
      

        #endregion Private Methods


    }
}
