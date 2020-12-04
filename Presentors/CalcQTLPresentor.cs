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

        public void GeneratePrevoiusTable(List<string> modelParams, float rowSize, float colSize, int colAmount, int amountOfRows)
        {
            //generate the table
            calQTLTable.GenerateTableForView(modelParams, rowSize, colSize, colAmount, amountOfRows);
         
            //get the data from the singelton 
            List<Dictionary<int, string>> dataFromDB=null;
            
            //fill the data from the db
            calQTLTable.PopulateViewTable(dataFromDB);
        }


        public void ReadDataGenotype()
        {

        }
        public void ReadDataPhenotype()
        {

        }

    }
}
