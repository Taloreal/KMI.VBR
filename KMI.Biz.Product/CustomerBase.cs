using System;
using System.Collections;
using KMI.Sim;

namespace KMI.Biz.Product
{
	// Token: 0x0200001D RID: 29
	[Serializable]
	public abstract class CustomerBase : ActiveObject
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x0000D465 File Offset: 0x0000C465
		public CustomerBase()
		{
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000D47C File Offset: 0x0000C47C
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000D494 File Offset: 0x0000C494
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

		// Token: 0x060000D7 RID: 215 RVA: 0x0000D4A0 File Offset: 0x0000C4A0
		public bool Credit(Entity entity)
		{
			return this.credit.Contains(entity);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000D4C0 File Offset: 0x0000C4C0
		public void SetCredit(Entity entity, bool Value)
		{
			if (Value)
			{
				if (!this.credit.Contains(entity))
				{
					this.credit.Add(entity);
				}
			}
			else
			{
				this.credit.Remove(entity);
			}
		}

		// Token: 0x04000127 RID: 295
		protected string name;

		// Token: 0x04000128 RID: 296
		protected ArrayList credit = new ArrayList();
	}
}
