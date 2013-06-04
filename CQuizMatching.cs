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
		public CQuizMatching(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent) : base(ref dataGridCurrent, ref dTableCurrent)
		{
			//
			// TODO: Add constructor logic here
			//

            sCurrentJsQuizType = "Matching";

            //InitializeGrid(ref dataGridCurrent, ref dTableCurrent);
		}



        /// <summary>
        ///
        /// </summary>
        public override void InitializeGrid(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent)
        {
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
            

            for (int i = 0;  i < 3;  i++) 
            {
                dTableCurrent.Columns.Add("Column" + (i+1).ToString(), System.Type.GetType("System.String"));
            }
            
            // Add a GridColumnStyle and set the MappingName 
            // to the name of a DataColumn in the DataTable. 
            // Set the HeaderText and Width properties. 
            DataGridViewTextBoxColumn gtbc1 = new DataGridViewTextBoxColumn();
            gtbc1.HeaderText = "Beginning Phrase";
            gtbc1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc1.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc1.DataPropertyName = "Column1";
            //gtbc1.ValueType = typeof(string);
            gtbc1.Width = 400;
            gtbc1.DefaultCellStyle.NullValue = "<type phrase here>";
            dataGridCurrent.Columns.Add(gtbc1);

            
            DataGridViewTextBoxColumn gtbc2 = new DataGridViewTextBoxColumn();
            gtbc2.HeaderText = "Position (a...z)";
            gtbc2.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc2.DataPropertyName = "Column2";
            gtbc2.Width = 100;
            gtbc2.DefaultCellStyle.NullValue = "<insert letter>";
            dataGridCurrent.Columns.Add(gtbc2);

            DataGridViewTextBoxColumn gtbc3 = new DataGridViewTextBoxColumn();
            gtbc3.HeaderText = "Ending Phrase";
            gtbc3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc3.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc3.DataPropertyName = "Column3";
            //gtbc1.ValueType = typeof(string);
            gtbc3.Width = 400;
            gtbc3.DefaultCellStyle.NullValue = "<type phrase here>";
            dataGridCurrent.Columns.Add(gtbc3);

            
            dataGridCurrent.EditingControlShowing += 
new DataGridViewEditingControlShowingEventHandler(dataGridView_EditingControlShowing);

            foreach (DataGridViewColumn column in dataGridCurrent.Columns)
            {
                dataGridCurrent.Columns[column.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridCurrent.Visible = true;
            dataGridCurrent.DataSource = dTableCurrent;
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
            if(dataGridCurrentMain.CurrentCell.ColumnIndex != 1) return;
            if (((e.KeyChar >= 'a') && (e.KeyChar <= 'z'))
                ||  ((e.KeyChar >= 'A') && (e.KeyChar <= 'Z'))
                ||  (e.KeyChar == '\r')
                ||  (e.KeyChar == '\b')) 
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
            //IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsMa", false)[0]).Controls.GetEnumerator();

            //ieTabPage.MoveNext();
            //ieTabPage.MoveNext();
            //ieTabPage.MoveNext();
            //((TextBox)ieTabPage.Current).Text = sColumns;
            //ieTabPage.MoveNext();
            //((TextBox)ieTabPage.Current).Text = sRows;


            Control.ControlCollection ocTabPageJsOptions = tabData.Controls.Find("tabPageJsOptionsMa", false)[0].Controls;

            ((TextBox)ocTabPageJsOptions.Find("textBoxMaResultsCols", false)[0]).Text = sColumns;
            ((TextBox)ocTabPageJsOptions.Find("textBoxMaResultsRows", false)[0]).Text = sRows;

        }


        /// <summary>
        ///
        /// </summary>
        public override string ParseGridAndCreateJavascriptData(DataGridView dataGridCurrent, string sJsDataTemplate, Form cMainForm, TabControl tabData)
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
                    string sQuestion = dataGridCurrent[0, row].Value.ToString();
                    string sPosition = dataGridCurrent[1, row].Value.ToString();
                    string sAnswer   = dataGridCurrent[2, row].Value.ToString();

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
                //IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsMa", false)[0]).Controls.GetEnumerator();

                //ieTabPage.MoveNext();
                //ieTabPage.MoveNext();
                //ieTabPage.MoveNext();
                //string sNumCols = ((TextBox)ieTabPage.Current).Text;
                //ieTabPage.MoveNext();
                //string sNumRows = ((TextBox)ieTabPage.Current).Text;

                Control.ControlCollection ocTabPageJsOptions = tabData.Controls.Find("tabPageJsOptionsMa", false)[0].Controls;

                string sNumCols = ((TextBox)ocTabPageJsOptions.Find("textBoxMaResultsCols", false)[0]).Text;
                string sNumRows = ((TextBox)ocTabPageJsOptions.Find("textBoxMaResultsRows", false)[0]).Text;

                sReturnJavascript += "\r\niResultsWidth=" + sNumCols + ";\r\n";
                sReturnJavascript += "\r\niResultsHeight=" + sNumRows + ";\r\n";

            }
            return (sReturnJavascript);
        }

	}
}
