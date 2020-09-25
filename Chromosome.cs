using System;
using System.Collections.Generic;
using System.Text;

namespace QTLProject
{
    public class Chromosome
    {
        public int Id { get; set; }//0,1,2,3
        public string Name { get; set; }//for Human: 1,2,3,...,22, X and Y
        public bool BGender { get; set; }//Human: XX=Girl, XY=Boy
        public double LenPhysBp { get; set; }//Physical length of the chromosome (bp=base pairs, 1 kbp=1000 bp, 1Mbp=1,000,000 bp, 1 Gbp=1,000,000,000 bp), (Not important for this project)
        public double LenGenetcM { get; set; }//Genetic length of the chromosome (1 cM ~ 1% of recombination) NB! in this progects equal for males and females
        public IList<Locus> Locus { get; set; }//list of loci (markers and QTLs)
        public bool BPresentedInMales { get; set; }//Human: XX=Girl, XY=Boy: => true for all
        public bool BPresentedInFemales { get; set; }//Human: XX=Girl, XY=Boy: => Girl: false for Y chromosome
        public bool BRecInMales { get; set; }//Human: XX=Girl, XY=Boy: Males: false for X and Y
        public bool BRecInFemales { get; set; }//Human: XX=Girl, XY=Boy: Females: true for all
    }
}
