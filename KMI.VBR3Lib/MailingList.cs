using System;
using System.Collections;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for MailingList.
	/// </summary>
	// Token: 0x02000017 RID: 23
	[Serializable]
	public class MailingList
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x0000A685 File Offset: 0x00009685
		public MailingList()
		{
			this.name = this.name;
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x0000A6A8 File Offset: 0x000096A8
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x0000A6C0 File Offset: 0x000096C0
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x0400009C RID: 156
		protected string name;

		// Token: 0x0400009D RID: 157
		public ArrayList RecipientIDs = new ArrayList();
	}
}
