using System;
using System.Collections;
using KMI.Sim;

namespace KMI.Biz.Product
{
	// Token: 0x02000008 RID: 8
	[Serializable]
	public class AccountsReceivable
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00003A2D File Offset: 0x00002A2D
		public void AddReceivable(Receivable receivable)
		{
			this.receivables.Add(receivable);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003A40 File Offset: 0x00002A40
		public void ReceivePayments(SortedList customers, GeneralLedger GL)
		{
			foreach (object obj in ((ArrayList)this.receivables.Clone()))
			{
				Receivable receivable = (Receivable)obj;
				float num = 0f;
				AccountsReceivable.Pay pay = AccountsReceivable.Pay.DontPay;
				if (pay == AccountsReceivable.Pay.Pay || pay == AccountsReceivable.Pay.PayEarly)
				{
					if (pay == AccountsReceivable.Pay.PayEarly)
					{
						num = receivable.Amount * receivable.EarlyPayDiscount;
					}
					GL.Post("Cash", receivable.Amount - num, "Accounts Receivable");
					this.receivables.Remove(receivable);
				}
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003B10 File Offset: 0x00002B10
		public Hashtable GetARInfo()
		{
			Hashtable hashtable = new Hashtable();
			foreach (object obj in this.receivables)
			{
				Receivable receivable = (Receivable)obj;
				if (!hashtable.ContainsKey(receivable.Customer.Name))
				{
					Hashtable hashtable2 = hashtable;
					object name = receivable.Customer.Name;
					float[] value = new float[5];
					hashtable2.Add(name, value);
				}
				float[] array = (float[])hashtable[receivable.Customer.Name];
				int num;
				if (S.ST.Now < receivable.NetDate)
				{
					num = 0;
				}
				else
				{
					num = (S.ST.Now - receivable.NetDate).Days / 30 + 1;
				}
				array[num] += receivable.Amount;
			}
			return hashtable;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00003C38 File Offset: 0x00002C38
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00003C50 File Offset: 0x00002C50
		public ArrayList NoCredit
		{
			get
			{
				return this.noCredit;
			}
			set
			{
				this.noCredit = value;
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003C5C File Offset: 0x00002C5C
		public Receivable GetRandomReceivable(int daysSinceLastDunned)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.receivables)
			{
				Receivable receivable = (Receivable)obj;
				if (receivable.NetDate < S.ST.Now && (S.ST.Now - receivable.LastDunned).Days > daysSinceLastDunned)
				{
					arrayList.Add(receivable);
				}
			}
			Receivable result;
			if (arrayList.Count > 0)
			{
				result = (Receivable)arrayList[S.ST.Random.Next(arrayList.Count)];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003D4C File Offset: 0x00002D4C
		public void ReceivePayments(Receivable receivable, GeneralLedger GL)
		{
			if (this.receivables.Contains(receivable))
			{
				GL.Post("Cash", receivable.Amount, "Accounts Receivable");
				this.receivables.Remove(receivable);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003D94 File Offset: 0x00002D94
		public ArrayList GetOverdueReceivables()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.receivables)
			{
				Receivable receivable = (Receivable)obj;
				if (S.ST.Now > receivable.NetDate)
				{
					arrayList.Add(receivable);
				}
			}
			return arrayList;
		}

		// Token: 0x04000035 RID: 53
		protected ArrayList receivables = new ArrayList();

		// Token: 0x04000036 RID: 54
		protected ArrayList noCredit = new ArrayList();

		// Token: 0x04000037 RID: 55
		public int NetPayDays;

		// Token: 0x04000038 RID: 56
		public int EarlyPayDays;

		// Token: 0x04000039 RID: 57
		public float EarlyPayDiscount;

		// Token: 0x02000009 RID: 9
		private enum Pay
		{
			// Token: 0x0400003B RID: 59
			Pay,
			// Token: 0x0400003C RID: 60
			PayEarly,
			// Token: 0x0400003D RID: 61
			DontPay
		}
	}
}
