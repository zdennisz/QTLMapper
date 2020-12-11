using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject.Utils
{
    public static class TempDataHolder
    {
        public static event EventHandler UpdateTempHolder;

        public static List<Dictionary<int, string>> PartialTempFileHolder = new List<Dictionary<int, string>>();
        public static List<Dictionary<int, string>> FullTempFileHolder = new List<Dictionary<int, string>>();
        public static  void DataUpdated()
        {
            UpdateTempHolder?.Invoke(PartialTempFileHolder, null);
        }
    }
}
