using System;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Staffing
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	public class Job
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00003BEC File Offset: 0x00002BEC
		public void CreateRandom(string employeeName, DateTime startDate, int nWeeks, float goodness, float respondsToWarnings)
		{
			this.StartDate = startDate;
			this.EndDate = this.StartDate.AddDays((double)(nWeeks * 7));
			Random random = S.ST.Random;
			this.EmployerName = Utilities.MakePossessive(Utilities.GetRandomFirstName(random));
			this.EmployerID = -1L;
			this.Reference = this.MakeUpReference(employeeName, this.EmployerName, goodness, respondsToWarnings);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003C54 File Offset: 0x00002C54
		protected string MakeUpReference(string employeeName, string employerName, float goodness, float respondsToWarnings)
		{
			string newLine = Environment.NewLine;
			string text = null;
			if (S.ST.Random.NextDouble() < (double)goodness)
			{
				Phraser phraser = new Phraser(S.R.GetString("somewhat|quite|very|extremely"));
				string text2 = S.R.GetString("{0} worked for us from {1} to {2} and was {3} reliable and conscientious about coming to work.", new object[]
				{
					employeeName,
					this.StartDate.ToLongDateString(),
					this.EndDate.ToLongDateString(),
					phraser.GetPhrase((double)goodness)
				});
				string @string = S.R.GetString("took");
				if ((double)respondsToWarnings < 0.5)
				{
					@string = S.R.GetString("did not take");
				}
				text2 = text2 + newLine + newLine + S.R.GetString("I found that {0} {1} direction very well.", new object[]
				{
					employeeName,
					@string
				});
				text = "To Whom It May Concern:" + newLine + newLine;
				text = text + text2 + newLine + newLine;
				text = text + "Sincerely," + newLine + newLine;
				text = text + Utilities.GetRandomFullName(S.ST.Random) + newLine;
				text = text + "Director of Personnel" + newLine;
				text = text + employerName + ", Inc.";
			}
			return text;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00003DAC File Offset: 0x00002DAC
		public int Weeks
		{
			get
			{
				DateTime d = this.EndDate;
				if (d == Job.NoEndDate)
				{
					d = S.MF.Now;
				}
				return (d - this.StartDate).Days / 7;
			}
		}

		// Token: 0x04000028 RID: 40
		public string EmployerName;

		// Token: 0x04000029 RID: 41
		public long EmployerID;

		// Token: 0x0400002A RID: 42
		public DateTime StartDate;

		// Token: 0x0400002B RID: 43
		public bool WasFired;

		// Token: 0x0400002C RID: 44
		public DateTime EndDate = Job.NoEndDate;

		// Token: 0x0400002D RID: 45
		public Type TaskType;

		// Token: 0x0400002E RID: 46
		public string Reference;

		// Token: 0x0400002F RID: 47
		public bool LeftForCause;

		// Token: 0x04000030 RID: 48
		public static DateTime NoEndDate = DateTime.MinValue;
	}
}
