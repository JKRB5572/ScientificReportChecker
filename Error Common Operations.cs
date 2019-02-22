using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static WordAddIn1.Variables;
using static WordAddIn1.Basic_Functions;

namespace WordAddIn1
{
    //The following class contains functions to log and report if common operations are execessively described
    class Error_Common_Operations
    {
        //The following function logs uses of common opeartions for each paragraph in the document
        internal static void logCommonOperations(string paragraph)
        {
            try
            {
                {
                    //The following lines check for key words that make up the three seperate error dictionaries
                    errorCarryCommonOperations1 += (short)Regex.Matches(paragraph.ToLower(), @"filter|frit|paper|funnel|b(u|\u00FC)chner|hirsch|vacuum|suction").Count;
                    errorCarryCommonOperations2 += (short)Regex.Matches(paragraph.ToLower(), @"crystallisation|crystallise|crystallize|hot|heating|minimum|flask|filter|crystals|cool|dropwise|dissolve|solution").Count;
                    errorCarryCommonOperations3 += (short)Regex.Matches(paragraph.ToLower(), @"packaging|vial|sample|product|balance|weight|weighing|weigh|mass|label|stopper|tube|record|write").Count;
                }
            }
            catch
            {
                programError("5ECO00");
            }
        }

        internal static void checkCommonOperations()
        {
            try
            {
                //Checkes to see if there are more than 9 uses of words from each of the dictionaries and then adds an error
                if (errorCarryCommonOperations1 > 9 || errorCarryCommonOperations2 > 9 || errorCarryCommonOperations3 > 9)
                {
                    addError("test");
                    errorReportHeader.Add("");
                    errorReportBody.Add("You have described common operations in excessive detail. You can assume that the reader will be familiar with common procedures like weighing, filtering and performing a recrystallisation. It is unnecessary to describe these procedures in great detail.");

                }
                //Otherwise checks to see if there are more than 4 uses of words from each of the dictionaries and then adds a recommendation
                else if ((errorCarryCommonOperations1 > 4) || (errorCarryCommonOperations2 > 4) || (errorCarryCommonOperations3 > 4))
                {
                    addRecommendation("It is recommended that you describe common operations less. You can assume that the reader will be familiar with basic laboratory operations like setting up a filtration and weighing samples.");
                }
            }
            catch
            {
                programError("5ECO10");
            }
        }
    }
}
