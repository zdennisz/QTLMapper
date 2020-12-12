using System.Collections.Generic;
using QTLProject.Utils;
using System.Windows.Forms;
using QTLProject.Enums;
using System.IO;
using static QTLProject.Types;

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
        private async void WriteToFile(string path,List<Dictionary<int,string>> data)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                foreach (Dictionary<int, string> dic in data)
                {
                    await writer.WriteAsync(dic[0] + "\t" + dic[1] + "\t" + dic[2]+"\n");
                }
              
            }
        }
        private void CreateTableColumns()
        {
            List<string> geneticParams = new List<string>();
            geneticParams.Add(Constants.Marker);
            geneticParams.Add(Constants.CoorcM);
            geneticParams.Add(Constants.Chr);

            dataTable.CreateInputDataTable(geneticParams, 25, 400, 3, 1);

        }
        private List<Dictionary<int, string>> parseData(string filePath)
        {
            List<Dictionary<int, string>> data = new List<Dictionary<int, string>>();
            string line;
            //open the file and read it 
            var fileStream = File.OpenRead(filePath);
            using (StreamReader reader = new StreamReader(fileStream))
            {
               //read the first line of the col names
                reader.ReadLine();
                while ( (line = reader.ReadLine()) != null){
                    string[] symbols = line.Split('\t');
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
        #endregion Private Methods

        #region Public Methods
        public void ReadDataFromFile(string path)
        {
            //parse the data
            var data = parseData(path);
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
            //fill the table
            fillTable(partialData);

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

        public void SaveDataToNewFile()
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
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                WriteToFile(path, allData);
            }
        }

        #endregion Public Methods
    }
}
