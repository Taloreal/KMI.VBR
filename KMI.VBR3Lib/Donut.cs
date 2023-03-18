using System;
using KMI.Sim;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Rack.
	/// </summary>
	// Token: 0x02000030 RID: 48
	[Serializable]
	public class Donut : Station
	{
		// Token: 0x0600015E RID: 350 RVA: 0x00013DE8 File Offset: 0x00012DE8
		public Donut(NodeV2 node, int dy) : base(node, dy)
		{
			this.ImageName = "Donut";
			this.RackType = "Donut Station";
		}
	}
}
