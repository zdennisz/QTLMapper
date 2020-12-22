using QTLProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTLProject.Types;

namespace QTLProject
{
    public class Locus
    {
        private List<AllelName> alleneNameOriginal = new List<AllelName>();

        public int Id { get; set; }//id in the System
        public string FullName { get; set; }
        public string Name { get; set; }
        public bool BMarker { get; set; }
        public Position Position { get; set; }//ID of chromosome
        public List<QTL_SingleLocusEffectOnSingleTrait> QTL = new List<QTL_SingleLocusEffectOnSingleTrait>();

        //public IList<AllelName> AlleneNameOriginal { get { return alleneNameOriginal;  } set { alleneNameOriginal = (List<AllelName>)value; } }//usually ('0','1'), ('a','A'), ('m','M'), ('A','T'), ('C','G'),... 
        public string[] AlleneNameOriginal = new string[2];
        public LocusDominanceStatus IdDominanceStatus { get; set; }//0 - allele 0 is dominant, 1 - allele 1 is dominant, 2 - codominant

        public Locus(int nLociCurrent, Position pos)
        {
            Id = nLociCurrent;
            Position = pos;
            Name = "m" + Id.ToString() + "_" + pos.Chromosome.Name + "_" + pos.PositionChrGenetic.ToString();//m1234_X_15.5
            BMarker = true;
            QTL = new List<QTL_SingleLocusEffectOnSingleTrait>();
            IdDominanceStatus = LocusDominanceStatus.IncompleteDominance;//1, i.e., codominant
            AlleneNameOriginal = new string[] { "A", "B" };
        }

    }
}
