using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using static QTLProject.Types;
using QTLProject.Enums;

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
            this.comboBoxGenetic.SelectedIndexChanged += ComboBoxGenetic_SelectedIndexChanged;
           
            SetDateTimeFormat();
            DataGeneratorPresentor dgp = new DataGeneratorPresentor();
            dgp.DefineChromosomeLength();
            dgp.DefineChromosomePositions();
            dgp.DefineParentalHaplotypes();
            dgp.SimulateRecombination();
            dgp.DefineQTL();

        }

        private void ComboBoxDesign_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ComboBoxGenetic_SelectedIndexChanged(object sender, EventArgs e)
        {
      
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
            
            foreach(TableLayoutPanel panel in this.panelTableContainer.Controls)
            {
                panel.Visible = false;
            }
            if (tableType != QTLTaritModels.NoQTL)
            {
                tableAmount++;
                taritModelParams.Add("QTL pos (cM)");
                taritModelParams.Add("QTL Chr");
                taritModelParams.Add("Var Q");
                taritModelParams.Add("Var q");
                taritModelParams.Add("Avq. Q");
                taritModelParams.Add("Avq. q");

                if (tableType == QTLTaritModels.TwoLinkedQTL)
                {
                    tableAmount++;
                }
                createTable(tableAmount, taritModelParams);

            }

            //update the genetic table
        }

        private void createTable(int amountOftables, List<string> modelParams)
        {
           
            for (int i = 0; i < amountOftables; i++)
            {
                var table = (TableLayoutPanel)this.panelTableContainer.Controls[i];
                table.Controls.Clear();
                table.RowStyles.Clear();
                table.ColumnCount = 2;
                table.RowCount = modelParams.Count;
                int rowIndex = 0;
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));

                foreach (string name in modelParams)
                {


                    Label l = new Label();
                    l.Text = name;

                    l.Dock = DockStyle.Fill;
                    TextBox tb = new TextBox();
                    tb.Name = "tb" + name.Replace(" ", "");
                    tb.Dock = DockStyle.Fill;

                    table.Controls.Add(tb, 1, rowIndex);
                    table.Controls.Add(l, 0, rowIndex);
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));


                    rowIndex++;
                }
                table.Visible = true;
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
