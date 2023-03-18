using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KMI.Sim.Academics
{
	// Token: 0x0200005E RID: 94
	public partial class frmChooseMathPack : Form
	{
		// Token: 0x0600036D RID: 877 RVA: 0x00019988 File Offset: 0x00018988
		public frmChooseMathPack()
		{
			this.InitializeComponent();
			this.pageBankNames = Directory.GetDirectories(Application.StartupPath + Path.DirectorySeparatorChar + "MathPaks");
			foreach (string text in this.pageBankNames)
			{
				int num = text.LastIndexOf(Path.DirectorySeparatorChar);
				string item = text.Substring(num + 1, text.Length - num - 1);
				this.lstPaks.Items.Add(item);
			}
			if (this.lstPaks.Items.Count == 0)
			{
				MessageBox.Show("No math paks found. Cannot continue.", "Missing Math Paks");
				Application.Exit();
			}
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00019DF0 File Offset: 0x00018DF0
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.lstPaks.SelectedIndex == -1)
			{
				MessageBox.Show("Please choose a Math Pak", "Input Required");
			}
			else
			{
				AcademicGod.PageBankPath = this.pageBankNames[this.lstPaks.SelectedIndex];
				base.Close();
			}
		}

		// Token: 0x04000239 RID: 569
		private string[] pageBankNames;
	}
}
