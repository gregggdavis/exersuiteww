using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;

using Leadit.ExtendedDataGrid;


namespace BrowserApp 
{
    /// <summary>
    /// Summary description for CQuizSentenceCombo.
    /// </summary>
    public class CQuizSentenceCombo : CQuiz 
    {

        public CQuizSentenceCombo(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent) : base(ref dataGridCurrent, ref dTableCurrent)
        {
            //
            // TODO: Add constructor logic here
            //

            sCurrentJsQuizType = "SentenceCombo";

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
            

            for (int i = 0;  i < 5;  i++) {
                dTableCurrent.Columns.Add("Column" + (i+1).ToString(), System.Type.GetType("System.String"));
            }

            DataGridViewTextBoxColumn gtbc1 = new DataGridViewTextBoxColumn();
            gtbc1.HeaderText = "Section Header Text";
            gtbc1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc1.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc1.DataPropertyName = "Column1";
            //gtbc1.ValueType = typeof(string);
            gtbc1.Width = 140;
            gtbc1.DefaultCellStyle.NullValue = "<type header here>";
            dataGridCurrent.Columns.Add(gtbc1);
            // Add a GridColumnStyle and set the MappingName 
            // to the name of a DataColumn in the DataTable. 
            // Set the HeaderText and Width properties. 
            //ExtendedDataGridMultiLineTextBoxColumn tbc1 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc1.MappingName = "Column1";
            //tbc1.TextBox.Multiline = true;
            //tbc1.MinimumHeight = 35;
            //tbc1.HeaderText = "Section Header Text";
            //tbc1.Width = 140;
            //tbc1.NullText = "<type header here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc1);

            DataGridViewTextBoxColumn gtbc2 = new DataGridViewTextBoxColumn();
            gtbc2.HeaderText = "Sentences to Combine";
            gtbc2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc2.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc2.DataPropertyName = "Column2";
            //gtbc1.ValueType = typeof(string);
            gtbc2.Width = 400;
            gtbc2.DefaultCellStyle.NullValue = "<type sentences here>";
            dataGridCurrent.Columns.Add(gtbc2);

            //ExtendedDataGridMultiLineTextBoxColumn tbc2 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc2.MappingName = "Column2";
            //tbc2.HeaderText = "Sentences to Combine";
            //tbc2.TextBox.Multiline = true;
            //tbc2.MinimumHeight = 35;
            //tbc2.Width = 400;
            //tbc2.NullText = "<type sentences here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc2);
            DataGridViewTextBoxColumn gtbc3 = new DataGridViewTextBoxColumn();
            gtbc3.HeaderText = "Correct Answer Sentence";
            gtbc3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc3.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc3.DataPropertyName = "Column3";
            //gtbc1.ValueType = typeof(string);
            gtbc3.Width = 370;
            gtbc3.DefaultCellStyle.NullValue = "<type answer here>";
            dataGridCurrent.Columns.Add(gtbc3);
            //ExtendedDataGridMultiLineTextBoxColumn tbc3 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc3.MappingName = "Column3";
            //tbc3.HeaderText = "Correct Answer Sentence";
            //tbc3.TextBox.Multiline = true;
            //tbc3.MinimumHeight = 35;
            //tbc3.Width = 370;
            //tbc3.NullText = "<type answer here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc3);
            DataGridViewTextBoxColumn gtbc4 = new DataGridViewTextBoxColumn();
            gtbc4.HeaderText = "Width";
            gtbc4.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc4.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc4.DataPropertyName = "Column4";
            //gtbc1.ValueType = typeof(string);
            gtbc4.Width = 50;
            gtbc4.DefaultCellStyle.NullValue = "<# of columns here>";
            dataGridCurrent.Columns.Add(gtbc4);

            //ExtendedDataGridMultiLineTextBoxColumn tbc4 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc4.MappingName = "Column4";
            //tbc4.HeaderText = "Width";
            //tbc4.TextBox.Multiline = true;
            //tbc4.MinimumHeight = 35;
            //tbc4.Width = 50;
            //tbc4.NullText = "<# of columns here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc4);

            DataGridViewTextBoxColumn gtbc5 = new DataGridViewTextBoxColumn();
            gtbc5.HeaderText = "Height";
            gtbc5.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gtbc5.SortMode = DataGridViewColumnSortMode.NotSortable;
            gtbc5.DataPropertyName = "Column5";
            //gtbc1.ValueType = typeof(string);
            gtbc5.Width = 50;
            gtbc5.DefaultCellStyle.NullValue = "<# of rows here>";
            dataGridCurrent.Columns.Add(gtbc5);

            //ExtendedDataGridMultiLineTextBoxColumn tbc5 = new ExtendedDataGridMultiLineTextBoxColumn();
            //tbc5.MappingName = "Column5";
            //tbc5.HeaderText = "Height";
            //tbc5.TextBox.Multiline = true;
            //tbc5.MinimumHeight = 35;
            //tbc5.Width = 50;
            //tbc5.NullText = "<# of rows here>";

            //dgdtblStyle.GridColumnStyles.Add(tbc5);

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

        public override void DatagridPositionKeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridCurrentMain.CurrentCell.ColumnIndex != 3 && dataGridCurrentMain.CurrentCell.ColumnIndex != 4) return;
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')))
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
        public override void FillGridWithJavascriptData(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent, string sJavascriptData, TabControl tabData)
        {
            AcceptChanges(dataGridCurrent);
            string sQuestionsLength = GetLastMatchedString(sJavascriptData, "questions[", "]");

            for (int i = 0;  (sQuestionsLength.Length > 0) && (i < (Convert.ToInt32(sQuestionsLength) + 1));  i++) {
                string sNextHeader = GetLastMatchedString(sJavascriptData, "headers[" + i.ToString() + "]=\"", "\"");

                string sNextQuestion = GetLastMatchedString(sJavascriptData, "questions[" + i.ToString() + "]=\"", "\"");
                string sNextAnswer = GetLastMatchedString(sJavascriptData, "answers[" + i.ToString() + "]=\"", "\"");

                string sCols = GetLastMatchedString(sJavascriptData, "aWidth[" + i.ToString() + "]=", ";");
                string sRows = GetLastMatchedString(sJavascriptData, "aHeight[" + i.ToString() + "]=", ";");

                DataRow drNewData = dTableCurrent.NewRow();
                drNewData["Column1"] = sNextHeader;
                drNewData["Column2"] = sNextQuestion;
                drNewData["Column3"] = sNextAnswer;
                drNewData["Column4"] = sCols;
                drNewData["Column5"] = sRows;
                dTableCurrent.Rows.Add(drNewData);
            }

            string sArrangement         = GetLastMatchedString(sJavascriptData, "bOnePerPage=", ";");
            string sMouseOverRight      = GetLastMatchedString(sJavascriptData, "bMouseOverPlaceRight=", ";");
            string sShowQuestionNumbers = GetLastMatchedString(sJavascriptData, "bShowQuestionNumbers=", ";");

            // Set Options on Js Options Tab Page
            //IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsSc", false)[0]).Controls.GetEnumerator();

            //ieTabPage.MoveNext();
            //ieTabPage.MoveNext();

            ////GAD - Assigning Enumerator and Iterating through via Move next can be removed and replaced with just something like this foreach control:
            ////((CheckBox)tabData.Controls.Find("checkBoxScShowNumbers", false)[0]).Checked = sShowQuestionNumbers.Equals("true");

            //((CheckBox)ieTabPage.Current).Checked = sShowQuestionNumbers.Equals("true");
            //ieTabPage.MoveNext();
            //((CheckBox)ieTabPage.Current).Checked = sMouseOverRight.Equals("true");
            //ieTabPage.MoveNext();
            //ieTabPage.MoveNext();
            //if (sArrangement.Equals("true")) {
            //    ((RadioButton)ieTabPage.Current).Checked = true;
            //    ieTabPage.MoveNext();
            //    ((RadioButton)ieTabPage.Current).Checked = false;
            //} else {
            //    ((RadioButton)ieTabPage.Current).Checked = false;
            //    ieTabPage.MoveNext();
            //    ((RadioButton)ieTabPage.Current).Checked = true;
            //}

            Control.ControlCollection ocTabPageJsOptions = tabData.Controls.Find("tabPageJsOptionsSc", false)[0].Controls;

            ((CheckBox)ocTabPageJsOptions.Find("checkBoxScShowNumbers", false)[0]).Checked = sShowQuestionNumbers.Equals("true");
            ((CheckBox)ocTabPageJsOptions.Find("checkBoxScMouseoverRight", false)[0]).Checked = sMouseOverRight.Equals("true");
            if (sArrangement.Equals("true"))
            {
                ((RadioButton)ocTabPageJsOptions.Find("radioButtonScQuestionOne", false)[0]).Checked = true;
                ((RadioButton)ocTabPageJsOptions.Find("radioButtonScQuestionAll", false)[0]).Checked = false;
            }
            else
            {
                ((RadioButton)ocTabPageJsOptions.Find("radioButtonScQuestionOne", false)[0]).Checked = true;
                ((RadioButton)ocTabPageJsOptions.Find("radioButtonScQuestionAll", false)[0]).Checked = false;
            }
            

        }


