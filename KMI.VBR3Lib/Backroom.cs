using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.Product;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Backroom of a store.
	/// </summary>
	// Token: 0x0200002D RID: 45
	[Serializable]
	public class Backroom
	{
		// Token: 0x06000115 RID: 277 RVA: 0x000113E8 File Offset: 0x000103E8
		public Backroom(AppEntity parent)
		{
			this.parent = parent;
			for (int i = 0; i < this.products.Length; i++)
			{
				this.products[i] = new ArrayList();
			}
			this.Map = new MapV2();
			this.Map.load(typeof(Floor).Assembly, "KMI.VBR3Lib.Data.BackroomMap.xml");
			this.CoolingDuct = new CoolingDuct(this.Map.getNode("CD"), 1);
		}

		/// <summary>
		/// Gets total number of units of given product in backroom
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000116 RID: 278 RVA: 0x00011490 File Offset: 0x00010490
		public int GetUnitCount(ProductType prod)
		{
			return this.products[prod.Index].Count;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000114B4 File Offset: 0x000104B4
		public Item TakeItemOfType(ProductType prod)
		{
			int i = prod.Index;
			Item result;
			if (this.GetUnitCount(prod) > 0)
			{
				Item item = (Item)this.products[i][0];
				this.products[i].RemoveAt(0);
				result = item;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00011507 File Offset: 0x00010507
		public void Restock(Item item)
		{
			this.products[item.ProductType.Index].Insert(0, item);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00011524 File Offset: 0x00010524
		public void Stock(ProductType pt, int count)
		{
			for (int i = 0; i < count; i++)
			{
				this.products[pt.Index].Add(new Item(pt));
			}
		}

		/// <summary>
		/// Throw away all items of given product from the backroom
		/// </summary>
		// Token: 0x0600011A RID: 282 RVA: 0x0001155C File Offset: 0x0001055C
		public void ThrowAwayAll(int productIndex)
		{
			ArrayList i = this.products[productIndex];
			foreach (object obj in i)
			{
				Item item = (Item)obj;
				item.ThrowOut(this.parent);
			}
			i.Clear();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000115D4 File Offset: 0x000105D4
		public void ExpireAll()
		{
			foreach (ArrayList i in this.products)
			{
				foreach (object obj in i)
				{
					Item item = (Item)obj;
					if (((VBRProductType)item.ProductType).RackType == A.R.GetString("Refrigeration Unit"))
					{
						item.ExpirationDate = DateTime.MinValue;
					}
				}
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00011698 File Offset: 0x00010698
		public bool Full
		{
			get
			{
				float z = 0f;
				int loc = 0;
				foreach (VBRProductType p in AppConstants.ProductTypes)
				{
					int nCrates = (int)Math.Ceiling((double)((float)this.products[p.Index].Count / (float)p.ItemsPerCase));
					for (int i = 0; i < nCrates; i++)
					{
						if (z + p.CaseHeight > 5f)
						{
							z = 0f;
							loc++;
							if (loc >= 24)
							{
								return true;
							}
						}
						z += p.CaseHeight;
					}
				}
				return false;
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00011760 File Offset: 0x00010760
		public ArrayList GetDrawables()
		{
			int colSpacing = 91;
			int rowSpacing = 46;
			int zSpacing = 20;
			int baseX = 430;
			int baseY = 190;
			ArrayList d = new ArrayList();
			for (int i = 0; i < 3; i++)
			{
				if (this.CoolingDuct.Broken)
				{
					d.Add(new Drawable(this.Map.getNode("Flaps" + i).Location, "FlapsOff"));
				}
				else
				{
					d.Add(new Drawable(this.Map.getNode("Flaps" + i).Location, "Flaps" + (i + A.ST.FrameCounter) % 6));
				}
			}
			float z = 0f;
			int loc = 0;
			foreach (VBRProductType p in AppConstants.ProductTypes)
			{
				int nCrates = (int)Math.Ceiling((double)((float)this.products[p.Index].Count / (float)p.ItemsPerCase));
				for (int j = 0; j < nCrates; j++)
				{
					if (z + p.CaseHeight > 5f)
					{
						z = 0f;
						loc++;
					}
					float percentExpired = ((Item)this.products[p.Index][0]).PercentExpired;
					if (loc < 24)
					{
						int r = loc / 4;
						int c = loc % 4;
						d.Add(new BackroomDrawable(new Point(baseX - c * colSpacing + r * rowSpacing, baseY + c * colSpacing / 2 + r * rowSpacing / 2 - (int)(z * (float)zSpacing)), "Case" + p.Index, p.Index, percentExpired)
						{
							ToolTipText = A.R.GetString("{0} total units of {1}", new object[]
							{
								this.products[p.Index].Count * 20,
								p.Name
							}),
							VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom
						});
					}
					z += p.CaseHeight;
				}
			}
			foreach (object obj in this.Repairmen)
			{
				Repairman r2 = (Repairman)obj;
				d.AddRange(r2.GetDrawables());
			}
			return d;
		}

		// Token: 0x04000134 RID: 308
		public const int MaxCaseStackHeight = 5;

		// Token: 0x04000135 RID: 309
		public const int Rows = 6;

		// Token: 0x04000136 RID: 310
		public const int Cols = 4;

		// Token: 0x04000137 RID: 311
		public ArrayList Repairmen = new ArrayList();

		// Token: 0x04000138 RID: 312
		protected AppEntity parent;

		/// <summary>
		/// The inventory of product items in the back room, indexed by product ID.
		/// Items are FIFO.
		/// </summary>
		// Token: 0x04000139 RID: 313
		protected ArrayList[] products = new ArrayList[AppConstants.ProductTypes.Length];

		// Token: 0x0400013A RID: 314
		public CoolingDuct CoolingDuct;

		// Token: 0x0400013B RID: 315
		public MapV2 Map;
	}
}
