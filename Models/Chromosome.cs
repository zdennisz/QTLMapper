using System;
using System.Collections.Generic;
using System.Text;

namespace QTLProject
{
    public class Chromosome
    {

        private IList<Locus> locus = new List<Locus>();
        public int Id { get; set; }//0,1,2,3
        public string Name { get; set; }//for Human: 1,2,3,...,22, X and Y
        public double LenGenetcM { get; set; }//Genetic length of the chromosome (1 cM ~ 1% of recombination) NB! in this progects equal for males and females

        public bool BGender { get; set; }//Human: XX=Girl, XY=Boy
        public bool BPresentedInMales { get; set; }//Human: XX=Girl, XY=Boy: => true for all
        public bool BPresentedInFemales { get; set; }//Human: XX=Girl, XY=Boy: => Girl: false for Y chromosome
        public bool BRecInMales { get; set; }//Human: XX=Girl, XY=Boy: Males: false for X and Y
        public bool BRecInFemales { get; set; }//Human: XX=Girl, XY=Boy: Females: true for all
        
        public IList<Locus> Locus { get { return locus; } set { locus = value; } }//list of loci (markers and QTLs)

        public Chromosome()
        {
            BGender = false;
            BPresentedInMales = true;
            BPresentedInFemales = true;
            BRecInMales = true;
            BRecInFemales = true;
        }
    }
}
