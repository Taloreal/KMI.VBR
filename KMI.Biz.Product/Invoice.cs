using System;

namespace KMI.Biz.Product
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	public class Invoice
	{
		// Token: 0x06000072 RID: 114 RVA: 0x00008192 File Offset: 0x00007192
		public Invoice(string supplierName, string description, float amount, DateTime invoiceDate, DateTime dueDate, DateTime earlyPayDate, float earlyPayDiscount)
		{
			this.supplierName = supplierName;
			this.description = description;
			this.amount = amount;
			this.invoiceDate = invoiceDate;
			this.dueDate = dueDate;
			this.earlyPayDate = earlyPayDate;
			this.earlyPayDiscount = earlyPayDiscount;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000081D4 File Offset: 0x000071D4
		public string SupplierName
		{
			get
			{
				return this.supplierName;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000081EC File Offset: 0x000071EC
		public string Description
		{
			get
			{
				return this.description;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00008204 File Offset: 0x00007204
		public float Amount
		{
			get
			{
				return this.amount;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000076 RID: 118 RVA: 0x0000821C File Offset: 0x0000721C
		public DateTime InvoiceDate
		{
			get
			{
				return this.invoiceDate;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00008234 File Offset: 0x00007234
		public DateTime DueDate
		{
			get
			{
				return this.dueDate;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000078 RID: 120 RVA: 0x0000824C File Offset: 0x0000724C
		public DateTime EarlyPayDate
		{
			get
			{
				return this.earlyPayDate;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00008264 File Offset: 0x00007264
		public float EarlyPayDiscount
		{
			get
			{
				return this.earlyPayDiscount;
			}
		}

		// Token: 0x040000AF RID: 175
		protected string supplierName;

		// Token: 0x040000B0 RID: 176
		protected string description;

		// Token: 0x040000B1 RID: 177
		protected float amount;

		// Token: 0x040000B2 RID: 178
		protected DateTime invoiceDate;

		// Token: 0x040000B3 RID: 179
		protected DateTime dueDate;

		// Token: 0x040000B4 RID: 180
		protected DateTime earlyPayDate;

		// Token: 0x040000B5 RID: 181
		protected float earlyPayDiscount;
	}
}
