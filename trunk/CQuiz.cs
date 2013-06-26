using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;

namespace BrowserApp
{
	/// <summary>
	/// Summary description for CQuiz.
	/// </summary>
	public class CQuiz
	{
        protected DataGridView dataGridCurrentMain;
        protected string sCurrentJsQuizType = "None";
        private bool _DataChanged = false;
        public bool DataChanged
        {
            set
            {
                _DataChanged = value;
            }
            get
            {
                return _DataChanged;
            }

        }
        public delegate void ChangedEventHandler(bool changed);
        public event ChangedEventHandler Changed;
        protected virtual void OnChanged(bool changed)
        {
            if (Changed != null)
                Changed(changed);
        }
        /// <summary>
        ///
        /// </summary>
        public CQuiz(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent)
		{
			//
			// TODO: Add constructor logic here
			//

            sCurrentJsQuizType = "None";
            dataGridCurrentMain = dataGridCurrent;
            InitializeGrid(ref dataGridCurrent, ref dTableCurrent);
            dataGridCurrent.CellValueChanged += new DataGridViewCellEventHandler(dataGridCurrent_CellValueChanged);
            dataGridCurrent.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridCurrent_EditingControlShowing);
        
            dataGridCurrent.KeyDown += new KeyEventHandler(dataGridCurrent_KeyDown);
		}



        /// <summary>
        ///
        /// </summary>
        public string GetQuizType()
        {
            return(sCurrentJsQuizType);
        }


        /// <summary>
        ///
        /// </summary>
        public string GetLastMatchedString(string sTheString, string sMatch, string sDeliminator)
        {
            string sReturnMatched = "";
            if (sTheString != "") {
                int iNextBegin = sTheString.LastIndexOf(sMatch);
                int iNextEnd   = sTheString.IndexOf(sDeliminator, iNextBegin + sMatch.Length);
                sReturnMatched = sTheString.Substring(iNextBegin + sMatch.Length, iNextEnd - (iNextBegin + sMatch.Length));
            }
            return(sReturnMatched);
        }


        /// <summary>
        ///
        /// </summary>
        public string GetMatchedString(string sTheString, string sMatch, string sDeliminator)
        {
            string sReturnMatched = "";
            if (sTheString != "") {
                int iNextBegin = sTheString.IndexOf(sMatch);
                int iNextEnd   = sTheString.IndexOf(sDeliminator, iNextBegin + sMatch.Length);
                sReturnMatched = sTheString.Substring(iNextBegin + sMatch.Length, iNextEnd - (iNextBegin + sMatch.Length));
            }
            return(sReturnMatched);
        }


        /// <summary>
        ///
        /// </summary>
        public virtual void InitializeGrid(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent)
        {
            foreach(DataGridViewColumn column in dataGridCurrent.Columns)
            {
                dataGridCurrent.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dataGridCurrent.Visible = false;
            
        }

        private void dataGridCurrent_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Update the balance column whenever the value of any cell changes.
            OnChanged(true);
        }

        private void dataGridCurrent_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Update the balance column whenever the value of any cell changes.
            TextBox txtBox = e.Control as TextBox;
            if (txtBox != null)
            {
                // Handle the TextChanged event.
                txtBox.TextChanged += new EventHandler(txtBox_TextChanged);
            }
            
        }

        void txtBox_TextChanged(object sender, EventArgs e)
        {
            OnChanged(true);
        }

        private void dataGridCurrent_KeyDown(object sender, KeyEventArgs e)
        {
            // Update the balance column whenever the value of any cell changes.
            if(e.KeyData == Keys.Delete)
            {
                if (dataGridCurrentMain.SelectedCells.Count > 0)
                {
                    int selectedIndex = dataGridCurrentMain.SelectedCells[0].RowIndex;

                    if (selectedIndex < (dataGridCurrentMain.RowCount - 1))
                    {
                        dataGridCurrentMain.Rows.RemoveAt(selectedIndex);
                    }
                    
                }
                OnChanged(true);
            }
        }

       

        /// <summary>
        /// Keypress handler for date values.
        /// </summary>
        public virtual void DatagridPositionKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }



        /// <summary>
        ///
        /// </summary>
        public virtual void FillGridWithJavascriptData(ref DataGridView dataGridCurrent, ref DataTable dTableCurrent, string sJavascriptData, TabControl tabData)
        {
            InitializeGrid(ref dataGridCurrent, ref dTableCurrent);
        }


        /// <summary>
        ///
        /// </summary>
        public virtual string ParseGridAndCreateJavascriptData(DataGridView dataGridCurrent, string sJsDataTemplate, Form cMainForm, TabControl tabData) {
            string sReturnJavascript = sJsDataTemplate;
            dataGridCurrent.EndEdit();
            return (sReturnJavascript);
        }

        public void AcceptChanges(DataGridView dataGridCurrent)
        {
            
            if (dataGridCurrent.IsCurrentCellDirty || dataGridCurrent.IsCurrentRowDirty)
            {
                dataGridCurrent.CommitEdit(DataGridViewDataErrorContexts.Commit);
                
            }
            dataGridCurrent.EndEdit();
            //dataGridCurrent.is
            //DataTable table = dataGridCurrent.DataSource as DataTable;
            //if (table.GetChanges() != null)
            //{
            //    foreach (DataRow row in table.Rows)
            //    {
            //        row.AcceptChanges();
            //    }
            //}
            
        }
        public static List<DataGridViewEditingControlShowingEventHandler> cShowingEventHandlers = new List<DataGridViewEditingControlShowingEventHandler>();
        public static void RemoveClickEvent(DataGridView b)
        {
            ClearDelegate();
        }

        private static void ClearDelegate()
        {
            for (int i = 0; i < cShowingEventHandlers.Count; i++)
            {
                DataGridViewEditingControlShowingEventHandler delg = cShowingEventHandlers[i];
                Delegate[] delegates = delg.GetInvocationList();
                foreach (Delegate d in delegates)
                {
                    delg -= (DataGridViewEditingControlShowingEventHandler)d;
                }
            }
            cShowingEventHandlers.Clear();
            
        }
    }
}

