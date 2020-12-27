using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using LiveCharts.WinForms;
using QTLProject.Enums;
using QTLProject.Models;
using QTLProject.Utils;

namespace QTLProject
{
    public class VIewResultsPresentor
    {
        Database db = null;
        HistogramChart traithistogramChart;
        public VIewResultsPresentor(CartesianChart chart )
        {
            traithistogramChart = new HistogramChart(chart);
            db = DatabaseProvider.GetDatabase();
            //calcs
        }
        public List<Trait> GetTraitList()
        {
          
          return (List<Trait>)db.SubData[0].Trait;
            
        }
        public void GenerateGrpah()
        {

        }

        public void ReadData()
        {

        }

        public void GenereateQTLEffect()
        {

        }

        public string CalculatePValue()
        {
            double result = 0.0;
            db = DatabaseProvider.GetDatabase();
            HashSet<int> indi_0 = new HashSet<int>(); // individuals with genotype 0
            HashSet<int> indi_1 = new HashSet<int>(); // individuals with genotype 1
            int n0, n1; // should it be int? (size of sets) ?
            double x_i, y_i, x_a, y_a, x_s2 = 0.0, y_s2 = 0.0; // trait values, average and variance of individuals sets
            double x_sum = 0, y_sum = 0, x_sum_variance=0, y_sum_variance=0;
            double ttest;


            // fill arrays of indviduals
            for (int i = 0; i < this.db.SubData.Count; i++)
            {
                for (int j = 0; j < this.db.SubData[i].Genotype.Length; j++)
                {

                    if (this.db.SubData[i].Genotype[0, j] == 0)
                    {
                        indi_0.Add(i);
                    }
                    else if (this.db.SubData[i].Genotype[0,j] == 1)
                    {

                        indi_1.Add(i);
                    }
                }
            }

            foreach(int i in indi_0)
            {
                for(int j = 0; j < this.db.SubData[i].TraitValue.Length; j++)
                {
                    x_sum += db.SubData[i].TraitValue[0,j];
                }
            }

            foreach (int i in indi_1)
            {
                for (int j = 0; j < this.db.SubData[i].TraitValue.Length; j++)
                {
                    y_sum += db.SubData[i].TraitValue[0, j];
                }
            }
           
            n0 = indi_0.Count;
            n1 = indi_1.Count;

            x_a = x_sum / n0; // average of set with genotype 0 
            y_a = y_sum / n1; // average of set with genotype 1
            foreach (int i in indi_0)
            {
                for (int j = 0; j < this.db.SubData[i].TraitValue.Length; j++)
                {
                    x_sum_variance += Math.Pow((db.SubData[i].TraitValue[0, j] - x_a), 2);
                }
            }

            foreach (int i in indi_1)
            {
                for (int j = 0; j < this.db.SubData[i].TraitValue.Length; j++)
                {
                    y_sum_variance += Math.Pow((db.SubData[i].TraitValue[0, j] - x_a), 2);
                }
            }
            x_s2 = x_sum_variance / n0; // the variance of indi_0
            y_s2 = y_sum_variance / n1; // the variance of indi_1

            ttest = (y_a - x_a) / (Math.Sqrt(y_s2 / Math.Sqrt(n1) + x_s2 / Math.Sqrt(n0)));

               

            return Convert.ToString(result);
        }

        public void TraitDistributionHistogram(int traitIndex)
        {

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
            List<string> allValues = new List<string>();
            for (int i = 1; i <= 5; i++)
            {
                proportionVal = traitVal * i;
                allValues.Add(proportionVal.ToString("0.000"));
            }

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




            traithistogramChart.AddColumnSeries(allValues, proportionOfIndivid.Values.ToList<double>(), ColorConstants.highliteColor);
        }
    }
}
