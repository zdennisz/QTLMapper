using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using Color = System.Drawing.Color;

namespace QTLProject.Utils
{
    public class LineChartXY:UserControl
    {
        private CartesianChart chart;
        private Axis axisY,axisX;
        public string AxisXTitle { set { axisX.Title = value; } }
        public string AxisYTitle { set { axisY.Title = value; } }

        public double SetXAxisMaxValue { set { axisX.MaxValue = value; } }
        public LineChartXY(CartesianChart chart)
        {
            this.chart = chart;
            axisY = new Axis();
            axisX = new Axis();
            chart.AxisX.Add(axisX);
            chart.AxisY.Add(axisY);
            this.chart.Series = new SeriesCollection();
            


        }

        public void AddLineChart(List<ObservablePoint> list,double pointSize)
        {
            LineSeries lineSeries = new LineSeries();
            ChartValues<ObservablePoint> values = new ChartValues<ObservablePoint>();
            values.AddRange(list);
            lineSeries.Values = values;
            lineSeries.PointGeometrySize = pointSize;
            this.chart.Series.Add(lineSeries);
            this.chart.AxisX[0].Foreground = ConvertColor(Color.Black);
            this.chart.AxisY[0].Foreground = ConvertColor(Color.Black);

        }
        /// <summary>
        /// Converts the color from drawing to media standard
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private SolidColorBrush ConvertColor(Color c)
        {

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = System.Windows.Media.Color.FromRgb(c.R, c.G, c.B);
            return mySolidColorBrush;
        }

    }
}
