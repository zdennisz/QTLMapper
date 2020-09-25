using System;
using System.Collections.Generic;
using System.Text;

namespace QTLProject
{
   public class DataAll
    {
        public GenomeOrganization GenomeOrganization { get; set; }
        public DataIndividualsAndTraits DataIndividualsAndTraits { get; set; }
        public IList<Model> Model { get; set; }
        public IList<DataIndividualsAndTraits> SubData { get; set; }
 
    }
}
