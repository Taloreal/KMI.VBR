using System;
using System.Drawing;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for StationDrawable.
	/// </summary>
	// Token: 0x02000028 RID: 40
	[Serializable]
	public class StationDrawable : FlexDrawable, IPctExpired
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x0000F5BF File Offset: 0x0000E5BF
		public StationDrawable(Point location, string imageName, float percentExpired) : base(location, imageName)
		{
			this.percentExpired = percentExpired;
			this.clickString = " ";
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000F5E0 File Offset: 0x0000E5E0
		public float PercentExpired()
		{
			return this.percentExpired;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000F5F8 File Offset: 0x0000E5F8
		public override void Drawable_Click(object sender, EventArgs e)
		{
			this.ShelfDrawable.Drawable_Click(sender, e);
		}

		// Token: 0x0400011B RID: 283
		protected float percentExpired;

		// Token: 0x0400011C RID: 284
		public ShelfDrawable ShelfDrawable;
	}
}
