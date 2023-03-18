using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for BillboardDrawable.
	/// </summary>
	// Token: 0x0200004F RID: 79
	[Serializable]
	public class BillboardDrawable : Drawable
	{
		// Token: 0x060002FB RID: 763 RVA: 0x00022D08 File Offset: 0x00021D08
		public BillboardDrawable(Point location, string imageName, int avenue, int street, int lot, float reach) : base(location, imageName)
		{
			this.clickString = " ";
			this.Avenue = avenue;
			this.Street = street;
			this.Lot = lot;
			this.Reach = reach;
			base.ToolTipText = A.R.GetString("Reach: {0}   Cost/Wk: {1}", new object[]
			{
				Utilities.FU((int)reach),
				Utilities.FC(AppBuilding.BillboardRentFromReach(reach), A.I.CurrencyConversion)
			});
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00022D8C File Offset: 0x00021D8C
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(A.R.GetString("Do you want to remove this billboard?"), A.R.GetString("Remove Billboard"), MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				try
				{
					A.SA.KillBillboard(A.MF.CurrentEntityID, this.Avenue, this.Street, this.Lot);
					A.MF.UpdateView();
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}

		// Token: 0x04000290 RID: 656
		public int Avenue;

		// Token: 0x04000291 RID: 657
		public int Street;

		// Token: 0x04000292 RID: 658
		public int Lot;

		// Token: 0x04000293 RID: 659
		public float Reach;
	}
}
