﻿using System;
using System.Collections;
using System.Drawing;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200003B RID: 59
	[Serializable]
	public class NodeV2
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000242 RID: 578 RVA: 0x0001295C File Offset: 0x0001195C
		// (set) Token: 0x06000243 RID: 579 RVA: 0x0001297F File Offset: 0x0001197F
		public Point Location
		{
			get
			{
				return new Point(this.x, this.y);
			}
			set
			{
				this.x = value.X;
				this.y = value.Y;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0001299C File Offset: 0x0001199C
		public Point DistributedLocation
		{
			get
			{
				int num = S.ST.Random.Next(this.width);
				int num2 = S.ST.Random.Next(this.height);
				PointF pointF = Utilities.cartesianToIsometric(this.centerx * (float)this.width / 1f, this.centery * (float)this.height / 1f, 0f, 0f, 1f, 1f);
				PointF pointF2 = Utilities.cartesianToIsometric((float)num, (float)num2, (float)this.x - pointF.X, (float)this.y - pointF.Y, 1f, 1f);
				return new Point((int)pointF2.X, (int)pointF2.Y);
			}
		}

		// Token: 0x0400015F RID: 351
		public string name = "";

		// Token: 0x04000160 RID: 352
		public int x;

		// Token: 0x04000161 RID: 353
		public int y;

		// Token: 0x04000162 RID: 354
		public int width = 8;

		// Token: 0x04000163 RID: 355
		public int height = 8;

		// Token: 0x04000164 RID: 356
		public float centerx = 0.5f;

		// Token: 0x04000165 RID: 357
		public float centery = 0.5f;

		// Token: 0x04000166 RID: 358
		public bool visited = false;

		// Token: 0x04000167 RID: 359
		public bool blocked = false;

		// Token: 0x04000168 RID: 360
		public ArrayList nodes = new ArrayList();

		// Token: 0x04000169 RID: 361
		public int weight = 0;

		// Token: 0x0400016A RID: 362
		[NonSerialized]
		public bool isDead;

		// Token: 0x0400016B RID: 363
		[NonSerialized]
		public int distance;

		// Token: 0x0400016C RID: 364
		[NonSerialized]
		public NodeV2 nextLink;
	}
}
