using System;
using System.Drawing;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000063 RID: 99
	[Serializable]
	public class PixelDrawable : Drawable
	{
		// Token: 0x060003A7 RID: 935 RVA: 0x0001AE5C File Offset: 0x00019E5C
		public PixelDrawable(Point location, Color color) : base(location, "")
		{
			this.color = color;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0001AE74 File Offset: 0x00019E74
		public PixelDrawable(Point location, Color color, string clickString) : base(location, "", clickString)
		{
			this.color = color;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0001AE8D File Offset: 0x00019E8D
		public override void Draw(Graphics g)
		{
			PixelDrawable.bitmap.SetPixel(0, 0, this.color);
			g.DrawImageUnscaled(PixelDrawable.bitmap, this.location.X, this.location.Y);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0001AEC8 File Offset: 0x00019EC8
		public override bool HitTest(int x, int y)
		{
			return this.hittable && (this.location.X <= x + 1 && this.location.X >= x - 1 && this.location.Y <= y + 1) && this.location.Y >= y - 1;
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060003AB RID: 939 RVA: 0x0001AF30 File Offset: 0x00019F30
		// (set) Token: 0x060003AC RID: 940 RVA: 0x0001AF48 File Offset: 0x00019F48
		public Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color = value;
			}
		}

		// Token: 0x04000260 RID: 608
		private const int CLICK_THRESHOLD = 1;

		// Token: 0x04000261 RID: 609
		protected Color color;

		// Token: 0x04000262 RID: 610
		private static Bitmap bitmap = new Bitmap(1, 1);
	}
}
