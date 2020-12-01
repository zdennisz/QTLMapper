using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTLProject.Enums;
using QTLProject.Views;
using QTLProject.Utils;
using System.IO;

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
                button.BackColor = ColorTranslator.FromHtml("#ebf9fc");
                button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#ebf9fc");
                button.Size = new Size(48, 48);
                button.Image = (Image)(new Bitmap(button.Image, new Size(28, 28)));

            }


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
            //TODO make the presentor preform the actions

            inputDataPresentor.DeleteTableRow();

        }

        private void BtnPasteData_MouseClick(object sender, MouseEventArgs e)
        {
            //TODO make the presentor preform the actions
            throw new NotImplementedException();
        }


        private void BtnCutData_MouseClick(object sender, MouseEventArgs e)
        {
            //TODO make the presentor preform the actions
            throw new NotImplementedException();
        }

        private void BtnCopyData_MouseClick(object sender, MouseEventArgs e)
        {
            //TODO make the presentor preform the actions
            int row;
           // inputDataPresentor.SaveTableRow(row);
        }

        private void BtnSaveData_MouseClick(object sender, MouseEventArgs e)
        {
            inputDataPresentor.SaveTableData();
        }

        private void BtnOpenData_MouseClick(object sender, MouseEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                   // inputDataPresentor.ReadDataFromFile(filePath);
                }
            }


        }

        private void BtnInsrData_MouseClick(object sender, MouseEventArgs e)
        {
            inputDataPresentor.AddTableRow();
        }

        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            nextButtonClicked?.Invoke(this, e);
        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            backButtonClicked?.Invoke(this, e);
        }
        #endregion Private Methods


    }
}
