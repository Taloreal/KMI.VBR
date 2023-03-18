using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;

namespace KMI.Biz.Staffing
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class EmployeeBase : MovableActiveObject
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00003E18 File Offset: 0x00002E18
		public long ID
		{
			get
			{
				return this.id;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003E30 File Offset: 0x00002E30
		public EmployeeBase()
		{
			this.id = S.ST.GetNextID();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003E64 File Offset: 0x00002E64
		public int WeeksOfExperience(Type taskType)
		{
			int num = 0;
			foreach (object obj in this.colJobs)
			{
				Job job = (Job)obj;
				if (job.TaskType == taskType)
				{
					num += job.Weeks;
				}
			}
			return num;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00003EEC File Offset: 0x00002EEC
		public DateTime StartDate
		{
			get
			{
				int num = this.colJobs.Count - 1;
				while (num >= 0 && ((Job)this.colJobs[num]).EmployerName == ((Job)this.colJobs[this.colJobs.Count - 1]).EmployerName)
				{
					num--;
				}
				return ((Job)this.colJobs[num + 1]).StartDate;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00003F74 File Offset: 0x00002F74
		public string FullName
		{
			get
			{
				return this.FirstName + " " + this.LastName;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00003F9C File Offset: 0x00002F9C
		public int EducationLevel
		{
			get
			{
				int result;
				if (this.FourYearCollegeName != null)
				{
					result = 3;
				}
				else if (this.TwoYearCollegeName != null)
				{
					result = 2;
				}
				else if (this.HighSchoolName != null)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00003FE4 File Offset: 0x00002FE4
		public string LastEmployerName
		{
			get
			{
				return ((Job)this.colJobs[this.colJobs.Count - 1]).EmployerName;
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00004018 File Offset: 0x00003018
		public void AddJob(Entity entity, Type taskType)
		{
			Job job = new Job();
			job.EmployerName = entity.Name;
			job.EmployerID = entity.ID;
			job.TaskType = taskType;
			job.StartDate = S.ST.Now;
			this.colJobs.Add(job);
			for (int i = 0; i < 4; i++)
			{
				this.fProductivity[i] = -1;
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004084 File Offset: 0x00003084
		public void EndJob(bool wasFired)
		{
			Job job = (Job)this.colJobs[this.colJobs.Count - 1];
			job.WasFired = wasFired;
			job.EndDate = S.ST.Now;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000040C8 File Offset: 0x000030C8
		public Entity CurrentEmployer
		{
			get
			{
				Entity result;
				if (this.CurrentJob == null)
				{
					result = null;
				}
				else
				{
					result = (Entity)S.ST.Entity[this.CurrentJob.EmployerID];
				}
				return result;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00004114 File Offset: 0x00003114
		public Job CurrentJob
		{
			get
			{
				if (this.colJobs.Count > 0)
				{
					Job job = (Job)this.colJobs[this.colJobs.Count - 1];
					if (job.EndDate == Job.NoEndDate)
					{
						return job;
					}
				}
				return null;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00004178 File Offset: 0x00003178
		public bool WasFiredByOrLeftForCause(long entityID)
		{
			foreach (object obj in this.colJobs)
			{
				Job job = (Job)obj;
				if (job.EmployerID == entityID && (job.WasFired || job.LeftForCause))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004208 File Offset: 0x00003208
		public void IncrementProduction()
		{
			this.fProductivity[S.ST.CurrentWeek % 4]++;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000422F File Offset: 0x0000322F
		public override void NewWeek()
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004234 File Offset: 0x00003234
		public int ProductivityWeekly()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 4; i++)
			{
				if (this.fProductivity[i] != -1)
				{
					num += this.fProductivity[i];
					num2++;
				}
			}
			return num / Math.Max(1, num2);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004289 File Offset: 0x00003289
		public virtual Bitmap GetMugShot()
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000031 RID: 49
		public const int MaxRecentWeeks = 4;

		// Token: 0x04000032 RID: 50
		public int Shift;

		// Token: 0x04000033 RID: 51
		public int Task;

		// Token: 0x04000034 RID: 52
		public bool Fired;

		// Token: 0x04000035 RID: 53
		private int[] fProductivity = new int[4];

		// Token: 0x04000036 RID: 54
		protected long id;

		// Token: 0x04000037 RID: 55
		public string FirstName;

		// Token: 0x04000038 RID: 56
		public string LastName;

		// Token: 0x04000039 RID: 57
		public int image;

		// Token: 0x0400003A RID: 58
		public int Country;

		// Token: 0x0400003B RID: 59
		public string HighSchoolName;

		// Token: 0x0400003C RID: 60
		public string TwoYearCollegeName;

		// Token: 0x0400003D RID: 61
		public string FourYearCollegeName;

		// Token: 0x0400003E RID: 62
		public float MinAcceptableWage;

		// Token: 0x0400003F RID: 63
		public bool Telecommuter;

		// Token: 0x04000040 RID: 64
		public ArrayList colJobs = new ArrayList();
	}
}
