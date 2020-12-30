using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using static QTLProject.Types;
using QTLProject.Enums;
using QTLProject.Utils;
using static QTLProject.Views.PopInfoTableRow;

namespace QTLProject
{
    public partial class SimulateData : UserControl
    {
        #region Fields
        TableGenerator genetictable;
        TableGenerator traitTable;
        TableGenerator popInfoTable;
        DataGeneratorPresentor dgp;
        #endregion Fields

        #region Events
        public event EventHandler nextButtonClicked;
        public event EventHandler backButtonClicked;
        #endregion Events
        #region Constructor
        public SimulateData()
        {
            InitializeComponent();
            setupUI();
            genetictable = new TableGenerator(this.tableGeneticModel);
            traitTable = new TableGenerator(this.panelTableContainer);
            popInfoTable = new TableGenerator(this.tableDataPrecentage);
            //set the format of the dates
            this.btnNext.MouseClick += BtnNext_MouseClick;
            this.btnBack.MouseClick += BtnBack_MouseClick;
            this.comboBoxTrait.SelectedIndexChanged += ComboBoxTrait_SelectedIndexChanged;
            popInfoTable.AmountOfRowsChanged += PopInfoTable_AmountOfRowsChanged;
            generateGeneticTable();
            generatePopInfoTable();

            SetDateTimeFormat();
            /* 
             * DataGeneratorPresentor dgp = new DataGeneratorPresentor();
             dgp.DefineChromosomeLength();
             dgp.DefineChromosomePositions();
             dgp.DefineParentalHaplotypes();
             dgp.SimulateRecombination();
             dgp.DefineQTL();
            */
        }

        private void PopInfoTable_AmountOfRowsChanged(object sender, EventArgsRowsAmount e)
        {
            int currRows = genetictable.GetGeneticTableAmountOfRows();
            if (currRows < e.AmountOfRows && e.AmountOfRows > 0)
            {
                //add rows
                var deltaInRows = e.AmountOfRows - currRows;
                genetictable.AddTableRow(deltaInRows, TableRowType.GeneticDataRow);
            }
            else if (currRows > e.AmountOfRows && e.AmountOfRows > 0)
            {
                //delete rows
                var deltaInRows = currRows - e.AmountOfRows;
                genetictable.DeleteTableRow(deltaInRows);
            }

        }

        private void generatePopInfoTable()
        {
            List<string> tableParams = new List<string>();
            tableParams.Add(Constants.PopSize);
            tableParams.Add(Constants.MissingData);
            tableParams.Add(Constants.Error);
            tableParams.Add(Constants.ChrAmount);

            popInfoTable.GeneratePopInfoTable(tableParams, 25, 100, 2);
            popInfoTable.InitPopInfoDefaultData(200, 3);
        }

        private void generateGeneticTable()
        {
            List<string> geneticParams = new List<string>();
            geneticParams.Add(Constants.ChrNum);
            geneticParams.Add(Constants.ChrLen);
            geneticParams.Add(Constants.MarkerPerCM);
            genetictable.CreateGeneticTable(geneticParams, 25, 400, geneticParams.Count, 4);
            List<string> defaultValues = new List<string>();
            defaultValues.Add("1");
            defaultValues.Add("75");
            defaultValues.Add("2");
            defaultValues.Add("107");
            defaultValues.Add("3");
            defaultValues.Add("110");
            genetictable.InitGeneticTableDefaultData(defaultValues);

        }
        private void ComboBoxTrait_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTraitTable((QTLTaritModels)this.comboBoxTrait.SelectedIndex);
        }



        private void updateTraitTable(QTLTaritModels tableType)
        {

            int tableAmount = 0;
            List<string> taritModelParams = new List<string>();

            foreach (TableLayoutPanel panel in this.panelTableContainer.Controls)
            {
                panel.Visible = false;
            }
            if (tableType != QTLTaritModels.NoQTL)
            {
                tableAmount++;
                taritModelParams.Add(Constants.QtlPos);
                taritModelParams.Add(Constants.QTLChr);
                taritModelParams.Add(Constants.VarQ);
                taritModelParams.Add(Constants.Varq);
                taritModelParams.Add(Constants.AvgQ);
                taritModelParams.Add(Constants.Avgq);
                taritModelParams.Add(Constants.DominanceEffect);

                if (tableType == QTLTaritModels.TwoLinkedQTL)
                {
                    tableAmount++;
                }
                traitTable.CreateTraitTable(tableAmount, taritModelParams, 25, 75, 2);
                List<string> defaultValues = new List<string>();
                defaultValues.Add("40");
                defaultValues.Add("1");
                defaultValues.Add("1");
                defaultValues.Add("1");
                defaultValues.Add("1");
                defaultValues.Add("0");
                defaultValues.Add("0.5");
                traitTable.InitTraitTableDefaultData(tableAmount, defaultValues);
            }


        }



