using System;
using System.Drawing;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000054 RID: 84
	[Serializable]
	public class RectangleDrawable : Drawable
	{
		// Token: 0x0600030D RID: 781 RVA: 0x0001854F File Offset: 0x0001754F
		public RectangleDrawable(Point location, Size size, Color color, bool fill) : base(location, null)
		{
			this.fill = fill;
			this.size = size;
			this.color = color;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00018572 File Offset: 0x00017572
		public RectangleDrawable(Point location, string clickString, Size size, Color color, bool fill) : base(location, null, clickString)
		{
			this.fill = fill;
			this.size = size;
			this.color = color;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00018598 File Offset: 0x00017598
		public override void Draw(Graphics g)
		{
			if (this.fill)
			{
				g.FillRectangle(new SolidBrush(this.color), new Rectangle(this.location, this.size));
			}
			else
			{
				g.DrawRectangle(new Pen(this.color, 1f), new Rectangle(this.location, this.size));
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000310 RID: 784 RVA: 0x00018600 File Offset: 0x00017600
		protected override Size Size
		{
			get
			{
				return this.size;
			}
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00018618 File Offset: 0x00017618
		public override bool HitTest(int x, int y)
		{
			return this.hittable && new Rectangle(this.location, this.size).Contains(x, y);
		}

		// Token: 0x040001EA RID: 490
		protected bool fill;

		// Token: 0x040001EB RID: 491
		protected Size size;

		// Token: 0x040001EC RID: 492
		protected Color color;
	}
}
