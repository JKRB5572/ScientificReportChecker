using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAddIn1
{
    class Error
    {
        string _log;
        public string Log
        {
            get { return this._log; }
            set { this._log = value; }
        }

        string _reportParagraph;
        public string ReportParagraph
        {
            get { return this._reportParagraph; }
            set { this._reportParagraph = value; }
        }

        byte _countParagraph;
        public byte CountParagraph
        {
            get { return this._countParagraph; }
            set { this._countParagraph = value; }
        }

        byte _countTotal;
        public byte CountTotal
        {
            get { return this._countTotal; }
            set { this._countTotal = value; }
        }

        public struct Carry
        {
            bool _section;
            public bool Section
            {
                get { return this._section; }
                set { this._section = value; }
            }

            bool _lists;
            public bool Lists
            {
                get { return this._lists; }
                set { this._lists = value; }
            }

            bool _multiplicationSign;
            public bool MultiplicationSign
            {
                get { return this._multiplicationSign; }
                set { this._multiplicationSign = value; }
            }

            byte _paragraphDecrement;
            public byte ParagraphDecrement
            {
                get { return this._paragraphDecrement; }
                set { this._paragraphDecrement = value; }
            }
        }

        public struct Recommendations
        {
            string _report;
            public string Report
            {
                get { return this._report; }
                set { this._report = value; }
            }

            byte _count;
            public byte Count
            {
                get { return this._count; }
                set { this._count = value; }
            }
        }
    }
}