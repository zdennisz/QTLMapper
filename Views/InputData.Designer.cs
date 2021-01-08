using QTLProject.Utils;

namespace QTLProject
{
    partial class InputData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputData));
            this.inputDataTable = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpenData = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnSaveData = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnCutData = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnCopyData = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnPasteData = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnInsrData = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnDelData = new QTLProject.Utils.RoundedButtonToolBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new QTLProject.Utils.RoundedButtonToolBar();
            this.btnNext = new QTLProject.Utils.RoundedButtonToolBar();
            this.notifyInputDataSaved = new System.Windows.Forms.NotifyIcon(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputDataTable
            // 
            this.inputDataTable.AutoSize = true;
            this.inputDataTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inputDataTable.ColumnCount = 6;
            this.inputDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.inputDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.inputDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.inputDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.inputDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.inputDataTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 484F));
            this.inputDataTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputDataTable.Location = new System.Drawing.Point(0, 0);
            this.inputDataTable.Name = "inputDataTable";
            this.inputDataTable.RowCount = 10;
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.21561F));
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.78439F));
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.inputDataTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.inputDataTable.Size = new System.Drawing.Size(643, 256);
            this.inputDataTable.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnOpenData);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveData);
            this.flowLayoutPanel1.Controls.Add(this.btnCutData);
            this.flowLayoutPanel1.Controls.Add(this.btnCopyData);
            this.flowLayoutPanel1.Controls.Add(this.btnPasteData);
            this.flowLayoutPanel1.Controls.Add(this.btnInsrData);
            this.flowLayoutPanel1.Controls.Add(this.btnDelData);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(271, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(567, 55);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // btnOpenData
            // 
            this.btnOpenData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenData.FlatAppearance.BorderSize = 0;
            this.btnOpenData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenData.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenData.Image")));
            this.btnOpenData.Location = new System.Drawing.Point(15, 8);
            this.btnOpenData.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnOpenData.Name = "btnOpenData";
            this.btnOpenData.Size = new System.Drawing.Size(26, 26);
            this.btnOpenData.TabIndex = 5;
            this.btnOpenData.UseVisualStyleBackColor = true;
            // 
            // btnSaveData
            // 
            this.btnSaveData.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveData.FlatAppearance.BorderSize = 0;
            this.btnSaveData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveData.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveData.Image")));
            this.btnSaveData.Location = new System.Drawing.Point(61, 8);
            this.btnSaveData.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(26, 26);
            this.btnSaveData.TabIndex = 16;
            this.btnSaveData.UseVisualStyleBackColor = false;
            // 
            // btnCutData
            // 
            this.btnCutData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCutData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCutData.Enabled = false;
            this.btnCutData.FlatAppearance.BorderSize = 0;
            this.btnCutData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCutData.Image = ((System.Drawing.Image)(resources.GetObject("btnCutData.Image")));
            this.btnCutData.Location = new System.Drawing.Point(107, 8);
            this.btnCutData.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnCutData.Name = "btnCutData";
            this.btnCutData.Size = new System.Drawing.Size(26, 26);
            this.btnCutData.TabIndex = 7;
            this.btnCutData.UseVisualStyleBackColor = true;
            this.btnCutData.Visible = false;
            // 
            // btnCopyData
            // 
            this.btnCopyData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCopyData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyData.FlatAppearance.BorderSize = 0;
            this.btnCopyData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyData.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyData.Image")));
            this.btnCopyData.Location = new System.Drawing.Point(153, 8);
            this.btnCopyData.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnCopyData.Name = "btnCopyData";
            this.btnCopyData.Size = new System.Drawing.Size(26, 26);
            this.btnCopyData.TabIndex = 8;
            this.btnCopyData.UseVisualStyleBackColor = true;
            // 
            // btnPasteData
            // 
            this.btnPasteData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPasteData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasteData.FlatAppearance.BorderSize = 0;
            this.btnPasteData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasteData.Image = ((System.Drawing.Image)(resources.GetObject("btnPasteData.Image")));
            this.btnPasteData.Location = new System.Drawing.Point(199, 8);
            this.btnPasteData.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnPasteData.Name = "btnPasteData";
            this.btnPasteData.Size = new System.Drawing.Size(26, 26);
            this.btnPasteData.TabIndex = 9;
            this.btnPasteData.UseVisualStyleBackColor = true;
            // 
            // btnInsrData
            // 
            this.btnInsrData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInsrData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsrData.FlatAppearance.BorderSize = 0;
            this.btnInsrData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsrData.Image = ((System.Drawing.Image)(resources.GetObject("btnInsrData.Image")));
            this.btnInsrData.Location = new System.Drawing.Point(245, 8);
            this.btnInsrData.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnInsrData.Name = "btnInsrData";
            this.btnInsrData.Size = new System.Drawing.Size(26, 26);
            this.btnInsrData.TabIndex = 14;
            this.btnInsrData.UseVisualStyleBackColor = true;
            // 
            // btnDelData
            // 
            this.btnDelData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelData.FlatAppearance.BorderSize = 0;
            this.btnDelData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelData.Image = ((System.Drawing.Image)(resources.GetObject("btnDelData.Image")));
            this.btnDelData.Location = new System.Drawing.Point(291, 8);
            this.btnDelData.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnDelData.Name = "btnDelData";
            this.btnDelData.Size = new System.Drawing.Size(26, 26);
            this.btnDelData.TabIndex = 15;
            this.btnDelData.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.inputDataTable);
            this.panel1.Location = new System.Drawing.Point(41, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 452);
            this.panel1.TabIndex = 18;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F);
            this.btnBack.Location = new System.Drawing.Point(516, 561);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 32);
            this.btnBack.TabIndex = 4;
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
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // notifyInputDataSaved
            // 
            this.notifyInputDataSaved.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyInputDataSaved.Icon")));
            this.notifyInputDataSaved.Visible = true;
            // 
            // InputData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Name = "InputData";
            this.Size = new System.Drawing.Size(732, 601);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private RoundedButtonToolBar btnBack;
        private RoundedButtonToolBar btnNext;
        private RoundedButtonToolBar btnOpenData;
        private RoundedButtonToolBar btnCutData;
        private RoundedButtonToolBar btnCopyData;
        private RoundedButtonToolBar btnPasteData;
        private System.Windows.Forms.TableLayoutPanel inputDataTable;
        private RoundedButtonToolBar btnSaveData;
        private RoundedButtonToolBar btnDelData;
        private RoundedButtonToolBar btnInsrData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NotifyIcon notifyInputDataSaved;
    }
}
