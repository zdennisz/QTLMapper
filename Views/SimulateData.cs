using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using static QTLProject.Types;
using QTLProject.Enums;
using System.Drawing;
using QTLProject.Views;

namespace QTLProject
{
    public partial class SimulateData : UserControl
    {

        #region Events
        public event EventHandler nextButtonClicked;
        public event EventHandler backButtonClicked;
        #endregion Events
        #region Constructor
        public SimulateData()
        {
            InitializeComponent();
            setupUI();
            //set the format of the dates
            this.btnNext.MouseClick += BtnNext_MouseClick;
            this.btnBack.MouseClick += BtnBack_MouseClick;
            this.comboBoxTrait.SelectedIndexChanged += ComboBoxTrait_SelectedIndexChanged;
            generateGeneticTable();

            SetDateTimeFormat();
            DataGeneratorPresentor dgp = new DataGeneratorPresentor();
            dgp.DefineChromosomeLength();
            dgp.DefineChromosomePositions();
            dgp.DefineParentalHaplotypes();
            dgp.SimulateRecombination();
            dgp.DefineQTL();

        }




        private void generateGeneticTable()
        {
            List<string> geneticParams = new List<string>();
            geneticParams.Add(Constants.ChrNum);
            geneticParams.Add(Constants.ChrLen);
            geneticParams.Add(Constants.MarkerPerChr);
            geneticParams.Add(Constants.PopSize);
            geneticParams.Add(Constants.MissingData);
            geneticParams.Add(Constants.Error);

            createTableCol(geneticParams, 25, 400, 6, 8);

        }
        private void ComboBoxTrait_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.labelTraitModel.Text = this.comboBoxTrait.SelectedItem.ToString();
            if (this.labelTraitModel.Text.Equals(Constants.NoQTL))
            {
                this.labelTraitModel.Visible = false;
            }
            else
            {
                this.labelTraitModel.Visible = true;
            }


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

                if (tableType == QTLTaritModels.TwoLinkedQTL)
                {
                    tableAmount++;
                }
                createTableRow(tableAmount, taritModelParams, 25, 75, 2);

            }

            //update the genetic table
        }

        private void createTableRow(int amountOftables, List<string> modelParams, float rowSize, float colSize, int colAmount)
        {

            for (int i = 0; i < amountOftables; i++)
            {
                int rowIndex = 0;
                var table = (TableLayoutPanel)this.panelTableContainer.Controls[i];
                table.Controls.Clear();
                table.RowStyles.Clear();
                table.ColumnCount = colAmount;
                table.RowCount = modelParams.Count + 1;

                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, colSize));
                Label placeHodler = new Label();
                placeHodler.Dock = DockStyle.Fill;
                placeHodler.BackColor = ColorConstants.tableHeaderColor;
                table.SetColumnSpan(placeHodler, table.ColumnCount);
                table.Controls.Add(placeHodler, 0, rowIndex);

                table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));
                rowIndex++;
                foreach (string name in modelParams)
                {

                    TraitTableRow tableRow = new TraitTableRow();
                    tableRow.rowLabel.Text = name;
                    // tableRow.Size = new Size(100, 25);

                    tableRow.rowTextBox.Name = "tb" + name.Replace(" ", "");
                    tableRow.rowPanel.Dock = DockStyle.Fill;

                    tableRow.rowPanel.BackColor = Color.White;
                    tableRow.rowTextBox.BackColor = Color.White;

                    if (rowIndex % 2 == 0)
                    {
                        tableRow.rowPanel.BackColor = Color.LightGray;
                        tableRow.rowTextBox.BackColor = Color.LightGray;
                    }
                    tableRow.rowTextBox.BorderStyle = BorderStyle.None;

                    table.SetColumnSpan(tableRow, 2);
                    table.Controls.Add(tableRow, 0, rowIndex);
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));


                    rowIndex++;
                }
                table.Visible = true;
            }
        }

        private void createTableCol(List<string> modelParams, float rowSize, float colSize, int colAmount, int amountOfRows)
        {
            int rowIndex = 0;
            var table = (TableLayoutPanel)this.tableGeneticModel;
            table.Controls.Clear();
            table.RowStyles.Clear();
            table.ColumnCount = colAmount;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, colSize));
            GeneticTableHeader geneticTableRowHeader = new GeneticTableHeader();
            geneticTableRowHeader.InitHeaderNames(modelParams);
            geneticTableRowHeader.Dock = DockStyle.Fill;
            geneticTableRowHeader.BackColor = ColorConstants.tableHeaderColor;

            table.SetColumnSpan(geneticTableRowHeader, table.ColumnCount);
            table.Controls.Add(geneticTableRowHeader, 0, rowIndex);

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));
            rowIndex++;
            while (rowIndex < amountOfRows)
            {

                GeneticTableRow tableRow = new GeneticTableRow();
                tableRow.Dock = DockStyle.Fill;



                if (rowIndex % 2 == 0)
                {
                    tableRow.BackColor = Color.LightGray;
                    tableRow.BackColor = Color.LightGray;
                    tableRow.setTextBoxBackgroundColor(Color.LightGray);
                }
                else
                {
                    tableRow.BackColor = Color.White;
                    tableRow.BackColor = Color.White;
                    tableRow.setTextBoxBackgroundColor(Color.White);

                }
                tableRow.BorderStyle = BorderStyle.None;
                table.SetColumnSpan(tableRow, colAmount);
                table.Controls.Add(tableRow, 0, rowIndex);
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));



                rowIndex++;
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

        }
        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            backButtonClicked?.Invoke(this, e);
        }

        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            nextButtonClicked?.Invoke(this, e);
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
            generateGeneticMap(dateTime);

            //Step 3 - Generate Table of traits
            generateTableOfTraits(dateTime);


            GenerateOkMessageBox("Data Generated Successfully at " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Information");

        }

        private void GenerateOkMessageBox(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {

            }
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

        private void generateGeneticMap(DateTime dateTime)
        {
            var delimiter = "\t";

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + "\\GeneticMap_" + dateTime.ToString() + ".CSV";

            using (var writer = new StreamWriter(filePath))
            {
                //    var line = string.Join(delimiter, itemContent);
                //    writer.WriteLine(line);
            }
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
