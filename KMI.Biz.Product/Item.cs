using System;

namespace KMI.Biz.Product
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class Item
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00003E2C File Offset: 0x00002E2C
		public Item(int cat)
		{
			this.Cat = cat;
		}

		// Token: 0x0400003E RID: 62
		public int Cat;

		// Token: 0x0400003F RID: 63
		public float QuotedPrice;

		// Token: 0x04000040 RID: 64
		public float Cost;
	}
}
