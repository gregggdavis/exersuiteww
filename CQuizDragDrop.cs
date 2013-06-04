using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

using Leadit.ExtendedDataGrid;


namespace BrowserApp {
    /// <summary>
    /// Summary description for CQuizDragAndDrop.
    /// </summary>
    public class CQuizDragAndDrop : CQuiz {

        public CQuizDragAndDrop(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent) : base(ref dataGridCurrent, ref dTableCurrent)
        {
            //
            // TODO: Add constructor logic here
            //

            sCurrentJsQuizType = "DragAndDrop";

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
            
            for (int i = 0;  i < 2;  i++) {
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
            gtbc1.Width = 450;
            gtbc1.DefaultCellStyle.NullValue = "<type phrase here>";
            dataGridCurrent.Columns.Add(gtbc1);

            //ExtendedDataGridMultiLineTextBoxColumn tbc1 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc1.MappingName = "Column1";
            //tbc1.TextBox.Multiline = true;
            //tbc1.MinimumHeight = 35;
            //tbc1.HeaderText = "Beginning Phrase";
            //tbc1.Width = 450;
            //tbc1.NullText = "<type phrase here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc1);
            DataGridViewTextBoxColumn gtbc3 = new DataGridViewTextBoxColumn();
            gtbc3.HeaderText = "Ending Phrase";
            gtbc3.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc3.DataPropertyName = "Column2";
            //gtbc1.ValueType = typeof(string);
            gtbc3.Width = 450;
            gtbc3.DefaultCellStyle.NullValue = "<type phrase here>";
            dataGridCurrent.Columns.Add(gtbc3);

            //ExtendedDataGridMultiLineTextBoxColumn tbc2 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc2.MappingName = "Column2";
            //tbc2.HeaderText = "Ending Phrase";
            //tbc2.TextBox.Multiline = true;
            //tbc2.MinimumHeight = 35;
            //tbc2.Width = 450;
            //tbc2.NullText = "<type phrase here>";

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
            string sMatchAnswersLength = "answers[";
            int    iAnswersLength = sJavascriptData.LastIndexOf(sMatchAnswersLength);
            int    iNumAnswersEnd = sJavascriptData.IndexOf("]", iAnswersLength + sMatchAnswersLength.Length);
            string sAnswersLength = sJavascriptData.Substring(iAnswersLength + sMatchAnswersLength.Length, iNumAnswersEnd - (iAnswersLength + sMatchAnswersLength.Length));

            for (int i = 0;  (sAnswersLength.Length > 0) && (i < (Convert.ToInt32(sAnswersLength) + 1));  i++) {
                string sQuestionMatch = "questions[" + i.ToString() + "]=\"";
                int iNextQuestionBegin = sJavascriptData.IndexOf(sQuestionMatch);
                int iNextQuestionEnd   = sJavascriptData.IndexOf("\"", iNextQuestionBegin + sQuestionMatch.Length);
                string sNextQuestion   = sJavascriptData.Substring(iNextQuestionBegin + sQuestionMatch.Length, iNextQuestionEnd - (iNextQuestionBegin + sQuestionMatch.Length));
                
                string sAnswerMatch = "answers[" + i.ToString() + "]=\"";
                int iNextAnswerBegin = sJavascriptData.IndexOf(sAnswerMatch);
                int iNextAnswerEnd   = sJavascriptData.IndexOf("\"", iNextAnswerBegin + sAnswerMatch.Length);
                string sNextAnswer   = sJavascriptData.Substring(iNextAnswerBegin + sAnswerMatch.Length, iNextAnswerEnd - (iNextAnswerBegin + sAnswerMatch.Length));

                DataRow drNewData = dTableCurrent.NewRow();
                drNewData["Column1"] = sNextQuestion;
                drNewData["Column2"] = sNextAnswer;
                dTableCurrent.Rows.Add(drNewData);
            }

            string sCardMatch = "optionCardFontSize=\"";
            int iCardBegin    = sJavascriptData.LastIndexOf(sCardMatch);
            int iCardEnd      = sJavascriptData.IndexOf("\"", iCardBegin + sCardMatch.Length);
            string sCard      = sJavascriptData.Substring(iCardBegin + sCardMatch.Length, iCardEnd - (iCardBegin + sCardMatch.Length));

            // Set Options on Js Options Tab Page
            //IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsDd", false)[0]).Controls.GetEnumerator();

            //ieTabPage.MoveNext();
            //ieTabPage.MoveNext();
            //((ComboBox)ieTabPage.Current).Text = sCard;


            Control.ControlCollection ocTabPageJsOptions = tabData.Controls.Find("tabPageJsOptionsDd", false)[0].Controls;

            ((ComboBox)ocTabPageJsOptions.Find("comboBoxDdCardFontSize", false)[0]).Text = sCard;
            
        }


        /// <summary>
        ///
        /// </summary>
        public override string ParseGridAndCreateJavascriptData(DataGridView dataGridCurrent, string sJsDataTemplate, Form cMainForm, TabControl tabData)
        {
            string sReturnJavascript = sJsDataTemplate;

            if (dataGridCurrent.DataSource != null) {

                string  sMatchingQuestionsLine = "\r\nquestions[NNN]=\"QQQ\";";
                string  sMatchingAnswersLine   = "\r\nanswers[NNN]=\"AAA\";";

                string  sQuestionLines = "";
                string  sAnswerLines   = "";

                CurrencyManager cm = (CurrencyManager)cMainForm.BindingContext[dataGridCurrent.DataSource]; 

                for (int row = 0;  row < cm.Count;  row++) {

                    string sQuestion = dataGridCurrent[0, row].Value.ToString();
                    string sAnswer   = dataGridCurrent[1, row].Value.ToString();

                    if ((sQuestion.Length > 0) && (sAnswer.Length > 0)) {

                        string sTempQuestionsLine = sMatchingQuestionsLine;
                        sTempQuestionsLine = sTempQuestionsLine.Replace("NNN", row.ToString());
                        sQuestion = sQuestion.Replace("\"", "&quot;");
                        sTempQuestionsLine = sTempQuestionsLine.Replace("QQQ", sQuestion);

                        sQuestionLines = sQuestionLines + sTempQuestionsLine;

                        string sTempAnswersLine = sMatchingAnswersLine;
                        sTempAnswersLine = sTempAnswersLine.Replace("NNN", row.ToString());
                        sAnswer = sAnswer.Replace("\"", "&quot;");
                        sTempAnswersLine = sTempAnswersLine.Replace("AAA", sAnswer);

                        sAnswerLines = sAnswerLines + sTempAnswersLine;

                    }
                }

                int iQuestionsEnd = sReturnJavascript.IndexOf("//QUESTIONSEND");
                sReturnJavascript = sReturnJavascript.Insert(iQuestionsEnd, sQuestionLines + "\r\n" + sAnswerLines + "\r\n");

                // Get Options to write
                IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsDd", false)[0]).Controls.GetEnumerator();

                ieTabPage.MoveNext();
                ieTabPage.MoveNext();
                string strCardFontSize = ((ComboBox)ieTabPage.Current).Text;

                sReturnJavascript += "\r\noptionCardFontSize=\"" + strCardFontSize + "\";\r\n";
            }
            return (sReturnJavascript);
        }

    }
}
