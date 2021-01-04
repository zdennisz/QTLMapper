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
        int amountOfColumns;
        public QTLPositionView()
        {
            InitializeComponent();
            VIewResultsPresentor = new VIewResultsPresentor();
            for(int i = 0; i < 9; i++)
            {
                CartesianChart cartesianChart = new CartesianChart();
                cartesianChart.Size = new Size(670, 200);
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
            this.numericUpDownColAmount.ValueChanged += NumericUpDownColAmount_ValueChanged;


        }

        private void NumericUpDownColAmount_ValueChanged(object sender, EventArgs e)
        {
            amountOfColumns = Convert.ToInt32((sender as NumericUpDown).Value);
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
            VIewResultsPresentor.QTLPosition(indexFound, this.charts);
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
