using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject.Enums
{
    class Constants
    {
        /// <summary>
        /// Tarit models names
        /// </summary>
        public const string NoQTL = "No QTL";
        public const string OneQTL = "1 QTL";
        public const string DominantQTL = "Dominant 1 QTL";
        public const string TwoLinkedQTL = "2 Linked QTL";

        /// <summary>
        /// Genetic table header titles
        /// </summary>
        public const string ChrNum = "Chr Num.";
        public const string ChrLen = "Chr Len. (cM)";
        public const string MarkerPerChr = "Marker per Chr";
        public const string PopSize = "Pop Size";
        public const string MissingData = "Missing Data %";
        public const string Error = "Error %";


        /// <summary>
        ///  Tratit table column names
        /// </summary>
        public const string QtlPos= "QTL pos (cM)";
        public const string QTLChr="QTL Chr";
        public const string VarQ="Var Q";
        public const string Varq="Var q";
        public const string AvgQ="Avq. Q";
        public const string Avgq="Avq. q";


    }

    class ColorConstants
    {
        public static Color tableHeaderColor = Color.FromArgb(199, 243, 252);
        public static Color backgroundColor = Color.FromArgb(239, 252, 255);
        public static Color backgroundContrastColor = Color.FromArgb(255, 255, 255);
    }
}
