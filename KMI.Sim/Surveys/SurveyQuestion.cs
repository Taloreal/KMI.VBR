using System;

namespace KMI.Sim.Surveys
{
	// Token: 0x02000046 RID: 70
	[Serializable]
	public class SurveyQuestion
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00014F88 File Offset: 0x00013F88
		// (set) Token: 0x0600027B RID: 635 RVA: 0x00014FA0 File Offset: 0x00013FA0
		public string ShortName
		{
			get
			{
				return this.shortName;
			}
			set
			{
				this.shortName = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600027C RID: 636 RVA: 0x00014FAC File Offset: 0x00013FAC
		// (set) Token: 0x0600027D RID: 637 RVA: 0x00014FC4 File Offset: 0x00013FC4
		public string Question
		{
			get
			{
				return this.question;
			}
			set
			{
				this.question = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00014FD0 File Offset: 0x00013FD0
		// (set) Token: 0x0600027F RID: 639 RVA: 0x00015027 File Offset: 0x00014027
		public string[] PossibleResponses
		{
			get
			{
				string[] result;
				if (!this.answersAreEntities)
				{
					result = this.possibleResponses;
				}
				else
				{
					string[] array = new string[this.parent.EntityNames.Length + 1];
					array[0] = "None";
					this.parent.EntityNames.CopyTo(array, 1);
					result = array;
				}
				return result;
			}
			set
			{
				this.possibleResponses = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00015034 File Offset: 0x00014034
		// (set) Token: 0x06000281 RID: 641 RVA: 0x0001504C File Offset: 0x0001404C
		public bool MultiEntity
		{
			get
			{
				return this.multiEntity;
			}
			set
			{
				this.multiEntity = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000282 RID: 642 RVA: 0x00015058 File Offset: 0x00014058
		// (set) Token: 0x06000283 RID: 643 RVA: 0x00015070 File Offset: 0x00014070
		public bool AnswersAreEntities
		{
			get
			{
				return this.answersAreEntities;
			}
			set
			{
				this.answersAreEntities = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (set) Token: 0x06000284 RID: 644 RVA: 0x0001507A File Offset: 0x0001407A
		public Survey Parent
		{
			set
			{
				this.parent = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00015084 File Offset: 0x00014084
		// (set) Token: 0x06000286 RID: 646 RVA: 0x0001509C File Offset: 0x0001409C
		public string PossibleResponsesConcatenated
		{
			get
			{
				return this.possibleResponsesConcatenated;
			}
			set
			{
				this.possibleResponsesConcatenated = value;
			}
		}

		// Token: 0x040001A8 RID: 424
		protected string shortName;

		// Token: 0x040001A9 RID: 425
		protected string question;

		// Token: 0x040001AA RID: 426
		protected string[] possibleResponses;

		// Token: 0x040001AB RID: 427
		protected bool multiEntity;

		// Token: 0x040001AC RID: 428
		protected bool answersAreEntities;

		// Token: 0x040001AD RID: 429
		protected Survey parent;

		// Token: 0x040001AE RID: 430
		protected string possibleResponsesConcatenated;
	}
}
