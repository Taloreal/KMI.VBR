namespace KMI.Biz.Product
{
	// Token: 0x02000020 RID: 32
	public partial class frmTradeCredit : global::System.Windows.Forms.Form
	{
		// Token: 0x060000EF RID: 239 RVA: 0x0000DA04 File Offset: 0x0000CA04
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

		// Token: 0x060000F0 RID: 240 RVA: 0x0000DA40 File Offset: 0x0000CA40
		private void InitializeComponent()
		{
			this.labPaymentTerms = new global::System.Windows.Forms.Label();
			this.labTotalOwed = new global::System.Windows.Forms.Label();
			this.labPastDue = new global::System.Windows.Forms.Label();
			this.labOldestInvoice = new global::System.Windows.Forms.Label();
			this.labPayIn = new global::System.Windows.Forms.Label();
			this.cmdOK = new global::System.Windows.Forms.Button();
			this.cmdCancel = new global::System.Windows.Forms.Button();
			this.cmdHelp = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panUpdDays = new global::System.Windows.Forms.Panel();
			this.updDays0 = new global::System.Windows.Forms.NumericUpDown();
			this.labOldestInvoice0 = new global::System.Windows.Forms.Label();
			this.labVendorName0 = new global::System.Windows.Forms.Label();
			this.labPaymentTerms0 = new global::System.Windows.Forms.Label();
			this.labTotalOwed0 = new global::System.Windows.Forms.Label();
			this.labPastDue0 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.labVendorName = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panUpdDays.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updDays0).BeginInit();
			base.SuspendLayout();
			this.labPaymentTerms.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labPaymentTerms.Location = new global::System.Drawing.Point(168, 8);
			this.labPaymentTerms.Name = "labPaymentTerms";
			this.labPaymentTerms.Size = new global::System.Drawing.Size(72, 16);
			this.labPaymentTerms.TabIndex = 1;
			this.labPaymentTerms.Text = "Payment";
			this.labTotalOwed.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labTotalOwed.Location = new global::System.Drawing.Point(240, 24);
			this.labTotalOwed.Name = "labTotalOwed";
			this.labTotalOwed.Size = new global::System.Drawing.Size(88, 16);
			this.labTotalOwed.TabIndex = 3;
			this.labTotalOwed.Text = "Total Owed";
			this.labPastDue.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labPastDue.Location = new global::System.Drawing.Point(328, 24);
			this.labPastDue.Name = "labPastDue";
			this.labPastDue.Size = new global::System.Drawing.Size(72, 16);
			this.labPastDue.TabIndex = 4;
			this.labPastDue.Text = "Past Due";
			this.labOldestInvoice.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labOldestInvoice.Location = new global::System.Drawing.Point(408, 24);
			this.labOldestInvoice.Name = "labOldestInvoice";
			this.labOldestInvoice.Size = new global::System.Drawing.Size(88, 16);
			this.labOldestInvoice.TabIndex = 5;
			this.labOldestInvoice.Text = "Oldest Invoice";
			this.labPayIn.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labPayIn.Location = new global::System.Drawing.Point(512, 24);
			this.labPayIn.Name = "labPayIn";
			this.labPayIn.Size = new global::System.Drawing.Size(80, 16);
			this.labPayIn.TabIndex = 6;
			this.labPayIn.Text = "Pay in (days)";
			this.cmdOK.Location = new global::System.Drawing.Point(104, 224);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new global::System.Drawing.Size(104, 24);
			this.cmdOK.TabIndex = 9;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new global::System.EventHandler(this.cmdOK_Click);
			this.cmdCancel.Location = new global::System.Drawing.Point(248, 224);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new global::System.Drawing.Size(104, 24);
			this.cmdCancel.TabIndex = 10;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Click += new global::System.EventHandler(this.cmdCancel_Click);
			this.cmdHelp.Location = new global::System.Drawing.Point(392, 224);
			this.cmdHelp.Name = "cmdHelp";
			this.cmdHelp.Size = new global::System.Drawing.Size(104, 24);
			this.cmdHelp.TabIndex = 11;
			this.cmdHelp.Text = "Help";
			this.cmdHelp.Click += new global::System.EventHandler(this.cmdHelp_Click);
			this.panel1.Controls.Add(this.panUpdDays);
			this.panel1.Controls.Add(this.labOldestInvoice0);
			this.panel1.Controls.Add(this.labVendorName0);
			this.panel1.Controls.Add(this.labPaymentTerms0);
			this.panel1.Controls.Add(this.labTotalOwed0);
			this.panel1.Controls.Add(this.labPastDue0);
			this.panel1.Location = new global::System.Drawing.Point(8, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(592, 96);
			this.panel1.TabIndex = 7;
			this.panUpdDays.Controls.Add(this.updDays0);
			this.panUpdDays.Location = new global::System.Drawing.Point(496, 0);
			this.panUpdDays.Name = "panUpdDays";
			this.panUpdDays.Size = new global::System.Drawing.Size(88, 96);
			this.panUpdDays.TabIndex = 5;
			this.updDays0.Location = new global::System.Drawing.Point(16, 8);
			this.updDays0.Name = "updDays0";
			this.updDays0.Size = new global::System.Drawing.Size(56, 20);
			this.updDays0.TabIndex = 0;
			this.updDays0.Tag = "0";
			this.updDays0.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.labOldestInvoice0.Location = new global::System.Drawing.Point(408, 16);
			this.labOldestInvoice0.Name = "labOldestInvoice0";
			this.labOldestInvoice0.Size = new global::System.Drawing.Size(72, 16);
			this.labOldestInvoice0.TabIndex = 4;
			this.labOldestInvoice0.Tag = "0";
			this.labVendorName0.Location = new global::System.Drawing.Point(8, 16);
			this.labVendorName0.Name = "labVendorName0";
			this.labVendorName0.Size = new global::System.Drawing.Size(144, 16);
			this.labVendorName0.TabIndex = 0;
			this.labVendorName0.Text = "#";
			this.labPaymentTerms0.Location = new global::System.Drawing.Point(160, 16);
			this.labPaymentTerms0.Name = "labPaymentTerms0";
			this.labPaymentTerms0.Size = new global::System.Drawing.Size(56, 16);
			this.labPaymentTerms0.TabIndex = 1;
			this.labPaymentTerms0.Tag = "0";
			this.labTotalOwed0.Location = new global::System.Drawing.Point(232, 16);
			this.labTotalOwed0.Name = "labTotalOwed0";
			this.labTotalOwed0.Size = new global::System.Drawing.Size(72, 16);
			this.labTotalOwed0.TabIndex = 2;
			this.labTotalOwed0.Tag = "0";
			this.labTotalOwed0.Text = "#";
			this.labPastDue0.Location = new global::System.Drawing.Point(320, 16);
			this.labPastDue0.Name = "labPastDue0";
			this.labPastDue0.Size = new global::System.Drawing.Size(72, 16);
			this.labPastDue0.TabIndex = 3;
			this.labPastDue0.Tag = "0";
			this.labPastDue0.Text = "#";
			this.label6.Location = new global::System.Drawing.Point(104, 144);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(392, 48);
			this.label6.TabIndex = 8;
			this.label6.Text = "#";
			this.labVendorName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labVendorName.Location = new global::System.Drawing.Point(8, 24);
			this.labVendorName.Name = "labVendorName";
			this.labVendorName.Size = new global::System.Drawing.Size(88, 16);
			this.labVendorName.TabIndex = 0;
			this.labVendorName.Text = "Vendor Name";
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(168, 24);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(48, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Terms";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(608, 270);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.labVendorName);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.cmdHelp);
			base.Controls.Add(this.cmdCancel);
			base.Controls.Add(this.cmdOK);
			base.Controls.Add(this.labPayIn);
			base.Controls.Add(this.labOldestInvoice);
			base.Controls.Add(this.labPastDue);
			base.Controls.Add(this.labTotalOwed);
			base.Controls.Add(this.labPaymentTerms);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmTradeCredit";
			base.ShowInTaskbar = false;
			this.Text = "Trade Credit";
			this.panel1.ResumeLayout(false);
			this.panUpdDays.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updDays0).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.Button cmdOK;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.Button cmdCancel;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.Label labPaymentTerms;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.Label labTotalOwed;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.Label labPastDue;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.Label labOldestInvoice;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.Label labPayIn;

		// Token: 0x0400013C RID: 316
		private global::System.Windows.Forms.Button cmdHelp;

		// Token: 0x0400013D RID: 317
		private global::System.Windows.Forms.Label labVendorName;

		// Token: 0x0400013E RID: 318
		private global::System.Windows.Forms.Label labVendorName0;

		// Token: 0x0400013F RID: 319
		private global::System.Windows.Forms.Label labPaymentTerms0;

		// Token: 0x04000140 RID: 320
		private global::System.Windows.Forms.Label labTotalOwed0;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.Label labPastDue0;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.Label labOldestInvoice0;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.Panel panUpdDays;

		// Token: 0x04000144 RID: 324
		private global::System.Windows.Forms.NumericUpDown updDays0;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000146 RID: 326
		private global::System.ComponentModel.Container components = null;
	}
}
