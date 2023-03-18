using System;

namespace KMI.Biz.Product
{
	// Token: 0x02000011 RID: 17
	[Serializable]
	public class ProductType
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00007B4C File Offset: 0x00006B4C
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00007B64 File Offset: 0x00006B64
		public int Index
		{
			get
			{
				return this.index;
			}
			set
			{
				this.index = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00007B70 File Offset: 0x00006B70
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00007B88 File Offset: 0x00006B88
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00007B94 File Offset: 0x00006B94
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00007BAC File Offset: 0x00006BAC
		public int ShelfLife
		{
			get
			{
				return this.shelfLife;
			}
			set
			{
				this.shelfLife = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00007BB8 File Offset: 0x00006BB8
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00007BD0 File Offset: 0x00006BD0
		public float Cost
		{
			get
			{
				return this.cost;
			}
			set
			{
				this.cost = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00007BDC File Offset: 0x00006BDC
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00007BF4 File Offset: 0x00006BF4
		public float Seasonality
		{
			get
			{
				return this.seasonality;
			}
			set
			{
				this.seasonality = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00007C00 File Offset: 0x00006C00
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00007C18 File Offset: 0x00006C18
		public float RelativeDemand
		{
			get
			{
				return this.relativeDemand;
			}
			set
			{
				this.relativeDemand = value;
			}
		}

		// Token: 0x040000A3 RID: 163
		protected int index;

		// Token: 0x040000A4 RID: 164
		protected string name;

		// Token: 0x040000A5 RID: 165
		public static string ImageBaseName = "Prod";

		// Token: 0x040000A6 RID: 166
		protected int shelfLife;

		// Token: 0x040000A7 RID: 167
		protected float cost;

		// Token: 0x040000A8 RID: 168
		protected float seasonality;

		// Token: 0x040000A9 RID: 169
		protected float relativeDemand;
	}
}
