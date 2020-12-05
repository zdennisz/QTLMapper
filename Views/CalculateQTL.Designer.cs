using QTLProject.Utils;

namespace QTLProject
{
    partial class CalculateQTL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculateQTL));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPhenotype = new System.Windows.Forms.TextBox();
            this.textBoxGenotype = new System.Windows.Forms.TextBox();
            this.tablePanelContainer = new System.Windows.Forms.Panel();
            this.prevoiusTableData = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenDataGen = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnOpenDataPhen = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnBack = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnNext = new QTLProject.Utils.RoundedButtonToolBar();
            this.tablePanelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phenotype";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(273, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Genotype";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(515, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Model";
            // 
            // textBoxPhenotype
            // 
            this.textBoxPhenotype.Enabled = false;
            this.textBoxPhenotype.Location = new System.Drawing.Point(12, 56);
            this.textBoxPhenotype.Name = "textBoxPhenotype";
            this.textBoxPhenotype.Size = new System.Drawing.Size(160, 20);
            this.textBoxPhenotype.TabIndex = 9;
            // 
            // textBoxGenotype
            // 
            this.textBoxGenotype.Enabled = false;
            this.textBoxGenotype.Location = new System.Drawing.Point(275, 55);
            this.textBoxGenotype.Name = "textBoxGenotype";
            this.textBoxGenotype.Size = new System.Drawing.Size(160, 20);
            this.textBoxGenotype.TabIndex = 11;
            // 
            // tablePanelContainer
            // 
            this.tablePanelContainer.AutoScroll = true;
            this.tablePanelContainer.Controls.Add(this.prevoiusTableData);
            this.tablePanelContainer.Location = new System.Drawing.Point(13, 105);
            this.tablePanelContainer.Name = "tablePanelContainer";
            this.tablePanelContainer.Size = new System.Drawing.Size(610, 430);
            this.tablePanelContainer.TabIndex = 18;
            // 
            // prevoiusTableData
            // 
            this.prevoiusTableData.AutoSize = true;
            this.prevoiusTableData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.prevoiusTableData.ColumnCount = 2;
            this.prevoiusTableData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.prevoiusTableData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.prevoiusTableData.Dock = System.Windows.Forms.DockStyle.Top;
            this.prevoiusTableData.Location = new System.Drawing.Point(0, 0);
            this.prevoiusTableData.Name = "prevoiusTableData";
            this.prevoiusTableData.RowCount = 2;
            this.prevoiusTableData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.prevoiusTableData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.prevoiusTableData.Size = new System.Drawing.Size(610, 0);
            this.prevoiusTableData.TabIndex = 0;
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(519, 50);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(105, 21);
            this.comboBoxModel.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Genetic Map";
            // 
            // btnOpenDataGen
            // 
            this.btnOpenDataGen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOpenDataGen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenDataGen.FlatAppearance.BorderSize = 0;
            this.btnOpenDataGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDataGen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDataGen.Image")));
            this.btnOpenDataGen.Location = new System.Drawing.Point(448, 41);
            this.btnOpenDataGen.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnOpenDataGen.Name = "btnOpenDataGen";
            this.btnOpenDataGen.Size = new System.Drawing.Size(76, 31);
            this.btnOpenDataGen.TabIndex = 12;
            this.btnOpenDataGen.UseVisualStyleBackColor = true;
            this.btnOpenDataGen.Click += new System.EventHandler(this.btnOpenDataGen_Click);
            // 
            // btnOpenDataPhen
            // 
            this.btnOpenDataPhen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOpenDataPhen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenDataPhen.FlatAppearance.BorderSize = 0;
            this.btnOpenDataPhen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDataPhen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDataPhen.Image")));
            this.btnOpenDataPhen.Location = new System.Drawing.Point(186, 41);
            this.btnOpenDataPhen.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnOpenDataPhen.Name = "btnOpenDataPhen";
            this.btnOpenDataPhen.Size = new System.Drawing.Size(76, 31);
            this.btnOpenDataPhen.TabIndex = 10;
            this.btnOpenDataPhen.UseVisualStyleBackColor = true;
            this.btnOpenDataPhen.Click += new System.EventHandler(this.btnOpenDataPhen_Click);
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F);
            this.btnBack.Location = new System.Drawing.Point(516, 561);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 32);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNext.Location = new System.Drawing.Point(623, 561);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 32);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // CalculateQTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenDataGen);
            this.Controls.Add(this.btnOpenDataPhen);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.tablePanelContainer);
            this.Controls.Add(this.textBoxGenotype);
            this.Controls.Add(this.textBoxPhenotype);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Name = "CalculateQTL";
            this.Size = new System.Drawing.Size(732, 601);
            this.tablePanelContainer.ResumeLayout(false);
            this.tablePanelContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RoundedButtonToolBar btnNext;
        private RoundedButtonToolBar btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPhenotype;
        private System.Windows.Forms.TextBox textBoxGenotype;
        private System.Windows.Forms.Panel tablePanelContainer;
        private System.Windows.Forms.TableLayoutPanel prevoiusTableData;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private RoundedButtonToolBar btnOpenDataPhen;
        private RoundedButtonToolBar btnOpenDataGen;
        private System.Windows.Forms.Label label1;
    }
}
