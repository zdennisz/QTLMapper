﻿using System;
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


namespace QTLProject
{
    public partial class ShowResults : Form
    {
        bool isGraph, isInDepthReport;
        string typeOfGraph;
        VIewResultsPresentor presentor;
        public ShowResults(bool isGraph,bool isInDepthReport,string typeOfGraph)
        {
            InitializeComponent();
            this.isGraph = isGraph;
            this.isInDepthReport = isInDepthReport;
            this.typeOfGraph = typeOfGraph;

            string res = presentor.CalculatePValue();

            setupUI();
            this.tabControl.TabPages[0].Text = "Chart Series";
            this.tabControl.TabPages[1].Text = "Histogram Chart";

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


            HistogramChart histogramChart = new HistogramChart(this.cartesianChart3);
            histogramChart.AxisXTitle = "Some X values";
            histogramChart.AxisYTitle = "Some y Values";

            List < string > sss= new List<string>();
            sss.Add("Heelo");
            sss.Add("I");
            sss.Add("Like");
            sss.Add("Cookies");
            List<double> doubleList = new List<double>();
            doubleList.Add(0.045);
            doubleList.Add(0.087);
            doubleList.Add(0.02);
            doubleList.Add(0.1);


            histogramChart.AddColumnSeries(sss, doubleList, ColorConstants.highliteColor);
        }
        private void setupUI()
        {
            this.BackColor = ColorConstants.backgroundColor;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }


    }
}

