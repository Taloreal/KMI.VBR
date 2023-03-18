using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x02000022 RID: 34
	public partial class frmPricing : Form
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x0000E62C File Offset: 0x0000D62C
		public frmPricing(ProductType[] productTypes, int productTypeIndex, bool intl)
		{
			this.InitializeComponent();
			this.intl = intl;
			this.numProds = productTypes.Length;
			this.productTypes = productTypes;
			this.chkCustom = new ControlArray(this);
			this.lblProductImage = new ControlArray(this);
			this.lblProductName = new ControlArray(this);
			this.lblPrice = new ControlArray(this);
			this.lblPercentage = new ControlArray(this);
			this.input = ((IBizProductStateAdapter)S.SA).GetPricing(S.MF.CurrentEntityID);
			this.competitorsExist = (this.input.MinCompetitivePrices != null);
			for (int i = 0; i < this.numProds; i++)
			{
				frmPricing.advanced = (frmPricing.advanced || this.input.PricingPolicy.GetCustom(i));
			}
			if (intl)
			{
				this.grpMarginExplanation.Visible = false;
				this.lblMarginPoints.Text = S.R.GetString("Domestic Margin Points:");
				this.labIntlMarginPoints.Visible = true;
				this.txtIntlMargin.Visible = true;
				this.lblPoints2.Visible = true;
				this.grpLegend.Height = 96;
				this.lblYourRecentPrices.Text = S.R.GetString("Domestic Prices");
				this.lblIntlPrices.Visible = true;
				this.picIntlLegend.Visible = true;
			}
			this.inputProductIndex = productTypeIndex;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000E7C4 File Offset: 0x0000D7C4
		protected void SetPrices()
		{
			for (int i = 0; i < this.numProds; i++)
			{
				if (!this.input.PricingPolicy.GetCustom(i))
				{
					this.input.OurPrices[i, 0] = this.productTypes[i].Cost / (1f - this.input.PricingPolicy.GlobalMargin);
					((Label)this.lblPrice[i]).Text = string.Format("{0:F1}", this.OurMargin(i) * 100f) + " pts";
					if (this.competitorsExist)
					{
						((Label)this.lblPercentage[i]).Text = string.Format("{0:F1}", (double)(this.input.OurPrices[i, 0] / this.input.MinCompetitivePrices[i, 0]) * 100.0).ToString() + "% of Competitor";
					}
				}
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000E8F0 File Offset: 0x0000D8F0
		protected void Initializegraphics()
		{
			this.darkGrayBrush = new SolidBrush(Color.DarkGray);
			this.dashedRedPen = new Pen(Color.Red);
			this.dashedRedPen.DashStyle = DashStyle.Dash;
			this.bluePen = new Pen(Color.Blue);
			this.greenPen = new Pen(Color.Green);
			this.purplePen = new Pen(Color.DarkViolet);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000E95C File Offset: 0x0000D95C
		protected void ResizeForm()
		{
			if (frmPricing.advanced)
			{
				base.Width = 768;
				this.btnAdvanced.Text = "&Less <<";
				this.grpCustom.Enabled = true;
			}
			else
			{
				base.Width = 288;
				this.btnAdvanced.Text = "&More >>";
				this.grpCustom.Enabled = false;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000E9D0 File Offset: 0x0000D9D0
		protected void CreateCustomSection()
		{
			for (int i = 0; i < this.numProds; i++)
			{
				int left = 16 + i % 3 * 156;
				int top = 4 + i / 3 * 36;
				this.chkCustom.AddNewControl(new CheckBox());
				((CheckBox)this.chkCustom[i]).Name = "chkCustom" + (i + 1).ToString();
				((CheckBox)this.chkCustom[i]).Width = 16;
				((CheckBox)this.chkCustom[i]).Height = 24;
				((CheckBox)this.chkCustom[i]).Text = "";
				((CheckBox)this.chkCustom[i]).Parent = this.panCustom;
				((CheckBox)this.chkCustom[i]).Left = left;
				((CheckBox)this.chkCustom[i]).Top = top;
			}
			for (int i = 0; i < this.numProds; i++)
			{
				int left = 64 + i % 3 * 156;
				int top = i / 3 * 36;
				this.lblProductName.AddNewControl(new Label());
				((Label)this.lblProductName[i]).Name = "lblProductName" + (i + 1).ToString();
				((Label)this.lblProductName[i]).Cursor = Cursors.Hand;
				((Label)this.lblProductName[i]).ForeColor = Color.Blue;
				((Label)this.lblProductName[i]).AutoSize = true;
				((Label)this.lblProductName[i]).Font = new Font("Microsoft Sans Serif", 7f);
				((Label)this.lblProductName[i]).Parent = this.panCustom;
				((Label)this.lblProductName[i]).Left = left;
				((Label)this.lblProductName[i]).Top = top;
			}
			for (int i = 0; i < this.numProds; i++)
			{
				int left = 32 + i % 3 * 156;
				int top = i / 3 * 36;
				this.lblProductImage.AddNewControl(new Label());
				((Label)this.lblProductImage[i]).Name = "lblProductImage" + (i + 1).ToString();
				((Label)this.lblProductImage[i]).Cursor = Cursors.Hand;
				((Label)this.lblProductImage[i]).Width = 32;
				((Label)this.lblProductImage[i]).Height = 32;
				((Label)this.lblProductImage[i]).Image = S.R.GetImage(ProductType.ImageBaseName + i);
				((Label)this.lblProductImage[i]).ImageAlign = ContentAlignment.MiddleCenter;
				((Label)this.lblProductImage[i]).Text = "";
				((Label)this.lblProductImage[i]).Parent = this.panCustom;
				((Label)this.lblProductImage[i]).Left = left;
				((Label)this.lblProductImage[i]).Top = top;
			}
			for (int i = 0; i < this.numProds; i++)
			{
				int left = 64 + i % 3 * 156;
				int top = 12 + i / 3 * 36;
				this.lblPrice.AddNewControl(new Label());
				((Label)this.lblPrice[i]).Name = "lblPrice" + (i + 1).ToString();
				((Label)this.lblPrice[i]).Cursor = Cursors.Hand;
				((Label)this.lblPrice[i]).ForeColor = Color.FromArgb(64, 64, 64);
				((Label)this.lblPrice[i]).AutoSize = true;
				((Label)this.lblPrice[i]).Font = new Font("Microsoft Sans Serif", 7f);
				((Label)this.lblPrice[i]).Parent = this.panCustom;
				((Label)this.lblPrice[i]).Left = left;
				((Label)this.lblPrice[i]).Top = top;
			}
			for (int i = 0; i < this.numProds; i++)
			{
				int left = 64 + i % 3 * 156;
				int top = 24 + i / 3 * 36;
				this.lblPercentage.AddNewControl(new Label());
				((Label)this.lblPercentage[i]).Name = "lblPercentage" + (i + 1).ToString();
				((Label)this.lblPercentage[i]).Cursor = Cursors.Hand;
				((Label)this.lblPercentage[i]).ForeColor = Color.FromArgb(64, 64, 64);
				((Label)this.lblPercentage[i]).AutoSize = true;
				((Label)this.lblPercentage[i]).Font = new Font("Microsoft Sans Serif", 7f);
				((Label)this.lblPercentage[i]).Parent = this.panCustom;
				((Label)this.lblPercentage[i]).Left = left;
				((Label)this.lblPercentage[i]).Top = top;
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000F00C File Offset: 0x0000E00C
		protected void RegisterEvents()
		{
			for (int i = 0; i < this.numProds; i++)
			{
				((CheckBox)this.chkCustom[i]).Click += this.chkCustom_Click;
				((Label)this.lblProductImage[i]).Click += this.CustomLabels_Click;
				((Label)this.lblProductName[i]).Click += this.CustomLabels_Click;
				((Label)this.lblPrice[i]).Click += this.CustomLabels_Click;
				((Label)this.lblPercentage[i]).Click += this.CustomLabels_Click;
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000F0E8 File Offset: 0x0000E0E8
		protected float GetAveragePrice()
		{
			return this.GetAveragePrice(0);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000F104 File Offset: 0x0000E104
		protected float GetAveragePrice(int SpecificWeek)
		{
			float num = 0f;
			for (int i = 0; i < this.numProds; i++)
			{
				num += this.input.OurPrices[i, SpecificWeek];
			}
			return num / (float)this.numProds;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000F150 File Offset: 0x0000E150
		protected float GetAverageCompetitorPrice()
		{
			return this.GetAverageCompetitorPrice(0);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000F16C File Offset: 0x0000E16C
		protected float GetAverageCompetitorPrice(int SpecificWeek)
		{
			float num = 0f;
			if (this.competitorsExist)
			{
				for (int i = 0; i < this.numProds; i++)
				{
					num += this.input.MinCompetitivePrices[i, SpecificWeek];
				}
			}
			return num / (float)this.numProds;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000F1C4 File Offset: 0x0000E1C4
		protected float GetAverageCost()
		{
			float num = 0f;
			for (int i = 0; i < this.numProds; i++)
			{
				num += this.productTypes[i].Cost;
			}
			return num / (float)this.numProds;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000F20C File Offset: 0x0000E20C
		protected float MaxHistoricalPrice()
		{
			float num = 0f;
			for (int i = 1; i < 8; i++)
			{
				num = Math.Max(num, this.GetAveragePrice(i));
			}
			return num;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00010634 File Offset: 0x0000F634
		private void Form_Load(object sender, EventArgs e)
		{
			this.ResizeForm();
			this.Initializegraphics();
			this.CreateCustomSection();
			this.RegisterEvents();
			for (int i = 0; i < this.numProds; i++)
			{
				((Label)this.lblProductName[i]).Text = this.productTypes[i].Name;
				((CheckBox)this.chkCustom[i]).Checked = this.input.PricingPolicy.GetCustom(i);
				((Label)this.lblPrice[i]).Text = string.Format("{0:F1}", this.OurMargin(i) * 100f) + " pts";
				if (this.competitorsExist)
				{
					((Label)this.lblPercentage[i]).Text = string.Format("{0:F1}", (double)this.input.OurPrices[i, 0] / Math.Max(0.01, (double)this.input.MinCompetitivePrices[i, 0]) * 100.0).ToString() + "% of Competitor";
				}
				else
				{
					((Label)this.lblPercentage[i]).Visible = false;
				}
			}
			this.lblGlobalPercentage.Visible = this.competitorsExist;
			this.lblCompetitorPrices.Visible = this.competitorsExist;
			this.lblLastWeeks.Text = "Last " + 8.ToString() + " Weeks";
			this.txtMargin.Text = string.Format("{0:F1}", (double)this.input.PricingPolicy.GlobalMargin * 100.0).ToString();
			if (this.inputProductIndex > -1)
			{
				this.Customize(this.inputProductIndex);
				this.btnOK.PerformClick();
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00010850 File Offset: 0x0000F850
		private void picLegendCanvas_Paint(object sender, PaintEventArgs e)
		{
			this.legend = e.Graphics;
			this.legend.DrawLine(this.bluePen, 4, 8, 78, 8);
			if (this.competitorsExist)
			{
				this.legend.DrawLine(this.greenPen, 92, 8, 162, 8);
			}
			this.legend.FillRectangle(this.darkGrayBrush, 178, 2, 53, 12);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000108C5 File Offset: 0x0000F8C5
		private void picIntlLegend_Paint(object sender, PaintEventArgs e)
		{
			this.legend = e.Graphics;
			this.legend.DrawLine(this.purplePen, 4, 8, 78, 8);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000108EC File Offset: 0x0000F8EC
		private void picGraph_Paint(object sender, PaintEventArgs e)
		{
			float num = 0f;
			float num2 = (float)this.picGraph.Width / 7f - 0.5714286f;
			float y = 0f;
			float y2 = 0f;
			this.graph = e.Graphics;
			this.graph.Clear(SystemColors.Control);
			float num3 = (float)this.picGraph.Height - this.GetAverageCost() / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
			this.graph.FillRectangle(this.darkGrayBrush, 0f, num3, (float)this.picGraph.Width, (float)this.picGraph.Height - num3);
			for (int i = 7; i > 0; i--)
			{
				float y3 = (float)this.picGraph.Height - this.GetAveragePrice(i) / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
				float y4 = (float)this.picGraph.Height - this.GetAveragePrice(i - 1) / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
				if (this.competitorsExist)
				{
					y = (float)this.picGraph.Height - this.GetAverageCompetitorPrice(i) / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
					y2 = (float)this.picGraph.Height - this.GetAverageCompetitorPrice(i - 1) / ((float)this.sliPrice.Maximum / 10f) * (float)this.picGraph.Height;
				}
				try
				{
					this.graph.DrawLine(this.bluePen, num, y3, num + num2, y4);
					if (this.competitorsExist)
					{
						this.graph.DrawLine(this.greenPen, num, y, num + num2, y2);
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
				this.graph.DrawLine(this.dashedRedPen, 0f, num4, (float)this.picGraph.Width, num4);
			}
			catch (Exception)
			{
				throw new Exception("Error in drawing graph on frmPricing");
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00010B94 File Offset: 0x0000FB94
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				float[] array = new float[this.numProds];
				for (int i = 0; i < this.numProds; i++)
				{
					array[i] = this.input.OurPrices[i, 0];
				}
				((IBizProductStateAdapter)S.SA).SetPricing(S.MF.CurrentEntityID, this.input.PricingPolicy);
				base.Close();
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2);
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00010C28 File Offset: 0x0000FC28
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00010C34 File Offset: 0x0000FC34
		private void btnAdvanced_Click(object sender, EventArgs e)
		{
			if (this.intl)
			{
				MessageBox.Show(S.R.GetString("For simplicity, product-specific margins cannot be set in international simulations."), S.R.GetString("International Sim"));
			}
			else
			{
				frmPricing.advanced = !frmPricing.advanced;
				this.ResizeForm();
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00010C8C File Offset: 0x0000FC8C
		private void CustomLabels_Click(object sender, EventArgs e)
		{
			int index;
			if (this.chkCustom.IndexOf(sender) != -1)
			{
				index = this.chkCustom.IndexOf(sender);
			}
			else if (this.lblProductImage.IndexOf(sender) != -1)
			{
				index = this.lblProductImage.IndexOf(sender);
			}
			else if (this.lblProductName.IndexOf(sender) != -1)
			{
				index = this.lblProductName.IndexOf(sender);
			}
			else if (this.lblPrice.IndexOf(sender) != -1)
			{
				index = this.lblPrice.IndexOf(sender);
			}
			else if (this.lblPercentage.IndexOf(sender) != -1)
			{
				index = this.lblPercentage.IndexOf(sender);
			}
			else
			{
				index = 0;
			}
			this.Customize(index);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00010D60 File Offset: 0x0000FD60
		private void Customize(int index)
		{
			frmPricingCustom frmPricingCustom = new frmPricingCustom(this.productTypes, index, (frmPricing.Input)Utilities.DeepCopyBySerialization(this.input));
			frmPricingCustom.Text = "Custom Pricing - " + this.lblProductName[index].Text;
			if (frmPricingCustom.ShowDialog() == DialogResult.OK)
			{
				this.input = frmPricingCustom.input;
				((Label)this.lblPrice[index]).Text = string.Format("{0:F1}", this.OurMargin(index) * 100f) + " pts";
				if (this.competitorsExist)
				{
					((Label)this.lblPercentage[index]).Text = string.Format("{0:F1}", (double)this.input.OurPrices[index, 0] / Math.Max(0.01, (double)this.input.MinCompetitivePrices[index, 0]) * 100.0).ToString() + "% of Competitor";
				}
				((CheckBox)this.chkCustom[index]).Checked = true;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00010EAC File Offset: 0x0000FEAC
		private void chkCustom_Click(object sender, EventArgs e)
		{
			int num = this.chkCustom.IndexOf(sender);
			if (!((CheckBox)sender).Checked)
			{
				this.input.PricingPolicy.SetToGlobal(num);
				((Label)this.lblPrice[num]).Text = string.Format("{0:F1}", this.OurMargin(num) * 100f) + " pts";
				if (this.competitorsExist)
				{
					((Label)this.lblPercentage[num]).Text = string.Format("{0:F1}", (double)this.input.OurPrices[num, 0] / Math.Max(0.01, (double)this.input.MinCompetitivePrices[num, 0]) * 100.0).ToString() + "% of Competitor";
				}
			}
			else
			{
				this.Customize(num);
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00010FB8 File Offset: 0x0000FFB8
		private void sliPrice_MouseUp(object sender, MouseEventArgs e)
		{
			this.txtMargin.Text = string.Format("{0:F1}", Math.Min(99.9, 100.0 * (1.0 - (double)this.GetAverageCost() / ((double)((float)this.sliPrice.Value) / 10.0)))).ToString();
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00011028 File Offset: 0x00010028
		private void sliPrice_Scroll(object sender, EventArgs e)
		{
			float num = (float)this.sliPrice.Value / 10f;
			float num2 = 1f - this.GetAverageCost() / Math.Max(0.01f, num);
			this.myToolTip.SetToolTip(this.sliPrice, string.Format("{0:F1}", Math.Min(99.9, (double)(num2 * 100f))).ToString() + " pts");
			for (int i = 0; i < this.numProds; i++)
			{
				if (!this.input.PricingPolicy.GetCustom(i))
				{
					((Label)this.lblPrice[i]).Text = string.Format("{0:F1}", num2 * 100f) + " pts";
					((Label)this.lblPercentage[i]).Text = string.Format("{0:F1}", (double)(num / this.GetAverageCompetitorPrice()) * 100.0).ToString() + "% of Competitor";
				}
			}
			this.lblGlobalPercentage.Text = string.Format("{0:F1}", num / this.GetAverageCompetitorPrice() * 100f).ToString() + "% of Competitor's Prices";
			this.picGraph.Refresh();
			if (S.MF.IsWin98)
			{
				base.BringToFront();
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000111BC File Offset: 0x000101BC
		private void txtMargin_TextChanged(object sender, EventArgs e)
		{
			bool flag = false;
			try
			{
				if (!(this.txtMargin.Text == "-") && !(this.txtMargin.Text == "-."))
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
			}
			catch (Exception)
			{
				if (this.txtMargin.Text != "")
				{
					this.txtMargin.Text = this.validationString;
					MessageBox.Show("Please enter a postive or negative number for your amount.");
					this.txtMargin.Focus();
					this.txtMargin.SelectAll();
				}
			}
			finally
			{
				if (flag)
				{
					this.input.PricingPolicy.GlobalMargin = float.Parse(this.txtMargin.Text) / 100f;
					this.SetPrices();
					this.sliPrice.Maximum = 10 * (int)(Math.Max(3.0, (double)Math.Max(this.GetAveragePrice(), this.MaxHistoricalPrice())) + 0.65 * (double)this.GetAveragePrice());
					this.sliPrice.TickFrequency = this.sliPrice.Maximum / 20;
					this.sliPrice.Value = (int)((double)this.GetAveragePrice() * 10.0);
					this.lblHi.Text = string.Format("{0:C}", (double)((float)this.sliPrice.Maximum) / 10.0).ToString();
					this.lblGlobalPercentage.Text = string.Format("{0:F1}", (double)(this.GetAveragePrice() / this.GetAverageCompetitorPrice()) * 100.0).ToString() + "% of Competitor's Prices";
					this.picGraph.Refresh();
				}
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00011438 File Offset: 0x00010438
		private void txtMargin_Validating(object sender, CancelEventArgs e)
		{
			if (this.txtMargin.Text == "" || this.txtMargin.Text == "-" || this.txtMargin.Text == "-.")
			{
				MessageBox.Show("Please enter a postive or negative margin value.");
				e.Cancel = true;
				this.txtMargin.Focus();
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000114B4 File Offset: 0x000104B4
		private void txtMargin_Enter(object sender, EventArgs e)
		{
			this.validationString = this.txtMargin.Text;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000114C8 File Offset: 0x000104C8
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

		// Token: 0x06000112 RID: 274 RVA: 0x00011520 File Offset: 0x00010520
		private float OurMargin(int index)
		{
			return 1f - this.productTypes[index].Cost / Math.Max(0.01f, this.input.OurPrices[index, 0]);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00011562 File Offset: 0x00010562
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Pricing");
		}

		// Token: 0x0400014D RID: 333
		public const int RECENT_WEEKS = 8;

		// Token: 0x0400014E RID: 334
		protected int inputProductIndex = -1;

		// Token: 0x0400014F RID: 335
		protected bool competitorsExist;

		// Token: 0x04000150 RID: 336
		protected frmPricing.Input input;

		// Token: 0x04000151 RID: 337
		public static bool advanced;

		// Token: 0x04000152 RID: 338
		protected string validationString;

		// Token: 0x04000153 RID: 339
		protected Graphics legend;

		// Token: 0x04000154 RID: 340
		protected Graphics graph;

		// Token: 0x04000155 RID: 341
		protected SolidBrush darkGrayBrush;

		// Token: 0x04000156 RID: 342
		protected Pen dashedRedPen;

		// Token: 0x04000157 RID: 343
		protected Pen bluePen;

		// Token: 0x04000158 RID: 344
		protected Pen greenPen;

		// Token: 0x04000159 RID: 345
		protected Pen purplePen;

		// Token: 0x0400015A RID: 346
		protected ControlArray chkCustom;

		// Token: 0x0400015B RID: 347
		protected ControlArray lblProductImage;

		// Token: 0x0400015C RID: 348
		protected ControlArray lblProductName;

		// Token: 0x0400015D RID: 349
		protected ControlArray lblPrice;

		// Token: 0x0400015E RID: 350
		protected ControlArray lblPercentage;

		// Token: 0x0400017E RID: 382
		protected int numProds = 0;

		// Token: 0x0400017F RID: 383
		protected ProductType[] productTypes;

		// Token: 0x04000180 RID: 384
		protected bool intl = false;

		// Token: 0x02000023 RID: 35
		[Serializable]
		public struct Input
		{
			// Token: 0x04000181 RID: 385
			public PricingPolicy PricingPolicy;

			// Token: 0x04000182 RID: 386
			public float[,] OurPrices;

			// Token: 0x04000183 RID: 387
			public float[,] MinCompetitivePrices;
		}
	}
}
