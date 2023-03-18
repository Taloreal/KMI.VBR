using System;
using System.Collections;

namespace KMI.Biz.Banking
{
	// Token: 0x02000003 RID: 3
	public interface IBizBankingStateAdapter
	{
		// Token: 0x0600000B RID: 11
		frmGetLoan.Input GetLoanInfo(long entityID);

		// Token: 0x0600000C RID: 12
		void GetLoan(long entityID, float amount, int term, float rate);

		// Token: 0x0600000D RID: 13
		void PayLoan(long entityID, ArrayList loanDue, ArrayList payAmount);
	}
}
