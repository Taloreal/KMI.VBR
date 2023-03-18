using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x02000020 RID: 32
	public partial class frmTradeCredit : Form
	{
		// Token: 0x060000EE RID: 238 RVA: 0x0000D814 File Offset: 0x0000C814
		public frmTradeCredit()
		{
			this.InitializeComponent();
			frmTradeCredit.Input tradeCredit = ((IBizProductStateAdapter)S.SA).GetTradeCredit(S.MF.CurrentEntityID);
			this.panUpdDays.Controls.Clear();
			for (int i = 0; i < tradeCredit.DaysToPay.Length; i++)
			{
				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Location = new Point(this.updDays0.Location.X, this.updDays0.Location.Y + i * 20);
				numericUpDown.Size = this.updDays0.Size;
				numericUpDown.TextAlign = this.updDays0.TextAlign;
				numericUpDown.Maximum = this.updDays0.Maximum;
				numericUpDown.Minimum = this.updDays0.Minimum;
				numericUpDown.Value = tradeCredit.DaysToPay[i];
				this.panUpdDays.Controls.Add(numericUpDown);
			}
			if (tradeCredit.OldestInvoice[0] != DateTime.MinValue)
			{
				this.labOldestInvoice0.Text = tradeCredit.OldestInvoice[0].ToShortDateString();
			}
			this.labPaymentTerms0.Text = tradeCredit.PaymentTerms[0];
			this.labPastDue0.Text = Utilities.FC(tradeCredit.PastDue[0], S.I.CurrencyConversion);
			this.labTotalOwed0.Text = Utilities.FC(tradeCredit.TotalOwed[0], S.I.CurrencyConversion);
			this.labVendorName0.Text = tradeCredit.Name[0];
			this.label6.Text = S.R.GetString("Understanding Payment Terms: Here's an example, payment terms of 2/10/N/30 mean you will get a 2% discount if you pay within 10 days. Otherwise, the Net (or full) amount is due within 30 days.");
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000E539 File Offset: 0x0000D539
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000E544 File Offset: 0x0000D544
		private void cmdOK_Click(object sender, EventArgs e)
		{
			try
			{
				int[] array = new int[this.panUpdDays.Controls.Count];
				int num = 0;
				foreach (object obj in this.panUpdDays.Controls)
				{
					NumericUpDown numericUpDown = (NumericUpDown)obj;
					array[num] = (int)numericUpDown.Value;
					num++;
				}
				((IBizProductStateAdapter)S.SA).SetTradeCredit(S.MF.CurrentEntityID, array);
				base.Close();
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2);
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000E61C File Offset: 0x0000D61C
		private void cmdHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Trade Credit");
		}

		// Token: 0x02000021 RID: 33
		[Serializable]
		public struct Input
		{
			// Token: 0x04000147 RID: 327
			public string[] Name;

			// Token: 0x04000148 RID: 328
			public string[] PaymentTerms;

			// Token: 0x04000149 RID: 329
			public float[] TotalOwed;

			// Token: 0x0400014A RID: 330
			public float[] PastDue;

			// Token: 0x0400014B RID: 331
			public DateTime[] OldestInvoice;

			// Token: 0x0400014C RID: 332
			public int[] DaysToPay;
		}
	}
}
