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
        public ErrorMessage errorMessage;
        public CalcQTLPresentor(TableLayoutPanel panel)
        {
            calQTLTable = new TableGenerator(panel);


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
        public bool CheckDataAviliability()
        {
            Database db = DatabaseProvider.GetDatabase();

            if (db.SubData.Count > 0 && db.SubData[0].Genotype != null && db.SubData[0].TraitValue == null)
            {
                errorMessage = ErrorMessage.MissingPhenotype;
                return false;
            }
            else if (db.SubData.Count > 0 && db.SubData[0].TraitValue != null && db.SubData[0].Genotype == null)
            {
                errorMessage = ErrorMessage.MissingGenotype;
                return false;
            }
            else if (db.SubData.Count == 0)
            {
                errorMessage = ErrorMessage.NoDataLoaded;
                return false;
            }

            return true;
        }
        public async void ReadDataGenotype(string path)
        {
            Cursor.Current = Cursors.WaitCursor;
            var rawData = await Task.Run(() => readFileGenData(path));
            Cursor.Current = Cursors.Default;
            List<Dictionary<int, string>> filteredData = new List<Dictionary<int, string>>();
            // filter out the locus that are not in the both files
            //iterate over all the raw data and filter only the ones that are both 
            if(rawData == null)
            {
                MessageBox.Show("Genotype file is not in correct format.\nExample:\nmarkerName\t010101010", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            List<Locus> LocusList = new List<Locus>();
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
                        LocusList.Add(locus);
                    }
                }
                if (filteredData.Count == 0)
                {
                    MessageBox.Show("Cannot find any Genotypes in the Genetic Map,\nPlease reload the Genetic map with a relevant ogranism.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorMessage = ErrorMessage.BadGeneticMap;
                    return;
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

                    for (int i = 0; i < population.Length; i++)
                    {
                        //create classes at first use
                        DataIndividualsAndTraits individualsAndTraits = new DataIndividualsAndTraits();
                        db.SubData.Add(individualsAndTraits);
                        db.SubData[i].Genotype = new int[1, filteredData.Count];
                        db.SubData[i].GenotypeOk = new bool[1, filteredData.Count];
                        db.SubData[i].Locus = LocusList;
                    }
                }
                else
                {
                    //already created just need to define the size
                    for (int i = 0; i < population.Length; i++)
                    {
                        db.SubData[i].Genotype = new int[1, filteredData.Count];
                        db.SubData[i].GenotypeOk = new bool[1, filteredData.Count];
                        db.SubData[i].Locus = LocusList;

                    }
                }

                int subIndex = 0;
                foreach (Dictionary<int, string> dic in filteredData)
                {
                    var pop = Regex.Split(dic[1], string.Empty);
                    if (pop[0] == "")
                    {
                        pop = pop.Skip(1).ToArray();
                    }
                    if (pop[pop.Length - 1] == "")
                    {
                        Array.Resize(ref pop, pop.Length - 1);
                    }


                    int offSetIndex = 0;

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
            if (rawData == null)
            {
                MessageBox.Show("Phenotype file is not in correct format.\nExample:tc111\t0.25\t0.21...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            string tempValue = null;
            for (int i = 0; i < rawData.Count; i++)
            {
                //iterate and remove all the trait names since we dont need them anymore
                rawData[i].Remove(0);
                rawData[i].TryGetValue(rawData[i].Count, out tempValue);
                if (tempValue.Equals(""))
                {
                    rawData[i].Remove(rawData[i].Count);
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
                //init all arrays
                for (int j = 0; j < rawData[0].Count; j++)
                {
                    db.SubData[j].TraitValueOk = new bool[1, rawData.Count];
                    db.SubData[j].TraitValue = new float[1, rawData.Count];
                }
                int traitCounter = 0;
                int dicCounter = 1;
                foreach (Dictionary<int, string> dic in rawData)
                {

                    for (int i = 0; i < db.SubData.Count; i++)
                    {
                        string tempVal = dic[dicCounter];
                        if (tempVal.Equals("$") || tempVal.Equals(""))
                        {
                            //missing data
                            db.SubData[i].TraitValueOk[0, traitCounter] = false;
                            db.SubData[i].TraitValue[0, traitCounter] = 0;
                        }
                        else
                        {
                            db.SubData[i].TraitValueOk[0, traitCounter] = true;
                            float val = float.Parse(tempVal);
                            db.SubData[i].TraitValue[0, traitCounter] = val;
                        }
                        dicCounter++;
                        dicCounter = dicCounter % 117;
                        if (dicCounter == 0)
                        {
                            dicCounter = 1;
                        }
                    }
                    traitCounter++;

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
                    if (symbols.Length == 2)
                    {


                        Dictionary<int, string> row = new Dictionary<int, string>();
                        for (int i = 0; i < symbols.Length; i++)
                        {
                            //symbol is what we to put in to the data structure
                            row.Add(i, symbols[i]);
                        }

                        data.Add(row);
                    }
                    else
                    {
                        return null;
                    }
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
                    if (symbols[0].Substring(0, 1).ToLower().Equals("t"))
                    {

                  
                    Dictionary<int, string> row = new Dictionary<int, string>();
                    for (int i = 0; i < symbols.Length; i++)
                    {
                        //symbol is what we to put in to the data structure
                        row.Add(i, symbols[i]);
                    }

                    data.Add(row);
                    }
                    else
                    {
                        return null;
                    }
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
            //save the modified data 
            int counter = 0;
            foreach (Dictionary<int, string> dic in TempDataHolder.PartialTempFileHolder)
            {
                allData.Add(dic);
                counter++;
            }
            //copy the unmodified data
            for (int i = counter; i < fullData.Count; i++)
            {
                allData.Add(fullData[i]);
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