        private void setupUI()
        {
            List<string> geneticModel = new List<string>();
            geneticModel.Add("Backcross");
            this.Dock = DockStyle.Fill;
            this.comboBoxGenetic.Items.AddRange(geneticModel.ToArray());
            this.comboBoxGenetic.SelectedIndex = 0;

            List<string> traitModels = new List<string>();
            traitModels.Add(Constants.NoQTL);
            traitModels.Add(Constants.OneQTL);
            traitModels.Add(Constants.DominantQTL);
            traitModels.Add(Constants.TwoLinkedQTL);
            this.comboBoxTrait.Items.AddRange(traitModels.ToArray());
            this.comboBoxTrait.SelectedIndex = 0;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnBack, Constants.GoToPrevStage);
            toolTip.SetToolTip(btnNext, Constants.GoToNextStage);

            btnBack.BackColor = ColorConstants.toolbarButtonsColor;
            btnBack.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
            btnNext.BackColor = ColorConstants.toolbarButtonsColor;
            btnNext.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;

        }
        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            backButtonClicked?.Invoke(this, e);
        }

        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            



            // dgp.DefineParentalHaplotypes();
            // dgp.SimulateRecombination();
            //dgp.DefineQTL();

            
            if (GenerateGeneticMap())
            {
                MessageBox.Show("Data Generated Successfully at " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\GeneticMap_CurrentDate"+"\n\nYou can go to Input data and use the data as the Genetic Map.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data was not generated since empty lines detected at genetic map table.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }
        #endregion Constructor

        /// <summary>
        /// Applies a date and time format  
        /// </summary>
        private void SetDateTimeFormat()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd_MM_yyyy H_mm_ss";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }
        public void GenerateData()
        {
            DateTime dateTime = DateTime.Now;



            //Step 1 - Table of Geneotypes
            generateTableOfGenotypes(dateTime);

            //Step 2 - Generate genetic map
            //done!

            //Step 3 - Generate Table of traits
            generateTableOfTraits(dateTime);




        }



        private void generateTableOfGenotypes(DateTime dateTime)
        {
            var delimiter = "\t";

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + "\\Genotype_" + dateTime.ToString() + ".CSV";
            using (var writer = new StreamWriter(filePath))
            {
                //    var line = string.Join(delimiter, itemContent);
                //    writer.WriteLine(line);
            }
        }

        private bool produceData(List<Dictionary<int, string>> data)
        {
            DateTime dateTime = DateTime.Now;
            dgp.DefineChromosomeLength();
            dgp.DefineChromosomePositions();
            var delimiter = "\t";

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + "\\GeneticMap_" + dateTime.ToString() + ".txt";
           
            return dgp.SaveGeneticMap(filePath);

        }
        /// <summary>
        /// Generates the genetic map for the organism
        /// </summary>
        private bool GenerateGeneticMap()
        {
            bool dataVerified = true;
            // checks which organism is it 
            var data = genetictable.RetreiveTableData();
            foreach (Dictionary<int, string> dic in data)
            {
                if (dic.Count < 3)
                {
                    dataVerified = false;
                    break;
                }
            }
            if (dataVerified == true)
            {
                string lengthOfChr1 = Convert.ToString(75);
                string lengthOfChr2 = Convert.ToString(107);
                string lengthOfChr3 = Convert.ToString(110);
                if (data.Count == 3 && data[0][1].Equals(lengthOfChr1) && data[1][1].Equals(lengthOfChr2) && data[2][1].Equals(lengthOfChr3))
                {
                    dgp = new DataGeneratorPresentor(3, OrganismType.Drosophila);
                }
                else
                {
                    dgp = new DataGeneratorPresentor(data.Count, OrganismType.Random, data);
                }
                
                return produceData(data);
            }
            return false;
        }

        private void generateTableOfTraits(DateTime dateTime)
        {
            var delimiter = "\t";

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + "\\TraitTable_" + dateTime.ToString() + ".CSV";

            using (var writer = new StreamWriter(filePath))
            {
                //    var line = string.Join(delimiter, itemContent);
                //    writer.WriteLine(line);
            }
        }


    }
}
