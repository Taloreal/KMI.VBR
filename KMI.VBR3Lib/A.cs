using System;
using KMI.Sim;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// This class contains several static properties that
	/// act as syntactic shortcuts to important sim variables.
	/// </summary>
	// Token: 0x0200004A RID: 74
	public class A
	{
		/// <summary>
		/// Shortcut to AppSimSettings.
		/// </summary>
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x00021EE8 File Offset: 0x00020EE8
		public static AppSimSettings SS
		{
			get
			{
				return (AppSimSettings)Simulator.Instance.SimState.SimSettings;
			}
		}

		/// <summary>
		/// Shortcut to AppSimState.
		/// </summary>
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00021F10 File Offset: 0x00020F10
		public static AppSimState ST
		{
			get
			{
				return (AppSimState)Simulator.Instance.SimState;
			}
		}

		/// <summary>
		/// Shortcut to AppStateAdapter.
		/// </summary>
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00021F34 File Offset: 0x00020F34
		public static AppStateAdapter SA
		{
			get
			{
				return (AppStateAdapter)Simulator.Instance.SimStateAdapter;
			}
		}

		/// <summary>
		/// Shortcut to the singleton instance of Simulator.
		/// </summary>
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002EB RID: 747 RVA: 0x00021F58 File Offset: 0x00020F58
		public static Simulator I
		{
			get
			{
				return Simulator.Instance;
			}
		}

		/// <summary>
		/// Shortcut to the singleton instance of the Main Form.
		/// </summary>
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00021F70 File Offset: 0x00020F70
		public static frmMain MF
		{
			get
			{
				return (frmMain)frmMainBase.Instance;
			}
		}

		/// <summary>
		/// Shortcut to the application's resource handler.
		/// </summary>
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002ED RID: 749 RVA: 0x00021F8C File Offset: 0x00020F8C
		public static Resource R
		{
			get
			{
				return Simulator.Instance.Resource;
			}
		}
	}
}
