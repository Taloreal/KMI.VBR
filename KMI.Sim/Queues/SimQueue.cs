using System;
using System.Collections;
using System.Drawing;

namespace KMI.Sim.Queues
{
	// Token: 0x02000023 RID: 35
	[Serializable]
	public class SimQueue
	{
		// Token: 0x0600017A RID: 378 RVA: 0x0000CCBC File Offset: 0x0000BCBC
		public SimQueue()
		{
			this.segments = new ArrayList();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000CCD4 File Offset: 0x0000BCD4
		public virtual ArrayList GetDrawables()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.segments)
			{
				SimQueueSegment simQueueSegment = (SimQueueSegment)obj;
				arrayList.AddRange(simQueueSegment.GetDrawables());
			}
			return arrayList;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000CD54 File Offset: 0x0000BD54
		public virtual ArrayList GetQueueObjects()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.segments)
			{
				SimQueueSegment simQueueSegment = (SimQueueSegment)obj;
				arrayList.AddRange(simQueueSegment.QueueObjects);
			}
			return arrayList;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000CDD4 File Offset: 0x0000BDD4
		public virtual void Clear()
		{
			for (int i = 0; i < this.segments.Count; i++)
			{
				this[i].Clear();
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000CE0C File Offset: 0x0000BE0C
		public virtual void ExecuteStep()
		{
			for (int i = this.segments.Count - 1; i >= 0; i--)
			{
				this[i].MoveQueueObjects();
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000CE48 File Offset: 0x0000BE48
		public virtual void AppendSegment(SimQueueSegment segment)
		{
			if (this.SegmentCount == 0)
			{
				this.segments.Add(segment);
			}
			else
			{
				this[this.SegmentCount - 1].Next.Add(segment);
				segment.Previous.Add(this[this.SegmentCount - 1]);
				this.segments.Add(segment);
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000CEBC File Offset: 0x0000BEBC
		public virtual void Connect(SimQueue queue)
		{
			if (!this[this.SegmentCount - 1].Next.Contains(queue[0]))
			{
				this[this.SegmentCount - 1].Next.Add(queue[0]);
			}
			if (!queue[0].Previous.Contains(this[this.SegmentCount - 1]))
			{
				queue[0].Previous.Add(this[this.SegmentCount - 1]);
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000CF54 File Offset: 0x0000BF54
		public virtual void Disconnect(SimQueue queue)
		{
			if (this[this.SegmentCount - 1].Next.Contains(queue[0]))
			{
				this[this.SegmentCount - 1].Next.Remove(queue[0]);
			}
			if (queue[0].Previous.Contains(this[this.SegmentCount - 1]))
			{
				queue[0].Previous.Remove(this[this.SegmentCount - 1]);
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000CFF4 File Offset: 0x0000BFF4
		public void ReverseAllSegments()
		{
			foreach (object obj in this.segments)
			{
				SimQueueSegment simQueueSegment = (SimQueueSegment)obj;
				simQueueSegment.Reverse = true;
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000D05C File Offset: 0x0000C05C
		public void UnreverseAllSegments()
		{
			foreach (object obj in this.segments)
			{
				SimQueueSegment simQueueSegment = (SimQueueSegment)obj;
				simQueueSegment.Reverse = false;
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000D0C4 File Offset: 0x0000C0C4
		public virtual bool TryAddToStart(ISimQueueObject obj)
		{
			return this.CanAddToStart() && ((SimQueueSegment)this.segments[0]).TryAddToStart(obj);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000D100 File Offset: 0x0000C100
		public virtual bool TryAddToEnd(ISimQueueObject obj)
		{
			return this.CanAddToEnd() && ((SimQueueSegment)this.segments[this.segments.Count - 1]).TryAddToEnd(obj);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000D148 File Offset: 0x0000C148
		public virtual bool CanAddToStart()
		{
			return this.segments.Count > 0 && ((SimQueueSegment)this.segments[0]).CanAddToStart();
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000D184 File Offset: 0x0000C184
		public virtual bool CanAddToEnd()
		{
			return this.segments.Count > 0 && ((SimQueueSegment)this.segments[this.segments.Count - 1]).CanAddToEnd();
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000D1CC File Offset: 0x0000C1CC
		public virtual ISimQueueObject TryRemoveFromEnd()
		{
			ISimQueueObject result;
			if (this.CanRemoveFromEnd())
			{
				result = ((SimQueueSegment)this.segments[this.segments.Count - 1]).TryRemoveFromEnd();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000D214 File Offset: 0x0000C214
		public virtual ISimQueueObject TryRemoveFromStart()
		{
			ISimQueueObject result;
			if (this.CanRemoveFromStart())
			{
				result = ((SimQueueSegment)this.segments[0]).TryRemoveFromStart();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000D250 File Offset: 0x0000C250
		public virtual bool CanRemoveFromEnd()
		{
			return this.segments.Count > 0 && ((SimQueueSegment)this.segments[this.segments.Count - 1]).CanRemoveFromEnd();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000D298 File Offset: 0x0000C298
		public virtual bool CanRemoveFromStart()
		{
			return this.segments.Count > 0 && ((SimQueueSegment)this.segments[0]).CanRemoveFromStart();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000D2D4 File Offset: 0x0000C2D4
		public static SimQueue Create(int numSegments, Point[,] segmentPoints, string[][] objectOrientations, int dx, int dy, int objectSeparationX, int objectSeparationY)
		{
			SimQueue simQueue = new SimQueue();
			for (int i = 0; i < numSegments; i++)
			{
				SimQueueSegment segment = new SimQueueSegment();
				simQueue.AppendSegment(segment);
			}
			simQueue.SetDXDY(dx, dy);
			simQueue.SetObjectSeparation(objectSeparationX, objectSeparationY);
			simQueue.SetObjectOrientations(objectOrientations);
			simQueue.SetSegmentPoints(segmentPoints);
			return simQueue;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000D334 File Offset: 0x0000C334
		public static SimQueue Create(int numSegments, Point[,] segmentPoints, string[] objectOrientation, int dx, int dy, int objectSeparationX, int objectSeparationY)
		{
			SimQueue simQueue = new SimQueue();
			for (int i = 0; i < numSegments; i++)
			{
				SimQueueSegment segment = new SimQueueSegment();
				simQueue.AppendSegment(segment);
			}
			simQueue.SetDXDY(dx, dy);
			simQueue.SetObjectSeparation(objectSeparationX, objectSeparationY);
			simQueue.SetObjectOrientations(objectOrientation);
			simQueue.SetSegmentPoints(segmentPoints);
			return simQueue;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000D394 File Offset: 0x0000C394
		public virtual void SetObjectOrientations(string[][] orientations)
		{
			if (orientations != null && this.segments.Count == orientations.Length)
			{
				for (int i = 0; i < this.segments.Count; i++)
				{
					this[i].ObjectOrientation = orientations[i];
				}
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000D3F0 File Offset: 0x0000C3F0
		public virtual void SetObjectOrientations(string[] orientation)
		{
			if (orientation != null)
			{
				for (int i = 0; i < this.segments.Count; i++)
				{
					this[i].ObjectOrientation = orientation;
				}
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000D434 File Offset: 0x0000C434
		public virtual void SetSegmentPoints(Point[,] points)
		{
			if (points != null)
			{
				for (int i = 0; i < this.SegmentCount; i++)
				{
					this[i].StartPoint = points[i, 0];
					this[i].EndPoint = points[i, 1];
				}
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000D498 File Offset: 0x0000C498
		public virtual void SetDXDY(int dx, int dy)
		{
			for (int i = 0; i < this.SegmentCount; i++)
			{
				this[i].DX = dx;
				this[i].DY = dy;
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000D4DC File Offset: 0x0000C4DC
		public virtual void SetObjectSeparation(int objectSeparationX, int objectSeparationY)
		{
			for (int i = 0; i < this.SegmentCount; i++)
			{
				this[i].ObjectSeparationX = objectSeparationX;
				this[i].ObjectSeparationY = objectSeparationY;
			}
		}

		// Token: 0x17000065 RID: 101
		public SimQueueSegment this[int index]
		{
			get
			{
				return (SimQueueSegment)this.segments[index];
			}
			set
			{
				this.segments[index] = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000D554 File Offset: 0x0000C554
		public int ObjectCount
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this.segments.Count; i++)
				{
					num += this[i].Count;
				}
				return num;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000196 RID: 406 RVA: 0x0000D594 File Offset: 0x0000C594
		public int SegmentCount
		{
			get
			{
				return this.segments.Count;
			}
		}

		// Token: 0x040000F5 RID: 245
		protected ArrayList segments;
	}
}
