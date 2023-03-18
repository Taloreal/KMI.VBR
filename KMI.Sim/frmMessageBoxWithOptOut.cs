using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000053 RID: 83
	public partial class frmMessageBoxWithOptOut : Form
	{
		// Token: 0x06000307 RID: 775 RVA: 0x0001828C File Offset: 0x0001728C
		public frmMessageBoxWithOptOut(string title, string message) : this(title, message, true)
		{
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0001829A File Offset: 0x0001729A
		public frmMessageBoxWithOptOut(string title, string message, bool optOutEnabled)
		{
			this.InitializeComponent();
			this.Text = title;
			this.labText.Text = message;
			this.chkDontShow.Visible = optOutEnabled;
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00018514 File Offset: 0x00017514
		private void frmMessageBoxWithOptOut_Closed(object sender, EventArgs e)
		{
			if (this.chkDontShow.Checked)
			{
				S.I.DontShowAgain(this.Text);
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00018545 File Offset: 0x00017545
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
