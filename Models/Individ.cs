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
        /// <summary>
        /// With Lists must allocate space, unless null pointer exception will be thrown
        /// </summary>
        private List<Position> recEventsParent0 = new List<Position>();
        private List<Position> recEventsParent1 = new List<Position>();
        private List<int> haplotype0 = new List<int>();
        private List<bool> haplotype0Ok = new List<bool>();
        private List<int> haplotype1 = new List<int>();
        private List<bool> haplotype1Ok = new List<bool>();
        public int Id { get; set; }//id in the System
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Individ Parent0 { get; set; }//Human: Mother
        public Individ Parent1 { get; set; }//Human: Father
        public IList<Position> RecEventsParent0 { get { return recEventsParent0; } set { } }//list of all of recombination events to produce haplotype from mother
        public IList<Position> RecEventsParent1 { get { return recEventsParent1; } set { } }//list of all of recombination events to produce haplotype from mfather

        public List<int> Genotype { get; set; }
        public List<bool> GenotypeOk { get; set; }
        public List<int> Haplotype0 { get { return haplotype0; } set { } }
        public List<bool> Haplotype0Ok { get { return haplotype0Ok; } set { } }
        public List<int> Haplotype1 { get { return haplotype1; } set { } }
        public List<bool> Haplotype1Ok { get { return haplotype1Ok; } set { } }
        //public IList<Locus> LocusKnownHaplotype { get { return locusKnownHaplotype; } set { } }
        //public IList<Locus> LocusKnownGenotype { get; set; }
        //public int[] Haplotype0 { get { return haplotype0; } set {  } }
        //public int[] Haplotype1 { get { return haplotype1; } set { } }
        //public int[] Genotype { get { return genotype; } set { } }
        //public Trait[] TraitKnownValue { get; set; }
        //public float[] TraitValue { get { return traitValue; } set { } }
        public List<bool> traitPhenotypeValOk { get; set; }
        public List<float> traitPhenotypeVal { get; set; }
        public List<float> traitGenotypeVal { get; set; }

        public bool HaplotypeOk(int h, int iLocus)
        {
            if (h == 1) { return Haplotype1Ok[iLocus]; } else { return Haplotype0Ok[iLocus]; }
        }
        public int Haplotype(int h, int iLocus)
        {
            if (h == 1) { return Haplotype1[iLocus]; } else { return Haplotype0[iLocus]; }
        }
        public void InheritOrderedListOfLoci(List<Locus> OrderedListOfLoci)
        {
            HaplotypeInheritOrderedListOfLoci(OrderedListOfLoci, Parent0, RecEventsParent0,
                                                       out haplotype0,
                                                       out haplotype0Ok);
            HaplotypeInheritOrderedListOfLoci(OrderedListOfLoci, Parent1, RecEventsParent1,
                                                       out haplotype1,
                                                       out haplotype1Ok);
            Genotype = new List<int>();
            GenotypeOk = new List<bool>();
            int i = 0;
            foreach (Locus locus in OrderedListOfLoci)
            {
                bool b = Haplotype0Ok[i] && Haplotype1Ok[i];
                int a = -1;
                if (b) { a = Haplotype0[i] + Haplotype1[i]; }
                GenotypeOk.Add(b);
                Genotype.Add(a);
                i++;
            }
        }
        private void HaplotypeInheritOrderedListOfLoci(List<Locus> OrderedListOfLoci, Individ parent, IList<Position> RecEventsParent,
                                                       out List<int> Haplotype,
                                                       out List<bool> HaplotypeOk)
        {
            int Phase = 0;
            int NRec = RecEventsParent.Count;
            int NLoci = OrderedListOfLoci.Count;
            //NotBeforePosition(Position Pos)
            Haplotype = new List<int>();
            HaplotypeOk = new List<bool>();
            if (NLoci > 0)
            {
                Position PosLast = new Position();
                PosLast.Chromosome = OrderedListOfLoci[NLoci].Position.Chromosome;
                PosLast.PositionChrGenetic = OrderedListOfLoci[NLoci].Position.PositionChrGenetic + 10;
                Position PosNextRec = new Position();
                if (NRec == 0) { PosNextRec = PosLast; } else { PosNextRec = RecEventsParent[0]; }
                int IRec = 0;
                int ILocus = 0;
                List<int> ParentHaplotype;
                List<bool> ParentHaplotypeOk;
                foreach (Locus locus in OrderedListOfLoci)
                {
                    while (!PosNextRec.NotBeforePosition(locus.Position))
                    {
                        IRec++;
                        if (IRec >= NRec) { PosNextRec = PosLast; } else { PosNextRec = RecEventsParent[IRec]; }
                        Phase = 1 - Phase;//0<->1
                    }
                    if (Phase == 0)
                    {
                        ParentHaplotype = this.Haplotype0;
                        ParentHaplotypeOk = this.Haplotype0Ok;
                    }
                    else
                    {
                        ParentHaplotype = this.Haplotype1;
                        ParentHaplotypeOk = this.Haplotype1Ok;
                    }
                    Haplotype.Add(ParentHaplotype[ILocus]);
                    HaplotypeOk.Add(ParentHaplotypeOk[ILocus]);
                    ILocus++;
                }
            }
        }
    }
}
