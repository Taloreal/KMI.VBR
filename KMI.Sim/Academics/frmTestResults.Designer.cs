namespace KMI.Sim.Academics
{
	// Token: 0x02000057 RID: 87
	public partial class frmTestResults : global::System.Windows.Forms.Form
	{
		// Token: 0x06000316 RID: 790 RVA: 0x000187A0 File Offset: 0x000177A0
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

		// Token: 0x06000317 RID: 791 RVA: 0x000187DC File Offset: 0x000177DC
		private void InitializeComponent()
		{
			this.panResults = new global::System.Windows.Forms.Panel();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.labAverage = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.panResults.AutoScroll = true;
			this.panResults.Location = new global::System.Drawing.Point(0, 0);
			this.panResults.Name = "panResults";
			this.panResults.Size = new global::System.Drawing.Size(360, 176);
			this.panResults.TabIndex = 0;
			this.btnClose.Location = new global::System.Drawing.Point(256, 184);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(80, 24);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.labAverage.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labAverage.Location = new global::System.Drawing.Point(24, 192);
			this.labAverage.Name = "labAverage";
			this.labAverage.Size = new global::System.Drawing.Size(144, 24);
			this.labAverage.TabIndex = 2;
			this.labAverage.Text = "No test results yet.";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(362, 224);
			base.Controls.Add(this.labAverage);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.panResults);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmTestResults";
			this.Text = "Test Results";
			base.ResumeLayout(false);
		}

		// Token: 0x040001F3 RID: 499
		private global::System.Windows.Forms.Label labAverage;

		// Token: 0x040001F4 RID: 500
		private global::System.Windows.Forms.Panel panResults;

		// Token: 0x040001F5 RID: 501
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040001F6 RID: 502
		private global::System.ComponentModel.Container components = null;
	}
}
