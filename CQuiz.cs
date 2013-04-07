using System;
using System.Data;
using System.Windows.Forms;

namespace BrowserApp
{
	/// <summary>
	/// Summary description for CQuiz.
	/// </summary>
	public class CQuiz
	{

        protected string sCurrentJsQuizType = "None";


        /// <summary>
        ///
        /// </summary>
        public CQuiz(ref DataGrid dataGridCurrent, ref DataTable dTableCurrent)
		{
			//
			// TODO: Add constructor logic here
			//

            sCurrentJsQuizType = "None";

            InitializeGrid(ref dataGridCurrent, ref dTableCurrent);
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
        public virtual void InitializeGrid(ref DataGrid dataGridCurrent, ref DataTable dTableCurrent)
        {
            dataGridCurrent.AllowSorting = false;
            dataGridCurrent.Visible = false;
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
        public virtual void FillGridWithJavascriptData(ref DataGrid dataGridCurrent, ref DataTable dTableCurrent, string sJavascriptData, TabControl tabData)
        {
            InitializeGrid(ref dataGridCurrent, ref dTableCurrent);
        }


        /// <summary>
        ///
        /// </summary>
        public virtual string ParseGridAndCreateJavascriptData(DataGrid dataGridCurrent, string sJsDataTemplate, Form cMainForm, TabControl tabData) {
            string sReturnJavascript = sJsDataTemplate;
            return (sReturnJavascript);
        }

    }
}

