using System;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200005D RID: 93
	public class MultiplayerRole
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000365 RID: 869 RVA: 0x00019850 File Offset: 0x00018850
		// (set) Token: 0x06000366 RID: 870 RVA: 0x00019868 File Offset: 0x00018868
		public string RoleName
		{
			get
			{
				return this.roleName;
			}
			set
			{
				this.roleName = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00019874 File Offset: 0x00018874
		// (set) Token: 0x06000368 RID: 872 RVA: 0x0001988C File Offset: 0x0001888C
		public string DisableListConcatenated
		{
			get
			{
				return this.disableListConcatenated;
			}
			set
			{
				this.disableListConcatenated = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00019898 File Offset: 0x00018898
		// (set) Token: 0x0600036A RID: 874 RVA: 0x000198B0 File Offset: 0x000188B0
		public bool ReceivesMessages
		{
			get
			{
				return this.receivesMessages;
			}
			set
			{
				this.receivesMessages = value;
			}
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000198BC File Offset: 0x000188BC
		public bool DisableListContains(string text)
		{
			foreach (string b in this.DisableList)
			{
				if (Utilities.NoAmpersand(Utilities.NoEllipsis(text)) == b)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00019910 File Offset: 0x00018910
		public static void LoadRolesFromTable(Type type, string resource)
		{
			MultiplayerRole.Roles = (MultiplayerRole[])TableReader.Read(type.Assembly, typeof(MultiplayerRole), resource);
			foreach (MultiplayerRole multiplayerRole in MultiplayerRole.Roles)
			{
				multiplayerRole.DisableList = multiplayerRole.DisableListConcatenated.Split(new char[]
				{
					'|'
				});
				multiplayerRole.DisableListConcatenated = null;
			}
		}

		// Token: 0x0400022E RID: 558
		public static MultiplayerRole[] Roles;

		// Token: 0x0400022F RID: 559
		protected string roleName;

		// Token: 0x04000230 RID: 560
		protected string disableListConcatenated;

		// Token: 0x04000231 RID: 561
		public bool receivesMessages;

		// Token: 0x04000232 RID: 562
		public string[] DisableList;
	}
}
