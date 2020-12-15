namespace QTLProject.Views
{
    partial class InputDataTableHeader
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
            this.label1Col = new System.Windows.Forms.Label();
            this.label2Col = new System.Windows.Forms.Label();
            this.label3Col = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1Col
            // 
            this.label1Col.AutoSize = true;
            this.label1Col.Font = new System.Drawing.Font("Arial", 10F);
            this.label1Col.Location = new System.Drawing.Point(90, 4);
            this.label1Col.Name = "label1Col";
            this.label1Col.Size = new System.Drawing.Size(46, 16);
            this.label1Col.TabIndex = 6;
            this.label1Col.Text = "label1";
            // 
            // label2Col
            // 
            this.label2Col.AutoSize = true;
            this.label2Col.Font = new System.Drawing.Font("Arial", 10F);
            this.label2Col.Location = new System.Drawing.Point(280, 4);
            this.label2Col.Name = "label2Col";
            this.label2Col.Size = new System.Drawing.Size(46, 16);
            this.label2Col.TabIndex = 7;
            this.label2Col.Text = "label2";
            // 
            // label3Col
            // 
            this.label3Col.AutoSize = true;
            this.label3Col.Font = new System.Drawing.Font("Arial", 10F);
            this.label3Col.Location = new System.Drawing.Point(485, 4);
            this.label3Col.Name = "label3Col";
            this.label3Col.Size = new System.Drawing.Size(46, 16);
            this.label3Col.TabIndex = 8;
            this.label3Col.Text = "label3";
            // 
            // InputDataTableHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1Col);
            this.Controls.Add(this.label2Col);
            this.Controls.Add(this.label3Col);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InputDataTableHeader";
            this.Size = new System.Drawing.Size(600, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1Col;
        private System.Windows.Forms.Label label2Col;
        private System.Windows.Forms.Label label3Col;
    }
}
