using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Interop.Word;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace WordAddIn1
{
    public partial class Ribbon1
    {
        internal void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        internal void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.taskPane.Visible = true;
        }
    }
}
