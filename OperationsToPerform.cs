using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WordAddIn1.Properties.Settings;
using static WordAddIn1.Basic_Functions;

namespace WordAddIn1
{
    //The following class determines which checks to perform based off of which checks have been enabled via the settings menu
    class OperationsToPerform
    {
        internal static void defaultSettings(bool changeTermStatus = true)
        {
            Default.Setting_paragraphLength = 300;
            Default.Setting_glassware = true;
            Default.Setting_decimalPlaces = true;
            Default.Setting_sequenceWords = true;
            Default.Setting_sulfur = true;
            Default.Setting_commonOperations = true;
            Default.Setting_firstPerson = true;
            Default.Setting_degreeSymbol = true;
            Default.Setting_imperatives = true;
            Default.Setting_lists = true;
            Default.Setting_multiplicationSymbol = true;
            Default.Setting_mp = true;
            Default.Setting_DMC_THF_DMF = true;
            Default.Setting_pH = true;
            Default.Setting_tlc = true;

            if (changeTermStatus == true)
            {
                Default.Setting_termsAccepted = false;
            }
        }


        internal static void allOff()
        {
            Default.Setting_paragraphLength = 0;
            Default.Setting_glassware = false;
            Default.Setting_decimalPlaces = false;
            Default.Setting_sequenceWords = false;
            Default.Setting_sulfur = false;
            Default.Setting_commonOperations = false;
            Default.Setting_firstPerson = false;
            Default.Setting_degreeSymbol = false;
            Default.Setting_imperatives = false;
            Default.Setting_lists = false;
            Default.Setting_multiplicationSymbol = false;
            Default.Setting_mp = false;
            Default.Setting_DMC_THF_DMF = false;
            Default.Setting_pH = false;
            Default.Setting_tlc = false;
        }


        internal static void customSettings(string settingsString)
        {
            defaultSettings(false);

            if (settingsString[0].ToString() == "1")
            {
                Default.Setting_firstPerson = false;
                Default.Setting_degreeSymbol = false;
                Default.Setting_decimalPlaces = false;
            }
            else
            {
                if (checkRegexpBool(settingsString[0].ToString(), @"3|4|6") == true)
                {
                    Default.Setting_firstPerson = false;
                }
                if (checkRegexpBool(settingsString[0].ToString(), @"2|4|7") == true)
                {
                    Default.Setting_degreeSymbol = false;
                }
                if (checkRegexpBool(settingsString[0].ToString(), @"2|3|5") == true)
                {
                    Default.Setting_decimalPlaces = false;
                }
            }

            if (settingsString[1].ToString() == "1")
            {
                Default.Setting_multiplicationSymbol = false;
                Default.Setting_glassware = false;
                Default.Setting_sequenceWords = false;
            }
            else
            {
                if (checkRegexpBool(settingsString[1].ToString(), @"3|4|6") == true)
                {
                    Default.Setting_multiplicationSymbol = false;
                }
                if (checkRegexpBool(settingsString[1].ToString(), @"2|4|7") == true)
                {
                    Default.Setting_glassware = false;
                }
                if (checkRegexpBool(settingsString[1].ToString(), @"2|3|5") == true)
                {
                    Default.Setting_sequenceWords = false;
                }
            }

            if (settingsString[2].ToString() == "1")
            {
                Default.Setting_imperatives = false;
                Default.Setting_commonOperations = false;
                Default.Setting_lists = false;
            }
            else
            {
                if (checkRegexpBool(settingsString[2].ToString(), @"3|4|6") == true)
                {
                    Default.Setting_imperatives = false;
                }
                if (checkRegexpBool(settingsString[2].ToString(), @"2|4|7") == true)
                {
                    Default.Setting_commonOperations = false;
                }
                if (checkRegexpBool(settingsString[2].ToString(), @"2|3|5") == true)
                {
                    Default.Setting_lists = false;
                }
            }

            if (settingsString[3].ToString() == "1")
            {
                Default.Setting_DMC_THF_DMF = false;
                Default.Setting_pH = false;
                Default.Setting_sulfur = false;
            }
            else
            {
                if (checkRegexpBool(settingsString[3].ToString(), @"3|4|6") == true)
                {
                    Default.Setting_DMC_THF_DMF = false;
                }
                if (checkRegexpBool(settingsString[3].ToString(), @"2|4|7") == true)
                {
                    Default.Setting_pH = false;
                }
                if (checkRegexpBool(settingsString[3].ToString(), @"2|3|5") == true)
                {
                    Default.Setting_sulfur = false;
                }
            }

            if (settingsString[4].ToString() == "1")
            {
                Default.Setting_mp = false;
                Default.Setting_tlc = false;
            }
            else
            {
                if (checkRegexpBool(settingsString[4].ToString(), @"3|4|6") == true)
                {
                    Default.Setting_mp = false;
                }
                if (checkRegexpBool(settingsString[4].ToString(), @"2|4|7") == true)
                {
                    Default.Setting_tlc = false;
                }
            }

            if (settingsString[5].ToString() == "0")
            {
                Properties.Settings.Default.Setting_paragraphLength = 0;
            }
            else
            {
                string lengthAsString = settingsString[5].ToString();
                short lengthAsNumber = 0;
                Int16.TryParse(lengthAsString, out lengthAsNumber);
                lengthAsNumber *= 50;
                lengthAsNumber += 50;
                Default.Setting_paragraphLength = (lengthAsNumber);
            }
        }
    }
}
