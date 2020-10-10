namespace QTLbyRegression
{
    partial class Form1
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
            this.btnSimulateData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSimulateData
            // 
            this.btnSimulateData.Location = new System.Drawing.Point(12, 75);
            this.btnSimulateData.Name = "btnSimulateData";
            this.btnSimulateData.Size = new System.Drawing.Size(134, 70);
            this.btnSimulateData.TabIndex = 1;
            this.btnSimulateData.Text = "Simulate Data";
            this.btnSimulateData.UseVisualStyleBackColor = true;
            this.btnSimulateData.Click += new System.EventHandler(this.btnSimulateData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSimulateData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSimulateData;
    }
}

