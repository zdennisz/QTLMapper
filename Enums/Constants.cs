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
        public const string NoQTL = "No QTL";
        public const string OneQTL = "1 QTL";
        public const string DominantQTL = "Dominant 1 QTL";
        public const string TwoLinkedQTL = "2 Linked QTL";
      

    }

    class ColorConstants
    {
        public static Color tableHeaderColor = Color.FromArgb(199, 243, 252);
        public static Color backgroundColor = Color.FromArgb(239, 252, 255);
        public static Color backgroundContrastColor = Color.FromArgb(255, 255, 255);
    }
}
