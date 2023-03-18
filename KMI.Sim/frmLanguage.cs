using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000073 RID: 115
	public partial class frmLanguage : Form
	{
		// Token: 0x0600042B RID: 1067 RVA: 0x0001E4A8 File Offset: 0x0001D4A8
		public frmLanguage()
		{
			this.InitializeComponent();
			AppSettingsReader appSettingsReader = new AppSettingsReader();
			this.preferredLanguageCode = (string)appSettingsReader.GetValue("PreferredLanguageCode", typeof(string));
			this.languageNames = ((string)appSettingsReader.GetValue("SupportedLanguageNames", typeof(string))).Split(new char[]
			{
				'|'
			});
			this.languageCodes = ((string)appSettingsReader.GetValue("SupportedLanguageCodes", typeof(string))).Split(new char[]
			{
				'|'
			});
			this.lstLanguages.Items.Add("English");
			for (int i = 0; i < this.languageNames.Length; i++)
			{
				this.lstLanguages.Items.Add(this.languageNames[i]);
				if (this.preferredLanguageCode == this.languageCodes[i])
				{
					this.lstLanguages.SelectedIndex = this.lstLanguages.Items.Count - 1;
				}
			}
			if (this.lstLanguages.SelectedIndex == -1)
			{
				this.lstLanguages.SelectedIndex = 0;
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0001E7B4 File Offset: 0x0001D7B4
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x0001E7C0 File Offset: 0x0001D7C0
		public int LanguageCount
		{
			get
			{
				int result;
				if (this.languageCodes[0] == "")
				{
					result = 0;
				}
				else
				{
					result = this.languageCodes.Length;
				}
				return result;
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0001E7F8 File Offset: 0x0001D7F8
		private void frmLanguage_Closed(object sender, EventArgs e)
		{
			if (this.lstLanguages.SelectedIndex > 0)
			{
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.languageCodes[this.lstLanguages.SelectedIndex - 1]);
			}
		}

		// Token: 0x040002C6 RID: 710
		private string preferredLanguageCode;

		// Token: 0x040002C7 RID: 711
		private string[] languageNames;

		// Token: 0x040002C8 RID: 712
		private string[] languageCodes;
	}
}
