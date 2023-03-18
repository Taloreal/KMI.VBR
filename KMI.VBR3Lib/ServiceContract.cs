using System;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for ServiceContract.
	/// </summary>
	// Token: 0x0200003A RID: 58
	[Serializable]
	public class ServiceContract
	{
		// Token: 0x06000179 RID: 377 RVA: 0x00015186 File Offset: 0x00014186
		public ServiceContract(string rackType)
		{
			this.RackType = rackType;
		}

		// Token: 0x04000179 RID: 377
		public int ResponseTimeIndex = 0;

		// Token: 0x0400017A RID: 378
		public string RackType;

		// Token: 0x0400017B RID: 379
		public int UnitsCovered;
	}
}
