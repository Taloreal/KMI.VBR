namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmAppSurveyResults.
	/// </summary>
	// Token: 0x02000033 RID: 51
	public partial class frmAppSurveyResults : global::KMI.Sim.Surveys.frmSurveyResults
	{
		// Token: 0x06000169 RID: 361 RVA: 0x0001402C File Offset: 0x0001302C
		private void InitializeComponent()
		{
			this.btnAerial = new global::System.Windows.Forms.Button();
			this.labAerial = new global::System.Windows.Forms.Label();
			this.panMain.SuspendLayout();
			base.SuspendLayout();
			this.panMain.Controls.Add(this.btnAerial);
			this.panMain.Controls.Add(this.labAerial);
			this.panMain.Controls.SetChildIndex(this.labAerial, 0);
			this.panMain.Controls.SetChildIndex(this.btnAerial, 0);
			this.panMain.Controls.SetChildIndex(this.kmiGraph1, 0);
			this.btnAerial.Location = new global::System.Drawing.Point(188, 131);
			this.btnAerial.Name = "btnAerial";
			this.btnAerial.Size = new global::System.Drawing.Size(208, 40);
			this.btnAerial.TabIndex = 4;
			this.btnAerial.Text = "Show Results in City View";
			this.btnAerial.Click += new global::System.EventHandler(this.btnAerial_Click);
			this.labAerial.Location = new global::System.Drawing.Point(100, 67);
			this.labAerial.Name = "labAerial";
			this.labAerial.Size = new global::System.Drawing.Size(360, 40);
			this.labAerial.TabIndex = 3;
			this.labAerial.Text = "The answers to this question are best displayed in the City view. Click the button below or select another question.";
			this.labAerial.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(760, 516);
			base.Name = "frmAppSurveyResults";
			this.panMain.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000146 RID: 326
		private global::System.Windows.Forms.Button btnAerial;

		// Token: 0x04000147 RID: 327
		private global::System.Windows.Forms.Label labAerial;
	}
}
