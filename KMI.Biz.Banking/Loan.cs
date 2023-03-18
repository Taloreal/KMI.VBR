using System;
using System.Collections;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz
{
	// Token: 0x02000002 RID: 2
	[Serializable]
	public class Loan
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public Loan(float amount, float rate, int termInMonths)
		{
			this.origination = S.ST.Now;
			this.due = this.origination.AddMonths(termInMonths);
			this.balance = amount;
			this.interestRate = rate;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000208C File Offset: 0x0000108C
		// (set) Token: 0x06000003 RID: 3 RVA: 0x000020A4 File Offset: 0x000010A4
		public DateTime Due
		{
			get
			{
				return this.due;
			}
			set
			{
				this.due = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020B0 File Offset: 0x000010B0
		public float InterestRate
		{
			get
			{
				return this.interestRate;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020C8 File Offset: 0x000010C8
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020E0 File Offset: 0x000010E0
		public float Balance
		{
			get
			{
				return this.balance;
			}
			set
			{
				this.balance = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020EC File Offset: 0x000010EC
		public DateTime Origination
		{
			get
			{
				return this.origination;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002104 File Offset: 0x00001104
		public static void GetLoan(GeneralLedger GL, SortedList loans, float amount, int term, float rate)
		{
			Loan loan = new Loan(amount, rate, term);
			while (loans.ContainsKey(loan.Due))
			{
				loan.Due = loan.Due.AddSeconds(1.0);
			}
			loans.Add(loan.Due, loan);
			GL.Post("Interest", loan.Balance * loan.InterestRate / 52f, "Cash");
			GL.Post("Cash", loan.Balance, "Debt");
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021A0 File Offset: 0x000011A0
		public static void PayLoan(GeneralLedger GL, SortedList loans, ArrayList loanDue, ArrayList payAmount)
		{
			float num = 0f;
			foreach (object obj in payAmount)
			{
				float num2 = (float)obj;
				num += num2;
			}
			if (num > GL.AccountBalance("Cash"))
			{
				throw new SimApplicationException(S.R.GetString("You do not have enough cash to make all the payments you specified. Please try again. Your current total cash is {0}.", new object[]
				{
					Utilities.FC(GL.AccountBalance("Cash"), S.I.CurrencyConversion)
				}));
			}
			for (int i = 0; i < loanDue.Count; i++)
			{
				if (loans.ContainsKey(loanDue[i]))
				{
					Loan loan = (Loan)loans[loanDue[i]];
					loan.Balance -= (float)payAmount[i];
					if (loan.Balance < 0.01f)
					{
						loans.Remove(loan.Due);
					}
					GL.Post("Debt", (float)payAmount[i], "Cash");
				}
			}
		}

		// Token: 0x04000001 RID: 1
		protected DateTime due;

		// Token: 0x04000002 RID: 2
		protected float interestRate;

		// Token: 0x04000003 RID: 3
		protected float balance;

		// Token: 0x04000004 RID: 4
		protected DateTime origination;

		// Token: 0x04000005 RID: 5
		public static int DaysBetweenLoans = 14;
	}
}
