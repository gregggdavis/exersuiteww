using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
//using mshtml;
using System.Text.RegularExpressions;

using Microsoft.Win32;
//using Leadit.ExtendedDataGrid;

namespace BrowserApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.DataGridView dataGridQuestions;
        private DataTable dTable;
        private System.Windows.Forms.Button buttonPreview;

        private string  sJsDataTemplate = "";
        private string  sJsQuizTemplate = "";

        private string sHtmlBlankTemplate = "<HTML><HEAD><TITLE> Blank Html Template </TITLE></HEAD><META http-equiv=Content-Type content=\"text/html; charset=utf-8\"><BODY><DIV align=center><!--BEGINJAVASCRIPTDATA--><!--ENDJAVASCRIPTDATA-->\r\n<!--BEGINJAVASCRIPTQUIZ--><!--ENDJAVASCRIPTQUIZ--></DIV></BODY></HTML>\r\n";

        private string  sFlashObjectTemplate = "<br /><object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" height=\"HHH1\" width=\"WWW1\"><param name=\"movie\" value=\"NNN1\"><param name=\"quality\" value=\"best\"><param name=\"play\" value=\"true\"><embed height=\"HHH2\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" src=\"NNN2\" type=\"application/x-shockwave-flash\" width=\"WWW2\" quality=\"best\" play=\"true\"></object><br />";

        private string  sHtmlTemplate          = "";
        private string  sJsQuizBasePath        = Environment.CurrentDirectory + "\\Never Open - Templates - Javascript\\";
        private string  sHtmlTemplatesBasePath = Environment.CurrentDirectory + "\\Never Open - Templates - Html\\";
        private string  sRegistryKeyLocation   = "Software\\WhalesWeb\\ExerciseSuite";
        private string  sJsFileSavedAsName   = "";
        private string  sHtmlFileSavedAsName = "";

        private CQuiz   cQuiz = null;

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuFile;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxHtmlTemplate;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuNew;
        private System.Windows.Forms.TabControl tabControlData;
        private System.Windows.Forms.TabPage tabPageJsData;
        private System.Windows.Forms.TabPage tabPageHtmlData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUnitNumber;
        private System.Windows.Forms.TextBox textBoxAssignmentNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPageNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPageTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxInstructionsTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxInstructionsText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNextPageText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxQuizFlashFileName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxQuizFlashHeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxQuizFlashWidth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxDdCardFontSize;
        private System.Windows.Forms.ComboBox comboBoxNaviFlashFileName;
        private System.Windows.Forms.ComboBox comboBoxNaviFlashHeight;
        private System.Windows.Forms.ComboBox comboBoxNaviFlashWidth;
        private System.Windows.Forms.TabPage tabPageJsOptionsFi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tabPageJsOptionsDd;
        private System.Windows.Forms.TabPage tabPageJsOptionsNone;
        private System.Windows.Forms.TextBox textBoxJsOptionsFiChoices;
        private System.Windows.Forms.TabPage tabPageJsOptionsMa;
        private System.Windows.Forms.TextBox textBoxMaResultsCols;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxMaResultsRows;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPageJsOptionsMc;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxMtResultsCols;
        private System.Windows.Forms.TextBox textBoxMtResultsRows;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RadioButton radioButtonMcQuestionOne;
        private System.Windows.Forms.RadioButton radioButtonMcQuestionAll;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RadioButton radioButtonFiQuestionAll;
        private System.Windows.Forms.RadioButton radioButtonFiQuestionOne;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBoxFiResultsCols;
        private System.Windows.Forms.TextBox textBoxFiResultsRows;
        private System.Windows.Forms.CheckBox checkBoxFiShowNumbers;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBoxFiPageWidth;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabPage tabPageJsOptionsSc;
        private System.Windows.Forms.RadioButton radioButtonScQuestionOne;
        private System.Windows.Forms.RadioButton radioButtonScQuestionAll;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox checkBoxScMouseoverRight;
        private System.Windows.Forms.MenuItem menuOpen;
        private System.Windows.Forms.MenuItem menuSaveAs;
        private System.Windows.Forms.MenuItem menuClose;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuSave;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.CheckBox checkBoxScShowNumbers;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox checkBoxMcFeedbackInPopup;
        private System.Windows.Forms.CheckBox checkBoxMcFeedbackInResults;
        private System.Windows.Forms.CheckBox checkBoxMcCheckAnswersButton;
        private Splitter splitter1;
        public WebBrowser webBrowserInput;
        private CheckBox checkBoxFiTypeQuiz;
        private IContainer components;


        /// <summary>
        ///
        /// </summary>
        public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            this.Text += " " + GetShortVersionInfo();

            cQuiz = new CQuiz(ref dataGridQuestions, ref dTable);
            buttonPreview.Text = "Render data for :  " + cQuiz.GetQuizType();

            RegistryInitialize();

            tabControlData.TabPages.Clear();
            tabControlData.TabPages.Add(tabPageJsData);
            tabControlData.TabPages.Add(tabPageJsOptionsNone);
            tabControlData.TabPages.Add(tabPageHtmlData);

