namespace KMI.Biz.Product
{
	// Token: 0x02000012 RID: 18
	public partial class frmReportsAR : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00007EA4 File Offset: 0x00006EA4
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

		// Token: 0x0600006F RID: 111 RVA: 0x00007EE0 File Offset: 0x00006EE0
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.Header = new global::KMI.Biz.Product.CustomControls.ARInfo();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Location = new global::System.Drawing.Point(16, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(576, 224);
			this.panel1.TabIndex = 0;
			this.Header.Location = new global::System.Drawing.Point(16, 16);
			this.Header.Name = "Header";
			this.Header.Size = new global::System.Drawing.Size(544, 24);
			this.Header.TabIndex = 2;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(200, 280);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Close";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(336, 280);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 7;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(610, 320);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.Header);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmReportsAR";
			base.ShowInTaskbar = false;
			this.Text = "Accounts Receivable";
			base.ResumeLayout(false);
		}

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040000AD RID: 173
		private global::KMI.Biz.Product.CustomControls.ARInfo Header;

		// Token: 0x040000AE RID: 174
		private global::System.ComponentModel.Container components = null;
	}
}
