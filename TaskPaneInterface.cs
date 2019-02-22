using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Office.Tools.Word;
using static WordAddIn1.Variables;

namespace WordAddIn1
{
    public partial class TaskPaneInterface : UserControl
    {
        Functions f = new Functions();

        public TaskPaneInterface()
        {
            ;
            InitializeComponent();
            button1.Visible = false;
            richTextBox1.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Remove previous text from rich text box
            richTextBox1.Text = "";

            f.resetVariables();

            string documentSection = "none";


            foreach (Microsoft.Office.Interop.Word.Paragraph paragraph in Globals.ThisAddIn.Application.ActiveDocument.Paragraphs)
            {
                paragraphText.Add(paragraph.Range.Text);
                paragraphStyle.Add(paragraph.get_Style().NameLocal);
            }

            //Parse through each paragraph preforming checks
            foreach (string paragraph in paragraphText)
            {
                paragraphNumber++;

                //Check the section of the document
                //If not experiment section search for experiment header
                if (documentSection != "conclusion")
                {
                    if (documentSection == "experimental")
                    {
                        //Perform checks
                        f.resetErrors();

                        //Errors to be checked
                        f.checkBrackets(paragraph);
                        f.checkImpersonalLanguage(paragraph);
                        f.checkAnd(paragraph);
                        f.checkDegreeSymbol(paragraph);
                        f.checkDecimalPlaces(paragraph);
                        //Recommendations to be checked
                        f.checkLists();
                        f.checkMultiplicationSign(paragraph);
                        f.checkGlassWare(paragraph);
                        f.checkTimeWords(paragraph);
                        //
                        f.checkTense(paragraph);
                        f.logInconsitencies(paragraph);
                        f.logCommonOperations(paragraph);
                        //
                        f.appendErrorHeader();
                    }
                    else
                    {
                        documentSection = f.checkDocumentSection(documentSection, paragraph);
                    }
                }
            }
            f.checkInconsitencies();
            f.checkCommonOperations();

            //Return complete error report
            if (documentSection == "none")
            {
                richTextBox1.AppendText("There is no experiment header. You must add an experiment header", Color.Red, new Font("Segoe UI Symbol", 12));
            }
            else
            {
                if (errorCountTotal == 0 && recommendationCount == 0)
                {
                    richTextBox1.AppendText("No errors were found", Color.Green, new Font("Segoe UI Symbol", 12));
                }
                else
                {
                    if (errorCountTotal == 1)
                    {
                        richTextBox1.AppendText("1 error was found\n", Color.Red, new Font("Segoe UI Symbol", 12));
                        richTextBox1.AppendText(errorReportHeader[0], Color.Red, new Font("Seogoe UI Symbol", 10, FontStyle.Bold));
                        richTextBox1.AppendText(errorReportBody[0], Color.Black, new Font("Segoe UI Symbol", 10));
                    }
                    else if (errorCountTotal > 1)
                    {
                        richTextBox1.AppendText(errorCountTotal + " errors were found\n", Color.Red, new Font("Segoe UI Symbol", 12)); 
                        for (int i = 0; i < errorReportBody.Count; i++)
                        {
                            richTextBox1.AppendText(errorReportHeader[i], Color.Red, new Font("Segoe UI Symbol", 10, FontStyle.Bold));
                            richTextBox1.AppendText(errorReportBody[i], Color.Black, new Font("Segoe UI Symbol", 10));
                        }
                    }
                }
                //Return recommendation report
                if (recommendationCount > 0)
                {
                    richTextBox1.AppendText("\nRecommendations\n", Color.Orange, new Font("Segoe UI Symbol", 12));
                    richTextBox1.AppendText(recommendationBody, Color.Black, new Font("Segoe UI Symbol", 10));
                }
                if (pastCheck.Count - presentCheck.Count == 1)
                {
                    richTextBox1.AppendText("\n\nThe follwoing error was corrected: -\n\n", Color.Green, new Font("Segoe UI Symbol", 12));
                    foreach (string _ in pastCheck)
                    {
                        if (presentCheck.Contains(_) == false)
                        {
                            richTextBox1.AppendText(_.Substring(1) + " in paragraph " + _.Substring(0, 1) + "\n", Color.Black, new Font("Segoe UI Symbol", 10));
                            break;
                        }
                    }
                }
                else if (pastCheck.Count > presentCheck.Count)
                {
                    richTextBox1.AppendText("\n\nThe following errors were corrected: -\n\n", Color.Green, new Font("Segoe UI Symbol", 12));
                    foreach (string _ in pastCheck)
                    {
                        if (presentCheck.Contains(_) == false)
                        {
                            richTextBox1.AppendText(_.Substring(1) + " in paragraph " + _.Substring(0, 1) + "\n", Color.Black, new Font("Segoe UI Symbol", 10));
                        }
                    }
                }
                //
                /*
                richTextBox1.AppendText("\n\n\nFlags: -\n\n");

                richTextBox1.AppendText("Error score: " + errorScore);
                richTextBox1.AppendText(" Correct score: " + correctScore);
                richTextBox1.AppendText("\nTime Words: " + errorCarryTimeWords);
                richTextBox1.AppendText("\nParagraph Number: " + paragraphNumber);
                richTextBox1.AppendText(" Paragraph Decrement: " + paragraphDecrement);
                */
            }
        }

        private void TaskPaneInterface_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Visible = false;
                label2.Visible = false;
                richTextBox1.Visible = true;
                button1.Visible = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    //Extension to change the text color of rich text boxes
    //Sourced from: https://stackoverflow.com/questions/1926264/color-different-parts-of-a-richtextbox-string
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.SelectionFont = font;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
