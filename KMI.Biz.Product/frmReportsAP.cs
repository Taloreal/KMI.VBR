using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x02000014 RID: 20
	public partial class frmReportsAP : frmDrawnReport
	{
		// Token: 0x0600007A RID: 122 RVA: 0x0000827C File Offset: 0x0000727C
		public frmReportsAP()
		{
			this.Text = S.R.GetString("Accounts Payable");
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000082A0 File Offset: 0x000072A0
		protected override void DrawReportVirtual(Graphics g)
		{
			Font font = new Font("Arial", 8f);
			Brush brush = new SolidBrush(Color.Black);
			int num = 0;
			Font font2 = new Font("Arial", 8f, FontStyle.Underline);
			g.DrawString(S.R.GetString("Outstanding Invoives"), font, brush, 0f, (float)num);
			num += 24;
			g.DrawString(S.R.GetString("Due Date"), font2, brush, 0f, (float)num);
			g.DrawString(S.R.GetString("Amount"), font2, brush, 184f, (float)num);
			num += 12;
			foreach (object obj in this.invoices.Values)
			{
				Invoice invoice = (Invoice)obj;
				g.DrawString(invoice.DueDate.ToLongDateString(), font, brush, 0f, (float)num);
				g.DrawString(Utilities.FC(invoice.Amount, S.I.CurrencyConversion), font, brush, 184f, (float)num);
				num += 12;
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000083F0 File Offset: 0x000073F0
		protected override void GetDataVirtual()
		{
			this.invoices = ((IBizProductStateAdapter)S.SA).GetReportsAP(S.MF.CurrentEntityID);
			this.picReport.Height = 12 * (this.invoices.Count + 7);
		}

		// Token: 0x040000B6 RID: 182
		private const int dy = 12;

		// Token: 0x040000B7 RID: 183
		private SortedList invoices;
	}
}
