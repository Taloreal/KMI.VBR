namespace KMI.Biz.Banking
{
	// Token: 0x02000004 RID: 4
	public partial class frmGetLoan : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000F RID: 15 RVA: 0x0000249C File Offset: 0x0000149C
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

		// Token: 0x06000010 RID: 16 RVA: 0x000024D8 File Offset: 0x000014D8
		private void InitializeComponent()
		{
			this.txtCreditReport = new global::System.Windows.Forms.TextBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.grpOptions = new global::System.Windows.Forms.GroupBox();
			this.labCreditDenied = new global::System.Windows.Forms.Label();
			this.optLoan = new global::System.Windows.Forms.RadioButton();
			this.grpOptions.SuspendLayout();
			base.SuspendLayout();
			this.txtCreditReport.BackColor = global::System.Drawing.SystemColors.Control;
			this.txtCreditReport.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.txtCreditReport.Location = new global::System.Drawing.Point(24, 16);
			this.txtCreditReport.Multiline = true;
			this.txtCreditReport.Name = "txtCreditReport";
			this.txtCreditReport.ReadOnly = true;
			this.txtCreditReport.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.txtCreditReport.Size = new global::System.Drawing.Size(312, 136);
			this.txtCreditReport.TabIndex = 0;
			this.txtCreditReport.TabStop = false;
			this.txtCreditReport.Text = "textBox1";
			this.btnOK.Location = new global::System.Drawing.Point(16, 312);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(128, 312);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(240, 312);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.grpOptions.Controls.Add(this.labCreditDenied);
			this.grpOptions.Controls.Add(this.optLoan);
			this.grpOptions.Location = new global::System.Drawing.Point(16, 160);
			this.grpOptions.Name = "grpOptions";
			this.grpOptions.Size = new global::System.Drawing.Size(320, 136);
			this.grpOptions.TabIndex = 4;
			this.grpOptions.TabStop = false;
			this.grpOptions.Text = "Available loans based on your credit rating. Choose one:";
			this.labCreditDenied.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labCreditDenied.ForeColor = global::System.Drawing.Color.Red;
			this.labCreditDenied.Location = new global::System.Drawing.Point(48, 48);
			this.labCreditDenied.Name = "labCreditDenied";
			this.labCreditDenied.Size = new global::System.Drawing.Size(224, 40);
			this.labCreditDenied.TabIndex = 1;
			this.labCreditDenied.Text = "Credit Denied";
			this.labCreditDenied.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labCreditDenied.Visible = false;
			this.optLoan.Location = new global::System.Drawing.Point(16, 24);
			this.optLoan.Name = "optLoan";
			this.optLoan.Size = new global::System.Drawing.Size(272, 16);
			this.optLoan.TabIndex = 0;
			this.optLoan.Text = "$50,000 for 5 years at 12% interest rate.";
			this.optLoan.Visible = false;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(354, 352);
			base.Controls.Add(this.grpOptions);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.txtCreditReport);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmGetLoan";
			base.ShowInTaskbar = false;
			this.Text = "Get Loan";
			base.Load += new global::System.EventHandler(this.frmGetLoan_Load);
			this.grpOptions.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.TextBox txtCreditReport;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.GroupBox grpOptions;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.RadioButton optLoan;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label labCreditDenied;

		// Token: 0x0400000D RID: 13
		private global::System.ComponentModel.Container components = null;
	}
}
