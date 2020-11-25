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
        //private int[] haplotype0 = new int[40];
        //private int[] haplotype1 = new int[40];
        //private int[] genotype = new int[40];
        //private List<Position> recEventsParent0 = new List<Position>();
        //private List<Position> recEventsParent1 = new List<Position>();
        //private List<Locus> locusKnownHaplotype = new List<Locus>();
        //private float[] traitValue = new float[2];
        
        public int Id { get; set; }//id in the System
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Individ Parent0 { get; set; }//Human: Mother
        public Individ Parent1 { get; set; }//Human: Father
        public IList<Position> RecEventsParent0 { get { return recEventsParent0; } set { } }//list of all of recombination events to produce haplotype from mother
        public IList<Position> RecEventsParent1 { get { return recEventsParent1; } set { } }//list of all of recombination events to produce haplotype from mfather
        
        public List<int> Genotype { get; set;}
        public List<bool> GenotypeOk { get; set;}
        public List<int> Haplotype0 { get; set;}
        public List<bool> Haplotype0Ok { get; set;}
        public List<int> Haplotype1 { get; set;}
        public List<bool> Haplotype1Ok { get; set;}
        //public IList<Locus> LocusKnownHaplotype { get { return locusKnownHaplotype; } set { } }
        //public IList<Locus> LocusKnownGenotype { get; set; }
        //public int[] Haplotype0 { get { return haplotype0; } set {  } }
        //public int[] Haplotype1 { get { return haplotype1; } set { } }
        //public int[] Genotype { get { return genotype; } set { } }
        //public Trait[] TraitKnownValue { get; set; }
        //public float[] TraitValue { get { return traitValue; } set { } }
    }
    public bool HaplotypeOk(int h, int iLocus){
        if (h==1) {return Haplotype1Ok[iLocus];} else {return Haplotype0Ok[iLocus];}
    }
}
