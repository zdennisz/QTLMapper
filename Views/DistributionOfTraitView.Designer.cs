
namespace QTLProject.Views
{
    partial class DistributionOfTraitView
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColAmount)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.flowLayoutPanel1.TabIndex = 6;
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
            this.panel1.Size = new System.Drawing.Size(698, 188);
            this.panel1.TabIndex = 0;
            // 
            // labelColAmount
            // 
            this.labelColAmount.AutoSize = true;
            this.labelColAmount.Location = new System.Drawing.Point(284, 54);
            this.labelColAmount.Name = "labelColAmount";
            this.labelColAmount.Size = new System.Drawing.Size(100, 13);
            this.labelColAmount.TabIndex = 12;
            this.labelColAmount.Text = "Amount Of Columns";
            // 
            // numericUpDownColAmount
            // 
            this.numericUpDownColAmount.Location = new System.Drawing.Point(403, 50);
            this.numericUpDownColAmount.Name = "numericUpDownColAmount";
            this.numericUpDownColAmount.Size = new System.Drawing.Size(128, 20);
            this.numericUpDownColAmount.TabIndex = 11;
            this.numericUpDownColAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownColAmount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // buttonPreformLogOnData
            // 
            this.buttonPreformLogOnData.Location = new System.Drawing.Point(537, 21);
            this.buttonPreformLogOnData.Name = "buttonPreformLogOnData";
            this.buttonPreformLogOnData.Size = new System.Drawing.Size(128, 23);
            this.buttonPreformLogOnData.TabIndex = 10;
            this.buttonPreformLogOnData.Text = "-Log on Data";
            this.buttonPreformLogOnData.UseVisualStyleBackColor = true;
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Location = new System.Drawing.Point(403, 21);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(128, 23);
            this.buttonSaveGraph.TabIndex = 9;
            this.buttonSaveGraph.Text = "Save Graph";
            this.buttonSaveGraph.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveOutliers
            // 
            this.buttonRemoveOutliers.Location = new System.Drawing.Point(269, 21);
            this.buttonRemoveOutliers.Name = "buttonRemoveOutliers";
            this.buttonRemoveOutliers.Size = new System.Drawing.Size(128, 23);
            this.buttonRemoveOutliers.TabIndex = 8;
            this.buttonRemoveOutliers.Text = "Remove Outliers";
            this.buttonRemoveOutliers.UseVisualStyleBackColor = true;
            // 
            // labelChartType
            // 
            this.labelChartType.AutoSize = true;
            this.labelChartType.Location = new System.Drawing.Point(23, 21);
            this.labelChartType.Name = "labelChartType";
            this.labelChartType.Size = new System.Drawing.Size(35, 13);
            this.labelChartType.TabIndex = 7;
            this.labelChartType.Text = "label2";
            // 
            // selectionCombobox
            // 
            this.selectionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionCombobox.FormattingEnabled = true;
            this.selectionCombobox.Location = new System.Drawing.Point(26, 37);
            this.selectionCombobox.Name = "selectionCombobox";
            this.selectionCombobox.Size = new System.Drawing.Size(121, 21);
            this.selectionCombobox.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cartesianChart1);
            this.panel2.Location = new System.Drawing.Point(3, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 210);
            this.panel2.TabIndex = 1;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 0);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(698, 210);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // DistributionOfTraitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DistributionOfTraitView";
            this.Size = new System.Drawing.Size(704, 561);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColAmount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelChartType;
        private System.Windows.Forms.ComboBox selectionCombobox;
        private System.Windows.Forms.Panel panel2;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Label labelColAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownColAmount;
        private Utils.RoundedButtonToolBar buttonPreformLogOnData;
        private Utils.RoundedButtonToolBar buttonSaveGraph;
        private Utils.RoundedButtonToolBar buttonRemoveOutliers;
    }
}
