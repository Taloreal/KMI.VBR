using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200004A RID: 74
	public class ToolbarSponsored : ToolBar
	{
		// Token: 0x06000290 RID: 656 RVA: 0x00015204 File Offset: 0x00014204
		public ToolbarSponsored()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00015220 File Offset: 0x00014220
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

		// Token: 0x06000292 RID: 658 RVA: 0x0001525C File Offset: 0x0001425C
		private void InitializeComponent()
		{
			this.labLogo = new Label();
			base.SuspendLayout();
			this.labLogo.Dock = DockStyle.Right;
			this.labLogo.Location = new Point(110, 0);
			this.labLogo.Name = "labLogo";
			this.labLogo.Size = new Size(40, 150);
			this.labLogo.TabIndex = 0;
			base.Controls.Add(this.labLogo);
			base.Name = "ToolbarSponsored";
			base.ResumeLayout(false);
		}

		// Token: 0x040001B3 RID: 435
		public Label labLogo;

		// Token: 0x040001B4 RID: 436
		private Container components = null;
	}
}
