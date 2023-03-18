using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000075 RID: 117
	[Serializable]
	public class LineDrawable : Drawable
	{
		// Token: 0x06000436 RID: 1078 RVA: 0x0001EE40 File Offset: 0x0001DE40
		public LineDrawable(Point location, Point connector) : base(location, "")
		{
			this.connector = connector;
			this.width = 1f;
			this.color = Color.Black;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0001EE75 File Offset: 0x0001DE75
		public LineDrawable(Point location, Point connector, string clickString) : base(location, "", clickString)
		{
			this.connector = connector;
			this.width = 1f;
			this.color = Color.Black;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0001EEAC File Offset: 0x0001DEAC
		public override void Draw(Graphics g)
		{
			SmoothingMode smoothingMode = g.SmoothingMode;
			g.SmoothingMode = this.smoothingMode;
			SolidBrush brush = new SolidBrush(this.color);
			g.DrawLine(new Pen(brush, this.width), this.location, this.connector);
			g.SmoothingMode = smoothingMode;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0001EF04 File Offset: 0x0001DF04
		public override bool HitTest(int x, int y)
		{
			bool result;
			if (!this.hittable)
			{
				result = false;
			}
			else
			{
				int num = Math.Min(this.location.X, this.connector.X);
				int num2 = Math.Max(this.location.X, this.connector.X);
				if (x >= num - 1 && x <= num2 + 1)
				{
					float num3 = (float)(this.location.Y - this.connector.Y) / (float)(this.location.X - this.connector.X);
					float num4 = num3 * (float)(x - this.location.X) + (float)this.location.Y;
					if (num4 >= (float)y - 1f && num4 <= (float)y + 1f)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x0001EFF4 File Offset: 0x0001DFF4
		// (set) Token: 0x0600043B RID: 1083 RVA: 0x0001F00C File Offset: 0x0001E00C
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

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x0001F018 File Offset: 0x0001E018
		// (set) Token: 0x0600043D RID: 1085 RVA: 0x0001F030 File Offset: 0x0001E030
		public float Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
			}
		}

		// Token: 0x170000FC RID: 252
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x0001F03A File Offset: 0x0001E03A
		public SmoothingMode SmoothingMode
		{
			set
			{
				this.smoothingMode = value;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0001F044 File Offset: 0x0001E044
		protected override Size Size
		{
			get
			{
				return new Size(Math.Abs(this.location.X - this.connector.X), Math.Abs(this.location.Y - this.connector.Y));
			}
		}

		// Token: 0x040002D2 RID: 722
		private const int CLICK_THRESHOLD = 1;

		// Token: 0x040002D3 RID: 723
		protected SmoothingMode smoothingMode = SmoothingMode.AntiAlias;

		// Token: 0x040002D4 RID: 724
		protected Point connector;

		// Token: 0x040002D5 RID: 725
		protected Color color;

		// Token: 0x040002D6 RID: 726
		protected float width;
	}
}
