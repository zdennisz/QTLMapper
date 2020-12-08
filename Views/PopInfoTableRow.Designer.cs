namespace QTLProject.Views
{
    partial class PopInfoTableRow
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
            this.rowPanel = new System.Windows.Forms.Panel();
            this.rowTextBox = new System.Windows.Forms.TextBox();
            this.rowLabel = new System.Windows.Forms.Label();
            this.rowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rowPanel
            // 
            this.rowPanel.Controls.Add(this.rowTextBox);
            this.rowPanel.Controls.Add(this.rowLabel);
            this.rowPanel.Location = new System.Drawing.Point(0, 0);
            this.rowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rowPanel.Name = "rowPanel";
            this.rowPanel.Size = new System.Drawing.Size(169, 25);
            this.rowPanel.TabIndex = 0;
            // 
            // rowTextBox
            // 
            this.rowTextBox.BackColor = System.Drawing.Color.White;
            this.rowTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rowTextBox.Location = new System.Drawing.Point(120, 6);
            this.rowTextBox.Name = "rowTextBox";
            this.rowTextBox.Size = new System.Drawing.Size(44, 13);
            this.rowTextBox.TabIndex = 1;
            this.rowTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.rowLabel.Location = new System.Drawing.Point(15, 2);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(46, 16);
            this.rowLabel.TabIndex = 0;
            this.rowLabel.Text = "label1";
            // 
            // PopInfoTableRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rowPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PopInfoTableRow";
            this.Size = new System.Drawing.Size(205, 25);
            this.rowPanel.ResumeLayout(false);
            this.rowPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox rowTextBox;
        public System.Windows.Forms.Label rowLabel;
        public System.Windows.Forms.Panel rowPanel;
    }
}
