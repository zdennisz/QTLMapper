using QTLProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTLProject
{
    public class CalcQTLPresentor
    {
        TableGenerator calQTLTable;
      
        public CalcQTLPresentor(TableLayoutPanel panel)
        {
            calQTLTable = new TableGenerator(panel);
            
            
        }

        public void AnalyzeData()
        {

        }

        public void GeneratePrevoiusTable(List<string> modelParams, float rowSize, float colSize, int colAmount)
        {
            //get the data from the singelton 
            var dataFromDB = TempDataHolder.PartialTempFileHolder;


            //generate the table
           
            calQTLTable.GenerateTableForView(modelParams, rowSize, colSize, colAmount, dataFromDB.Count);


            

            //fill the data from the db
            calQTLTable.PopulateViewTable(dataFromDB);
        }

        public List<Dictionary<int,string>> CombineGeneticMap()
        {
            List<Dictionary<int, string>> allData = new List<Dictionary<int, string>>();
            var fullData = TempDataHolder.FullTempFileHolder;
            //copy the unmodified data
            for (int i = 100; i < fullData.Count; i++)
            {
                allData.Add(fullData[i]);
            }
            //save the modified data 
            foreach (Dictionary<int, string> dic in TempDataHolder.PartialTempFileHolder)
            {
                allData.Add(dic);
            }

        }
        public async void ReadDataGenotype(string path)
        {
            Cursor.Current = Cursors.WaitCursor;
            var data = await Task.Run(() => parseGenData(path));
            Cursor.Current = Cursors.Default;

        }
        public async void ReadDataPhenotype(string path)
        {
            Cursor.Current = Cursors.WaitCursor;
            var data = await Task.Run(() => parsePhenData(path));
            Cursor.Current = Cursors.Default;
        }

        private object parseGenData(string path)
        {
            return null;
        }
        private object parsePhenData(string path)
        {
            return null;
        }
    }
}
