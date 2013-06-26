using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrowserApp
{
	/// <summary>
	/// Summary description for FormProperties.
	/// </summary>
	public class FormProperties : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonJsTemplatesPath;
        public System.Windows.Forms.TextBox textBoxHtmlTemplatesPath;
        private System.Windows.Forms.Button buttonHtmlTemplatesPath;
        public System.Windows.Forms.TextBox textBoxJsQuizPath;
        public CheckBox checkBoxShowJavascriptErrors;
        private GroupBox groupBoxProperties;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormProperties()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxJsQuizPath = new System.Windows.Forms.TextBox();
            this.buttonJsTemplatesPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxHtmlTemplatesPath = new System.Windows.Forms.TextBox();
            this.buttonHtmlTemplatesPath = new System.Windows.Forms.Button();
            this.checkBoxShowJavascriptErrors = new System.Windows.Forms.CheckBox();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(359, 210);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(105, 28);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(522, 210);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(106, 28);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Javascript Templates Folder:";
            // 
            // textBoxJsQuizPath
            // 
            this.textBoxJsQuizPath.Location = new System.Drawing.Point(207, 101);
            this.textBoxJsQuizPath.Name = "textBoxJsQuizPath";
            this.textBoxJsQuizPath.Size = new System.Drawing.Size(585, 22);
            this.textBoxJsQuizPath.TabIndex = 2;
            // 
            // buttonJsTemplatesPath
            // 
            this.buttonJsTemplatesPath.Location = new System.Drawing.Point(802, 101);
            this.buttonJsTemplatesPath.Name = "buttonJsTemplatesPath";
            this.buttonJsTemplatesPath.Size = new System.Drawing.Size(96, 23);
            this.buttonJsTemplatesPath.TabIndex = 3;
            this.buttonJsTemplatesPath.Text = "Browse";
            this.buttonJsTemplatesPath.Click += new System.EventHandler(this.buttonExercisesPath_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Html Templates Folder:";
            // 
            // textBoxHtmlTemplatesPath
            // 
            this.textBoxHtmlTemplatesPath.Location = new System.Drawing.Point(207, 50);
            this.textBoxHtmlTemplatesPath.Name = "textBoxHtmlTemplatesPath";
            this.textBoxHtmlTemplatesPath.Size = new System.Drawing.Size(585, 22);
            this.textBoxHtmlTemplatesPath.TabIndex = 0;
            // 
            // buttonHtmlTemplatesPath
            // 
            this.buttonHtmlTemplatesPath.Location = new System.Drawing.Point(802, 50);
            this.buttonHtmlTemplatesPath.Name = "buttonHtmlTemplatesPath";
            this.buttonHtmlTemplatesPath.Size = new System.Drawing.Size(96, 23);
            this.buttonHtmlTemplatesPath.TabIndex = 1;
            this.buttonHtmlTemplatesPath.Text = "Browse";
            this.buttonHtmlTemplatesPath.Click += new System.EventHandler(this.buttonHtmlPath_Click);
            // 
            // checkBoxShowJavascriptErrors
            // 
            this.checkBoxShowJavascriptErrors.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowJavascriptErrors.Location = new System.Drawing.Point(22, 168);
            this.checkBoxShowJavascriptErrors.Name = "checkBoxShowJavascriptErrors";
            this.checkBoxShowJavascriptErrors.Size = new System.Drawing.Size(203, 29);
            this.checkBoxShowJavascriptErrors.TabIndex = 10;
            this.checkBoxShowJavascriptErrors.Text = "Show Javascript Errors";
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProperties.Location = new System.Drawing.Point(16, 16);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(900, 130);
            this.groupBoxProperties.TabIndex = 11;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "DON\'T MODIFY";
            // 
            // FormProperties
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.AutoSize = true;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(934, 255);
            this.Controls.Add(this.checkBoxShowJavascriptErrors);
            this.Controls.Add(this.buttonHtmlTemplatesPath);
            this.Controls.Add(this.textBoxHtmlTemplatesPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonJsTemplatesPath);
            this.Controls.Add(this.textBoxJsQuizPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBoxProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProperties";
            this.ShowInTaskbar = false;
            this.Text = "Exercise Suite Properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        private void buttonExercisesPath_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();  
 
            dlgFolder.Description  = "Select Exercises Folder"; 
            dlgFolder.ShowNewFolderButton = false;
            dlgFolder.SelectedPath = textBoxJsQuizPath.Text;

            if (dlgFolder.ShowDialog() == DialogResult.OK) 
            {
                textBoxJsQuizPath.Text = dlgFolder.SelectedPath;
            }
        }

        private void buttonHtmlPath_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();  
 
            dlgFolder.Description  = "Select Html Templates Folder"; 
            dlgFolder.ShowNewFolderButton = false;
            dlgFolder.SelectedPath = textBoxHtmlTemplatesPath.Text;

            if (dlgFolder.ShowDialog() == DialogResult.OK) 
            {
                textBoxHtmlTemplatesPath.Text = dlgFolder.SelectedPath;
            }
        }

	}
}
