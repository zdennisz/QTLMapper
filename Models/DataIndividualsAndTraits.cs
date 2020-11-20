using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject
{
    public class DataIndividualsAndTraits
    {
        public IList<Locus> Locus { get; set; }//list of selected loci (markers and QTLs)
        public IList<Individ> Individ { get; set; }//list of selected individuals
        public IList<Trait> Trait { get; set; }//list of selected traits 
        public int[] GenotypeOfInd { get; set; }//[iIndSelected]
        public float[,] TraitValue { get; set; }//[iIndSelected,iTraitSelected]
    }
}
