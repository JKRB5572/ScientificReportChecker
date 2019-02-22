using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAddIn1
{
    class Variables
    {
        //Taskpane status variables
        private static bool _settingsActive = false;
        public static bool settingsActive { get { return _settingsActive; } set { _settingsActive = value; } }


        //Lists to store each paragraph's text and style

        private static List<string> _paragraphText = new List<string>();
        public static List<string> paragraphText { get { return _paragraphText; } set { _paragraphText = value; } }

        private static List<string> _paragraphStyle = new List<string>();
        public static List<string> paragraphStyle { get { return _paragraphStyle; } set { _paragraphStyle = value; } }


        //Lists to recored error report text and number of errors

        private static List<string> _errorReportHeader = new List<string>();
        public static List<string> errorReportHeader { get { return _errorReportHeader; } set { _errorReportHeader = value; } }

        private static List<string> _errorReportBody = new List<string>();
        public static List<string> errorReportBody { get { return _errorReportBody; } set { _errorReportBody = value; } }

        private static string _errorReportParagraph;
        public static string errorReportParagraph { get { return _errorReportParagraph; } set { _errorReportParagraph = value; } }

        private static short _errorCountParagraph;
        public static short errorCountParagraph { get { return _errorCountParagraph; } set { _errorCountParagraph = value; } }

        private static short _errorCountTotal;
        public static short errorCountTotal { get { return _errorCountTotal; } set { _errorCountTotal = value; } }


        //Varaibles to record recommendations

        private static string _recommendationBody;
        public static string recommendationBody { get { return _recommendationBody; } set { _recommendationBody = value; } }

        private static short _recommendationCount;
        public static short recommendationCount { get { return _recommendationCount; } set { _recommendationCount = value; } }


        //Varibles to carry errors

        private static bool _errorCarryCheckLists = false;
        public static bool errorCarryCheckLists { get { return _errorCarryCheckLists; } set { _errorCarryCheckLists = value; } }

        private static bool _errorCarryMultiplicationSign = false;
        public static bool errorCarryMultiplicationSign { get { return _errorCarryMultiplicationSign; } set { _errorCarryMultiplicationSign = value; } }

        private static bool _errorCarryDCM = false;
        public static bool errorCarryDMC { get { return _errorCarryDCM; } set { _errorCarryDCM = value; } }

        private static bool _errorCarryTHF = false;
        public static bool errorCarryTHF { get { return _errorCarryTHF; } set { _errorCarryTHF = value; } }

        private static bool _errorCarryDMF = false;
        public static bool errorCarryDMF { get { return _errorCarryDMF; } set { _errorCarryDMF = value; } }

        private static short _errorCarryGlassWare = 0;
        public static short errorCarryGlassWare { get { return _errorCarryGlassWare; } set { _errorCarryGlassWare = value; } }

        private static sbyte _errorCarryTimeWords = 0;
        public static sbyte errorCarryTimeWords { get { return _errorCarryTimeWords; } set { _errorCarryTimeWords = value; } }

        private static short _errorCarrySulfur = 0;
        public static short errorCarrySulfur { get { return _errorCarrySulfur; } set { _errorCarrySulfur = value; } }

        private static short _errorCarrySulphur = 0;
        public static short errorCarrySulphur { get { return _errorCarrySulphur; } set { _errorCarrySulphur = value; } }

        private static short _errorCarryTLC1 = 0;
        public static short errorCarryTLC1 { get { return _errorCarryTLC1; } set { _errorCarryTLC1 = value; } }

        private static short _errorCarryTLC2 = 0;
        public static short errorCarryTLC2 { get { return _errorCarryTLC2; } set { _errorCarryTLC2 = value; } }

        private static short _errorCarryTLC3 = 0;
        public static short errorCarryTLC3 { get { return _errorCarryTLC3; } set { _errorCarryTLC3 = value; } }

        private static short _errorCarryTLC4 = 0;
        public static short errorCarryTLC4 { get { return _errorCarryTLC4; } set { _errorCarryTLC4 = value; } }

        public static short _errorCarryml = 0;
        public static short errorCarryml { get { return _errorCarryml; } set { _errorCarryml = value; } }

        public static short _errorCarrymL = 0;
        public static short errorCarrymL { get { return _errorCarrymL; } set { _errorCarrymL = value; } }

        public static bool _errorCarryML = false;
        public static bool errorCarryML { get { return _errorCarryML; } set { _errorCarryML = value; } }

        public static short _errorCarrymp = 0;
        public static short errorCarrymp { get { return _errorCarrymp; } set { _errorCarrymp = value; } }

        public static short _errorCarrym_p_ = 0;
        public static short errorCarrym_p_ { get { return _errorCarrym_p_; } set { _errorCarrym_p_ = value; } }


        private static short _errorCarryCommonOperations1 = 0;
        public static short errorCarryCommonOperations1 { get { return _errorCarryCommonOperations1; } set { _errorCarryCommonOperations1 = value; } }

        private static short _errorCarryCommonOperations2 = 0;
        public static short errorCarryCommonOperations2 { get { return _errorCarryCommonOperations2; } set { _errorCarryCommonOperations2 = value; } }

        private static short _errorCarryCommonOperations3 = 0;
        public static short errorCarryCommonOperations3 { get { return _errorCarryCommonOperations3; } set { _errorCarryCommonOperations3 = value; } }

        private static short _paragraphDecrement = 0;
        public static short paragraphDecrement { get { return _paragraphDecrement; } set { _paragraphDecrement = value; } }

        private static short _paragraphNumber = 0;
        public static short paragraphNumber { get { return _paragraphNumber; } set { _paragraphNumber = value; } }

        private static string _documentSection = "none";
        public static string documentSection { get { return _documentSection; } set { _documentSection = value; } }

        private static short _errorScore = 0;
        public static short errorScore { get { return _errorScore; } set { _errorScore = value; } }

        private static short _correctScore = 0;
        public static short correctScore { get { return _correctScore; } set { _correctScore = value; } }


        //Variables to compare errors

        private static List<string> _pastCheckString = new List<string>();
        public static List<string> pastCheckString { get { return _pastCheckString; } set { _pastCheckString = value; } }

        private static List<short> _pastCheckShort = new List<short>();
        public static List<short> pastCheckShort { get { return _pastCheckShort; } set { _pastCheckShort = value; } }

        private static List<string> _presentCheckString = new List<string>();
        public static List<string> presentCheckString { get { return _presentCheckString; } set { _presentCheckString = value; } }

        private static List<short> _presentCheckShort = new List<short>();
        public static List<short> presentCheckShort { get { return _presentCheckShort; } set { _presentCheckShort = value; } }
    }
}
