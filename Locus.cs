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
        public int Id { get; set; }//id in the System
        public string Name { get; set; }
        public bool BMarker { get; set; }
        public Position Position { get; set; }//ID of chromosome
        
        public string[] AlleneNameOriginal { get; set; }//usually ('0','1'), ('a','A'), ('m','M'), ('A','T'), ('C','G'),... 
        public LocusDominanceStatus IdDominanceStatus { get; set; }//0 - allele 0 is dominant, 1 - allele 1 is dominant, 2 - codominant

    }
}
