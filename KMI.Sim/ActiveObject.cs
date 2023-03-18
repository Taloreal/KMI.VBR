using System;

namespace KMI.Sim
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	public class ActiveObject
	{
		// Token: 0x060000FD RID: 253 RVA: 0x000084D1 File Offset: 0x000074D1
		public virtual bool NewStep()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000084D9 File Offset: 0x000074D9
		public virtual void NewHour()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000084E1 File Offset: 0x000074E1
		public virtual void NewDay()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000084E9 File Offset: 0x000074E9
		public virtual void NewWeek()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000084F1 File Offset: 0x000074F1
		public virtual void NewYear()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000102 RID: 258 RVA: 0x000084FC File Offset: 0x000074FC
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00008514 File Offset: 0x00007514
		public virtual DateTime WakeupTime
		{
			get
			{
				return this.wakeupTime;
			}
			set
			{
				this.wakeupTime = value;
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000851E File Offset: 0x0000751E
		public virtual void Retire()
		{
			S.I.UnSubscribe(this);
		}

		// Token: 0x04000088 RID: 136
		protected DateTime wakeupTime;
	}
}
