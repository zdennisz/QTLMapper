
namespace QTLProject.Views
{
    partial class SingleMarkerTestView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectionCombobox = new System.Windows.Forms.ComboBox();
            this.labelColAmount = new System.Windows.Forms.Label();
            this.numericUpDownColAmount = new System.Windows.Forms.NumericUpDown();
            this.labelChartType = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pvalChart = new LiveCharts.WinForms.CartesianChart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.markerQualityChart = new LiveCharts.WinForms.CartesianChart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.segregationChart = new LiveCharts.WinForms.CartesianChart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chiChart = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart7 = new LiveCharts.WinForms.CartesianChart();
            this.buttonPreformLogOnData = new QTLProject.Utils.RoundedButtonToolBar();
            this.buttonSaveGraph = new QTLProject.Utils.RoundedButtonToolBar();
            this.buttonRemoveOutliers = new QTLProject.Utils.RoundedButtonToolBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColAmount)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(704, 561);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectionCombobox);
            this.panel1.Controls.Add(this.labelColAmount);
            this.panel1.Controls.Add(this.numericUpDownColAmount);
            this.panel1.Controls.Add(this.buttonPreformLogOnData);
            this.panel1.Controls.Add(this.buttonSaveGraph);
            this.panel1.Controls.Add(this.buttonRemoveOutliers);
            this.panel1.Controls.Add(this.labelChartType);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 100);
            this.panel1.TabIndex = 0;
            // 
            // selectionCombobox
            // 
            this.selectionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionCombobox.FormattingEnabled = true;
            this.selectionCombobox.Location = new System.Drawing.Point(20, 33);
            this.selectionCombobox.Name = "selectionCombobox";
            this.selectionCombobox.Size = new System.Drawing.Size(121, 21);
            this.selectionCombobox.TabIndex = 18;
            // 
            // labelColAmount
            // 
            this.labelColAmount.AutoSize = true;
            this.labelColAmount.Location = new System.Drawing.Point(304, 50);
            this.labelColAmount.Name = "labelColAmount";
            this.labelColAmount.Size = new System.Drawing.Size(100, 13);
            this.labelColAmount.TabIndex = 17;
            this.labelColAmount.Text = "Amount Of Columns";
            // 
            // numericUpDownColAmount
            // 
            this.numericUpDownColAmount.Location = new System.Drawing.Point(423, 46);
            this.numericUpDownColAmount.Name = "numericUpDownColAmount";
            this.numericUpDownColAmount.Size = new System.Drawing.Size(128, 20);
            this.numericUpDownColAmount.TabIndex = 16;
            this.numericUpDownColAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownColAmount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelChartType
            // 
            this.labelChartType.AutoSize = true;
            this.labelChartType.Location = new System.Drawing.Point(17, 17);
            this.labelChartType.Name = "labelChartType";
            this.labelChartType.Size = new System.Drawing.Size(35, 13);
            this.labelChartType.TabIndex = 8;
            this.labelChartType.Text = "label2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(3, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 342);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(703, 342);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pvalChart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(695, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "P Value";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pvalChart
            // 
            this.pvalChart.Location = new System.Drawing.Point(6, 35);
            this.pvalChart.Name = "pvalChart";
            this.pvalChart.Size = new System.Drawing.Size(686, 157);
            this.pvalChart.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.markerQualityChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(695, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Marker Quality";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // markerQualityChart
            // 
            this.markerQualityChart.Location = new System.Drawing.Point(6, 100);
            this.markerQualityChart.Name = "markerQualityChart";
            this.markerQualityChart.Size = new System.Drawing.Size(683, 210);
            this.markerQualityChart.TabIndex = 0;
            this.markerQualityChart.Text = "cartesianChart3";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.segregationChart);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(695, 316);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Segregation ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // segregationChart
            // 
            this.segregationChart.Location = new System.Drawing.Point(6, 155);
            this.segregationChart.Name = "segregationChart";
            this.segregationChart.Size = new System.Drawing.Size(686, 155);
            this.segregationChart.TabIndex = 2;
            this.segregationChart.Text = "cartesianChart5";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chiChart);
            this.tabPage4.Controls.Add(this.cartesianChart7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(695, 316);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Chi^2";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chiChart
            // 
            this.chiChart.Location = new System.Drawing.Point(10, 6);
            this.chiChart.Name = "chiChart";
            this.chiChart.Size = new System.Drawing.Size(675, 150);
            this.chiChart.TabIndex = 3;
            this.chiChart.Text = "cartesianChart6";
            // 
            // cartesianChart7
            // 
            this.cartesianChart7.Location = new System.Drawing.Point(12, 162);
            this.cartesianChart7.Name = "cartesianChart7";
            this.cartesianChart7.Size = new System.Drawing.Size(673, 148);
            this.cartesianChart7.TabIndex = 2;
            this.cartesianChart7.Text = "cartesianChart7";
            // 
            // buttonPreformLogOnData
            // 
            this.buttonPreformLogOnData.Location = new System.Drawing.Point(557, 17);
            this.buttonPreformLogOnData.Name = "buttonPreformLogOnData";
            this.buttonPreformLogOnData.Size = new System.Drawing.Size(128, 23);
            this.buttonPreformLogOnData.TabIndex = 15;
            this.buttonPreformLogOnData.Text = "-Log on Data";
            this.buttonPreformLogOnData.UseVisualStyleBackColor = true;
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Location = new System.Drawing.Point(423, 17);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(128, 23);
            this.buttonSaveGraph.TabIndex = 14;
            this.buttonSaveGraph.Text = "Save Graph";
            this.buttonSaveGraph.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveOutliers
            // 
            this.buttonRemoveOutliers.Location = new System.Drawing.Point(289, 17);
            this.buttonRemoveOutliers.Name = "buttonRemoveOutliers";
            this.buttonRemoveOutliers.Size = new System.Drawing.Size(128, 23);
            this.buttonRemoveOutliers.TabIndex = 13;
            this.buttonRemoveOutliers.Text = "Remove Outliers";
            this.buttonRemoveOutliers.UseVisualStyleBackColor = true;
            // 
            // SingleMarkerTestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "SingleMarkerTestView";
            this.Size = new System.Drawing.Size(704, 561);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColAmount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label labelChartType;
        private System.Windows.Forms.Label labelColAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownColAmount;
        private Utils.RoundedButtonToolBar buttonPreformLogOnData;
        private Utils.RoundedButtonToolBar buttonSaveGraph;
        private Utils.RoundedButtonToolBar buttonRemoveOutliers;
        private LiveCharts.WinForms.CartesianChart pvalChart;
        private System.Windows.Forms.ComboBox selectionCombobox;
        private LiveCharts.WinForms.CartesianChart markerQualityChart;
        private LiveCharts.WinForms.CartesianChart segregationChart;
        private LiveCharts.WinForms.CartesianChart chiChart;
        private LiveCharts.WinForms.CartesianChart cartesianChart7;
    }
}
