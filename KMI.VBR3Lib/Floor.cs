using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.Product;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Floor.
	/// </summary>
	// Token: 0x0200002B RID: 43
	[Serializable]
	public class Floor
	{
		// Token: 0x06000102 RID: 258 RVA: 0x0000FDE4 File Offset: 0x0000EDE4
		public Floor(AppEntity parent)
		{
			this.Map = new MapV2();
			this.Map.load(typeof(Floor).Assembly, "KMI.VBR3Lib.Data.FloorMap.xml");
			for (int i = 0; i < 13; i++)
			{
				int dy = 1;
				if (i >= 9)
				{
					dy = -1;
				}
				NodeV2 node = this.Map.getNode("S" + i);
				SectionBase sb = new SectionBase(node, dy);
				this.Sections.Add(node.name, sb);
			}
			this.Parent = parent;
			if (parent.AI)
			{
				this.AutoLayout();
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000FED0 File Offset: 0x0000EED0
		public void AutoLayout()
		{
			ArrayList prods = new ArrayList(AppConstants.ProductTypes);
			for (int i = 0; i < 13; i++)
			{
				VBRProductType pt;
				if (prods.Count > 0)
				{
					int j = A.ST.Random.Next(prods.Count);
					pt = (VBRProductType)prods[j];
					prods.RemoveAt(j);
				}
				else
				{
					pt = AppConstants.ProductTypes[A.ST.Random.Next(AppConstants.ProductTypes.Length)];
				}
				SectionBase sb = (SectionBase)this.Sections["S" + i];
				sb = ((AppFactory)A.I.SimFactory).CreateSection(pt, sb);
				this.Sections["S" + i] = sb;
				sb.Shelves[0].ProductType = pt;
				for (int s = 1; s < sb.Shelves.Length; s++)
				{
					sb.Shelves[s].ProductType = this.GetCompatibleProductType(pt, prods);
				}
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00010004 File Offset: 0x0000F004
		public VBRProductType GetCompatibleProductType(VBRProductType p, ArrayList prods)
		{
			if (prods.Count > 0)
			{
				ArrayList temp = new ArrayList(prods);
				Utilities.Shuffle(temp, A.ST.Random);
				foreach (object obj in temp)
				{
					VBRProductType pt = (VBRProductType)obj;
					if (pt.RackType == p.RackType)
					{
						prods.Remove(pt);
						return pt;
					}
				}
			}
			ArrayList temp2 = new ArrayList(AppConstants.ProductTypes);
			Utilities.Shuffle(temp2, A.ST.Random);
			foreach (object obj2 in temp2)
			{
				VBRProductType pt = (VBRProductType)obj2;
				if (pt.RackType == p.RackType)
				{
					return pt;
				}
			}
			return null;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00010154 File Offset: 0x0000F154
		public ArrayList GetDrawables()
		{
			ArrayList d = new ArrayList();
			foreach (object obj in this.Sections.Values)
			{
				SectionBase sb = (SectionBase)obj;
				d.AddRange(sb.GetDrawables());
			}
			foreach (object obj2 in this.Parent.Customers)
			{
				Customer c = (Customer)obj2;
				d.AddRange(c.GetDrawables());
			}
			foreach (object obj3 in this.Parent.ShelfStockers)
			{
				ShelfStocker ss = (ShelfStocker)obj3;
				d.AddRange(ss.GetDrawables());
			}
			foreach (object obj4 in this.Parent.Cashiers)
			{
				Cashier c2 = (Cashier)obj4;
				d.AddRange(c2.GetDrawables());
			}
			foreach (object obj5 in this.Repairmen)
			{
				Repairman r = (Repairman)obj5;
				d.AddRange(r.GetDrawables());
			}
			d.Sort();
			ArrayList behindCounter = new ArrayList();
			ArrayList frontCounter = new ArrayList();
			ArrayList outside = new ArrayList();
			foreach (object obj6 in d)
			{
				Drawable dr = (Drawable)obj6;
				if (dr.Location.Y > -dr.Location.X / 2 + 642)
				{
					outside.Add(dr);
				}
				else if (dr.Location.Y > dr.Location.X / 2 - 12)
				{
					frontCounter.Add(dr);
				}
				else
				{
					behindCounter.Add(dr);
				}
			}
			ArrayList final = new ArrayList(behindCounter);
			Point c3 = this.Map.getNode("C0").Location;
			final.Add(new Drawable(new Point(c3.X - 4, c3.Y - 85), "Counter"));
			final.Add(new TextDrawable(new Point(c3.X + 101, c3.Y - 15), this.Parent.Name, "Arial", 14, Color.Purple, -0.5f)
			{
				Center = true
			});
			for (int i = 0; i < this.Parent.Registers; i++)
			{
				Point regloc = this.Parent.RegisterLocation(i);
				final.Add(new Drawable(new Point(regloc.X - 49, regloc.Y - 69), "CashRegister"));
			}
			final.AddRange(frontCounter);
			final.Add(new Drawable(new Point(6, 188), "Windows")
			{
				Hittable = false
			});
			AppEntity e = this.Parent;
			for (int i = 0; i < AdSimple.MaxAds; i++)
			{
				if (this.Ads[i] == null)
				{
					Point p = this.Map.getNode("A" + i).Location;
					final.Add(new AdSpaceDrawable(this.AdSpaceOutline(new Point(p.X - 40, p.Y - 10)), i, " "));
				}
				else
				{
					this.Ads[i].Price = e.GetPriceWithDiscount(this.Ads[i].ProductIndex);
					final.Add(this.Ads[i]);
				}
			}
			for (int i = 0; i < 5; i++)
			{
				string img = "Camera";
				if (!this.Cameras[i])
				{
					img += "Mount";
				}
				if (i >= 4)
				{
					img += "SE";
				}
				final.Add(new CamMountDrawable(this.Map.getNode("Cam" + i).Location, img, i, this.Cameras[i]));
			}
			ArrayList comments = new ArrayList();
			foreach (object obj7 in this.Parent.Customers)
			{
				Customer c = (Customer)obj7;
				CommentDrawable cd = c.GetCommentDrawable();
				if (cd != null)
				{
					comments.Add(cd);
				}
			}
			foreach (object obj8 in this.Parent.ShelfStockers)
			{
				ShelfStocker c4 = (ShelfStocker)obj8;
				CommentDrawable cd = c4.GetCommentDrawable();
				if (cd != null)
				{
					comments.Add(cd);
				}
			}
			comments.Sort();
			final.AddRange(comments);
			final.AddRange(outside);
			return final;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0001081C File Offset: 0x0000F81C
		protected Point[] AdSpaceOutline(Point Anchor)
		{
			int Width = 40;
			int Height = 60;
			return new Point[]
			{
				Anchor,
				new Point(Anchor.X, Anchor.Y - Height),
				new Point(Anchor.X + Width, Anchor.Y - Width / 2 - Height),
				new Point(Anchor.X + Width, Anchor.Y - Width / 2)
			};
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000108C0 File Offset: 0x0000F8C0
		public Shelf FindStocking(ShelfStocker stocker)
		{
			ArrayList nearlyEmptyShelves = new ArrayList();
			ArrayList productOutages = new ArrayList();
			foreach (object obj in this.AllShelves)
			{
				Shelf shelf = (Shelf)obj;
				if (shelf.NearlyEmpty && !this.ShelfAssigned(shelf))
				{
					if (this.Parent.Backroom.GetUnitCount(shelf.ProductType) > 0)
					{
						nearlyEmptyShelves.Add(shelf);
					}
					else if ((A.ST.Now - A.SS.StartDate).Days > 2)
					{
						productOutages.Add(shelf.ProductType.Name);
					}
				}
			}
			return (Shelf)Utilities.PickRandom(nearlyEmptyShelves, A.ST.Random);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000109DC File Offset: 0x0000F9DC
		public Shelf FindExpired(ShelfStocker stocker)
		{
			ArrayList shelvesWithExpired = new ArrayList();
			foreach (object obj in this.AllShelves)
			{
				Shelf shelf = (Shelf)obj;
				if (!this.ShelfAssigned(shelf))
				{
					foreach (Item item in shelf.Items)
					{
						if (item != null && item.IsExpired)
						{
							shelvesWithExpired.Add(shelf);
						}
					}
				}
			}
			return (Shelf)Utilities.PickRandom(shelvesWithExpired, A.ST.Random);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00010AB8 File Offset: 0x0000FAB8
		protected bool ShelfAssigned(Shelf shelf)
		{
			foreach (object obj in this.Parent.ShelfStockers)
			{
				ShelfStocker s = (ShelfStocker)obj;
				if (s.TargetShelf == shelf)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00010B38 File Offset: 0x0000FB38
		public static PointF TileToScreen(float x, float y)
		{
			return new PointF(382f + 19.2f * x - 19.2f * y, 567f - 9.6f * x - 9.6f * y);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00010B7C File Offset: 0x0000FB7C
		public static PointF TileToScreen(PointF p)
		{
			return Floor.TileToScreen(p.X, p.Y);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00010BA4 File Offset: 0x0000FBA4
		public int GetUnitCount(ProductType prod)
		{
			int total = 0;
			foreach (object obj in this.AllShelves)
			{
				Shelf sh = (Shelf)obj;
				if (sh.ProductType.Index == prod.Index)
				{
					foreach (Item item in sh.Items)
					{
						if (item != null)
						{
							total++;
						}
					}
				}
			}
			foreach (object obj2 in this.Parent.ShelfStockers)
			{
				ShelfStocker stocker = (ShelfStocker)obj2;
				foreach (object obj3 in stocker.Carrying)
				{
					Item item = (Item)obj3;
					if (item.ProductType.Index == prod.Index)
					{
						total++;
					}
				}
			}
			foreach (object obj4 in this.Parent.Customers)
			{
				Customer c = (Customer)obj4;
				if (c.State != Customer.States.Exit)
				{
					foreach (object obj5 in c.Items)
					{
						Item item = (Item)obj5;
						if (item.ProductType.Index == prod.Index)
						{
							total++;
						}
					}
				}
			}
			return total;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00010E28 File Offset: 0x0000FE28
		public ArrayList AllShelves
		{
			get
			{
				ArrayList shelves = new ArrayList();
				foreach (object obj in this.Sections.Values)
				{
					SectionBase sb = (SectionBase)obj;
					if (sb.Shelves != null)
					{
						shelves.AddRange(sb.Shelves);
					}
				}
				return shelves;
			}
		}

		// Token: 0x04000125 RID: 293
		public const float TileWidth = 19.2f;

		// Token: 0x04000126 RID: 294
		public const float CashierSpacing = 3f;

		// Token: 0x04000127 RID: 295
		public MapV2 Map;

		// Token: 0x04000128 RID: 296
		public Hashtable Sections = new Hashtable();

		// Token: 0x04000129 RID: 297
		public AdSimple[] Ads = new AdSimple[Ad.MaxAds];

		// Token: 0x0400012A RID: 298
		public bool[] Cameras = new bool[5];

		// Token: 0x0400012B RID: 299
		public AppEntity Parent;

		// Token: 0x0400012C RID: 300
		public ArrayList Repairmen = new ArrayList();
	}
}
