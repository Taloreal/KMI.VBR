using System;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for RadioStation.
	/// </summary>
	// Token: 0x02000031 RID: 49
	[Serializable]
	public class RadioStation
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00013E18 File Offset: 0x00012E18
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00013E30 File Offset: 0x00012E30
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00013E3C File Offset: 0x00012E3C
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00013E54 File Offset: 0x00012E54
		public string Format
		{
			get
			{
				return this.format;
			}
			set
			{
				this.format = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00013E60 File Offset: 0x00012E60
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00013E78 File Offset: 0x00012E78
		public string SampleSongFilename
		{
			get
			{
				return this.sampleSongFilename;
			}
			set
			{
				this.sampleSongFilename = value;
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00013E84 File Offset: 0x00012E84
		public static RadioStation.Rotations InRotation(int hour)
		{
			RadioStation.Rotations result;
			if (hour >= 6 && hour <= 9)
			{
				result = RadioStation.Rotations.MorningDrivetime;
			}
			else if (hour >= 10 && hour <= 16)
			{
				result = RadioStation.Rotations.Daytime;
			}
			else if (hour >= 17 && hour <= 20)
			{
				result = RadioStation.Rotations.EveningDriveTime;
			}
			else
			{
				result = RadioStation.Rotations.LateNight;
			}
			return result;
		}

		// Token: 0x0400013C RID: 316
		public const int NumRotations = 4;

		// Token: 0x0400013D RID: 317
		protected string name;

		// Token: 0x0400013E RID: 318
		protected string format;

		// Token: 0x0400013F RID: 319
		protected string sampleSongFilename;

		// Token: 0x04000140 RID: 320
		public int Reach;

		// Token: 0x02000032 RID: 50
		public enum Rotations
		{
			// Token: 0x04000142 RID: 322
			MorningDrivetime,
			// Token: 0x04000143 RID: 323
			Daytime,
			// Token: 0x04000144 RID: 324
			EveningDriveTime,
			// Token: 0x04000145 RID: 325
			LateNight
		}
	}
}
