namespace QTLProject
{
    partial class ViewResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewResults));
            this.btnBack = new System.Windows.Forms.Button();
            this.displayGraphBtn = new System.Windows.Forms.RadioButton();
            this.inDepthReportBtn = new System.Windows.Forms.RadioButton();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtOpenFolder = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShowResutls = new System.Windows.Forms.Button();
            this.comboBoxFuncs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(538, 564);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // displayGraphBtn
            // 
            this.displayGraphBtn.AutoSize = true;
            this.displayGraphBtn.Location = new System.Drawing.Point(216, 72);
            this.displayGraphBtn.Name = "displayGraphBtn";
            this.displayGraphBtn.Size = new System.Drawing.Size(91, 17);
            this.displayGraphBtn.TabIndex = 5;
            this.displayGraphBtn.TabStop = true;
            this.displayGraphBtn.Text = "Display Graph";
            this.displayGraphBtn.UseVisualStyleBackColor = true;
            // 
            // inDepthReportBtn
            // 
            this.inDepthReportBtn.AutoSize = true;
            this.inDepthReportBtn.Location = new System.Drawing.Point(6, 11);
            this.inDepthReportBtn.Name = "inDepthReportBtn";
            this.inDepthReportBtn.Size = new System.Drawing.Size(101, 17);
            this.inDepthReportBtn.TabIndex = 6;
            this.inDepthReportBtn.Text = "In Depth Report";
            this.inDepthReportBtn.UseVisualStyleBackColor = true;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFolder.Image")));
            this.btnOpenFolder.Location = new System.Drawing.Point(365, 13);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(43, 43);
            this.btnOpenFolder.TabIndex = 7;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            // 
            // txtOpenFolder
            // 
            this.txtOpenFolder.Location = new System.Drawing.Point(12, 25);
            this.txtOpenFolder.Name = "txtOpenFolder";
            this.txtOpenFolder.Size = new System.Drawing.Size(336, 20);
            this.txtOpenFolder.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(515, 234);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // btnShowResutls
            // 
            this.btnShowResutls.Location = new System.Drawing.Point(619, 564);
            this.btnShowResutls.Name = "btnShowResutls";
            this.btnShowResutls.Size = new System.Drawing.Size(101, 23);
            this.btnShowResutls.TabIndex = 18;
            this.btnShowResutls.Text = "Show Results";
            this.btnShowResutls.UseVisualStyleBackColor = true;
            // 
            // comboBoxFuncs
            // 
            this.comboBoxFuncs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFuncs.FormattingEnabled = true;
            this.comboBoxFuncs.Items.AddRange(new object[] {
            "Distribution of Trait",
            "Single Marker Tests",
            "QTL Position",
            "QTLs Effect",
            "Trait Distribution for QTL alleles",
            "Model Comparison",
            "Power"});
            this.comboBoxFuncs.Location = new System.Drawing.Point(12, 86);
            this.comboBoxFuncs.Name = "comboBoxFuncs";
            this.comboBoxFuncs.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFuncs.TabIndex = 19;
            this.comboBoxFuncs.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFuncs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "View";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Selected:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(67, 140);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(13, 13);
            this.lblValue.TabIndex = 22;
            this.lblValue.Text = "?";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inDepthReportBtn);
            this.groupBox1.Location = new System.Drawing.Point(325, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 46);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // ViewResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFuncs);
            this.Controls.Add(this.btnShowResutls);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtOpenFolder);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.displayGraphBtn);
            this.Controls.Add(this.btnBack);
            this.Name = "ViewResults";
            this.Size = new System.Drawing.Size(732, 601);
            this.Load += new System.EventHandler(this.ViewResults_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RadioButton displayGraphBtn;
        private System.Windows.Forms.RadioButton inDepthReportBtn;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtOpenFolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnShowResutls;
        private System.Windows.Forms.ComboBox comboBoxFuncs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
