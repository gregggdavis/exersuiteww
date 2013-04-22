using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

using Leadit.ExtendedDataGrid;


namespace BrowserApp
{
	/// <summary>
	/// Summary description for CQuizMatching.
	/// </summary>
	public class CQuizMatching : CQuiz

	{
		public CQuizMatching(ref DataGrid dataGridCurrent, ref DataTable dTableCurrent) : base(ref dataGridCurrent, ref dTableCurrent)
		{
			//
			// TODO: Add constructor logic here
			//

            sCurrentJsQuizType = "Matching";

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



            for (int i = 0;  i < 3;  i++) 
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
            tbc1.HeaderText = "Beginning Phrase";
            tbc1.Width = 400;
            tbc1.NullText = "<type phrase here>";

            dgdtblStyle.GridColumnStyles.Add(tbc1);

            DataGridTextBoxColumn tbc2 = new DataGridTextBoxColumn();
            tbc2.MappingName = "Column2";
            tbc2.HeaderText = "Position (a...z)";
            tbc2.Width = 100;
            tbc2.NullText = "<insert letter>";

            dgdtblStyle.GridColumnStyles.Add(tbc2);

            ExtendedDataGridMultiLineTextBoxColumn tbc3 = new ExtendedDataGridMultiLineTextBoxColumn();
            tbc3.MappingName = "Column3";
            tbc3.HeaderText = "Ending Phrase";
            tbc3.TextBox.Multiline = true;
            tbc3.MinimumHeight = 35;
            tbc3.Width = 400;
            tbc3.NullText = "<type phrase here>";

            dgdtblStyle.GridColumnStyles.Add(tbc3);

            //
            // Tie our keypress handler to the textbox's KeyPress event.
            //
            DataGridTextBoxColumn tbcHandler = (DataGridTextBoxColumn)dgdtblStyle.GridColumnStyles[1];
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
            if (((e.KeyChar >= 'a') && (e.KeyChar <= 'z'))
                ||  ((e.KeyChar >= 'A') && (e.KeyChar <= 'Z'))
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
            string sMatchQuestionsLength = "questions.length=";
            int    iQuestionsLength = sJavascriptData.LastIndexOf(sMatchQuestionsLength);
            int    iNumQuestionsEnd = sJavascriptData.IndexOf(";", iQuestionsLength + sMatchQuestionsLength.Length);
            string sQuestionsLength = sJavascriptData.Substring(iQuestionsLength + sMatchQuestionsLength.Length, iNumQuestionsEnd - (iQuestionsLength + sMatchQuestionsLength.Length));

            for (int i = 0;  i < Convert.ToInt32(sQuestionsLength);  i++) 
            {
                string sQuestionMatch = "questions[" + (i+1).ToString() + "]=new Question(\"";
                int iNextQuestionBegin = sJavascriptData.IndexOf(sQuestionMatch);
                int iNextQuestionEnd   = sJavascriptData.IndexOf("\"", iNextQuestionBegin + sQuestionMatch.Length);
                string sNextQuestion   = sJavascriptData.Substring(iNextQuestionBegin + sQuestionMatch.Length, iNextQuestionEnd - (iNextQuestionBegin + sQuestionMatch.Length));
                
                string sPosition       = sJavascriptData.Substring(iNextQuestionEnd + 3, 1); 

                string sAnswerMatch = "answers[\"" + sPosition + "\"]=\"";
                int iNextAnswerBegin = sJavascriptData.IndexOf(sAnswerMatch);
                int iNextAnswerEnd   = sJavascriptData.IndexOf("\"", iNextAnswerBegin + sAnswerMatch.Length);
                string sNextAnswer   = sJavascriptData.Substring(iNextAnswerBegin + sAnswerMatch.Length, iNextAnswerEnd - (iNextAnswerBegin + sAnswerMatch.Length));

                DataRow drNewData = dTableCurrent.NewRow();
                drNewData["Column1"] = sNextQuestion;
                drNewData["Column2"] = sPosition;
                drNewData["Column3"] = sNextAnswer;
                dTableCurrent.Rows.Add(drNewData);
            }
 
            string sColumnsMatch = "iResultsWidth=";
            int iColumnsBegin    = sJavascriptData.LastIndexOf(sColumnsMatch);
            int iColumnsEnd      = sJavascriptData.IndexOf(";", iColumnsBegin + sColumnsMatch.Length);
            string sColumns      = sJavascriptData.Substring(iColumnsBegin + sColumnsMatch.Length, iColumnsEnd - (iColumnsBegin + sColumnsMatch.Length));

            string sRowsMatch = "iResultsHeight=";
            int iRowsBegin    = sJavascriptData.LastIndexOf(sRowsMatch);
            int iRowsEnd      = sJavascriptData.IndexOf(";", iRowsBegin + sRowsMatch.Length);
            string sRows      = sJavascriptData.Substring(iRowsBegin + sRowsMatch.Length, iRowsEnd - (iRowsBegin + sRowsMatch.Length));

            // Set Options on Js Options Tab Page
            IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsMa", false)[0]).Controls.GetEnumerator();

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
                string  sMatchingAnswersLine   = "\r\nanswers[\"LLL\"]=\"AAA\";";
                string  sMatchingQuestionsLine = "\r\nquestions[NNN]=new Question(\"QQQ\",\"LLL\");";

                string  sAnswerLines   = "";
                string  sQuestionLines = "";
                int     iQuestionsCount = 0;

                CurrencyManager cm = (CurrencyManager)cMainForm.BindingContext[dataGridCurrent.DataSource]; 

                for (int row = 0;  row < cm.Count;  row++) 
                {
                    string sQuestion = dataGridCurrent[row, 0].ToString();
                    string sPosition = dataGridCurrent[row, 1].ToString();
                    string sAnswer   = dataGridCurrent[row, 2].ToString();

                    if ((sQuestion.Length > 0) && (sPosition.Length > 0) && (sAnswer.Length > 0)) 
                    {
                        
                        sPosition = sPosition.ToLower().Substring(0, 1);

                        iQuestionsCount++;

                        string sTempAnswersLine = sMatchingAnswersLine;
                        sTempAnswersLine = sTempAnswersLine.Replace("LLL", sPosition);
                        sAnswer = sAnswer.Replace("\"", "&quot;");
                        sTempAnswersLine = sTempAnswersLine.Replace("AAA", sAnswer);

                        sAnswerLines = sAnswerLines + sTempAnswersLine;

                        string sTempQuestionsLine = sMatchingQuestionsLine;
                        sTempQuestionsLine = sTempQuestionsLine.Replace("NNN", (iQuestionsCount).ToString());
                        sQuestion = sQuestion.Replace("\"", "&quot;");
                        sTempQuestionsLine = sTempQuestionsLine.Replace("QQQ", sQuestion);
                        sTempQuestionsLine = sTempQuestionsLine.Replace("LLL", sPosition);

                        sQuestionLines = sQuestionLines + sTempQuestionsLine;
                    }
                }
                sAnswerLines = sAnswerLines + "\r\nanswers.length=" + iQuestionsCount.ToString() + ";\r\n";
                sQuestionLines = sQuestionLines + "\r\nquestions.length=" + iQuestionsCount.ToString() + ";\r\n";

                string sAnswersBegin   = "//ANSWERSBEGIN";
                string sAnswersEnd     = "//ANSWERSEND";
                string sQuestionsBegin = "//QUESTIONSBEGIN";
                string sQuestionsEnd   = "//QUESTIONSEND";
                int iAnswersBegin = sReturnJavascript.IndexOf(sAnswersBegin) + sAnswersBegin.Length;
                int iAnswersEnd   = sReturnJavascript.IndexOf(sAnswersEnd);

                sReturnJavascript = sReturnJavascript.Insert(iAnswersEnd, sAnswerLines);

                int iQuestionsBegin = sReturnJavascript.IndexOf(sQuestionsBegin) + sQuestionsBegin.Length;
                int iQuestionsEnd   = sReturnJavascript.IndexOf(sQuestionsEnd);

                sReturnJavascript = sReturnJavascript.Insert(iQuestionsEnd, sQuestionLines);


                // Get Options to write
                IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsMa", false)[0]).Controls.GetEnumerator();

                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                string sNumCols = ((TextBox)ieTabPage.Current).Text;
                ieTabPage.MoveNext();
                string sNumRows = ((TextBox)ieTabPage.Current).Text;

                sReturnJavascript += "\r\niResultsWidth=" + sNumCols + ";\r\n";
                sReturnJavascript += "\r\niResultsHeight=" + sNumRows + ";\r\n";

            }
            return (sReturnJavascript);
        }

	}
}
