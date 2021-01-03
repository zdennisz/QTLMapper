using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public SingleMarkerTestView()
        {
            InitializeComponent();
            viewResultsPresentor = new VIewResultsPresentor();
            PValueChart = this.pvalChart;
            segregationHistogram = this.segregationChart;
            markerQualityHistogram = this.markerQualityChart;
            chiSquaredChart= this.chiChart;
            setupComoboxForPVal();
            viewResultsPresentor.MarkerQualityHistogram(this.markerQualityHistogram);
            viewResultsPresentor.SegregationMarkerHistogram(this.segregationHistogram);
            //viewResultsPresentor.ChiSquaredLineChart(this.chiSquaredChart);
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
    }
}
