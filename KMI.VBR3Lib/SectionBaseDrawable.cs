using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for SectionBaseDrawable.
	/// </summary>
	// Token: 0x02000043 RID: 67
	[Serializable]
	public class SectionBaseDrawable : PolygonDrawable
	{
		// Token: 0x06000203 RID: 515 RVA: 0x0001E1F0 File Offset: 0x0001D1F0
		public SectionBaseDrawable(Point[] footprint, string nodeName, string clickString) : base(footprint, clickString)
		{
			this.Footprint = footprint;
			this.NodeName = nodeName;
			this.clickString = " ";
			base.ToolTipText = A.R.GetString("Space for Fixture");
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0001E22C File Offset: 0x0001D22C
		public override void DrawSelected(Graphics g)
		{
			Pen pen = new Pen(Color.Gold, 2f);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			pen.DashStyle = DashStyle.Dash;
			g.DrawPolygon(pen, this.Footprint);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0001E268 File Offset: 0x0001D268
		public override void Draw(Graphics g)
		{
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0001E26C File Offset: 0x0001D26C
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (A.MF.mnuActionsMerchandising.Enabled)
			{
				PictureBox p = (PictureBox)sender;
				ContextMenu i = new ContextMenu();
				foreach (VBRProductType pt in AppConstants.ProductTypes)
				{
					MenuItem itm = new MenuItem(pt.Name, new EventHandler(this.AssignProduct));
					if (pt.Name == "Eggs" || pt.Name == "Whipped Cream")
					{
						i.MenuItems.Add(2, itm);
					}
					else
					{
						i.MenuItems.Add(itm);
					}
				}
				i.Show(p, this.location);
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0001E340 File Offset: 0x0001D340
		private void AssignProduct(object sender, EventArgs e)
		{
			try
			{
				VBRProductType pt = null;
				MenuItem i = (MenuItem)sender;
				foreach (VBRProductType p in AppConstants.ProductTypes)
				{
					if (i.Text == p.Name)
					{
						pt = p;
					}
				}
				if (MessageBox.Show(A.R.GetString("This product requires a {0} which leases for {1} per week. OK to lease?", new object[]
				{
					pt.RackType,
					Utilities.FC(SectionBase.RentForRackType(pt.RackType), A.I.CurrencyConversion)
				}), A.R.GetString("Change Fixture"), MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					A.SA.ReassignShelf(A.MF.CurrentEntityID, this.NodeName, -1L, pt.Index);
					KMI.Sim.View.ClearCurrentHit();
					A.MF.UpdateView();
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x040001FE RID: 510
		public Point[] Footprint;

		// Token: 0x040001FF RID: 511
		public string NodeName;
	}
}
