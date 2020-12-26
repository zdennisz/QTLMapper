using QTLProject.Enums;
using QTLProject.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QTLProject.Types;
using static QTLProject.Views.PopInfoTableRow;

namespace QTLProject.Utils
{
    public class TableGenerator
    {
        public TableLayoutPanel tableLayoutPanel;
        public Panel panelTableContainer;
        SortedDictionary<int, bool> selectedRows = new SortedDictionary<int, bool>();
        public event EventHandler<EventArgsRowsAmount> AmountOfRowsChanged;
       
        public TableGenerator(TableLayoutPanel panel)
        {
            this.tableLayoutPanel = panel;


        }
        public TableGenerator(Panel panel1)
        {
            this.panelTableContainer = panel1;

        }
        /// <summary>
        /// Changes the visiblity of the table
        /// </summary>
        /// <param name="val"></param>
        public void ChangeTableVisibility(bool val)
        {
            this.tableLayoutPanel.Visible = val;
        }
        public List<Dictionary<int, string>> RetreiveTableData()
        {
            List<Dictionary<int, string>> tableData = new List<Dictionary<int, string>>();

            if (this.tableLayoutPanel != null)
            {

                foreach (var row in tableLayoutPanel.Controls)
                {
                    if (row.GetType().Name == Constants.GeneticTableRowName)
                    {
                        tableData.Add(((GeneticTableRow)row).tableRow);
                    }
                    if (row.GetType().Name == Constants.InputDataTableRowName)
                    {
                        tableData.Add(((InputDataTableRow)row).tableRow);
                    }
                }
            }
            else
            {
                int index = 0, row;
                for (int i = 0; i < this.panelTableContainer.Controls.Count; i++)
                {
                    tableData.Add(new Dictionary<int, string>());
                }

                foreach (TableLayoutPanel table in this.panelTableContainer.Controls)
                {
                    foreach (var column in table.Controls)
                    {


                        if (column.GetType().Name == Constants.TraitTableRowName)
                        {

                            row = index % 6;
                            if (index < 6)
                            {
                                tableData[0].Add(row, ((TraitTableRow)column).textVal);

                            }
                            else
                            {

                                tableData[1].Add(row, ((TraitTableRow)column).textVal);
                            }
                            index++;
                        }
                    }
                }


            }
            return tableData;
        }
        /// <summary>
        /// Adds a row to the table
        /// </summary>
        public void AddTableRow(TableRowType row)
        {

            switch (row)
            {
                case TableRowType.InputDataRow:
                    AddTableRowInputData();


                    break;
                case TableRowType.GeneticDataRow:
                    AddTableRowGeneticData();
                    break;
            }


        }
        private void AddTableRowInputData()
        {
            var table = this.tableLayoutPanel;
            int colAmount = table.ColumnCount;
            int rowIndex = table.RowStyles.Count;
            InputDataTableRow tableRow = null;
            tableRow = new InputDataTableRow(rowIndex);
            tableRow.RowChecked += TableRow_RowChecked;
            tableRow.Dock = DockStyle.Fill;

            if (rowIndex % 2 == 0)
            {
                tableRow.BackColor = ColorConstants.tableBackgroundColor;
                tableRow.BackColor = ColorConstants.tableBackgroundColor;
                tableRow.setTextBoxBackgroundColor(ColorConstants.tableBackgroundColor);
            }
            else
            {
                tableRow.BackColor = Color.White;
                tableRow.BackColor = Color.White;
                tableRow.setTextBoxBackgroundColor(Color.White);

            }

            tableRow.BorderStyle = BorderStyle.None;
            table.SetColumnSpan(tableRow, colAmount);
            
            table.Controls.Add(tableRow, 0, rowIndex);
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
        }

