using System;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000049 RID: 73
	[Serializable]
	public class StopDateReachedMessage : ModalMessage
	{
		// Token: 0x0600028F RID: 655 RVA: 0x000151F0 File Offset: 0x000141F0
		public StopDateReachedMessage() : base("", null, null, MessageBoxIcon.Hand)
		{
		}
	}
}
