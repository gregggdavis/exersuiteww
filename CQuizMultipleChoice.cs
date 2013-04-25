using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

using Leadit.ExtendedDataGrid;


namespace BrowserApp
{
    /// <summary>
    /// Summary description for CQuizMultipleChoice.
    /// </summary>
    public class CQuizMultipleChoice : CQuiz

    {
        public CQuizMultipleChoice(ref DataGrid dataGridCurrent, ref DataTable dTableCurrent) : base(ref dataGridCurrent, ref dTableCurrent)
        {
            //
            // TODO: Add constructor logic here
            //

            sCurrentJsQuizType = "MultipleChoice";

            InitializeGrid(ref dataGridCurrent, ref dTableCurrent);
        }



        /// <summary>
        ///
        /// </summary>
        public override void InitializeGrid(ref DataGrid dataGridCurrent, ref DataTable dTableCurrent)
        {
            dTableCurrent = new DataTable ("DataTable" + GetQuizType());

            dataGridCurrent.DataSource = dTableCurrent;
            dataGridCurrent.TableStyles.Clear();

            // Add a GridTableStyle and set the MappingName 
            // to the name of the DataTable.
            DataGridTableStyle dgdtblStyle = new DataGridTableStyle();
            dgdtblStyle.RowHeadersVisible  = false;
            dgdtblStyle.MappingName = dTableCurrent.TableName;
            dgdtblStyle.AllowSorting = false;



            for (int i = 0;  i < 4;  i++) 
            {
                dTableCurrent.Columns.Add("Column" + (i+1).ToString(), System.Type.GetType("System.String"));
            }

            // Add a GridColumnStyle and set the MappingName 
            // to the name of a DataColumn in the DataTable. 
            // Set the HeaderText and Width properties. 
            ExtendedDataGridMultiLineTextBoxColumn tbc1 = new ExtendedDataGridMultiLineTextBoxColumn();
            tbc1.MappingName = "Column1";
            tbc1.TextBox.Multiline = true;
            tbc1.MinimumHeight = 35;
            tbc1.HeaderText = "Question Phrase";
            tbc1.Width = 310;
            tbc1.NullText = "<type question here>";

            dgdtblStyle.GridColumnStyles.Add(tbc1);

            ExtendedDataGridMultiLineTextBoxColumn tbc2 = new ExtendedDataGridMultiLineTextBoxColumn();
            tbc2.MappingName = "Column2";
            tbc2.HeaderText = "Choices";
            tbc2.TextBox.Multiline = true;
            tbc2.MinimumHeight = 35;
            tbc2.Width = 220;
            tbc2.NullText = "<type choices here>";

            dgdtblStyle.GridColumnStyles.Add(tbc2);

            ExtendedDataGridMultiLineTextBoxColumn tbc3 = new ExtendedDataGridMultiLineTextBoxColumn();
            tbc3.MappingName = "Column3";
            tbc3.HeaderText = "Feedback";
            tbc3.TextBox.Multiline = true;
            tbc3.MinimumHeight = 35;
            tbc3.Width = 310;
            tbc3.NullText = "<type feedback here>";

            dgdtblStyle.GridColumnStyles.Add(tbc3);

            DataGridTextBoxColumn tbc4 = new DataGridTextBoxColumn();
            tbc4.MappingName = "Column4";
            tbc4.HeaderText = "Answer(a...d)";
            tbc4.Width = 84;
            tbc4.NullText = "<insert letter>";

            dgdtblStyle.GridColumnStyles.Add(tbc4);

            //
            // Tie our keypress handler to the textbox's KeyPress event.
            //
            DataGridTextBoxColumn tbcHandler = (DataGridTextBoxColumn)dgdtblStyle.GridColumnStyles[3];
            tbcHandler.TextBox.KeyPress += new KeyPressEventHandler(DatagridPositionKeyPress);


            
            // Add the DataGridTableStyle instance to the GridTableStylesCollection. 
            dataGridCurrent.TableStyles.Add(dgdtblStyle);

            dataGridCurrent.Visible = true;
        }



