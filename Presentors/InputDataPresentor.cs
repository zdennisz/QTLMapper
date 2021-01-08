using System.Collections.Generic;
using QTLProject.Utils;
using System.Windows.Forms;
using QTLProject.Enums;
using System.IO;
using static QTLProject.Types;
using System.Threading.Tasks;
using QTLProject.Models;
using System;

namespace QTLProject
{
    public class InputDataPresentor
    {
        #region Fields
        TableGenerator dataTable;
        private int rowsToBeCopied;
        #endregion Fields

        #region Constructor
        public InputDataPresentor(TableLayoutPanel inputDataTable)
        {
            dataTable = new TableGenerator(inputDataTable);
            CreateTableColumns();
        }
        #endregion Constructor

        #region Private Methods
        /// <summary>
        /// Write the data to the disk to a new file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        private async void WriteToFile(string pathWithoutExt,string fileName,string extension,List<Dictionary<int,string>> data)
        {
            
            string formatedFileName = fileName+ DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            formatedFileName+=extension;
            pathWithoutExt= pathWithoutExt+"//"+ formatedFileName;
            using (StreamWriter writer = File.CreateText(pathWithoutExt))
            {
                  writer.WriteLine("marker" + "\t" + "LG" + "\t" + "coorOnLG"+ "\t");
                 foreach(Dictionary<int, string> dic in data)
                {
                    await writer.WriteLineAsync(dic[0] + "\t" + dic[1] + "\t" + dic[2]);
                }
              
            }
        }
        /// <summary>
        /// Create the basic table for the page
        /// </summary>
        private void CreateTableColumns()
        {
            List<string> geneticParams = new List<string>();
            geneticParams.Add(Constants.Marker);
            geneticParams.Add(Constants.Chr);
            geneticParams.Add(Constants.CoorcM);

            dataTable.CreateInputDataTable(geneticParams, 25, 400, 3, 1);

        }
        /// <summary>
        /// Parse the file data from the file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<Dictionary<int, string>> parseData(string filePath)
        {
            List<Dictionary<int, string>> data = new List<Dictionary<int, string>>();
            string line;
            FileStream fileStream=null;
            //open the file and read it 
            fileStream = File.OpenRead(filePath);
            using (StreamReader reader = new StreamReader(fileStream))
            {
               //read the first line of the col names
                reader.ReadLine();
                while ( (line = reader.ReadLine()) != null){
                    string[] symbols = line.Split('\t');
                    if (symbols.Length != 3)
                    {
                        return null;
                    }
                        Dictionary<int,string> row=new Dictionary<int,string>();
                    for(int i=0;i< symbols.Length;i++)
                    {
                        //symbol is what we to put in to the data structure
                        row.Add(i,symbols[i]);
                    }

                    data.Add(row);
                }

            }
            
          


            return data;
        }
        /// <summary>
        /// Fills the table with data via the pointer to the table
        /// (fills the table with 100 rows only)
        /// </summary>
        /// <param name="tableData"></param>
        private void fillTable(List<Dictionary<int, string>> tableData)
        {

            dataTable.InsertTableData(tableData, tableData.Count, TableRowType.InputDataRow);
        }

        private void showToastMessage(NotifyIcon notifyIcon, string message = "File Saved at selected location.")
        {
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(1000);
        }


        #endregion Private Methods

        #region Public Methods
        public async void ReadDataFromFile(string path)
        {
            //parse the data in a none blocking way
            Cursor.Current = Cursors.WaitCursor;

            var data = await  Task.Run(() => parseData(path));
            Cursor.Current = Cursors.Default;
            if (data == null)
            {
                MessageBox.Show("Genetic Map is in incorrect format.\nFormat example :\nMarker name\tChromosome (i)\tGenetic location(cM)", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            //save the data in a temp holder

            List<Dictionary<int, string>> partialData = new List<Dictionary<int, string>>();
            int counter = 0;
            foreach( Dictionary<int,string> dic in data)
            {
                partialData.Add(dic);
                counter++;
                if (counter > 99)
                {
                    break;
                }
            }
            TempDataHolder.PartialTempFileHolder = partialData;
            TempDataHolder.FullTempFileHolder = data;
            //hide the table
            dataTable.ChangeTableVisibility(false);
            //fill the table
            fillTable(partialData);
            //show the table
            dataTable.ChangeTableVisibility(true);

        }
        /// <summary>
        /// Delets the last row of the table
        /// </summary>
        public void DeleteTableRow()
        {
            //delets the last table row
            dataTable.DeleteTableRow();
            //get the recent data
            var data = TempDataHolder.PartialTempFileHolder;
            //removes the data of the last row
            data.RemoveAt(data.Count-1);
        }

        public void AddTableRow()
        {
            dataTable.AddTableRow(TableRowType.InputDataRow);
            var data = TempDataHolder.PartialTempFileHolder;
            Dictionary<int, string> newDic = new Dictionary<int, string>();
            string str = "";
            newDic.Add(0, str);
            newDic.Add(1, str);
            newDic.Add(2, str);
            data.Add(newDic);
            dataTable.InsertTableData(newDic,TableRowType.InputDataRow);
        }

        public bool CheckDataAviliablity()
        {
            Database db = DatabaseProvider.GetDatabase();
            if (db.GenomeOrganization.Chromosome.Count > 0)
            {
                return true;
            }
            return false;

        }
        public void CopyTableRow()
        {
            rowsToBeCopied = dataTable.GetCopiedRows();
        }

        public void PasteTableRows()
        {
            if (this.rowsToBeCopied > 0)
            {
                //copy the actual rows
                dataTable.PasteTableRows(this.rowsToBeCopied);
            

            }
            
        }

        public void SaveTableData()
        {
           
            var data=dataTable.RetreiveTableData();
            //save the data in a temp file holder
            TempDataHolder.PartialTempFileHolder = data;
            //assign the data
            TempDataHolder.DataUpdated();
            //send update message to who ever is listening
        }

        public void SaveDataToNewFile(NotifyIcon notifyIcon)
        {
            List<Dictionary<int, string>> allData = new List<Dictionary<int, string>>();
            var fullData = TempDataHolder.FullTempFileHolder;
            //copy the unmodified data
            for(int i=100;i< fullData.Count; i++)
            {
                allData.Add(fullData[i]);
            }
            //save the modified data 
            foreach(Dictionary<int,string> dic in TempDataHolder.PartialTempFileHolder)
            {
                allData.Add(dic);
            }

            string path =null;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.OverwritePrompt = false; 
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                string fileName =Path.GetFileNameWithoutExtension(path);
                string extension=Path.GetExtension(path);
                var pathWithoutExt = Path.GetDirectoryName(path);
                WriteToFile(pathWithoutExt, fileName, extension,allData);
                showToastMessage(notifyIcon);


            }
        }





        #endregion Public Methods
    }
}
