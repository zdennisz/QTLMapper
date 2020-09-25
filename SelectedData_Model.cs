using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject
{
    class SelectedData_Model
    {
        public Model Model { get; set; }
        public DataIndividualsAndTraits SubData { get; set; }
        public IList<SelectedData_Model_ChromosomeStatistics> ChromosomeStatistics { get; set; }
        public IList<SelectedData_Model_MarkerStatistics> MarkerStatistics { get; set; }
    }
}
