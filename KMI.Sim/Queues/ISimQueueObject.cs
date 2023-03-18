using System;
using System.Drawing;
using KMI.Sim.Drawables;

namespace KMI.Sim.Queues
{
	// Token: 0x0200004B RID: 75
	public interface ISimQueueObject
	{
		// Token: 0x06000293 RID: 659
		Drawable GetDrawable();

		// Token: 0x06000294 RID: 660
		void ChangeActionState();

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000295 RID: 661
		// (set) Token: 0x06000296 RID: 662
		int X { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000297 RID: 663
		// (set) Token: 0x06000298 RID: 664
		int Y { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000299 RID: 665
		// (set) Token: 0x0600029A RID: 666
		Point Location { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600029B RID: 667
		// (set) Token: 0x0600029C RID: 668
		string BaseImageName { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600029D RID: 669
		// (set) Token: 0x0600029E RID: 670
		string Orientation { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600029F RID: 671
		// (set) Token: 0x060002A0 RID: 672
		string ActionState { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002A1 RID: 673
		// (set) Token: 0x060002A2 RID: 674
		bool Waiting { get; set; }
	}
}
