using System;

namespace KMI.Biz.Product
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class Receivable
	{
		// Token: 0x04000026 RID: 38
		public CustomerBase Customer;

		// Token: 0x04000027 RID: 39
		public int OrderNumber;

		// Token: 0x04000028 RID: 40
		public float Amount;

		// Token: 0x04000029 RID: 41
		public DateTime NetDate;

		// Token: 0x0400002A RID: 42
		public DateTime EarlyPayDate;

		// Token: 0x0400002B RID: 43
		public float EarlyPayDiscount;

		// Token: 0x0400002C RID: 44
		public bool COD;

		// Token: 0x0400002D RID: 45
		public DateTime LastDunned;
	}
}
