using System;

namespace KMI.Sim.Academics
{
	// Token: 0x02000056 RID: 86
	[Serializable]
	public class Page
	{
		// Token: 0x040001EE RID: 494
		public string Name;

		// Token: 0x040001EF RID: 495
		public string Power;

		// Token: 0x040001F0 RID: 496
		public string BodyURL;

		// Token: 0x040001F1 RID: 497
		public float MinScore = float.MinValue;

		// Token: 0x040001F2 RID: 498
		public Question[] Questions;
	}
}
