using System;
using System.Drawing;
using KMI.Utility;

namespace KMI.Sim.Drawables
{
	// Token: 0x02000055 RID: 85
	[Serializable]
	public class CommentDrawable : Drawable
	{
		// Token: 0x06000312 RID: 786 RVA: 0x00018653 File Offset: 0x00017653
		public CommentDrawable(Point location, string comment) : base(location, null)
		{
			this.comment = comment;
			base.Hittable = false;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0001866F File Offset: 0x0001766F
		public override void Draw(Graphics g)
		{
			Utilities.DrawComment(g, this.comment, this.location, S.MF.MainWindowBounds);
		}

		// Token: 0x040001ED RID: 493
		protected string comment;
	}
}
