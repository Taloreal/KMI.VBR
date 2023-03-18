using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000072 RID: 114
	public partial class frmMessages : Form
	{
		// Token: 0x06000423 RID: 1059 RVA: 0x0001E1BC File Offset: 0x0001D1BC
		public frmMessages()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0001E2D8 File Offset: 0x0001D2D8
		public void AddMessage(PlayerMessage message)
		{
			if (base.Controls.Count == frmMessages.MAX_MESSAGES)
			{
				base.Controls.RemoveAt(0);
			}
			MessageControl messageControl = new MessageControl(message);
			if (this.alternateBackground)
			{
				messageControl.BackColor = Color.Gainsboro;
			}
			this.alternateBackground = !this.alternateBackground;
			base.SuspendLayout();
			base.Controls.Add(messageControl);
			base.ResumeLayout();
			this.frmMessages_Resize(this, new EventArgs());
			base.ScrollControlIntoView(base.Controls[base.Controls.Count - 1]);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0001E386 File Offset: 0x0001D386
		private void frmMessages_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			S.MF.HideMessageWindow();
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0001E39C File Offset: 0x0001D39C
		public void Clear()
		{
			base.SuspendLayout();
			base.Controls.Clear();
			base.ResumeLayout();
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0001E3BC File Offset: 0x0001D3BC
		private void frmMessages_Resize(object sender, EventArgs e)
		{
			base.SuspendLayout();
			for (int i = 0; i < base.Controls.Count; i++)
			{
				MessageControl messageControl = (MessageControl)base.Controls[i];
				messageControl.Width = base.Width - 30;
				if (i == 0)
				{
					messageControl.Location = new Point(base.AutoScrollPosition.X, base.AutoScrollPosition.Y);
				}
				else
				{
					messageControl.Location = new Point(base.AutoScrollPosition.X, base.Controls[i - 1].Location.Y + base.Controls[i - 1].Height);
				}
			}
			base.ResumeLayout();
		}

		// Token: 0x040002BF RID: 703
		protected const int AVAILABLE_WIDTH = 30;

		// Token: 0x040002C1 RID: 705
		protected bool alternateBackground = false;

		// Token: 0x040002C2 RID: 706
		public static int MAX_MESSAGES = 20;
	}
}
