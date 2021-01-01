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
                //graph number 2
                presentor.MarkerQualityHistogram(this.chart);
                this.labelChartType.Text = Constants.SingleMarkerTest;

            }
            else if (this.typeOfGraph.Equals(Constants.QTLPosition))
            {
                //graph number 3
                presentor.SegregationMarkerHistogram(this.chart);
                this.labelChartType.Text = Constants.QTLPosition;
            }
            else if (this.typeOfGraph.Equals(Constants.QTLsEffect))
            {
                //graph number 4 - dosent work
                //presentor.ChiSquaredLineChart(this.chart);
                //this.labelChartType.Text = Constants.QTLsEffect;
                this.labelChartType.Text = "Coming soon in the next version.";
            }
            else if (this.typeOfGraph.Equals(Constants.ModelComparison))
            {
                // grpahs number 6
               // this.labelChartType.Text = Constants.ModelComparison;
                this.labelChartType.Text = "Coming soon in the next version.";
            }
            else if (this.typeOfGraph.Equals(Constants.Power))
            {
                // grpahs number 7
                //this.labelChartType.Text = Constants.Power;
                this.labelChartType.Text = "Coming soon in the next version.";
            }

            setupUI();


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
                setupComoboxforTraitDist();
                this.selectionCombobox.Visible = true;
                this.labelChartType.Text = Constants.DistributionTest;
            }
            else if (this.typeOfGraph.Equals(Constants.TraitDistributionforQTLalleles))
            {
                setupComoboxForPVal();
                this.selectionCombobox.Visible = true;
                this.labelChartType.Text = Constants.TraitDistributionforQTLalleles;
            }
            else
            {
                this.selectionCombobox.Visible = false;

            }


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
            //graph number 1
            presentor.TraitDistributionHistogram(indexFound, this.chart);
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
                presentor.PValueHistogram(this.chart);
            }
            else
            {
                presentor.PValueLogHistogram(this.chart);
            }
        }
    }
}

