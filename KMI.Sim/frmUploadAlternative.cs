using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000078 RID: 120
	public partial class frmUploadAlternative : Form
	{
		// Token: 0x06000445 RID: 1093 RVA: 0x0001F3E0 File Offset: 0x0001E3E0
		public frmUploadAlternative(string post)
		{
			this.InitializeComponent();
			string key = "prkdeGRNIK648593648qwcvhufUYTFVC3456748392KJHSDFftyfDFHCtwpolao82935";
			this.txtCipher.Text = Utilities.Encrypt(post, key);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0001F7CA File Offset: 0x0001E7CA
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
