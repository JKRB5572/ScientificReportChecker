using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Tools.Word;
using static WordAddIn1.Variables;


namespace WordAddIn1
{
    class Functions
    {

        /*
        //Function to check units
        internal static void checkUnits(string paragraph)
        {
            int numbers = Regex.Matches(paragraph, @"\d+.?\d*( |.|[A-z])").Count;
            int correct = Regex.Matches(paragraph, @"\d+.?\d* ?(gram|g|mg|kg|litre|[Ll]|cm3|dm3|mole|mol|mmol|M|mol/dm3|mol dm-3|N|%|% w\/w|% w\/v|g\/ml|g\/cm3|g cm-3|g ml-1|)").Count;

        }
        */

        /*
        //If the number of open brackets are closed brackets are equal check that any substance units are listed correctly
        else
        {
            int positionStart = paragraph.IndexOf("(");
            int positionEnd = paragraph.IndexOf(")");
            int stringLength = positionEnd - positionStart + 1;
            List<string> substances = new List<string>();
            string regexp0 = @"\(\d+";
            string regexp1 = @"\(\d+\.?\d* ?g, \d+\.?\d* ?mol\)";
            string regexp2 = @"\(\d+\.?\d* ?ml, \d+\.?\d* ?g, \d+\.?\d* ?mol\)";
            string regexp3 = @"\(\d+\.?\d* ?ml, \d+\.?\d* ?mol\)";
            string regexp4 = @"\(\d+\.?\d* ?cm3, \d+\.?\d* ?mol\)";
            while (positionStart != -1)
            {
                string substance = paragraph.Substring(positionStart, stringLength);
                if (Regex.IsMatch(substance, regexp0) == true)
                {
                    if ((Regex.IsMatch(substance, regexp1) == false) && (Regex.IsMatch(substance, regexp2) == false) && (Regex.IsMatch(substance, regexp3) == false) && (Regex.IsMatch(substance, regexp4) == false))
                    {
                        substances.Add(substance);
                    }
                }
                positionStart = paragraph.IndexOf("(", positionEnd + 1);
                positionEnd = paragraph.IndexOf(")", positionEnd + 1);
                stringLength = positionEnd - positionStart + 1;
            }
            if (substances.Count == 1)
            {
                addError("The following substance is wrong: " + substances[0]);
            }
            else if (substances.Count > 1)
            {
                errorReportParagraph += "The following susbtances are wrong: -";
                foreach (string _ in substances)
                {
                    addError(_);
                }
            }
        }
    }
    */

























    }
}
