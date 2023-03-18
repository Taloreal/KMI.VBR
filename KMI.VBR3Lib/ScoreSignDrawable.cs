using System;
using System.Collections;
using System.Drawing;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for BillboardDrawable.
	/// </summary>
	// Token: 0x02000014 RID: 20
	[Serializable]
	public class ScoreSignDrawable : CompoundDrawable
	{
		// Token: 0x06000092 RID: 146 RVA: 0x000093C4 File Offset: 0x000083C4
		public ScoreSignDrawable(Point location, string imageName, long ownerID, string ownerName, Color color, float score, bool zoomed) : base(location, null, null)
		{
			this.OwnerID = ownerID;
			this.OwnerName = ownerName;
			Font f = new Font("Arial", 8f);
			Point p = location;
			ArrayList d = new ArrayList();
			Point offset = ((CityView)A.I.Views[0]).OffsetToBuildingCenter(zoomed);
			Point center = new Point(p.X + offset.X, p.Y + offset.Y);
			d.Add(new LineDrawable(center, new Point(center.X, center.Y - 16 + 1)));
			string text = this.OwnerName + "\r\n" + Utilities.FC(score, A.I.CurrencyConversion);
			SizeF textSize = A.MF.picMain.CreateGraphics().MeasureString(text, f);
			textSize = new SizeF(textSize.Width + 4f, textSize.Height);
			RectangleF r = new RectangleF(new Point(center.X - (int)textSize.Width / 2, center.Y - 16 - (int)textSize.Height), textSize);
			d.Add(new RectangleDrawable(Point.Round(r.Location), Size.Round(r.Size), color, true));
			d.Add(new RectangleDrawable(Point.Round(r.Location), Size.Round(r.Size), Color.Black, false));
			d.Add(new TextDrawable(new Point(center.X, center.Y - 16 - (int)textSize.Height), text, "Arial", 8, Color.Black)
			{
				Center = true,
				Hittable = false
			});
			this.drawables = d;
		}

		// Token: 0x0400007D RID: 125
		public long OwnerID;

		// Token: 0x0400007E RID: 126
		public string OwnerName;

		// Token: 0x0400007F RID: 127
		public Color color;

		// Token: 0x04000080 RID: 128
		public float Score;
	}
}
