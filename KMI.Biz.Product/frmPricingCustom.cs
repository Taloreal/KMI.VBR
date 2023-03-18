using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x0200000D RID: 13
	public partial class frmPricingCustom : Form
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00003EC2 File Offset: 0x00002EC2
		public frmPricingCustom(ProductType[] productTypes, int productTypeIndex, frmPricing.Input input)
		{
			this.InitializeComponent();
			this.input = input;
			this.productTypes = productTypes;
			this.productIndex = productTypeIndex;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003EEC File Offset: 0x00002EEC
		protected void InitializeGraphics()
		{
			this.DarkGrayBrush = new SolidBrush(Color.DarkGray);
			this.DashedBluePen = new Pen(Color.Blue);
			this.DashedBluePen.DashStyle = DashStyle.Dash;
			this.DashedGreenPen = new Pen(Color.Green);
			this.DashedGreenPen.DashStyle = DashStyle.Dash;
			this.DashedRedPen = new Pen(Color.Red);
			this.DashedRedPen.DashStyle = DashStyle.Dash;
			this.BluePen = new Pen(Color.Blue);
			this.GreenPen = new Pen(Color.Green);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003F84 File Offset: 0x00002F84
		protected float MaxHistoricalPrice()
		{
			float num = 0f;
			for (int i = 1; i < 8; i++)
			{
				num = Math.Max(num, this.input.OurPrices[this.productIndex, i]);
			}
			return num;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000050A8 File Offset: 0x000040A8
		private void Form_Load(object sender, EventArgs e)
		{
			this.InitializeGraphics();
			this.txtMargin.Text = string.Format("{0:F1}", Math.Min(99.9, (double)(100f * this.input.PricingPolicy.GetMargin(this.productIndex)))).ToString();
			if (this.input.MinCompetitivePrices == null)
			{
				this.lblCompetitorPrices.Visible = false;
				this.lblGlobalPercentage.Visible = false;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000513C File Offset: 0x0000413C
		private void picLegendCanvas_Paint(object sender, PaintEventArgs e)
		{
			this.legend = e.Graphics;
			this.legend.DrawLine(this.DashedBluePen, 4, 8, 78, 8);
			if (this.input.MinCompetitivePrices != null)
			{
				this.legend.DrawLine(this.DashedGreenPen, 92, 8, 162, 8);
			}
			this.legend.FillRectangle(this.DarkGrayBrush, 178, 2, 53, 12);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000051B8 File Offset: 0x000041B8
		private void picGraph_Paint(object sender, PaintEventArgs e)
		{
			float num = 0f;
			float num2 = (float)this.picGraph.Width / 7f - 0.5714286f;
			float y = 0f;
			float y2 = 0f;
			this.graph = e.Graphics;
			this.graph.Clear(SystemColors.Control);
			float num3 = (float)this.picGraph.Height - this.productTypes[this.productIndex].Cost / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
			this.graph.FillRectangle(this.DarkGrayBrush, 0f, num3, (float)this.picGraph.Width, (float)this.picGraph.Height - num3);
			for (int i = 7; i > 0; i--)
			{
				float y3 = (float)this.picGraph.Height - this.input.OurPrices[this.productIndex, i] / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
				float y4 = (float)this.picGraph.Height - this.input.OurPrices[this.productIndex, i - 1] / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
				if (this.input.MinCompetitivePrices != null)
				{
					y = (float)this.picGraph.Height - this.input.MinCompetitivePrices[this.productIndex, i] / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
					y2 = (float)this.picGraph.Height - this.input.MinCompetitivePrices[this.productIndex, i - 1] / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
				}
				try
				{
					this.graph.DrawLine(this.BluePen, num, y3, num + num2, y4);
					if (this.input.MinCompetitivePrices != null)
					{
						this.graph.DrawLine(this.GreenPen, num, y, num + num2, y2);
					}
				}
				catch (Exception)
				{
				}
				num += num2;
			}
			float num4 = (1f - (float)this.sliPrice.Value / (float)this.sliPrice.Maximum) * (float)(this.picGraph.Height - 4);
			try
			{
				this.graph.DrawLine(this.DashedRedPen, 0f, num4, (float)this.picGraph.Width, num4);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000054B0 File Offset: 0x000044B0
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000054C2 File Offset: 0x000044C2
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000054CC File Offset: 0x000044CC
		private void sliPrice_MouseUp(object sender, MouseEventArgs e)
		{
			this.txtMargin.Text = string.Format("{0:F1}", Math.Min(99.9, 100.0 * (1.0 - (double)this.productTypes[this.productIndex].Cost / ((double)((float)this.sliPrice.Value) / 10.0)))).ToString();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00005548 File Offset: 0x00004548
		private void sliPrice_Scroll(object sender, EventArgs e)
		{
			float num = (float)this.sliPrice.Value / 10f;
			float num2 = 1f - this.productTypes[this.productIndex].Cost / num;
			this.myToolTip.SetToolTip(this.sliPrice, string.Format("{0:F1}", Math.Min(99.9, (double)(num2 * 100f))).ToString() + " pts");
			if (this.input.MinCompetitivePrices != null)
			{
				this.lblGlobalPercentage.Text = string.Format("{0:F1}", (double)(num / this.input.MinCompetitivePrices[this.productIndex, 0]) * 100.0).ToString() + "% of Competitor's Prices";
			}
			this.picGraph.Refresh();
			this.labYourPriceValue.Text = Utilities.FC(num, 2, S.I.CurrencyConversion);
			this.labYourCostValue.Text = Utilities.FC(this.productTypes[this.productIndex].Cost, 2, S.I.CurrencyConversion);
			if (S.MF.IsWin98)
			{
				base.BringToFront();
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000569C File Offset: 0x0000469C
		private void txtMargin_TextChanged(object sender, EventArgs e)
		{
			if (!(this.txtMargin.Text == "-") && !(this.txtMargin.Text == "-."))
			{
				bool flag = false;
				try
				{
					if (float.Parse(this.txtMargin.Text) < 100f)
					{
						flag = true;
					}
					else
					{
						this.txtMargin.Text = this.validationString;
						MessageBox.Show("Your value for Margin points must be less than 100.");
						this.txtMargin.Focus();
						this.txtMargin.SelectAll();
					}
				}
				catch (Exception)
				{
					if (this.txtMargin.Text != "")
					{
						this.txtMargin.Text = this.validationString;
						MessageBox.Show("Please enter a valid numeric expression for your amount.");
						this.txtMargin.Focus();
						this.txtMargin.SelectAll();
					}
				}
				finally
				{
					if (flag)
					{
						float num = float.Parse(this.txtMargin.Text) / 100f;
						float num2 = this.productTypes[this.productIndex].Cost / (1f - num);
						this.input.PricingPolicy.SetToCustom(this.productIndex, num, 1f);
						this.input.OurPrices[this.productIndex, 0] = num2;
						this.sliPrice.Maximum = 10 * (int)((double)Math.Max(3f, Math.Max(num2, this.MaxHistoricalPrice())) + 0.65 * (double)num2);
						this.sliPrice.TickFrequency = this.sliPrice.Maximum / 20;
						this.sliPrice.Value = (int)((double)num2 * 10.0);
						this.lblHi.Text = string.Format("{0:C}", (double)((float)this.sliPrice.Maximum) / 10.0).ToString();
						if (this.input.MinCompetitivePrices != null)
						{
							this.lblGlobalPercentage.Text = string.Format("{0:F1}", (double)(num2 / this.input.MinCompetitivePrices[this.productIndex, 0]) * 100.0).ToString() + "% of Competitor's Prices";
						}
						this.labYourPriceValue.Text = Utilities.FC(num2, 2, S.I.CurrencyConversion);
						this.labYourCostValue.Text = Utilities.FC(this.productTypes[this.productIndex].Cost, 2, S.I.CurrencyConversion);
						this.picGraph.Refresh();
					}
				}
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000059A8 File Offset: 0x000049A8
		private void txtMargin_Validating(object sender, CancelEventArgs e)
		{
			if (this.txtMargin.Text == "" || this.txtMargin.Text == "-" || this.txtMargin.Text == "-.")
			{
				MessageBox.Show("Please enter a margin value.");
				e.Cancel = true;
				this.txtMargin.Focus();
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005A24 File Offset: 0x00004A24
		private void txtMargin_Enter(object sender, EventArgs e)
		{
			this.validationString = this.txtMargin.Text;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005A38 File Offset: 0x00004A38
		private void txtMargin_Leave(object sender, EventArgs e)
		{
			try
			{
				this.txtMargin.Text = string.Format("{0:F1}", float.Parse(this.txtMargin.Text)).ToString();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005A90 File Offset: 0x00004A90
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Pricing");
		}

		// Token: 0x0400004D RID: 77
		public frmPricing.Input input;

		// Token: 0x04000052 RID: 82
		protected ProductType[] productTypes;

		// Token: 0x04000053 RID: 83
		protected string validationString;

		// Token: 0x04000054 RID: 84
		protected int productIndex;

		// Token: 0x04000055 RID: 85
		protected Graphics legend;

		// Token: 0x04000056 RID: 86
		protected Graphics graph;

		// Token: 0x04000057 RID: 87
		protected SolidBrush DarkGrayBrush;

		// Token: 0x04000058 RID: 88
		protected Pen DashedBluePen;

		// Token: 0x04000059 RID: 89
		protected Pen DashedGreenPen;

		// Token: 0x0400005A RID: 90
		protected Pen DashedRedPen;

		// Token: 0x0400005B RID: 91
		protected Pen BluePen;

		// Token: 0x0400005C RID: 92
		protected Pen GreenPen;
	}
}
