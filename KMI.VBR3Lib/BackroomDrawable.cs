using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz.Product;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for BackroomDrawable.
	/// </summary>
	// Token: 0x02000034 RID: 52
	[Serializable]
	public class BackroomDrawable : FlexDrawable, IPctExpired
	{
		// Token: 0x0600016B RID: 363 RVA: 0x000142C6 File Offset: 0x000132C6
		public BackroomDrawable(Point location, string imageName, int product, float pctExpired) : base(location, imageName)
		{
			this.percentExpired = pctExpired;
			this.clickString = " ";
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000142E8 File Offset: 0x000132E8
		public float PercentExpired()
		{
			return this.percentExpired;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00014300 File Offset: 0x00013300
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (!A.MF.mnuActionsPurchasing.Enabled)
			{
				MessageBox.Show("You can't change Purchasing for this store.");
			}
			else
			{
				try
				{
					Form f = new frmPurchasing(AppConstants.ProductTypes, -1, 25000);
					f.ShowDialog(A.MF);
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}

		// Token: 0x04000148 RID: 328
		protected float percentExpired;
	}
}
