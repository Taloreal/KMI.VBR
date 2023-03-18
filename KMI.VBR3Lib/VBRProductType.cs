using System;
using KMI.Biz.Product;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for VBRProductType.
	/// </summary>
	// Token: 0x0200001B RID: 27
	[Serializable]
	public class VBRProductType : ProductType
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000AE RID: 174 RVA: 0x0000AA80 File Offset: 0x00009A80
		// (set) Token: 0x060000AF RID: 175 RVA: 0x0000AA98 File Offset: 0x00009A98
		public bool IsImpulseItem
		{
			get
			{
				return this.isImpulseItem;
			}
			set
			{
				this.isImpulseItem = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000AAA4 File Offset: 0x00009AA4
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000AABC File Offset: 0x00009ABC
		public int Stealability
		{
			get
			{
				return this.stealability;
			}
			set
			{
				this.stealability = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000AAC8 File Offset: 0x00009AC8
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x0000AAE0 File Offset: 0x00009AE0
		public bool FridgeRequired
		{
			get
			{
				return this.fridgeRequired;
			}
			set
			{
				this.fridgeRequired = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000AAEC File Offset: 0x00009AEC
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x0000AB04 File Offset: 0x00009B04
		public bool FridgeOK
		{
			get
			{
				return this.fridgeOK;
			}
			set
			{
				this.fridgeOK = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000AB10 File Offset: 0x00009B10
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x0000AB28 File Offset: 0x00009B28
		public string RackType
		{
			get
			{
				return this.rackType;
			}
			set
			{
				this.rackType = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x0000AB34 File Offset: 0x00009B34
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x0000AB4C File Offset: 0x00009B4C
		public float CaseHeight
		{
			get
			{
				return this.caseHeight;
			}
			set
			{
				this.caseHeight = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000BA RID: 186 RVA: 0x0000AB58 File Offset: 0x00009B58
		// (set) Token: 0x060000BB RID: 187 RVA: 0x0000AB70 File Offset: 0x00009B70
		public int ItemsPerCase
		{
			get
			{
				return this.itemsPerCase;
			}
			set
			{
				this.itemsPerCase = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0000AB7C File Offset: 0x00009B7C
		// (set) Token: 0x060000BD RID: 189 RVA: 0x0000AB94 File Offset: 0x00009B94
		public int ComplementedBy
		{
			get
			{
				return this.complementedBy;
			}
			set
			{
				this.complementedBy = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000BE RID: 190 RVA: 0x0000ABA0 File Offset: 0x00009BA0
		// (set) Token: 0x060000BF RID: 191 RVA: 0x0000ABB8 File Offset: 0x00009BB8
		public int Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x0000ABC4 File Offset: 0x00009BC4
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x0000ABDC File Offset: 0x00009BDC
		public int ProductSpacing
		{
			get
			{
				return this.productSpacing;
			}
			set
			{
				this.productSpacing = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x0000ABE8 File Offset: 0x00009BE8
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x0000AC00 File Offset: 0x00009C00
		public float MarginMultiplier
		{
			get
			{
				return this.marginMultiplier;
			}
			set
			{
				this.marginMultiplier = value;
			}
		}

		// Token: 0x040000A5 RID: 165
		protected bool isImpulseItem;

		// Token: 0x040000A6 RID: 166
		protected int stealability;

		// Token: 0x040000A7 RID: 167
		protected bool fridgeRequired;

		// Token: 0x040000A8 RID: 168
		protected bool fridgeOK;

		// Token: 0x040000A9 RID: 169
		protected string rackType;

		// Token: 0x040000AA RID: 170
		protected float caseHeight;

		// Token: 0x040000AB RID: 171
		protected int itemsPerCase;

		// Token: 0x040000AC RID: 172
		protected int complementedBy = -1;

		// Token: 0x040000AD RID: 173
		protected int width = 0;

		// Token: 0x040000AE RID: 174
		protected int productSpacing = -1;

		// Token: 0x040000AF RID: 175
		protected float marginMultiplier;
	}
}
