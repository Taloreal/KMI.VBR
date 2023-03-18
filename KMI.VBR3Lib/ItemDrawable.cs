using System;
using System.Drawing;
using KMI.Biz.Product;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for ItemDrawable.
	/// </summary>
	// Token: 0x02000025 RID: 37
	[Serializable]
	public class ItemDrawable : FlexDrawable, IPctExpired
	{
		// Token: 0x060000EC RID: 236 RVA: 0x0000E5AC File Offset: 0x0000D5AC
		public ItemDrawable(Point location, string imageName, ProductType productType, DateTime purchaseDate, DateTime expirationDate, float percentExpired, long shelfID) : base(location, imageName)
		{
			this.ProductType = productType;
			this.PurchaseDate = purchaseDate;
			this.ExpirationDate = expirationDate;
			this.percentExpired = percentExpired;
			base.VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom;
			base.HorizontalAlignment = FlexDrawable.HorizontalAlignments.Center;
			base.ToolTipText = productType.Name;
			base.Hittable = false;
			this.ShelfID = shelfID;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000E610 File Offset: 0x0000D610
		public float PercentExpired()
		{
			return this.percentExpired;
		}

		// Token: 0x04000105 RID: 261
		public long ID;

		// Token: 0x04000106 RID: 262
		public long ShelfID;

		// Token: 0x04000107 RID: 263
		public ProductType ProductType;

		// Token: 0x04000108 RID: 264
		public DateTime PurchaseDate;

		// Token: 0x04000109 RID: 265
		public DateTime ExpirationDate;

		// Token: 0x0400010A RID: 266
		protected float percentExpired;
	}
}