        /// <summary>
        /// Keypress handler for date values.
        /// </summary>
        public override void DatagridPositionKeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 'a') && (e.KeyChar <= 'd'))
                ||  ((e.KeyChar >= 'A') && (e.KeyChar <= 'D'))
                ||  (e.KeyChar == '\r')
                ||  (e.KeyChar == '\b')) 
            {
                e.Handled = false;
                //DataGridColumnStyle dgc = dataGridQuestions.TableStyles[0].GridColumnStyles[1];
                //dataGridQuestions.EndEdit(dgc, 0, false);
            } 
            else 
            {
                e.Handled = true;
            }
        }



        /// <summary>
        ///
        /// </summary>
        public override void FillGridWithJavascriptData(ref DataGrid dataGridCurrent, ref DataTable dTableCurrent, string sJavascriptData, TabControl tabData)
        {

            string sNumQuestions = GetLastMatchedString(sJavascriptData, "numQues=", ";");
            string sNumChoices = GetLastMatchedString(sJavascriptData, "numChoi=", ";");

            for (int i = 0;  i < Convert.ToInt32(sNumQuestions);  i++) {

                string sNextAnswerPosition = "";

                string sNextQuestion = GetLastMatchedString(sJavascriptData, "questions[" + i.ToString() + "][0]=\"", "\"");
                string sNextAnswer   = GetLastMatchedString(sJavascriptData, "answers[" + i.ToString() + "]=\"", "\"");
                string[] sNextChoice   = new string[4];
                string[] sNextFeedback = new string[4];
                for (int iChoice = 0;  iChoice < Convert.ToInt32(sNumChoices);  iChoice++) {
                    sNextChoice[iChoice]   = GetLastMatchedString(sJavascriptData, "questions[" + i.ToString() + "][" + (iChoice+1).ToString() + "]=\"", "\"");

                    sNextFeedback[iChoice] = GetLastMatchedString(sJavascriptData, "feedback[" + i.ToString() + "][" + (iChoice).ToString() + "]=\"", "\"");

                    if (sNextChoice[iChoice] == sNextAnswer) {
                        sNextAnswerPosition = Convert.ToString(Convert.ToChar('a' + iChoice));
                    }
                }

                DataRow drNewData = dTableCurrent.NewRow();
                drNewData["Column1"] = sNextQuestion;
                drNewData["Column2"] = sNextChoice[0];
                drNewData["Column3"] = sNextFeedback[0];
                drNewData["Column4"] = sNextAnswerPosition;
                dTableCurrent.Rows.Add(drNewData);

                for (int iChoice = 1;  iChoice < Convert.ToInt32(sNumChoices);  iChoice++) {
                    drNewData = dTableCurrent.NewRow();
                    drNewData["Column1"] = "";
                    drNewData["Column2"] = sNextChoice[iChoice];
                    drNewData["Column3"] = sNextFeedback[iChoice];
                    drNewData["Column4"] = "";
                    dTableCurrent.Rows.Add(drNewData);
                }
            }
 
            string sColumns = GetLastMatchedString(sJavascriptData, "iResultsWidth=", ";");
            string sRows    = GetLastMatchedString(sJavascriptData, "iResultsHeight=", ";");

            string sArrangement = GetLastMatchedString(sJavascriptData, "bOnePerPage=", ";");

            string sFeedbackDisplayInPopup  =GetLastMatchedString(sJavascriptData, "bFeedbackDisplayInPopup=", ";");
            string sFeedbackDisplayInResults=GetLastMatchedString(sJavascriptData, "bFeedbackDisplayInResults=", ";");
            string sCheckAnswersButton      =GetLastMatchedString(sJavascriptData, "bCheckAnswersButton=", ";");

            // Set Options on Js Options Tab Page
            IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsMc", false)[0]).Controls.GetEnumerator();

            ieTabPage.MoveNext();
            ((CheckBox)ieTabPage.Current).Checked = sCheckAnswersButton.Equals("true");
            ieTabPage.MoveNext();
            ((CheckBox)ieTabPage.Current).Checked = sFeedbackDisplayInResults.Equals("true");
            ieTabPage.MoveNext();
            ieTabPage.MoveNext();
            ((CheckBox)ieTabPage.Current).Checked = sFeedbackDisplayInPopup.Equals("true");
            ieTabPage.MoveNext();
            if (sArrangement.Equals("true")) {
                ((RadioButton)ieTabPage.Current).Checked = true;
                ieTabPage.MoveNext();
                ((RadioButton)ieTabPage.Current).Checked = false;
            } else {
                ((RadioButton)ieTabPage.Current).Checked = false;
                ieTabPage.MoveNext();
                ((RadioButton)ieTabPage.Current).Checked = true;
            }
            ieTabPage.MoveNext();
            ieTabPage.MoveNext();
            ieTabPage.MoveNext();
            ieTabPage.MoveNext();
            ((TextBox)ieTabPage.Current).Text = sColumns;
            ieTabPage.MoveNext();
            ((TextBox)ieTabPage.Current).Text = sRows;
        }


        /// <summary>
        ///
        /// </summary>
        public override string ParseGridAndCreateJavascriptData(DataGrid dataGridCurrent, string sJsDataTemplate, Form cMainForm, TabControl tabData)
        {
            string sReturnJavascript = sJsDataTemplate;

            if (dataGridCurrent.DataSource != null) 
            {
                int     iQuestionsCount = 0;
                int     iChoicesCount   = 0;

                string[][] sFinalQuestions = new string[500][];
                string[]   sFinalAnswers   = new string[500];
                string[][] sFinalFeedback  = new string[500][];

                CurrencyManager cm = (CurrencyManager)cMainForm.BindingContext[dataGridCurrent.DataSource]; 

                int iChoice = 1;
                for (int row = 0;  row < cm.Count;  row += iChoice) {

                    string   sQuestion = dataGridCurrent[row, 0].ToString();
                    string   sAnswer   = dataGridCurrent[row, 3].ToString();
                    string[] sChoices   = new string[4];
                    string[] sFeedback  = new string[4];
                    sChoices[0]  = dataGridCurrent[row, 1].ToString();
                    sFeedback[0] = dataGridCurrent[row, 2].ToString();
                    string sNextQuestion = "";
                    for (iChoice = 1;  (sNextQuestion.Length <= 0) && ((row + iChoice) < cm.Count);  iChoice++) {
                        string sLookAhead = dataGridCurrent[row + iChoice, 0].ToString();
                        if (sLookAhead.Length <= 0) {
                            sChoices[iChoice]  = dataGridCurrent[row + iChoice, 1].ToString();
                            sFeedback[iChoice] = dataGridCurrent[row + iChoice, 2].ToString();
                        } else {
                            sNextQuestion = sLookAhead;
                            // if this for loop breaks out from (row + iChoice) < cm.Count
                            // then we are at end of entire list
                            // so we need to subtract 1 from iChoice whenever that's not the case
                            // ---- ONLY SUBTRACT 1 WHEN NOT ON LAST QUESTION
                            iChoice--;
                        }
                    }
                    
                    int iCurrentChoicesCount = iChoice;

                    if ((sQuestion.Length > 0) && (sAnswer.Length > 0) && (iCurrentChoicesCount > 0)) {

                        sAnswer = sAnswer.ToLower().Substring(0, 1);
                        int iCorrectIndex = sAnswer[0] - 'a';
                        if ((iCorrectIndex < 4) && (sChoices[iCorrectIndex].Length > 0)) {

                            sFinalQuestions[iQuestionsCount] = new string[5];
                            sFinalQuestions[iQuestionsCount][0] = sQuestion;
                            sFinalQuestions[iQuestionsCount][1] = sChoices[0];
                            sFinalQuestions[iQuestionsCount][2] = sChoices[1];
                            sFinalQuestions[iQuestionsCount][3] = sChoices[2];
                            sFinalQuestions[iQuestionsCount][4] = sChoices[3];
                            sFinalAnswers  [iQuestionsCount]    = sChoices[iCorrectIndex];
                            sFinalFeedback [iQuestionsCount] = new string[4];
                            sFinalFeedback [iQuestionsCount][0] = sFeedback[0];
                            sFinalFeedback [iQuestionsCount][1] = sFeedback[1];
                            sFinalFeedback [iQuestionsCount][2] = sFeedback[2];
                            sFinalFeedback [iQuestionsCount][3] = sFeedback[3];

                            iQuestionsCount++;

                            if (iCurrentChoicesCount > iChoicesCount) {
                                iChoicesCount = iCurrentChoicesCount;
                            }

                        }
                    }

                }

                string sNewSizeVars = "numQues=" + iQuestionsCount + ";\r\n"
                                    + "numChoi=" + iChoicesCount   + ";\r\n";

                int iSizeVarsEnd  = sReturnJavascript.IndexOf("//SIZEVARSEND");
                sReturnJavascript = sReturnJavascript.Insert(iSizeVarsEnd, sNewSizeVars);

                string  sMatchingQuestionsLine = "\r\nquestions[NNN][OOO]=\"QQQ\";";
                string  sMatchingAnswersLine   = "\r\nanswers[NNN]=\"AAA\";";
                string  sMatchingFeedbackLine  = "\r\nfeedback[NNN][PPP]=\"FFF\";";
                string  sQuestionLines  = "";
                string  sAnswerLines    = "";
                string  sFeedbackLines  = "";

                for (int row = 0;  row < iQuestionsCount;  row++) {

                    for (int i = 0;  i < 5;  i++) {
                        string sTempQuestionsLine = sMatchingQuestionsLine;
                        sTempQuestionsLine = sTempQuestionsLine.Replace("NNN", row.ToString());
                        sTempQuestionsLine = sTempQuestionsLine.Replace("OOO", i.ToString());
                        if (sFinalQuestions[row][i] != null) {
                            sFinalQuestions[row][i] = sFinalQuestions[row][i].Replace("\"", "&quot;");
                        }
                        sTempQuestionsLine = sTempQuestionsLine.Replace("QQQ", sFinalQuestions[row][i]);
                        sQuestionLines = sQuestionLines + sTempQuestionsLine;
                    }

                    string sTempAnswersLine = sMatchingAnswersLine;
                    sTempAnswersLine = sTempAnswersLine.Replace("NNN", row.ToString());
                    sFinalAnswers[row] = sFinalAnswers[row].Replace("\"", "&quot;");
                    sTempAnswersLine = sTempAnswersLine.Replace("AAA", sFinalAnswers[row]);

                    sAnswerLines = sAnswerLines + sTempAnswersLine;

                    for (int i = 0;  i < 4;  i++) {
                        string sTempFeedbackLine = sMatchingFeedbackLine;
                        sTempFeedbackLine = sTempFeedbackLine.Replace("NNN", row.ToString());
                        sTempFeedbackLine = sTempFeedbackLine.Replace("PPP", i.ToString());
                        if (sFinalFeedback[row][i] != null) {
                            sFinalFeedback[row][i] = sFinalFeedback[row][i].Replace("\"", "&quot;");
                        }
                        sTempFeedbackLine = sTempFeedbackLine.Replace("FFF", sFinalFeedback[row][i]);
                        sFeedbackLines = sFeedbackLines + sTempFeedbackLine;
                    }

                }

                int iQuestionsEnd   = sReturnJavascript.IndexOf("//QUESTIONSEND");
                sReturnJavascript = sReturnJavascript.Insert(iQuestionsEnd, sQuestionLines + "\r\n");

                int iAnswersEnd   = sReturnJavascript.IndexOf("//ANSWERSEND");
                sReturnJavascript = sReturnJavascript.Insert(iAnswersEnd, sAnswerLines + "\r\n");

                int iFeedbackEnd   = sReturnJavascript.IndexOf("//FEEDBACKEND");
                sReturnJavascript = sReturnJavascript.Insert(iFeedbackEnd, sFeedbackLines + "\r\n");

                string sOnePerPage = "false";

                // Get Options to write
                IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsMc", false)[0]).Controls.GetEnumerator();

                ieTabPage.MoveNext();
                string sCheckAnswersButton       = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                ieTabPage.MoveNext();
                string sFeedbackDisplayInResults = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                string sFeedbackDisplayInPopup   = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                ieTabPage.MoveNext();
                if (((RadioButton)ieTabPage.Current).Checked) {
                    sOnePerPage = "true";
                }
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                string sNumCols = ((TextBox)ieTabPage.Current).Text;
                ieTabPage.MoveNext();
                string sNumRows = ((TextBox)ieTabPage.Current).Text;

                sReturnJavascript += "\r\niResultsWidth="             + sNumCols + ";\r\n";
                sReturnJavascript += "\r\niResultsHeight="            + sNumRows + ";\r\n";
                sReturnJavascript += "\r\nbOnePerPage="               + sOnePerPage + ";\r\n";
                sReturnJavascript += "\r\nbFeedbackDisplayInPopup="   + sFeedbackDisplayInPopup + ";\r\n";
                sReturnJavascript += "\r\nbFeedbackDisplayInResults=" + sFeedbackDisplayInResults + ";\r\n";
                sReturnJavascript += "\r\nbCheckAnswersButton="       + sCheckAnswersButton + ";\r\n";

            }
            return (sReturnJavascript);
        }

    }
}