        private void AddTableRowGeneticData()
        {
            var table = this.tableLayoutPanel;
            int colAmount = table.ColumnCount;
            int rowIndex = table.RowStyles.Count;
            GeneticTableRow tableRow;
            tableRow = new GeneticTableRow();
            tableRow.Dock = DockStyle.Fill;

            if (rowIndex % 2 == 0)
            {
                tableRow.BackColor = ColorConstants.tableBackgroundColor;
                tableRow.BackColor = ColorConstants.tableBackgroundColor;
                tableRow.setTextBoxBackgroundColor(ColorConstants.tableBackgroundColor);
            }
            else
            {
                tableRow.BackColor = Color.White;
                tableRow.BackColor = Color.White;
                tableRow.setTextBoxBackgroundColor(Color.White);

            }

            tableRow.BorderStyle = BorderStyle.None;
            table.SetColumnSpan(tableRow, colAmount);
            table.Controls.Add(tableRow, 0, rowIndex);
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
        }

        /// <summary>
        /// Adds rows according to the amount that it is  sent
        /// </summary>
        /// <param name="AmountOfRows"></param>
        public void AddTableRow(int AmountOfRows,TableRowType type)
        {
           
            while (AmountOfRows > 0)
            {
                AddTableRow(type);
                AmountOfRows--;
            }
        }

        private void TableRow_RowChecked(object sender, EventArgs e)
        {
            InputDataTableRow row = sender as InputDataTableRow;
            bool isChecked = ((CheckBox)(row.Controls[0])).Checked;
            selectedRows[row.rowIndex] = isChecked;
        }
        /// <summary>
        /// Get the amount of rows that the table has
        /// </summary>
        /// <returns></returns>
        public int GetGeneticTableAmountOfRows()
        {
            var table = this.tableLayoutPanel;
            //remove one since the header of the table is not a data row
            return (table.RowStyles.Count-1);

        }

