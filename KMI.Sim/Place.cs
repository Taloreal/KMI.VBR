using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000069 RID: 105
	[Serializable]
	public class Place
	{
		// Token: 0x060003DB RID: 987 RVA: 0x0001C8D6 File Offset: 0x0001B8D6
		public Place()
		{
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0001C902 File Offset: 0x0001B902
		public Place(PointF location)
		{
			this.Location = location;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0001C938 File Offset: 0x0001B938
		public void Link(Place otherPlace)
		{
			if (!this.LinkedPlaces.Contains(otherPlace))
			{
				this.LinkedPlaces.Add(otherPlace);
				otherPlace.Link(this);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003DE RID: 990 RVA: 0x0001C970 File Offset: 0x0001B970
		public bool UnderConstruction
		{
			get
			{
				return S.ST.Now < this.EndConstruction;
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0001C998 File Offset: 0x0001B998
		public override bool Equals(object obj)
		{
			Place place = (Place)obj;
			return Utilities.DistanceBetween(this.Location, place.Location) < 3f;
		}

		// Token: 0x04000291 RID: 657
		public PointF Location;

		// Token: 0x04000292 RID: 658
		public ArrayList LinkedPlaces = new ArrayList();

		// Token: 0x04000293 RID: 659
		public bool tempIsDead;

		// Token: 0x04000294 RID: 660
		public float tempDistance;

		// Token: 0x04000295 RID: 661
		public Place tempNextLink;

		// Token: 0x04000296 RID: 662
		public float SpeedLimit = Place.DefaultSpeedLimit;

		// Token: 0x04000297 RID: 663
		public static float DefaultSpeedLimit = 0.18f;

		// Token: 0x04000298 RID: 664
		public DateTime EndConstruction = Place.NoConstruction;

		// Token: 0x04000299 RID: 665
		public static DateTime NoConstruction = DateTime.MinValue;

		// Token: 0x0200006A RID: 106
		[Serializable]
		public class PlaceLoader
		{
			// Token: 0x170000EE RID: 238
			// (get) Token: 0x060003E1 RID: 993 RVA: 0x0001C9E0 File Offset: 0x0001B9E0
			// (set) Token: 0x060003E2 RID: 994 RVA: 0x0001C9F8 File Offset: 0x0001B9F8
			public int X
			{
				get
				{
					return this.x;
				}
				set
				{
					this.x = value;
				}
			}

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x060003E3 RID: 995 RVA: 0x0001CA04 File Offset: 0x0001BA04
			// (set) Token: 0x060003E4 RID: 996 RVA: 0x0001CA1C File Offset: 0x0001BA1C
			public int Y
			{
				get
				{
					return this.y;
				}
				set
				{
					this.y = value;
				}
			}

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x060003E5 RID: 997 RVA: 0x0001CA28 File Offset: 0x0001BA28
			// (set) Token: 0x060003E6 RID: 998 RVA: 0x0001CA40 File Offset: 0x0001BA40
			public string Links
			{
				get
				{
					return this.links;
				}
				set
				{
					this.links = value;
				}
			}

			// Token: 0x170000F1 RID: 241
			// (get) Token: 0x060003E7 RID: 999 RVA: 0x0001CA4C File Offset: 0x0001BA4C
			// (set) Token: 0x060003E8 RID: 1000 RVA: 0x0001CA64 File Offset: 0x0001BA64
			public string Name
			{
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}

			// Token: 0x0400029A RID: 666
			protected int x;

			// Token: 0x0400029B RID: 667
			protected int y;

			// Token: 0x0400029C RID: 668
			protected string links;

			// Token: 0x0400029D RID: 669
			protected string name;
		}
	}
}
