using System;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200007F RID: 127
	[Serializable]
	public class RunToDateReachedMessage : ModalMessage
	{
		// Token: 0x060004FA RID: 1274 RVA: 0x00026B53 File Offset: 0x00025B53
		public RunToDateReachedMessage() : base("", null, null, MessageBoxIcon.Hand)
		{
		}
	}
}
