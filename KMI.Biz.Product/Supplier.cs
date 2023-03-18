using System;
using KMI.Sim;

namespace KMI.Biz.Product
{
	// Token: 0x02000002 RID: 2
	[Serializable]
	public class Supplier : ActiveObject
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000205C File Offset: 0x0000105C
		// (set) Token: 0x06000003 RID: 3 RVA: 0x00002074 File Offset: 0x00001074
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

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002080 File Offset: 0x00001080
		// (set) Token: 0x06000005 RID: 5 RVA: 0x00002098 File Offset: 0x00001098
		public int DaysToPay
		{
			get
			{
				return this.daysToPay;
			}
			set
			{
				this.daysToPay = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020A4 File Offset: 0x000010A4
		// (set) Token: 0x06000007 RID: 7 RVA: 0x000020BC File Offset: 0x000010BC
		public int EarlyPayDays
		{
			get
			{
				return this.earlyPayDays;
			}
			set
			{
				this.earlyPayDays = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020C8 File Offset: 0x000010C8
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020E0 File Offset: 0x000010E0
		public float EarlyPayDiscount
		{
			get
			{
				return this.earlyPayDiscount;
			}
			set
			{
				this.earlyPayDiscount = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020EC File Offset: 0x000010EC
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002104 File Offset: 0x00001104
		public float RelativePrice
		{
			get
			{
				return this.relativePrice;
			}
			set
			{
				this.relativePrice = value;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002110 File Offset: 0x00001110
		public Invoice CreateInvoice(float amount, string description)
		{
			DateTime now = S.ST.Now;
			return new Invoice(this.name, description, amount, now, now.AddDays((double)this.daysToPay), now.AddDays((double)this.earlyPayDays), this.earlyPayDiscount);
		}

		// Token: 0x04000001 RID: 1
		protected string name;

		// Token: 0x04000002 RID: 2
		protected int daysToPay;

		// Token: 0x04000003 RID: 3
		protected int earlyPayDays;

		// Token: 0x04000004 RID: 4
		protected float earlyPayDiscount;

		// Token: 0x04000005 RID: 5
		protected float relativePrice;
	}
}
