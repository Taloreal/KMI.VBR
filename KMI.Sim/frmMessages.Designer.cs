namespace KMI.Sim
{
	// Token: 0x02000072 RID: 114
	public partial class frmMessages : global::System.Windows.Forms.Form
	{
		// Token: 0x06000424 RID: 1060 RVA: 0x0001E1D8 File Offset: 0x0001D1D8
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

		// Token: 0x06000425 RID: 1061 RVA: 0x0001E214 File Offset: 0x0001D214
		private void InitializeComponent()
		{
			base.AutoScale = false;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			base.ClientSize = new global::System.Drawing.Size(288, 166);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Location = new global::System.Drawing.Point(0, 5000);
			this.MinimumSize = new global::System.Drawing.Size(200, 160);
			base.Name = "frmMessages";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Message Center";
			base.Resize += new global::System.EventHandler(this.frmMessages_Resize);
			base.Closing += new global::System.ComponentModel.CancelEventHandler(this.frmMessages_Closing);
		}

		// Token: 0x040002C0 RID: 704
		private global::System.ComponentModel.IContainer components;
	}
}
