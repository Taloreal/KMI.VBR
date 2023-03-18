namespace KMI.Biz.Banking
{
	// Token: 0x02000006 RID: 6
	public partial class frmPayLoan : global::System.Windows.Forms.Form
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002F80 File Offset: 0x00001F80
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

		// Token: 0x06000018 RID: 24 RVA: 0x00002FBC File Offset: 0x00001FBC
		private void InitializeComponent()
		{
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.panLoans = new global::System.Windows.Forms.Panel();
			this.labLoan = new global::System.Windows.Forms.Label();
			this.updAmount = new global::System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panLoans.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).BeginInit();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.btnHelp.Location = new global::System.Drawing.Point(288, 216);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(176, 216);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnOK.Location = new global::System.Drawing.Point(64, 216);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.panLoans.AutoScroll = true;
			this.panLoans.Controls.Add(this.labLoan);
			this.panLoans.Controls.Add(this.updAmount);
			this.panLoans.Location = new global::System.Drawing.Point(16, 24);
			this.panLoans.Name = "panLoans";
			this.panLoans.Size = new global::System.Drawing.Size(408, 136);
			this.panLoans.TabIndex = 0;
			this.labLoan.Location = new global::System.Drawing.Point(16, 16);
			this.labLoan.Name = "labLoan";
			this.labLoan.Size = new global::System.Drawing.Size(256, 16);
			this.labLoan.TabIndex = 0;
			this.labLoan.Text = "$100,000 at 12% interest due 10/04/05.";
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updAmount;
			int[] array = new int[4];
			array[0] = 1000;
			numericUpDown.Increment = new decimal(array);
			this.updAmount.Location = new global::System.Drawing.Point(280, 16);
			this.updAmount.Name = "updAmount";
			this.updAmount.Size = new global::System.Drawing.Size(88, 20);
			this.updAmount.TabIndex = 1;
			this.updAmount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.groupBox1.Controls.Add(this.panLoans);
			this.groupBox1.Location = new global::System.Drawing.Point(16, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(432, 176);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Outstanding Loans: Enter amount to pay next to any or all loans.";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(464, 254);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmPayLoan";
			base.ShowInTaskbar = false;
			this.Text = "Pay Loan";
			base.Load += new global::System.EventHandler(this.frmPayLoan_Load);
			this.panLoans.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updAmount).EndInit();
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Panel panLoans;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.NumericUpDown updAmount;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Label labLoan;

		// Token: 0x0400001D RID: 29
		private global::System.ComponentModel.Container components = null;
	}
}
