using System.Collections.Generic;
using static QTLProject.Types;

namespace QTLProject
{
    public class GenomeOrganization
    {
      
        public MappingIndex MappingFunctionIndex { get; set; }//0=Haldane (independent recombinations), 1=Kossambi, ...(no need more for this project)
        public IList<Chromosome> Chromosome { get; set; }//list of all chromosomes in the genome (Human: includes also X and Y even for Women having no Y chromosome)
        
        //number of chromosomes
        public int nChr()
        {
            return (Chromosome.Count);
        }
        public void addChr(Chromosome ch)
        {
            ch.Id = nChr();
            Chromosome.Add(ch); 
        }
    }
}
