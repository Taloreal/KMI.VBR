using System;
using System.Collections;
using System.Drawing;

namespace KMI.Sim
{
	// Token: 0x02000047 RID: 71
	[Serializable]
	public class PathV2
	{
		// Token: 0x06000288 RID: 648 RVA: 0x000150BC File Offset: 0x000140BC
		public ArrayList ToPoints()
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 1; i < this.nodes.Count; i++)
			{
				PointF pointF = ((NodeV2)this.nodes[i]).Location;
				arrayList.Add(pointF);
			}
			return arrayList;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0001511C File Offset: 0x0001411C
		public ArrayList ToDistributedPoints()
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 1; i < this.nodes.Count; i++)
			{
				PointF pointF = ((NodeV2)this.nodes[i]).DistributedLocation;
				arrayList.Add(pointF);
			}
			return arrayList;
		}

		// Token: 0x040001AF RID: 431
		public ArrayList nodes = new ArrayList();
	}
}
