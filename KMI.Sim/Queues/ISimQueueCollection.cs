using System;
using System.Collections;

namespace KMI.Sim.Queues
{
	// Token: 0x02000060 RID: 96
	public interface ISimQueueCollection
	{
		// Token: 0x06000391 RID: 913
		ArrayList GetDrawables();

		// Token: 0x06000392 RID: 914
		void Go();

		// Token: 0x06000393 RID: 915
		void Stop();

		// Token: 0x06000394 RID: 916
		void Clear();

		// Token: 0x06000395 RID: 917
		bool NewStep();
	}
}
