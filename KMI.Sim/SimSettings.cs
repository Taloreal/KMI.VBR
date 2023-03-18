using System;

namespace KMI.Sim
{
	// Token: 0x0200005F RID: 95
	[Serializable]
	public class SimSettings
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000372 RID: 882 RVA: 0x00019EA4 File Offset: 0x00018EA4
		// (set) Token: 0x06000373 RID: 883 RVA: 0x00019EBC File Offset: 0x00018EBC
		public DateTime StartDate
		{
			get
			{
				return this.startDate;
			}
			set
			{
				this.startDate = value;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000374 RID: 884 RVA: 0x00019EC8 File Offset: 0x00018EC8
		// (set) Token: 0x06000375 RID: 885 RVA: 0x00019EE0 File Offset: 0x00018EE0
		public DateTime StopDate
		{
			get
			{
				return this.stopDate;
			}
			set
			{
				this.stopDate = value;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000376 RID: 886 RVA: 0x00019EEC File Offset: 0x00018EEC
		// (set) Token: 0x06000377 RID: 887 RVA: 0x00019F04 File Offset: 0x00018F04
		public int RandomSeed
		{
			get
			{
				return this.randomSeed;
			}
			set
			{
				this.randomSeed = value;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000378 RID: 888 RVA: 0x00019F10 File Offset: 0x00018F10
		// (set) Token: 0x06000379 RID: 889 RVA: 0x00019F28 File Offset: 0x00018F28
		public byte[] PdfAssignment
		{
			get
			{
				return this.pdfAssignment;
			}
			set
			{
				this.pdfAssignment = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00019F34 File Offset: 0x00018F34
		// (set) Token: 0x0600037B RID: 891 RVA: 0x00019F4C File Offset: 0x00018F4C
		public bool Seasonality
		{
			get
			{
				return this.seasonality;
			}
			set
			{
				this.seasonality = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600037C RID: 892 RVA: 0x00019F58 File Offset: 0x00018F58
		// (set) Token: 0x0600037D RID: 893 RVA: 0x00019F70 File Offset: 0x00018F70
		public bool LevelManagementOn
		{
			get
			{
				return this.levelManagementOn;
			}
			set
			{
				this.levelManagementOn = value;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600037E RID: 894 RVA: 0x00019F7C File Offset: 0x00018F7C
		// (set) Token: 0x0600037F RID: 895 RVA: 0x00019F94 File Offset: 0x00018F94
		public virtual int Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00019FA0 File Offset: 0x00018FA0
		// (set) Token: 0x06000381 RID: 897 RVA: 0x00019FB8 File Offset: 0x00018FB8
		public int StudentOrg
		{
			get
			{
				return this.studentOrg;
			}
			set
			{
				this.studentOrg = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00019FC4 File Offset: 0x00018FC4
		// (set) Token: 0x06000383 RID: 899 RVA: 0x00019FDC File Offset: 0x00018FDC
		public string BlockMessagesContaining
		{
			get
			{
				return this.blockMessagesContaining;
			}
			set
			{
				this.blockMessagesContaining = value;
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00019FE8 File Offset: 0x00018FE8
		public virtual bool AllowInstructorToEdit(string propertyName)
		{
			return false;
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00019FFC File Offset: 0x00018FFC
		// (set) Token: 0x06000386 RID: 902 RVA: 0x0001A014 File Offset: 0x00019014
		public bool ReservedBool1
		{
			get
			{
				return this.reservedBool1;
			}
			set
			{
				this.reservedBool1 = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0001A020 File Offset: 0x00019020
		// (set) Token: 0x06000388 RID: 904 RVA: 0x0001A038 File Offset: 0x00019038
		public bool ReservedBool2
		{
			get
			{
				return this.reservedBool2;
			}
			set
			{
				this.reservedBool2 = value;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000389 RID: 905 RVA: 0x0001A044 File Offset: 0x00019044
		// (set) Token: 0x0600038A RID: 906 RVA: 0x0001A05C File Offset: 0x0001905C
		public bool ReservedBool3
		{
			get
			{
				return this.reservedBool3;
			}
			set
			{
				this.reservedBool3 = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0001A068 File Offset: 0x00019068
		// (set) Token: 0x0600038C RID: 908 RVA: 0x0001A080 File Offset: 0x00019080
		public float ReservedFloat1
		{
			get
			{
				return this.reservedFloat1;
			}
			set
			{
				this.reservedFloat1 = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0001A08C File Offset: 0x0001908C
		// (set) Token: 0x0600038E RID: 910 RVA: 0x0001A0A4 File Offset: 0x000190A4
		public float ReservedFloat2
		{
			get
			{
				return this.reservedFloat2;
			}
			set
			{
				this.reservedFloat2 = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600038F RID: 911 RVA: 0x0001A0B0 File Offset: 0x000190B0
		// (set) Token: 0x06000390 RID: 912 RVA: 0x0001A0C8 File Offset: 0x000190C8
		public float ReservedFloat3
		{
			get
			{
				return this.reservedFloat3;
			}
			set
			{
				this.reservedFloat3 = value;
			}
		}

		// Token: 0x0400023A RID: 570
		protected DateTime startDate = new DateTime(2008, 1, 5, 23, 59, 59);

		// Token: 0x0400023B RID: 571
		protected DateTime stopDate;

		// Token: 0x0400023C RID: 572
		protected int randomSeed = -1;

		// Token: 0x0400023D RID: 573
		protected byte[] pdfAssignment;

		// Token: 0x0400023E RID: 574
		protected bool seasonality = true;

		// Token: 0x0400023F RID: 575
		protected bool levelManagementOn = true;

		// Token: 0x04000240 RID: 576
		protected int level = 0;

		// Token: 0x04000241 RID: 577
		protected int studentOrg = 0;

		// Token: 0x04000242 RID: 578
		protected string blockMessagesContaining = "";

		// Token: 0x04000243 RID: 579
		protected bool reservedBool1;

		// Token: 0x04000244 RID: 580
		protected bool reservedBool2;

		// Token: 0x04000245 RID: 581
		protected bool reservedBool3;

		// Token: 0x04000246 RID: 582
		protected float reservedFloat1;

		// Token: 0x04000247 RID: 583
		protected float reservedFloat2;

		// Token: 0x04000248 RID: 584
		protected float reservedFloat3;
	}
}
