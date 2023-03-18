using System;
using System.Collections;

namespace KMI.Biz.Product
{
	// Token: 0x02000016 RID: 22
	public interface IBizProductStateAdapter
	{
		// Token: 0x0600007F RID: 127
		frmCustomerCredit.Input GetCustomerCredit(long entityID);

		// Token: 0x06000080 RID: 128
		void SetCustomerCredit(long entityID, ArrayList noCredit, float earlyPayDiscount, int earlyPayDays, int netPayDays);

		// Token: 0x06000081 RID: 129
		frmTradeCredit.Input GetTradeCredit(long entityID);

		// Token: 0x06000082 RID: 130
		void SetTradeCredit(long entityID, int[] daysToPay);

		// Token: 0x06000083 RID: 131
		frmPurchasing.Input GetPurchasing(long entityID);

		// Token: 0x06000084 RID: 132
		void SetPurchasing(long entityID, PurchasingPolicy policy);

		// Token: 0x06000085 RID: 133
		void DiscardAllProduct(long entityID, int index);

		// Token: 0x06000086 RID: 134
		frmPricing.Input GetPricing(long entityID);

		// Token: 0x06000087 RID: 135
		void SetPricing(long entityID, PricingPolicy policy);

		// Token: 0x06000088 RID: 136
		frmAdDesigner.Input GetAd(long entityID, int adNumber);

		// Token: 0x06000089 RID: 137
		void SetAd(long entityID, int adNumber, Ad ad);

		// Token: 0x0600008A RID: 138
		Hashtable GetReportsAR(long entityID);

		// Token: 0x0600008B RID: 139
		SortedList GetReportsAP(long entityID);
	}
}
