using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject
{
    public class Population
    {
        private List<Individ> individ = new List<Individ>();

        public int Id { get; set; }//id in the System
        public string Name { get; set; }
        public string Text { get; set; }//short description
        public IList<Individ> Individ { get { return individ; } set {  } }//list of selected individuals
    }
}
