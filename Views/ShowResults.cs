using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using QTLProject.Utils;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using QTLProject.Enums;
using QTLProject.Models;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace QTLProject
{
    public partial class ShowResults : Form
    {
        bool isInDepthReport;
        string typeOfGraph, typeOfTraitHistogram;
        CartesianChart chart;

        VIewResultsPresentor presentor;
        public ShowResults(bool isInDepthReport, string typeOfGraph)
        {
            InitializeComponent();
            this.isInDepthReport = isInDepthReport;
            this.typeOfGraph = typeOfGraph;
            chart = this.cartesianChart;
            presentor = new VIewResultsPresentor();

            if (this.typeOfGraph.Equals(Constants.SingleMarkerTest))
            {
                presentor.PValueHistogram(this.chart);
                this.labelChartType.Text = Constants.SingleMarkerTest;
            }
            else if (this.typeOfGraph.Equals(Constants.QTLPosition))
            {
                presentor.MarkerQualityHistogram(this.chart);
                this.labelChartType.Text = Constants.QTLPosition;
            }
            else if (this.typeOfGraph.Equals(Constants.TraitDistributionforQTLalleles))
            {
                presentor.SegregationMarkerHistogram(this.chart);
                this.labelChartType.Text = Constants.TraitDistributionforQTLalleles;
            }

            setupUI();
            /*
             LineChartXY lineChartXY = new LineChartXY(this.cartesianChart1);
             lineChartXY.AxisXTitle = "Some  X Title";
             lineChartXY.AxisYTitle = "Some  Y Title";

             List<ObservablePoint> points = new List<ObservablePoint>();
             points.Add(new ObservablePoint(0, 10));
             points.Add(new ObservablePoint(4, 7));
             points.Add(new ObservablePoint(5, 3));
             points.Add(new ObservablePoint(7, 6));
             points.Add(new ObservablePoint(10, 8));

             List<ObservablePoint> points2 = new List<ObservablePoint>();
             points2.Add(new ObservablePoint(0, 2));
             points2.Add(new ObservablePoint(2, 5));
             points2.Add(new ObservablePoint(3, 6));
             points2.Add(new ObservablePoint(6, 8));
             points2.Add(new ObservablePoint(10, 5));

             List<ObservablePoint> points3 = new List<ObservablePoint>();
             points3.Add(new ObservablePoint(0, 4));
             points3.Add(new ObservablePoint(5, 5));
             points3.Add(new ObservablePoint(7, 7));
             points3.Add(new ObservablePoint(9, 10));
             points3.Add(new ObservablePoint(10, 9));



             lineChartXY.AddLineChart(points, 25);
             lineChartXY.AddLineChart(points2, 14);
             lineChartXY.AddLineChart(points3, 10);



             List<string> sss = new List<string>();
             sss.Add("Heelo");
             sss.Add("I");
             sss.Add("Like");
             sss.Add("Cookies");
             List<double> doubleList = new List<double>();
             doubleList.Add(0.045);
             doubleList.Add(0.087);
             doubleList.Add(0.02);
             doubleList.Add(0.1);
            */

        }
        private void setupUI()
        {
            this.BackColor = ColorConstants.backgroundColor;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            if (isInDepthReport)
            {
                this.calculationsPanel.Visible = true;
            }
            else
            {
                this.calculationsPanel.Visible = false;
            }
            if (this.typeOfGraph.Equals(Constants.DistributionTest))
            {
                setupComobox();
                this.traitCombobox.Visible = true;
                this.labelChartType.Text = Constants.DistributionTest;
            }
            else
            {
                this.traitCombobox.Visible = false;
            }


        }

        private void setupComobox()
        {

            foreach (Trait t in presentor.GetTraitList())
            {
                this.traitCombobox.Items.Add(t.NameFull);
            }
            this.traitCombobox.SelectedValueChanged += TraitCombobox_SelectedValueChanged;
            this.traitCombobox.SelectedIndex = 0;
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

