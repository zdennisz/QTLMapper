
namespace QTLProject.Views
{
    partial class QTLPositionView
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
            this.labelColAmount = new System.Windows.Forms.Label();
            this.numericUpDownColAmount = new System.Windows.Forms.NumericUpDown();
            this.buttonPreformLogOnData = new QTLProject.Utils.RoundedButtonToolBar();
            this.buttonSaveGraph = new QTLProject.Utils.RoundedButtonToolBar();
            this.buttonRemoveOutliers = new QTLProject.Utils.RoundedButtonToolBar();
            this.labelChartType = new System.Windows.Forms.Label();
            this.selectionCombobox = new System.Windows.Forms.ComboBox();
            this.cartesianChartsContainer = new System.Windows.Forms.Panel();
            this.cartesianChart3 = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColAmount)).BeginInit();
            this.cartesianChartsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.cartesianChartsContainer);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(704, 561);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelColAmount);
            this.panel1.Controls.Add(this.numericUpDownColAmount);
            this.panel1.Controls.Add(this.buttonPreformLogOnData);
            this.panel1.Controls.Add(this.buttonSaveGraph);
            this.panel1.Controls.Add(this.buttonRemoveOutliers);
            this.panel1.Controls.Add(this.labelChartType);
            this.panel1.Controls.Add(this.selectionCombobox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 100);
            this.panel1.TabIndex = 0;
            // 
            // labelColAmount
            // 
            this.labelColAmount.AutoSize = true;
            this.labelColAmount.Location = new System.Drawing.Point(281, 59);
            this.labelColAmount.Name = "labelColAmount";
            this.labelColAmount.Size = new System.Drawing.Size(100, 13);
            this.labelColAmount.TabIndex = 19;
            this.labelColAmount.Text = "Amount Of Columns";
            // 
            // numericUpDownColAmount
            // 
            this.numericUpDownColAmount.Location = new System.Drawing.Point(400, 55);
            this.numericUpDownColAmount.Name = "numericUpDownColAmount";
            this.numericUpDownColAmount.Size = new System.Drawing.Size(128, 20);
            this.numericUpDownColAmount.TabIndex = 18;
            this.numericUpDownColAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownColAmount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // buttonPreformLogOnData
            // 
            this.buttonPreformLogOnData.Location = new System.Drawing.Point(534, 26);
            this.buttonPreformLogOnData.Name = "buttonPreformLogOnData";
            this.buttonPreformLogOnData.Size = new System.Drawing.Size(128, 23);
            this.buttonPreformLogOnData.TabIndex = 17;
            this.buttonPreformLogOnData.Text = "-Log on Data";
            this.buttonPreformLogOnData.UseVisualStyleBackColor = true;
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Location = new System.Drawing.Point(400, 26);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(128, 23);
            this.buttonSaveGraph.TabIndex = 16;
            this.buttonSaveGraph.Text = "Save Graph";
            this.buttonSaveGraph.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveOutliers
            // 
            this.buttonRemoveOutliers.Location = new System.Drawing.Point(266, 26);
            this.buttonRemoveOutliers.Name = "buttonRemoveOutliers";
            this.buttonRemoveOutliers.Size = new System.Drawing.Size(128, 23);
            this.buttonRemoveOutliers.TabIndex = 15;
            this.buttonRemoveOutliers.Text = "Remove Outliers";
            this.buttonRemoveOutliers.UseVisualStyleBackColor = true;
            // 
            // labelChartType
            // 
            this.labelChartType.AutoSize = true;
            this.labelChartType.Location = new System.Drawing.Point(20, 26);
            this.labelChartType.Name = "labelChartType";
            this.labelChartType.Size = new System.Drawing.Size(35, 13);
            this.labelChartType.TabIndex = 14;
            this.labelChartType.Text = "label2";
            // 
            // selectionCombobox
            // 
            this.selectionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionCombobox.FormattingEnabled = true;
            this.selectionCombobox.Location = new System.Drawing.Point(23, 42);
            this.selectionCombobox.Name = "selectionCombobox";
            this.selectionCombobox.Size = new System.Drawing.Size(121, 21);
            this.selectionCombobox.TabIndex = 13;
            // 
            // cartesianChartsContainer
            // 
            this.cartesianChartsContainer.Controls.Add(this.cartesianChart3);
            this.cartesianChartsContainer.Controls.Add(this.cartesianChart2);
            this.cartesianChartsContainer.Controls.Add(this.cartesianChart1);
            this.cartesianChartsContainer.Location = new System.Drawing.Point(3, 109);
            this.cartesianChartsContainer.Name = "cartesianChartsContainer";
            this.cartesianChartsContainer.Size = new System.Drawing.Size(698, 427);
            this.cartesianChartsContainer.TabIndex = 1;
            // 
            // cartesianChart3
            // 
            this.cartesianChart3.Location = new System.Drawing.Point(3, 296);
            this.cartesianChart3.Name = "cartesianChart3";
            this.cartesianChart3.Size = new System.Drawing.Size(692, 128);
            this.cartesianChart3.TabIndex = 2;
            this.cartesianChart3.Text = "cartesianChart3";
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Location = new System.Drawing.Point(3, 154);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(692, 136);
            this.cartesianChart2.TabIndex = 1;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(3, 3);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(692, 145);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // QTLPositionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "QTLPositionView";
            this.Size = new System.Drawing.Size(704, 561);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColAmount)).EndInit();
            this.cartesianChartsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel cartesianChartsContainer;
        private System.Windows.Forms.Label labelColAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownColAmount;
        private Utils.RoundedButtonToolBar buttonPreformLogOnData;
        private Utils.RoundedButtonToolBar buttonSaveGraph;
        private Utils.RoundedButtonToolBar buttonRemoveOutliers;
        private System.Windows.Forms.Label labelChartType;
        private System.Windows.Forms.ComboBox selectionCombobox;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart cartesianChart3;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
    }
}
