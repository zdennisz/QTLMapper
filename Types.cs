using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject
{
    public static class Types
    {
        /// <summary>
        ///  Complete dominance, Incomplete dominance, and Codominance
        /// 0 - allele 0 is dominant, 1 - allele 1 is dominant, 2 - codominant
        /// </summary>
        public enum LocusDominanceStatus
        {
          CompleteDominance=0,
          IncompleteDominance=1,
          Codominant=2
        }

        /// <summary>
        /// Gender : 0 - Female, 1 - Male
        /// </summary>
        public enum Gender
        {
            Female=0,
            Male=1
        }
    }
}
