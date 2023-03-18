using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmAutoLayout.
	/// </summary>
	// Token: 0x0200003F RID: 63
	public partial class frmAutoLayout : Form
	{
		// Token: 0x060001ED RID: 493 RVA: 0x0001CE0C File Offset: 0x0001BE0C
		public frmAutoLayout()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0001D244 File Offset: 0x0001C244
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0001D24E File Offset: 0x0001C24E
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0001D260 File Offset: 0x0001C260
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.radAuto.Checked)
			{
				A.SA.AutoLayout(A.MF.CurrentEntityID);
			}
			base.Close();
		}
	}
}
