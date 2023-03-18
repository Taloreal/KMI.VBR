using System;
using System.Collections;

namespace KMI.Biz.Staffing
{
	// Token: 0x02000003 RID: 3
	public interface IBizStaffingStateAdapter
	{
		// Token: 0x06000015 RID: 21
		int[,] GetSchedule(long entityID);

		// Token: 0x06000016 RID: 22
		void SetSchedule(long entityID, int[,] schedule);

		// Token: 0x06000017 RID: 23
		Hashtable GetWages(long entityID);

		// Token: 0x06000018 RID: 24
		void SetWages(long entityID, Hashtable wages);
	}
}
