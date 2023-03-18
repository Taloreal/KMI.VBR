using System;
using KMI.Sim;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Rack.
	/// </summary>
	// Token: 0x02000010 RID: 16
	[Serializable]
	public class Slushy : Station
	{
		// Token: 0x0600007A RID: 122 RVA: 0x00007A5F File Offset: 0x00006A5F
		public Slushy(NodeV2 node, int dy) : base(node, dy)
		{
			this.ImageName = "Slushie";
			this.RackType = "Slushy Machine";
			this.LikelihoodOfBreakingPerHour = 6E-05f;
		}
	}
}
