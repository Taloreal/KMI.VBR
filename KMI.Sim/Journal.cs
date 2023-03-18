using System;
using System.Collections;

namespace KMI.Sim
{
	// Token: 0x02000051 RID: 81
	[Serializable]
	public class Journal
	{
		// Token: 0x060002EC RID: 748 RVA: 0x00017A4C File Offset: 0x00016A4C
		public Journal(string entityName, string[] numericDataSeriesNames, float daysPerPeriod)
		{
			this.entityName = entityName;
			this.numericDataSeriesNames = numericDataSeriesNames;
			for (int i = 0; i < numericDataSeriesNames.Length; i++)
			{
				this.numericDataSeries.Add(numericDataSeriesNames[i], new ArrayList());
			}
			this.daysPerPeriod = daysPerPeriod;
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002ED RID: 749 RVA: 0x00017AB8 File Offset: 0x00016AB8
		public string EntityName
		{
			get
			{
				return this.entityName;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00017AD0 File Offset: 0x00016AD0
		public string[] NumericDataSeriesNames
		{
			get
			{
				return this.numericDataSeriesNames;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002EF RID: 751 RVA: 0x00017AE8 File Offset: 0x00016AE8
		public ArrayList Entries
		{
			get
			{
				return this.entries;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00017B00 File Offset: 0x00016B00
		public float DaysPerPeriod
		{
			get
			{
				return this.daysPerPeriod;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x00017B18 File Offset: 0x00016B18
		public int DataSeriesCount
		{
			get
			{
				return this.numericDataSeries.Count;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00017B38 File Offset: 0x00016B38
		public int Periods
		{
			get
			{
				return (this.numericDataSeries[this.numericDataSeriesNames[0]] as ArrayList).Count;
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00017B68 File Offset: 0x00016B68
		public void AddEntry(DateTime timeStamp, string description, FlagsAttribute flags)
		{
			if (!S.MF.DesignerMode)
			{
				JournalEntry journalEntry = new JournalEntry(timeStamp, this.entityName, description, flags);
				for (int i = this.entries.Count - 1; i >= -1; i--)
				{
					if (i == -1)
					{
						this.entries.Insert(0, journalEntry);
						break;
					}
					if (journalEntry.TimeStamp >= ((JournalEntry)this.entries[i]).TimeStamp)
					{
						this.entries.Insert(i + 1, journalEntry);
						break;
					}
				}
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00017C13 File Offset: 0x00016C13
		public void AddEntry(string description, FlagsAttribute flags)
		{
			this.AddEntry(Simulator.Instance.SimState.Now, description, flags);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00017C2E File Offset: 0x00016C2E
		public void AddEntry(DateTime timeStamp, string description)
		{
			this.AddEntry(timeStamp, description, new FlagsAttribute());
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00017C3F File Offset: 0x00016C3F
		public void AddEntry(string description)
		{
			this.AddEntry(Simulator.Instance.SimState.Now, description, new FlagsAttribute());
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00017C5E File Offset: 0x00016C5E
		public void AddNumericData(string seriesName, float amount)
		{
			((ArrayList)this.numericDataSeries[seriesName]).Add(amount);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00017C80 File Offset: 0x00016C80
		public ArrayList NumericDataSeries(string seriesName)
		{
			return (ArrayList)this.numericDataSeries[seriesName];
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00017CA4 File Offset: 0x00016CA4
		public float NumericDataSeriesLastEntry(string seriesName)
		{
			ArrayList arrayList = (ArrayList)this.numericDataSeries[seriesName];
			float result;
			if (arrayList.Count == 0)
			{
				result = 0f;
			}
			else
			{
				result = (float)arrayList[arrayList.Count - 1];
			}
			return result;
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00017CF4 File Offset: 0x00016CF4
		// (set) Token: 0x060002FB RID: 763 RVA: 0x00017D0B File Offset: 0x00016D0B
		public static string ScoreSeriesName
		{
			get
			{
				return Journal.scoreSeriesName;
			}
			set
			{
				Journal.scoreSeriesName = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00017D14 File Offset: 0x00016D14
		// (set) Token: 0x060002FD RID: 765 RVA: 0x00017D2B File Offset: 0x00016D2B
		public static string[] JournalNumericDataSeriesNames
		{
			get
			{
				return Journal.journalNumericDataSeriesNames;
			}
			set
			{
				Journal.journalNumericDataSeriesNames = value;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00017D34 File Offset: 0x00016D34
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00017D4B File Offset: 0x00016D4B
		public static string JournalSeriesName
		{
			get
			{
				return Journal.journalSeriesName;
			}
			set
			{
				Journal.journalSeriesName = value;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00017D54 File Offset: 0x00016D54
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00017D6B File Offset: 0x00016D6B
		public static int JournalDaysPerPeriod
		{
			get
			{
				return Journal.journalDaysPerPeriod;
			}
			set
			{
				Journal.journalDaysPerPeriod = value;
			}
		}

		// Token: 0x040001D7 RID: 471
		protected Hashtable numericDataSeries = new Hashtable();

		// Token: 0x040001D8 RID: 472
		protected string entityName;

		// Token: 0x040001D9 RID: 473
		protected string[] numericDataSeriesNames;

		// Token: 0x040001DA RID: 474
		protected ArrayList entries = new ArrayList();

		// Token: 0x040001DB RID: 475
		protected float daysPerPeriod;

		// Token: 0x040001DC RID: 476
		protected static string scoreSeriesName = "Cumulative Profit";

		// Token: 0x040001DD RID: 477
		protected static string[] journalNumericDataSeriesNames = new string[]
		{
			"Profit",
			"Cumulative Profit"
		};

		// Token: 0x040001DE RID: 478
		protected static string journalSeriesName = "Profit";

		// Token: 0x040001DF RID: 479
		protected static int journalDaysPerPeriod = 7;
	}
}
