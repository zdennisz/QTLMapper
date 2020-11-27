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
        #endregion Fields

        #region Constructor
        public InputData()
        {
           
            InitializeComponent();
            SetupUI();
            inputDatatable = new TableGenerator(this.inputDataTable);
            CreateTableColumns();
          
            this.btnBack.MouseClick += BtnBack_MouseClick;
            this.btnNext.MouseClick += BtnNext_MouseClick;

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