        /// <summary>
        /// Generates the pop info table
        /// </summary>
        /// <param name="modelParams"></param>
        /// <param name="rowSize"></param>
        /// <param name="colSize"></param>
        /// <param name="colAmount"></param>
        public void GeneratePopInfoTable(List<string> modelParams, float rowSize, float colSize, int colAmount)
        {
            int rowIndex = 0;
            var table = (TableLayoutPanel)this.tableLayoutPanel;
            table.Controls.Clear();
            table.RowStyles.Clear();
            table.ColumnCount = colAmount;
            table.RowCount = modelParams.Count + 1;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, colSize));
            Label placeHodler = new Label();
            placeHodler.Dock = DockStyle.Fill;
            placeHodler.Text = "Pop Info";
            placeHodler.BackColor = ColorConstants.tableHeaderColor;
            table.SetColumnSpan(placeHodler, table.ColumnCount);
            table.Controls.Add(placeHodler, 0, rowIndex);

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));
            rowIndex++;
            foreach (string name in modelParams)
            {

                var tableRow = new PopInfoTableRow();
                tableRow.rowLabel.Text = name;


                tableRow.rowTextBox.Name = "tb" + name.Replace(" ", "");
                tableRow.rowPanel.Dock = DockStyle.Fill;

                tableRow.rowPanel.BackColor = Color.White;
                tableRow.rowTextBox.BackColor = Color.White;

                if (rowIndex % 2 == 0)
                {
                    tableRow.rowPanel.BackColor = ColorConstants.tableBackgroundColor;
                    tableRow.rowTextBox.BackColor = ColorConstants.tableBackgroundColor;
                }
                tableRow.rowTextBox.BorderStyle = BorderStyle.None;

                table.SetColumnSpan(tableRow, 2);
                table.Controls.Add(tableRow, 0, rowIndex);
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));
                if (rowIndex == modelParams.Count)
                {
                    //sign up for the event for the Chr Amount
                    tableRow.AmountOfRows += TableRow_AmountOfRows;
                }

                rowIndex++;
            }
        }

        private void TableRow_AmountOfRows(object sender, PopInfoTableRow.EventArgsRowsAmount e)
        {
            AmountOfRowsChanged?.Invoke(this, e);
        }
        /// <summary>
        /// Initiates the table with basic default data
        /// </summary>
        /// <param name="defaultValues"></param>
        public void InitGeneticTableDefaultData(List<string> defaultValues)
        {
            var table = this.tableLayoutPanel;
            int colIndex = 0;
            foreach(GeneticTableRow row in table.Controls.OfType<GeneticTableRow>())
            {

                row.Controls[0].Text = defaultValues[colIndex];

                colIndex++;


                row.Controls[1].Text = defaultValues[colIndex];
                
                colIndex++;

                int val = Convert.ToInt32(row.Controls[0].Text);
                int val2 = Convert.ToInt32(row.Controls[1].Text);
                var result = val * val2;
                
                row.Controls[2].Text = Convert.ToString(result);
            }
        }

        public void InitPopInfoDefaultData(int popSize,int chrAmount)
        {
            var table = this.tableLayoutPanel;
            int index = 0;
            foreach(PopInfoTableRow row in table.Controls.OfType<PopInfoTableRow>())
            {
                
                if (index == 0)
                {
                    row.rowTextBox.Text = popSize.ToString();
                }
                if (index == 3)
                {
                    row.rowTextBox.Text = chrAmount.ToString();
                }
                index++;
            }

        }

        /// <summary>
        /// Removes the last row of the table
        /// </summary>
        public void DeleteTableRow()
        {
            var table = this.tableLayoutPanel;
            
            int rowIndex = table.RowStyles.Count;
            int rowIndexControls = table.Controls.Count;
            if (rowIndex > 1)
            {
                rowIndex--;
                rowIndexControls--;
                table.RowStyles.RemoveAt(rowIndex);
                table.Controls.RemoveAt(rowIndexControls);
            }


        }
        /// <summary>
        /// Removes rows according to the amount that it is  sent
        /// </summary>
        /// <param name="amountOfRows"></param>
        public void DeleteTableRow(int amountOfRows)
        {
            while (amountOfRows > 0)
            {
                DeleteTableRow();
                amountOfRows--;
            }
        }
        /// <summary>
        /// Inserts data into the selected table 
        /// </summary>
        /// <param name="tableData"></param>
        /// <param name="rowsToCopy"></param>
        public void InsertTableData(List<Dictionary<int, string>> tableData, int rowsToCopy, TableRowType type)
        {
            
            var table = this.tableLayoutPanel;
            int amountOfRowsToAdd = rowsToCopy;
            while (amountOfRowsToAdd > 0)
            {
                AddTableRow(type);
                amountOfRowsToAdd--;
            }

            //this is the row of the insertion , row at index 0 is the row of the header
            int currRow;
            //insert when the table just initialized
            if (table.Controls.Count<= rowsToCopy)
            {
                currRow = 1;
            }
            else
            {
                //insert when the table is already full
                currRow = (table.Controls.Count) - rowsToCopy;
            }

            //get the current data of the row to be copied
            foreach (Dictionary<int, string> dic in tableData)
            {
                //access the row in the table to place the data
                var tableRow = (InputDataTableRow)table.Controls[currRow];
                //first control is checkbox - thus we create offset
                int offestIndex = 1;
                foreach (KeyValuePair<int, string> entry in dic)
                {
                    tableRow.Controls[entry.Key + offestIndex].Text = entry.Value;
                }
                currRow++;
            }
            //Assign the data to the actual table rows
        }
        public void InsertTableData(Dictionary<int,string> newRowData,TableRowType type)
        {
            
            switch (type)
            {
                case TableRowType.InputDataRow:
                    var table = this.tableLayoutPanel;
                    int counter =0;
                    foreach (KeyValuePair<int,string> entry in newRowData)
                    {
                        var row = ((InputDataTableRow)table.Controls[table.Controls.Count-1]);
                        row.tableRow[counter] = entry.Value;
                        counter++;
                    }
                    break;
                
                default:
                break;
            }
        }
        public void CreateGeneticTable(List<string> modelParams, float rowSize, float colSize, int colAmount, int amountOfRows)
        {

            int rowIndex = 0;
            var table = this.tableLayoutPanel;
            table.Controls.Clear();
            table.RowStyles.Clear();
            table.ColumnCount = colAmount;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, colSize));
            var tableRowHeader = new GeneticTableHeader();
            tableRowHeader.InitHeaderNames(modelParams);
            tableRowHeader.Dock = DockStyle.Fill;
            tableRowHeader.BackColor = ColorConstants.tableHeaderColor;

            table.SetColumnSpan(tableRowHeader, table.ColumnCount);
            table.Controls.Add(tableRowHeader, 0, rowIndex);

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));
            rowIndex++;
            while (rowIndex < amountOfRows)
            {

                var tableRow = new GeneticTableRow();
                tableRow.Dock = DockStyle.Fill;



                if (rowIndex % 2 == 0)
                {
                    tableRow.BackColor = ColorConstants.tableBackgroundColor;
                    tableRow.BackColor = ColorConstants.tableBackgroundColor;
                    tableRow.setTextBoxBackgroundColor(ColorConstants.tableBackgroundColor);
                }
                else
                {
                    tableRow.BackColor = Color.White;
                    tableRow.BackColor = Color.White;
                    tableRow.setTextBoxBackgroundColor(Color.White);

                }
                tableRow.BorderStyle = BorderStyle.None;
                table.SetColumnSpan(tableRow, colAmount);
                table.Controls.Add(tableRow, 0, rowIndex);
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));



                rowIndex++;
            }
        }
        /// <summary>
        /// Generates a table according to the amount of params and teh sizes of the colums and rows
        /// </summary>
        /// <param name="modelParams"></param>
        /// <param name="rowSize"></param>
        /// <param name="colSize"></param>
        /// <param name="colAmount"></param>
        /// <param name="amountOfRows"></param>
        public void CreateInputDataTable(List<string> modelParams, float rowSize, float colSize, int colAmount, int amountOfRows)
        {

            int rowIndex = 0;
            var table = this.tableLayoutPanel;
            table.Controls.Clear();
            table.RowStyles.Clear();
            table.ColumnCount = colAmount;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, colSize));
            var tableRowHeader = new InputDataTableHeader();
            tableRowHeader.InitHeaderNames(modelParams);
            tableRowHeader.Dock = DockStyle.Fill;
            tableRowHeader.BackColor = ColorConstants.tableHeaderColor;

            table.SetColumnSpan(tableRowHeader, table.ColumnCount);
            table.Controls.Add(tableRowHeader, 0, rowIndex);

            table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));
            rowIndex++;
            while (rowIndex < amountOfRows)
            {

                var tableRow = new InputDataTableRow(rowIndex);
                tableRow.RowChecked += TableRow_RowChecked;
                tableRow.Dock = DockStyle.Fill;



                if (rowIndex % 2 == 0)
                {
                    tableRow.BackColor = ColorConstants.tableBackgroundColor;
                    tableRow.BackColor = ColorConstants.tableBackgroundColor;
                    tableRow.setTextBoxBackgroundColor(ColorConstants.tableBackgroundColor);
                }
                else
                {
                    tableRow.BackColor = Color.White;
                    tableRow.BackColor = Color.White;
                    tableRow.setTextBoxBackgroundColor(Color.White);

                }
                tableRow.BorderStyle = BorderStyle.None;
                table.SetColumnSpan(tableRow, colAmount);
                table.Controls.Add(tableRow, 0, rowIndex);
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));



                rowIndex++;
            }
        }
        /// <summary>
        /// Generates the table according to the params that are passed
        /// </summary>
        /// <param name="amountOftables"></param>
        /// <param name="modelParams"></param>
        /// <param name="rowSize"></param>
        /// <param name="colSize"></param>
        /// <param name="colAmount"></param>
        public void CreateTraitTable(int amountOftables, List<string> modelParams, float rowSize, float colSize, int colAmount)
        {

            for (int i = 0; i < amountOftables; i++)
            {
                int rowIndex = 0;
                var table = (TableLayoutPanel)this.panelTableContainer.Controls[i];
                table.Controls.Clear();
                table.RowStyles.Clear();
                table.ColumnCount = colAmount;
                table.RowCount = modelParams.Count + 1;

                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, colSize));
                Label placeHodler = new Label();
                placeHodler.Dock = DockStyle.Fill;
                placeHodler.Text = "QTL #" + (i+1);
                placeHodler.BackColor = ColorConstants.tableHeaderColor;
                table.SetColumnSpan(placeHodler, table.ColumnCount);
                table.Controls.Add(placeHodler, 0, rowIndex);

                table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));
                rowIndex++;
                foreach (string name in modelParams)
                {

                    TraitTableRow tableRow = new TraitTableRow();
                    tableRow.rowLabel.Text = name;
                    

                    tableRow.rowTextBox.Name = "tb" + name.Replace(" ", "");
                    tableRow.rowPanel.Dock = DockStyle.Fill;

                    tableRow.rowPanel.BackColor = Color.White;
                    tableRow.rowTextBox.BackColor = Color.White;

                    if (rowIndex % 2 == 0)
                    {
                        tableRow.rowPanel.BackColor = ColorConstants.tableBackgroundColor;
                        tableRow.rowTextBox.BackColor = ColorConstants.tableBackgroundColor;
                    }
                    tableRow.rowTextBox.BorderStyle = BorderStyle.None;

                    table.SetColumnSpan(tableRow, 2);
                    table.Controls.Add(tableRow, 0, rowIndex);
                    table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));


                    rowIndex++;
                }
                table.Visible = true;
            }
        }
        
        /// <summary>
        /// Sets up the tables with default data
        /// </summary>
        /// <param name="amountOftables"></param>
        /// <param name="defaultValues"></param>
        public void InitTraitTableDefaultData(int amountOftables,List<string> defaultValues)
        {
            for(int i = 0; i < amountOftables; i++)
            {
                var table = (TableLayoutPanel)this.panelTableContainer.Controls[i];
                int rowIndex = 0;
                foreach(TraitTableRow row in table.Controls.OfType<TraitTableRow>())
                {
                    row.rowTextBox.Text = defaultValues[rowIndex];
                    rowIndex = (rowIndex + 1) % 7;
                }

            }
        }



        /// <summary>
        /// Calculates the amount of rows to copy
        /// </summary>
        /// <returns></returns>
        public int GetCopiedRows()
        {
            int rowsToCopy = 0;

            foreach (KeyValuePair<int, bool> entry in selectedRows)
            {
                if (entry.Value == true)
                {
                    rowsToCopy++;
                }
            }

            return rowsToCopy;
        }
        /// <summary>
        /// Pastes the copied rows to the end of the table 
        /// </summary>
        /// <param name="rowsToCopy"></param>
        public void PasteTableRows(int rowsToCopy)
        {
            var table = this.tableLayoutPanel;
            List<Dictionary<int, string>> tableRowData = new List<Dictionary<int, string>>();
            //copy the rows data
            foreach (KeyValuePair<int, bool> entry in selectedRows)
            {
                //copy the row 
                if (entry.Value == true)
                {
                    //we get the index of the row 
                    int rowIndex = entry.Key;
                    Dictionary<int, string> row = new Dictionary<int, string>();
                    InputDataTableRow rowToCopy = (InputDataTableRow)table.Controls[rowIndex];
                    int i = 0;
                    foreach (TextBox textBox in rowToCopy.Controls.OfType<TextBox>())
                    {
                        row.Add(i, textBox.Text);
                        i++;
                    }
                    tableRowData.Add(row);
                }
            }

            //only if we have data to send we insert the table data
            if (tableRowData.Count > 0)
            {
                InsertTableData(tableRowData, rowsToCopy,TableRowType.InputDataRow);
            }


        }
        /// <summary>
        /// Generates a table for view only and it is identical from the input data table
        /// </summary>
        public void GenerateTableForView(List<string> modelParams, float rowSize, float colSize, int colAmount, int amountOfRows)
        {
            //Creates the table
            int amountOfRowsWithHeader = amountOfRows + 1;
            CreateInputDataTable(modelParams, rowSize, colSize, colAmount, amountOfRowsWithHeader);
            //iterate over the rows and disable the checkbox
            var table = this.tableLayoutPanel;
            foreach (InputDataTableRow row in table.Controls.OfType<InputDataTableRow>())
            {
                //Disable all the controls to editing
                foreach (Control control in row.Controls)
                {
                    control.Enabled = false;
                }

            }


        }
        public void PopulateViewTable(List<Dictionary<int, string>> data)
        {
            if (data.Count > 0 && data != null)
            {
                var table = this.tableLayoutPanel;
                int rowIndex = 0;
                foreach (InputDataTableRow row in table.Controls.OfType<InputDataTableRow>())
                {
                    int col = 0;
                    var dic = data[rowIndex];
                    foreach (TextBox tb in row.Controls.OfType<TextBox>())
                    {
                        tb.Text = dic[col];
                        col++;
                    }
                    rowIndex++;
                }
            }
        }

    }
}
