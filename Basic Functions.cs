using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WordAddIn1.Variables;

namespace WordAddIn1
{
    //The follwing class defines a number of functions that are used for core functionality
    class Basic_Functions
    {
        /* The following two functions, when called, creates a dialog box informing the user that an error has
         * occured in the program and determines what text should be displayed. The first function is for program
         * errors that prevent some features from working, the second function is for critical errors that cause
         * the program to crash or stop functioning.
         * 
         * Critical errors are given a unique name relating to the speific error.
         * Program errors are given a alphanumeric code that follows the formatting: 5 (Abbreviation of class name) (Function number, in order of apperance in the class) (Error number, in order of apperance in the function)
         * 
         */


        internal static void programError(string errorNumber = "undefined")
        {
            DialogResult result = MessageBox.Show("An error has been detected in the add in. Please file a bug report on Learning Central and quote Error Code " + errorNumber + ".", "Error: " + errorNumber, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        internal static void criticalError(string errorText = "UNDEFINED")
        {
            DialogResult result = MessageBox.Show("A critical error has been detected in the add in. Please file a bug report on Learning Central and quote Critical Error: " + errorText + ".", "CRITICAL ERROR: " + errorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Function to check that the document section is the experimental section of the document
        internal static string checkDocumentSection(string documentSection, string paragraph)
        {
            try
            {
                if (documentSection == "none")
                {
                    if (checkRegexpBool(paragraph.ToLower(), @"(^experimental)|(^method)") == true)
                    {
                        paragraphDecrement--;
                        return "experimental";
                    }
                    else return "none";
                }
                else if (documentSection == "experimental")
                {
                    if (checkRegexpBool(paragraph.ToLower(), @"^conclusion") == true)
                    {
                        return "conclusion";
                    }
                    else return "experimental";
                }
                else return "conclusion";
            }
            catch
            {
                programError("5BF20");
                return "";
            }
        }


        //Function to add an error
        internal static void addError(string error, short increment = 1)
        {
            try
            {
                errorReportParagraph += error + "\n\n";
                if (paragraphNumber != 0)
                {
                    presentCheckShort.Add((short)(paragraphNumber + paragraphDecrement));
                    presentCheckString.Add(error);
                }
                else
                {
                    presentCheckShort.Add(-1);          //To prevent indexing errors add -1 to the presentCheckShort list
                }
                errorCountParagraph += increment;
                errorCountTotal += increment;
            }
            catch
            {
                programError("5BF30");
            }
        }


        //Function to add a recommendation
        internal static void addRecommendation(string recommendation, short increment = 1)
        {
            try
            {
                recommendationBody += recommendation + "\n\n";
                presentCheckShort.Add(-1);          //To prevent indexing errors add -1 to the presentCheckShort list               
                presentCheckString.Add(recommendation);
                recommendationCount += increment;
            }
            catch
            {
                programError("5BF40");
            }
        }


        //Function to check regular expression with a Boolean return
        internal static bool checkRegexpBool(string text, string regexp)
        {
            try
            {
                if (Regex.IsMatch(text, regexp)) { return true; }
                else { return false; }
            }
            catch
            {
                programError("5BF50");
                return false;
            }
        }


        //Function to check regular expression with a Short return
        internal static short checkRegexpShort(string text, string regexp)
        {
            try
            {
                return (short)Regex.Matches(text, regexp).Count;
            }
            catch
            {
                programError("5BF60");
                return 0;
            }
        }


        //Function to add the apperopraite error header
        internal static void appendErrorHeader()
        {
            try
            {
                //If errors were found append appropriate header to errorReportParagraph before appending to errorReportComplete
                if (errorCountParagraph == 1)
                {
                    errorReportHeader.Add("\n1 error found in paragraph " + (paragraphNumber + paragraphDecrement) + "\n");
                    errorReportBody.Add(errorReportParagraph);
                }
                else if (errorCountParagraph > 1)
                {
                    errorReportHeader.Add("\n" + errorCountParagraph + " errors were found in paragraph " + (paragraphNumber + paragraphDecrement) + "\n");
                    errorReportBody.Add(errorReportParagraph);
                }
            }
            catch
            {
                programError("5BF70");
            }
        }

        //Function to add a header that tells the user how many errors and recommendations were detected
        internal static string errorsAndRecommendationsHeader()
        {
            try
            {
                if (errorCountTotal > 0 || recommendationCount > 0)
                {
                    string returnString = "";
                    bool andNeeded = false;
                    if (errorCountTotal == 1)
                    {
                        returnString += "1 error";
                        andNeeded = true;
                    }
                    else if (errorCountTotal > 1)
                    {
                        returnString += errorCountTotal + " errors";
                        andNeeded = true;
                    }
                    if (recommendationCount == 1)
                    {
                        if(andNeeded == true)
                        {
                            returnString += " and ";
                        }
                        returnString += "1 recommendation";
                    }
                    else if (recommendationCount > 1)
                    {
                        if(andNeeded == true)
                        {
                            returnString += " and ";
                        }
                        returnString += recommendationCount + " recommendations";
                    }
                    return returnString += "\n";
                }
                return "";
            }
            catch
            {
                programError("5BF80");
                return "";
            }
        }
    }
}
