using System;
using KMI.Biz.Product;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Class representing an item on a shelf, box of cereal, carton of milk, etc.
	/// </summary>
	// Token: 0x0200003B RID: 59
	[Serializable]
	public class Item
	{
		// Token: 0x0600017A RID: 378 RVA: 0x000151A0 File Offset: 0x000141A0
		public Item(ProductType productType)
		{
			this.productType = productType;
			this.PurchaseDate = A.ST.Now;
			this.ExpirationDate = this.PurchaseDate.AddDays((double)productType.ShelfLife);
			this.ID = A.ST.GetNextID();
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600017B RID: 379 RVA: 0x000151FC File Offset: 0x000141FC
		public ProductType ProductType
		{
			get
			{
				return this.productType;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00015214 File Offset: 0x00014214
		// (set) Token: 0x0600017D RID: 381 RVA: 0x0001522C File Offset: 0x0001422C
		public DateTime PurchaseDate
		{
			get
			{
				return this.purchaseDate;
			}
			set
			{
				this.purchaseDate = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00015238 File Offset: 0x00014238
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00015285 File Offset: 0x00014285
		public DateTime ExpirationDate
		{
			get
			{
				DateTime result;
				if (this.expirationDate.Equals(DateTime.MinValue))
				{
					result = DateTime.MinValue;
				}
				else if (!A.SS.ExpireGoods)
				{
					result = DateTime.MaxValue;
				}
				else
				{
					result = this.expirationDate;
				}
				return result;
			}
			set
			{
				this.expirationDate = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00015290 File Offset: 0x00014290
		public bool IsExpired
		{
			get
			{
				return this.ExpirationDate < A.ST.Now;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000181 RID: 385 RVA: 0x000152B8 File Offset: 0x000142B8
		public float PercentExpired
		{
			get
			{
				float result;
				if (this.IsExpired)
				{
					result = 1f;
				}
				else
				{
					int daysRemaining = (this.ExpirationDate - A.ST.Now).Days;
					float pct = (float)(this.ProductType.ShelfLife - daysRemaining) / (float)this.ProductType.ShelfLife;
					result = Math.Max(0f, pct);
				}
				return result;
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00015328 File Offset: 0x00014328
		public void ThrowOut(AppEntity store)
		{
			store.GL.Post("Expired Goods", this.ProductType.Cost * 20f, "Inventory", this.ProductType.Name, 20, new string[]
			{
				"Expired Goods"
			}, new string[]
			{
				"Inventory"
			});
		}

		// Token: 0x0400017C RID: 380
		public long ID;

		/// <summary>
		/// The product type of this item instance.
		/// </summary>
		// Token: 0x0400017D RID: 381
		protected ProductType productType;

		// Token: 0x0400017E RID: 382
		protected DateTime purchaseDate;

		// Token: 0x0400017F RID: 383
		protected DateTime expirationDate;
	}
}
