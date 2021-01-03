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
    public partial class DistributionOfTraitView : UserControl
    {
        VIewResultsPresentor presentor;
        string typeOfTraitHistogram;
        CartesianChart chart;

        public DistributionOfTraitView()
        {
            InitializeComponent();
            chart = this.cartesianChart1;
            presentor = new VIewResultsPresentor();
            setupComoboxforTraitDist();
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
    }
}
