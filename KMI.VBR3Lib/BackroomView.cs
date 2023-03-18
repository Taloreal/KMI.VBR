using System;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// An example View for an application.
	/// </summary>
	// Token: 0x02000050 RID: 80
	public class BackroomView : View
	{
		/// <summary>
		/// Contructs a new instance of this View with the given name
		/// and background image.
		/// </summary>
		/// <param name="name">The name for this View as it is to
		/// appear in the application.</param>
		/// <param name="background">The background image to use
		/// for this View in the application.</param>
		// Token: 0x060002FD RID: 765 RVA: 0x00022E20 File Offset: 0x00021E20
		public BackroomView(string name, Bitmap background) : base(name, background)
		{
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00022E30 File Offset: 0x00021E30
		public override Drawable[] BuildDrawables(long entityID, params object[] args)
		{
			AppEntity e = (AppEntity)A.ST.Entity[entityID];
			return (Drawable[])e.Backroom.GetDrawables().ToArray(typeof(Drawable));
		}
	}
}
