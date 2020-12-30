using QTLProject.Enums;
using QTLProject.Models;
using QTLProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace QTLProject
{
    public class VIewResultsPresentor
    {
        #region Fields
        Database db = null;
        HistogramChart traithistogramChart;
        HistogramChart markerQualityHistogramChart;
        HistogramChart segregationMarkerChart;
        HistogramChart pValueChart;
        HistogramChart pValueLogChart;

        #endregion Fields

        #region Constructor
        public VIewResultsPresentor()
        {
            //traithistogramChart = new HistogramChart(chart);
            db = DatabaseProvider.GetDatabase();
            //calcs
        }

        #endregion Constructor

        #region Public Methods
        public List<Trait> GetTraitList()
        {

            return (List<Trait>)db.SubData[0].Trait;

        }




        public void GenereateQTLEffect()
        {
            
        }

 

        public void TraitDistributionHistogram(int traitIndex, CartesianChart chart)
        {
            if (traithistogramChart == null)
            {
                traithistogramChart = new HistogramChart(chart);
            }

            traithistogramChart.AxisXTitle = "Trait Values";
            traithistogramChart.AxisYTitle = "Proportion of trait Values";
            traithistogramChart.RemvoeColumnSeries();
            HashSet<double> allTraitValues = new HashSet<double>();

            double popSize = db.SubData.Count * 1.0;
            double proportionVal = 0.0;
            double max = db.SubData[0].TraitValue[0, traitIndex];
            double min = db.SubData[0].TraitValue[0, traitIndex];
            double traitVal;
            for (int i = 0; i < db.SubData.Count; i++)
            {
                if (db.SubData[i].TraitValue[0, traitIndex] > max && db.SubData[i].TraitValueOk[0, traitIndex] == true)
                {
                    max = db.SubData[i].TraitValue[0, traitIndex];
                }


                if (db.SubData[i].TraitValue[0, traitIndex] < min && db.SubData[i].TraitValueOk[0, traitIndex] == true)
                {
                    min = db.SubData[i].TraitValue[0, traitIndex];
                }

            }
            traitVal = (max - min) / 5.0;

            Dictionary<int, double> proportionOfIndivid = new Dictionary<int, double>();
            double j = 0.0, k = 0.0, h = 0.0, g = 0.0, l = 0.0;
            proportionOfIndivid[0] = j;
            proportionOfIndivid[1] = h;
            proportionOfIndivid[2] = k;
            proportionOfIndivid[3] = g;
            proportionOfIndivid[4] = l;
            for (int i = 0; i < this.db.SubData.Count; i++)
            {
                if (db.SubData[i].TraitValue[0, traitIndex] >= 0 && db.SubData[i].TraitValue[0, traitIndex] < traitVal && db.SubData[i].TraitValueOk[0, traitIndex] == true)
                {
                    j++;
                    proportionOfIndivid[0] = j;
                }
                else if (db.SubData[i].TraitValue[0, traitIndex] >= traitVal && db.SubData[i].TraitValue[0, traitIndex] < 2 * traitVal && db.SubData[i].TraitValueOk[0, traitIndex] == true)
                {
                    k++;
                    proportionOfIndivid[1] = k;
                }
                else if (db.SubData[i].TraitValue[0, traitIndex] >= 2 * traitVal && db.SubData[i].TraitValue[0, traitIndex] < 3 * traitVal && db.SubData[i].TraitValueOk[0, traitIndex] == true)
                {
                    h++;
                    proportionOfIndivid[2] = h;
                }
                else if (db.SubData[i].TraitValue[0, traitIndex] >= 3 * traitVal && db.SubData[i].TraitValue[0, traitIndex] < 4 * traitVal && db.SubData[i].TraitValueOk[0, traitIndex] == true)
                {
                    g++;
                    proportionOfIndivid[3] = g;
                }
                else if (db.SubData[i].TraitValue[0, traitIndex] >= 4 * traitVal && db.SubData[i].TraitValue[0, traitIndex] < 5 * traitVal && db.SubData[i].TraitValueOk[0, traitIndex] == true)
                {
                    l++;
                    proportionOfIndivid[4] = l;
                }

            }
            proportionOfIndivid[0] = proportionOfIndivid[0] / popSize;
            proportionOfIndivid[1] = proportionOfIndivid[1] / popSize;
            proportionOfIndivid[2] = proportionOfIndivid[2] / popSize;
            proportionOfIndivid[3] = proportionOfIndivid[3] / popSize;
            proportionOfIndivid[4] = proportionOfIndivid[4] / popSize;

            //get the proportion of the indivivuals

            List<string> titles = new List<string>();
            titles.Add("0-20%");
            titles.Add("20-40%");
            titles.Add("40-60%");
            titles.Add("60-80%");
            titles.Add("80-100%");


            traithistogramChart.AddColumnSeries(titles, proportionOfIndivid.Values.ToList<double>(), ColorConstants.highliteColor);
        }

        public void MarkerQualityHistogram(CartesianChart chart)
        {
            if (markerQualityHistogramChart == null)
            {
                markerQualityHistogramChart = new HistogramChart(chart);
            }
            markerQualityHistogramChart.AxisXTitle = " Missing Data %";
            markerQualityHistogramChart.AxisYTitle = "Proportion of Markers %";

            // find out which markers are:
            //0-20% 
            //20-40%
            //40-60%
            //60-80% 
            //80-100%
            int twentyPercent = 0;
            int fortyPercent = 0;
            int sixtyPercent = 0;
            int eightyPercent = 0;
            int oneHundrerdPercent = 0;
            double popSize = db.SubData.Count * 1.0;
            double temp;
            double counter = 0;
            // this is our 100%
            double genotypeSize = db.SubData[0].Genotype.Length;

            //we iterate over all the population
            for (int i = 0; i < this.db.SubData.Count; i++)
            {
                counter = 0;
                //we iterate over the genotype of each person
                for (int j = 0; j < this.db.SubData[i].Genotype.Length; j++)
                {
                    if (this.db.SubData[i].GenotypeOk[0, j] == true)
                    {
                        counter++;
                    }

                }
                //we finished going over the persons genotype divide by the 100 percent and add to the relevant bucket

                temp = counter / genotypeSize;
                if (temp >= 0.0 && temp < 0.2)
                {
                    twentyPercent++;
                }
                else if (temp >= 0.2 && temp < 0.4)
                {
                    fortyPercent++;
                }
                else if (temp >= 0.4 && temp < 0.6)
                {
                    sixtyPercent++;
                }
                else if (temp >= 0.6 && temp < 0.8)
                {
                    eightyPercent++;
                }
                else if (temp >= 0.8 && temp <= 0.1)
                {
                    oneHundrerdPercent++;
                }

            }
            //we have all the data now we arrange it in the format the histogram has to accept
            List<string> titles = new List<string>();
            titles.Add("0-20%");
            titles.Add("20-40%");
            titles.Add("40-60%");
            titles.Add("60-80%");
            titles.Add("80-100%");
            List<double> values = new List<double>();
            values.Add(twentyPercent / popSize);
            values.Add(fortyPercent / popSize);
            values.Add(sixtyPercent / popSize);
            values.Add(eightyPercent / popSize);
            values.Add(oneHundrerdPercent / popSize);
            markerQualityHistogramChart.AddColumnSeries(titles, values, ColorConstants.highliteColor);

        }

        public void SegregationMarkerHistogram(CartesianChart chart)
        {
            if (segregationMarkerChart == null)
            {
                segregationMarkerChart = new HistogramChart(chart);
            }
            segregationMarkerChart.AxisXTitle = " n0/(n1+n0)";
            segregationMarkerChart.AxisYTitle = "Proportion of Markers %";
            int twentyPercent = 0;
            int fortyPercent = 0;
            int sixtyPercent = 0;
            int eightyPercent = 0;
            int oneHundrerdPercent = 0;
            double popSize = db.SubData.Count * 1.0;
            double temp;
            double counterN0 = 0;
            double counterN1 = 0;
            // this is our 100%
            double genotypeSize = db.SubData[0].Genotype.Length;
            //we iterate over all the population
            for (int i = 0; i < this.db.SubData.Count; i++)
            {
                counterN0 = 0;
                counterN1 = 0;
                //we iterate over the genotype of each person
                for (int j = 0; j < this.db.SubData[i].Genotype.Length; j++)
                {
                    if (this.db.SubData[i].Genotype[0, j] == 0)
                    {
                        counterN0++;
                    }
                    else if (this.db.SubData[i].Genotype[0, j] == 1)
                    {
                        counterN1++;
                    }

                }
                //we finished going over the persons genotype divide by the 100 percent and add to the relevant bucket

                temp = counterN0 / (counterN1 + counterN0);

                if (temp >= 0.0 && temp < 0.2)
                {
                    twentyPercent++;
                }
                else if (temp >= 0.2 && temp < 0.4)
                {
                    fortyPercent++;
                }
                else if (temp >= 0.4 && temp < 0.6)
                {
                    sixtyPercent++;
                }
                else if (temp >= 0.6 && temp < 0.8)
                {
                    eightyPercent++;
                }
                else if (temp >= 0.8 && temp <= 0.1)
                {
                    oneHundrerdPercent++;
                }

            }
            List<string> titles = new List<string>();
            titles.Add("0-20%");
            titles.Add("20-40%");
            titles.Add("40-60%");
            titles.Add("60-80%");
            titles.Add("80-100%");
            List<double> values = new List<double>();
            values.Add(twentyPercent / popSize);
            values.Add(fortyPercent / popSize);
            values.Add(sixtyPercent / popSize);
            values.Add(eightyPercent / popSize);
            values.Add(oneHundrerdPercent / popSize);
            segregationMarkerChart.AddColumnSeries(titles, values, ColorConstants.highliteColor);
        }

        public void PValueHistogram(CartesianChart chart)
        {
            if (pValueChart == null)
            {
                pValueChart = new HistogramChart(chart);
            }
            pValueChart.AxisXTitle = "P-Value";
            pValueChart.AxisYTitle = "Proportion of Markers %";
            int twentyPercent = 0;
            int fortyPercent = 0;
            int sixtyPercent = 0;
            int eightyPercent = 0;
            int oneHundrerdPercent = 0;
            double temp = 0.0;
            double popSize = (db.SubData[0].Genotype.Length) * (db.SubData[0].TraitValue.Length) * 1.0;


            //go over all the individuals of first marker and first trait and calculate p value  
            //get the answer and put it in the correct bin 
            for (int i = 0; i < this.db.SubData[0].Genotype.Length; i++)
            {
                //we get the wanted genotype index
                for (int j = 0; j < this.db.SubData[0].TraitValue.Length; j++)
                {
                    //we get the wanted trait index
                    List<double> no = new List<double>();
                    List<double> n1 = new List<double>();
                    for (int k = 0; k < this.db.SubData.Count; k++)
                    {
                        if (this.db.SubData[k].Genotype[0, i] == 0)
                        {
                            no.Add(this.db.SubData[k].TraitValue[0, j]);
                        }
                        else if (this.db.SubData[k].Genotype[0, i] == 1)
                        {
                            n1.Add(this.db.SubData[k].TraitValue[0, j]);
                        }
                        //iterate over all the people and gather two groups of n0 and n1
                    }
                    //calculate the pvalue for trait and genotype and put in the correct bin
                    //temp=result of p value
                    temp = calculatePValue(no, n1);
                    if (temp >= 0.0 && temp < 0.2)
                    {
                        twentyPercent++;
                    }
                    else if (temp >= 0.2 && temp < 0.4)
                    {
                        fortyPercent++;
                    }
                    else if (temp >= 0.4 && temp < 0.6)
                    {
                        sixtyPercent++;
                    }
                    else if (temp >= 0.6 && temp < 0.8)
                    {
                        eightyPercent++;
                    }
                    else if (temp >= 0.8 && temp <= 0.1)
                    {
                        oneHundrerdPercent++;
                    }
                }
            }




            List<double> values = new List<double>();
            values.Add(twentyPercent / popSize);
            values.Add(fortyPercent / popSize);
            values.Add(sixtyPercent / popSize);
            values.Add(eightyPercent / popSize);
            values.Add(oneHundrerdPercent / popSize);
            List<string> titles = new List<string>();
            titles.Add("0-20%");
            titles.Add("20-40%");
            titles.Add("40-60%");
            titles.Add("60-80%");
            titles.Add("80-100%");
            pValueChart.AddColumnSeries(titles, values, ColorConstants.highliteColor);
        }

        public void PValueLogHistogram(CartesianChart chart)
        {
            if (pValueLogChart == null)
            {
                pValueLogChart = new HistogramChart(chart);
            }
            pValueLogChart.AxisXTitle = "-Log(P-Value)";
            pValueLogChart.AxisYTitle = "-Log(Proportion of Markers %)";
        }

        #endregion Public Methods
        #region Private Methods

        private double calculatePValue(List<double> n_0, List<double> n_1)
        {
            double x_sum = 0.0, y_sum = 0.0, x_sum_variance = 0.0, y_sum_variance = 0.0, tStatistic = 0.0, x_a = 0.0, y_a = 0.0, x_s2 = 0.0, y_s2 = 0.0;
            int n0 = n_0.Count;
            int n1 = n_1.Count;
            foreach (double d in n_0)
            {
                x_sum += d;
            }

            foreach (double d in n_1)
            {
                y_sum += d;
            }
            x_a = x_sum / n0; // average of set with genotype 0 
            y_a = y_sum / n1; // average of set with genotype 1

            foreach (double d in n_0)
            {
                x_sum_variance += Math.Pow((d - x_a), 2);
            }

            foreach (double d in n_1)
            {
                y_sum_variance += Math.Pow((d - x_a), 2);
            }

            x_s2 = x_sum_variance / (n0 - 1); // the variance of n0
            y_s2 = y_sum_variance / (n1 - 1); // the variance of n1

            tStatistic = (y_a - x_a) / (Math.Sqrt(y_s2 / Math.Sqrt(n1) + x_s2 / Math.Sqrt(n0)));


            double num = ((x_s2 / n0) + (y_s2 / n1)) * ((x_s2 / n0) + (y_s2 / n1));
            double denomLeft = ((x_s2 / n1) * (x_s2 / n0)) / (n0 - 1);
            double denomRight = ((y_s2 / n1) * (y_s2 / n1)) / (n1 - 1);
            double denom = denomLeft + denomRight;
            double df = num / denom;

            return acmALgo(tStatistic, df);

        }
        private double acmALgo(double t, double df)
        {
            // for large integer df or double df
            // adapted from ACM algorithm 395
            // returns 2-tail p-value
            double n = df; // to sync with ACM parameter name
            double a, b, y;
            t = t * t;
            y = t / n;
            b = y + 1.0;
            if (y > 1.0E-6) y = Math.Log(b);
            a = n - 0.5;
            b = 48.0 * a * a;
            y = a * y;
            y = (((((-0.4 * y - 3.3) * y - 24.0) * y - 85.5) /
              (0.8 * y * y + 100.0 + b) + y + 3.0) / b + 1.0) *
              Math.Sqrt(y);
            return 2.0 * Gauss(-y); // ACM algorithm 209
        }


        private double Gauss(double z)
        {
            // input = z-value (-inf to +inf)
            // output = p under Standard Normal curve from -inf to z
            // e.g., if z = 0.0, function returns 0.5000
            // ACM Algorithm #209
            double y; // 209 scratch variable
            double p; // result. called 'z' in 209
            double w; // 209 scratch variable
            if (z == 0.0)
                p = 0.0;
            else
            {
                y = Math.Abs(z) / 2;
                if (y >= 3.0)
                {
                    p = 1.0;
                }
                else if (y < 1.0)
                {
                    w = y * y;
                    p = ((((((((0.000124818987 * w
                      - 0.001075204047) * w + 0.005198775019) * w
                      - 0.019198292004) * w + 0.059054035642) * w
                      - 0.151968751364) * w + 0.319152932694) * w
                      - 0.531923007300) * w + 0.797884560593) * y * 2.0;
                }
                else
                {
                    y = y - 2.0;
                    p = (((((((((((((-0.000045255659 * y
                      + 0.000152529290) * y - 0.000019538132) * y
                      - 0.000676904986) * y + 0.001390604284) * y
                      - 0.000794620820) * y - 0.002034254874) * y
                      + 0.006549791214) * y - 0.010557625006) * y
                      + 0.011630447319) * y - 0.009279453341) * y
                      + 0.005353579108) * y - 0.002141268741) * y
                      + 0.000535310849) * y + 0.999936657524;
                }
            }
            if (z > 0.0)
                return (p + 1.0) / 2;
            else
                return (1.0 - p) / 2;
        }

        #endregion Private Methods
    }
}
