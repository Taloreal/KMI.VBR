using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x0200000E RID: 14
	[Serializable]
	public class Ad : Drawable
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00005A9E File Offset: 0x00004A9E
		public Ad() : base(new Point(0, 0), "")
		{
			this.clickString = " ";
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005AD8 File Offset: 0x00004AD8
		public override bool HitTest(int x, int y)
		{
			Point point = Ad.Ad_Locations[this.Index];
			Size ad_Size = Ad.Ad_Size;
			return x > point.X && x < point.X + ad_Size.Width && y > point.Y - (x - point.X) / 2 && y < point.Y + ad_Size.Height - (x - point.X) / 2;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005B5C File Offset: 0x00004B5C
		public override void Draw(Graphics g)
		{
			float num = (float)Ad.Ad_Size.Height / 360f;
			Matrix transform = g.Transform;
			Point point = Ad.Ad_Locations[this.Index];
			Size ad_Size = Ad.Ad_Size;
			Rectangle rect = new Rectangle(point.X, point.Y, ad_Size.Width, ad_Size.Height);
			Matrix transform2 = new Matrix(rect, new Point[]
			{
				new Point(point.X, point.Y),
				new Point(point.X + ad_Size.Width, point.Y - ad_Size.Width / 2),
				new Point(point.X, point.Y + ad_Size.Height)
			});
			g.Transform = transform2;
			SolidBrush brush = new SolidBrush(Color.White);
			Pen pen = new Pen(Color.Purple, 2f);
			g.FillRectangle(brush, point.X, point.Y, ad_Size.Width, ad_Size.Height);
			g.DrawRectangle(pen, point.X, point.Y, ad_Size.Width, ad_Size.Height);
			foreach (object obj in this.TextAdElements)
			{
				TextAdElement textAdElement = (TextAdElement)obj;
				brush = new SolidBrush(textAdElement.Color);
				Font font = new Font(textAdElement.FontName, textAdElement.FontSize * num, frmAdDesigner.FontStyleFromBools(textAdElement.Bold, textAdElement.Italic, textAdElement.Underline));
				g.DrawString(textAdElement.Text, font, brush, (float)point.X + num * (float)textAdElement.Location.X, (float)point.Y + num * (float)textAdElement.Location.Y);
			}
			brush = new SolidBrush(Color.Black);
			foreach (object obj2 in this.GraphicAdElements)
			{
				GraphicAdElement graphicAdElement = (GraphicAdElement)obj2;
				float num2 = (float)point.X + num * (float)graphicAdElement.Location.X;
				float num3 = (float)point.Y + num * (float)graphicAdElement.Location.Y;
				Font font = new Font("Microsoft Sans Serif", GraphicAdElement.Fonts[(int)graphicAdElement.Size].Size * num);
				Bitmap image = S.R.GetImage("ProdLarge" + graphicAdElement.ProductType.Index);
				float num4 = GraphicAdElement.ImageScales[(int)graphicAdElement.Size];
				Bitmap bitmap = new Bitmap(image, (int)((float)image.Width * num4 * num), (int)((float)image.Height * num4 * num));
				string text = Utilities.FC(graphicAdElement.Price, 2, S.I.CurrencyConversion);
				Size size = Size.Round(g.MeasureString(graphicAdElement.ProductType.Name, font));
				Size size2 = bitmap.Size;
				Size size3 = Size.Round(g.MeasureString(text, font));
				float num5 = (float)Math.Max(size.Width, Math.Max(size2.Width, size3.Width));
				if (graphicAdElement.ShowName)
				{
					g.DrawString(graphicAdElement.ProductType.Name, font, brush, num2 + (num5 - (float)size.Width) / 2f, num3);
				}
				g.DrawImage(bitmap, num2 + (num5 - (float)size2.Width) / 2f, num3 + (float)size.Height);
				if (graphicAdElement.ShowPrice)
				{
					g.DrawString(text, font, brush, num2 + (num5 - (float)size3.Width) / 2f, num3 + (float)size.Height + (float)size2.Height);
				}
			}
			g.Transform = transform;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005FF8 File Offset: 0x00004FF8
		public override void Drawable_Click(object sender, EventArgs e)
		{
			try
			{
				Form form = new frmAdDesigner(Ad.ProductTypes, this.Index);
				form.ShowDialog(S.MF);
				S.MF.UpdateView();
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2);
			}
		}

		// Token: 0x04000073 RID: 115
		public ArrayList TextAdElements = new ArrayList();

		// Token: 0x04000074 RID: 116
		public ArrayList GraphicAdElements = new ArrayList();

		// Token: 0x04000075 RID: 117
		public int Index;

		// Token: 0x04000076 RID: 118
		public static int MaxAds = 3;

		// Token: 0x04000077 RID: 119
		public static Point[] Ad_Locations = new Point[]
		{
			new Point(311, 355),
			new Point(395, 313),
			new Point(553, 234)
		};

		// Token: 0x04000078 RID: 120
		public static Size Ad_Size = new Size(59, 127);

		// Token: 0x04000079 RID: 121
		public static ProductType[] ProductTypes;
	}
}
