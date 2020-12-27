using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTLProject.Models;

namespace QTLProject
{
    public class VIewResultsPresentor
    {
        Database db = null;
        public VIewResultsPresentor()
        {


            //calcs
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
    }
}
