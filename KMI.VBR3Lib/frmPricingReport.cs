using System;
using System.Drawing;
using KMI.Biz.Product;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	// Token: 0x0200004B RID: 75
	public partial class frmPricingReport : frmDrawnReport
	{
		// Token: 0x060002EF RID: 751 RVA: 0x00021FB0 File Offset: 0x00020FB0
		public frmPricingReport()
		{
			this.Text = A.R.GetString("Competitive Prices");
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00021FD1 File Offset: 0x00020FD1
		protected override void GetDataVirtual()
		{
			this.input = A.SA.GetPricingReport();
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00021FE4 File Offset: 0x00020FE4
		protected override void DrawReportVirtual(Graphics g)
		{
			int space = 80;
			this.picReport.Height = base.Height - 100;
			int i = this.input.StoreNames.Length;
			base.Width = Math.Max(1, i) * space + 150;
			Font f = new Font("Arial", 10f);
			Font fb = new Font("Arial", 10f, FontStyle.Bold);
			Brush b = new SolidBrush(Color.Black);
			if (i == 0)
			{
				g.DrawString(A.R.GetString("No Stores"), fb, b, 0f, 0f);
			}
			else
			{
				StringFormat sfc = new StringFormat();
				StringFormat sfr = new StringFormat();
				sfc.Alignment = StringAlignment.Center;
				sfr.Alignment = StringAlignment.Far;
				int y = 0;
				for (int j = 0; j < i; j++)
				{
					g.DrawString(this.input.StoreNames[j], fb, b, (float)((2 + j) * space), (float)y, sfr);
				}
				for (int k = 0; k < 25; k++)
				{
					y += 15;
					g.DrawString(AppConstants.ProductTypes[k].Name, fb, b, 0f, (float)y);
					for (int j = 0; j < i; j++)
					{
						g.DrawString(Utilities.FC(this.input.PricingPolicies[j].GetPrice(k, AppConstants.ProductTypes[k].Cost), 2, A.I.CurrencyConversion), f, b, (float)((2 + j) * space), (float)y, sfr);
					}
				}
			}
		}

		// Token: 0x0400027B RID: 635
		private frmPricingReport.Input input;

		// Token: 0x0200004C RID: 76
		[Serializable]
		public struct Input
		{
			// Token: 0x0400027C RID: 636
			public string[] StoreNames;

			// Token: 0x0400027D RID: 637
			public PricingPolicy[] PricingPolicies;
		}
	}
}
