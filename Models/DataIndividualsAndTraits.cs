using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject
{
    public class DataIndividualsAndTraits
    {
        //iIndSelected
        //iLocusSelected
        //iTraitSelected
        public IList<Locus> Locus { get; set; }//list of selected loci (markers and QTLs)
        public IList<Individ> Individ { get; set; }//list of selected individuals
        public IList<Trait> Trait { get; set; }//list of selected traits 
        
        //why do you need these?
        private List<int> genotypeOfInd = new List<int>();
        public IList<int> GenotypeOfInd { get { return genotypeOfInd; } set { genotypeOfInd = (List<int>)value;} }//[iIndSelected]
        
        public int[,] Genotype { get; set; }//[iIndSelected,iLocusSelected]
        public bool[,] GenotypeOk { get; set; }//[iIndSelected,iLocusSelected]
        public float[,] TraitValue { get; set; }//[iIndSelected,iTraitSelected]
        public bool[,] TraitValueOk { get; set; }//[iIndSelected,iTraitSelected]
    }
}
