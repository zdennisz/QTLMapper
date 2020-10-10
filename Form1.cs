using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTLbyRegression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupUI();
            //set the format of the dates
            SetDateTimeFormat();
        }

        private void btnSimulateData_Click(object sender, EventArgs e)
        {

            // Create 3 output files

            //Get current date and generate the files under the same time 
            DateTime dateTime = DateTime.Now;

            /*  1.table of genotypes: 
                 -tab delimited
                 - columns are individuals, rows are markers
                 -markers have unique name(id, column 0), 
                 -individuals have unique name(id, row 0), can be not provided
                 -only few possible genotypes are possible
                 - some genotypes can be unclear(coded by some text)
                 -some genotypes can be missed(coded by some text)
                 Example:
                 < tab > ind1 < tab > ind2 < tab > ind3
                 m1<tab> AA<tab>AA<tab> AB
                 m2<tab> NA< tab > AA < tab > BB
                 program should read any of such files but the analysis and simulations we will do only for simple case: only four variants for genotypes: -1(missed), 0(AA), 1(AB), 2(BB); all genotypes are clear

             2.genetic map:
                 -tab delimited
                 - rows are markers(names like in file with genotypes): < marker >< tab >< linkage group(chromosome) >< tab >< coor(cM) >
                 -some markers presented on map are not presented in file with genotypes
                 - some markers with genotypes are not presented on the map
                 Example:
                 marker < tab > chr < tab > coor
                 m1 < tab > Chr1 < tab > 0.1
                 m2 < tab > Chr1 < tab > 56

             3.table of traits:
                 -tab delimited
                 - usually rows are traits, columns are individuals(can be vice versa)
                 - some traits are unknown
                 - some traits are outliers
                 Example: 
                 trait < tab > ind1 < tab > ind2
                 age < tab > 28 < tab > 45
                 weight < tab > 71.5 < tab > 82
                 height < tab > NA < tab > 180
            */

            //Step 1 - Table of Geneotypes
            generateTableOfGenotypes(dateTime);

            //Step 2 - Generate genetic map
            generateGeneticMap(dateTime);

            //Step 3 - Generate Table of traits
            generateTableOfTraits(dateTime);


            GenerateOkMessageBox("Data Generated Successfully at " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Information");

        }

        private void GenerateOkMessageBox(string message,string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            
            result = MessageBox.Show(message, caption, buttons,MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
          
            }
        }
        private void SetupUI()
        {
            //Set the background color 
            this.BackColor = Color.FromArgb(239, 252, 255);
          
        
        }

        private void SetDateTimeFormat()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd_MM_yyyy H_mm_ss";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }
        private void generateTableOfGenotypes(DateTime dateTime)
        {
            var delimiter = "\t";
           
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + "\\Genotype_"+ dateTime.ToString() + ".CSV";

            using (var writer = new StreamWriter(filePath))
            {
            //    var line = string.Join(delimiter, itemContent);
            //    writer.WriteLine(line);
            }
        }

        private void generateGeneticMap(DateTime dateTime)
        {
            var delimiter = "\t";

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + "\\GeneticMap_" + dateTime.ToString() + ".CSV";

            using (var writer = new StreamWriter(filePath))
            {
                //    var line = string.Join(delimiter, itemContent);
                //    writer.WriteLine(line);
            }
        }


        private void generateTableOfTraits(DateTime dateTime)
        {
            var delimiter = "\t";

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + "\\TraitTable_" + dateTime.ToString() + ".CSV";

            using (var writer = new StreamWriter(filePath))
            {
                //    var line = string.Join(delimiter, itemContent);
                //    writer.WriteLine(line);
            }
        }

       
    }
}
