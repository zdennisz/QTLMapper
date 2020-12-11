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
        /// </summary>
        /// <param name="tableData"></param>
        private void fillTable(List<Dictionary<int, string>> tableData)
        {
            //limit the rows to copy to 100
            int rowsToCopy = 100;

            dataTable.InsertTableData(tableData, rowsToCopy, TableRowType.InputDataRow);
        }
        #endregion Private Methods

        #region Public Methods
        public void ReadDataFromFile(string path)
        {
            List<Dictionary<int, string>> data = parseData(path);
            //Currentlly disabled since we have no file to test 
            fillTable(data);

        }

        public void DeleteTableRow()
        {
            dataTable.DeleteTableRow();
        }

        public void AddTableRow()
        {
            dataTable.AddTableRow(TableRowType.InputDataRow);
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
