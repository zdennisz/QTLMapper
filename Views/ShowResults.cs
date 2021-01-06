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
using QTLProject.Views;

namespace QTLProject
{
    public partial class ShowResults : Form
    {
        
        string typeOfGraph;
        public ShowResults( string typeOfGraph)
        {
            InitializeComponent();
            this.typeOfGraph = typeOfGraph;
            setupUI();


        }
        private void setupUI()
        {
            this.BackColor = ColorConstants.backgroundContrastColor;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
            if (this.typeOfGraph.Equals(Constants.DistributionTest))
            {
                DistributionOfTraitView distributionOfTraitView = new DistributionOfTraitView();
                distributionOfTraitView.Dock = DockStyle.Fill;
                this.showResultsContentPanel.Controls.Add(distributionOfTraitView);

            }
            else if (this.typeOfGraph.Equals(Constants.SingleMarkerTest))
            {
                SingleMarkerTestView singleMarkerTestView = new SingleMarkerTestView();
                singleMarkerTestView.Dock = DockStyle.Fill;
                this.showResultsContentPanel.Controls.Add(singleMarkerTestView);
            }
            else if (this.typeOfGraph.Equals(Constants.QTLPosition))
            {
                QTLPositionView qTLPositionView = new QTLPositionView();
                qTLPositionView.Dock = DockStyle.Fill;
                this.showResultsContentPanel.Controls.Add(qTLPositionView);
            }




        }




    }
}

