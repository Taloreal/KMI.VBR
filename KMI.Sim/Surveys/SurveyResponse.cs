using System;
using System.Collections;

namespace KMI.Sim.Surveys
{
	// Token: 0x02000064 RID: 100
	[Serializable]
	public class SurveyResponse
	{
		// Token: 0x060003AE RID: 942 RVA: 0x0001AF60 File Offset: 0x00019F60
		public SurveyResponse(long respondantID)
		{
			this.respondantID = respondantID;
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060003AF RID: 943 RVA: 0x0001AF80 File Offset: 0x00019F80
		public ArrayList Answers
		{
			get
			{
				return this.answers;
			}
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0001AF98 File Offset: 0x00019F98
		public void AddAnswer(int[] answer)
		{
			this.answers.Add(answer);
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x0001AFA8 File Offset: 0x00019FA8
		public long RespondantID
		{
			get
			{
				return this.respondantID;
			}
		}

		// Token: 0x04000263 RID: 611
		protected ArrayList answers = new ArrayList();

		// Token: 0x04000264 RID: 612
		protected long respondantID;
	}
}
