
using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using System.Collections.Generic;

using QTLProject.Enums;
using System.Drawing;
using System.Windows.Media;
using Color = System.Drawing.Color;
using System.Linq;

namespace QTLProject.Utils
{
    public class HistogramChart : UserControl
    {
        private CartesianChart chart;
        private Axis axisY,axisX;
       
        public string AxisXTitle {  set { axisX.Title = value; } }
        public string AxisYTitle { set { axisY.Title = value; } }

        public HistogramChart(CartesianChart chart)
        {
            this.chart = chart;
            this.chart.BackColor = Color.White;
            
            //create 2 axis
            axisY = new Axis();
            axisX = new Axis();
          
            axisX.Separator.Step = 1d;
            axisX.LabelsRotation = 45d;

            axisY.LabelFormatter = labelFormatter;
            //add axis to the chart
            chart.AxisX.Add(axisX);
            chart.AxisY.Add(axisY);
            //add empty serires of upcoming data
            chart.Series = new SeriesCollection();
           
        }

      
        /// <summary>
        /// Adds the data to the histogram
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="val"></param>
        /// <param name="seriresColor"></param>
        public void AddColumnSeries( List<string> titles, List<double> val, Color seriresColor)
        {
            ChartValues<double> values = new ChartValues<double>();
            values.AddRange(val);
            ColumnSeries cs = new ColumnSeries();
            cs.MaxColumnWidth = double.PositiveInfinity;
            cs.ColumnPadding = 0;
            cs.Values = values;
          
           
            cs.Stroke = ConvertColor(Color.White);
            cs.Fill = ConvertColor(seriresColor);
            this.axisX.Labels = titles;
            this.chart.Series.Add(cs);
            this.chart.AxisX[0].Foreground = ConvertColor(Color.Black);
            this.chart.AxisY[0].Foreground = ConvertColor(Color.Black);
        }

        public void RemvoeColumnSeries()
        {
            if (this.chart.Series.Count > 0)
            {
                this.chart.Series.Clear();

            }
         
            
        }
        /// <summary>
        ///  Converts the color from drawing to media standard
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private SolidColorBrush ConvertColor(Color c)
        {

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = System.Windows.Media.Color.FromRgb( c.R, c.G, c.B);
            return mySolidColorBrush;
        }
        private string labelFormatter(double val)
        {
         
            
            return val.ToString("P");
        }


    }
}
