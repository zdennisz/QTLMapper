using QTLProject.Enums;
using QTLProject.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
namespace QTLProject.Views
{
    public partial class DistributionOfTraitView : UserControl
    {
        VIewResultsPresentor presentor;
        string typeOfTraitHistogram;
        CartesianChart chart;
        int amountOfColumns;

        public DistributionOfTraitView()
        {
            InitializeComponent();
            chart = this.cartesianChart1;
            presentor = new VIewResultsPresentor();

            setupComoboxforTraitDist();

            foreach (RoundedButtonToolBar btn in this.buttonPanelContainer.Controls.OfType<RoundedButtonToolBar>())
            {
                btn.BackColor = ColorConstants.toolbarButtonsColor;
                btn.FlatAppearance.BorderColor = ColorConstants.toolbarButtonsColor;
            }

            this.numericUpDownColAmount.ValueChanged += NumericUpDownColAmount_ValueChanged;
            this.labelChartType.Text = Constants.DistributionTest;
        }

        private void NumericUpDownColAmount_ValueChanged(object sender, EventArgs e)
        {
            amountOfColumns = Convert.ToInt32((sender as NumericUpDown).Value);
        }

        private void setupComoboxforTraitDist()
        {

            foreach (Trait t in presentor.GetTraitList())
            {
                this.selectionCombobox.Items.Add(t.NameFull);
            }
            this.selectionCombobox.SelectedValueChanged += TraitCombobox_SelectedValueChanged;
            this.selectionCombobox.SelectedIndex = 0;
        }
        private void TraitCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            typeOfTraitHistogram = (sender as ComboBox).Text;
            List<Trait> list = presentor.GetTraitList();

            int indexFound = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (typeOfTraitHistogram.Equals(list[i].NameFull))
                {
                    indexFound = i;
                    break;
                }
            }
            presentor.TraitDistributionHistogram(indexFound, this.chart);
        }

        private void buttonRemoveOutliers_Click(object sender, EventArgs e)
        {
            //ROsen algo
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
                Bitmap bmp = new Bitmap(chart.Width, chart.Height);
                chart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(path, ImageFormat.Png);
                showToastMessage();
            }

        }
        private void showToastMessage(string message = "File Saved at selected location.")
        {
            notifyIconDistributionOfTrait.Visible = true;
            notifyIconDistributionOfTrait.BalloonTipText = message;
            notifyIconDistributionOfTrait.ShowBalloonTip(1000);
        }
    }
}
