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
            this.showResultsContentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // showResultsContentPanel
            // 
            this.showResultsContentPanel.AutoScroll = true;
            this.showResultsContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showResultsContentPanel.Location = new System.Drawing.Point(0, 0);
            this.showResultsContentPanel.Name = "showResultsContentPanel";
            this.showResultsContentPanel.Size = new System.Drawing.Size(704, 561);
            this.showResultsContentPanel.TabIndex = 0;
            // 
            // ShowResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 561);
            this.Controls.Add(this.showResultsContentPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowResults";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel showResultsContentPanel;
    }
}