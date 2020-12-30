using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using QTLProject.Enums;
using QTLProject.Utils;

namespace QTLProject
{
    public partial class CalculateQTL : UserControl
    {
        public event EventHandler backButtonClicked;
        public event EventHandler nextButtonClicked;
        CalcQTLPresentor calcQTLPresentor;
        public CalculateQTL()
        {
            InitializeComponent();
            calcQTLPresentor = new CalcQTLPresentor(this.prevoiusTableData);
            TempDataHolder.UpdateTempHolder += TempDataHolder_UpdateTempHolder;
            setupUI();
            this.Dock = DockStyle.Fill;
            this.btnBack.MouseClick += BtnBack_MouseClick;
            this.btnNext.MouseClick += BtnNext_MouseClick;
           
        }

        private void TempDataHolder_UpdateTempHolder(object sender, EventArgs e)
        {
           setUpTable();
        }

        private void setupUI()
        {
            setupComboBox();
            
            setupButtons();
            setupFilePaths();
        }

        /// <summary>
        /// Adds design to the textboxes  
        /// </summary>
        private void setupFilePaths()
        {
            this.textBoxGenotype.BackColor = Color.White;
            this.textBoxGenotype.BorderStyle = BorderStyle.None;
            this.textBoxGenotype.Controls.Add(new Label()
            { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
            this.textBoxPhenotype.BackColor = Color.White;
            this.textBoxPhenotype.BorderStyle = BorderStyle.None;
            this.textBoxPhenotype.Controls.Add(new Label()
            { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
            this.comboBoxModel.BackColor = Color.White;

        }
        /// <summary>
        /// Setups the buttons color and design
        /// </summary>
        private void setupButtons()
        {
          
            btnOpenDataGen.BackColor = ColorConstants.toolbarButtonsColor;
            btnOpenDataGen.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
            btnOpenDataGen.Size = new Size(60, 30);
            btnOpenDataGen.Image = (Image)(new Bitmap(btnOpenDataGen.Image, new Size(18, 18)));

            btnBack.BackColor = ColorConstants.toolbarButtonsColor;
            btnBack.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
            btnNext.BackColor = ColorConstants.toolbarButtonsColor;
            btnNext.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;


            btnOpenDataPhen.BackColor = ColorConstants.toolbarButtonsColor;
            btnOpenDataPhen.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
            btnOpenDataPhen.Size = new Size(60, 30);
            btnOpenDataPhen.Image = (Image)(new Bitmap(btnOpenDataPhen.Image, new Size(18, 18)));
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnBack, Constants.GoToPrevStage);
            toolTip.SetToolTip(btnNext, Constants.GoToNextStage);
            toolTip.SetToolTip(btnOpenDataGen, Constants.OpenGenFile);
            toolTip.SetToolTip(btnOpenDataPhen, Constants.OpenPhenFile);
        }
        /// <summary>
        /// Setups the comboboxes design and color 
        /// </summary>
        private void setupComboBox()
        {
            ArrayList comboBoxData = new ArrayList() { Constants.NoQTL, Constants.OneQTL, Constants.DominantQTL, Constants.TwoLinkedQTL };
            this.comboBoxModel.Items.AddRange(comboBoxData.ToArray());
            this.comboBoxModel.SelectedIndex = 0;
        }
        /// <summary>
        /// Genertes the table from the prevoius screen
        /// </summary>
        private void setUpTable()
        {
            List<string> geneticParams = new List<string>();
            geneticParams.Add(Constants.Marker);
            geneticParams.Add(Constants.Chr);
            geneticParams.Add(Constants.CoorcM);
            
            
            calcQTLPresentor.GeneratePrevoiusTable(geneticParams, 25, 400, geneticParams.Count);
            calcQTLPresentor.ProcessAllGeneticMapData();
        }

        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {

            if (calcQTLPresentor.CheckDataAviliability())
            {
                nextButtonClicked?.Invoke(this, e);
            }
            else
            {
                switch (calcQTLPresentor.errorMessage)
                {
                    case Types.ErrorMessage.BadGeneticMap:
                        MessageBox.Show("Please load Genetic Map with another file the data is inconsistent with the genotype.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case Types.ErrorMessage.MissingGenotype:
                        MessageBox.Show("Please load genotype data it is missing.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case Types.ErrorMessage.MissingPhenotype:
                        MessageBox.Show("Please load phenotype data it is missing.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case Types.ErrorMessage.NoDataLoaded:
                        MessageBox.Show("Please load genotype data and phenotype data accordingly.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    default:
                        break;
                }
               
            }
            
         
        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            backButtonClicked?.Invoke(this, e);
        }
        /// <summary>
        /// Browse for the genotype file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenDataGen_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.Title = "Load Genotype data";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    calcQTLPresentor.ReadDataGenotype(filePath);
                    this.textBoxGenotype.Text = filePath;
                }
            }
        }
        /// <summary>
        /// Browse for the phenotype file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenDataPhen_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.Title = "Load Phenotype data";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    calcQTLPresentor.ReadDataPhenotype(filePath);
                    this.textBoxPhenotype.Text = filePath;
                }
            }
        }
    }
}
