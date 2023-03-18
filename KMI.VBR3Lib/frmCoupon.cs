using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmCoupon.
	/// </summary>
	// Token: 0x02000022 RID: 34
	public partial class frmCoupon : Form
	{
		// Token: 0x060000DC RID: 220 RVA: 0x0000D1A8 File Offset: 0x0000C1A8
		public frmCoupon(float[] discounts)
		{
			this.InitializeComponent();
			if (discounts != null)
			{
				this.discounts = (float[])discounts.Clone();
			}
			else
			{
				this.discounts = new float[25];
			}
			this.cboProduct.Items.Add("{All}");
			for (int i = 0; i < 25; i++)
			{
				this.cboProduct.Items.Add(AppConstants.ProductTypes[i].Name);
			}
			this.cboProduct.SelectedIndex = 0;
			this.labValidFor.Text = "All coupons valid for " + 7 + " days.";
			this.picCoupons.Refresh();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000DA28 File Offset: 0x0000CA28
		private void picCoupons_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Brush brush = new SolidBrush(Color.Black);
			Pen pen = new Pen(Color.DarkGray, 1f);
			Font offFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold | FontStyle.Italic);
			Font nameFont = new Font("Microsoft Sans Serif", 7f);
			int maxImageWidth = 0;
			int maxImageHeight = 0;
			int maxNameWidth = 0;
			int maxNameHeight = 0;
			for (int i = 0; i < 25; i++)
			{
				maxImageWidth = Math.Max(maxImageWidth, A.R.GetImage("Prod" + i).Width);
				maxImageHeight = Math.Max(maxImageHeight, A.R.GetImage("Prod" + i).Height);
				maxNameWidth = (int)Math.Max((float)maxNameWidth, g.MeasureString(AppConstants.ProductTypes[i].Name, nameFont).Width);
				maxNameHeight = (int)Math.Max((float)maxNameHeight, g.MeasureString(AppConstants.ProductTypes[i].Name, nameFont).Height);
			}
			int couponWidth = maxImageWidth + maxNameWidth + 6;
			int couponHeight = maxImageHeight + 4;
			g.DrawRectangle(pen, 0, 0, this.picCoupons.Width - 1, this.picCoupons.Height - 1);
			g.DrawLine(pen, 0, 0, this.picCoupons.Width / 2, this.picCoupons.Height / 3);
			g.DrawLine(pen, this.picCoupons.Width, 0, this.picCoupons.Width / 2, this.picCoupons.Height / 3);
			int j = 0;
			for (int i = 0; i < 25; i++)
			{
				if (this.discounts[i] > 0f)
				{
					int y = j % 6 * (couponHeight - 4) + 8;
					int x = j / 6 * (couponWidth + 12) + j % 6 * 3 * 2 + 4;
					j++;
					g.FillRectangle(new SolidBrush(Color.Yellow), x, y, couponWidth, couponHeight);
					g.DrawRectangle(pen, x, y, couponWidth, couponHeight);
					Bitmap prod = A.R.GetImage("Prod" + i);
					g.DrawImage(prod, x + 2 + (maxImageWidth - prod.Width) / 2, y + 2 + (maxImageHeight - prod.Height) / 2);
					g.DrawString(AppConstants.ProductTypes[i].Name, nameFont, brush, (float)(x + maxImageWidth + 2), (float)(y + couponHeight - maxNameHeight - 4));
					g.DrawString((this.discounts[i] * 100f).ToString() + "% Off!", offFont, brush, (float)(x + maxImageWidth + 2), (float)(y + 2));
				}
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000DD0C File Offset: 0x0000CD0C
		private void btnInsertCoupons_Click(object sender, EventArgs e)
		{
			if (this.cboProduct.SelectedIndex == 0)
			{
				for (int i = 0; i < 25; i++)
				{
					this.discounts[i] = (float)this.updPercentOff.Value / 100f;
				}
			}
			else
			{
				this.discounts[this.cboProduct.SelectedIndex - 1] = (float)this.updPercentOff.Value / 100f;
			}
			this.picCoupons.Refresh();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000DD9C File Offset: 0x0000CD9C
		private void btnClear_Click(object sender, EventArgs e)
		{
			this.discounts = new float[25];
			this.picCoupons.Refresh();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000DDB8 File Offset: 0x0000CDB8
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000DDCA File Offset: 0x0000CDCA
		private void button4_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Direct Mail");
		}

		// Token: 0x040000F6 RID: 246
		public float[] discounts;

		// Token: 0x040000FB RID: 251
		protected bool dirty = false;
	}
}
