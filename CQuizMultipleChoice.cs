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
        public CQuizMultipleChoice(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent) : base(ref dataGridCurrent, ref dTableCurrent)
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
        public override void InitializeGrid(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent)
        {
            RemoveClickEvent(dataGridCurrent);
            dTableCurrent = new DataTable ("DataTable" + GetQuizType());
            dataGridCurrent.Columns.Clear();
            dataGridCurrent.RowTemplate.Height = 35;
            
            //dataGridCurrent.TableStyles.Clear();

            // Add a GridTableStyle and set the MappingName 
            // to the name of the DataTable.
            DataGridTableStyle dgdtblStyle = new DataGridTableStyle();
            dgdtblStyle.RowHeadersVisible  = false;
            dgdtblStyle.MappingName = dTableCurrent.TableName;
            dgdtblStyle.AllowSorting = false;

            dataGridCurrent.RowHeadersVisible = false;
            

            for (int i = 0;  i < 4;  i++) 
            {
                dTableCurrent.Columns.Add("Column" + (i+1).ToString(), System.Type.GetType("System.String"));
            }
            DataGridViewTextBoxColumn gtbc1 = new DataGridViewTextBoxColumn();
            gtbc1.HeaderText = "Question Phrase";
            gtbc1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc1.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc1.DataPropertyName = "Column1";
            //gtbc1.ValueType = typeof(string);
            gtbc1.Width = 310;
            gtbc1.DefaultCellStyle.NullValue = "<type question here>";
            dataGridCurrent.Columns.Add(gtbc1);

            // Add a GridColumnStyle and set the MappingName 
            // to the name of a DataColumn in the DataTable. 
            // Set the HeaderText and Width properties. 
            //ExtendedDataGridMultiLineTextBoxColumn tbc1 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc1.MappingName = "Column1";
            //tbc1.TextBox.Multiline = true;
            //tbc1.MinimumHeight = 35;
            //tbc1.HeaderText = "Question Phrase";
            //tbc1.Width = 310;
            //tbc1.NullText = "<type question here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc1);
            DataGridViewTextBoxColumn gtbc2 = new DataGridViewTextBoxColumn();
            gtbc2.HeaderText = "Choices";
            gtbc2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc2.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc2.DataPropertyName = "Column2";
            //gtbc1.ValueType = typeof(string);
            gtbc2.Width = 220;
            gtbc2.DefaultCellStyle.NullValue = "<type choices here>";
            dataGridCurrent.Columns.Add(gtbc2);
            
            //ExtendedDataGridMultiLineTextBoxColumn tbc2 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc2.MappingName = "Column2";
            //tbc2.HeaderText = "Choices";
            //tbc2.TextBox.Multiline = true;
            //tbc2.MinimumHeight = 35;
            //tbc2.Width = 220;
            //tbc2.NullText = "<type choices here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc2);
            DataGridViewTextBoxColumn gtbc3 = new DataGridViewTextBoxColumn();
            gtbc3.HeaderText = "Feedback";
            gtbc3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc3.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc3.DataPropertyName = "Column3";
            //gtbc1.ValueType = typeof(string);
            gtbc3.Width = 310;
            gtbc3.DefaultCellStyle.NullValue = "<type feedback here>";
            dataGridCurrent.Columns.Add(gtbc3);

            //ExtendedDataGridMultiLineTextBoxColumn tbc3 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc3.MappingName = "Column3";
            //tbc3.HeaderText = "Feedback";
            //tbc3.TextBox.Multiline = true;
            //tbc3.MinimumHeight = 35;
            //tbc3.Width = 310;
            //tbc3.NullText = "<type feedback here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc3);
            DataGridViewTextBoxColumn gtbc4 = new DataGridViewTextBoxColumn();
            gtbc4.HeaderText = "Answer(a...d)";
            gtbc4.DataPropertyName = "Column4";
            gtbc4.Width = 84;
            gtbc4.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc4.DefaultCellStyle.NullValue = "<insert letter>";
            dataGridCurrent.Columns.Add(gtbc4);

            //DataGridTextBoxColumn tbc4 = new DataGridTextBoxColumn();
            //tbc4.MappingName = "Column4";
            //tbc4.HeaderText = "Answer(a...d)";
            //tbc4.Width = 84;
            //tbc4.NullText = "<insert letter>";

            //dgdtblStyle.GridColumnStyles.Add(tbc4);

            //
            // Tie our keypress handler to the textbox's KeyPress event.
            //
            //DataGridTextBoxColumn tbcHandler = (DataGridTextBoxColumn)dgdtblStyle.GridColumnStyles[3];
            //tbcHandler.TextBox.KeyPress += new KeyPressEventHandler(DatagridPositionKeyPress);
            DataGridViewEditingControlShowingEventHandler dlg = new DataGridViewEditingControlShowingEventHandler(dataGridView_EditingControlShowing);
            cShowingEventHandlers.Add(dlg);
            dataGridCurrent.EditingControlShowing += dlg;


            foreach (DataGridViewColumn column in dataGridCurrent.Columns)
            {
                dataGridCurrent.Columns[column.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            // Add the DataGridTableStyle instance to the GridTableStylesCollection. 
            //dataGridCurrent.TableStyles.Add(dgdtblStyle);
            dataGridCurrent.DataSource = dTableCurrent;
            dataGridCurrent.Visible = true;
        }

        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress +=
                new KeyPressEventHandler(DatagridPositionKeyPress);
        }

        /// <summary>
        /// Keypress handler for date values.
        /// </summary>
        public override void DatagridPositionKeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridCurrentMain.CurrentCell.ColumnIndex != 3) return;
            if (((e.KeyChar >= 'a') && (e.KeyChar <= 'd'))
               || ((e.KeyChar >= 'A') && (e.KeyChar <= 'D'))
               || (e.KeyChar == '\r')
               || (e.KeyChar == '\b')) 
            {
                e.Handled = false;
                TextBox t = sender as TextBox;
                if (t != null)
                {
                    t.Text = "";
                }
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
        public override void FillGridWithJavascriptData(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent, string sJavascriptData, TabControl tabData)
        {
            AcceptChanges(dataGridCurrent);
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

                    // Need to include the semicolon in the search below because otherwise you sometimes end prematurley due to any \\\" (quote) in the feedback
                    sNextFeedback[iChoice] = GetLastMatchedString(sJavascriptData, "feedback[" + i.ToString() + "][" + (iChoice).ToString() + "]=\"", "\";");

                    if (sNextChoice[iChoice] == sNextAnswer) {
                        sNextAnswerPosition = Convert.ToString(Convert.ToChar('a' + iChoice));
                    }
                }

                DataRow drNewData = dTableCurrent.NewRow();
                drNewData["Column1"] = sNextQuestion;
                drNewData["Column2"] = sNextChoice[0];
                // Actually for some odd reason (because it's not displayed in html, but in the alert and input text box?)...
                //...Feedback needs to be opposite of the others
                sNextFeedback[0] = sNextFeedback[0].Replace("\\\"", "&quot;");
                drNewData["Column3"] = sNextFeedback[0];
                drNewData["Column4"] = sNextAnswerPosition;
                dTableCurrent.Rows.Add(drNewData);

                for (int iChoice = 1;  iChoice < Convert.ToInt32(sNumChoices);  iChoice++) {
                    drNewData = dTableCurrent.NewRow();
                    drNewData["Column1"] = "";
                    drNewData["Column2"] = sNextChoice[iChoice];
                    // Actually for some odd reason (because it's not displayed in html, but in the alert and input text box?)...
                    //...Feedback needs to be opposite of the others
                    sNextFeedback[iChoice] = sNextFeedback[iChoice].Replace("\\\"", "&quot;");
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

           

            Control.ControlCollection ocTabPageJsOptions = tabData.Controls.Find("tabPageJsOptionsMc", false)[0].Controls;
            ((CheckBox)ocTabPageJsOptions.Find("checkBoxMcCheckAnswersButton", false)[0]).Checked = sCheckAnswersButton.Equals("true");
            ((CheckBox)ocTabPageJsOptions.Find("checkBoxMcFeedbackInResults", false)[0]).Checked = sFeedbackDisplayInResults.Equals("true");
            ((CheckBox)ocTabPageJsOptions.Find("checkBoxMcFeedbackInPopup", false)[0]).Checked = sFeedbackDisplayInPopup.Equals("true");
            if (sArrangement.Equals("true"))
            {
                ((RadioButton)ocTabPageJsOptions.Find("radioButtonMcQuestionOne", false)[0]).Checked = true;
                ((RadioButton)ocTabPageJsOptions.Find("radioButtonMcQuestionAll", false)[0]).Checked = false;
            }
            else
            {
                ((RadioButton)ocTabPageJsOptions.Find("radioButtonMcQuestionOne", false)[0]).Checked = false;
                ((RadioButton)ocTabPageJsOptions.Find("radioButtonMcQuestionAll", false)[0]).Checked = true;
            }
            ((TextBox)ocTabPageJsOptions.Find("textBoxMtResultsCols", false)[0]).Text = sColumns;
            ((TextBox)ocTabPageJsOptions.Find("textBoxMtResultsRows", false)[0]).Text = sRows;
            

        }


        /// <summary>
        ///
        /// </summary>
        public override string ParseGridAndCreateJavascriptData(DataGridView dataGridCurrent, string sJsDataTemplate, Form cMainForm, TabControl tabData)
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

                    string   sQuestion = dataGridCurrent[0,row].Value.ToString();
                    string   sAnswer   = dataGridCurrent[3,row].Value.ToString();
                    string[] sChoices   = new string[4];
                    string[] sFeedback  = new string[4];
                    sChoices[0]  = dataGridCurrent[1,row].Value.ToString();
                    sFeedback[0] = dataGridCurrent[2,row].Value.ToString();
                    string sNextQuestion = "";
                    for (iChoice = 1;  (sNextQuestion.Length <= 0) && ((row + iChoice) < cm.Count);  iChoice++) {
                        string sLookAhead = dataGridCurrent[0,row + iChoice].Value.ToString();
                        if (sLookAhead.Length <= 0) {
                            sChoices[iChoice]  = dataGridCurrent[1,row + iChoice].Value.ToString();
                            sFeedback[iChoice] = dataGridCurrent[2,row + iChoice].Value.ToString();
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
                            //sFinalFeedback[row][i] = sFinalFeedback[row][i].Replace("\"", "&quot;");
                            // Actually for some odd reason (because it's not displayed in html, but in the alert and input text box?)...
                            //...Feedback needs to be opposite of the others
                            sFinalFeedback[row][i] = sFinalFeedback[row][i].Replace("&quot;", "\\\"");
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

                //string sOnePerPage = "false";

                // Get Options to write
                //IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsMc", false)[0]).Controls.GetEnumerator();

                //ieTabPage.MoveNext();
                //string sCheckAnswersButton       = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                //ieTabPage.MoveNext();
                //string sFeedbackDisplayInResults = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                //ieTabPage.MoveNext();
                //ieTabPage.MoveNext();
                //string sFeedbackDisplayInPopup   = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                //ieTabPage.MoveNext();
                //if (((RadioButton)ieTabPage.Current).Checked) {
                //    sOnePerPage = "true";
                //}
                //ieTabPage.MoveNext();
                //ieTabPage.MoveNext();
                //ieTabPage.MoveNext();
                //ieTabPage.MoveNext();
                //ieTabPage.MoveNext();
                //string sNumCols = ((TextBox)ieTabPage.Current).Text;
                //ieTabPage.MoveNext();
                //string sNumRows = ((TextBox)ieTabPage.Current).Text;


                Control.ControlCollection ocTabPageJsOptions = tabData.Controls.Find("tabPageJsOptionsMc", false)[0].Controls;
                string sCheckAnswersButton = ((CheckBox)ocTabPageJsOptions.Find("checkBoxMcCheckAnswersButton", false)[0]).Checked ? "true" : "false";
                string sFeedbackDisplayInResults = ((CheckBox)ocTabPageJsOptions.Find("checkBoxMcFeedbackInResults", false)[0]).Checked ? "true" : "false";
                string sFeedbackDisplayInPopup = ((CheckBox)ocTabPageJsOptions.Find("checkBoxMcFeedbackInPopup", false)[0]).Checked ? "true" : "false";
                string sOnePerPage = "false";
                if (((RadioButton)ocTabPageJsOptions.Find("radioButtonMcQuestionOne", false)[0]).Checked)
                {
                    sOnePerPage = "true";
                }
                string sNumCols = ((TextBox)ocTabPageJsOptions.Find("textBoxMtResultsCols", false)[0]).Text;
                string sNumRows = ((TextBox)ocTabPageJsOptions.Find("textBoxMtResultsRows", false)[0]).Text;


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
