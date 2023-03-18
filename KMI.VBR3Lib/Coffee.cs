using System;
using KMI.Sim;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Rack.
	/// </summary>
	// Token: 0x02000036 RID: 54
	[Serializable]
	public class Coffee : Station
	{
		// Token: 0x06000172 RID: 370 RVA: 0x0001443C File Offset: 0x0001343C
		public Coffee(NodeV2 node, int dy) : base(node, dy)
		{
			this.ImageName = "Coffee";
			this.LikelihoodOfBreakingPerHour = 6E-05f;
			this.RackType = "Coffee Station";
		}
	}
}
