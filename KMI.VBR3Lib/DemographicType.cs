using System;
using System.Collections;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for DemographicType.
	/// </summary>
	// Token: 0x0200000B RID: 11
	[Serializable]
	public class DemographicType
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000474C File Offset: 0x0000374C
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00004764 File Offset: 0x00003764
		public int AvgAge
		{
			get
			{
				return this.avgAge;
			}
			set
			{
				this.avgAge = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00004770 File Offset: 0x00003770
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00004788 File Offset: 0x00003788
		public int StdDevAge
		{
			get
			{
				return this.stdDevAge;
			}
			set
			{
				this.stdDevAge = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00004794 File Offset: 0x00003794
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000047AC File Offset: 0x000037AC
		public int AvgIncome
		{
			get
			{
				return this.avgIncome;
			}
			set
			{
				this.avgIncome = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000047B8 File Offset: 0x000037B8
		// (set) Token: 0x0600002F RID: 47 RVA: 0x000047D0 File Offset: 0x000037D0
		public int StdDevIncome
		{
			get
			{
				return this.stdDevIncome;
			}
			set
			{
				this.stdDevIncome = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000047DC File Offset: 0x000037DC
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000047F4 File Offset: 0x000037F4
		public string ProbShopEvery2HhrsStart7am
		{
			get
			{
				return "";
			}
			set
			{
				string[] temp = value.Split(new char[]
				{
					'|'
				});
				this.shoppingTimeDist = new float[temp.Length];
				float total = 0f;
				float runningTotal = 0f;
				for (int i = 0; i < temp.Length; i++)
				{
					total += float.Parse(temp[i]);
				}
				if (total != 0f)
				{
					for (int i = 0; i < temp.Length; i++)
					{
						runningTotal += float.Parse(temp[i]);
						this.shoppingTimeDist[i] = runningTotal / total;
					}
				}
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000488C File Offset: 0x0000388C
		public float[] ShoppingTimeDist
		{
			get
			{
				return this.shoppingTimeDist;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000048A4 File Offset: 0x000038A4
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000048BC File Offset: 0x000038BC
		public string NeedsListTemp
		{
			get
			{
				return "";
			}
			set
			{
				string[] temp = value.Split(new char[]
				{
					'|'
				});
				foreach (string s in temp)
				{
					this.needs.Add(int.Parse(s));
				}
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00004918 File Offset: 0x00003918
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00004930 File Offset: 0x00003930
		public string ImpulseItemsListTemp
		{
			get
			{
				return "";
			}
			set
			{
				string[] temp = value.Split(new char[]
				{
					'|'
				});
				foreach (string s in temp)
				{
					this.impulseItems.Add(int.Parse(s));
				}
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000498C File Offset: 0x0000398C
		public ArrayList Needs
		{
			get
			{
				return this.needs;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000049A4 File Offset: 0x000039A4
		public ArrayList ImpulseItems
		{
			get
			{
				return this.impulseItems;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000049BC File Offset: 0x000039BC
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000049D4 File Offset: 0x000039D4
		public string Occupation
		{
			get
			{
				return this.occupation;
			}
			set
			{
				this.occupation = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000049E0 File Offset: 0x000039E0
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000049F8 File Offset: 0x000039F8
		public int PreferredHome
		{
			get
			{
				return this.preferredHome;
			}
			set
			{
				this.preferredHome = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00004A04 File Offset: 0x00003A04
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00004A1C File Offset: 0x00003A1C
		public float PctInPreferredHome
		{
			get
			{
				return this.pctInPreferredHome;
			}
			set
			{
				this.pctInPreferredHome = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00004A28 File Offset: 0x00003A28
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00004A40 File Offset: 0x00003A40
		public int PreferredWorkplace
		{
			get
			{
				return this.preferredWorkplace;
			}
			set
			{
				this.preferredWorkplace = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00004A4C File Offset: 0x00003A4C
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00004A64 File Offset: 0x00003A64
		public float PctInPreferredWorkplace
		{
			get
			{
				return this.pctInPreferredWorkplace;
			}
			set
			{
				this.pctInPreferredWorkplace = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00004A70 File Offset: 0x00003A70
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00004A88 File Offset: 0x00003A88
		public int PreferredRadioStation
		{
			get
			{
				return this.preferredRadioStation;
			}
			set
			{
				this.preferredRadioStation = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00004A94 File Offset: 0x00003A94
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00004AAC File Offset: 0x00003AAC
		public float PctPreferredRadioStation
		{
			get
			{
				return this.pctPreferredRadioStation;
			}
			set
			{
				this.pctPreferredRadioStation = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00004AB8 File Offset: 0x00003AB8
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00004AD0 File Offset: 0x00003AD0
		public bool PriceSensitive
		{
			get
			{
				return this.priceSensitive;
			}
			set
			{
				this.priceSensitive = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00004ADC File Offset: 0x00003ADC
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00004AF4 File Offset: 0x00003AF4
		public int WaitTolerance
		{
			get
			{
				return this.waitTolerance;
			}
			set
			{
				this.waitTolerance = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00004B00 File Offset: 0x00003B00
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00004B18 File Offset: 0x00003B18
		public int Index
		{
			get
			{
				return this.index;
			}
			set
			{
				this.index = value;
			}
		}

		// Token: 0x04000032 RID: 50
		protected int avgAge;

		// Token: 0x04000033 RID: 51
		protected int stdDevAge;

		// Token: 0x04000034 RID: 52
		protected int avgIncome;

		// Token: 0x04000035 RID: 53
		protected int stdDevIncome;

		// Token: 0x04000036 RID: 54
		protected float[] shoppingTimeDist;

		// Token: 0x04000037 RID: 55
		protected ArrayList needs = new ArrayList();

		// Token: 0x04000038 RID: 56
		protected ArrayList impulseItems = new ArrayList();

		// Token: 0x04000039 RID: 57
		protected string occupation;

		// Token: 0x0400003A RID: 58
		protected int preferredHome;

		// Token: 0x0400003B RID: 59
		protected float pctInPreferredHome;

		// Token: 0x0400003C RID: 60
		protected int preferredWorkplace;

		// Token: 0x0400003D RID: 61
		protected float pctInPreferredWorkplace;

		// Token: 0x0400003E RID: 62
		protected int preferredRadioStation;

		// Token: 0x0400003F RID: 63
		protected float pctPreferredRadioStation;

		// Token: 0x04000040 RID: 64
		protected bool priceSensitive;

		// Token: 0x04000041 RID: 65
		protected int waitTolerance;

		// Token: 0x04000042 RID: 66
		protected int index;

		// Token: 0x0200000C RID: 12
		public enum Types
		{
			// Token: 0x04000044 RID: 68
			Student,
			// Token: 0x04000045 RID: 69
			Professional,
			// Token: 0x04000046 RID: 70
			Retiree
		}
	}
}