        /// <summary>
        ///
        /// </summary>
        public override string ParseGridAndCreateJavascriptData(DataGridView dataGridCurrent, string sJsDataTemplate, Form cMainForm, TabControl tabData)
        {
            string sReturnJavascript = sJsDataTemplate;

            if (dataGridCurrent.DataSource != null) {

                string  sMatchingHeadersLine   = "\r\nheaders[NNN]=\"HHH\";";
                string  sMatchingQuestionsLine = "\r\nquestions[NNN]=\"QQQ\";";
                string  sMatchingAnswersLine   = "\r\nanswers[NNN]=\"AAA\";";
                string  sMatchingColsLine      = "\r\naWidth[NNN]=III;";
                string  sMatchingRowsLine      = "\r\naHeight[NNN]=III;";

                string  sHeaderLines   = "";
                string  sQuestionLines = "";
                string  sAnswerLines   = "";
                string  sColsLines     = "";
                string  sRowsLines     = "";

                CurrencyManager cm = (CurrencyManager)cMainForm.BindingContext[dataGridCurrent.DataSource]; 

                for (int row = 0;  row < cm.Count;  row++) {

                    string sHeader   = dataGridCurrent[0,row].Value.ToString();
                    string sQuestion = dataGridCurrent[1,row].Value.ToString();
                    string sAnswer   = dataGridCurrent[2,row].Value.ToString();
                    string sCols     = dataGridCurrent[3,row].Value.ToString();
                    if (sCols == "") {
                      sCols = "0";
                    }
                    string sRows     = dataGridCurrent[4,row].Value.ToString();
                    if (sRows == "") 
                    {
                        sRows = "0";
                    }

                    if ((sQuestion.Length > 0) && (sAnswer.Length > 0)) 
                    {

                        string sTempHeadersLine = sMatchingHeadersLine;
                        sTempHeadersLine = sTempHeadersLine.Replace("NNN", row.ToString());
                        sHeader = sHeader.Replace("\"", "&quot;");
                        sTempHeadersLine = sTempHeadersLine.Replace("HHH", sHeader);

                        sHeaderLines = sHeaderLines + sTempHeadersLine;

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

                        string sTempColsLine = sMatchingColsLine;
                        sTempColsLine = sTempColsLine.Replace("NNN", row.ToString());
                        sTempColsLine = sTempColsLine.Replace("III", sCols);

                        sColsLines = sColsLines + sTempColsLine;

                        string sTempRowsLine = sMatchingRowsLine;
                        sTempRowsLine = sTempRowsLine.Replace("NNN", row.ToString());
                        sTempRowsLine = sTempRowsLine.Replace("III", sRows);

                        sRowsLines = sRowsLines + sTempRowsLine;
                    }
                }

                int iHeadersEnd   = sReturnJavascript.IndexOf("//HEADERSEND");
                sReturnJavascript = sReturnJavascript.Insert(iHeadersEnd, sHeaderLines + "\r\n" + sQuestionLines + "\r\n" + sAnswerLines + "\r\n" + sColsLines + "\r\n" + sRowsLines + "\r\n");

                // Get Options to write
                //IEnumerator ieTabPage = ((TabPage)tabData.Controls.Find("tabPageJsOptionsSc", false)[0]).Controls.GetEnumerator();

                //ieTabPage.MoveNext();
                //ieTabPage.MoveNext();
                //string sShowQuestionNumbers = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                //ieTabPage.MoveNext();
                //string sMouseOverRight = ((CheckBox)ieTabPage.Current).Checked ? "true" : "false";
                //ieTabPage.MoveNext();
                //ieTabPage.MoveNext();
                //string sOnePerPage = "false";
                //if (((RadioButton)ieTabPage.Current).Checked) 
                //{
                //    sOnePerPage = "true";
                //}

                Control.ControlCollection ocTabPageJsOptions = tabData.Controls.Find("tabPageJsOptionsSc", false)[0].Controls;

                string sShowQuestionNumbers = ((CheckBox)ocTabPageJsOptions.Find("checkBoxScShowNumbers", false)[0]).Checked ? "true" : "false" ;
                string sMouseOverRight =      ((CheckBox)ocTabPageJsOptions.Find("checkBoxScMouseoverRight", false)[0]).Checked ? "true" : "false";
                string sOnePerPage = "false";
                if (((RadioButton)ocTabPageJsOptions.Find("radioButtonScQuestionOne", false)[0]).Checked)
                {
                    sOnePerPage = "true";
                }
                

                sReturnJavascript += "\r\nbOnePerPage=" + sOnePerPage + ";\r\n";
                sReturnJavascript += "\r\nbMouseOverPlaceRight=" + sMouseOverRight + ";\r\n";
                sReturnJavascript += "\r\nbShowQuestionNumbers=" + sShowQuestionNumbers + ";\r\n";

            }
            return (sReturnJavascript);
        }

    }
}
