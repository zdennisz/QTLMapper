using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTLProject.Types;

namespace QTLProject
{
    public class Individ
    {
        public int Id { get; set; }//id in the System
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Individ Parent0 { get; set; }//Human: Mother
        public Individ Parent1 { get; set; }//Human: Father
        public IList<Position> RecEventsParent0 { get; set; }//list of all of recombination events to produce haplotype from mother
        public IList<Position> RecEventsParent1 { get; set; }//list of all of recombination events to produce haplotype from mfather
        public IList<Locus> LocusKnownHaplotype { get; set; }
        public IList<Locus> LocusKnownGenotype { get; set; }
        public int[] Haplotype0 { get; set; }
        public int[] Haplotype1 { get; set; }
        public int[] Genotype { get; set; }
        public Trait[] TraitKnownValue { get; set; }
        public float[] TraitValue { get; set; }
    }
}
