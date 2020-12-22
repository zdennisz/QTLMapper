using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTLProject.Types;

namespace QTLProject
{
    public class DataIndividualsAndTraits
    {
        private List<Locus> locus = new List<Locus>();
        private List<Individ> individ = new List<Individ>();
        private List<Trait> trait = new List<Trait>();
        //iIndSelected
        //iLocusSelected
        //iTraitSelected

        public IList<Locus> Locus { get { return locus; } set { locus = (List<Locus>)value; } }//list of selected loci (markers and QTLs)
        public IList<Individ> Individ { get { return individ; } set { individ = (List<Individ>)value; } }//list of selected individuals
        public IList<Trait> Trait { get { return trait; } set { trait = (List<Trait>)value; } }//list of selected traits 
         
        public int[,] Genotype { get; set; }//[iIndSelected,iLocusSelected]
        public bool[,] GenotypeOk { get; set; }//[iIndSelected,iLocusSelected]
        public float[,] TraitValue { get; set; }//[iIndSelected,iTraitSelected]
        public bool[,] TraitValueOk { get; set; }//[iIndSelected,iTraitSelected]
    }
}
