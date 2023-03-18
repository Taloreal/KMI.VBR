using System;
using KMI.Sim;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for CoolingDuct.
	/// </summary>
	// Token: 0x02000044 RID: 68
	[Serializable]
	public class CoolingDuct : SectionBase
	{
		// Token: 0x06000208 RID: 520 RVA: 0x0001E454 File Offset: 0x0001D454
		public CoolingDuct(NodeV2 node, int dy) : base(node, dy)
		{
			this.LikelihoodOfBreakingPerHour = 6E-05f;
			this.RackType = "Backroom Cooling Duct";
		}
	}
}
