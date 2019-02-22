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
        public TaskPaneInterface()
        {
            ;
            InitializeComponent();

            //Determine which UI objects to display

            if (Properties.Settings.Default.Setting_termsAccepted == false)
            {
                performChecksButton.Visible = settingsButton.Visible = errorOutputArea.Visible = false;
            }
            else
            {
                disclaimerAccept.Visible = disclaimer.Visible = false;
            }

            buildVersion.Visible = settingsTitle.Visible = settingsText.Visible = settingsEntryField.Visible = settingsSubmitButton.Visible = settingsOutputText.Visible = settingsRestoreDefaults.Visible = settingsViewDisclaimer.Visible = false;
        }


        internal void performChecksButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Remove previous text from rich text box
                errorOutputArea.Text = "";

                Resets.resetVariables();

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
                            Resets.resetErrors();

                            //Operations to be performed

                            Error_Brackets.checkBrackets(paragraph);
                            Error_Functions.checkAnd(paragraph);
                            if (Properties.Settings.Default.Setting_firstPerson == true) { Error_Functions.checkFristPerson(paragraph); }
                            if (Properties.Settings.Default.Setting_degreeSymbol == true) { Error_Functions.checkDegreeSymbol(paragraph); }
                            if (Properties.Settings.Default.Setting_decimalPlaces == true) { Error_Functions.checkDecimalPlaces(paragraph); }
                            if (Properties.Settings.Default.Setting_lists == true) { Recommendation_Functions.checkLists(); }
                            if (Properties.Settings.Default.Setting_multiplicationSymbol == true) { Recommendation_Functions.checkMultiplicationSign(paragraph); }
                            if (Properties.Settings.Default.Setting_glassware == true) { Recommendation_Functions.checkGlassWare(paragraph); }
                            if (Properties.Settings.Default.Setting_sequenceWords == true) { Recommendation_Functions.checkSequenceWords(paragraph); }
                            if (Properties.Settings.Default.Setting_imperatives == true) { Recommendation_Functions.checkImperatives(paragraph); }
                            if (Properties.Settings.Default.Setting_commonOperations == true) { Error_Common_Operations.logCommonOperations(paragraph); }
                            if (Properties.Settings.Default.Setting_DMC_THF_DMF == true) { Recommendation_Functions.checkDMC_THF_DMF(paragraph); }
                            if (Properties.Settings.Default.Setting_pH == true) { Error_Functions.checkpH(paragraph); }
                            Recommendation_Functions.checkML(paragraph);
                            if (Properties.Settings.Default.Setting_paragraphLength > 0) { Recommendation_Functions.checkParagraphLength(paragraph); }
                            //For the following function the checks for if the operation is enabled is contained within the function
                            Error_Inconsistencies.logInconsitencies(paragraph);


                            Basic_Functions.appendErrorHeader();
                        }
                        else
                        {
                            documentSection = Basic_Functions.checkDocumentSection(documentSection, paragraph);
                        }
                    }
                }
                if (Properties.Settings.Default.Setting_commonOperations == true) { Error_Common_Operations.checkCommonOperations(); }
                Error_Inconsistencies.checkInconsitencies();

                //Return complete error report
                if (documentSection == "none")
                {
                    errorOutputArea.AppendText("There is no 'Experimental' or 'Methods' heading. You should add an 'Experimental' heading to the section of your document that describes the experimental procedures in detail.", Color.Red, new Font("Segoe UI Symbol", 10));
                }
                else
                {
                    if (errorCountTotal == 0 && recommendationCount == 0)
                    {
                        errorOutputArea.AppendText("No errors were found", Color.Green, new Font("Segoe UI Symbol", 11));
                    }
                    else
                    {
                        errorOutputArea.AppendText("Report Summary: ", Color.DodgerBlue, new Font("Segoe UI Symbol", 10, FontStyle.Bold));
                        errorOutputArea.AppendText(Basic_Functions.errorsAndRecommendationsHeader(), Color.Black, new Font("Segoe UI Symbol", 10));
                        if (errorCountTotal > 0)
                        {
                            for (int i = 0; i < errorReportBody.Count; i++)
                            {
                                errorOutputArea.AppendText(errorReportHeader[i] + "\n", Color.Red, new Font("Segoe UI Symbol", 11));
                                errorOutputArea.AppendText(errorReportBody[i], Color.Black, new Font("Segoe UI Symbol", 10));
                            }
                        }
                        //Return recommendation report
                        if (recommendationCount > 0)
                        {
                            errorOutputArea.AppendText("\nRecommendations\n\n", Color.Orange, new Font("Segoe UI Symbol", 11));
                            errorOutputArea.AppendText(recommendationBody, Color.Black, new Font("Segoe UI Symbol", 10));
                        }
                    }
                    if (pastCheckShort.Count - presentCheckShort.Count == 1)
                    {
                        errorOutputArea.AppendText("\nThe following error was corrected: -\n\n", Color.Green, new Font("Segoe UI Symbol", 12));

                        short i = 0;
                        foreach (string _ in pastCheckString)
                        {
                            if (presentCheckString.Contains(_) == false)
                            {
                                if (pastCheckShort[i] == -1)
                                {
                                    errorOutputArea.AppendText(_ + "\n\n", Color.Black, new Font("Segoe UI Symbol", 10));
                                    break;
                                }
                                else
                                {
                                    errorOutputArea.AppendText(_ + " in pragraph " + pastCheckShort[i] + "\n\n", Color.Black, new Font("Segoe UI Symbol", 10));
                                    break;
                                }
                            }
                            i++;
                        }
                    }
                    else if (pastCheckShort.Count > presentCheckShort.Count)
                    {
                        errorOutputArea.AppendText("\nThe following errors were corrected: -\n\n", Color.Green, new Font("Segoe UI Symbol", 12));

                        short i = 0;
                        foreach (string _ in pastCheckString)
                        {
                            if (presentCheckString.Contains(_) == false)
                            {
                                if (pastCheckShort[i] == -1)
                                {
                                    errorOutputArea.AppendText(_ + "\n\n", Color.Black, new Font("Segoe UI Symbol", 10));
                                }
                                else
                                {
                                    errorOutputArea.AppendText(_ + " in paragraph " + pastCheckShort[i] + "\n\n", Color.Black, new Font("Segoe UI Symbol", 10));
                                }
                            }
                            i++;
                        }
                    }
                }
            }
            catch
            {
                Basic_Functions.criticalError("Basic Operations Failed");
            }
        }

        internal void TaskPaneInterface_Load(object sender, EventArgs e)
        {

        }

        internal void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (disclaimerAccept.Checked == true)
            {
                disclaimerAccept.Visible = disclaimer.Visible = false;
                performChecksButton.Visible = settingsButton.Visible = errorOutputArea.Visible = true;
                Properties.Settings.Default.Setting_termsAccepted = true;
                Properties.Settings.Default.Save();
            }
        }

        internal void settingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (settingsActive == false)
                {
                    settingsActive = true;
                    errorOutputArea.Visible = performChecksButton.Visible = false;
                    buildVersion.Visible = settingsTitle.Visible = settingsText.Visible = settingsEntryField.Visible = settingsSubmitButton.Visible = settingsOutputText.Visible = settingsRestoreDefaults.Visible = settingsViewDisclaimer.Visible = true;
                }
                else
                {
                    settingsActive = false;
                    errorOutputArea.Visible = performChecksButton.Visible = true;
                    buildVersion.Visible = settingsTitle.Visible = settingsText.Visible = settingsEntryField.Visible = settingsSubmitButton.Visible = settingsOutputText.Visible = settingsRestoreDefaults.Visible = settingsViewDisclaimer.Visible = false;
                }
            }
            catch
            {
                Basic_Functions.criticalError("Settings Load Failed");
            }
        }

        internal void settingsSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (settingsEntryField.Text == "000000")
                {
                    OperationsToPerform.defaultSettings();
                    Resets.resetPastCheck();
                    errorOutputArea.Text = "";
                    settingsOutputText.Text = "Settings Updated";
                }
                else if (settingsEntryField.Text == "999999")
                {
                    OperationsToPerform.allOff();
                    Resets.resetPastCheck();
                    errorOutputArea.Text = "";
                    settingsOutputText.Text = "Settings Updated";
                }
                else if (Basic_Functions.checkRegexpBool(settingsEntryField.Text, @"[1-8]{4}[1-4][0-9]") == true)
                {
                    OperationsToPerform.customSettings(settingsEntryField.Text);
                    Resets.resetPastCheck();
                    errorOutputArea.Text = "";
                    settingsOutputText.Text = "Settings Updated";
                }
                else if (settingsEntryField.Text == "")
                {
                    settingsOutputText.Text = "No code has been entered";
                }
                else if (settingsEntryField.Text.Length < 6)
                {
                    settingsOutputText.Text = "Code is too short";
                }
                else {
                    settingsOutputText.Text = "Incorrect Code";
                }
                Properties.Settings.Default.Save();
            }
            catch
            {
                Basic_Functions.criticalError("Settings Save Failed");
            }
        }

        internal void settingsEntryField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                settingsSubmitButton_Click(sender, e);
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                settingsOutputText.Text = "";
            }
        }

        private void settingsEntryField_Click(object sender, EventArgs e)
        {
            settingsOutputText.Text = "";
        }

        private void settingsRestoreDefaults_Click(object sender, EventArgs e)
        {
            OperationsToPerform.defaultSettings();
            Resets.resetPastCheck();
            errorOutputArea.Text = "";
            settingsOutputText.Text = "Default Settings Restored";
        }

        private void settingsViewDisclaimer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("The following automated tool provides advisory feedback only, with the purpose of allowing you to improve your writing style in the experimental section of synthetic chemistry laboratory reports.The tool checks for some common mistakes in style and formatting, but it cannot check your procedures for accuracy or chemical correctness.Using this tool does not guarantee that your mark will increase.Whilst using this tool you accept full responsibility for any changes that you make to your reports and / or assessments.", "Disclaimer", MessageBoxButtons.OK);
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
