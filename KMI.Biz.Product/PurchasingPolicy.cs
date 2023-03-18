using System;

namespace KMI.Biz.Product
{
	// Token: 0x0200001E RID: 30
	[Serializable]
	public class PurchasingPolicy
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x0000D508 File Offset: 0x0000C508
		public PurchasingPolicy(int globalAmount, int globalWhen, int numProducts)
		{
			this.globalAmount = globalAmount;
			this.globalWhen = globalWhen;
			this.custom = new bool[numProducts];
			this.amount = new int[numProducts];
			this.when = new int[numProducts];
			for (int i = 0; i < numProducts; i++)
			{
				this.custom[i] = false;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000D569 File Offset: 0x0000C569
		public void SetToCustom(int product, int amount, int when)
		{
			this.custom[product] = true;
			this.amount[product] = amount;
			this.when[product] = when;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000D587 File Offset: 0x0000C587
		public void SetToGlobal(int product)
		{
			this.custom[product] = false;
			this.amount[product] = this.globalAmount;
			this.when[product] = this.globalWhen;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000D5B0 File Offset: 0x0000C5B0
		public int GetAmount(int product)
		{
			int result;
			if (this.custom[product])
			{
				result = this.amount[product];
			}
			else
			{
				result = this.globalAmount;
			}
			return result;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000D5E4 File Offset: 0x0000C5E4
		public int GetWhen(int product)
		{
			int result;
			if (this.custom[product])
			{
				result = this.when[product];
			}
			else
			{
				result = this.globalWhen;
			}
			return result;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000D618 File Offset: 0x0000C618
		public bool GetCustom(int product)
		{
			return this.custom[product];
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000DF RID: 223 RVA: 0x0000D634 File Offset: 0x0000C634
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x0000D64C File Offset: 0x0000C64C
		public int GlobalAmount
		{
			get
			{
				return this.globalAmount;
			}
			set
			{
				this.globalAmount = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x0000D658 File Offset: 0x0000C658
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x0000D670 File Offset: 0x0000C670
		public int GlobalWhen
		{
			get
			{
				return this.globalWhen;
			}
			set
			{
				this.globalWhen = value;
			}
		}

		// Token: 0x04000129 RID: 297
		protected bool[] custom;

		// Token: 0x0400012A RID: 298
		protected int[] amount;

		// Token: 0x0400012B RID: 299
		protected int[] when;

		// Token: 0x0400012C RID: 300
		protected int globalAmount;

		// Token: 0x0400012D RID: 301
		protected int globalWhen;
	}
}
