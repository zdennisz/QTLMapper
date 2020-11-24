namespace QTLProject
{
    partial class SimulateData
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tableTraitTable1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTraitModel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxGenetic = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxTrait = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableGeneticModel = new System.Windows.Forms.TableLayoutPanel();
            this.labelGeneticModel = new System.Windows.Forms.Label();
            this.tableTraitTable2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTableContainer = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelTableContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(566, 569);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(647, 569);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // tableTraitTable1
            // 
            this.tableTraitTable1.AutoSize = true;
            this.tableTraitTable1.ColumnCount = 2;
            this.tableTraitTable1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.44186F));
            this.tableTraitTable1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.55814F));
            this.tableTraitTable1.Location = new System.Drawing.Point(396, 18);
            this.tableTraitTable1.Name = "tableTraitTable1";
            this.tableTraitTable1.RowCount = 6;
            this.tableTraitTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.21127F));
            this.tableTraitTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.78873F));
            this.tableTraitTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableTraitTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableTraitTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableTraitTable1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableTraitTable1.Size = new System.Drawing.Size(200, 152);
            this.tableTraitTable1.TabIndex = 14;
            this.tableTraitTable1.Visible = false;
            // 
            // labelTraitModel
            // 
            this.labelTraitModel.AutoSize = true;
            this.labelTraitModel.Location = new System.Drawing.Point(45, 125);
            this.labelTraitModel.Name = "labelTraitModel";
            this.labelTraitModel.Size = new System.Drawing.Size(60, 13);
            this.labelTraitModel.TabIndex = 15;
            this.labelTraitModel.Text = "Tarit Model";
            this.labelTraitModel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxGenetic);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(24, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 74);
            this.panel2.TabIndex = 12;
            // 
            // comboBoxGenetic
            // 
            this.comboBoxGenetic.BackColor = System.Drawing.Color.White;
            this.comboBoxGenetic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenetic.FormattingEnabled = true;
            this.comboBoxGenetic.Location = new System.Drawing.Point(16, 35);
            this.comboBoxGenetic.Name = "comboBoxGenetic";
            this.comboBoxGenetic.Size = new System.Drawing.Size(176, 21);
            this.comboBoxGenetic.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Genetic Model";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBoxTrait);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(262, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 74);
            this.panel3.TabIndex = 13;
            // 
            // comboBoxTrait
            // 
            this.comboBoxTrait.BackColor = System.Drawing.Color.White;
            this.comboBoxTrait.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrait.FormattingEnabled = true;
            this.comboBoxTrait.Location = new System.Drawing.Point(16, 35);
            this.comboBoxTrait.Name = "comboBoxTrait";
            this.comboBoxTrait.Size = new System.Drawing.Size(176, 21);
            this.comboBoxTrait.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Trait Model";
            // 
            // tableGeneticModel
            // 
            this.tableGeneticModel.ColumnCount = 6;
            this.tableGeneticModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.689F));
            this.tableGeneticModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.311F));
            this.tableGeneticModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 254F));
            this.tableGeneticModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableGeneticModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableGeneticModel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableGeneticModel.Location = new System.Drawing.Point(19, 385);
            this.tableGeneticModel.Name = "tableGeneticModel";
            this.tableGeneticModel.RowCount = 7;
            this.tableGeneticModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.39535F));
            this.tableGeneticModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.60465F));
            this.tableGeneticModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableGeneticModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableGeneticModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableGeneticModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableGeneticModel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableGeneticModel.Size = new System.Drawing.Size(687, 144);
            this.tableGeneticModel.TabIndex = 15;
            // 
            // labelGeneticModel
            // 
            this.labelGeneticModel.AutoSize = true;
            this.labelGeneticModel.Location = new System.Drawing.Point(32, 369);
            this.labelGeneticModel.Name = "labelGeneticModel";
            this.labelGeneticModel.Size = new System.Drawing.Size(76, 13);
            this.labelGeneticModel.TabIndex = 16;
            this.labelGeneticModel.Text = "Genetic Model";
            this.labelGeneticModel.Visible = false;
            // 
            // tableTraitTable2
            // 
            this.tableTraitTable2.AutoSize = true;
            this.tableTraitTable2.ColumnCount = 2;
            this.tableTraitTable2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.33333F));
            this.tableTraitTable2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.66667F));
            this.tableTraitTable2.Location = new System.Drawing.Point(13, 15);
            this.tableTraitTable2.Name = "tableTraitTable2";
            this.tableTraitTable2.RowCount = 5;
            this.tableTraitTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableTraitTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableTraitTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableTraitTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableTraitTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableTraitTable2.Size = new System.Drawing.Size(200, 152);
            this.tableTraitTable2.TabIndex = 17;
            this.tableTraitTable2.Visible = false;
            // 
            // panelTableContainer
            // 
            this.panelTableContainer.Controls.Add(this.tableTraitTable2);
            this.panelTableContainer.Controls.Add(this.tableTraitTable1);
            this.panelTableContainer.Location = new System.Drawing.Point(22, 141);
            this.panelTableContainer.Name = "panelTableContainer";
            this.panelTableContainer.Size = new System.Drawing.Size(661, 213);
            this.panelTableContainer.TabIndex = 18;
            // 
            // SimulateData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTableContainer);
            this.Controls.Add(this.labelGeneticModel);
            this.Controls.Add(this.tableGeneticModel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelTraitModel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Name = "SimulateData";
            this.Size = new System.Drawing.Size(732, 601);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelTableContainer.ResumeLayout(false);
            this.panelTableContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label labelTraitModel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxGenetic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxTrait;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelGeneticModel;
        public System.Windows.Forms.TableLayoutPanel tableTraitTable1;
        public System.Windows.Forms.TableLayoutPanel tableGeneticModel;
        private System.Windows.Forms.Panel panelTableContainer;
        public System.Windows.Forms.TableLayoutPanel tableTraitTable2;
    }
}
