using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz.Product;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	// Token: 0x0200004D RID: 77
	public partial class frmAdDesignerSimple : Form
	{
		/// <summary>
		/// </summary>
		// Token: 0x060002F2 RID: 754 RVA: 0x00022198 File Offset: 0x00021198
		public frmAdDesignerSimple(ProductType[] ProductTypes, int adNumber)
		{
			this.InitializeComponent();
			this.adNumber = adNumber;
			this.ProductTypes = ProductTypes;
			for (int i = 0; i < ProductTypes.Length; i++)
			{
				Label j = new Label();
				j.Tag = i;
				j.Size = new Size(32, 32);
				j.Cursor = Cursors.Hand;
				j.Image = S.R.GetImage("Prod" + i);
				this.toolTip.SetToolTip(j, ProductTypes[i].Name);
				int row = (int)Math.Floor((double)i / 3.0);
				int col = i % 3;
				j.Location = new Point(col * j.Width + 8, row * j.Height + 8);
				j.Click += this.Prod_Click;
				this.panProd.Height = Math.Max(j.Location.Y + j.Height + 4, this.panProd.Height);
				this.panProd.Controls.Add(j);
			}
			this.input = A.SA.GetAdSimple(S.MF.CurrentEntityID, adNumber);
			this.pnlCanvas.Refresh();
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x000222FC File Offset: 0x000212FC
		private void Prod_Click(object sender, EventArgs e)
		{
			this.input.Ad = new AdSimple(this.adNumber, (int)((Control)sender).Tag);
			this.input.Ad.Price = this.input.OurPrices[this.input.Ad.ProductIndex];
			this.pnlCanvas.Refresh();
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00022B1B File Offset: 0x00021B1B
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Storefront Ads");
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00022B29 File Offset: 0x00021B29
		private void btnDeleteAd_Click(object sender, EventArgs e)
		{
			this.input.Ad = null;
			this.pnlCanvas.Refresh();
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00022B44 File Offset: 0x00021B44
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				A.SA.SetAdSimple(S.MF.CurrentEntityID, this.adNumber, this.input.Ad);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
			base.Close();
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00022BA4 File Offset: 0x00021BA4
		private void pnlCanvas_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(Color.White);
			if (this.input.Ad != null)
			{
				this.input.Ad.DrawWithoutTransform(e.Graphics, new Point(0, 0), this.pnlCanvas.Size, 1f);
			}
			this.btnPricing.Enabled = (A.MF.mnuActionsPricing.Enabled && this.input.Ad != null);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00022C34 File Offset: 0x00021C34
		private void btnPricing_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmPricing(AppConstants.ProductTypes, this.input.Ad.ProductIndex, false);
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
			this.input.OurPrices[this.input.Ad.ProductIndex] = A.SA.GetPrice(A.MF.CurrentEntityID, this.ProductTypes[this.input.Ad.ProductIndex]);
			this.input.Ad.Price = this.input.OurPrices[this.input.Ad.ProductIndex];
			this.pnlCanvas.Refresh();
		}

		// Token: 0x0400028B RID: 651
		private int adNumber;

		// Token: 0x0400028C RID: 652
		protected ProductType[] ProductTypes;

		// Token: 0x0400028D RID: 653
		public frmAdDesignerSimple.Input input;

		// Token: 0x0200004E RID: 78
		[Serializable]
		public struct Input
		{
			// Token: 0x0400028E RID: 654
			public AdSimple Ad;

			// Token: 0x0400028F RID: 655
			public float[] OurPrices;
		}
	}
}
