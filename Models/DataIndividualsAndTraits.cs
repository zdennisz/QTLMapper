using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject
{
    public class DataIndividualsAndTraits
    {
        private List<int> genotypeOfInd = new List<int>();
        public IList<Locus> Locus { get; set; }//list of selected loci (markers and QTLs)
        public IList<Individ> Individ { get; set; }//list of selected individuals
        public IList<Trait> Trait { get; set; }//list of selected traits 
        public IList<int> GenotypeOfInd { get { return genotypeOfInd; } set { genotypeOfInd = (List<int>)value;} }//[iIndSelected]
        public float[,] TraitValue { get; set; }//[iIndSelected,iTraitSelected]
    }
}
