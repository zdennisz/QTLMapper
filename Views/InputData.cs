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

namespace QTLProject
{
    public partial class InputData : UserControl
    {
        #region Fields
        public event EventHandler nextButtonClicked;
        public event EventHandler backButtonClicked;
        TableGenerator inputDatatable ;
        InputDataPresentor inputDataPresentor;
        #endregion Fields

        #region Constructor
        public InputData()
        {
           
            InitializeComponent();
            SetupUI();
            inputDatatable = new TableGenerator(this.inputDataTable);
            CreateTableColumns();
            inputDataPresentor = new InputDataPresentor();
        }

        private void BtnDelData_MouseClick(object sender, MouseEventArgs e)
        {
            //TODO make the presentor preform the actions

            throw new NotImplementedException();
        }

        private void BtnPasteData_MouseClick(object sender, MouseEventArgs e)
        {
            //TODO make the presentor preform the actions
            throw new NotImplementedException();
        }

        private void BtnEditData_MouseClick(object sender, MouseEventArgs e)
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
            throw new NotImplementedException();
        }

        private void BtnSaveData_MouseClick(object sender, MouseEventArgs e)
        {
            //TODO make the presentor preform the actions
            throw new NotImplementedException();
        }

        private void BtnOpenData_MouseClick(object sender, MouseEventArgs e)
        {
            //TODO make the presentor preform the actions
            throw new NotImplementedException();
        }

        private void CreateTableColumns()
        {
            List<string> geneticParams = new List<string>();
            geneticParams.Add(Constants.Marker);
            geneticParams.Add(Constants.CoorcM);
            geneticParams.Add(Constants.Chr);
            geneticParams.Add(Constants.Quality);
            
            inputDatatable.CreateInputDataTable(geneticParams, 25, 400, 4, 14);
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
                button.FlatAppearance.BorderColor= ColorTranslator.FromHtml("#ebf9fc");
            }

            this.btnBack.MouseClick += BtnBack_MouseClick;
            this.btnNext.MouseClick += BtnNext_MouseClick;
            this.btnOpenData.MouseClick += BtnOpenData_MouseClick;
            this.btnSaveData.MouseClick += BtnSaveData_MouseClick;
            this.btnCopyData.MouseClick += BtnCopyData_MouseClick;
            this.btnCutData.MouseClick += BtnCutData_MouseClick;
            this.btnEditData.MouseClick += BtnEditData_MouseClick;
            this.btnPasteData.MouseClick += BtnPasteData_MouseClick;
            this.btnDelData.MouseClick += BtnDelData_MouseClick;

            this.btnInsrData.Enabled = false;
            this.btnSortAsc.Enabled = false;
            this.btnSortDsc.Enabled = false;

            this.btnInsrData.Visible = false;
            this.btnSortAsc.Visible = false;
            this.btnSortDsc.Visible = false;

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
