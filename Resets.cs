using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WordAddIn1.Variables;

namespace WordAddIn1
{
    class Resets
    {
        //Function to reset variables that are used to log the paragraph text, paragraph style, errors, recommendations, error carrys and more.
        internal static void resetVariables()
        {
            try
            {
                paragraphText.Clear();
                paragraphStyle.Clear();
                errorReportHeader.Clear();
                errorReportBody.Clear();
                errorCountTotal = 0;
                recommendationBody = "";
                recommendationCount = 0;
                errorCarryCheckLists = false;
                errorCarryMultiplicationSign = false;
                errorCarryDMF = false;
                errorCarryDMC = false;
                errorCarryTHF = false;
                errorCarryML = false;
                errorCarryml = 0;
                errorCarrymL = 0;
                errorCarryGlassWare = 0;
                errorCarryTimeWords = 0;
                errorCarryCommonOperations1 = 0;
                errorCarryCommonOperations2 = 0;
                errorCarryCommonOperations3 = 0;
                errorCarryTLC1 = 0;
                errorCarryTLC2 = 0;
                errorCarryTLC3 = 0;
                errorCarryTLC4 = 0;
                errorCarrySulfur = 0;
                errorCarrySulphur = 0;
                paragraphDecrement = 0;
                paragraphNumber = 0;
                documentSection = "none";
                pastCheckShort.Clear();
                foreach (short _ in presentCheckShort)
                {
                    pastCheckShort.Add(_);
                }
                presentCheckShort.Clear();
                pastCheckString.Clear();
                foreach (string _ in presentCheckString)
                {
                    pastCheckString.Add(_);
                }
                presentCheckString.Clear();
                errorScore = 0;
                correctScore = 0;
            }
            catch
            {
                Basic_Functions.programError("5R00");
            }
        }


        //Set errorCountParagraph and errorReportParagraph to null for each paragraph
        internal static void resetErrors()
        {
            try
            {
                errorReportParagraph = "";
                errorCountParagraph = 0;
            }
            catch
            {
                Basic_Functions.programError("5R10");
            }
        }


        //Function to clear past check variables
        internal static void resetPastCheck()
        {
            try
            {
                pastCheckShort.Clear();
                pastCheckString.Clear();
                presentCheckShort.Clear();
                presentCheckString.Clear();
            }
            catch
            {
                Basic_Functions.programError("5R20");
            }
        }
    }
}
