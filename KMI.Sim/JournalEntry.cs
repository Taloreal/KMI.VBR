using System;

namespace KMI.Sim
{
	// Token: 0x02000028 RID: 40
	[Serializable]
	public class JournalEntry
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x0000E02A File Offset: 0x0000D02A
		public JournalEntry(DateTime timeStamp, string entityName, string description, FlagsAttribute flags)
		{
			this.timeStamp = timeStamp;
			this.entityName = entityName;
			this.description = description;
			this.flags = flags;
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000E054 File Offset: 0x0000D054
		public DateTime TimeStamp
		{
			get
			{
				return this.timeStamp;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x0000E06C File Offset: 0x0000D06C
		public string EntityName
		{
			get
			{
				return this.entityName;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000E084 File Offset: 0x0000D084
		public string Description
		{
			get
			{
				return this.description;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000E09C File Offset: 0x0000D09C
		public FlagsAttribute Flags
		{
			get
			{
				return this.flags;
			}
		}

		// Token: 0x04000109 RID: 265
		protected DateTime timeStamp;

		// Token: 0x0400010A RID: 266
		protected string entityName;

		// Token: 0x0400010B RID: 267
		protected string description;

		// Token: 0x0400010C RID: 268
		protected FlagsAttribute flags;
	}
}
