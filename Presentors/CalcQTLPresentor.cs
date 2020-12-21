using QTLProject.Models;
using QTLProject.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            List<Dictionary<int, string>> filteredData = new List<Dictionary<int, string>>();
            // filter out the locus that are not in the both files
            //iterate over all the raw data and filter only the ones that are both 
            db = DatabaseProvider.GetDatabase();
            lock (db)
            {

                //in filterd data we removed the markers that are not found in the map 
                foreach (Dictionary<int, string> dic in rawData)
                {
                    var locus = findLocus(db.GenomeOrganization.Chromosome, dic[0]);
                    if (locus != null)
                    {
                        filteredData.Add(dic);
                    }
                }

                var population = Regex.Split(filteredData[0][1], string.Empty);
                if (population[0] == "")
                {
                    population = population.Skip(1).ToArray();
                }
                if (population[population.Length - 1] == "")
                {
                    Array.Resize(ref population, population.Length - 1);
                }

                if (db.SubData.Count == 0)
                {
                   
                    for (int i=0;i< population.Length; i++)
                    {
                        //create classes at first use
                        DataIndividualsAndTraits individualsAndTraits = new DataIndividualsAndTraits();
                        db.SubData.Add(individualsAndTraits);
                        db.SubData[i].Genotype = new int[1, filteredData.Count];
                        db.SubData[i].GenotypeOk = new bool[1, filteredData.Count];
                    }
                }
                else
                {
                    //already created just need to define the size
                    for (int i = 0; i < population.Length; i++)
                    {
                        db.SubData[i].Genotype = new int[1, filteredData.Count];
                        db.SubData[i].GenotypeOk = new bool[1, filteredData.Count];

                    }
                }


                foreach (Dictionary<int, string> dic in filteredData)
                {
                    var pop = Regex.Split(dic[1], string.Empty);
                    if (pop[0] == "")
                    {
                        pop = pop.Skip(1).ToArray();
                    }
                    if (pop[pop.Length-1] == "")
                    {
                        Array.Resize(ref pop, pop.Length - 1);
                    }

                    int subIndex = 0;
                    int offSetIndex = 1;
                    if (offSetIndex == 0)
                    {
                        offSetIndex = 1;
                    }
                    foreach (DataIndividualsAndTraits indiv in db.SubData)
                    {

                        if (pop[offSetIndex].Equals("-"))
                        {
                            //missing data - need to add another state to go with 1 is true ,0 false , -1 missing
                            indiv.Genotype[0, subIndex] = -1;
                            indiv.GenotypeOk[0, subIndex] = false;
                        }
                        else if (pop[offSetIndex].Equals("1"))
                        {
                            // data is 1
                            indiv.Genotype[0, subIndex] = 1;
                            indiv.GenotypeOk[0, subIndex] = true;
                        }
                        else if (pop[offSetIndex].Equals("0"))
                        {
                            //data is 0
                            indiv.Genotype[0, subIndex] = 0;
                            indiv.GenotypeOk[0, subIndex] = false;
                        }
                        offSetIndex = (offSetIndex + 1) % pop.Length;
                       
                    }

                    subIndex = (subIndex + 1) % filteredData.Count;



                }



            }



        }
        public async void ReadDataPhenotype(string path)
        {
            Cursor.Current = Cursors.WaitCursor;
            var rawData = await Task.Run(() => readPhenData(path));
            Cursor.Current = Cursors.Default;


            //create list of traits
            List<Trait> tempListTraits = new List<Trait>();

            //get full names of the traits
            for (int i = 0; i < rawData.Count; i++)
            {
                string traitName;
                rawData[i].TryGetValue(0, out traitName);
                Trait t = new Trait();
                t.Id = i;
                t.NameFull = traitName;
                tempListTraits.Add(t);
            }
            string tempValue=null;
            for(int i=0; i < rawData.Count; i++)
            {
                //iterate and remove all the trait names since we dont need them anymore
                rawData[i].Remove(0);
                rawData[i].TryGetValue(rawData[i].Count , out tempValue);
                if (tempValue.Equals(""))
                {
                    rawData[i].Remove(rawData[i].Count );
                }
              
            }
            db = DatabaseProvider.GetDatabase();
            lock (db)
            {
                
                
               
                if (db.SubData.Count == 0)
                {

                    for (int i = 0; i < rawData[0].Count; i++)
                    {
                        //assign all the individuals the same traits from file
                        DataIndividualsAndTraits individualsAndTraits = new DataIndividualsAndTraits();
                        individualsAndTraits.Trait = tempListTraits;
                        db.SubData.Add(individualsAndTraits);
                    }
                }
                else
                {
                    for (int i = 0; i < rawData[0].Count; i++)
                    {
                        //data already exists thus need to add it the traits
                        db.SubData[i].Trait = tempListTraits;
                    }
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
                        if (tempVal.Equals("$") || tempVal.Equals(""))
                        {
                            //missing data
                            db.SubData[i].TraitValueOk[0, colNum] = false;
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
                    if (loc.FullName.Equals(locusName))
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
                    l.FullName = row[0];
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
                    l.FullName = row[0];
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
