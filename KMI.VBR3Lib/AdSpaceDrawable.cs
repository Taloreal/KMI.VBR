using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for SectionBaseDrawable.
	/// </summary>
	// Token: 0x02000035 RID: 53
	[Serializable]
	public class AdSpaceDrawable : PolygonDrawable
	{
		// Token: 0x0600016E RID: 366 RVA: 0x00014370 File Offset: 0x00013370
		public AdSpaceDrawable(Point[] footprint, int index, string clickString) : base(footprint, clickString)
		{
			this.Footprint = footprint;
			this.index = index;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0001438C File Offset: 0x0001338C
		public override void DrawSelected(Graphics g)
		{
			Pen pen = new Pen(Color.Black, 2f);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			pen.DashStyle = DashStyle.Dash;
			g.DrawPolygon(pen, this.Footprint);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000143C8 File Offset: 0x000133C8
		public override void Draw(Graphics g)
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000143CC File Offset: 0x000133CC
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (A.MF.mnuActionsPromotionStorefrontAds.Enabled)
			{
				try
				{
					Form f = new frmAdDesignerSimple(AppConstants.ProductTypes, this.index);
					f.ShowDialog(A.MF);
					A.MF.UpdateView();
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}

		// Token: 0x04000149 RID: 329
		public Point[] Footprint;

		// Token: 0x0400014A RID: 330
		public int index;
	}
}
