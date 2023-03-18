using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for AppBuilding.
	/// </summary>
	// Token: 0x0200002F RID: 47
	[Serializable]
	public class AppBuilding : Building
	{
		// Token: 0x06000156 RID: 342 RVA: 0x00013994 File Offset: 0x00012994
		public AppBuilding(CityBlock block, int lotIndex, BuildingType type) : base(block, lotIndex, type)
		{
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000139A4 File Offset: 0x000129A4
		public static float RentFromReach(float reach)
		{
			return Math.Max(reach * 100f / 1000f, 200f);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000139D0 File Offset: 0x000129D0
		public static float BillboardRentFromReach(float reach)
		{
			return Math.Max(reach * 75f / 1000f, 100f);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000139FC File Offset: 0x000129FC
		public override ArrayList GetDrawables(int centerAvenue, int centerStreet)
		{
			ArrayList d = new ArrayList();
			Point bldgPt = this.ScreenLoc(centerAvenue, centerStreet);
			d.AddRange(base.GetDrawables(centerAvenue, centerStreet));
			if (this.BillboardOwner != null)
			{
				Point signPt = new Point(bldgPt.X + 21, bldgPt.Y - 27 - this.BuildingType.Height);
				d.Add(new BillboardDrawable(signPt, "BB" + ((AppEntity)this.BillboardOwner).SignColorIndex, base.Avenue, base.Street, base.Lot, (float)base.Reach));
			}
			if (this.Owner != null)
			{
				d.Add(((AppEntity)this.Owner).GetDrawableScoreSign(centerAvenue, centerStreet));
			}
			if (base.Block.GetConstruction() && (base.Lot == 0 || base.Lot == City.LOTS_PER_BLOCK[0] - 1))
			{
				int wave = (int)(14.0 * Math.Sin((double)((float)(A.ST.FrameCounter + base.Lot * 3) / 6f)));
				Point p = new Point(bldgPt.X + 50 + wave, bldgPt.Y - (16 + wave / 2));
				d.Add(new Drawable(p, "Construction"));
			}
			return d;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00013B70 File Offset: 0x00012B70
		public override ArrayList GetDrawablesWholeCity()
		{
			ArrayList d = new ArrayList();
			Point bldgPt = Point.Round(City.Transform((float)base.Avenue, (float)base.Street, (float)this.lotIndex));
			bldgPt = new Point(bldgPt.X / City.AVENUE_VIEWING_REGIONS + City.WHOLE_CITY_OFFSET.X, bldgPt.Y / City.STREET_VIEWING_REGIONS + City.WHOLE_CITY_OFFSET.Y);
			d.Add(new BuildingDrawable(bldgPt, "BuildingSmall" + this.BuildingType.Index, this.BuildingType, base.Avenue, base.Street, base.Lot, -1L, (float)base.Reach, (float)base.Rent, ""));
			if (this.BillboardOwner != null)
			{
				Point signPt = new Point(bldgPt.X + 4, bldgPt.Y - 13 - this.BuildingType.Height / 3);
				d.Add(new BillboardDrawable(signPt, "BB" + ((AppEntity)this.BillboardOwner).SignColorIndex + "Small", base.Avenue, base.Street, base.Lot, (float)base.Reach));
			}
			if (this.Owner != null)
			{
				d.Add(((AppEntity)this.Owner).GetDrawableScoreSign());
			}
			if (base.Block.GetConstruction() && (base.Lot == 0 || base.Lot == City.LOTS_PER_BLOCK[0] - 1))
			{
				int wave = (int)(14.0 * Math.Sin((double)((float)(A.ST.FrameCounter + base.Lot * 3) / 6f)));
				Point p = new Point(bldgPt.X + (50 + wave) / 3, bldgPt.Y - (16 + wave / 2) / 3);
				d.Add(new Drawable(p, "ConstructionSmall"));
			}
			return d;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00013D80 File Offset: 0x00012D80
		public Point ScreenLoc(int centerAvenue, int centerStreet)
		{
			return Point.Round(City.Transform2((float)base.Avenue, (float)base.Street, (float)base.Lot, centerAvenue, centerStreet));
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00013DB4 File Offset: 0x00012DB4
		public Point ScreenLocWholeCity
		{
			get
			{
				return Point.Round(City.TransformWholeCity((float)base.Avenue, (float)base.Street, (float)base.Lot));
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00013DE5 File Offset: 0x00012DE5
		public override void NewWeek()
		{
		}
	}
}
