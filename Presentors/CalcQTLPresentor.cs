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

        public void CombineGeneticMap()
        {
            
            //combine the partial and full temp holder data
        }
        public void ReadDataGenotype()
        {

        }
        public void ReadDataPhenotype()
        {

        }

    }
}
