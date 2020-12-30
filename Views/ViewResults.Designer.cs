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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ToggleButtonInDepthReport = new QTLProject.Utils.CustomToggleButton();
            this.ToggleButtonDisplayGraph = new QTLProject.Utils.CustomToggleButton();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.Location = new System.Drawing.Point(372, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Display Graph";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F);
            this.label3.Location = new System.Drawing.Point(487, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "In Depth Report";
            // 
            // ToggleButtonInDepthReport
            // 
            this.ToggleButtonInDepthReport.BorderColor = System.Drawing.Color.LightGray;
            this.ToggleButtonInDepthReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleButtonInDepthReport.ForeColor = System.Drawing.Color.White;
            this.ToggleButtonInDepthReport.IsOn = false;
            this.ToggleButtonInDepthReport.Location = new System.Drawing.Point(490, 72);
            this.ToggleButtonInDepthReport.Name = "ToggleButtonInDepthReport";
            this.ToggleButtonInDepthReport.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ToggleButtonInDepthReport.OffText = "";
            this.ToggleButtonInDepthReport.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(229)))));
            this.ToggleButtonInDepthReport.OnText = "";
            this.ToggleButtonInDepthReport.Size = new System.Drawing.Size(60, 35);
            this.ToggleButtonInDepthReport.TabIndex = 28;
            this.ToggleButtonInDepthReport.TextEnabled = true;
            // 
            // ToggleButtonDisplayGraph
            // 
            this.ToggleButtonDisplayGraph.BorderColor = System.Drawing.Color.LightGray;
            this.ToggleButtonDisplayGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleButtonDisplayGraph.ForeColor = System.Drawing.Color.White;
            this.ToggleButtonDisplayGraph.IsOn = false;
            this.ToggleButtonDisplayGraph.Location = new System.Drawing.Point(375, 72);
            this.ToggleButtonDisplayGraph.Name = "ToggleButtonDisplayGraph";
            this.ToggleButtonDisplayGraph.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ToggleButtonDisplayGraph.OffText = "";
            this.ToggleButtonDisplayGraph.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(229)))));
            this.ToggleButtonDisplayGraph.OnText = "";
            this.ToggleButtonDisplayGraph.Size = new System.Drawing.Size(66, 35);
            this.ToggleButtonDisplayGraph.TabIndex = 27;
            this.ToggleButtonDisplayGraph.TextEnabled = true;
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
            this.Controls.Add(this.ToggleButtonInDepthReport);
            this.Controls.Add(this.ToggleButtonDisplayGraph);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomToggleButton ToggleButtonDisplayGraph;
        private CustomToggleButton ToggleButtonInDepthReport;
    }
}
