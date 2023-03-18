using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim.Drawables;

namespace KMI.Sim
{
	// Token: 0x02000058 RID: 88
	public abstract class View
	{
		// Token: 0x06000319 RID: 793 RVA: 0x000189EC File Offset: 0x000179EC
		public View(string name, Bitmap background)
		{
			this.name = name;
			this.background = background;
			this.size = background.Size;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00018A1F File Offset: 0x00017A1F
		public View(string name, Size size)
		{
			this.name = name;
			this.size = size;
			this.background = null;
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00018A50 File Offset: 0x00017A50
		public Size Size
		{
			get
			{
				return this.size;
			}
		}

		// Token: 0x0600031C RID: 796
		public abstract Drawable[] BuildDrawables(long entityID, params object[] args);

		// Token: 0x0600031D RID: 797 RVA: 0x00018A68 File Offset: 0x00017A68
		public void Draw(Graphics g)
		{
			if (this.background != null)
			{
				g.DrawImageUnscaled(this.background, 0, 0);
			}
			foreach (Drawable drawable in this.drawables)
			{
				drawable.Draw(g);
			}
			if (View.currentHit != null)
			{
				View.currentHit.DrawSelected(g);
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00018AD4 File Offset: 0x00017AD4
		public Drawable HitTest(int x, int y)
		{
			if (this.drawables != null)
			{
				for (int i = this.drawables.Length - 1; i >= 0; i--)
				{
					if (this.drawables[i].HitTest(x, y))
					{
						return this.drawables[i];
					}
				}
			}
			return null;
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00018B34 File Offset: 0x00017B34
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000320 RID: 800 RVA: 0x00018B4C File Offset: 0x00017B4C
		// (set) Token: 0x06000321 RID: 801 RVA: 0x00018B64 File Offset: 0x00017B64
		public Drawable[] Drawables
		{
			get
			{
				return this.drawables;
			}
			set
			{
				this.drawables = value;
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00018B6E File Offset: 0x00017B6E
		protected internal void UpdateCurrentHit(MouseEventArgs e)
		{
			View.currentHit = this.HitTest(e.X, e.Y);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00018B88 File Offset: 0x00017B88
		public static void ClearCurrentHit()
		{
			View.currentHit = null;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00018B94 File Offset: 0x00017B94
		public virtual void View_Click(object sender, EventArgs e)
		{
			if (View.currentHit != null)
			{
				View.currentHit.Drawable_Click(sender, e);
			}
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00018BBC File Offset: 0x00017BBC
		public virtual void View_DoubleClick(object sender, EventArgs e)
		{
			if (View.currentHit != null)
			{
				View.currentHit.Drawable_DoubleClick(sender, e);
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00018BE4 File Offset: 0x00017BE4
		public virtual void View_MouseMove(object sender, MouseEventArgs e)
		{
			if (!S.I.SimTimeRunning && this.ClearDrawSelectedOnMouseMove)
			{
				S.MF.picMain.Refresh();
			}
			Control control = (Control)sender;
			control.Cursor = Cursors.Default;
			if (View.currentHit != null)
			{
				View.currentHit.Drawable_MouseMove(sender, e);
			}
			else
			{
				S.MF.ViewToolTip.SetToolTip(control, "");
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00018C62 File Offset: 0x00017C62
		public virtual void View_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00018C65 File Offset: 0x00017C65
		public virtual void View_MouseUp(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00018C68 File Offset: 0x00017C68
		// (set) Token: 0x0600032A RID: 810 RVA: 0x00018C80 File Offset: 0x00017C80
		public bool ClearDrawSelectedOnMouseMove
		{
			get
			{
				return this.clearDrawSelectedOnMouseMove;
			}
			set
			{
				this.clearDrawSelectedOnMouseMove = value;
			}
		}

		// Token: 0x040001F8 RID: 504
		protected string name;

		// Token: 0x040001F9 RID: 505
		protected Bitmap background;

		// Token: 0x040001FA RID: 506
		protected Drawable[] drawables;

		// Token: 0x040001FB RID: 507
		protected int skewFactor = 2;

		// Token: 0x040001FC RID: 508
		public object[] ViewerOptions;

		// Token: 0x040001FD RID: 509
		protected Size size;

		// Token: 0x040001FE RID: 510
		protected static Drawable currentHit;

		// Token: 0x040001FF RID: 511
		protected bool clearDrawSelectedOnMouseMove = false;
	}
}
