using System;

namespace KMI.Sim
{
	// Token: 0x02000068 RID: 104
	[Serializable]
	public class UserAdminSettings
	{
		// Token: 0x060003C7 RID: 967 RVA: 0x0001C6C0 File Offset: 0x0001B6C0
		public UserAdminSettings()
		{
			this.defaultDirectory = null;
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0001C710 File Offset: 0x0001B710
		// (set) Token: 0x060003C9 RID: 969 RVA: 0x0001C728 File Offset: 0x0001B728
		public string DefaultDirectory
		{
			get
			{
				return this.defaultDirectory;
			}
			set
			{
				this.defaultDirectory = value;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0001C734 File Offset: 0x0001B734
		// (set) Token: 0x060003CB RID: 971 RVA: 0x0001C74C File Offset: 0x0001B74C
		public string ProxyAddress
		{
			get
			{
				return this.proxyAddress;
			}
			set
			{
				this.proxyAddress = value;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060003CC RID: 972 RVA: 0x0001C758 File Offset: 0x0001B758
		// (set) Token: 0x060003CD RID: 973 RVA: 0x0001C770 File Offset: 0x0001B770
		public string ProxyBypassList
		{
			get
			{
				return this.proxyBypassList;
			}
			set
			{
				this.proxyBypassList = value;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060003CE RID: 974 RVA: 0x0001C77C File Offset: 0x0001B77C
		// (set) Token: 0x060003CF RID: 975 RVA: 0x0001C794 File Offset: 0x0001B794
		public int P
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0001C7A0 File Offset: 0x0001B7A0
		public string GetP()
		{
			int num = this.p;
			if (num <= 23)
			{
				switch (num)
				{
				case 7:
					return "JackRabbit";
				case 8:
				case 10:
					break;
				case 9:
					return "SuperStore";
				case 11:
					return "LearnFast";
				default:
					if (num == 23)
					{
						return "CustomerIsKing";
					}
					break;
				}
			}
			else
			{
				if (num == 39)
				{
					return "LuckyLearners";
				}
				if (num == 47)
				{
					return "CoolSchool";
				}
			}
			return "XGHYMZ";
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x0001C824 File Offset: 0x0001B824
		// (set) Token: 0x060003D2 RID: 978 RVA: 0x0001C83C File Offset: 0x0001B83C
		public bool NoSound
		{
			get
			{
				return this.noSound;
			}
			set
			{
				this.noSound = value;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x0001C848 File Offset: 0x0001B848
		// (set) Token: 0x060003D4 RID: 980 RVA: 0x0001C860 File Offset: 0x0001B860
		public int MultiplayerBasePort
		{
			get
			{
				return this.multiplayerBasePort;
			}
			set
			{
				this.multiplayerBasePort = value;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x0001C86C File Offset: 0x0001B86C
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x0001C884 File Offset: 0x0001B884
		public int MultiplayerPortCount
		{
			get
			{
				return this.multiplayerPortCount;
			}
			set
			{
				this.multiplayerPortCount = value;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x0001C890 File Offset: 0x0001B890
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x0001C8A8 File Offset: 0x0001B8A8
		public int ClientDrawStepPeriod
		{
			get
			{
				return this.clientDrawStepPeriod;
			}
			set
			{
				this.clientDrawStepPeriod = value;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x0001C8B4 File Offset: 0x0001B8B4
		// (set) Token: 0x060003DA RID: 986 RVA: 0x0001C8CC File Offset: 0x0001B8CC
		public bool PasswordsForMultiplayer
		{
			get
			{
				return this.passwordsForMultiplayer;
			}
			set
			{
				this.passwordsForMultiplayer = value;
			}
		}

		// Token: 0x04000287 RID: 647
		protected bool noSound = false;

		// Token: 0x04000288 RID: 648
		protected int multiplayerBasePort = 20172;

		// Token: 0x04000289 RID: 649
		protected int multiplayerPortCount = 10;

		// Token: 0x0400028A RID: 650
		protected int clientDrawStepPeriod = 50;

		// Token: 0x0400028B RID: 651
		protected bool passwordsForMultiplayer = false;

		// Token: 0x0400028C RID: 652
		protected string language;

		// Token: 0x0400028D RID: 653
		protected string defaultDirectory;

		// Token: 0x0400028E RID: 654
		protected string proxyAddress;

		// Token: 0x0400028F RID: 655
		protected string proxyBypassList;

		// Token: 0x04000290 RID: 656
		protected int p = 11;
	}
}
