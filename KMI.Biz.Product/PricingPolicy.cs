using System;

namespace KMI.Biz.Product
{
	// Token: 0x0200001F RID: 31
	[Serializable]
	public class PricingPolicy
	{
		// Token: 0x060000E3 RID: 227 RVA: 0x0000D67C File Offset: 0x0000C67C
		public PricingPolicy(float globalMargin, float globalMarginIntl, int numProducts)
		{
			this.globalMargin = globalMargin;
			this.globalMarginIntl = globalMarginIntl;
			this.custom = new bool[numProducts];
			this.margin = new float[numProducts];
			this.marginIntl = new float[numProducts];
			for (int i = 0; i < numProducts; i++)
			{
				this.custom[i] = false;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000D6DD File Offset: 0x0000C6DD
		public void SetToCustom(int product, float margin, float marginIntl)
		{
			this.custom[product] = true;
			this.margin[product] = margin;
			this.marginIntl[product] = marginIntl;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000D6FB File Offset: 0x0000C6FB
		public void SetToGlobal(int product)
		{
			this.custom[product] = false;
			this.margin[product] = this.globalMargin;
			this.marginIntl[product] = this.globalMarginIntl;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000D724 File Offset: 0x0000C724
		public float GetPrice(int product, float cost)
		{
			return cost / (1f - this.GetMargin(product));
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000D748 File Offset: 0x0000C748
		public float GetMargin(int product)
		{
			float result;
			if (this.custom[product])
			{
				result = this.margin[product];
			}
			else
			{
				result = this.globalMargin;
			}
			return result;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000D77C File Offset: 0x0000C77C
		public float GetMarginIntl(int product)
		{
			float result;
			if (this.custom[product])
			{
				result = this.margin[product];
			}
			else
			{
				result = this.globalMarginIntl;
			}
			return result;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000D7B0 File Offset: 0x0000C7B0
		public bool GetCustom(int product)
		{
			return this.custom[product];
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000EA RID: 234 RVA: 0x0000D7CC File Offset: 0x0000C7CC
		// (set) Token: 0x060000EB RID: 235 RVA: 0x0000D7E4 File Offset: 0x0000C7E4
		public float GlobalMargin
		{
			get
			{
				return this.globalMargin;
			}
			set
			{
				this.globalMargin = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000EC RID: 236 RVA: 0x0000D7F0 File Offset: 0x0000C7F0
		// (set) Token: 0x060000ED RID: 237 RVA: 0x0000D808 File Offset: 0x0000C808
		public float GlobalMarginIntl
		{
			get
			{
				return this.globalMarginIntl;
			}
			set
			{
				this.globalMarginIntl = value;
			}
		}

		// Token: 0x0400012E RID: 302
		protected bool[] custom;

		// Token: 0x0400012F RID: 303
		protected float[] margin;

		// Token: 0x04000130 RID: 304
		protected float[] marginIntl;

		// Token: 0x04000131 RID: 305
		protected float globalMargin;

		// Token: 0x04000132 RID: 306
		protected float globalMarginIntl;
	}
}