//            object oEmpty = null;
//            axWebBrowserInput.Navigate( "about:blank", ref oEmpty, ref oEmpty, ref oEmpty, ref oEmpty);
            webBrowserInput.Navigate("about:blank");

            InitializeBrowser();

            comboBoxHtmlTemplate.Items.Add("None");
            string[] sHtmlFileNames = Directory.GetFiles(sHtmlTemplatesBasePath);
            foreach (string sFileName in sHtmlFileNames) {
                string sName = sFileName.Substring(sFileName.LastIndexOf("\\") + 1);
                //sName.Substring(0, sName.IndexOf(".htm"));
                comboBoxHtmlTemplate.Items.Add(sName);
            }
            comboBoxHtmlTemplate.SelectedIndex = 0;

            comboBoxNaviFlashFileName.Items.Add("unav_01.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_01plus.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_02.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_02plus.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_03.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_03plus.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_04.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_04plus.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_05.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_05plus.swf");
            comboBoxNaviFlashFileName.Items.Add("unav_exit.swf");
            comboBoxNaviFlashFileName.Text = "";

            comboBoxNaviFlashHeight.Items.Add("38");
            comboBoxNaviFlashHeight.Text = "";
            comboBoxNaviFlashWidth.Items.Add("360");
            comboBoxNaviFlashWidth.Text = "";

            comboBoxDdCardFontSize.Items.Add("xx-small");
            comboBoxDdCardFontSize.Items.Add("x-small");
            comboBoxDdCardFontSize.Items.Add("small");
            comboBoxDdCardFontSize.Items.Add("medium");
            comboBoxDdCardFontSize.Items.Add("large");
            comboBoxDdCardFontSize.Items.Add("x-large");
            comboBoxDdCardFontSize.Items.Add("xx-large");
            comboBoxDdCardFontSize.SelectedIndex = 2;

            textBoxMaResultsCols.Text = "47";
            textBoxMaResultsRows.Text = "8";

            //DisplayQuizChooser();
        }



		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.dataGridQuestions = new System.Windows.Forms.DataGridView();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuNew = new System.Windows.Forms.MenuItem();
            this.menuOpen = new System.Windows.Forms.MenuItem();
            this.menuClose = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuSave = new System.Windows.Forms.MenuItem();
            this.menuSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuProperties = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxHtmlTemplate = new System.Windows.Forms.ComboBox();
            this.tabControlData = new System.Windows.Forms.TabControl();
            this.tabPageJsData = new System.Windows.Forms.TabPage();
            this.tabPageJsOptionsNone = new System.Windows.Forms.TabPage();
            this.tabPageJsOptionsMc = new System.Windows.Forms.TabPage();
            this.checkBoxMcCheckAnswersButton = new System.Windows.Forms.CheckBox();
            this.checkBoxMcFeedbackInResults = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.checkBoxMcFeedbackInPopup = new System.Windows.Forms.CheckBox();
            this.radioButtonMcQuestionOne = new System.Windows.Forms.RadioButton();
            this.radioButtonMcQuestionAll = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxMtResultsCols = new System.Windows.Forms.TextBox();
            this.textBoxMtResultsRows = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPageJsOptionsMa = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxMaResultsCols = new System.Windows.Forms.TextBox();
            this.textBoxMaResultsRows = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPageJsOptionsSc = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.checkBoxScShowNumbers = new System.Windows.Forms.CheckBox();
            this.checkBoxScMouseoverRight = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.radioButtonScQuestionOne = new System.Windows.Forms.RadioButton();
            this.radioButtonScQuestionAll = new System.Windows.Forms.RadioButton();
            this.label30 = new System.Windows.Forms.Label();
            this.tabPageJsOptionsDd = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDdCardFontSize = new System.Windows.Forms.ComboBox();
            this.tabPageJsOptionsFi = new System.Windows.Forms.TabPage();
            this.checkBoxFiTypeQuiz = new System.Windows.Forms.CheckBox();
            this.textBoxFiPageWidth = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.checkBoxFiShowNumbers = new System.Windows.Forms.CheckBox();
            this.textBoxFiResultsCols = new System.Windows.Forms.TextBox();
            this.textBoxFiResultsRows = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.radioButtonFiQuestionOne = new System.Windows.Forms.RadioButton();
            this.radioButtonFiQuestionAll = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxJsOptionsFiChoices = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPageHtmlData = new System.Windows.Forms.TabPage();
            this.textBoxNextPageText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxInstructionsText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxInstructionsTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPageTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPageNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAssignmentNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUnitNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxQuizFlashWidth = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxQuizFlashHeight = new System.Windows.Forms.TextBox();
            this.textBoxQuizFlashFileName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxNaviFlashWidth = new System.Windows.Forms.ComboBox();
            this.comboBoxNaviFlashHeight = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBoxNaviFlashFileName = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.webBrowserInput = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridQuestions)).BeginInit();
            this.tabControlData.SuspendLayout();
            this.tabPageJsData.SuspendLayout();
            this.tabPageJsOptionsMc.SuspendLayout();
            this.tabPageJsOptionsMa.SuspendLayout();
            this.tabPageJsOptionsSc.SuspendLayout();
            this.tabPageJsOptionsDd.SuspendLayout();
            this.tabPageJsOptionsFi.SuspendLayout();
            this.tabPageHtmlData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridQuestions
            // 
            this.dataGridQuestions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridQuestions.Location = new System.Drawing.Point(0, 0);
            this.dataGridQuestions.Name = "dataGridQuestions";
            this.dataGridQuestions.RowHeadersVisible = false;
            this.dataGridQuestions.Size = new System.Drawing.Size(906, 230);
            this.dataGridQuestions.TabIndex = 1;
            // 
            // buttonPreview
            // 
            this.buttonPreview.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreview.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonPreview.Location = new System.Drawing.Point(303, 253);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(244, 24);
            this.buttonPreview.TabIndex = 1;
            this.buttonPreview.Text = "Render data for:  None";
            this.buttonPreview.UseVisualStyleBackColor = false;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuNew,
            this.menuOpen,
            this.menuClose,
            this.menuItem1,
            this.menuSave,
            this.menuSaveAs,
            this.menuItem4,
            this.menuProperties,
            this.menuItem5,
            this.menuExit});
            this.menuFile.Text = "File";
            // 
            // menuNew
            // 
            this.menuNew.Index = 0;
            this.menuNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuNew.Text = "New Quiz";
            this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Index = 1;
            this.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuOpen.Text = "Open Js or Html";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuClose
            // 
            this.menuClose.Enabled = false;
            this.menuClose.Index = 2;
            this.menuClose.Text = "Close";
            this.menuClose.Visible = false;
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // menuSave
            // 
            this.menuSave.Enabled = false;
            this.menuSave.Index = 4;
            this.menuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuSave.Text = "Save (old)";
            this.menuSave.Visible = false;
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Index = 5;
            this.menuSaveAs.Text = "Save Html";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 6;
            this.menuItem4.Text = "-";
            // 
            // menuProperties
            // 
            this.menuProperties.Index = 7;
            this.menuProperties.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuProperties.Text = "Properties";
            this.menuProperties.Click += new System.EventHandler(this.menuProperties_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 8;
            this.menuItem5.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 9;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Html Template:";
            // 
            // comboBoxHtmlTemplate
            // 
            this.comboBoxHtmlTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHtmlTemplate.Location = new System.Drawing.Point(144, 8);
            this.comboBoxHtmlTemplate.Name = "comboBoxHtmlTemplate";
            this.comboBoxHtmlTemplate.Size = new System.Drawing.Size(300, 21);
            this.comboBoxHtmlTemplate.TabIndex = 1;
            this.comboBoxHtmlTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxHtmlTemplate_SelectedIndexChanged);
            // 
            // tabControlData
            // 
            this.tabControlData.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlData.Controls.Add(this.tabPageJsData);
            this.tabControlData.Controls.Add(this.tabPageJsOptionsNone);
            this.tabControlData.Controls.Add(this.tabPageJsOptionsMc);
            this.tabControlData.Controls.Add(this.tabPageJsOptionsMa);
            this.tabControlData.Controls.Add(this.tabPageJsOptionsSc);
            this.tabControlData.Controls.Add(this.tabPageJsOptionsDd);
            this.tabControlData.Controls.Add(this.tabPageJsOptionsFi);
            this.tabControlData.Controls.Add(this.tabPageHtmlData);
            this.tabControlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlData.HotTrack = true;
            this.tabControlData.Location = new System.Drawing.Point(0, 0);
            this.tabControlData.Name = "tabControlData";
            this.tabControlData.SelectedIndex = 0;
            this.tabControlData.Size = new System.Drawing.Size(914, 256);
            this.tabControlData.TabIndex = 0;
            // 
            // tabPageJsData
            // 
            this.tabPageJsData.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageJsData.Controls.Add(this.dataGridQuestions);
            this.tabPageJsData.Location = new System.Drawing.Point(4, 4);
            this.tabPageJsData.Name = "tabPageJsData";
            this.tabPageJsData.Size = new System.Drawing.Size(906, 230);
            this.tabPageJsData.TabIndex = 0;
            this.tabPageJsData.Text = "Exercise Data";
            // 
            // tabPageJsOptionsNone
            // 
            this.tabPageJsOptionsNone.Location = new System.Drawing.Point(4, 4);
            this.tabPageJsOptionsNone.Name = "tabPageJsOptionsNone";
            this.tabPageJsOptionsNone.Size = new System.Drawing.Size(906, 230);
            this.tabPageJsOptionsNone.TabIndex = 4;
            this.tabPageJsOptionsNone.Text = "Exercise Options";
            // 
            // tabPageJsOptionsMc
            // 
            this.tabPageJsOptionsMc.Controls.Add(this.checkBoxMcCheckAnswersButton);
            this.tabPageJsOptionsMc.Controls.Add(this.checkBoxMcFeedbackInResults);
            this.tabPageJsOptionsMc.Controls.Add(this.label33);
            this.tabPageJsOptionsMc.Controls.Add(this.checkBoxMcFeedbackInPopup);
            this.tabPageJsOptionsMc.Controls.Add(this.radioButtonMcQuestionOne);
            this.tabPageJsOptionsMc.Controls.Add(this.radioButtonMcQuestionAll);
            this.tabPageJsOptionsMc.Controls.Add(this.label23);
            this.tabPageJsOptionsMc.Controls.Add(this.label20);
            this.tabPageJsOptionsMc.Controls.Add(this.label21);
            this.tabPageJsOptionsMc.Controls.Add(this.textBoxMtResultsCols);
            this.tabPageJsOptionsMc.Controls.Add(this.textBoxMtResultsRows);
            this.tabPageJsOptionsMc.Controls.Add(this.label22);
            this.tabPageJsOptionsMc.Location = new System.Drawing.Point(4, 4);
            this.tabPageJsOptionsMc.Name = "tabPageJsOptionsMc";
            this.tabPageJsOptionsMc.Size = new System.Drawing.Size(906, 230);
            this.tabPageJsOptionsMc.TabIndex = 6;
            this.tabPageJsOptionsMc.Text = "Exercise Options";
            // 
            // checkBoxMcCheckAnswersButton
            // 
            this.checkBoxMcCheckAnswersButton.Location = new System.Drawing.Point(28, 188);
            this.checkBoxMcCheckAnswersButton.Name = "checkBoxMcCheckAnswersButton";
            this.checkBoxMcCheckAnswersButton.Size = new System.Drawing.Size(180, 16);
            this.checkBoxMcCheckAnswersButton.TabIndex = 22;
            this.checkBoxMcCheckAnswersButton.Text = "Display Check Answers Button";
            // 
            // checkBoxMcFeedbackInResults
            // 
            this.checkBoxMcFeedbackInResults.Location = new System.Drawing.Point(28, 168);
            this.checkBoxMcFeedbackInResults.Name = "checkBoxMcFeedbackInResults";
            this.checkBoxMcFeedbackInResults.Size = new System.Drawing.Size(180, 16);
            this.checkBoxMcFeedbackInResults.TabIndex = 21;
            this.checkBoxMcFeedbackInResults.Text = "Display Feedback in Results";
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(28, 124);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(136, 16);
            this.label33.TabIndex = 20;
            this.label33.Text = "Feedback:";
            // 
            // checkBoxMcFeedbackInPopup
            // 
            this.checkBoxMcFeedbackInPopup.Location = new System.Drawing.Point(28, 148);
            this.checkBoxMcFeedbackInPopup.Name = "checkBoxMcFeedbackInPopup";
            this.checkBoxMcFeedbackInPopup.Size = new System.Drawing.Size(180, 16);
            this.checkBoxMcFeedbackInPopup.TabIndex = 19;
            this.checkBoxMcFeedbackInPopup.Text = "Display Feedback in Popup";
            // 
            // radioButtonMcQuestionOne
            // 
            this.radioButtonMcQuestionOne.Location = new System.Drawing.Point(204, 68);
            this.radioButtonMcQuestionOne.Name = "radioButtonMcQuestionOne";
            this.radioButtonMcQuestionOne.Size = new System.Drawing.Size(160, 20);
            this.radioButtonMcQuestionOne.TabIndex = 11;
            this.radioButtonMcQuestionOne.Text = "One Question per page";
            // 
            // radioButtonMcQuestionAll
            // 
            this.radioButtonMcQuestionAll.Checked = true;
            this.radioButtonMcQuestionAll.Location = new System.Drawing.Point(204, 44);
            this.radioButtonMcQuestionAll.Name = "radioButtonMcQuestionAll";
            this.radioButtonMcQuestionAll.Size = new System.Drawing.Size(160, 20);
            this.radioButtonMcQuestionAll.TabIndex = 10;
            this.radioButtonMcQuestionAll.TabStop = true;
            this.radioButtonMcQuestionAll.Text = "All Questions on one page";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(204, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(160, 16);
            this.label23.TabIndex = 9;
            this.label23.Text = "Question Arrangment:";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(28, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(136, 16);
            this.label20.TabIndex = 7;
            this.label20.Text = "Results TextBox:";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(32, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 16);
            this.label21.TabIndex = 6;
            this.label21.Text = "Columns:";
            // 
            // textBoxMtResultsCols
            // 
            this.textBoxMtResultsCols.Location = new System.Drawing.Point(104, 44);
            this.textBoxMtResultsCols.Name = "textBoxMtResultsCols";
            this.textBoxMtResultsCols.Size = new System.Drawing.Size(60, 20);
            this.textBoxMtResultsCols.TabIndex = 3;
            // 
            // textBoxMtResultsRows
            // 
            this.textBoxMtResultsRows.Location = new System.Drawing.Point(104, 68);
            this.textBoxMtResultsRows.Name = "textBoxMtResultsRows";
            this.textBoxMtResultsRows.Size = new System.Drawing.Size(60, 20);
            this.textBoxMtResultsRows.TabIndex = 5;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(32, 72);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 16);
            this.label22.TabIndex = 4;
            this.label22.Text = "Rows:";
            // 
            // tabPageJsOptionsMa
            // 
            this.tabPageJsOptionsMa.Controls.Add(this.label19);
            this.tabPageJsOptionsMa.Controls.Add(this.label17);
            this.tabPageJsOptionsMa.Controls.Add(this.textBoxMaResultsCols);
            this.tabPageJsOptionsMa.Controls.Add(this.textBoxMaResultsRows);
            this.tabPageJsOptionsMa.Controls.Add(this.label18);
            this.tabPageJsOptionsMa.Location = new System.Drawing.Point(4, 4);
            this.tabPageJsOptionsMa.Name = "tabPageJsOptionsMa";
            this.tabPageJsOptionsMa.Size = new System.Drawing.Size(906, 230);
            this.tabPageJsOptionsMa.TabIndex = 5;
            this.tabPageJsOptionsMa.Text = "Exercise Options";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(28, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(136, 16);
            this.label19.TabIndex = 2;
            this.label19.Text = "Results TextBox:";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(32, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 16);
            this.label17.TabIndex = 1;
            this.label17.Text = "Columns:";
            // 
            // textBoxMaResultsCols
            // 
            this.textBoxMaResultsCols.Location = new System.Drawing.Point(104, 44);
            this.textBoxMaResultsCols.Name = "textBoxMaResultsCols";
            this.textBoxMaResultsCols.Size = new System.Drawing.Size(60, 20);
            this.textBoxMaResultsCols.TabIndex = 0;
            // 
            // textBoxMaResultsRows
            // 
            this.textBoxMaResultsRows.Location = new System.Drawing.Point(104, 68);
            this.textBoxMaResultsRows.Name = "textBoxMaResultsRows";
            this.textBoxMaResultsRows.Size = new System.Drawing.Size(60, 20);
            this.textBoxMaResultsRows.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(32, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 16);
            this.label18.TabIndex = 0;
            this.label18.Text = "Rows:";
            // 
            // tabPageJsOptionsSc
            // 
            this.tabPageJsOptionsSc.Controls.Add(this.label32);
            this.tabPageJsOptionsSc.Controls.Add(this.checkBoxScShowNumbers);
            this.tabPageJsOptionsSc.Controls.Add(this.checkBoxScMouseoverRight);
            this.tabPageJsOptionsSc.Controls.Add(this.label31);
            this.tabPageJsOptionsSc.Controls.Add(this.radioButtonScQuestionOne);
            this.tabPageJsOptionsSc.Controls.Add(this.radioButtonScQuestionAll);
            this.tabPageJsOptionsSc.Controls.Add(this.label30);
            this.tabPageJsOptionsSc.Location = new System.Drawing.Point(4, 4);
            this.tabPageJsOptionsSc.Name = "tabPageJsOptionsSc";
            this.tabPageJsOptionsSc.Size = new System.Drawing.Size(906, 230);
            this.tabPageJsOptionsSc.TabIndex = 7;
            this.tabPageJsOptionsSc.Text = "Exercise Options";
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(24, 132);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(136, 16);
            this.label32.TabIndex = 18;
            this.label32.Text = "Other:";
            // 
            // checkBoxScShowNumbers
            // 
            this.checkBoxScShowNumbers.Location = new System.Drawing.Point(24, 156);
            this.checkBoxScShowNumbers.Name = "checkBoxScShowNumbers";
            this.checkBoxScShowNumbers.Size = new System.Drawing.Size(180, 16);
            this.checkBoxScShowNumbers.TabIndex = 17;
            this.checkBoxScShowNumbers.Text = "Display Question Numbers";
            // 
            // checkBoxScMouseoverRight
            // 
            this.checkBoxScMouseoverRight.Location = new System.Drawing.Point(24, 40);
            this.checkBoxScMouseoverRight.Name = "checkBoxScMouseoverRight";
            this.checkBoxScMouseoverRight.Size = new System.Drawing.Size(152, 20);
            this.checkBoxScMouseoverRight.TabIndex = 16;
            this.checkBoxScMouseoverRight.Text = "To the Right";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(24, 20);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(152, 16);
            this.label31.TabIndex = 15;
            this.label31.Text = "Mouseover Position:";
            // 
            // radioButtonScQuestionOne
            // 
            this.radioButtonScQuestionOne.Location = new System.Drawing.Point(204, 68);
            this.radioButtonScQuestionOne.Name = "radioButtonScQuestionOne";
            this.radioButtonScQuestionOne.Size = new System.Drawing.Size(160, 20);
            this.radioButtonScQuestionOne.TabIndex = 14;
            this.radioButtonScQuestionOne.Text = "One Question per page";
            // 
            // radioButtonScQuestionAll
            // 
            this.radioButtonScQuestionAll.Checked = true;
            this.radioButtonScQuestionAll.Location = new System.Drawing.Point(204, 44);
            this.radioButtonScQuestionAll.Name = "radioButtonScQuestionAll";
            this.radioButtonScQuestionAll.Size = new System.Drawing.Size(160, 20);
            this.radioButtonScQuestionAll.TabIndex = 13;
            this.radioButtonScQuestionAll.TabStop = true;
            this.radioButtonScQuestionAll.Text = "All Questions on one page";
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(204, 20);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(160, 16);
            this.label30.TabIndex = 12;
            this.label30.Text = "Question Arrangment:";
            // 
            // tabPageJsOptionsDd
            // 
            this.tabPageJsOptionsDd.Controls.Add(this.label3);
            this.tabPageJsOptionsDd.Controls.Add(this.comboBoxDdCardFontSize);
            this.tabPageJsOptionsDd.Location = new System.Drawing.Point(4, 4);
            this.tabPageJsOptionsDd.Name = "tabPageJsOptionsDd";
            this.tabPageJsOptionsDd.Size = new System.Drawing.Size(906, 230);
            this.tabPageJsOptionsDd.TabIndex = 2;
            this.tabPageJsOptionsDd.Text = "Exercise Options";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Card Font Size:";
            // 
            // comboBoxDdCardFontSize
            // 
            this.comboBoxDdCardFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDdCardFontSize.Location = new System.Drawing.Point(160, 20);
            this.comboBoxDdCardFontSize.Name = "comboBoxDdCardFontSize";
            this.comboBoxDdCardFontSize.Size = new System.Drawing.Size(112, 21);
            this.comboBoxDdCardFontSize.TabIndex = 1;
            // 
            // tabPageJsOptionsFi
            // 
            this.tabPageJsOptionsFi.Controls.Add(this.checkBoxFiTypeQuiz);
            this.tabPageJsOptionsFi.Controls.Add(this.textBoxFiPageWidth);
            this.tabPageJsOptionsFi.Controls.Add(this.label29);
            this.tabPageJsOptionsFi.Controls.Add(this.label28);
            this.tabPageJsOptionsFi.Controls.Add(this.checkBoxFiShowNumbers);
            this.tabPageJsOptionsFi.Controls.Add(this.textBoxFiResultsCols);
            this.tabPageJsOptionsFi.Controls.Add(this.textBoxFiResultsRows);
            this.tabPageJsOptionsFi.Controls.Add(this.label26);
            this.tabPageJsOptionsFi.Controls.Add(this.label27);
            this.tabPageJsOptionsFi.Controls.Add(this.label25);
            this.tabPageJsOptionsFi.Controls.Add(this.radioButtonFiQuestionOne);
            this.tabPageJsOptionsFi.Controls.Add(this.radioButtonFiQuestionAll);
            this.tabPageJsOptionsFi.Controls.Add(this.label24);
            this.tabPageJsOptionsFi.Controls.Add(this.textBoxJsOptionsFiChoices);
            this.tabPageJsOptionsFi.Controls.Add(this.label16);
            this.tabPageJsOptionsFi.Location = new System.Drawing.Point(4, 4);
            this.tabPageJsOptionsFi.Name = "tabPageJsOptionsFi";
            this.tabPageJsOptionsFi.Size = new System.Drawing.Size(906, 230);
            this.tabPageJsOptionsFi.TabIndex = 3;
            this.tabPageJsOptionsFi.Text = "Exercise Options";
            // 
            // checkBoxFiTypeQuiz
            // 
            this.checkBoxFiTypeQuiz.Location = new System.Drawing.Point(28, 201);
            this.checkBoxFiTypeQuiz.Name = "checkBoxFiTypeQuiz";
            this.checkBoxFiTypeQuiz.Size = new System.Drawing.Size(563, 19);
            this.checkBoxFiTypeQuiz.TabIndex = 7;
            this.checkBoxFiTypeQuiz.Text = "Quiz (hides Hint button and only allows Check Answers button after all questions " +
    "attempted)";
            // 
            // textBoxFiPageWidth
            // 
            this.textBoxFiPageWidth.Location = new System.Drawing.Point(148, 152);
            this.textBoxFiPageWidth.Name = "textBoxFiPageWidth";
            this.textBoxFiPageWidth.Size = new System.Drawing.Size(60, 20);
            this.textBoxFiPageWidth.TabIndex = 5;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(28, 156);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(120, 16);
            this.label29.TabIndex = 16;
            this.label29.Text = "Main Page Width:";
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(28, 132);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(136, 16);
            this.label28.TabIndex = 14;
            this.label28.Text = "Other:";
            // 
            // checkBoxFiShowNumbers
            // 
            this.checkBoxFiShowNumbers.Location = new System.Drawing.Point(28, 180);
            this.checkBoxFiShowNumbers.Name = "checkBoxFiShowNumbers";
            this.checkBoxFiShowNumbers.Size = new System.Drawing.Size(180, 16);
            this.checkBoxFiShowNumbers.TabIndex = 6;
            this.checkBoxFiShowNumbers.Text = "Display Question Numbers";
            // 
            // textBoxFiResultsCols
            // 
            this.textBoxFiResultsCols.Location = new System.Drawing.Point(104, 44);
            this.textBoxFiResultsCols.Name = "textBoxFiResultsCols";
            this.textBoxFiResultsCols.Size = new System.Drawing.Size(60, 20);
            this.textBoxFiResultsCols.TabIndex = 0;
            // 
            // textBoxFiResultsRows
            // 
            this.textBoxFiResultsRows.Location = new System.Drawing.Point(104, 68);
            this.textBoxFiResultsRows.Name = "textBoxFiResultsRows";
            this.textBoxFiResultsRows.Size = new System.Drawing.Size(60, 20);
            this.textBoxFiResultsRows.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(28, 20);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(136, 16);
            this.label26.TabIndex = 12;
            this.label26.Text = "Results TextBox:";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(32, 48);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(72, 16);
            this.label27.TabIndex = 11;
            this.label27.Text = "Columns:";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(32, 72);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 16);
            this.label25.TabIndex = 9;
            this.label25.Text = "Rows:";
            // 
            // radioButtonFiQuestionOne
            // 
            this.radioButtonFiQuestionOne.Location = new System.Drawing.Point(204, 68);
            this.radioButtonFiQuestionOne.Name = "radioButtonFiQuestionOne";
            this.radioButtonFiQuestionOne.Size = new System.Drawing.Size(160, 20);
            this.radioButtonFiQuestionOne.TabIndex = 3;
            this.radioButtonFiQuestionOne.Text = "One Question per page";
            // 
            // radioButtonFiQuestionAll
            // 
            this.radioButtonFiQuestionAll.Location = new System.Drawing.Point(204, 44);
            this.radioButtonFiQuestionAll.Name = "radioButtonFiQuestionAll";
            this.radioButtonFiQuestionAll.Size = new System.Drawing.Size(160, 20);
            this.radioButtonFiQuestionAll.TabIndex = 2;
            this.radioButtonFiQuestionAll.Text = "All Questions on one page";
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label24.Location = new System.Drawing.Point(204, 20);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(160, 16);
            this.label24.TabIndex = 2;
            this.label24.Text = "Question Arrangment:";
            // 
            // textBoxJsOptionsFiChoices
            // 
            this.textBoxJsOptionsFiChoices.AcceptsReturn = true;
            this.textBoxJsOptionsFiChoices.Location = new System.Drawing.Point(412, 40);
            this.textBoxJsOptionsFiChoices.Multiline = true;
            this.textBoxJsOptionsFiChoices.Name = "textBoxJsOptionsFiChoices";
            this.textBoxJsOptionsFiChoices.Size = new System.Drawing.Size(296, 96);
            this.textBoxJsOptionsFiChoices.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(412, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(140, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Possible Answers:";
            // 
            // tabPageHtmlData
            // 
            this.tabPageHtmlData.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageHtmlData.Controls.Add(this.textBoxNextPageText);
            this.tabPageHtmlData.Controls.Add(this.label9);
            this.tabPageHtmlData.Controls.Add(this.textBoxInstructionsText);
            this.tabPageHtmlData.Controls.Add(this.label8);
            this.tabPageHtmlData.Controls.Add(this.textBoxInstructionsTitle);
            this.tabPageHtmlData.Controls.Add(this.label7);
            this.tabPageHtmlData.Controls.Add(this.textBoxPageTitle);
            this.tabPageHtmlData.Controls.Add(this.label6);
            this.tabPageHtmlData.Controls.Add(this.textBoxPageNumber);
            this.tabPageHtmlData.Controls.Add(this.label5);
            this.tabPageHtmlData.Controls.Add(this.textBoxAssignmentNumber);
            this.tabPageHtmlData.Controls.Add(this.label4);
            this.tabPageHtmlData.Controls.Add(this.textBoxUnitNumber);
            this.tabPageHtmlData.Controls.Add(this.label2);
            this.tabPageHtmlData.Controls.Add(this.groupBox1);
            this.tabPageHtmlData.Controls.Add(this.groupBox2);
            this.tabPageHtmlData.Controls.Add(this.comboBoxHtmlTemplate);
            this.tabPageHtmlData.Controls.Add(this.label1);
            this.tabPageHtmlData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageHtmlData.Location = new System.Drawing.Point(4, 4);
            this.tabPageHtmlData.Name = "tabPageHtmlData";
            this.tabPageHtmlData.Size = new System.Drawing.Size(906, 230);
            this.tabPageHtmlData.TabIndex = 1;
            this.tabPageHtmlData.Text = "Html Data";
            // 
            // textBoxNextPageText
            // 
            this.textBoxNextPageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNextPageText.Location = new System.Drawing.Point(144, 204);
            this.textBoxNextPageText.Name = "textBoxNextPageText";
            this.textBoxNextPageText.Size = new System.Drawing.Size(300, 20);
            this.textBoxNextPageText.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Next Page Text: ";
            // 
            // textBoxInstructionsText
            // 
            this.textBoxInstructionsText.AcceptsReturn = true;
            this.textBoxInstructionsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstructionsText.Location = new System.Drawing.Point(144, 128);
            this.textBoxInstructionsText.Multiline = true;
            this.textBoxInstructionsText.Name = "textBoxInstructionsText";
            this.textBoxInstructionsText.Size = new System.Drawing.Size(300, 72);
            this.textBoxInstructionsText.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Instructions Text: ";
            // 
            // textBoxInstructionsTitle
            // 
            this.textBoxInstructionsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstructionsTitle.Location = new System.Drawing.Point(144, 104);
            this.textBoxInstructionsTitle.Name = "textBoxInstructionsTitle";
            this.textBoxInstructionsTitle.Size = new System.Drawing.Size(300, 20);
            this.textBoxInstructionsTitle.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Instructions Title: ";
            // 
            // textBoxPageTitle
            // 
            this.textBoxPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPageTitle.Location = new System.Drawing.Point(144, 80);
            this.textBoxPageTitle.Name = "textBoxPageTitle";
            this.textBoxPageTitle.Size = new System.Drawing.Size(300, 20);
            this.textBoxPageTitle.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Exercise Target: ";
            // 
            // textBoxPageNumber
            // 
            this.textBoxPageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPageNumber.Location = new System.Drawing.Point(332, 56);
            this.textBoxPageNumber.Name = "textBoxPageNumber";
            this.textBoxPageNumber.Size = new System.Drawing.Size(112, 20);
            this.textBoxPageNumber.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(240, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Page Number: ";
            // 
            // textBoxAssignmentNumber
            // 
            this.textBoxAssignmentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAssignmentNumber.Location = new System.Drawing.Point(144, 56);
            this.textBoxAssignmentNumber.Name = "textBoxAssignmentNumber";
            this.textBoxAssignmentNumber.Size = new System.Drawing.Size(84, 20);
            this.textBoxAssignmentNumber.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Assignment Number: ";
            // 
            // textBoxUnitNumber
            // 
            this.textBoxUnitNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnitNumber.Location = new System.Drawing.Point(144, 32);
            this.textBoxUnitNumber.Name = "textBoxUnitNumber";
            this.textBoxUnitNumber.Size = new System.Drawing.Size(84, 20);
            this.textBoxUnitNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Unit Number: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxQuizFlashWidth);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBoxQuizFlashHeight);
            this.groupBox1.Controls.Add(this.textBoxQuizFlashFileName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(480, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flash Object Data for Quiz (before Javascript Data)";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Flash Object Width: ";
            // 
            // textBoxQuizFlashWidth
            // 
            this.textBoxQuizFlashWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuizFlashWidth.Location = new System.Drawing.Point(196, 72);
            this.textBoxQuizFlashWidth.Name = "textBoxQuizFlashWidth";
            this.textBoxQuizFlashWidth.Size = new System.Drawing.Size(76, 20);
            this.textBoxQuizFlashWidth.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Flash Object Height: ";
            // 
            // textBoxQuizFlashHeight
            // 
            this.textBoxQuizFlashHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuizFlashHeight.Location = new System.Drawing.Point(196, 48);
            this.textBoxQuizFlashHeight.Name = "textBoxQuizFlashHeight";
            this.textBoxQuizFlashHeight.Size = new System.Drawing.Size(76, 20);
            this.textBoxQuizFlashHeight.TabIndex = 19;
            // 
            // textBoxQuizFlashFileName
            // 
            this.textBoxQuizFlashFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuizFlashFileName.Location = new System.Drawing.Point(196, 24);
            this.textBoxQuizFlashFileName.Name = "textBoxQuizFlashFileName";
            this.textBoxQuizFlashFileName.Size = new System.Drawing.Size(128, 20);
            this.textBoxQuizFlashFileName.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Flash File Name (.swf): ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxNaviFlashWidth);
            this.groupBox2.Controls.Add(this.comboBoxNaviFlashHeight);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.comboBoxNaviFlashFileName);
            this.groupBox2.Location = new System.Drawing.Point(480, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 100);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flash Object Data for Page Navigation (bottom of page)";
            // 
            // comboBoxNaviFlashWidth
            // 
            this.comboBoxNaviFlashWidth.Location = new System.Drawing.Point(192, 72);
            this.comboBoxNaviFlashWidth.Name = "comboBoxNaviFlashWidth";
            this.comboBoxNaviFlashWidth.Size = new System.Drawing.Size(76, 21);
            this.comboBoxNaviFlashWidth.TabIndex = 25;
            this.comboBoxNaviFlashWidth.Text = "comboBox2";
            // 
            // comboBoxNaviFlashHeight
            // 
            this.comboBoxNaviFlashHeight.Location = new System.Drawing.Point(192, 48);
            this.comboBoxNaviFlashHeight.Name = "comboBoxNaviFlashHeight";
            this.comboBoxNaviFlashHeight.Size = new System.Drawing.Size(76, 21);
            this.comboBoxNaviFlashHeight.TabIndex = 24;
            this.comboBoxNaviFlashHeight.Text = "comboBox1";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(172, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "Flash Object Width: ";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(172, 16);
            this.label14.TabIndex = 18;
            this.label14.Text = "Flash Object Height: ";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(172, 16);
            this.label15.TabIndex = 23;
            this.label15.Text = "Flash File Name (.swf): ";
            // 
            // comboBoxNaviFlashFileName
            // 
            this.comboBoxNaviFlashFileName.Location = new System.Drawing.Point(192, 24);
            this.comboBoxNaviFlashFileName.Name = "comboBoxNaviFlashFileName";
            this.comboBoxNaviFlashFileName.Size = new System.Drawing.Size(164, 21);
            this.comboBoxNaviFlashFileName.TabIndex = 23;
            this.comboBoxNaviFlashFileName.Text = "comboBox1";
            this.comboBoxNaviFlashFileName.SelectedIndexChanged += new System.EventHandler(this.comboBoxNaviFlashFileName_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.webBrowserInput);
            this.panel1.Controls.Add(this.buttonPreview);
            this.panel1.Controls.Add(this.tabControlData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 657);
            this.panel1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 357);
            this.splitter1.MinExtra = 5;
            this.splitter1.MinSize = 200;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(914, 9);
            this.splitter1.TabIndex = 91;
            this.splitter1.TabStop = false;
            // 
            // webBrowserInput
            // 
            this.webBrowserInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowserInput.Location = new System.Drawing.Point(0, 366);
            this.webBrowserInput.Name = "webBrowserInput";
            this.webBrowserInput.ScriptErrorsSuppressed = true;
            this.webBrowserInput.Size = new System.Drawing.Size(914, 291);
            this.webBrowserInput.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(914, 657);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Exercise Suite";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.formExit_Click);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridQuestions)).EndInit();
            this.tabControlData.ResumeLayout(false);
            this.tabPageJsData.ResumeLayout(false);
            this.tabPageJsOptionsMc.ResumeLayout(false);
            this.tabPageJsOptionsMc.PerformLayout();
            this.tabPageJsOptionsMa.ResumeLayout(false);
            this.tabPageJsOptionsMa.PerformLayout();
            this.tabPageJsOptionsSc.ResumeLayout(false);
            this.tabPageJsOptionsDd.ResumeLayout(false);
            this.tabPageJsOptionsFi.ResumeLayout(false);
            this.tabPageJsOptionsFi.PerformLayout();
            this.tabPageHtmlData.ResumeLayout(false);
            this.tabPageHtmlData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}






        /// <summary>
        ///
        /// </summary>
        private void RegistryInitialize()
        {
            // Attempt to open the registry key for this app
            RegistryKey keyRead  = Registry.CurrentUser.OpenSubKey(sRegistryKeyLocation);
            // If the return value is null, the key doesn't exist
            if (keyRead == null) {
                keyRead = Registry.CurrentUser.CreateSubKey(sRegistryKeyLocation);
            }

            RegistryKey keyWrite = Registry.CurrentUser.OpenSubKey(sRegistryKeyLocation, true);

            // if null is returned, the value doesn't exist in the registry

            if ((keyRead.GetValue("DefaultDirectory") != null)
                &&  (Directory.Exists((string)keyRead.GetValue("DefaultDirectory")))) {
                Environment.CurrentDirectory = (string)keyRead.GetValue("DefaultDirectory");
            } else {
                keyWrite.SetValue("DefaultDirectory", Environment.CurrentDirectory);
            }
            if ((keyRead.GetValue("JsQuizBasePath") != null)
                &&  (Directory.Exists((string)keyRead.GetValue("JsQuizBasePath")))) {
                sJsQuizBasePath = (string)keyRead.GetValue("JsQuizBasePath");
            } else {
                keyWrite.SetValue("JsQuizBasePath", sJsQuizBasePath);
            }
            if ((keyRead.GetValue("HtmlTemplatesBasePath") != null)
                &&  (Directory.Exists((string)keyRead.GetValue("HtmlTemplatesBasePath")))) {
                sHtmlTemplatesBasePath = (string)keyRead.GetValue("HtmlTemplatesBasePath");
            } else {
                keyWrite.SetValue("HtmlTemplatesBasePath", sHtmlTemplatesBasePath);
            }
        }


        /// <summary>
        ///
        /// </summary>
        private void RegistrySave()
        {
            // Attempt to open the registry key for this app
            RegistryKey keyRead  = Registry.CurrentUser.OpenSubKey(sRegistryKeyLocation);
            // If the return value is null, the key doesn't exist
            if (keyRead == null) {
                keyRead = Registry.CurrentUser.CreateSubKey(sRegistryKeyLocation);
            }

            RegistryKey keyWrite = Registry.CurrentUser.OpenSubKey(sRegistryKeyLocation, true);

            if (Directory.Exists(Environment.CurrentDirectory)) {
                keyWrite.SetValue("DefaultDirectory", Environment.CurrentDirectory);
            }
        }


        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////
        ////      R E N D E R    U T I L I T Y   F U N C T I O N S
        ////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////


        private static string GetShortVersionInfo()
        {
            try {
                Assembly assembly = Assembly.GetExecutingAssembly();
                AssemblyName assemblyname = assembly.GetName();

                string strVersion = "Version " + assemblyname.Version.Major.ToString() + "." +
                    assemblyname.Version.Minor.ToString() + "." +
                    assemblyname.Version.Build.ToString() + "." +
                    assemblyname.Version.Revision.ToString() + " (.NET 4.0 - VS2010)";
                return strVersion;
            } catch {
                return "";
            }
        }

        /// <summary>
        ///
        /// </summary>
        private void InitializeBrowser()
        {
//            IHTMLDocument2 hDocInput = (IHTMLDocument2)axWebBrowserInput.Document;
//            hDocInput.write(sHtmlBlankTemplate);
//            hDocInput.close();
            HtmlDocument hDocInput = webBrowserInput.Document.OpenNew(true);

            hDocInput.Encoding = "UTF-8";
            hDocInput.Write(sHtmlBlankTemplate);
            webBrowserInput.Refresh();
        }


        /// <summary>
        ///
        /// </summary>
        private string CreateHtml()
        {
            string sReturnHtml = sHtmlTemplate;
            
            string sJsSourceData = "\r\n<script language=javascript>\r\n<!--\r\n"
                + cQuiz.ParseGridAndCreateJavascriptData(dataGridQuestions, sJsDataTemplate, this, tabControlData)
                + "\r\n// -->\r\n</script>\r\n";

            string sJsSourceQuiz = "\r\n<script language=javascript>\r\n<!--\r\n"
                + sJsQuizTemplate
                + "\r\n// -->\r\n</script>\r\n";
                
            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINJAVASCRIPTDATA-->(.*)<!--ENDJAVASCRIPTDATA-->", "<!--BEGINJAVASCRIPTDATA-->" + sJsSourceData + "<!--ENDJAVASCRIPTDATA-->", RegexOptions.Singleline);

            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINJAVASCRIPTQUIZ-->(.*)<!--ENDJAVASCRIPTQUIZ-->", "<!--BEGINJAVASCRIPTQUIZ--><!--BEGINQUIZTYPE=" + cQuiz.GetQuizType() + "--><!--ENDQUIZTYPE-->" + sJsSourceQuiz + "<!--ENDJAVASCRIPTQUIZ-->", RegexOptions.Singleline);

            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINCOURSENAME-->(.*)<!--ENDCOURSENAME-->", "<!--BEGINCOURSENAME-->" + comboBoxHtmlTemplate.Text + "<!--ENDCOURSENAME-->");
            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINUNITNUMBER-->(.*)<!--ENDUNITNUMBER-->", "<!--BEGINUNITNUMBER-->" + textBoxUnitNumber.Text + "<!--ENDUNITNUMBER-->");
            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINASSIGNMENTNUMBER-->(.*)<!--ENDASSIGNMENTNUMBER-->", "<!--BEGINASSIGNMENTNUMBER-->" + textBoxAssignmentNumber.Text + "<!--ENDASSIGNMENTNUMBER-->");
            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINPAGENUMBER-->(.*)<!--ENDPAGENUMBER-->", "<!--BEGINPAGENUMBER-->" + textBoxPageNumber.Text + "<!--ENDPAGENUMBER-->");
            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINPAGETITLE-->(.*)<!--ENDPAGETITLE-->", "<!--BEGINPAGETITLE-->" + textBoxPageTitle.Text + "<!--ENDPAGETITLE-->");
            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGININSTRUCTIONSTITLE-->(.*)<!--ENDINSTRUCTIONSTITLE-->", "<!--BEGININSTRUCTIONSTITLE-->" + textBoxInstructionsTitle.Text + "<!--ENDINSTRUCTIONSTITLE-->");
            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGININSTRUCTIONSTEXT-->(.*)<!--ENDINSTRUCTIONSTEXT-->", "<!--BEGININSTRUCTIONSTEXT-->" + textBoxInstructionsText.Text + "<!--ENDINSTRUCTIONSTEXT-->");
            sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINNEXTPAGETEXT-->(.*)<!--ENDNEXTPAGETEXT-->", "<!--BEGINNEXTPAGETEXT-->" + textBoxNextPageText.Text + "<!--ENDNEXTPAGETEXT-->");

            if ((textBoxQuizFlashFileName.Text.Length > 0)
            &&  (textBoxQuizFlashHeight.Text.Length > 0)
            &&  (textBoxQuizFlashWidth.Text.Length > 0)) {

                string sFlashObject = sFlashObjectTemplate;

                sFlashObject = sFlashObject.Replace("NNN1", textBoxQuizFlashFileName.Text);
                sFlashObject = sFlashObject.Replace("HHH1", textBoxQuizFlashHeight.Text);
                sFlashObject = sFlashObject.Replace("WWW1", textBoxQuizFlashWidth.Text);
                sFlashObject = sFlashObject.Replace("NNN2", textBoxQuizFlashFileName.Text);
                sFlashObject = sFlashObject.Replace("HHH2", textBoxQuizFlashHeight.Text);
                sFlashObject = sFlashObject.Replace("WWW2", textBoxQuizFlashWidth.Text);

                sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINQUIZFLASHOBJECT-->(.*)<!--ENDQUIZFLASHOBJECT-->", "<!--BEGINQUIZFLASHOBJECT--><!--BEGINPARAMS-->" + "<!--NNN=" + textBoxQuizFlashFileName.Text + "-->" + "<!--HHH=" + textBoxQuizFlashHeight.Text + "-->" + "<!--WWW=" + textBoxQuizFlashWidth.Text + "--><!--ENDPARAMS-->" + sFlashObject + "<!--ENDQUIZFLASHOBJECT-->");
            }

            if ((comboBoxNaviFlashFileName.Text.Length > 0)
            &&  (comboBoxNaviFlashHeight.Text.Length > 0)
            &&  (comboBoxNaviFlashWidth.Text.Length > 0)) {

                string sFlashObject = sFlashObjectTemplate;

                sFlashObject = sFlashObject.Replace("NNN1", comboBoxNaviFlashFileName.Text);
                sFlashObject = sFlashObject.Replace("HHH1", comboBoxNaviFlashHeight.Text);
                sFlashObject = sFlashObject.Replace("WWW1", comboBoxNaviFlashWidth.Text);
                sFlashObject = sFlashObject.Replace("NNN2", comboBoxNaviFlashFileName.Text);
                sFlashObject = sFlashObject.Replace("HHH2", comboBoxNaviFlashHeight.Text);
                sFlashObject = sFlashObject.Replace("WWW2", comboBoxNaviFlashWidth.Text);

                sReturnHtml = Regex.Replace(sReturnHtml, "<!--BEGINNAVIFLASHOBJECT-->(.*)<!--ENDNAVIFLASHOBJECT-->", "<!--BEGINNAVIFLASHOBJECT--><!--BEGINPARAMS-->" + "<!--NNN=" + comboBoxNaviFlashFileName.Text + "-->" + "<!--HHH=" + comboBoxNaviFlashHeight.Text + "-->" + "<!--WWW=" + comboBoxNaviFlashWidth.Text + "--><!--ENDPARAMS-->" + sFlashObject + "<!--ENDNAVIFLASHOBJECT-->");
            }

            return (sReturnHtml);
        }


        /// <summary>
        ///
        /// </summary>
        //
        // Maybe Add "RegexOptions.Singleline" to the end of all regex's to help with new lines in parsed files
        //
        private string ParseHtmlIntoVariablesAndGetJavascriptData(string strHtml)
        {
            Match cMatch = null;

            cMatch = Regex.Match(strHtml, "<!--BEGINJAVASCRIPTQUIZ--><!--BEGINQUIZTYPE=(.*)--><!--ENDQUIZTYPE-->.*<!--ENDJAVASCRIPTQUIZ-->", RegexOptions.Singleline);
            string sJsQuizType = cMatch.Success ? cMatch.Result("$1") : "None";


            cMatch = Regex.Match(strHtml,
                                 "<!--BEGINJAVASCRIPTDATA-->(.*)<!--ENDJAVASCRIPTDATA-->",
                                 RegexOptions.Singleline);
            sJsDataTemplate = cMatch.Success ? cMatch.Result("$1") : "";

            cMatch = Regex.Match(sJsDataTemplate,
                                 "<script language=javascript>\r\n<!--(.*)// -->\r\n</script>",
                                 RegexOptions.Singleline);
            sJsDataTemplate = cMatch.Success ? cMatch.Result("$1") : "";




            cMatch = Regex.Match(strHtml, "<!--BEGINCOURSENAME-->(.*)<!--ENDCOURSENAME-->");
            comboBoxHtmlTemplate.Text     = cMatch.Success ? cMatch.Result("$1") : "";
            cMatch = Regex.Match(strHtml, "<!--BEGINUNITNUMBER-->(.*)<!--ENDUNITNUMBER-->");
            textBoxUnitNumber.Text        = cMatch.Success ? cMatch.Result("$1") : "";
            cMatch = Regex.Match(strHtml, "<!--BEGINASSIGNMENTNUMBER-->(.*)<!--ENDASSIGNMENTNUMBER-->");
            textBoxAssignmentNumber.Text  = cMatch.Success ? cMatch.Result("$1") : "";
            cMatch = Regex.Match(strHtml, "<!--BEGINPAGENUMBER-->(.*)<!--ENDPAGENUMBER-->");
            textBoxPageNumber.Text        = cMatch.Success ? cMatch.Result("$1") : "";
            cMatch = Regex.Match(strHtml, "<!--BEGINPAGETITLE-->(.*)<!--ENDPAGETITLE-->");
            textBoxPageTitle.Text         = cMatch.Success ? cMatch.Result("$1") : "";
            cMatch = Regex.Match(strHtml, "<!--BEGININSTRUCTIONSTITLE-->(.*)<!--ENDINSTRUCTIONSTITLE-->");
            textBoxInstructionsTitle.Text = cMatch.Success ? cMatch.Result("$1") : "";
            cMatch = Regex.Match(strHtml, "<!--BEGININSTRUCTIONSTEXT-->(.*)<!--ENDINSTRUCTIONSTEXT-->", RegexOptions.Singleline);
            textBoxInstructionsText.Text  = cMatch.Success ? cMatch.Result("$1") : "";
            cMatch = Regex.Match(strHtml, "<!--BEGINNEXTPAGETEXT-->(.*)<!--ENDNEXTPAGETEXT-->");
            textBoxNextPageText.Text      = cMatch.Success ? cMatch.Result("$1") : "";

            cMatch = Regex.Match(strHtml, "<!--BEGINQUIZFLASHOBJECT--><!--BEGINPARAMS--><!--NNN=(.*)--><!--HHH=(.*)--><!--WWW=(.*)--><!--ENDPARAMS-->");
            textBoxQuizFlashFileName.Text = cMatch.Success ? cMatch.Result("$1") : "";
            textBoxQuizFlashHeight.Text   = cMatch.Success ? cMatch.Result("$2") : "";
            textBoxQuizFlashWidth.Text    = cMatch.Success ? cMatch.Result("$3") : "";

            cMatch = Regex.Match(strHtml, "<!--BEGINNAVIFLASHOBJECT--><!--BEGINPARAMS--><!--NNN=(.*)--><!--HHH=(.*)--><!--WWW=(.*)--><!--ENDPARAMS-->");
            comboBoxNaviFlashFileName.Text = cMatch.Success ? cMatch.Result("$1") : "";
            comboBoxNaviFlashHeight.Text   = cMatch.Success ? cMatch.Result("$2") : "";
            comboBoxNaviFlashWidth.Text    = cMatch.Success ? cMatch.Result("$3") : "";

            return(sJsQuizType);
        }


        /// <summary>
        ///
        /// </summary>
        private void ClearHtml()
        {
            comboBoxHtmlTemplate.Text      = "None";
            textBoxUnitNumber.Text         = "";
            textBoxAssignmentNumber.Text   = "";
            textBoxPageNumber.Text         = "";
            textBoxPageTitle.Text          = "";
            textBoxInstructionsTitle.Text  = "";
            textBoxInstructionsText.Text   = "";
            textBoxNextPageText.Text       = "";
            textBoxQuizFlashFileName.Text  = "";
            textBoxQuizFlashHeight.Text    = "";
            textBoxQuizFlashWidth.Text     = "";
            comboBoxNaviFlashFileName.Text = "";
            comboBoxNaviFlashHeight.Text   = "";
            comboBoxNaviFlashWidth.Text    = "";
        }


        /// <summary>
        ///
        /// </summary>
        private void RenderHtml()
        {
            Cursor.Current = Cursors.WaitCursor;

//            IHTMLDocument2 hDocInput = (IHTMLDocument2)axWebBrowserInput.Document;
            HtmlDocument hDocInput = webBrowserInput.Document.OpenNew(true);

            string sHtmlDocument = CreateHtml();

//            hDocInput.write(sHtmlDocument);
//            hDocInput.close();

            hDocInput.Encoding = "UTF-8";
            hDocInput.Write(sHtmlDocument);

            Cursor.Current = Cursors.Default;

            webBrowserInput.Refresh();
        }


        /// <summary>
        ///
        /// </summary>
        private void comboBoxHtmlTemplate_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //tabControlData.SelectedTab = tabPageHtmlData;

            ReadHtmlTemplate();
            RenderHtml();
        }


        /// <summary>
        ///
        /// </summary>
        private void comboBoxNaviFlashFileName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            comboBoxNaviFlashHeight.SelectedIndex = 0;
            comboBoxNaviFlashWidth.SelectedIndex = 0;
        }


        /// <summary>
        ///
        /// </summary>
        private void buttonPreview_Click(object sender, System.EventArgs e)
        {
            RenderHtml();
        }


        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////
        ////      M E N U    U T I L I T Y   F U N C T I O N S
        ////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////


        /// <summary>
        ///
        /// </summary>
        private void ClearCurrentData()
        {
            tabControlData.TabPages.Clear();
            tabControlData.TabPages.Add(tabPageJsData);
            tabControlData.TabPages.Add(tabPageJsOptionsNone);
            tabControlData.TabPages.Add(tabPageHtmlData);
            InitializeBrowser();
            cQuiz = new CQuiz(ref dataGridQuestions, ref dTable);
            sJsQuizTemplate = "";
            sJsDataTemplate = "";
            sHtmlFileSavedAsName = "";
            sJsFileSavedAsName   = "";
        }


        /// <summary>
        ///
        /// </summary>
        private void SaveFile(string sFilePathName, string sFileData)
        {
            //if (sFilePathName.Length <= 0) {
            //    sFilePathName = sHtmlTemplatesBasePath + "ERROR.html";
            //}
            FileStream file = new FileStream(sFilePathName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(sFileData);
            sw.Close();
            file.Close();
        }


        /// <summary>
        ///
        /// </summary>
        private DialogResult PromptSaveFile(string sType)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            if (sType == "JS") {
                saveFileDialog1.Filter           = "Javascript Data File (*.js)|*.js";
                saveFileDialog1.FileName         = sJsFileSavedAsName;
                saveFileDialog1.Title            = "Save Javascript File";
            } else {
                saveFileDialog1.Filter           = "Html File (*.html)|*.html";
                saveFileDialog1.FileName         = sHtmlFileSavedAsName;
                saveFileDialog1.Title            = "Save Html File";
            }

            DialogResult drReturnResult = saveFileDialog1.ShowDialog();

            if ((drReturnResult == DialogResult.OK) && (saveFileDialog1.FileName.Length > 0)) {

                if (sType == "JS") {
                    sJsFileSavedAsName = saveFileDialog1.FileName;
                    SaveFile(sJsFileSavedAsName, cQuiz.ParseGridAndCreateJavascriptData(dataGridQuestions, sJsDataTemplate, this, tabControlData));
                } else {
                    sHtmlFileSavedAsName = saveFileDialog1.FileName;
                    SaveFile(sHtmlFileSavedAsName, CreateHtml());
                }
            }

            return(drReturnResult);
        }


        /// <summary>
        ///
        /// </summary>
        private void OpenFile(string sFilePathName, ref string sReturnFileData)
        {
            //if (sFilePathName.Length <= 0) {
            //    sFilePathName = sHtmlTemplatesBasePath + "ERROR.html";
            //}
            FileStream file = new FileStream(sFilePathName, FileMode.Open, FileAccess.Read);
            //FileStream file = new FileStream(sFilePathName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            sReturnFileData = sr.ReadToEnd();
            sr.Close();
            file.Close();
        }


        /// <summary>
        ///
        /// </summary>
        private DialogResult PromptOpenFile(string sType, ref string sReturnFile, ref string sFileType)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (sType == "JS") {
                openFileDialog1.Filter           = "Exercise Suite Files (*.js;*.html)|*.js;*.html|Javascript File (*.js)|*.js|Html File (*.html)|*.html";
                openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog1.Title            = "Open a Javascript or Html File Created with the Exercise Suite";
            }

            DialogResult drReturnResult = openFileDialog1.ShowDialog();

            if ((drReturnResult == DialogResult.OK) && (openFileDialog1.FileName.Length > 0)) {

                Match cMatch = Regex.Match(openFileDialog1.FileName, "js$");
                sFileType = cMatch.Success ? "JS" : "HTML";

                if (sFileType == "JS") {
                    sJsFileSavedAsName = openFileDialog1.FileName;
                } else {
                    sHtmlFileSavedAsName = openFileDialog1.FileName;
                }
                OpenFile(openFileDialog1.FileName, ref sReturnFile);

            }

            return(drReturnResult);
        }


        /// <summary>
        ///
        /// </summary>
        private void ReadJsQuizTemplate()
        {
            string sQuizType = cQuiz.GetQuizType();
            if (sQuizType != "None") {
                OpenFile(sJsQuizBasePath + "\\" + sQuizType + ".js", ref sJsQuizTemplate);
            }
        }


        /// <summary>
        ///
        /// </summary>
        private void ReadJsDataTemplate()
        {
            string sQuizType = cQuiz.GetQuizType();
            if (sQuizType != "None") {
                OpenFile(sJsQuizBasePath + "\\" + sQuizType + "Data.js", ref sJsDataTemplate);
            }
        }


        /// <summary>
        ///
        /// </summary>
        private void ReadHtmlTemplate()
        {
            if (comboBoxHtmlTemplate.Text == "None") {
                sHtmlTemplate = sHtmlBlankTemplate;
            } else {
                OpenFile(sHtmlTemplatesBasePath + "\\" + comboBoxHtmlTemplate.Text, ref sHtmlTemplate);
            }
        }


        /// <summary>
        ///
        /// </summary>
        private bool PromptForSaveChanges()
        {
            if (!DataChanged) return true;
            DialogResult drResultSaveJs   = DialogResult.Yes;
            DialogResult drResultSaveHtml = DialogResult.Yes;
            DialogResult drResultSaveAll  = MessageBox.Show("Do you want to save the changes?", "Exercise Suite", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (drResultSaveAll == DialogResult.Yes) {

                if (sJsFileSavedAsName == "") {
                    drResultSaveJs   = PromptSaveFile("JS");
                } else {
                    SaveFile(sJsFileSavedAsName, cQuiz.ParseGridAndCreateJavascriptData(dataGridQuestions, sJsDataTemplate, this, tabControlData));
                    drResultSaveJs = DialogResult.OK;
                }

                if (sHtmlFileSavedAsName == "") {
                    drResultSaveHtml = PromptSaveFile("HTML");
                } else {
                    SaveFile(sHtmlFileSavedAsName, CreateHtml());
                    drResultSaveHtml = DialogResult.OK;
                }
                
                //drResultSaveJs   = PromptSaveFile("JS");
                //drResultSaveHtml = PromptSaveFile("HTML");
            }
            DataChanged = false;
            return ((drResultSaveAll != DialogResult.Cancel)
                &&  ((drResultSaveJs != DialogResult.Cancel) || (drResultSaveHtml != DialogResult.Cancel)));
        }




        /// <summary>
        ///
        /// </summary>
        private void LoadNewQuiz(string sType, string sJsQuizType, string sCustomJavascriptData)
        {
            tabControlData.TabPages.Clear();
            tabControlData.TabPages.Add(tabPageJsData);

            if (sJsQuizType.IndexOf("Matching") >= 0) {
                cQuiz = new CQuizMatching(ref dataGridQuestions, ref dTable);
                tabControlData.TabPages.Add(tabPageJsOptionsMa);
            } 
            else if (sJsQuizType.IndexOf("MultipleChoice") >= 0) {
                cQuiz = new CQuizMultipleChoice(ref dataGridQuestions, ref dTable);
                tabControlData.TabPages.Add(tabPageJsOptionsMc);
            } 
            else if (sJsQuizType.IndexOf("DragAndDrop") >= 0) {
                cQuiz = new CQuizDragAndDrop(ref dataGridQuestions, ref dTable);
                tabControlData.TabPages.Add(tabPageJsOptionsDd);
            }
            else if (sJsQuizType.IndexOf("SentenceCombo") >= 0) {
                cQuiz = new CQuizSentenceCombo(ref dataGridQuestions, ref dTable);
                tabControlData.TabPages.Add(tabPageJsOptionsSc);
            } 
            else if (sJsQuizType.IndexOf("FillIn") >= 0) {
                cQuiz = new CQuizFillIn(ref dataGridQuestions, ref dTable);
                tabControlData.TabPages.Add(tabPageJsOptionsFi);
            } else {
                tabControlData.TabPages.Add(tabPageJsOptionsNone);
            }

            tabControlData.TabPages.Add(tabPageHtmlData);

            ReadJsQuizTemplate();

            if (sType == "JS") {
                if (sCustomJavascriptData != "") {
                    sJsDataTemplate = sCustomJavascriptData;
                } else {
                    ReadJsDataTemplate();
                }
                cQuiz.FillGridWithJavascriptData(ref dataGridQuestions, ref dTable, sJsDataTemplate, tabControlData);
                //tabControlData.SelectedTab = tabPageJsData;
            } else {
                cQuiz.FillGridWithJavascriptData(ref dataGridQuestions, ref dTable, sJsDataTemplate, tabControlData);
                ReadJsDataTemplate();
                //tabControlData.SelectedTab = tabPageHtmlData;
            }
            cQuiz.Changed += new CQuiz.ChangedEventHandler(DataChangedInGrid);
            RenderHtml();
        }
        bool DataChanged = false;
        public void DataChangedInGrid(bool changed)
        {
            DataChanged = changed;
        }

        /// <summary>
        ///
        /// </summary>
        private void DisplayQuizChooser()
        {
            FormChooser dlgChooser = new FormChooser();
            if (dlgChooser.ShowDialog() == DialogResult.OK) {
            }
            string sQuizSelected = dlgChooser.sQuizSelected;
            LoadNewQuiz("JS", sQuizSelected, "");
            dlgChooser.Dispose();

            buttonPreview.Text = "Render data for :  " + cQuiz.GetQuizType();
        }


        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////
        ////
        ////      M E N U S
        ////
        ////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////


        /// <summary>
        ///
        /// </summary>
        private void menuNew_Click(object sender, System.EventArgs e)
        {
            if (PromptForSaveChanges()) {

                ClearCurrentData();

                buttonPreview.Text = "Render data for :  " + cQuiz.GetQuizType();
                ClearHtml();
                RenderHtml();

                DisplayQuizChooser();
                DataChanged = false;
            }
        }


        /// <summary>
        ///
        /// </summary>
        private void menuOpen_Click(object sender, System.EventArgs e)
        {
            if (PromptForSaveChanges()) {

                ClearCurrentData();

                string sFileData = "";
                string sFileType = "";
                DialogResult drResultOpen = PromptOpenFile("JS", ref sFileData, ref sFileType);

                if (drResultOpen == DialogResult.OK) {

                    string sJsQuizType = "None";
                    if (sFileType == "JS") {
                        Match cMatch = Regex.Match(sFileData, "//JSQUIZTYPE=(.*)//JSQUIZTYPEEND", RegexOptions.Singleline);
                        sJsQuizType = cMatch.Success ? cMatch.Result("$1") : "None";
                    } else {
                        sHtmlTemplate = sFileData;
                        sJsQuizType = ParseHtmlIntoVariablesAndGetJavascriptData(sHtmlTemplate);
                        sFileData = "";
                    }
                    LoadNewQuiz(sFileType, sJsQuizType, sFileData);
                }

                buttonPreview.Text = "Render data for :  " + cQuiz.GetQuizType();
            }
        }


        /// <summary>
        ///
        /// </summary>
        private void menuClose_Click(object sender, System.EventArgs e)
        {
            if (PromptForSaveChanges()) {

                ClearCurrentData();

            }
        }


        /// <summary>
        ///
        /// </summary>
        private void menuSave_Click(object sender, System.EventArgs e)
        {
            if (sJsFileSavedAsName == "") {
                PromptSaveFile("JS");
            } else {
                SaveFile(sJsFileSavedAsName, cQuiz.ParseGridAndCreateJavascriptData(dataGridQuestions, sJsDataTemplate, this, tabControlData));
            }

            if (sHtmlFileSavedAsName == "") {
                PromptSaveFile("HTML");
            } else {
                SaveFile(sHtmlFileSavedAsName, CreateHtml());
            }
        }


        /// <summary>
        ///
        /// </summary>
        private void menuSaveAs_Click(object sender, System.EventArgs e)
        {
            // Not needed right now since easier for user to understand always just saving everything in the html
            //PromptSaveFile("JS");
            PromptSaveFile("HTML");
        }


        /// <summary>
        ///
        /// </summary>
        private void menuProperties_Click(object sender, System.EventArgs e)
        {
            FormProperties dlgProperties = new FormProperties();

            dlgProperties.textBoxJsQuizPath.Text        = sJsQuizBasePath;
            dlgProperties.textBoxHtmlTemplatesPath.Text = sHtmlTemplatesBasePath;

            if (dlgProperties.ShowDialog() == DialogResult.OK) 
            {
                RegistryKey keyWrite = Registry.CurrentUser.OpenSubKey(sRegistryKeyLocation, true);

                sJsQuizBasePath = dlgProperties.textBoxJsQuizPath.Text;
                keyWrite.SetValue("JsQuizBasePath", sJsQuizBasePath);
                sHtmlTemplatesBasePath = dlgProperties.textBoxHtmlTemplatesPath.Text;
                keyWrite.SetValue("HtmlTemplatesBasePath", sHtmlTemplatesBasePath);

                webBrowserInput.ScriptErrorsSuppressed = !dlgProperties.checkBoxShowJavascriptErrors.Checked;
            }
            dlgProperties.Dispose();
        }



        /// <summary>
        ///
        /// </summary>
        private void menuExit_Click(object sender, System.EventArgs e)
        {
            if (PromptForSaveChanges()) {

                RegistrySave();
                Application.Exit();

            }
        }


        /// <summary>
        ///
        /// </summary>
        private void formExit_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ( ! PromptForSaveChanges()) {

                e.Cancel = true;

            } else {
                RegistrySave();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PromptForSaveChanges())
            {

                e.Cancel = true;

            }
            else
            {
                RegistrySave();
                e.Cancel = false;
            }
        }


	}
}









