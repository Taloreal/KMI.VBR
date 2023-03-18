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
	// Token: 0x02000003 RID: 3
	[Serializable]
	public class Rack : SectionBase
	{
		// Token: 0x0600000D RID: 13 RVA: 0x0000278C File Offset: 0x0000178C
		public Rack(NodeV2 node, int dy) : base(node, dy)
		{
			this.NumShelves = 3;
			if (dy == -1)
			{
				this.ProdOffsetX += 36;
			}
			base.CreateShelves();
			base.ReOrient();
			this.ImageName = "Rack";
			this.RackType = "Shelf Rack";
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000027EC File Offset: 0x000017EC
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
						Flip = rack.Flip,
						Hittable = false
					});
				}
			}
			return base.WrapInCompoundDrawable(this.Origin, d);
		}
	}
}
