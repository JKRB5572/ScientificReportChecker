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
    //The folllowing class contains functions that log and then compare uses of key words across the document to ensure that there are no inconsitencies in the spelling of these key words

    class Error_Inconsistencies
    {
        //Function to log potential inconsitencies
        internal static void logInconsitencies(string paragraph)
        {
            try
            {
                errorCarrySulfur += (short)Regex.Matches(paragraph.ToLower(), @"sulfur|sulfonyl|sulfate|sulfite|sulfuric|sulfonate|sulfonic|sulfide").Count;
                errorCarrySulphur += (short)Regex.Matches(paragraph.ToLower(), @"sulphur|sulphonyl|sulphate|sulphite|sulphuric|sulphonate|sulphonic|sulphide").Count;
                if (Properties.Settings.Default.Setting_tlc == true)
                {
                    errorCarryTLC1 += (short)Regex.Matches(paragraph, @"TLC").Count;
                    errorCarryTLC2 += (short)Regex.Matches(paragraph, @"T.L.C.").Count;
                    errorCarryTLC3 += (short)Regex.Matches(paragraph, @"tlc").Count;
                    errorCarryTLC4 += (short)Regex.Matches(paragraph, @"t.l.c.").Count;
                }
                errorCarryml += (short)Regex.Matches(paragraph, @"\d ?ml\W").Count;
                errorCarrymL += (short)Regex.Matches(paragraph, @"\d ?mL\W").Count;
                errorCarrymp += (short)Regex.Matches(paragraph, @"(\d | )mp\W").Count;
                errorCarrymp += (short)Regex.Matches(paragraph, @"(\d | )m\.p\.\W").Count;
            }
            catch
            {
                programError("5EI00");
            }
        }


        //Function to check all logged potential inconsitencies
        internal static void checkInconsitencies()
        {
            try
            {
                //Checks sulfur and varations are spelled consistently
                if (errorCarrySulfur > 0 && errorCarrySulphur > 0)
                {
                    addError("Inconsistent use of sulfur and sulphur");
                    errorReportHeader.Add(" ");
                    errorReportBody.Add("Inconsistent spelling of 'sulfur' and 'sulphur'. The official IUPAC spelling is 'sulfur', but whichever spelling you choose, it should be consistent throughout your document.");
                }
                else if (Properties.Settings.Default.Setting_sulfur == true)
                {
                    if (errorCarrySulphur > 0)
                    {
                        addRecommendation("It is recommended that you spell 'sulphur' as 'sulfur'. The 'f' spelling has been adopted by the International Union of Pure and Applied Chemistry (IUPAC).");
                    }
                }


                //Checks tlc is spelled consistently
                if (Properties.Settings.Default.Setting_tlc == true)
                {
                    string tlcError = "";
                    if (errorCarryTLC1 > 0) { tlcError += "t"; } else { tlcError += "f"; }
                    if (errorCarryTLC2 > 0) { tlcError += "t"; } else { tlcError += "f"; }
                    if (errorCarryTLC3 > 0) { tlcError += "t"; } else { tlcError += "f"; }
                    if (errorCarryTLC4 > 0) { tlcError += "t"; } else { tlcError += "f"; }

                    byte tlcErrors = (byte)checkRegexpShort(tlcError, @"t");


                    //If there is an error the following if statements determine those inconsistencies and how the error sentence should be construced to correctly reflect those inconsistencies
                    if (tlcErrors > 1)
                    {

                        string error = "You have used ";

                        if (tlcErrors == 2)
                        {
                            bool carry = false;
                            if (errorCarryTLC1 > 0)
                            {
                                error += "TLC and ";
                                carry = true;
                            }
                            if (errorCarryTLC2 > 0)
                            {
                                error += "T.L.C. ";
                                if (carry == false) { carry = true; error += "and "; }
                            }
                            if (errorCarryTLC3 > 0)
                            {
                                error += "tlc ";
                                if (carry == false) { error += "and "; }
                            }
                            if (errorCarryTLC4 > 0)
                            {
                                error += "t.l.c.";
                            }
                        }
                        else if (tlcErrors == 3)
                        {
                            byte carry = 0;
                            if (errorCarryTLC1 > 0)
                            {
                                error += "TLC, ";
                                carry = 1;
                            }
                            if (errorCarryTLC2 > 0)
                            {
                                error += "T.L.C. ";
                                if (carry == 1) { error += "and "; carry = 2; } else { error += ", "; }
                            }
                            if (errorCarryTLC3 > 0)
                            {
                                error += "tlc ";
                                if (carry != 2) { error += "and "; }
                            }
                            if (errorCarryTLC4 > 0)
                            {
                                error += "t.l.c.";
                            }
                        }
                        else if (tlcErrors == 4)
                        {
                            error += "TLC, T.L.C., tlc and t.l.c.";
                        }
                        error += " throughout your report. Any one variant is fine, but using multiple variants throughout makes your report inconsistent.";
                        addRecommendation(error);
                    }
                }


                //Checks to see that ml is spelled consistenetly
                if (errorCarryml > 0 && errorCarrymL > 0 && errorCarryML == false)
                {
                    addRecommendation("You have used both 'ml' and 'mL' as a unit label. For consitency you should use only one.");
                }

                //Checks to see that mp is spelled consistently
                if (errorCarrymp > 0 && errorCarrym_p_ > 0)
                {
                    addRecommendation("You have used both 'mp' and 'm.p.'. For consistency you should use only one. m.p. is prefered");
                }
                else if (Properties.Settings.Default.Setting_mp == true)
                {
                    if (errorCarrymp > 0)
                    {
                        addRecommendation("It is recommended that you change 'mp' to 'm.p.'");
                    }
                }
            }
            catch
            {
                programError("5EI10");
            }
        }
    }
}
