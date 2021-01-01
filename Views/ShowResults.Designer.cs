namespace QTLProject
{
    partial class ShowResults
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowResults));
            this.selectionCombobox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelChartType = new System.Windows.Forms.Label();
            this.histogramPanel = new System.Windows.Forms.Panel();
            this.cartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.calculationsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.histogramPanel.SuspendLayout();
            this.calculationsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectionCombobox
            // 
            this.selectionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionCombobox.FormattingEnabled = true;
            this.selectionCombobox.Location = new System.Drawing.Point(21, 22);
            this.selectionCombobox.Name = "selectionCombobox";
            this.selectionCombobox.Size = new System.Drawing.Size(121, 21);
            this.selectionCombobox.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.histogramPanel);
            this.flowLayoutPanel1.Controls.Add(this.calculationsPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(704, 561);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelChartType);
            this.panel1.Controls.Add(this.selectionCombobox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 112);
            this.panel1.TabIndex = 1;
            // 
            // labelChartType
            // 
            this.labelChartType.AutoSize = true;
            this.labelChartType.Location = new System.Drawing.Point(18, 6);
            this.labelChartType.Name = "labelChartType";
            this.labelChartType.Size = new System.Drawing.Size(35, 13);
            this.labelChartType.TabIndex = 4;
            this.labelChartType.Text = "label2";
            // 
            // histogramPanel
            // 
            this.histogramPanel.Controls.Add(this.cartesianChart);
            this.histogramPanel.Location = new System.Drawing.Point(0, 118);
            this.histogramPanel.Margin = new System.Windows.Forms.Padding(0);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(644, 177);
            this.histogramPanel.TabIndex = 5;
            // 
            // cartesianChart
            // 
            this.cartesianChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart.Location = new System.Drawing.Point(0, 0);
            this.cartesianChart.Margin = new System.Windows.Forms.Padding(0);
            this.cartesianChart.Name = "cartesianChart";
            this.cartesianChart.Size = new System.Drawing.Size(644, 177);
            this.cartesianChart.TabIndex = 0;
            this.cartesianChart.Text = "cartesianChart2";
            // 
            // calculationsPanel
            // 
            this.calculationsPanel.Controls.Add(this.label1);
            this.calculationsPanel.Location = new System.Drawing.Point(3, 298);
            this.calculationsPanel.Name = "calculationsPanel";
            this.calculationsPanel.Size = new System.Drawing.Size(640, 143);
            this.calculationsPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculations Panel";
            // 
            // ShowResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 561);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowResults";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.histogramPanel.ResumeLayout(false);
            this.calculationsPanel.ResumeLayout(false);
            this.calculationsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox selectionCombobox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel calculationsPanel;
        private System.Windows.Forms.Panel histogramPanel;
        private LiveCharts.WinForms.CartesianChart cartesianChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelChartType;
    }
}