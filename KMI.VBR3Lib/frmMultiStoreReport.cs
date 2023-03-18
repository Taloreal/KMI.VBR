using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmMultiStoreReport.
	/// </summary>
	// Token: 0x02000005 RID: 5
	public partial class frmMultiStoreReport : frmDrawnReport
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002F12 File Offset: 0x00001F12
		public frmMultiStoreReport()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002F24 File Offset: 0x00001F24
		protected override void GetDataVirtual()
		{
			this.inputs = A.SA.GetMultiStoreReport(A.MF.CurrentEntityID);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003008 File Offset: 0x00002008
		protected override void DrawReportVirtual(Graphics g)
		{
			Font f = new Font("Arial", 8f);
			Font f2 = new Font("Arial", 14f);
			Brush b = new SolidBrush(Color.Black);
			StringFormat sfr = new StringFormat();
			sfr.Alignment = StringAlignment.Far;
			StringFormat sfc = new StringFormat();
			sfc.Alignment = StringAlignment.Center;
			int left = 0;
			this.picReport.Controls.Clear();
			foreach (frmMultiStoreReport.Input i in this.inputs)
			{
				int y = 0;
				g.DrawString(i.Name, f2, b, (float)(left + 87), (float)y, sfc);
				y += 42;
				float rev = i.gl.AccountBalance("Revenue", i.CurrentWeek - 1);
				foreach (string accountName in new string[]
				{
					"Revenue",
					"COGS",
					"Gross Margin",
					"Rent",
					"Wages",
					"Promotion",
					"Equipment Costs",
					"Other",
					"Profit",
					"Cash",
					"Customers"
				})
				{
					float bal = i.gl.AccountBalance(accountName, i.CurrentWeek - 1);
					g.DrawString(accountName, f, b, (float)left, (float)y);
					string text = Utilities.FC(bal, A.I.CurrencyConversion);
					if (accountName == "Customers")
					{
						text = Utilities.FU((int)bal);
					}
					g.DrawString(text, f, b, (float)(left + 140), (float)y, sfr);
					if (accountName != "Customers" && accountName != "Cash")
					{
						string s = "NA";
						if (rev != 0f)
						{
							s = Utilities.FP(bal / rev);
						}
						g.DrawString(s, f, b, (float)(left + 175), (float)y, sfr);
					}
					y += 14;
					if (accountName == "Profit")
					{
						y += 14;
					}
				}
				Label btn = new Label();
				btn.ForeColor = Color.Blue;
				btn.Font = new Font(btn.Font, FontStyle.Underline);
				btn.Text = "View";
				btn.TextAlign = ContentAlignment.MiddleCenter;
				btn.Location = new Point(left + 87 - btn.Width / 2, 18);
				btn.Click += this.btnView_Click;
				btn.Tag = i.ID;
				btn.Cursor = Cursors.Hand;
				this.picReport.Controls.Add(btn);
				int x = (int)((double)left + 192.5);
				g.DrawLine(new Pen(b, 2f), new Point(x, 0), new Point(x, y));
				left += 210;
			}
			left -= 21;
			this.picReport.Width = left;
			base.Width = this.picReport.Width + 40;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003390 File Offset: 0x00002390
		private void btnView_Click(object sender, EventArgs e)
		{
			A.MF.OnCurrentEntityChange((long)((Control)sender).Tag);
			if (A.MF.CurrentViewName == S.I.Views[0].Name)
			{
				A.MF.OnViewChange(S.I.Views[1].Name);
			}
			else
			{
				A.MF.UpdateView();
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003409 File Offset: 0x00002409
		protected override void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Multi Store Report"));
		}

		// Token: 0x0400001D RID: 29
		protected frmMultiStoreReport.Input[] inputs;

		// Token: 0x02000006 RID: 6
		[Serializable]
		public struct Input
		{
			// Token: 0x0400001E RID: 30
			public string Name;

			// Token: 0x0400001F RID: 31
			public long ID;

			// Token: 0x04000020 RID: 32
			public GeneralLedger gl;

			// Token: 0x04000021 RID: 33
			public int CurrentWeek;
		}
	}
}
