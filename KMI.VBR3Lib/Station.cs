using System;
using System.Collections;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Rack.
	/// </summary>
	// Token: 0x0200000F RID: 15
	[Serializable]
	public class Station : SectionBase
	{
		// Token: 0x06000078 RID: 120 RVA: 0x000078F0 File Offset: 0x000068F0
		public Station(NodeV2 node, int dy) : base(node, dy)
		{
			base.CreateShelves();
			base.ReOrient();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000790C File Offset: 0x0000690C
		public override ArrayList GetDrawables()
		{
			ArrayList d = new ArrayList();
			Shelf s = this.Shelves[0];
			int full = (int)Math.Ceiling((double)((float)(5 * s.ItemsInStock) / (float)s.Items.Length));
			if (full == 5)
			{
				full--;
			}
			StationDrawable rack = new StationDrawable(this.Origin, this.ImageName + full, base.OldestPctExpired());
			rack.ToolTipText = s.Parent.RackType;
			rack.ShelfDrawable = new ShelfDrawable(s.bounds, s.ID, s.Parent.RackType, s.ProductType.Index)
			{
				Hittable = false
			};
			if (this.dy == -1)
			{
				rack.Flip = true;
			}
			d.Add(rack);
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
