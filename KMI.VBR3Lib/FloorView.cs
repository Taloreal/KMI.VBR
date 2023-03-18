using System;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// An example View for an application.
	/// </summary>
	// Token: 0x02000047 RID: 71
	public class FloorView : View
	{
		/// <summary>
		/// Contructs a new instance of this View with the given name
		/// and background image.
		/// </summary>
		/// <param name="name">The name for this View as it is to
		/// appear in the application.</param>
		/// <param name="background">The background image to use
		/// for this View in the application.</param>
		// Token: 0x06000221 RID: 545 RVA: 0x0001F9CC File Offset: 0x0001E9CC
		public FloorView(string name, Bitmap background) : base(name, background)
		{
			MapV2 i = new MapV2();
			i.load(typeof(Floor).Assembly, "KMI.VBR3Lib.Data.FloorMap.xml");
			AdSimple.Ad_Size = new Size(40, 60);
			AdSimple.Ad_Locations = new Point[AdSimple.MaxAds];
			for (int j = 0; j < AdSimple.MaxAds; j++)
			{
				Point p = i.getNode("A" + j).Location;
				AdSimple.Ad_Locations[j] = new Point(p.X - 40, p.Y - 70);
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0001FA80 File Offset: 0x0001EA80
		public override Drawable[] BuildDrawables(long entityID, params object[] args)
		{
			AppEntity e = (AppEntity)A.ST.Entity[entityID];
			return (Drawable[])e.Floor.GetDrawables().ToArray(typeof(Drawable));
		}
	}
}
