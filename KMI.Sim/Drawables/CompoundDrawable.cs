using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x0200006D RID: 109
	[Serializable]
	public class CompoundDrawable : Drawable
	{
		// Token: 0x060003F7 RID: 1015 RVA: 0x0001D692 File Offset: 0x0001C692
		public CompoundDrawable(Point location, ArrayList drawables, string clickString) : base(location, null, clickString)
		{
			this.drawables = drawables;
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x0001D6BC File Offset: 0x0001C6BC
		// (set) Token: 0x060003F9 RID: 1017 RVA: 0x0001D6EF File Offset: 0x0001C6EF
		public ArrayList Drawables
		{
			get
			{
				if (this.drawables == null)
				{
					this.drawables = new ArrayList();
				}
				return this.drawables;
			}
			set
			{
				this.drawables = value;
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0001D6FC File Offset: 0x0001C6FC
		public override void Draw(Graphics g)
		{
			foreach (object obj in this.drawables)
			{
				Drawable drawable = (Drawable)obj;
				drawable.Draw(g);
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0001D764 File Offset: 0x0001C764
		public override bool HitTest(int x, int y)
		{
			CompoundDrawable.clickedDrawable = null;
			bool result;
			if (!this.hittable)
			{
				result = false;
			}
			else
			{
				for (int i = this.drawables.Count - 1; i >= 0; i--)
				{
					if (((Drawable)this.drawables[i]).HitTest(x, y))
					{
						if (this.forwardClick)
						{
							CompoundDrawable.clickedDrawable = (Drawable)this.drawables[i];
						}
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x0001D7F4 File Offset: 0x0001C7F4
		// (set) Token: 0x060003FD RID: 1021 RVA: 0x0001D80C File Offset: 0x0001C80C
		public bool ForwardClick
		{
			get
			{
				return this.forwardClick;
			}
			set
			{
				this.forwardClick = value;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x0001D818 File Offset: 0x0001C818
		// (set) Token: 0x060003FF RID: 1023 RVA: 0x0001D84B File Offset: 0x0001C84B
		public Point ClickStringLocation
		{
			get
			{
				Point location;
				if (this.clickStringLocation.IsEmpty)
				{
					location = this.location;
				}
				else
				{
					location = this.clickStringLocation;
				}
				return location;
			}
			set
			{
				this.clickStringLocation = value;
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0001D858 File Offset: 0x0001C858
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (this.forwardClick && CompoundDrawable.clickedDrawable != null)
			{
				CompoundDrawable.clickedDrawable.Drawable_Click(sender, e);
			}
			Control control = (Control)sender;
			if (this.clickString != null && this.clickString != "")
			{
				Point anchor = new Point(this.ClickStringLocation.X + this.Size.Width / 2, this.ClickStringLocation.Y);
				Utilities.DrawComment(S.MF.BackBufferGraphics, this.clickString, anchor, S.MF.MainWindowBounds);
			}
			control.Refresh();
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0001D914 File Offset: 0x0001C914
		public override void Drawable_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.forwardClick && CompoundDrawable.clickedDrawable != null)
			{
				CompoundDrawable.clickedDrawable.Drawable_MouseMove(sender, e);
			}
			else
			{
				base.Drawable_MouseMove(sender, e);
			}
		}

		// Token: 0x040002B4 RID: 692
		protected ArrayList drawables;

		// Token: 0x040002B5 RID: 693
		private bool forwardClick = false;

		// Token: 0x040002B6 RID: 694
		protected Point clickStringLocation = Point.Empty;

		// Token: 0x040002B7 RID: 695
		private static Drawable clickedDrawable = null;
	}
}
