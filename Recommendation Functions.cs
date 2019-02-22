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
    class Recommendation_Functions
    {
        //Function to check glass ware is not listed
        internal static void checkGlassWare(string paragraph)
        {
            try
            {
                if (errorCarryGlassWare != -1)
                {
                    sbyte _ = (sbyte)Regex.Matches(paragraph.ToLower(), @"conical ?flask|round ?bottome?d? flask|measuring cylinder|funnel|flask|beaker|seperating ?funnel|spatula|balance").Count;
                    errorCarryGlassWare += _;
                    if (errorCarryGlassWare > 2)
                    {
                        addRecommendation("It is unnecessary to describe common items of glassware in detail. You can usually assume that chemists would choose an appropriate flask or beaker.");
                        errorCarryGlassWare = -1;
                    }
                }
            }
            catch
            {
                programError("5RF00");
            }
        }


        //Function to check that time and sequence words/phrases are not overused
        internal static void checkSequenceWords(string paragraph)
        {
            try
            {
                if (errorCarryTimeWords != -1)
                {
                    sbyte _ = (sbyte)Regex.Matches(paragraph.ToLower(), @"after|next|following|subsequently|once this|then|finally|to start with").Count;
                    errorCarryTimeWords += _;
                    if (errorCarryTimeWords > paragraphNumber + paragraphDecrement)
                    {
                        addRecommendation("Describe the method in chronological order. Keep it concise by not overusing words and phrases such as 'first', 'then', 'next', 'after this had been done' etc.");
                        errorCarryTimeWords = -1;
                    }
                }
            }
            catch
            {
                programError("5RF10");
            }
        }


        //Function to check imperatives are used
        internal static void checkImperatives(string paragraph)
        {
            try
            {
                //Constructs two dictionaries, one of correct phrases and one of incorrect phrases
                List<string> errorDictionary = new List<string>();

                errorDictionary.Add(@" ?[Ww]ere then ");
                errorDictionary.Add(@" ?[Aa]nd then ");
                errorDictionary.Add(@" ?[Ww]as then ");
                errorDictionary.Add(@" ?[Bb]ecause of the ");
                errorDictionary.Add(@" ?[Aa]dd ");

                List<string> correctDictionary = new List<string>();
                correctDictionary.Add(@" ?[Aa] mixture ");
                correctDictionary.Add(@" ?[Ss]till bound to ");
                correctDictionary.Add(@" ?[Bb]ecause the ");
                correctDictionary.Add(@" ?[Aa]dded ");


                //Caluclates the uses of correct and incorrect phrases to produce a correct score and an error score
                foreach (string regexp in errorDictionary)
                {
                    errorScore -= checkRegexpShort(paragraph, regexp);
                }
                foreach (string regexp in correctDictionary)
                {
                    correctScore += checkRegexpShort(paragraph, regexp);
                }

                //If the score is negative add recommendation
                if (errorScore + correctScore < 0)
                {
                    addRecommendation("The experimental method should describe what you did, rather than being written as a set of instructions. For example, instead of saying 'Add compound A to compound B', write 'Compound A was added to compound B'.");
                }
            }
            catch
            {
                programError("5RF20");
            }
        }


        //Function to check that no lists are used
        internal static void checkLists()
        {
            try
            {
                if (paragraphStyle[paragraphNumber - 1] == "List Paragraph")
                {
                    if (errorCarryCheckLists == false)
                    {
                        addRecommendation("It is recommended that you do not use numbered, bulleted and alphabetical lists. Experimental methods are usually written as paragraphs of continuous text.");
                        paragraphDecrement--;
                        errorCarryCheckLists = true;
                    }
                    else
                    {
                        paragraphDecrement--;
                    }
                }
            }
            catch
            {
                programError("5RF30");
            }
        }


        //Function to check multiplication sign is used instead of "x" or "X"
        internal static void checkMultiplicationSign(string paragraph)
        {
            try
            {
                if (errorCarryMultiplicationSign == false)
                {
                    if (checkRegexpBool(paragraph, @"\d+ ?x ?\d+") == true)
                    {
                        addRecommendation("You should use the multiplication sign (\u00D7) instead of the letter 'x'. You can find the × sign from the Insert Symbol menu in Word. You can also hold down the Alt key and type 0215 on the numeric keypad.");
                        errorCarryMultiplicationSign = true;
                    }
                    else if (checkRegexpBool(paragraph, @"\d+ ?x ?\d+") == true)
                    {
                        addRecommendation("You should use the multiplication sign (\u00D7) instead of the letter 'X'. You can find the × sign from the Insert Symbol menu in Word. You can also hold down the Alt key and type 0215 on the numeric keypad.");
                        errorCarryMultiplicationSign = true;
                    }
                }
            }
            catch
            {
                programError("5RF40");
            }
        }


        //Function to check paragraphLength
        internal static void checkParagraphLength(string paragraph)
        {
            try
            {
                short currentParagraphLength = (short)paragraph.Split().Length;
                if (currentParagraphLength > Properties.Settings.Default.Setting_paragraphLength)
                {
                    addRecommendation("Paragraph " + (paragraphNumber + paragraphDecrement) + " is quite long. Are there any unnecessary details or words that could be removed? Experimental methods should be concise, but still give sufficient detail to reproduce the procedure.");
                }
            }
            catch
            {
                programError("5RF50");
            }
        }


        //Function to check DCM, THF, DMF are capatalised
        internal static void checkDMC_THF_DMF(string paragraph)
        {
            try
            {
                if (errorCarryDMC == false)
                {
                    if (checkRegexpBool(paragraph, @"(dcm|Dcm|dCm|dcM|DCm|DcM|dCM)\W") == true)
                    {
                        addRecommendation("There are occasions in your report when you do not capatalise DCM. DCM should always be capatalise.");
                        errorCarryDMC = true;
                    }
                }
                if (errorCarryTHF == false)
                {
                    if (checkRegexpBool(paragraph, @"(thf|Thf|tHf|thF|THf|ThF|tHF)\W") == true)
                    {
                        addRecommendation("There are occasions in your report when you do not capatalise THF. THF should always be capatalised.");
                        errorCarryTHF = true;
                    }
                }
                if (errorCarryDMF == false)
                {
                    if (checkRegexpBool(paragraph, @"(dmf|Dmf|dMf|dmF|DMf|DmF|dMF)\W") == true)
                    {
                        addRecommendation("There are occasions in your report when you do not capatalise DMF. DMF shoudl always be capatalised.");
                        errorCarryDMF = false;
                    }
                }
            }
            catch
            {
                programError("5RF60");
            }
        }

        //Function to check that ML is not used a unit
        internal static void checkML(string paragraph)
        {
            try
            {
                if (errorCarryML == false)
                {
                    if (checkRegexpBool(paragraph, @"\d ?ML\W") == true)
                    {
                        addRecommendation("'ML' should not be used as a unit label, use 'ml' or 'mL' instead.");
                        errorCarryML = true;
                    }
                }
            }
            catch
            {
                programError("5ER70");
            }
        }
    }
}
