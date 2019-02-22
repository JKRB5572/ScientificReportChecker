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
    class Error_Functions
    {
        //Function to check numbers are listed to an appropirate number of decimal places
        internal static void checkDecimalPlaces(string paragraph)
        {
            try
            {
                MatchCollection matches = Regex.Matches(paragraph, @"\d+.?\d*( |\S)");
                foreach (Match match in matches)
                {
                    string number = match.Value;
                    String[] subnumbers = number.Split('.');
                    if (subnumbers.Length == 2)
                    {
                        //The following if statement checks that numbers below ten do not have more than 3 decimal places, numbers below one hundered do not have more than 2 decimal places, that numbers below one thousand do not have more than 1 decimal place, and that numbers equal to or greater than one thousand have no decimal places
                        if ((subnumbers[0].Length > 3 && subnumbers[1].Length > 1) || (subnumbers[0].Length == 3 && subnumbers[1].Length > 2) || (subnumbers[0].Length == 2 && subnumbers[1].Length > 3) || (subnumbers[0].Length == 1 && subnumbers[1].Length > 4))
                        {
                            addError(number.Remove(number.Length - 1) + " might have too many decimal places. Think about the precision of the data and round off appropriately.");
                        }
                    }
                }
            }
            catch
            {
                programError("5EF00");
            }
        }


        //Function to check that personal lanugage is not used 
        internal static void checkFristPerson(string paragraph)
        {
            try
            {
                if (checkRegexpBool(paragraph, @"(^I )|( I )|(^We )|( [Ww]e )|(^My )|( [Mm]y )") == true)

                {
                    addError("Generally, you should avoid using 'I', 'we', 'my' in scientific writing. For example, say 'Compound A was added to compound B' instead of 'I added compound A to compound B'");
                }
            }
            catch
            {
                programError("5EF10");
            }
        }


        //Function to check that a sentence does not begin with and
        internal static void checkAnd(string paragraph)
        {
            try
            {
                if (checkRegexpBool(paragraph, @"^And |\. [aA]nd ") == true)
                {
                    addError("And should not be used at the beginning of a sentence");
                }
            }
            catch
            {
                programError("5EF20");
            }
        }


        //Function to check that degree symbol is used instead of 0, o, or O
        internal static void checkDegreeSymbol(string paragraph)
        {
            try
            {
                if (checkRegexpBool(paragraph, @"\d+ ?[0oO][cC]( |\.)") == true)
                {
                    addError("When writing the units of temperature, °C , you should use the degree sign °. Do not use a superscript letter 'o' or zero '0'. You can find the ° sign from the Insert Symbol menu in Word. You can also hold down the Alt key and type 0176 on the numeric keypad.");
                }
            }
            catch
            {
                programError("5EF30");
            }
        }


        //Function to check that pH is written in the correct case
        internal static void checkpH(string paragraph)
        {
            try
            {
                if (checkRegexpBool(paragraph, @"(\d| )ph\W"))
                {
                    addError("You have not capatilsed the letter 'H' when spelling 'pH'.");
                }
                if (checkRegexpBool(paragraph, @"(\d| )PH\W"))
                {
                    addError("You have incorrectly capatilsed the letter 'p' when spelling 'pH'.");
                }
                if (checkRegexpBool(paragraph, @"(\d| )Ph\W"))
                {
                    addError("You have incorrectly capatilsed the letter 'p' instead of the letter 'H' when spelling 'pH'.");
                }
            }
            catch
            {
                programError("5EF40");
            }
        }
    }
}
