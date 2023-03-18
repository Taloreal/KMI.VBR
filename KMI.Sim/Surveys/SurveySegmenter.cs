using System;

namespace KMI.Sim.Surveys
{
	// Token: 0x02000079 RID: 121
	[Serializable]
	public class SurveySegmenter
	{
		// Token: 0x06000449 RID: 1097 RVA: 0x0001F7D4 File Offset: 0x0001E7D4
		public SurveySegmenter(int questionIndex, SurveyQuestion question, bool[] includesAnswer)
		{
			this.questionIndex = questionIndex;
			this.question = question;
			this.includesAnswer = includesAnswer;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0001F7F4 File Offset: 0x0001E7F4
		public SurveySegmenter(int questionIndex, SurveyQuestion question, bool[] includesAnswer, int entityIndex)
		{
			this.questionIndex = questionIndex;
			this.question = question;
			this.includesAnswer = includesAnswer;
			this.entityIndex = entityIndex;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0001F81C File Offset: 0x0001E81C
		public bool Excludes(SurveyResponse r)
		{
			int[] array = (int[])r.Answers[this.questionIndex];
			int num;
			if (this.question.MultiEntity)
			{
				num = array[this.entityIndex];
			}
			else
			{
				num = array[0];
			}
			return !this.includesAnswer[num];
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x0001F878 File Offset: 0x0001E878
		public bool AllChecked
		{
			get
			{
				bool[] array = this.includesAnswer;
				for (int i = 0; i < array.Length; i++)
				{
					if (!array[i])
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0001F8B8 File Offset: 0x0001E8B8
		public SurveyQuestion Question
		{
			get
			{
				return this.question;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600044E RID: 1102 RVA: 0x0001F8D0 File Offset: 0x0001E8D0
		public int EntityIndex
		{
			get
			{
				return this.entityIndex;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x0001F8E8 File Offset: 0x0001E8E8
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x0001F900 File Offset: 0x0001E900
		public bool[] IncludesAnswer
		{
			get
			{
				return this.includesAnswer;
			}
			set
			{
				this.includesAnswer = value;
			}
		}

		// Token: 0x040002E6 RID: 742
		protected int questionIndex;

		// Token: 0x040002E7 RID: 743
		protected SurveyQuestion question;

		// Token: 0x040002E8 RID: 744
		protected int entityIndex;

		// Token: 0x040002E9 RID: 745
		protected bool[] includesAnswer;
	}
}
