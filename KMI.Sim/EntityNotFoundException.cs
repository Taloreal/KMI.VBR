using System;
using System.Collections;
using System.Runtime.Serialization;

namespace KMI.Sim
{
	// Token: 0x0200007D RID: 125
	[Serializable]
	public class EntityNotFoundException : SimApplicationException
	{
		// Token: 0x060004E3 RID: 1251 RVA: 0x00026456 File Offset: 0x00025456
		public EntityNotFoundException()
		{
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00026464 File Offset: 0x00025464
		public EntityNotFoundException(string messageStringResource) : base(messageStringResource)
		{
			this.existingEntityID = -1L;
			if (S.ST.Entity != null)
			{

				IEnumerator enumerator = S.ST.Entity.Values.GetEnumerator();
					if (enumerator.MoveNext())
					{
						Entity entity = (Entity)enumerator.Current;
						this.existingEntityID = entity.ID;
					}
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00026500 File Offset: 0x00025500
		public EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.existingEntityID = (long)info.GetValue("existingEntityID", typeof(long));
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x00026530 File Offset: 0x00025530
		public long ExistingEntityID
		{
			get
			{
				return this.existingEntityID;
			}
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00026548 File Offset: 0x00025548
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("existingEntityID", this.existingEntityID);
		}

		// Token: 0x0400036B RID: 875
		protected long existingEntityID;
	}
}
