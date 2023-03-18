using System;

namespace KMI.Sim.Academics
{
	// Token: 0x02000044 RID: 68
	[Serializable]
	public class Question
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00014EF4 File Offset: 0x00013EF4
		public bool Correct
		{
			get
			{
				foreach (string text in this.Answers)
				{
					if (string.Compare(text.Trim(), this.Answer.Trim(), true) == 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x040001A1 RID: 417
		public string Text;

		// Token: 0x040001A2 RID: 418
		public string[] Answers;

		// Token: 0x040001A3 RID: 419
		public string Answer = null;
	}
}