/*
        /// <summary>
        ///
        /// </summary>
private void menuOpenJavascriptData_Click(object sender, System.EventArgs e) {
if (PromptForSaveChanges()) {

ClearCurrentData();

string sJavascriptData = "";
string sFileType = "";
DialogResult drResultOpenJs = PromptOpenFile("JS", ref sJavascriptData, ref sFileType);

if (drResultOpenJs == DialogResult.OK) {

Match cMatch = null;
cMatch = Regex.Match(sJavascriptData, "//JSQUIZTYPE=(.*)//JSQUIZTYPEEND", RegexOptions.Singleline);
string sJsQuizType = cMatch.Success ? cMatch.Result("$1") : "None";

LoadNewQuiz("JS", sJsQuizType, sJavascriptData);
}

buttonPreview.Text = "Render data for :  " + cQuiz.GetQuizType();
}
}


        /// <summary>
        ///
        /// </summary>
private void menuOpenHtml_Click(object sender, System.EventArgs e) {
if (PromptForSaveChanges()) {

ClearCurrentData();

string sFileType = "";
DialogResult drResultOpenHtml = PromptOpenFile("HTML", ref sHtmlTemplate, ref sFileType);

if (drResultOpenHtml == DialogResult.OK) {

string sJsQuizType = ParseHtmlIntoVariablesAndGetJavascriptData(sHtmlTemplate);

LoadNewQuiz("HTML", sJsQuizType, "");
}

buttonPreview.Text = "Render data for :  " + cQuiz.GetQuizType();

}
}


        /// <summary>
        ///
        /// </summary>
        private void menuSaveJavascriptData_Click(object sender, System.EventArgs e)
        {
            PromptSaveFile("JS");
        }


        /// <summary>
        ///
        /// </summary>
        private void menuSaveHtml_Click(object sender, System.EventArgs e)
        {
            PromptSaveFile("HTML");
        }



*/

