using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000074 RID: 116
	public partial class frmCreateMessage : Form
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x0001E840 File Offset: 0x0001D840
		public frmCreateMessage()
		{
			this.InitializeComponent();
			this.labFrom.Text = S.I.MultiplayerRoleName + ", " + S.I.ThisPlayerName;
			this.labTo.Text = S.I.ThisPlayerName + " " + S.R.GetString("Executive Team");
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0001EE01 File Offset: 0x0001DE01
		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0001EE0B File Offset: 0x0001DE0B
		private void btnSend_Click(object sender, EventArgs e)
		{
			S.SA.SendMessage(this.labFrom.Text, S.I.ThisPlayerName, this.txtMemo.Text);
			base.Close();
		}
	}
}
