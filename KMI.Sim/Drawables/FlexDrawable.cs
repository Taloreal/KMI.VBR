using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000040 RID: 64
	[Serializable]
	public class FlexDrawable : Drawable
	{
		// Token: 0x06000264 RID: 612 RVA: 0x000148F5 File Offset: 0x000138F5
		public FlexDrawable(Point location, string imageName) : base(location, imageName)
		{
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00014925 File Offset: 0x00013925
		public FlexDrawable(Point location, string imageName, string clickString) : base(location, imageName, clickString)
		{
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00014956 File Offset: 0x00013956
		public FlexDrawable(PointF location, string imageName) : base(location, imageName)
		{
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00014986 File Offset: 0x00013986
		public FlexDrawable(PointF location, string imageName, string clickString) : base(location, imageName, clickString)
		{
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000268 RID: 616 RVA: 0x000149B8 File Offset: 0x000139B8
		// (set) Token: 0x06000269 RID: 617 RVA: 0x000149D0 File Offset: 0x000139D0
		public bool Flip
		{
			get
			{
				return this.flip;
			}
			set
			{
				this.flip = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600026A RID: 618 RVA: 0x000149DC File Offset: 0x000139DC
		// (set) Token: 0x0600026B RID: 619 RVA: 0x000149F4 File Offset: 0x000139F4
		public FlexDrawable.HorizontalAlignments HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignment;
			}
			set
			{
				this.horizontalAlignment = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600026C RID: 620 RVA: 0x00014A00 File Offset: 0x00013A00
		// (set) Token: 0x0600026D RID: 621 RVA: 0x00014A18 File Offset: 0x00013A18
		public FlexDrawable.VerticalAlignments VerticalAlignment
		{
			get
			{
				return this.verticalAlignment;
			}
			set
			{
				this.verticalAlignment = value;
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00014A24 File Offset: 0x00013A24
		public override void Draw(Graphics g)
		{
			Bitmap image = S.R.GetImage(this.imageName);
			switch (this.verticalAlignment)
			{
			case FlexDrawable.VerticalAlignments.Top:
				this.offsetY = 0;
				break;
			case FlexDrawable.VerticalAlignments.Middle:
				this.offsetY = -image.Height / 2;
				break;
			case FlexDrawable.VerticalAlignments.Bottom:
				this.offsetY = -image.Height;
				break;
			}
			switch (this.horizontalAlignment)
			{
			case FlexDrawable.HorizontalAlignments.Left:
				this.offsetX = 0;
				break;
			case FlexDrawable.HorizontalAlignments.Center:
				this.offsetX = -image.Width / 2;
				break;
			case FlexDrawable.HorizontalAlignments.Right:
				this.offsetX = -image.Width;
				break;
			}
			if (this.flip)
			{
				g.DrawImage(image, this.location.X + this.offsetX + image.Width, this.location.Y + this.offsetY, -image.Width, image.Height);
			}
			else
			{
				g.DrawImage(image, this.location.X + this.offsetX, this.location.Y + this.offsetY, image.Width, image.Height);
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00014B54 File Offset: 0x00013B54
		public override bool HitTest(int x, int y)
		{
			return this.hittable && base.HitTest(x - this.offsetX, y - this.offsetY);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00014B8C File Offset: 0x00013B8C
		public override void Drawable_Click(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			if (this.clickString != null && this.clickString != "")
			{
				Point anchor = new Point(this.location.X + this.Size.Width / 2 + this.offsetX, this.location.Y + this.offsetY);
				Utilities.DrawComment(S.MF.BackBufferGraphics, this.clickString, anchor, S.MF.MainWindowBounds);
			}
			control.Refresh();
		}

		// Token: 0x0400018F RID: 399
		protected bool flip = false;

		// Token: 0x04000190 RID: 400
		protected FlexDrawable.HorizontalAlignments horizontalAlignment = FlexDrawable.HorizontalAlignments.Left;

		// Token: 0x04000191 RID: 401
		protected FlexDrawable.VerticalAlignments verticalAlignment = FlexDrawable.VerticalAlignments.Top;

		// Token: 0x04000192 RID: 402
		protected int offsetX = 0;

		// Token: 0x04000193 RID: 403
		protected int offsetY = 0;

		// Token: 0x02000041 RID: 65
		public enum HorizontalAlignments
		{
			// Token: 0x04000195 RID: 405
			Left,
			// Token: 0x04000196 RID: 406
			Center,
			// Token: 0x04000197 RID: 407
			Right
		}

		// Token: 0x02000042 RID: 66
		public enum VerticalAlignments
		{
			// Token: 0x04000199 RID: 409
			Top,
			// Token: 0x0400019A RID: 410
			Middle,
			// Token: 0x0400019B RID: 411
			Bottom
		}
	}
}
