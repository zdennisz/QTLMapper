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
                else if (temp >= 0.8 && temp <= 1.0)
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
                else if (temp >= 0.8 && temp <= 1.0)
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
                    temp = StatisticCalculations.PValueTStatistic(no, n1);
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
                    else if (temp >= 0.8 && temp <= 1.0)
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
 
    }
}
