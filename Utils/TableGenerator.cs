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
            var tableRow = new InputDataTableRow();
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

        public void InsertTableData(List<Dictionary<int, string>> tableData)
        {
            //TODO check how many rows if less then what we have then generate the missing rows
            var table = this.tableLayoutPanel;
            if (tableData.Count > table.Controls.Count - 1)
            {
                int amountOfRowsToAdd = tableData.Count - (table.Controls.Count - 1);
                while (amountOfRowsToAdd > 0)
                {
                    AddTableRow();
                    amountOfRowsToAdd--;
                }
            }

            int currRow=1;
       
            foreach(Dictionary<int,string>  dic in tableData)
            {
                var tableRow = (InputDataTableRow)table.Controls[currRow];
                foreach (KeyValuePair<int, string> entry in dic)
                {
                    tableRow.Controls[entry.Key].Text = entry.Value;
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

                var tableRow = new InputDataTableRow();
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
    }
}
