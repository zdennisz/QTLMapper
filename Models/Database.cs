using System;
using System.Collections.Generic;
using System.Text;

namespace QTLProject
{
    public class Database
    {
        /// <summary>
        /// This class represents the database class
        /// </summary>
        /// 
        private List<Model> model = new List<Model>();
        private List<DataIndividualsAndTraits> subData = new List<DataIndividualsAndTraits>();
        public GenomeOrganization GenomeOrganization { get; set; }
        public DataIndividualsAndTraits DataIndividualsAndTraits { get; set; }
        public IList<Model> Model { get { return model; } set { model = (List<Model>)value; } }
        public IList<DataIndividualsAndTraits> SubData { get { return subData; } set { subData = (List<DataIndividualsAndTraits>)value; } }

    }
}
