using System.Collections.Generic;
using QTLProject.Utils;
using System.Windows.Forms;
using QTLProject.Enums;
using System.IO;
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
        private void CreateTableColumns()
        {
            List<string> geneticParams = new List<string>();
            geneticParams.Add(Constants.Marker);
            geneticParams.Add(Constants.CoorcM);
            geneticParams.Add(Constants.Chr);
            geneticParams.Add(Constants.Quality);

            dataTable.CreateInputDataTable(geneticParams, 25, 400, 4, 14);

        }
        private List<Dictionary<int, string>> parseData(string filePath)
        {
            List<Dictionary<int, string>> data = null;
            string line;
            //open the file and read it 
            var fileStream = File.OpenRead(filePath);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while ( (line = reader.ReadLine()) != null){
                    string[] symbols = line.Split(' ');
                    //Dictionary<int,string> row=new Dictionary<int,string<();
                    for(int i=0;i< symbols.Length;i++)
                    {
                        //symbol is what we to put in to the data structure
                        //row.Add(i,symbols[i]);
                    }

                    //data.Add(row);
                }

            } 
            //TODO 
            return data;
        }

        private void fillTable(List<Dictionary<int, string>> tableData)
        {
            int rowsToCopy = tableData.Count;
            dataTable.InsertTableData(tableData, rowsToCopy);
        }
        #endregion Private Methods

        #region Public Methods
        public void ReadDataFromFile(string path)
        {
            List<Dictionary<int, string>> data = parseData(path);
            //Currentlly disabled since we have no file to test 
            //fillTable(data);

        }

        public void DeleteTableRow()
        {
            dataTable.DeleteTableRow();
        }

        public void AddTableRow()
        {
            dataTable.AddTableRow();
        }

        public void CopyTableRow()
        {
            rowsToBeCopied = dataTable.GetCopiedRows();
        }

        public void PasteTableRows()
        {
            if (this.rowsToBeCopied > 0)
            {
                dataTable.PasteTableRows(this.rowsToBeCopied);
            }
            
        }

        public void SaveTableData()
        {
            List<Dictionary<int,string>> data = null;
            data=dataTable.RetreiveTableData();
            TempDataHolder.tempFileHolder = data; 
        }
        
        #endregion Public Methods
    }
}
