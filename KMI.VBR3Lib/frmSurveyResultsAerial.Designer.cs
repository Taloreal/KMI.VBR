namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmSurveyResultsAerial.
	/// </summary>
	// Token: 0x02000011 RID: 17
	public partial class frmSurveyResultsAerial : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600007C RID: 124 RVA: 0x00007BE8 File Offset: 0x00006BE8
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x0600007D RID: 125 RVA: 0x00007C24 File Offset: 0x00006C24
		private void InitializeComponent()
		{
			this.btnReturn = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.optBoth = new global::System.Windows.Forms.RadioButton();
			this.optWorkplaces = new global::System.Windows.Forms.RadioButton();
			this.optHomes = new global::System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.btnReturn.Location = new global::System.Drawing.Point(16, 120);
			this.btnReturn.Name = "btnReturn";
			this.btnReturn.Size = new global::System.Drawing.Size(168, 24);
			this.btnReturn.TabIndex = 1;
			this.btnReturn.Text = "Return to Survey Results";
			this.btnReturn.Click += new global::System.EventHandler(this.btnReturn_Click);
			this.groupBox1.Controls.Add(this.optBoth);
			this.groupBox1.Controls.Add(this.optWorkplaces);
			this.groupBox1.Controls.Add(this.optHomes);
			this.groupBox1.Location = new global::System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(168, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "View";
			this.optBoth.Location = new global::System.Drawing.Point(24, 72);
			this.optBoth.Name = "optBoth";
			this.optBoth.Size = new global::System.Drawing.Size(120, 16);
			this.optBoth.TabIndex = 2;
			this.optBoth.Text = "Both (connected)";
			this.optBoth.Click += new global::System.EventHandler(this.optBoth_Click);
			this.optWorkplaces.Location = new global::System.Drawing.Point(24, 48);
			this.optWorkplaces.Name = "optWorkplaces";
			this.optWorkplaces.Size = new global::System.Drawing.Size(120, 16);
			this.optWorkplaces.TabIndex = 1;
			this.optWorkplaces.Text = "Workplaces";
			this.optWorkplaces.Click += new global::System.EventHandler(this.optWorkplaces_Click);
			this.optHomes.Location = new global::System.Drawing.Point(24, 24);
			this.optHomes.Name = "optHomes";
			this.optHomes.Size = new global::System.Drawing.Size(120, 16);
			this.optHomes.TabIndex = 0;
			this.optHomes.Text = "Homes";
			this.optHomes.Click += new global::System.EventHandler(this.optHomes_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(202, 158);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnReturn);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmSurveyResultsAerial";
			base.ShowInTaskbar = false;
			this.Text = "Survey City View";
			base.Closed += new global::System.EventHandler(this.frmSurveyResultsAerial_Closed);
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.Button btnReturn;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.RadioButton optHomes;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.RadioButton optWorkplaces;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.RadioButton optBoth;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000077 RID: 119
		private global::System.ComponentModel.Container components = null;
	}
}
