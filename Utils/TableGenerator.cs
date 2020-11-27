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
        TableLayoutPanel tableLayoutPanel;
        Panel panelTableContainer;
 
        public TableGenerator(TableLayoutPanel panel)
        {
            this.tableLayoutPanel = panel;
           

        }
        public TableGenerator(Panel panel1)
        {
            this.panelTableContainer = panel1;
            
        }

        


        public void CreateGeneticTable(List<string> modelParams, float rowSize, float colSize, int colAmount, int amountOfRows)
        {
           
            int rowIndex = 0;
            var table = this.tableLayoutPanel;
            table.Controls.Clear();
            table.RowStyles.Clear();
            table.ColumnCount = colAmount;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, colSize));    
            var  tableRowHeader = new GeneticTableHeader();
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
