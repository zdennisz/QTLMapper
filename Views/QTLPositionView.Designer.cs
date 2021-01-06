
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QTLPositionView));
            this.buttonPanelContainer = new System.Windows.Forms.Panel();
            this.labelColAmount = new System.Windows.Forms.Label();
            this.numericUpDownColAmount = new System.Windows.Forms.NumericUpDown();
            this.buttonPreformLogOnData = new QTLProject.Utils.RoundedButtonToolBar();
            this.buttonSaveGraph = new QTLProject.Utils.RoundedButtonToolBar();
            this.buttonRemoveOutliers = new QTLProject.Utils.RoundedButtonToolBar();
            this.labelChartType = new System.Windows.Forms.Label();
            this.selectionCombobox = new System.Windows.Forms.ComboBox();
            this.notifyIconQTLPosition = new System.Windows.Forms.NotifyIcon(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanelContainer
            // 
            this.buttonPanelContainer.Controls.Add(this.labelColAmount);
            this.buttonPanelContainer.Controls.Add(this.numericUpDownColAmount);
            this.buttonPanelContainer.Controls.Add(this.buttonPreformLogOnData);
            this.buttonPanelContainer.Controls.Add(this.buttonSaveGraph);
            this.buttonPanelContainer.Controls.Add(this.buttonRemoveOutliers);
            this.buttonPanelContainer.Controls.Add(this.labelChartType);
            this.buttonPanelContainer.Controls.Add(this.selectionCombobox);
            this.buttonPanelContainer.Location = new System.Drawing.Point(3, 3);
            this.buttonPanelContainer.Name = "buttonPanelContainer";
            this.buttonPanelContainer.Size = new System.Drawing.Size(698, 100);
            this.buttonPanelContainer.TabIndex = 0;
            // 
            // labelColAmount
            // 
            this.labelColAmount.AutoSize = true;
            this.labelColAmount.Font = new System.Drawing.Font("Arial", 10F);
            this.labelColAmount.Location = new System.Drawing.Point(296, 54);
            this.labelColAmount.Name = "labelColAmount";
            this.labelColAmount.Size = new System.Drawing.Size(170, 16);
            this.labelColAmount.TabIndex = 19;
            this.labelColAmount.Text = "Amount Of Chromosomes";
            // 
            // numericUpDownColAmount
            // 
            this.numericUpDownColAmount.Location = new System.Drawing.Point(472, 51);
            this.numericUpDownColAmount.Name = "numericUpDownColAmount";
            this.numericUpDownColAmount.Size = new System.Drawing.Size(128, 20);
            this.numericUpDownColAmount.TabIndex = 18;
            this.numericUpDownColAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownColAmount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // buttonPreformLogOnData
            // 
            this.buttonPreformLogOnData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPreformLogOnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPreformLogOnData.Font = new System.Drawing.Font("Arial", 10F);
            this.buttonPreformLogOnData.Location = new System.Drawing.Point(427, 10);
            this.buttonPreformLogOnData.Name = "buttonPreformLogOnData";
            this.buttonPreformLogOnData.Size = new System.Drawing.Size(130, 32);
            this.buttonPreformLogOnData.TabIndex = 17;
            this.buttonPreformLogOnData.Text = "-Log on Data";
            this.buttonPreformLogOnData.UseVisualStyleBackColor = true;
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveGraph.Font = new System.Drawing.Font("Arial", 10F);
            this.buttonSaveGraph.Location = new System.Drawing.Point(563, 10);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(130, 32);
            this.buttonSaveGraph.TabIndex = 16;
            this.buttonSaveGraph.Text = "Save Graph";
            this.buttonSaveGraph.UseVisualStyleBackColor = true;
            this.buttonSaveGraph.Click += new System.EventHandler(this.buttonSaveGraph_Click);
            // 
            // buttonRemoveOutliers
            // 
            this.buttonRemoveOutliers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoveOutliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveOutliers.Font = new System.Drawing.Font("Arial", 10F);
            this.buttonRemoveOutliers.Location = new System.Drawing.Point(291, 10);
            this.buttonRemoveOutliers.Name = "buttonRemoveOutliers";
            this.buttonRemoveOutliers.Size = new System.Drawing.Size(130, 32);
            this.buttonRemoveOutliers.TabIndex = 15;
            this.buttonRemoveOutliers.Text = "Remove Outliers";
            this.buttonRemoveOutliers.UseVisualStyleBackColor = true;
            this.buttonRemoveOutliers.Click += new System.EventHandler(this.buttonRemoveOutliers_Click);
            // 
            // labelChartType
            // 
            this.labelChartType.AutoSize = true;
            this.labelChartType.Font = new System.Drawing.Font("Arial", 10F);
            this.labelChartType.Location = new System.Drawing.Point(20, 23);
            this.labelChartType.Name = "labelChartType";
            this.labelChartType.Size = new System.Drawing.Size(46, 16);
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
            // notifyIconQTLPosition
            // 
            this.notifyIconQTLPosition.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconQTLPosition.Icon")));
            this.notifyIconQTLPosition.Text = "notifyIcon1";
            this.notifyIconQTLPosition.Visible = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 109);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(698, 449);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // QTLPositionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonPanelContainer);
            this.Name = "QTLPositionView";
            this.Size = new System.Drawing.Size(704, 561);
            this.buttonPanelContainer.ResumeLayout(false);
            this.buttonPanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel buttonPanelContainer;
        private System.Windows.Forms.Label labelChartType;
        private System.Windows.Forms.ComboBox selectionCombobox;
        private System.Windows.Forms.Label labelColAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownColAmount;
        private Utils.RoundedButtonToolBar buttonPreformLogOnData;
        private Utils.RoundedButtonToolBar buttonSaveGraph;
        private Utils.RoundedButtonToolBar buttonRemoveOutliers;
        private System.Windows.Forms.NotifyIcon notifyIconQTLPosition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
