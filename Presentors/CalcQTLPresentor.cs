using QTLProject.Models;
using QTLProject.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QTLProject.Types;

namespace QTLProject
{
    public class CalcQTLPresentor
    {
        TableGenerator calQTLTable;
        Database db;
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

            var allData = combineAllData();
            buildGenomeOrganizm(allData);

        }
        public async void ReadDataGenotype(string path)
        {
            Cursor.Current = Cursors.WaitCursor;
            var rawData = await Task.Run(() => readFileGenData(path));
            Cursor.Current = Cursors.Default;

            // Dictionary<string, List<int>> parsedData = new Dictionary<string, List<int>>();
            // int individualNumber = 0;
            // db = DatabaseProvider.GetDatabase();
            //// db.DataIndividualsAndTraits = new DataIndividualsAndTraits();

            // foreach (Dictionary<int, string> dic in rawData)
            // {
            //     var locus=findLocus(db.GenomeOrganization.Chromosome, dic[0]);
            //     if (locus!=null)
            //     {

            //         // we found it in genetic map
            //         db.DataIndividualsAndTraits.Locus.Add(locus);

            //         var population = dic[1].Split().ToArray();
            //         for (int i=0;i<population.Length;i++)
            //         {

            //             if (population[i].Equals("1"))
            //             {

            //                 //this individual has the marker

            //             }
            //             else if (population[i].Equals("0"))
            //             {
            //                 //this individual dosent havethe marker

            //                 //zero
            //             }
            //             else
            //             {
            //                 //genotypeOfMarker.Add(-1);

            //                 //missing data
            //             }
            //         }

            //         individualNumber++;
            //     }

            //     //parsedData.Add(dic[0], genotypeOfMarker);

            // }

            //db = DatabaseProvider.GetDatabase();
            //lock (db)
            //{
            //    foreach(KeyValuePair<string,List<int>> entry in parsedData)
            //    {
            //        if (findLocus(entry.Key))
            //        {
            //            //if we find the locus in the genetic map we add it in the database else we dont
            //        }
            //    }
            //    db.DataIndividualsAndTraits = new DataIndividualsAndTraits();
            //}

        }
        public async void ReadDataPhenotype(string path)
        {
            Cursor.Current = Cursors.WaitCursor;
            var rawData = await Task.Run(() => readPhenData(path));
            Cursor.Current = Cursors.Default;


            //create list of traits
            List<Trait> tempListTraits = new List<Trait>();

            for (int i = 0; i < rawData.Count; i++)
            {
                string traitName;
                rawData[i].TryGetValue(0, out traitName);
                Trait t = new Trait();
                t.Id = i;
                t.NameFull = traitName;
                tempListTraits.Add(t);
            }

            db = DatabaseProvider.GetDatabase();
            lock (db)
            {

                if (db.SubData == null)
                {
                    db.SubData = new List<DataIndividualsAndTraits>();

                }

                for (int i = 0; i < rawData[0].Count; i++)
                {
                    //assign all the individuals the same traits from file
                    DataIndividualsAndTraits individualsAndTraits = new DataIndividualsAndTraits();
                    individualsAndTraits.Trait = tempListTraits;
                    db.SubData.Add(individualsAndTraits);
                }
                //we begin from 1 since index 0 is the trait name
                int keyIndex = 1;
                int colNum = 0;
                for (int i = 0; i < rawData[0].Count; i++)
                {
                    if (keyIndex == 0)
                    {
                        keyIndex = 1;
                    }
                    db.SubData[i].TraitValueOk = new bool[1, rawData.Count];
                    db.SubData[i].TraitValue = new float[1, rawData.Count];
                    foreach (Dictionary<int, string> dic in rawData)
                    {
                        string tempVal;
                        dic.TryGetValue(keyIndex, out tempVal);
                        if (tempVal.Equals("$")|| tempVal.Equals(""))
                        {
                            //missing data
                            db.SubData[i].TraitValueOk[0, colNum] =false;
                            db.SubData[i].TraitValue[0, colNum] = -1;
                        }
                        else
                        {
                            db.SubData[i].TraitValueOk[0, colNum] = true;
                            float val = float.Parse(tempVal);
                            db.SubData[i].TraitValue[0, colNum] = val;
                        }
                        


                    }

                    keyIndex = (keyIndex + 1) % rawData.Count;
                    colNum = (colNum + 1) % rawData.Count;
                }
            }
        
        }

        private List<Dictionary<int, string>> readFileGenData(string path)
        {
            //reading file part
            string line;
            List<Dictionary<int, string>> data;
            var fileStream = File.OpenRead(path);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                data = new List<Dictionary<int, string>>();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] symbols = line.Split('\t');
                    Dictionary<int, string> row = new Dictionary<int, string>();
                    for (int i = 0; i < symbols.Length; i++)
                    {
                        //symbol is what we to put in to the data structure
                        row.Add(i, symbols[i]);
                    }

                    data.Add(row);
                }
            }
            return data;

        }

        private Locus findLocus(IList<Chromosome> chList, string locusName)
        {
            foreach (Chromosome chr in chList)
            {
                var chromosome = chr;
                foreach (Locus loc in chromosome.Locus)
                {
                    if (loc.Name.Equals(locusName))
                    {
                        return loc;
                    }
                }
            }
            return null;
        }


        private List<Dictionary<int, string>> readPhenData(string path)
        {
            //reading file part
            string line;
            List<Dictionary<int, string>> data;
            var fileStream = File.OpenRead(path);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                data = new List<Dictionary<int, string>>();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] symbols = line.Split('\t');
                    Dictionary<int, string> row = new Dictionary<int, string>();
                    for (int i = 0; i < symbols.Length; i++)
                    {
                        //symbol is what we to put in to the data structure
                        row.Add(i, symbols[i]);
                    }

                    data.Add(row);
                }
            }
            return data;

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
            foreach (Dictionary<int, string> row in data)
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
                    chrDic.TryGetValue(chrNumber, out markerList);
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


            foreach (KeyValuePair<int, List<Locus>> entry in chrDic)
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
