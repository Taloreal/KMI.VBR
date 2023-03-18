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
	// Token: 0x02000012 RID: 18
	[Serializable]
	public class CamMountDrawable : Drawable
	{
		// Token: 0x06000084 RID: 132 RVA: 0x0000837C File Offset: 0x0000737C
		public CamMountDrawable(Point location, string imageName, int index, bool installed) : base(location, imageName)
		{
			this.clickString = " ";
			this.Installed = installed;
			this.Index = index;
			base.ToolTipText = A.R.GetString("Security Camera");
			if (!installed)
			{
				base.ToolTipText = base.ToolTipText + " " + A.R.GetString("Mount");
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000083F0 File Offset: 0x000073F0
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (A.MF.mnuActionsEquipment.Enabled)
			{
				string msg = A.R.GetString("Security cameras cost {0} per week. Add camera?", new object[]
				{
					Utilities.FC(25f, A.I.CurrencyConversion)
				});
				if (this.Installed)
				{
					msg = A.R.GetString("Remove camera?");
				}
				if (MessageBox.Show(msg, A.R.GetString("Add Camera"), MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					try
					{
						A.SA.SetCamera(A.MF.CurrentEntityID, this.Index, !this.Installed);
						A.MF.UpdateView();
					}
					catch (Exception ex)
					{
						frmExceptionHandler.Handle(ex);
					}
				}
			}
		}

		// Token: 0x0400007B RID: 123
		public int Index;

		// Token: 0x0400007C RID: 124
		public bool Installed;
	}
}
