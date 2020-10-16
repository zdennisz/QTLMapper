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

        //0   - Allele 1 is recessive
        //1   - Allele 1 is dominant
        //0.5 - Allele 1 is codominant
        public struct AdditiveEffect_h 
        {
            public const double Recessive = 0;
            public const double Codominant = 0.5;
            public const double Dominant = 1;

        }

        /// <summary>
        /// Gender : 0 - Female, 1 - Male
        /// </summary>
        public enum Gender
        {
            Female=0,
            Male=1
        }
        /// <summary>
        ///MappingFunctionIndex  0=Haldane (independent recombinations), 1=Kossambi
        /// </summary>
        public enum MappingIndex
        {
            Haldane = 0,
            Kossambi=1
        }

        public enum OrganismType
        {
            Drosophila=1,
            PseudoWheat=2,
        }
         
    }
    }
