using System;
using System.Collections;
using System.Drawing;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Shelf.
	/// </summary>
	// Token: 0x02000029 RID: 41
	[Serializable]
	public class Shelf
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x0000F60C File Offset: 0x0000E60C
		public Shelf(SectionBase parent, int shelfIndex)
		{
			this.Parent = parent;
			this.ID = A.ST.GetNextID();
			this.productOrigin = new PointF((float)(parent.Origin.X + parent.ProdOffsetX), (float)(parent.Origin.Y + parent.ProdOffsetY + shelfIndex * parent.ShelfHeight));
			int x = parent.ShelfOffsetX - 8;
			int y = parent.ShelfOffsetY - 81;
			this.bounds = new Point[]
			{
				new Point(parent.Footprint[0].X + x, parent.Footprint[0].Y + y + shelfIndex * parent.ShelfHeight),
				new Point(parent.Footprint[1].X + x, parent.Footprint[1].Y + y + shelfIndex * parent.ShelfHeight),
				new Point(parent.Footprint[2].X + x, parent.Footprint[2].Y + y + shelfIndex * parent.ShelfHeight),
				new Point(parent.Footprint[3].X + x, parent.Footprint[3].Y + y + shelfIndex * parent.ShelfHeight)
			};
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x0000F7A4 File Offset: 0x0000E7A4
		// (set) Token: 0x060000FA RID: 250 RVA: 0x0000F7BC File Offset: 0x0000E7BC
		public VBRProductType ProductType
		{
			get
			{
				return this.productType;
			}
			set
			{
				this.productType = value;
				if (this.productType.ProductSpacing == -1)
				{
					float prodWidth = (float)this.productType.Width;
					this.productSpacing = prodWidth * 0.8f;
				}
				else
				{
					this.productSpacing = (float)this.productType.ProductSpacing;
				}
				int prodsCanFit = (int)Math.Floor((double)((float)this.Parent.Width / this.productSpacing));
				this.Items = new Item[prodsCanFit];
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000F840 File Offset: 0x0000E840
		public ArrayList GetDrawables()
		{
			ArrayList d = new ArrayList();
			string orientation = "";
			if (this.Parent.dy < 0)
			{
				orientation = "F";
			}
			d.Add(new ShelfDrawable(this.bounds, this.ID, this.Parent.RackType, this.ProductType.Index)
			{
				ToolTipText = A.R.GetString("Space for {0}", new object[]
				{
					this.ProductType.Name
				}),
				Color = Color.FromArgb(0, 255, 0, 0)
			});
			for (int i = 0; i < this.Items.Length; i++)
			{
				if (this.Items[i] != null)
				{
					Item item = this.Items[i];
					PointF loc = new PointF(this.productOrigin.X + (float)i * this.productSpacing, this.productOrigin.Y - (float)(i * this.Parent.dy) * this.productSpacing / 2f);
					d.Add(new ItemDrawable(Point.Round(loc), "Prod" + orientation + this.ProductType.Index, this.ProductType, item.PurchaseDate, item.ExpirationDate, item.PercentExpired, this.ID));
				}
			}
			d.Sort();
			return d;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000F9CC File Offset: 0x0000E9CC
		public bool ContainsAny(ArrayList needs)
		{
			foreach (Item i in this.Items)
			{
				if (i != null && needs.Contains(i.ProductType))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000FD RID: 253 RVA: 0x0000FA20 File Offset: 0x0000EA20
		public bool NearlyEmpty
		{
			get
			{
				float count = 0f;
				foreach (Item i in this.Items)
				{
					if (i != null)
					{
						count += 1f;
					}
				}
				return count / (float)this.Items.Length < 0.33f;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000FE RID: 254 RVA: 0x0000FA84 File Offset: 0x0000EA84
		public int ItemsToStock
		{
			get
			{
				int count = 0;
				foreach (Item i in this.Items)
				{
					if (i == null)
					{
						count++;
					}
				}
				return count;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000FF RID: 255 RVA: 0x0000FAD0 File Offset: 0x0000EAD0
		public int ItemsInStock
		{
			get
			{
				int count = 0;
				foreach (Item i in this.Items)
				{
					if (i != null)
					{
						count++;
					}
				}
				return count;
			}
		}

		// Token: 0x0400011D RID: 285
		protected const float SPACE_BETWEEN_PRODUCTS = -2f;

		// Token: 0x0400011E RID: 286
		public Point[] bounds;

		// Token: 0x0400011F RID: 287
		protected VBRProductType productType;

		// Token: 0x04000120 RID: 288
		public SectionBase Parent;

		// Token: 0x04000121 RID: 289
		protected float productSpacing;

		// Token: 0x04000122 RID: 290
		public Item[] Items = new Item[0];

		// Token: 0x04000123 RID: 291
		public PointF productOrigin;

		// Token: 0x04000124 RID: 292
		public long ID;
	}
}
