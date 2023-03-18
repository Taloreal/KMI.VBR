using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for AdSimple.
	/// </summary>
	// Token: 0x02000040 RID: 64
	[Serializable]
	public class AdSimple : Drawable
	{
		// Token: 0x060001F3 RID: 499 RVA: 0x0001D29C File Offset: 0x0001C29C
		public AdSimple(int index, int productIndex) : base(new Point(0, 0), "")
		{
			this.ProductIndex = productIndex;
			this.Index = index;
			this.clickString = " ";
			base.ToolTipText = A.R.GetString("Ad for {0}", new object[]
			{
				AppConstants.ProductTypes[this.ProductIndex].Name
			});
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0001D310 File Offset: 0x0001C310
		public override bool HitTest(int x, int y)
		{
			Point p = AdSimple.Ad_Locations[this.Index];
			Size s = AdSimple.Ad_Size;
			return x > p.X && x < p.X + s.Width && y > p.Y - (x - p.X) / 2 && y < p.Y + s.Height - (x - p.X) / 2;
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0001D394 File Offset: 0x0001C394
		public override void Draw(Graphics g)
		{
			Size s = AdSimple.Ad_Size;
			float scale = (float)s.Height / 360f;
			Matrix oldTransform = g.Transform;
			Point p = AdSimple.Ad_Locations[this.Index];
			Rectangle bounds = new Rectangle(p.X, p.Y, s.Width, s.Height);
			Matrix transform = new Matrix(bounds, new Point[]
			{
				new Point(p.X, p.Y),
				new Point(p.X + s.Width, p.Y - s.Width / 2),
				new Point(p.X, p.Y + s.Height)
			});
			g.Transform = transform;
			this.DrawWithoutTransform(g, p, s, scale);
			g.Transform = oldTransform;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0001D4A4 File Offset: 0x0001C4A4
		public void DrawWithoutTransform(Graphics g, Point p, Size s, float scale)
		{
			Font font = new Font("Arial", 14f * scale);
			Font font2 = new Font("Arial", 24f * scale);
			SolidBrush brush = new SolidBrush(Color.White);
			SolidBrush brush2 = new SolidBrush(Color.Black);
			Pen pen = new Pen(Color.Gray, 1f);
			StringFormat sfc = new StringFormat();
			sfc.Alignment = StringAlignment.Center;
			int i = 120;
			g.FillRectangle(brush, p.X, p.Y, s.Width, s.Height);
			g.DrawRectangle(pen, p.X, p.Y, s.Width, s.Height);
			string tagLine = A.R.GetString("Great Deal!");
			string name = AppConstants.ProductTypes[this.ProductIndex].Name;
			string price = Utilities.FC(this.Price, 2, A.I.CurrencyConversion);
			Bitmap temp = S.R.GetImage("ProdLarge" + this.ProductIndex);
			Bitmap bmp = new Bitmap(temp, (int)((float)temp.Width * scale), (int)((float)temp.Height * scale));
			Size tagLineSize = Size.Round(g.MeasureString(tagLine, font2));
			Size nameSize = Size.Round(g.MeasureString(name, font));
			Size priceSize = Size.Round(g.MeasureString(price, font2));
			g.DrawString(tagLine, font2, brush2, (float)p.X + (float)i * scale, (float)p.Y + 20f * scale, sfc);
			g.DrawString(name, font, brush2, (float)p.X + (float)i * scale, (float)p.Y + 90f * scale, sfc);
			g.DrawImage(bmp, (float)p.X + (240f * scale - (float)bmp.Width) / 2f, (float)p.Y + 130f * scale);
			g.DrawString(price, font2, brush2, (float)p.X + (float)i * scale, (float)p.Y + 300f * scale, sfc);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0001D6CC File Offset: 0x0001C6CC
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (A.MF.mnuActionsPromotionStorefrontAds.Enabled)
			{
				try
				{
					Form f = new frmAdDesignerSimple(AppConstants.ProductTypes, this.Index);
					f.ShowDialog(S.MF);
					S.MF.UpdateView();
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
				}
			}
		}

		// Token: 0x040001E6 RID: 486
		public int ProductIndex = -1;

		// Token: 0x040001E7 RID: 487
		public int Index;

		// Token: 0x040001E8 RID: 488
		public float Price;

		// Token: 0x040001E9 RID: 489
		public static int MaxAds = 3;

		// Token: 0x040001EA RID: 490
		public static Point[] Ad_Locations = new Point[]
		{
			new Point(311, 355),
			new Point(395, 313),
			new Point(553, 234)
		};

		// Token: 0x040001EB RID: 491
		public static Size Ad_Size = new Size(59, 127);
	}
}
