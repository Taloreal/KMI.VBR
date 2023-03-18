using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200006C RID: 108
	public partial class frmMultiplayerRole : Form
	{
		// Token: 0x060003F3 RID: 1011 RVA: 0x0001D3A0 File Offset: 0x0001C3A0
		public frmMultiplayerRole()
		{
			this.InitializeComponent();
			foreach (MultiplayerRole multiplayerRole in MultiplayerRole.Roles)
			{
				this.lstRoles.Items.Add(multiplayerRole.RoleName);
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0001D628 File Offset: 0x0001C628
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.lstRoles.SelectedIndex == -1)
			{
				MessageBox.Show(S.R.GetString("You must select a role to play in the sim."), S.R.GetString("Please Retry"));
			}
			else
			{
				this.RoleName = this.lstRoles.SelectedItem.ToString();
				base.Close();
			}
		}

		// Token: 0x040002B3 RID: 691
		public string RoleName;
	}
}
