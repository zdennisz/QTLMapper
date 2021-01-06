using QTLProject.Utils;

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
            this.comboBoxFuncs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowResutls = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnBack = new QTLProject.Utils.RoundedButtonToolBar();
            this.SuspendLayout();
            // 
            // comboBoxFuncs
            // 
            this.comboBoxFuncs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFuncs.Font = new System.Drawing.Font("Arial", 10F);
            this.comboBoxFuncs.FormattingEnabled = true;
            this.comboBoxFuncs.Location = new System.Drawing.Point(20, 80);
            this.comboBoxFuncs.Name = "comboBoxFuncs";
            this.comboBoxFuncs.Size = new System.Drawing.Size(217, 24);
            this.comboBoxFuncs.TabIndex = 19;
            this.comboBoxFuncs.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFuncs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.Location = new System.Drawing.Point(17, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Calculation Type";
            // 
            // btnShowResutls
            // 
            this.btnShowResutls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowResutls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowResutls.Font = new System.Drawing.Font("Arial", 10F);
            this.btnShowResutls.Location = new System.Drawing.Point(604, 561);
            this.btnShowResutls.Name = "btnShowResutls";
            this.btnShowResutls.Size = new System.Drawing.Size(118, 32);
            this.btnShowResutls.TabIndex = 18;
            this.btnShowResutls.Text = "Show Results";
            this.btnShowResutls.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F);
            this.btnBack.Location = new System.Drawing.Point(498, 561);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 32);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // ViewResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFuncs);
            this.Controls.Add(this.btnShowResutls);
            this.Controls.Add(this.btnBack);
            this.Name = "ViewResults";
            this.Size = new System.Drawing.Size(732, 601);
            this.Load += new System.EventHandler(this.ViewResults_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RoundedButtonToolBar btnBack;
        private RoundedButtonToolBar btnShowResutls;
        private System.Windows.Forms.ComboBox comboBoxFuncs;
        private System.Windows.Forms.Label label1;
    }
}
