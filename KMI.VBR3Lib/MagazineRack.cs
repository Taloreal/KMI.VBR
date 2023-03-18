using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Rack.
	/// </summary>
	// Token: 0x02000024 RID: 36
	[Serializable]
	public class MagazineRack : SectionBase
	{
		// Token: 0x060000EA RID: 234 RVA: 0x0000E34C File Offset: 0x0000D34C
		public MagazineRack(NodeV2 node, int dy) : base(node, dy)
		{
			this.NumShelves = 2;
			this.ProdOffsetX = -11;
			this.ProdOffsetY = -52;
			if (dy == -1)
			{
				this.ProdOffsetX += 38;
			}
			this.ShelfHeight = 37;
			Point[] p = this.shelfFootprint;
			if (dy == -1)
			{
				this.shelfFootprint[0] = new Point(p[0].X, p[0].Y + 16);
				this.shelfFootprint[1] = new Point(p[1].X, p[1].Y + 16);
			}
			else
			{
				this.shelfFootprint[0] = new Point(p[0].X, p[0].Y + 16);
				this.shelfFootprint[3] = new Point(p[3].X, p[3].Y + 16);
			}
			base.CreateShelves();
			base.ReOrient();
			this.ImageName = "Magazine";
			this.RackType = "Magazine Rack";
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000E4A0 File Offset: 0x0000D4A0
		public override ArrayList GetDrawables()
		{
			ArrayList d = new ArrayList();
			FlexDrawable rack = new FlexDrawable(this.Origin, this.ImageName);
			if (this.dy == -1)
			{
				rack.Flip = true;
			}
			d.Add(rack);
			for (int i = this.Shelves.Length - 1; i >= 0; i--)
			{
				d.AddRange(this.Shelves[i].GetDrawables());
				PointF p = new PointF((float)(this.Origin.X + this.ShelfOffsetX), (float)(this.Origin.Y + this.ShelfOffsetY + (i - 1) * this.ShelfHeight));
				if (i > 0)
				{
					d.Add(new FlexDrawable(p, this.ImageName + "Shelf")
					{
						Flip = rack.Flip
					});
				}
			}
			return base.WrapInCompoundDrawable(this.Origin, d);
		}
	}
}
