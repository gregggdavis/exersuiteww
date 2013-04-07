using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrowserApp
{
	/// <summary>
	/// Summary description for FormChooser.
	/// </summary>
	public class FormChooser : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button buttonMatching;
        private System.Windows.Forms.Button buttonMultipleChoice;
        private System.Windows.Forms.Button buttonDragAndDrop;
        private System.Windows.Forms.Button buttonSentenceCombo;
        private System.Windows.Forms.Button buttonFillIn;

        public string sQuizSelected = "None";

        /// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormChooser()
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
            this.buttonMatching = new System.Windows.Forms.Button();
            this.buttonMultipleChoice = new System.Windows.Forms.Button();
            this.buttonDragAndDrop = new System.Windows.Forms.Button();
            this.buttonSentenceCombo = new System.Windows.Forms.Button();
            this.buttonFillIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMatching
            // 
            this.buttonMatching.BackColor = System.Drawing.SystemColors.Control;
            this.buttonMatching.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonMatching.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.buttonMatching.Location = new System.Drawing.Point(32, 23);
            this.buttonMatching.Name = "buttonMatching";
            this.buttonMatching.Size = new System.Drawing.Size(206, 32);
            this.buttonMatching.TabIndex = 0;
            this.buttonMatching.Text = "Matching";
            this.buttonMatching.Click += new System.EventHandler(this.buttonMatching_Click);
            // 
            // buttonMultipleChoice
            // 
            this.buttonMultipleChoice.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonMultipleChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.buttonMultipleChoice.Location = new System.Drawing.Point(32, 79);
            this.buttonMultipleChoice.Name = "buttonMultipleChoice";
            this.buttonMultipleChoice.Size = new System.Drawing.Size(208, 32);
            this.buttonMultipleChoice.TabIndex = 1;
            this.buttonMultipleChoice.Text = "Multiple Choice";
            this.buttonMultipleChoice.Click += new System.EventHandler(this.buttonMultipleChoice_Click);
            // 
            // buttonDragAndDrop
            // 
            this.buttonDragAndDrop.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonDragAndDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.buttonDragAndDrop.Location = new System.Drawing.Point(32, 135);
            this.buttonDragAndDrop.Name = "buttonDragAndDrop";
            this.buttonDragAndDrop.Size = new System.Drawing.Size(208, 32);
            this.buttonDragAndDrop.TabIndex = 2;
            this.buttonDragAndDrop.Text = "Drag And Drop";
            this.buttonDragAndDrop.Click += new System.EventHandler(this.buttonDragAndDrop_Click);
            // 
            // buttonSentenceCombo
            // 
            this.buttonSentenceCombo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSentenceCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.buttonSentenceCombo.Location = new System.Drawing.Point(32, 247);
            this.buttonSentenceCombo.Name = "buttonSentenceCombo";
            this.buttonSentenceCombo.Size = new System.Drawing.Size(208, 32);
            this.buttonSentenceCombo.TabIndex = 4;
            this.buttonSentenceCombo.Text = "Sentence Combo";
            this.buttonSentenceCombo.Click += new System.EventHandler(this.buttonSentenceCombo_Click);
            // 
            // buttonFillIn
            // 
            this.buttonFillIn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonFillIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.buttonFillIn.Location = new System.Drawing.Point(32, 191);
            this.buttonFillIn.Name = "buttonFillIn";
            this.buttonFillIn.Size = new System.Drawing.Size(208, 32);
            this.buttonFillIn.TabIndex = 3;
            this.buttonFillIn.Text = "Fill In";
            this.buttonFillIn.Click += new System.EventHandler(this.buttonFillIn_Click);
            // 
            // FormChooser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(272, 302);
            this.Controls.Add(this.buttonFillIn);
            this.Controls.Add(this.buttonSentenceCombo);
            this.Controls.Add(this.buttonDragAndDrop);
            this.Controls.Add(this.buttonMultipleChoice);
            this.Controls.Add(this.buttonMatching);
            this.Name = "FormChooser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose A New Quiz Type";
            this.ResumeLayout(false);

        }
		#endregion

        private void buttonMatching_Click(object sender, System.EventArgs e)
        {
            sQuizSelected = "Matching";
        }

        private void buttonMultipleChoice_Click(object sender, System.EventArgs e)
        {
            sQuizSelected = "MultipleChoice";
        }

        private void buttonDragAndDrop_Click(object sender, System.EventArgs e) {
            sQuizSelected = "DragAndDrop";
        }

        private void buttonSentenceCombo_Click(object sender, System.EventArgs e) {
            sQuizSelected = "SentenceCombo";
        }

        private void buttonFillIn_Click(object sender, System.EventArgs e) {
            sQuizSelected = "FillIn";
        }
	}
}
