using QTLProject.Models;
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

        public void ProcessAllGeneticMapData()
        {

            var allData=combineAllData();
            buildGenomeOrganizm(allData);

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
        /// <summary>
        /// Combine all genetic data sources to one source
        /// </summary>
        /// <returns></returns>
        private List<Dictionary<int, string>> combineAllData()
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

            return allData;
        }
        /// <summary>
        /// Create the genetic organism object via teh input data
        /// </summary>
        /// <param name="data"></param>
        private void buildGenomeOrganizm(List<Dictionary<int, string>> data)
        {
            var db = DatabaseProvider.GetDatabase();
            db.GenomeOrganization = new GenomeOrganization();
            db.GenomeOrganization.Chromosome = new List<Chromosome>();
            int markerId = 0;
            var chrDic = new Dictionary<int, List<Locus>>();
            foreach (Dictionary<int,string> row in data)
           {
                //get the chr number
                string chrNum = row[1].Substring(2);
                int chrNumber = Convert.ToInt32(chrNum);

                //get the position of the marker
                double genPosition = Convert.ToDouble(row[2]);

                //set the position
                Position p = new Position();
                p.PositionChrGenetic = genPosition;
                

                if (chrDic.ContainsKey(chrNumber))
                {
                 //This is case we have the chromosome
                    List<Locus> markerList;
                    chrDic.TryGetValue(chrNumber,out markerList);
                    //same chromosome - as the first one from the list
                    p.Chromosome = markerList[0].Position.Chromosome;
                    Locus l = new Locus(markerId, p);
                    markerList.Add(l);
                    markerId++;
                    //add to the current chr
                }
                else
                {
                    List<Locus> markerList = new List<Locus>();
                    chrDic.Add(chrNumber, markerList);
                    p.Chromosome = new Chromosome();
                    p.Chromosome.Name = chrNumber.ToString();
                    Locus l = new Locus(markerId, p);
                    markerList.Add(l);  
                    //add new chromosome
                    markerId++;
                }


            }


            foreach(KeyValuePair<int, List<Locus>> entry in chrDic)
            {
                Chromosome ch = new Chromosome();
                ch.Id = entry.Key;
                ch.Locus = entry.Value;
                var maxChrLen = ch.Locus.Max(x => x.Position.PositionChrGenetic);
                ch.LenGenetcM = maxChrLen;
                db.GenomeOrganization.addChr(ch);
            }
        }

    }
}
