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
	// Token: 0x0200002A RID: 42
	[Serializable]
	public class Fridge : SectionBase
	{
		// Token: 0x06000100 RID: 256 RVA: 0x0000FB18 File Offset: 0x0000EB18
		public Fridge(NodeV2 node, int dy) : base(node, dy)
		{
			this.NumShelves = 2;
			this.ShelfOffsetX = 5;
			this.ShelfOffsetY = 38;
			this.ProdOffsetX = -12;
			this.ProdOffsetY = -50;
			if (dy == -1)
			{
				this.ProdOffsetX += 40;
				this.ProdOffsetY += 3;
			}
			base.CreateShelves();
			base.ReOrient();
			this.ImageName = "Fridge";
			this.RackType = "Refrigeration Unit";
			this.LikelihoodOfBreakingPerHour = 6E-05f;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000FBB0 File Offset: 0x0000EBB0
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
			FlexDrawable side = new FlexDrawable(this.Origin, this.ImageName + "Side");
			FlexDrawable front = new FlexDrawable(this.Origin, this.ImageName + "Front");
			FlexDrawable top = new FlexDrawable(this.Origin, this.ImageName + "Top");
			side.Flip = rack.Flip;
			side.Hittable = false;
			front.Flip = rack.Flip;
			front.Hittable = false;
			top.Flip = rack.Flip;
			top.Hittable = false;
			d.Add(side);
			d.Add(front);
			d.Add(top);
			if (base.Broken)
			{
				d.Add(new FlexDrawable(this.Origin, this.ImageName + "Broken" + A.ST.FrameCounter / 5 % 2, "")
				{
					Flip = rack.Flip,
					Hittable = false
				});
			}
			return base.WrapInCompoundDrawable(this.Origin, d);
		}
	}
}
