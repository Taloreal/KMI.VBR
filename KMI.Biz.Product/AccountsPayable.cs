using System;
using System.Collections;
using KMI.Sim;

namespace KMI.Biz.Product
{
	// Token: 0x02000019 RID: 25
	[Serializable]
	public class AccountsPayable
	{
		// Token: 0x060000AA RID: 170 RVA: 0x0000AC44 File Offset: 0x00009C44
		public void SetPolicy(string[] supplierNames, int[] daysToPay)
		{
			int num = 0;
			foreach (string key in supplierNames)
			{
				if (this.daysToPay.ContainsKey(key))
				{
					this.daysToPay[key] = daysToPay[num];
				}
				else
				{
					this.daysToPay.Add(key, daysToPay[num]);
				}
				num++;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000ACBC File Offset: 0x00009CBC
		public int GetPolicy(string supplierName)
		{
			int result;
			if (this.daysToPay.ContainsKey(supplierName))
			{
				result = (int)this.daysToPay[supplierName];
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000ACF8 File Offset: 0x00009CF8
		public void ClearPolicy(string[] supplierNames)
		{
			foreach (string key in supplierNames)
			{
				if (this.daysToPay.ContainsKey(key))
				{
					this.daysToPay.Remove(key);
				}
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000AD40 File Offset: 0x00009D40
		public void PayInvoices(Supplier[] Suppliers, DateTime today, GeneralLedger GL)
		{
			foreach (object obj in this.invoicesForSupplier.Values)
			{
				SortedList sortedList = (SortedList)obj;
				while (sortedList.Count > 0)
				{
					Invoice invoice = (Invoice)sortedList.GetByIndex(0);
					if (!(invoice.InvoiceDate.AddDays((double)this.GetPolicy(invoice.SupplierName)) < today))
					{
						break;
					}
					Supplier supplierByName = this.GetSupplierByName(Suppliers, invoice.SupplierName);
					if (invoice.InvoiceDate.AddDays((double)supplierByName.EarlyPayDays) > today)
					{
						float amount = invoice.Amount * supplierByName.EarlyPayDiscount;
						GL.Post("Cash", amount, "Early Pay Discounts");
					}
					GL.Post("Accounts Payable", invoice.Amount, "Cash");
					sortedList.RemoveAt(0);
				}
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000AE88 File Offset: 0x00009E88
		private Supplier GetSupplierByName(Supplier[] suppliers, string name)
		{
			foreach (Supplier supplier in suppliers)
			{
				if (supplier.Name == name)
				{
					return supplier;
				}
			}
			return null;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000AED0 File Offset: 0x00009ED0
		public void AddInvoice(Invoice invoice)
		{
			if (!this.invoicesForSupplier.ContainsKey(invoice.SupplierName))
			{
				SortedList sortedList = new SortedList();
				sortedList.Add(invoice.InvoiceDate, invoice);
				this.invoicesForSupplier.Add(invoice.SupplierName, sortedList);
			}
			else
			{
				((SortedList)this.invoicesForSupplier[invoice.SupplierName]).Add(invoice.InvoiceDate, invoice);
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000AF50 File Offset: 0x00009F50
		public float TotalOwed(Supplier supplier)
		{
			float result;
			if (!this.invoicesForSupplier.ContainsKey(supplier.Name))
			{
				result = 0f;
			}
			else
			{
				float num = 0f;
				foreach (object obj in ((SortedList)this.invoicesForSupplier[supplier.Name]).Values)
				{
					Invoice invoice = (Invoice)obj;
					num += invoice.Amount;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000AFFC File Offset: 0x00009FFC
		public float PastDue(Supplier supplier)
		{
			float result;
			if (!this.invoicesForSupplier.ContainsKey(supplier.Name))
			{
				result = 0f;
			}
			else
			{
				float num = 0f;
				foreach (object obj in ((SortedList)this.invoicesForSupplier[supplier.Name]).Values)
				{
					Invoice invoice = (Invoice)obj;
					if (invoice.DueDate < S.ST.Now)
					{
						num += invoice.Amount;
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000B0C8 File Offset: 0x0000A0C8
		public DateTime OldestInvoice(Supplier supplier)
		{
			DateTime result;
			if (!this.invoicesForSupplier.ContainsKey(supplier.Name))
			{
				result = DateTime.MinValue;
			}
			else
			{
				SortedList sortedList = (SortedList)this.invoicesForSupplier[supplier.Name];
				if (sortedList.Count == 0)
				{
					result = DateTime.MinValue;
				}
				else
				{
					result = ((Invoice)sortedList.GetByIndex(0)).InvoiceDate;
				}
			}
			return result;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000B138 File Offset: 0x0000A138
		public void PayInvoices(Supplier supplier, Invoice invoice, GeneralLedger GL)
		{
			SortedList sortedList = (SortedList)this.invoicesForSupplier[supplier.Name];
			if (sortedList.Contains(invoice.InvoiceDate))
			{
				GL.Post("Accounts Payable", invoice.Amount, "Cash");
				sortedList.RemoveAt(sortedList.IndexOfKey(invoice.InvoiceDate));
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000B1A8 File Offset: 0x0000A1A8
		public Invoice GetNearDueInvoice(Supplier supplier, int daysTillDue)
		{
			Invoice result;
			if (!this.invoicesForSupplier.ContainsKey(supplier.Name))
			{
				result = null;
			}
			else
			{
				SortedList sortedList = (SortedList)this.invoicesForSupplier[supplier.Name];
				if (sortedList.Count == 0)
				{
					result = null;
				}
				else
				{
					Invoice invoice = (Invoice)sortedList.GetByIndex(0);
					if ((invoice.DueDate - S.ST.Now).Days < daysTillDue)
					{
						result = invoice;
					}
					else
					{
						result = null;
					}
				}
			}
			return result;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000B238 File Offset: 0x0000A238
		public SortedList GetInvoicesFor(Supplier supplier)
		{
			SortedList result;
			if (!this.invoicesForSupplier.ContainsKey(supplier.Name))
			{
				result = null;
			}
			else
			{
				result = (SortedList)this.invoicesForSupplier[supplier.Name];
			}
			return result;
		}

		// Token: 0x040000F3 RID: 243
		protected Hashtable invoicesForSupplier = new Hashtable();

		// Token: 0x040000F4 RID: 244
		protected Hashtable daysToPay = new Hashtable();
	}
}
