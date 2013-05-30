using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

using Leadit.ExtendedDataGrid;


namespace BrowserApp
{
	/// <summary>
	/// Summary description for CQuizFillIn.
	/// </summary>
	public class CQuizFillIn : CQuiz

	{
		public CQuizFillIn(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent) : base(ref dataGridCurrent, ref dTableCurrent)
		{
			//
			// TODO: Add constructor logic here
			//

            sCurrentJsQuizType = "FillIn";

            InitializeGrid(ref dataGridCurrent, ref dTableCurrent);
		}



        /// <summary>
        ///
        /// </summary>
        public override void InitializeGrid(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent)
        {
            dTableCurrent = new DataTable ("DataTable" + GetQuizType());
            dataGridCurrent.Columns.Clear();
            dataGridCurrent.RowTemplate.Height = 52;
            
            //dataGridCurrent.TableStyles.Clear();

            // Add a GridTableStyle and set the MappingName 
            // to the name of the DataTable.
            DataGridTableStyle dgdtblStyle = new DataGridTableStyle();
            dgdtblStyle.RowHeadersVisible  = false;
            dgdtblStyle.MappingName = dTableCurrent.TableName;
            dgdtblStyle.AllowSorting = false;

            dataGridCurrent.RowHeadersVisible = false;
            

            for (int i = 0;  i < 2;  i++) {
                dTableCurrent.Columns.Add("Column" + (i+1).ToString(), System.Type.GetType("System.String"));
            }

            DataGridViewTextBoxColumn gtbc1 = new DataGridViewTextBoxColumn();
            gtbc1.HeaderText = "Phrase (use '<input0>, <input1>, etc' to denote multiple Fill-In boxes)";
            gtbc1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            gtbc1.DataPropertyName = "Column1";
            //gtbc1.ValueType = typeof(string);
            gtbc1.Width = 600;
            gtbc1.DefaultCellStyle.NullValue = "<type phrase here>";
            dataGridCurrent.Columns.Add(gtbc1);

            // Add a GridColumnStyle and set the MappingName 
            // to the name of a DataColumn in the DataTable. 
            // Set the HeaderText and Width properties. 
            //ExtendedDataGridMultiLineTextBoxColumn tbc1 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc1.MappingName = "Column1";
            //tbc1.TextBox.Multiline = true;
            //tbc1.MinimumHeight = 52;
            //tbc1.HeaderText = "Phrase (use '<input0>, <input1>, etc' to denote multiple Fill-In boxes)";
            //tbc1.Width = 600;
            //tbc1.NullText = "<type phrase here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc1);
            DataGridViewTextBoxColumn gtbc2 = new DataGridViewTextBoxColumn();
            gtbc2.HeaderText = "Answer (use semicolon \";\" to deliminate)";
            gtbc2.DataPropertyName = "Column2";
            gtbc2.Width = 300;
            gtbc2.DefaultCellStyle.NullValue = "<type answer here>";
            dataGridCurrent.Columns.Add(gtbc2);

            //DataGridTextBoxColumn tbc2 = new DataGridTextBoxColumn();
            //tbc2.MappingName = "Column2";
            //tbc2.HeaderText = "Answer (use semicolon \";\" to deliminate)";
            //tbc2.Width = 230;
            //tbc2.NullText = "<type answer here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc2);

            foreach (DataGridViewColumn column in dataGridCurrent.Columns)
            {
                dataGridCurrent.Columns[column.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            // Add the DataGridTableStyle instance to the GridTableStylesCollection. 
            //dataGridCurrent.TableStyles.Add(dgdtblStyle);
            dataGridCurrent.DataSource = dTableCurrent;
            dataGridCurrent.Visible = true;
        }



        /// <summary>
        ///
        /// </summary>
        public override void FillGridWithJavascriptData(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent, string sJavascriptData, TabControl tabData)
        {
            int iAnswerCount = 0;

            string sNumQuestions = GetLastMatchedString(sJavascriptData, "numQues=", ";");

            for (int i = 0;  (sNumQuestions.Length > 0) && (i < Convert.ToInt32(sNumQuestions));  i++) {

                string sInputCount   = GetLastMatchedString(sJavascriptData, "OrigQuestions[" + i.ToString() + "][0]=", ";");
                string sNextQuestion = GetLastMatchedString(sJavascriptData, "OrigQuestions[" + i.ToString() + "][1]=\"", "\"");
                //Should Convert sNextQuestion's <inputX> to <input> here in the future so user doesn't have to type number X
                string sNextAnswer = "";
                for (int j = 0;  j < Convert.ToInt32(sInputCount);  j++) {
                    sNextAnswer = sNextAnswer + GetLastMatchedString(sJavascriptData, "OrigAnswers[" + iAnswerCount.ToString() + "]=\"", "\"") + ";";
                    iAnswerCount++;
                }
                DataRow drNewData = dTableCurrent.NewRow();
                // Format for %'s in Netscape 6 - %25's from javascript file must become %'s
                sNextQuestion = sNextQuestion.Replace("%25", "%");
                sNextAnswer = sNextAnswer.Replace("%25", "%");
                // Format for %'s in Netscape 6 - %25's from javascript file must become %'s
                drNewData["Column1"] = sNextQuestion;
                drNewData["Column2"] = sNextAnswer;
                dTableCurrent.Rows.Add(drNewData);
            }

            string sChoices = GetLastMatchedString(sJavascriptData, "PossibleAnswers=\"", "\"");

            // Format for textbox - <br>, <br/>, <br />, <br  /> all become \n
            sChoices = sChoices.Replace("<br>",    "\r\n");
            sChoices = sChoices.Replace("<br/>",   "\r\n");
            sChoices = sChoices.Replace("<br />",  "\r\n");
            sChoices = sChoices.Replace("<br  />", "\r\n");

            string sArrangement = GetLastMatchedString(sJavascriptData, "bOnePerPage=", ";");

            string sColumns = GetLastMatchedString(sJavascriptData, "iResultsWidth=",  ";");
            string sRows    = GetLastMatchedString(sJavascriptData, "iResultsHeight=", ";");
            string sShowQuestionNumbers = GetLastMatchedString(sJavascriptData, "bShowQuestionNumbers=", ";");
            string sPageWidth = GetLastMatchedString(sJavascriptData, "iTotalPageWidth=", ";");
            string sTypeQuiz = GetLastMatchedString(sJavascriptData, "bTypeQuiz=", ";");

            // Set Options on Js Options Tab Page
            //IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsFi", false)[0]).Controls.GetEnumerator();

            // The better way to do assignments from javascript options to form elements
            // Should be done this way for all the quiz option pages and for html data tab
            Control.ControlCollection ocTabPageJsOptions = tabData.Controls.Find("tabPageJsOptionsFi", false)[0].Controls;

            ((TextBox)ocTabPageJsOptions.Find("textBoxFiResultsCols", false)[0]).Text = sColumns;
            ((TextBox)ocTabPageJsOptions.Find("textBoxFiResultsRows", false)[0]).Text = sRows;
            ((RadioButton)ocTabPageJsOptions.Find("radioButtonFiQuestionAll", false)[0]).Checked = sArrangement.Equals("true");
            ((RadioButton)ocTabPageJsOptions.Find("radioButtonFiQuestionOne", false)[0]).Checked = sArrangement.Equals("false");
            ((TextBox)ocTabPageJsOptions.Find("textBoxJsOptionsFiChoices", false)[0]).Text = sChoices;
            ((TextBox)ocTabPageJsOptions.Find("textBoxFiPageWidth", false)[0]).Text = sPageWidth;
            ((CheckBox)ocTabPageJsOptions.Find("checkBoxFiShowNumbers", false)[0]).Checked = sShowQuestionNumbers.Equals("true");
            ((CheckBox)ocTabPageJsOptions.Find("checkBoxFiTypeQuiz", false)[0]).Checked = sTypeQuiz.Equals("true");

            /*
            ieTabPage.MoveNext();
            ((TextBox)ieTabPage.Current).Text = sPageWidth;
            ieTabPage.MoveNext();
            ieTabPage.MoveNext();
            ieTabPage.MoveNext();
            ((CheckBox)ieTabPage.Current).Checked = sShowQuestionNumbers.Equals("true");
            ieTabPage.MoveNext();
            ((TextBox)ieTabPage.Current).Text = sColumns;
            ieTabPage.MoveNext();
            ((TextBox)ieTabPage.Current).Text = sRows;
            ieTabPage.MoveNext();
            ieTabPage.MoveNext();
            ieTabPage.MoveNext();
            ieTabPage.MoveNext();
            if (sArrangement.Equals("true"))
            {
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
            ((TextBox)ieTabPage.Current).Text = sChoices;

            //Not really set up yet so maybe need to change movenexts
            ((CheckBox)ieTabPage.Current).Checked = sTypeQuiz.Equals("true");
            */

        }


        /// <summary>
        ///
        /// </summary>
        public override string ParseGridAndCreateJavascriptData(DataGridView dataGridCurrent, string sJsDataTemplate, Form cMainForm, TabControl tabData)
        {
            string sReturnJavascript = sJsDataTemplate;

            if (dataGridCurrent.DataSource != null) {

                int     iQuestionsCount = 0;
                int     iAnswersCount   = 0;

                string  sMatchingInputCountLine = "\r\nOrigQuestions[NNN][0]=III;";
                string  sMatchingQuestionsLine = "\r\nOrigQuestions[NNN][1]=\"QQQ\";";
                string  sMatchingAnswersLine   = "\r\nOrigAnswers[NNN]=\"AAA\";";

                string  sQuestionLines = "";
                string  sAnswerLines   = "";

                CurrencyManager cm = (CurrencyManager)cMainForm.BindingContext[dataGridCurrent.DataSource]; 

                for (int row = 0;  row < cm.Count;  row++) {

                    string sQuestion = dataGridCurrent[0,row].Value.ToString();
                    string sAnswer   = dataGridCurrent[1,row].Value.ToString();

                    if ((sQuestion.Length > 0) && (sAnswer.Length > 0)) {

                        int iLastInput = sQuestion.LastIndexOf("<input");
                        string sInputCount = GetLastMatchedString(sQuestion.Substring(iLastInput), "<input", ">");
                        int iNumInputs = Convert.ToInt32(sInputCount) + 1;

                        string sTempInputCountLine = sMatchingInputCountLine;
                        sTempInputCountLine = sTempInputCountLine.Replace("NNN", row.ToString());
                        sTempInputCountLine = sTempInputCountLine.Replace("III", iNumInputs.ToString());

                        string sTempQuestionsLine = sMatchingQuestionsLine;
                        sTempQuestionsLine = sTempQuestionsLine.Replace("NNN", row.ToString());
                        sQuestion = sQuestion.Replace("\"", "&quot;");
                        sTempQuestionsLine = sTempQuestionsLine.Replace("QQQ", sQuestion);

                        sQuestionLines = sQuestionLines + sTempInputCountLine + sTempQuestionsLine;

                        sAnswer = sAnswer.Replace("\"", "&quot;");
                        string[] asIndividual = sAnswer.Split(new char[]{';'});
                        
                        for (int j = 0;  j < iNumInputs;  j++) {
                            string sTempAnswersLine = sMatchingAnswersLine;
                            sTempAnswersLine = sTempAnswersLine.Replace("NNN", iAnswersCount.ToString());
                            sTempAnswersLine = sTempAnswersLine.Replace("AAA", asIndividual[j]);

                            sAnswerLines = sAnswerLines + sTempAnswersLine;

                            iAnswersCount++;
                        }

                        iQuestionsCount++;

                    }
                }

                string sNewSizeVars = "numQues=" + iQuestionsCount + ";\r\n";

                int iSizeVarsEnd  = sReturnJavascript.IndexOf("//SIZEVARSEND");
                sReturnJavascript = sReturnJavascript.Insert(iSizeVarsEnd, sNewSizeVars);

                // Format for %'s in Netscape 6 - %25's from javascript file must become %'s
                sQuestionLines = sQuestionLines.Replace("%", "%25");
                sAnswerLines = sAnswerLines.Replace("%", "%25");
                // Format for %'s in Netscape 6 - %25's from javascript file must become %'s

                int iQuestionsEnd   = sReturnJavascript.IndexOf("//QUESTIONSEND");
                sReturnJavascript = sReturnJavascript.Insert(iQuestionsEnd, sQuestionLines + "\r\n");

                int iAnswersEnd   = sReturnJavascript.IndexOf("//ANSWERSEND");
                sReturnJavascript = sReturnJavascript.Insert(iAnswersEnd, sAnswerLines + "\r\n");

                // Set Options on Js Options Tab Page
                //IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsFi", false)[0]).Controls.GetEnumerator();

                // The better way to do assignments from javascript options to form elements
                // Should be done this way for all the quiz option pages and for html data tab
                Control.ControlCollection ocTabPageJsOptions = tabData.Controls.Find("tabPageJsOptionsFi", false)[0].Controls;

                string sNumCols = ((TextBox)ocTabPageJsOptions.Find("textBoxFiResultsCols", false)[0]).Text;
                string sNumRows = ((TextBox)ocTabPageJsOptions.Find("textBoxFiResultsRows", false)[0]).Text;
                //string sOnePerPage = !((RadioButton)ocTabPageJsOptions.Find("radioButtonFiQuestionAll", false)[0]).Checked ? "false" : "true";
                string sOnePerPage = ((RadioButton)ocTabPageJsOptions.Find("radioButtonFiQuestionOne", false)[0]).Checked ? "true" : "false";
                string sChoices = ((TextBox)ocTabPageJsOptions.Find("textBoxJsOptionsFiChoices", false)[0]).Text;
                string sPageWidth = ((TextBox)ocTabPageJsOptions.Find("textBoxFiPageWidth", false)[0]).Text;
                string sShowQuestionNumbers = ((CheckBox)ocTabPageJsOptions.Find("checkBoxFiShowNumbers", false)[0]).Checked ? "true" : "false";
                string sTypeQuiz = ((CheckBox)ocTabPageJsOptions.Find("checkBoxFiTypeQuiz", false)[0]).Checked ? "true" : "false";

                /*
                ieTabPage.MoveNext();
                string sPageWidth = ((TextBox)ieTabPage.Current).Text;
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                string sShowQuestionNumbers = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                ieTabPage.MoveNext();
                string sNumCols = ((TextBox)ieTabPage.Current).Text;
                ieTabPage.MoveNext();
                string sNumRows = ((TextBox)ieTabPage.Current).Text;
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                string sOnePerPage = "false";
                if (((RadioButton)ieTabPage.Current).Checked) 
                {
                    sOnePerPage = "true";
                }
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                string sChoices = ((TextBox)ieTabPage.Current).Text;

                //Not really set up yet so maybe need to change movenexts
                string sTypeQuiz = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                */

                // Format for textbox - <br>, <br/>, <br /> all become \r\n
                sChoices = sChoices.Replace("\r\n", "<br />");
                sChoices = sChoices.Replace("\"", "&quot;");

                string sMatchingChoicesLine = "\r\nPossibleAnswers=\"PPP\";";
                sMatchingChoicesLine = sMatchingChoicesLine.Replace("PPP", sChoices);

                int iChoicesEnd   = sReturnJavascript.IndexOf("//CHOICESEND");
                sReturnJavascript = sReturnJavascript.Insert(iChoicesEnd, sMatchingChoicesLine + "\r\n");

                sReturnJavascript += "\r\nbOnePerPage=" + sOnePerPage + ";\r\n";
                sReturnJavascript += "\r\niResultsWidth=" + sNumCols + ";\r\n";
                sReturnJavascript += "\r\niResultsHeight=" + sNumRows + ";\r\n";
                sReturnJavascript += "\r\nbShowQuestionNumbers=" + sShowQuestionNumbers + ";\r\n";
                sReturnJavascript += "\r\niTotalPageWidth=" + sPageWidth + ";\r\n";
                sReturnJavascript += "\r\nbTypeQuiz=" + sTypeQuiz + ";\r\n";
            }
            return (sReturnJavascript);
        }

    }
}
