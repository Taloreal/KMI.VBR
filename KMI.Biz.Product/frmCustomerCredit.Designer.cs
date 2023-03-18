namespace KMI.Biz.Product
{
	// Token: 0x02000003 RID: 3
	public partial class frmCustomerCredit : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000247C File Offset: 0x0000147C
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

		// Token: 0x0600000F RID: 15 RVA: 0x000024B8 File Offset: 0x000014B8
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.updEarlyPayDiscount = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.updEarlyPayDays = new global::System.Windows.Forms.NumericUpDown();
			this.updNetPayDays = new global::System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.lstNoCredit = new global::System.Windows.Forms.ListBox();
			this.lstCredit = new global::System.Windows.Forms.ListBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.Header = new global::KMI.Biz.Product.CustomControls.ARInfo();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCredit = new global::System.Windows.Forms.Button();
			this.btnNoCredit = new global::System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updEarlyPayDiscount).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.updEarlyPayDays).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.updNetPayDays).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			this.panel1.AutoScroll = true;
			this.panel1.Location = new global::System.Drawing.Point(16, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(576, 200);
			this.panel1.TabIndex = 0;
			this.groupBox1.Controls.Add(this.updEarlyPayDiscount);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.updEarlyPayDays);
			this.groupBox1.Controls.Add(this.updNetPayDays);
			this.groupBox1.Location = new global::System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(248, 128);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Credit Terms";
			this.updEarlyPayDiscount.Location = new global::System.Drawing.Point(168, 48);
			this.updEarlyPayDiscount.Name = "updEarlyPayDiscount";
			this.updEarlyPayDiscount.Size = new global::System.Drawing.Size(64, 20);
			this.updEarlyPayDiscount.TabIndex = 4;
			this.updEarlyPayDiscount.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.label4.Location = new global::System.Drawing.Point(16, 104);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(136, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Net Payment Due Days:";
			this.label3.Location = new global::System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(136, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Early Payment Days:";
			this.label2.Location = new global::System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(128, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Early Pay Discount(%):";
			this.label1.Location = new global::System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(96, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Current Terms:";
			this.updEarlyPayDays.Location = new global::System.Drawing.Point(168, 72);
			this.updEarlyPayDays.Name = "updEarlyPayDays";
			this.updEarlyPayDays.Size = new global::System.Drawing.Size(64, 20);
			this.updEarlyPayDays.TabIndex = 8;
			this.updEarlyPayDays.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updNetPayDays.Location = new global::System.Drawing.Point(168, 96);
			this.updNetPayDays.Name = "updNetPayDays";
			this.updNetPayDays.Size = new global::System.Drawing.Size(64, 20);
			this.updNetPayDays.TabIndex = 8;
			this.updNetPayDays.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.groupBox2.Controls.Add(this.btnNoCredit);
			this.groupBox2.Controls.Add(this.btnCredit);
			this.groupBox2.Controls.Add(this.lstNoCredit);
			this.groupBox2.Controls.Add(this.lstCredit);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new global::System.Drawing.Point(280, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(336, 128);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Customer Credit Status";
			this.lstNoCredit.Location = new global::System.Drawing.Point(192, 40);
			this.lstNoCredit.Name = "lstNoCredit";
			this.lstNoCredit.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstNoCredit.Size = new global::System.Drawing.Size(128, 82);
			this.lstNoCredit.Sorted = true;
			this.lstNoCredit.TabIndex = 3;
			this.lstCredit.Location = new global::System.Drawing.Point(16, 40);
			this.lstCredit.Name = "lstCredit";
			this.lstCredit.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstCredit.Size = new global::System.Drawing.Size(128, 82);
			this.lstCredit.Sorted = true;
			this.lstCredit.TabIndex = 2;
			this.label6.Location = new global::System.Drawing.Point(192, 24);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(128, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "Cash-on-Delivery:";
			this.label5.Location = new global::System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(112, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Offer Credit To:";
			this.groupBox3.Controls.Add(this.Header);
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Location = new global::System.Drawing.Point(16, 152);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(600, 248);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Accounts Receivable";
			this.Header.Location = new global::System.Drawing.Point(16, 16);
			this.Header.Name = "Header";
			this.Header.Size = new global::System.Drawing.Size(544, 24);
			this.Header.TabIndex = 2;
			this.btnOK.Location = new global::System.Drawing.Point(144, 408);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(264, 408);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(384, 408);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 7;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCredit.Location = new global::System.Drawing.Point(152, 48);
			this.btnCredit.Name = "btnCredit";
			this.btnCredit.Size = new global::System.Drawing.Size(32, 32);
			this.btnCredit.TabIndex = 4;
			this.btnCredit.Text = "<<";
			this.btnCredit.Click += new global::System.EventHandler(this.btnCredit_Click);
			this.btnNoCredit.Location = new global::System.Drawing.Point(152, 88);
			this.btnNoCredit.Name = "btnNoCredit";
			this.btnNoCredit.Size = new global::System.Drawing.Size(32, 32);
			this.btnNoCredit.TabIndex = 5;
			this.btnNoCredit.Text = ">>";
			this.btnNoCredit.Click += new global::System.EventHandler(this.btnNoCredit_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(634, 448);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmCustomerCredit";
			base.ShowInTaskbar = false;
			this.Text = "Customer Credit";
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updEarlyPayDiscount).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.updEarlyPayDays).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.updNetPayDays).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x0400000D RID: 13
		private global::KMI.Biz.Product.CustomControls.ARInfo Header;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.ListBox lstNoCredit;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.ListBox lstCredit;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Button btnCredit;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Button btnNoCredit;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.NumericUpDown updEarlyPayDiscount;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.NumericUpDown updEarlyPayDays;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.NumericUpDown updNetPayDays;

		// Token: 0x0400001B RID: 27
		private global::System.ComponentModel.Container components = null;
	}
}
