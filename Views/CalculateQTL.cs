﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using QTLProject.Enums;

namespace QTLProject
{
    public partial class CalculateQTL : UserControl
    {
        public event EventHandler backButtonClicked;
        public event EventHandler nextButtonClicked;
        CalcQTLPresentor calcQTLPresentor;
        public CalculateQTL()
        {
            InitializeComponent();
            calcQTLPresentor = new CalcQTLPresentor(this.prevoiusTableData);
            setupUI();
            this.Dock = DockStyle.Fill;
            this.btnBack.MouseClick += BtnBack_MouseClick;
            this.btnNext.MouseClick += BtnNext_MouseClick;
           
        }

        private void setupUI()
        {
            setupComboBox();
            setUpTable();
            setupButtons();
            setupFilePaths();
        }
        private void setupFilePaths()
        {
            this.textBoxGenotype.BackColor = Color.White;
            this.textBoxGenotype.BorderStyle = BorderStyle.None;
            this.textBoxGenotype.Controls.Add(new Label()
            { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
            this.textBoxPhenotype.BackColor = Color.White;
            this.textBoxPhenotype.BorderStyle = BorderStyle.None;
            this.textBoxPhenotype.Controls.Add(new Label()
            { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
            this.comboBoxModel.BackColor = Color.White;

        }
        private void setupButtons()
        {
            btnOpenDataGen.BackColor = ColorTranslator.FromHtml("#ebf9fc");
            btnOpenDataGen.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#ebf9fc");
            btnOpenDataGen.Size = new Size(60, 30);
            btnOpenDataGen.Image = (Image)(new Bitmap(btnOpenDataGen.Image, new Size(18, 18)));

            btnOpenDataPhen.BackColor = ColorTranslator.FromHtml("#ebf9fc");
            btnOpenDataPhen.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#ebf9fc");
            btnOpenDataPhen.Size = new Size(60, 30);
            btnOpenDataPhen.Image = (Image)(new Bitmap(btnOpenDataPhen.Image, new Size(18, 18)));

        }
        private void setupComboBox()
        {
            ArrayList comboBoxData = new ArrayList() { Constants.NoQTL, Constants.OneQTL, Constants.DominantQTL, Constants.TwoLinkedQTL };
            this.comboBoxModel.Items.AddRange(comboBoxData.ToArray());
            this.comboBoxModel.SelectedIndex = 0;
        }

        private void setUpTable()
        {
            List<string> geneticParams = new List<string>();
            geneticParams.Add(Constants.Marker);
            geneticParams.Add(Constants.CoorcM);
            geneticParams.Add(Constants.Chr);
            geneticParams.Add(Constants.Quality);

            
            calcQTLPresentor.GeneratePrevoiusTable(geneticParams, 25, 400, 4, 14);
        }
        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            nextButtonClicked?.Invoke(this, e);
        }

        private void BtnBack_MouseClick(object sender, MouseEventArgs e)
        {
            backButtonClicked?.Invoke(this, e);
        }

        private void btnOpenDataGen_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    // calcQTLPresentor.ReadDataGenotype(filePath);
                    this.textBoxGenotype.Text = filePath;
                }
            }
        }

        private void btnOpenDataPhen_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    // calcQTLPresentor.ReadDataPhenotype(filePath);
                    this.textBoxPhenotype.Text = filePath;
                }
            }
        }
    }
}
