using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static WordAddIn1.Basic_Functions;

namespace WordAddIn1
{
    //The following class contains functions to perform all of the bracket checks. The bracket checks are that; there is an equal number of open and closed brackets for each bracket type (round, square, and brace), and that brackets are correctly paired.
    class Error_Brackets
    {

        internal static void checkBrackets(string paragraph)
        {
            try
            {
                equalOpenedClosed(paragraph);
            }
            catch
            {
                programError("5EB00");
            }
            try
            {
                mispairedBrackets(paragraph);
            }
            catch
            {
                programError("5EB01");
            }
        }


        //Function to check that the number of open brackets of each type is equal to the closed brackets of each type.
        internal static void equalOpenedClosed(string paragraph)
        {
            try
            {
                short openRound = checkRegexpShort(paragraph, @"\(");
                short closedRound = checkRegexpShort(paragraph, @"\)");
                short openSquare = checkRegexpShort(paragraph, @"\[");
                short closedSquare = checkRegexpShort(paragraph, @"\]");
                short openBrace = checkRegexpShort(paragraph, @"\{");
                short closedBrace = checkRegexpShort(paragraph, @"\}");

                if ((openRound != closedRound) || (openSquare != closedSquare) || (openBrace != closedBrace))
                {
                    //The following if statements check to see if there is an equal number of each bracket type
                    if (openRound != closedRound)
                    {
                        bracketsError("round bracket", openRound, closedRound);
                    }
                    if (openSquare != closedSquare)
                    {
                        bracketsError("square bracket", openSquare, closedSquare);
                    }
                    if (openBrace != closedBrace)
                    {
                        bracketsError("brace", openBrace, closedBrace);
                    }
                }
            }
            catch
            {
                programError("5EB10");
            }
        }


        //Function to determine which brackets error to display I.E. which bracket type and whether there are more closed or open brackets
        internal static void bracketsError(string bracket, short open, short closed)
        {
            try
            {
                if (open > closed)
                {
                    short difference = (short)(open - closed);
                    addError("There " + subjectVerb(open, closed) + difference + " more open " + bracket + plural(open, closed) + " than closed " + bracket + "s");
                }
                else if (open < closed)
                {
                    short difference = (short)(closed - open);
                    addError("There " + subjectVerb(closed, open) + difference + " more closed " + bracket + plural(open, closed) + " than open " + bracket + "s");
                }
            }
            catch
            {
                programError("5EB20");
            }
        }

        //Function to determine which subject verb to use when displaying the bracket error
        internal static string subjectVerb(short a, short b)
        {
            try
            {
                if ((a - b == 1) || (a - b == -1))
                {
                    return "is ";
                }
                else return "are ";
            }
            catch
            {
                programError("5EB30");
                return "";
            }
        }


        //Function to determine whether the word bracket should be pluraised in the error report
        internal static string plural(short a, short b)
        {
            try
            {
                if ((a - b == 1) || (a - b == -1))
                {
                    return "";
                }
                else return "s ";
            }
            catch
            {
                programError("5EB40");
                return "";
            }
        }


        //Function to check that each opened bracket is correctly paired with a closing bracket of the same type
        internal static void mispairedBrackets(string paragraph)
        {
            try {
                string bracketLevel = "";
                string bracket = "";
                Regex regexp = new Regex(@"\(|\)|\[|\]|\{|\}");

                foreach (Match m in regexp.Matches(paragraph))
                {
                    bracket = m.ToString();
                    if (bracket == "(")
                    {
                        bracketLevel += "(";
                    }
                    else if (bracket == "[")
                    {
                        bracketLevel += "[";
                    }
                    else if (bracket == "{")
                    {
                        bracketLevel += "{";
                    }
                    else if (bracket == ")" && bracketLevel.Length > 0)
                    {
                        if (bracketLevel[bracketLevel.Length - 1].ToString() == "(")
                        {
                            bracketLevel = bracketLevel.Remove(bracketLevel.Length - 1);
                        }
                        else
                        {
                            mispairedBracketsError(bracketLevel[bracketLevel.Length - 1].ToString(), ")");
                            bracketLevel = bracketLevel.Remove(bracketLevel.Length - 1);
                        }
                    }
                    else if (bracket == "]" && bracketLevel.Length > 0)
                    {
                        if (bracketLevel[bracketLevel.Length - 1].ToString() == "[")
                        {
                            bracketLevel = bracketLevel.Remove(bracketLevel.Length - 1);
                        }
                        else
                        {
                            mispairedBracketsError(bracketLevel[bracketLevel.Length - 1].ToString(), "]");
                            bracketLevel.Remove(bracketLevel.Length - 1);
                        }
                    }
                    else if (bracket == "}" && bracketLevel.Length > 0)
                    {
                        if (bracketLevel[bracketLevel.Length - 1].ToString() == "{")
                        {
                            bracketLevel = bracketLevel.Remove(bracketLevel.Length - 1);
                        }
                        else
                        {
                            mispairedBracketsError(bracketLevel[bracketLevel.Length - 1].ToString(), "}");
                            bracketLevel = bracketLevel.Remove(bracketLevel.Length - 1);
                        }
                    }
                }
            }
            catch
            {
                programError("5EB50");
            }
        }


        //Function to add the releveant error based on which types of bracets have been mispaired.
        internal static void mispairedBracketsError(string openingBracket, string closingBracket)
        {
            try
            {
                addError("You have mismatched brackets were you have opened a set of brackets with '" + openingBracket + "' and closed the set with '" + closingBracket + "'.");
            }
            catch
            {
                programError("5EB60");
            }
        }
    }
}


/*
 *          OLD CODE - NO LONGER REQUIRED
        
                    //The following if statement checks to see if brackets have been mixed
                    if ((openRound + openSquare + openBrace) == (closedRound + closedSquare + closedBrace))
                    {
                        addError("You have mixed" + typesOfBrackets(openRound, closedRound, openSquare, closedSquare, openBrace, closedBrace) + " . Each open round and sqaure bracket and brace should be paired with a bracket of the same type.");
                    }
                    else
                    {



        //Function to determine which types of brackets are used unequally
        internal static string typesOfBrackets(short a, short b, short c, short d, short e, short f)
        {
            try
            {
                string response = "";
                bool carry = false;
                if (a != b)
                {
                    response += " round '('";
                    carry = true;
                }
                if (c != d)
                {
                    if (carry == true)
                    {
                        response += " and";
                    }
                    response += " square '['";
                    carry = true;
                }
                if (carry == true)
                {
                    response += " brackets";
                }
                if (e != f)
                {
                    response += " and braces '{'";
                }
                return response;
            }
            catch
            {
                programError("508B");
                return "";
            }
        }

*/