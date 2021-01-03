using LiveCharts.WinForms;
using QTLProject.Enums;
using QTLProject.Utils;
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
    public partial class QTLPositionView : UserControl
    {

        VIewResultsPresentor VIewResultsPresentor;
         List<LineChartXY> charts = new List<LineChartXY>();
        public QTLPositionView()
        {
            InitializeComponent();
            VIewResultsPresentor = new VIewResultsPresentor();
            
            
            foreach(CartesianChart chart in this.cartesianChartsContainer.Controls.OfType<CartesianChart>())
            {
                charts.Add(new LineChartXY(chart));
            }
            setupComoboxforTraitDist();
            this.labelChartType.Text = Constants.QTLPosition;
           
            

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
    }
}
