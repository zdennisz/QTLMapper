using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject.Utils
{
    class StatisticCalculations
    {
        private static double x_s2, y_s2;

        public static double PValueTStatistic(List<double> n_0, List<double> n_1)
        {
            double t_stat=tStatistic(n_0, n_1);
            double df = degreesOfFreedom(x_s2, y_s2, n_0.Count, n_1.Count);
            return Student(t_stat, df);
        }

        /// <summary>
        /// Calcuales the t statistic to use in order to calculate the p Value accordinglly
        /// </summary>
        /// <param name="n_0"></param>
        /// <param name="n_1"></param>
        /// <returns></returns>
        private static double tStatistic(List<double> n_0, List<double> n_1)
        {
            double x_sum = 0.0, y_sum = 0.0, x_sum_variance = 0.0, y_sum_variance = 0.0, tStatistic = 0.0, x_a = 0.0, y_a = 0.0;
            x_s2 = 0.0;
            y_s2 = 0.0;
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
            return tStatistic;
        }

        /// <summary>
        /// Calcuales the degrees of freedom using the variance of two gorups and their size
        /// </summary>
        /// <param name="x_s2"></param>
        /// <param name="y_s2"></param>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <returns></returns>
        public static double degreesOfFreedom(double x_s2, double y_s2, int n0, int n1)
        {
            double num, denomLeft, denomRight, denom, df;
            num = ((x_s2 / n0) + (y_s2 / n1)) * ((x_s2 / n0) + (y_s2 / n1));
            denomLeft = ((x_s2 / n1) * (x_s2 / n0)) / (n0 - 1);
            denomRight = ((y_s2 / n1) * (y_s2 / n1)) / (n1 - 1);
            denom = denomLeft + denomRight;
            df = num / denom;
            return df;
        }
       
       /// <summary>
       /// t test of the student type 
       /// </summary>
       /// <param name="t"></param>
       /// <param name="df"></param>
       /// <returns></returns>
        private static double Student(double t, double df)
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

        /// <summary>
        /// Calculates the p value according to gauss data distribution
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        private static double Gauss(double z)
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
    }
}
