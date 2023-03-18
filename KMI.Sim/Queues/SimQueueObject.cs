using System;
using System.Drawing;
using KMI.Sim.Drawables;

namespace KMI.Sim.Queues
{
	// Token: 0x0200004C RID: 76
	[Serializable]
	public class SimQueueObject : ISimQueueObject
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x000152FC File Offset: 0x000142FC
		public SimQueueObject(string baseImageName)
		{
			this.location = new Point(int.MinValue, int.MinValue);
			this.baseImageName = baseImageName;
			this.orientation = "";
			this.actionState = "";
			this.waiting = true;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0001534C File Offset: 0x0001434C
		public virtual Drawable GetDrawable()
		{
			return new Drawable(this.location, this.baseImageName + this.orientation + this.actionState);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00015380 File Offset: 0x00014380
		public virtual void ChangeActionState()
		{
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x00015384 File Offset: 0x00014384
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x000153A1 File Offset: 0x000143A1
		public int X
		{
			get
			{
				return this.location.X;
			}
			set
			{
				this.location.X = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x000153B4 File Offset: 0x000143B4
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x000153D1 File Offset: 0x000143D1
		public int Y
		{
			get
			{
				return this.location.Y;
			}
			set
			{
				this.location.Y = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002AA RID: 682 RVA: 0x000153E4 File Offset: 0x000143E4
		// (set) Token: 0x060002AB RID: 683 RVA: 0x000153FC File Offset: 0x000143FC
		public Point Location
		{
			get
			{
				return this.location;
			}
			set
			{
				this.location = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00015408 File Offset: 0x00014408
		// (set) Token: 0x060002AD RID: 685 RVA: 0x00015420 File Offset: 0x00014420
		public string BaseImageName
		{
			get
			{
				return this.baseImageName;
			}
			set
			{
				this.baseImageName = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002AE RID: 686 RVA: 0x0001542C File Offset: 0x0001442C
		// (set) Token: 0x060002AF RID: 687 RVA: 0x00015444 File Offset: 0x00014444
		public string Orientation
		{
			get
			{
				return this.orientation;
			}
			set
			{
				this.orientation = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00015450 File Offset: 0x00014450
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x00015468 File Offset: 0x00014468
		public string ActionState
		{
			get
			{
				return this.actionState;
			}
			set
			{
				this.actionState = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00015474 File Offset: 0x00014474
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x0001548C File Offset: 0x0001448C
		public bool Waiting
		{
			get
			{
				return this.waiting;
			}
			set
			{
				this.waiting = value;
			}
		}

		// Token: 0x040001B5 RID: 437
		protected Point location;

		// Token: 0x040001B6 RID: 438
		protected string baseImageName;

		// Token: 0x040001B7 RID: 439
		protected string orientation;

		// Token: 0x040001B8 RID: 440
		protected string actionState;

		// Token: 0x040001B9 RID: 441
		protected bool waiting;
	}
}
