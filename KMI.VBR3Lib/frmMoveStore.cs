using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmOpenNewStore.
	/// </summary>
	// Token: 0x02000015 RID: 21
	public partial class frmMoveStore : Form, IActionForm
	{
		// Token: 0x06000093 RID: 147 RVA: 0x000095A0 File Offset: 0x000085A0
		public frmMoveStore()
		{
			this.InitializeComponent();
			this.label2.Text = A.R.GetString(this.label2.Text, new object[]
			{
				Utilities.FC(25000f, A.I.CurrencyConversion)
			});
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00009640 File Offset: 0x00008640
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00009658 File Offset: 0x00008658
		public BuildingDrawable SelectedBuilding
		{
			get
			{
				return this.selectedBuilding;
			}
			set
			{
				this.selectedBuilding = value;
				float rent = AppBuilding.RentFromReach(this.selectedBuilding.Reach);
				this.labRent.Text = Utilities.FC(rent, A.I.CurrencyConversion);
				this.labMonthlyRent.Text = Utilities.FC(rent * 4f, A.I.CurrencyConversion);
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00009C44 File Offset: 0x00008C44
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.selectedBuilding == null)
			{
				string message = A.R.GetString("You must select a store location first.  Click on any available store.");
				string title = A.R.GetString("No Store Selected");
				MessageBox.Show(message, title);
			}
			else
			{
				try
				{
					A.SA.MoveEntity(A.MF.CurrentEntityID, this.selectedBuilding.Avenue, this.selectedBuilding.Street, this.selectedBuilding.Lot);
					A.MF.BringToFront();
					A.MF.UpdateView();
					base.Close();
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex, this);
				}
				if (A.MF.SoundOn)
				{
					Sound.PlaySoundFromFile("sounds\\Build.wav");
				}
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00009D24 File Offset: 0x00008D24
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00009D2E File Offset: 0x00008D2E
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00009D3D File Offset: 0x00008D3D
		private void frmOpenNewStore_Closed(object sender, EventArgs e)
		{
			((CityView)A.I.Views[0]).Mode = CityView.Modes.Default;
		}

		// Token: 0x0400008B RID: 139
		protected BuildingDrawable selectedBuilding;
	}
}
