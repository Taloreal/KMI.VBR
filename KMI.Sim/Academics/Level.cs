using System;

namespace KMI.Sim.Academics
{
	// Token: 0x02000045 RID: 69
	[Serializable]
	public class Level
	{
		// Token: 0x040001A4 RID: 420
		public Page[] Pages = new Page[0];

		// Token: 0x040001A5 RID: 421
		public string[] Powers = new string[0];

		// Token: 0x040001A6 RID: 422
		public float Goal;

		// Token: 0x040001A7 RID: 423
		public string LevelIntroMessage = "";
	}
}
