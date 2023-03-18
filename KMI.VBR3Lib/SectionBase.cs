using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Section.
	/// </summary>
	// Token: 0x02000002 RID: 2
	[Serializable]
	public class SectionBase
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public SectionBase(NodeV2 node, int dy)
		{
			this.node = node;
			this.dy = dy;
			if (dy == -1)
			{
				this.Origin = new Point(node.x - 11, node.y - 33);
				this.Footprint = new Point[]
				{
					this.Origin,
					new Point(this.Origin.X + this.Width, this.Origin.Y + this.Width / 2),
					new Point(this.Origin.X + this.Width + this.Depth, this.Origin.Y + this.Width / 2 - this.Depth / 2),
					new Point(this.Origin.X + this.Depth, this.Origin.Y - this.Depth / 2)
				};
				this.shelfFootprint = this.Footprint;
				this.shelfFootprint[0] = new Point(this.Origin.X + 16, this.Origin.Y - 8);
				this.shelfFootprint[1] = new Point(this.Origin.X + this.Width + 16, this.Origin.Y + this.Width / 2 - 8);
				this.shelfFootprint[2] = new Point(this.Origin.X + this.Width + this.Depth + 8, this.Origin.Y + this.Width / 2 - this.Depth / 2 - 4);
				this.shelfFootprint[3] = new Point(this.Origin.X + this.Depth + 8, this.Origin.Y - this.Depth / 2 - 4);
			}
			else
			{
				this.Origin = new Point(node.x - 30, node.y + 1);
				this.Footprint = new Point[]
				{
					this.Origin,
					new Point(this.Origin.X - this.Depth, this.Origin.Y - this.Depth / 2),
					new Point(this.Origin.X + this.Width - this.Depth, this.Origin.Y - this.Width / 2 - this.Depth / 2),
					new Point(this.Origin.X + this.Width, this.Origin.Y - this.Width / 2)
				};
				this.shelfFootprint = this.Footprint;
				this.shelfFootprint[0] = new Point(this.Origin.X - 8, this.Origin.Y - 4);
				this.shelfFootprint[3] = new Point(this.Origin.X + this.Width - 8, this.Origin.Y - this.Width / 2 - 4);
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002450 File Offset: 0x00001450
		public float Rent
		{
			get
			{
				return SectionBase.RentForRackType(this.RackType);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002470 File Offset: 0x00001470
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002488 File Offset: 0x00001488
		public bool Broken
		{
			get
			{
				return this.broken;
			}
			set
			{
				this.broken = value;
				if (this.broken)
				{
					this.dateBroken = A.ST.Now;
				}
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000024BC File Offset: 0x000014BC
		public DateTime DateBroken
		{
			get
			{
				return this.dateBroken;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000024D4 File Offset: 0x000014D4
		public virtual bool ContainsAny(ArrayList needs)
		{
			foreach (Shelf s in this.Shelves)
			{
				if (s.ContainsAny(needs))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000251C File Offset: 0x0000151C
		public virtual ArrayList GetDrawables()
		{
			return new ArrayList
			{
				new SectionBaseDrawable(this.Footprint, this.node.name, " ")
			};
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002558 File Offset: 0x00001558
		public void ReOrient()
		{
			if (this.dy == 1)
			{
				this.Origin = new Point(this.node.x - 66, this.node.y - 133);
			}
			else
			{
				this.Origin = new Point(this.node.x - 7, this.node.y - 131);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000025CC File Offset: 0x000015CC
		public void CreateShelves()
		{
			this.Shelves = new Shelf[this.NumShelves];
			for (int i = 0; i < this.Shelves.Length; i++)
			{
				this.Shelves[i] = new Shelf(this, i);
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002614 File Offset: 0x00001614
		public ArrayList WrapInCompoundDrawable(Point p, ArrayList d)
		{
			CompoundDrawable cd = new CompoundDrawable(new Point(p.X + 55, p.Y + 100), d, "");
			cd.ForwardClick = true;
			return new ArrayList
			{
				cd
			};
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002664 File Offset: 0x00001664
		public float OldestPctExpired()
		{
			float pct = -1f;
			foreach (Shelf s in this.Shelves)
			{
				foreach (Item i in s.Items)
				{
					if (i != null && i.PercentExpired > pct)
					{
						pct = i.PercentExpired;
					}
				}
			}
			return pct;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000026EC File Offset: 0x000016EC
		public static float RentForRackType(string rackType)
		{
			if (rackType != null)
			{
				if (rackType == "Shelf Rack")
				{
					return 20f;
				}
				if (rackType == "Magazine Rack")
				{
					return 25f;
				}
				if (rackType == "Donut Station")
				{
					return 30f;
				}
				if (rackType == "Refrigeration Unit")
				{
					return 40f;
				}
				if (rackType == "Coffee Station")
				{
					return 45f;
				}
				if (rackType == "Slushy Machine")
				{
					return 50f;
				}
			}
			return 0f;
		}

		// Token: 0x04000001 RID: 1
		public int dy;

		// Token: 0x04000002 RID: 2
		public Point[] Footprint;

		// Token: 0x04000003 RID: 3
		public Point[] shelfFootprint;

		// Token: 0x04000004 RID: 4
		public NodeV2 node;

		// Token: 0x04000005 RID: 5
		public Point Origin;

		// Token: 0x04000006 RID: 6
		public int Width = 80;

		// Token: 0x04000007 RID: 7
		public int Depth = 30;

		// Token: 0x04000008 RID: 8
		public Shelf[] Shelves = new Shelf[0];

		// Token: 0x04000009 RID: 9
		public int ShelfHeight = 22;

		// Token: 0x0400000A RID: 10
		public int ProdOffsetX = -14;

		// Token: 0x0400000B RID: 11
		public int ProdOffsetY = -68;

		// Token: 0x0400000C RID: 12
		public int ShelfOffsetX = 3;

		// Token: 0x0400000D RID: 13
		public int ShelfOffsetY = 18;

		// Token: 0x0400000E RID: 14
		public string ImageName;

		// Token: 0x0400000F RID: 15
		public float LikelihoodOfBreakingPerHour = 0f;

		// Token: 0x04000010 RID: 16
		public bool broken;

		// Token: 0x04000011 RID: 17
		public DateTime dateBroken;

		// Token: 0x04000012 RID: 18
		public int NumShelves = 1;

		// Token: 0x04000013 RID: 19
		public string RackType;
	}
}
