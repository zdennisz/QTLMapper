using LiveCharts.WinForms;
using QTLProject.Enums;
using QTLProject.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace QTLProject.Views
{
    public partial class QTLPositionView : UserControl
    {

        VIewResultsPresentor VIewResultsPresentor;
        List<LineChartXY> charts = new List<LineChartXY>();
        int amountOfChromosomes=4;
        public QTLPositionView()
        {
            InitializeComponent();
            VIewResultsPresentor = new VIewResultsPresentor();
            this.numericUpDownColAmount.ValueChanged += NumericUpDownColAmount_ValueChanged;
            for (int i = 0; i < amountOfChromosomes; i++)
            {
                CartesianChart cartesianChart = new CartesianChart();
                cartesianChart.Size = new Size(670, 200);
                cartesianChart.Hoverable = false;
                this.flowLayoutPanel1.Controls.Add(cartesianChart);
                charts.Add(new LineChartXY(cartesianChart));
            }

            foreach (RoundedButtonToolBar btn in this.buttonPanelContainer.Controls.OfType<RoundedButtonToolBar>())
            {
                btn.BackColor = ColorConstants.toolbarButtonsColor;
                btn.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
            }
            setupComoboxforTraitDist();
            this.labelChartType.Text = Constants.QTLPosition;
            


        }

        private void NumericUpDownColAmount_ValueChanged(object sender, EventArgs e)
        {
            int temp= Convert.ToInt32((sender as NumericUpDown).Value);
            int maxAmount = this.VIewResultsPresentor.GetGenomOrganismChromosomeSize();
            if (temp> maxAmount)
            {
                MessageBox.Show("The current limit to the chromosome amount is " + maxAmount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.numericUpDownColAmount.Value = 27;
            }
            else
            {
                amountOfChromosomes = temp;
                recalculateGraphs(amountOfChromosomes);
            }
        }

        private void recalculateGraphs(int amountOfgrpahs)
        {
            //TODO iterate over the grpahs and add or delete controls according to what value was sent
            if(charts.Count< amountOfgrpahs)
            {
                //add graphs
            }
            else
            {
                //remove graphs
            }
        }

        private void setupComoboxforTraitDist()
        {

            foreach (Trait t in VIewResultsPresentor.GetTraitList())
            {
                this.selectionCombobox.Items.Add(t.NameFull);
            }
            this.selectionCombobox.SelectedValueChanged += TraitCombobox_SelectedValueChanged;
            this.selectionCombobox.SelectedIndex = 0;
        }
        private void TraitCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            string typeOfTraitHistogram = (sender as ComboBox).Text;
            List<Trait> list = VIewResultsPresentor.GetTraitList();

            int indexFound = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (typeOfTraitHistogram.Equals(list[i].NameFull))
                {
                    indexFound = i;
                    break;
                }
            }
            //We find the index of the trait and calculate the data up to that trait
            //example we pick 1 trait we draw up to the first trait only
            //we pick 2nd trait we calculate the results for 1 trait and the second
            //we pick 3rd trait we calcualte the results for 1 trait ,2nd trait and 3rd trait...
            indexFound++;
            if (indexFound>=3 )
            {
                if(MessageBox.Show("Picking traits higher then the first 2 may cause performace issues and slow downs.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    VIewResultsPresentor.QTLPosition(indexFound, this.charts, amountOfChromosomes);
                }
                else
                {
                    VIewResultsPresentor.QTLPosition(1, this.charts, amountOfChromosomes);
                    indexFound--;
                    selectionCombobox.SelectedIndex = indexFound;
                }

            }
            else
            {
                VIewResultsPresentor.QTLPosition(indexFound, this.charts, amountOfChromosomes);
            }
            

        }

        private void buttonRemoveOutliers_Click(object sender, EventArgs e)
        {
            //Rosen algo
            showToastMessage("Preform Rosen Algorithm on the data");
        }

        private void buttonSaveGraph_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "png files (*.png)|*.png";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.RestoreDirectory = true;
            string path = null;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(path);
                string extension = Path.GetExtension(path);
                var pathWithoutExt = Path.GetDirectoryName(path);
                saveGraphToFile(pathWithoutExt, fileName, extension);
            }
        }

        private void saveGraphToFile(string pathWithoutExt, string fileName, string extension)
        {
            var chartsContainer = this.buttonPanelContainer.Controls;

            foreach (CartesianChart chart in chartsContainer.OfType<CartesianChart>())
            {
                string formatedFileName = fileName + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                formatedFileName += extension;
                var pathToSave = pathWithoutExt + "//" + formatedFileName;
                Bitmap bmp = new Bitmap(chart.Width, chart.Height);
                chart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(pathWithoutExt, ImageFormat.Png);
            }
            showToastMessage();

        }

        private void showToastMessage(string message = "File Saved at selected location.")
        {
            notifyIconQTLPosition.Visible = true;
            notifyIconQTLPosition.BalloonTipText = message;
            notifyIconQTLPosition.ShowBalloonTip(1000);
        }
    }
}
