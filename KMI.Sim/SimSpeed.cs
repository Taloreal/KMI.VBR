using System;

namespace KMI.Sim
{
	// Token: 0x02000077 RID: 119
	[Serializable]
	public class SimSpeed
	{
		// Token: 0x06000444 RID: 1092 RVA: 0x0001F3C6 File Offset: 0x0001E3C6
		public SimSpeed(int stepPeriod, int skipFactor)
		{
			this.StepPeriod = stepPeriod;
			this.SkipFactor = skipFactor;
		}

		// Token: 0x040002DD RID: 733
		public int StepPeriod;

		// Token: 0x040002DE RID: 734
		public int SkipFactor;
	}
}
