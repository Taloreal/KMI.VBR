using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x02000010 RID: 16
	public partial class frmPurchasingCustom : Form
	{
		// Token: 0x0600004B RID: 75 RVA: 0x00006668 File Offset: 0x00005668
		public frmPurchasingCustom(ProductType[] productTypes, int productTypeIndex, int maxPurchasingUnits, int AmountToOrder, int WhenToOrder, float AverageDailySales)
		{
			this.InitializeComponent();
			this.amountToOrder = AmountToOrder;
			this.whenToOrder = WhenToOrder;
			this.averageDailySales = AverageDailySales;
			this.productTypes = productTypes;
			this.productTypeIndex = productTypeIndex;
			this.maxPurchasingUnits = maxPurchasingUnits;
			this.Text = this.Text + " - " + productTypes[productTypeIndex].Name;
			Button button = this.btnDiscard;
			button.Text = button.Text + " " + productTypes[productTypeIndex].Name;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000066F5 File Offset: 0x000056F5
		protected void InitializeGraphics()
		{
			this.redBrush = new SolidBrush(Color.Red);
			this.darkGrayPen = new Pen(Color.FromArgb(64, 64, 64));
			this.darkGrayPen.DashStyle = DashStyle.Dash;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00007533 File Offset: 0x00006533
		private void Form_Load(object sender, EventArgs e)
		{
			this.InitializeGraphics();
			this.txtUnits.Text = this.amountToOrder.ToString();
			this.txtBelow.Text = this.whenToOrder.ToString();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000756B File Offset: 0x0000656B
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000757D File Offset: 0x0000657D
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00007588 File Offset: 0x00006588
		private void sliAmount_MouseUp(object sender, MouseEventArgs e)
		{
			this.txtUnits.Text = this.sliAmount.Value.ToString();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000075B8 File Offset: 0x000065B8
		private void sliAmount_Scroll(object sender, EventArgs e)
		{
			this.myToolTip.SetToolTip(this.sliAmount, this.sliAmount.Value + " Units");
			this.picBarGraph.Refresh();
			if (S.MF.IsWin98)
			{
				base.BringToFront();
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00007616 File Offset: 0x00006616
		private void picLegendCanvas_Paint(object sender, PaintEventArgs e)
		{
			this.legend = e.Graphics;
			this.legend.DrawLine(this.darkGrayPen, 16, 8, 86, 8);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00007640 File Offset: 0x00006640
		private void picBarGraph_Paint(object sender, PaintEventArgs e)
		{
			this.barGraph = e.Graphics;
			int height = this.picBarGraph.Height;
			int x = 30;
			int width = 44;
			int num = (int)((float)this.sliAmount.Value / (float)this.sliAmount.Maximum * (float)height);
			int y = height - num;
			int num2 = (int)Math.Max(5f, this.averageDailySales / (float)this.sliAmount.Maximum * (float)height);
			int num3 = height - num2;
			try
			{
				this.barGraph.Clear(SystemColors.Control);
				this.barGraph.FillRectangle(this.redBrush, x, y, width, num);
				this.barGraph.DrawLine(this.darkGrayPen, 0, num3, this.picBarGraph.Width, num3);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00007720 File Offset: 0x00006720
		private void txtBelow_TextChanged(object sender, EventArgs e)
		{
			bool flag = false;
			try
			{
				if (long.Parse(this.txtBelow.Text) >= 0L && long.Parse(this.txtBelow.Text) < (long)this.maxPurchasingUnits)
				{
					flag = true;
				}
				else
				{
					this.txtBelow.Text = this.validationString;
					MessageBox.Show("You must enter an amount greater than or equal to 0 and less than " + Utilities.FU(this.maxPurchasingUnits) + ".");
					this.txtBelow.Focus();
					this.txtBelow.SelectAll();
				}
			}
			catch (Exception)
			{
				if (this.txtBelow.Text != "")
				{
					this.txtBelow.Text = this.validationString;
					MessageBox.Show("Please enter a valid numeric expression for your amount.");
					this.txtBelow.Focus();
					this.txtBelow.SelectAll();
				}
			}
			finally
			{
				if (flag)
				{
					this.whenToOrder = int.Parse(this.txtBelow.Text);
				}
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00007858 File Offset: 0x00006858
		private void txtBelow_Enter(object sender, EventArgs e)
		{
			this.validationString = this.txtBelow.Text;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000786C File Offset: 0x0000686C
		private void txtBelow_Validating(object sender, CancelEventArgs e)
		{
			if (this.txtBelow.Text == "")
			{
				MessageBox.Show("Please enter an amount at which you would like to re-order your products.");
				e.Cancel = true;
				this.txtBelow.Focus();
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000078B8 File Offset: 0x000068B8
		private void txtUnits_TextChanged(object sender, EventArgs e)
		{
			bool flag = false;
			try
			{
				if (long.Parse(this.txtUnits.Text) >= 0L && long.Parse(this.txtUnits.Text) < (long)this.maxPurchasingUnits)
				{
					flag = true;
				}
				else
				{
					this.txtUnits.Text = this.validationString;
					MessageBox.Show("You must enter an amount greater than or equal to 0 and less than " + Utilities.FU(this.maxPurchasingUnits) + ".");
					this.txtUnits.Focus();
					this.txtUnits.SelectAll();
				}
			}
			catch (Exception)
			{
				if (this.txtUnits.Text != "")
				{
					this.txtUnits.Text = this.validationString;
					MessageBox.Show("Please enter a valid numeric expression for your amount.");
					this.txtUnits.Focus();
					this.txtUnits.SelectAll();
				}
			}
			finally
			{
				if (flag)
				{
					this.amountToOrder = int.Parse(this.txtUnits.Text);
					this.sliAmount.Maximum = Math.Max(this.amountToOrder, 500) + 250;
					this.sliAmount.TickFrequency = this.sliAmount.Maximum / 20;
					this.sliAmount.Value = this.amountToOrder;
					this.lblHi.Text = this.sliAmount.Maximum.ToString();
					this.picBarGraph.Refresh();
				}
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00007A70 File Offset: 0x00006A70
		private void txtUnits_Enter(object sender, EventArgs e)
		{
			this.validationString = this.txtUnits.Text;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00007A84 File Offset: 0x00006A84
		private void txtUnits_Validating(object sender, CancelEventArgs e)
		{
			if (this.txtUnits.Text == "")
			{
				MessageBox.Show("Please enter a target inventory level.");
				e.Cancel = true;
				this.txtUnits.Focus();
			}
		}

		// Token: 0x1700000A RID: 10
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00007ACF File Offset: 0x00006ACF
		public ProductType ProductType
		{
			set
			{
				this.productType = value;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00007ADC File Offset: 0x00006ADC
		private void btnDiscard_Click(object sender, EventArgs e)
		{
			try
			{
				((IBizProductStateAdapter)S.SA).DiscardAllProduct(S.MF.CurrentEntityID, this.productTypeIndex);
				S.MF.UpdateView();
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00007B30 File Offset: 0x00006B30
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Purchasing");
		}

		// Token: 0x04000082 RID: 130
		protected ProductType productType;

		// Token: 0x04000083 RID: 131
		public int amountToOrder;

		// Token: 0x04000084 RID: 132
		public int whenToOrder;

		// Token: 0x04000085 RID: 133
		protected ProductType[] productTypes;

		// Token: 0x04000086 RID: 134
		protected int productTypeIndex;

		// Token: 0x04000087 RID: 135
		protected int maxPurchasingUnits;

		// Token: 0x04000088 RID: 136
		protected float averageDailySales;

		// Token: 0x04000089 RID: 137
		protected string validationString;

		// Token: 0x0400008A RID: 138
		protected Graphics legend;

		// Token: 0x0400008B RID: 139
		protected Graphics barGraph;

		// Token: 0x0400008C RID: 140
		protected SolidBrush redBrush;

		// Token: 0x0400008D RID: 141
		protected Pen darkGrayPen;
	}
}
