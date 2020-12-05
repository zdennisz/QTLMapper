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

namespace QTLProject.Utils
{
    public class TableGenerator
    {
        public TableLayoutPanel tableLayoutPanel;
        public Panel panelTableContainer;
        SortedDictionary<int, bool> selectedRows = new SortedDictionary<int, bool>();

        public TableGenerator(TableLayoutPanel panel)
        {
            this.tableLayoutPanel = panel;


        }
        public TableGenerator(Panel panel1)
        {
            this.panelTableContainer = panel1;

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
        public void AddTableRow()
        {
            var table = this.tableLayoutPanel;
            int colAmount = table.ColumnCount;
            int rowIndex = table.RowStyles.Count;
            var tableRow = new InputDataTableRow(rowIndex);
            tableRow.RowChecked += TableRow_RowChecked;

            tableRow.Dock = DockStyle.Fill;

            if (rowIndex % 2 == 0)
            {
                tableRow.BackColor = Color.LightGray;
                tableRow.BackColor = Color.LightGray;
                tableRow.setTextBoxBackgroundColor(Color.LightGray);
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

        private void TableRow_RowChecked(object sender, EventArgs e)
        {
            InputDataTableRow row = sender as InputDataTableRow;
            bool isChecked = ((CheckBox)(row.Controls[0])).Checked;
            selectedRows[row.rowIndex] = isChecked;
        }


        /// <summary>
        /// Removes the last row of the table
        /// </summary>
        public void DeleteTableRow()
        {
            var table = this.tableLayoutPanel;
            int rowIndex = table.RowStyles.Count;
            if (rowIndex > 1)
            {
                rowIndex--;
                table.RowStyles.RemoveAt(rowIndex);
                table.Controls.RemoveAt(rowIndex);
            }


        }
        /// <summary>
        /// Inserts data into the selected table 
        /// </summary>
        /// <param name="tableData"></param>
        /// <param name="rowsToCopy"></param>
        public void InsertTableData(List<Dictionary<int, string>> tableData, int rowsToCopy)
        {
            //TODO check how many rows if less then what we have then generate the missing rows
            var table = this.tableLayoutPanel;
            int amountOfRowsToAdd = rowsToCopy;
            while (amountOfRowsToAdd > 0)
            {
                AddTableRow();
                amountOfRowsToAdd--;
            }

            //this is the row of the insertion - we calcualte it by the general amount of rows and the amount of data to insert
            //we remove additional one to account the table header which is a row in the table
            int currRow = (table.Controls.Count) - tableData.Count;

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
                    tableRow.BackColor = Color.LightGray;
                    tableRow.BackColor = Color.LightGray;
                    tableRow.setTextBoxBackgroundColor(Color.LightGray);
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
                    tableRow.BackColor = Color.LightGray;
                    tableRow.BackColor = Color.LightGray;
                    tableRow.setTextBoxBackgroundColor(Color.LightGray);
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
                placeHodler.BackColor = ColorConstants.tableHeaderColor;
                table.SetColumnSpan(placeHodler, table.ColumnCount);
                table.Controls.Add(placeHodler, 0, rowIndex);

                table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowSize));
                rowIndex++;
                foreach (string name in modelParams)
                {

                    TraitTableRow tableRow = new TraitTableRow();
                    tableRow.rowLabel.Text = name;
                    // tableRow.Size = new Size(100, 25);

                    tableRow.rowTextBox.Name = "tb" + name.Replace(" ", "");
                    tableRow.rowPanel.Dock = DockStyle.Fill;

                    tableRow.rowPanel.BackColor = Color.White;
                    tableRow.rowTextBox.BackColor = Color.White;

                    if (rowIndex % 2 == 0)
                    {
                        tableRow.rowPanel.BackColor = Color.LightGray;
                        tableRow.rowTextBox.BackColor = Color.LightGray;
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
                InsertTableData(tableRowData, rowsToCopy);
            }


        }
        /// <summary>
        /// Generates a table for view only and it is identical from the input data table
        /// </summary>
        public void GenerateTableForView(List<string> modelParams, float rowSize, float colSize, int colAmount, int amountOfRows)
        {
            //Creates the table
            CreateInputDataTable(modelParams, rowSize, colSize, colAmount, amountOfRows);
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
                    int col = 1;
                    var dic = data[rowIndex];
                    foreach (TextBox tb in row.Controls.OfType<TextBox>())
                    {
                        string ouVal = null;
                        dic.TryGetValue(col, out ouVal);
                        tb.Text = ouVal;
                        col++;
                    }
                    rowIndex++;
                }
            }
        }

    }
}
