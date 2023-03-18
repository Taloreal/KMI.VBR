using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	// Token: 0x02000023 RID: 35
	public partial class frmBillboard : Form, IActionForm
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x0000DDD8 File Offset: 0x0000CDD8
		public frmBillboard()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000E317 File Offset: 0x0000D317
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000E321 File Offset: 0x0000D321
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Billboards");
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000E32F File Offset: 0x0000D32F
		private void frmBillboard_Closed(object sender, EventArgs e)
		{
			((CityView)A.I.Views[0]).Mode = CityView.Modes.Default;
		}
	}
}
