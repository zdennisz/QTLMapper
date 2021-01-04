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
    public partial class SingleMarkerTestView : UserControl
    {
        VIewResultsPresentor viewResultsPresentor;
        CartesianChart segregationHistogram;
        CartesianChart PValueChart;
        CartesianChart markerQualityHistogram;
        CartesianChart chiSquaredChart;
        int amountOfColumns, tabIndex = 0;
        
        public SingleMarkerTestView()
        {
            InitializeComponent();
            viewResultsPresentor = new VIewResultsPresentor();
            foreach (RoundedButtonToolBar btn in this.buttonPanelContainer.Controls.OfType<RoundedButtonToolBar>())
            {
                btn.BackColor = ColorConstants.toolbarButtonsColor;
                btn.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
            }

            this.tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            this.numericUpDownColAmount.ValueChanged += NumericUpDownColAmount_ValueChanged;

            PValueChart = this.pvalChart;
            segregationHistogram = this.segregationChart;
            markerQualityHistogram = this.markerQualityChart;
            chiSquaredChart = this.chiChart;


            setupComoboxForPVal();
            viewResultsPresentor.MarkerQualityHistogram(this.markerQualityHistogram);
            viewResultsPresentor.SegregationMarkerHistogram(this.segregationHistogram);
            viewResultsPresentor.ChiSquaredHistogramChart(this.chiSquaredChart);
            this.labelChartType.Text = Constants.SingleMarkerTest;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabIndex = (sender as TabControl).SelectedIndex;
        }



        private void NumericUpDownColAmount_ValueChanged(object sender, EventArgs e)
        {
            amountOfColumns = Convert.ToInt32((sender as NumericUpDown).Value);
        }

        private void setupComoboxForPVal()
        {
            this.selectionCombobox.Items.Add("P-Value");
            this.selectionCombobox.Items.Add("-Log(P-Value)");
            this.selectionCombobox.SelectedValueChanged += TraitCombobox_SelectedValueChanged1;
            this.selectionCombobox.SelectedIndex = 0;
        }

        private void TraitCombobox_SelectedValueChanged1(object sender, EventArgs e)
        {
            string typeOfHistogram = (sender as ComboBox).Text;
            if (typeOfHistogram.Equals("P-Value"))
            {
                viewResultsPresentor.PValueHistogram(this.PValueChart);
            }
            else
            {
                viewResultsPresentor.PValueLogHistogram(this.PValueChart);
            }
        }

        private void buttonRemoveOutliers_Click(object sender, EventArgs e)
        {
            //Preform Rosen algo
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
                saveGraphToFile(tabIndex, pathWithoutExt, fileName, extension);
            }


        }

        private void saveGraphToFile(int tabIndex, string pathWithoutExt, string fileName, string extension)
        {
            var tab = this.tabControl1.Controls[tabIndex];

            foreach (CartesianChart chart in tab.Controls.OfType<CartesianChart>())
            {
                string formatedFileName = fileName + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                formatedFileName += extension;
                var pathToSave = pathWithoutExt + "//" + formatedFileName;
                Bitmap bmp = new Bitmap(chart.Width, chart.Height);
                chart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(pathToSave, ImageFormat.Png);
            }
            showToastMessage();


        }


        private void showToastMessage(string message = "File Saved at selected location.")
        {
            notifyIconSingleMarkerTest.Visible = true;
            notifyIconSingleMarkerTest.BalloonTipText = message;
            notifyIconSingleMarkerTest.ShowBalloonTip(1000);
        }
    }
}
