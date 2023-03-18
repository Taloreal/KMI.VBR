using System;
using System.Reflection;

namespace KMI.Sim
{
	// Token: 0x02000048 RID: 72
	[Serializable]
	public class MacroAction
	{
		// Token: 0x0600028A RID: 650 RVA: 0x0001517C File Offset: 0x0001417C
		public MacroAction()
		{
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00015187 File Offset: 0x00014187
		public MacroAction(MethodBase method, object[] argumentValues, DateTime timestamp)
		{
			this.method = method;
			this.argumentValues = argumentValues;
			this.timestamp = timestamp;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600028C RID: 652 RVA: 0x000151A8 File Offset: 0x000141A8
		public MethodBase Method
		{
			get
			{
				return this.method;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600028D RID: 653 RVA: 0x000151C0 File Offset: 0x000141C0
		public object[] ArgumentValues
		{
			get
			{
				return this.argumentValues;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600028E RID: 654 RVA: 0x000151D8 File Offset: 0x000141D8
		public DateTime Timestamp
		{
			get
			{
				return this.timestamp;
			}
		}

		// Token: 0x040001B0 RID: 432
		protected MethodBase method;

		// Token: 0x040001B1 RID: 433
		protected object[] argumentValues;

		// Token: 0x040001B2 RID: 434
		protected DateTime timestamp;
	}
}
