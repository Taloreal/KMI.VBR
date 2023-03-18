using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for ShelfStocker.
	/// </summary>
	// Token: 0x02000041 RID: 65
	[Serializable]
	public class ShelfStocker : Person
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x0001D7BC File Offset: 0x0001C7BC
		public ShelfStocker(Floor parent)
		{
			this.Parent = parent;
			base.Speed = 8f;
			base.Location = parent.Map.getNode("Stockers").DistributedLocation;
			A.I.Subscribe(this, Simulator.TimePeriod.Step);
			if (base.Gender == Person.GenderType.Female)
			{
				this.genderString = "F";
			}
			this.raceString = (new string[]
			{
				"B",
				"C",
				"H"
			})[(int)this.race];
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0001D894 File Offset: 0x0001C894
		public void ThrowBackProduct()
		{
			foreach (object obj in this.Carrying)
			{
				Item item = (Item)obj;
				this.Parent.Parent.Backroom.Restock(item);
			}
			this.Carrying.Clear();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0001D914 File Offset: 0x0001C914
		public ArrayList GetDrawables()
		{
			ArrayList d = new ArrayList();
			ArrayList temp = new ArrayList();
			string name = "W" + this.genderString + this.carryWalkStand + this.raceString;
			PageDrawable pd = new PageDrawable(base.Location, name, "");
			bool flipX = false;
			pd.Row = base.OrientationIndexWithFlip(ref flipX);
			pd.FlipX = flipX;
			if (this.carryWalkStand != "S")
			{
				pd.Col = A.ST.FrameCounter % 9;
			}
			else
			{
				pd.Row = 1;
				pd.FlipX = true;
			}
			temp.Add(pd);
			if (this.Carrying.Count > 0)
			{
				int xOffset = 0;
				int yOffset = 0;
				if (base.Orientation().EndsWith("W"))
				{
					xOffset = -32;
				}
				if (base.Orientation().StartsWith("N"))
				{
					yOffset -= 27;
				}
				string img = "Case" + ((Item)this.Carrying[0]).ProductType.Index;
				PointF loc = new PointF(base.Location.X + 15f + (float)xOffset, base.Location.Y - 13f + (float)yOffset);
				FlexDrawable f = new FlexDrawable(loc, img);
				f.VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom;
				f.HorizontalAlignment = FlexDrawable.HorizontalAlignments.Center;
				if (base.Orientation().StartsWith("N"))
				{
					temp.Insert(0, f);
				}
				else
				{
					temp.Add(f);
				}
			}
			string clickString = this.DefaultComment();
			if (this.Comment != null)
			{
				clickString = this.Comment;
			}
			CompoundDrawable cd = new CompoundDrawable(Point.Round(base.Location), temp, clickString);
			Point topCenter = new Point(pd.Location.X, pd.Location.Y - 81);
			cd.ClickStringLocation = topCenter;
			d.Add(cd);
			return d;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0001DB48 File Offset: 0x0001CB48
		public CommentDrawable GetCommentDrawable()
		{
			Point topCenter = new Point((int)base.Location.X, (int)base.Location.Y - 81);
			CommentDrawable result;
			if (this.Comment != null && this.commentTimer > 0 && A.MF.ShowComments)
			{
				result = new CommentDrawable(topCenter, this.Comment);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0001DBB8 File Offset: 0x0001CBB8
		public override bool NewStep()
		{
			switch (this.State)
			{
			case ShelfStocker.States.Idle:
				if ((long)(A.ST.Now.Minute % 5) != this.ID % 5L)
				{
					return false;
				}
				this.carryWalkStand = "S";
				this.TargetShelf = this.Parent.FindExpired(this);
				if (this.TargetShelf != null)
				{
					this.State = ShelfStocker.States.ToExpire;
					this.carryWalkStand = "W";
					base.Path = this.Parent.Parent.Floor.Map.findPath("Stockers", this.TargetShelf.Parent.node.name).ToPoints();
				}
				else
				{
					this.TargetShelf = this.Parent.FindStocking(this);
					if (this.TargetShelf != null)
					{
						for (int i = 0; i < this.TargetShelf.ItemsToStock; i++)
						{
							Item item = this.Parent.Parent.Backroom.TakeItemOfType(this.TargetShelf.ProductType);
							if (item == null)
							{
								break;
							}
							this.Carrying.Add(item);
						}
						this.State = ShelfStocker.States.ToStock;
						this.carryWalkStand = "C";
						base.Path = this.Parent.Parent.Floor.Map.findPath("Stockers", this.TargetShelf.Parent.node.name).ToPoints();
					}
				}
				break;
			case ShelfStocker.States.ToStock:
				if (this.Move())
				{
					int i = 0;
					while (this.Carrying.Count > 0)
					{
						Item item = (Item)this.Carrying[0];
						if (this.TargetShelf.ProductType.Index != item.ProductType.Index || i >= this.TargetShelf.Items.Length)
						{
							this.ThrowBackProduct();
							break;
						}
						if (this.TargetShelf.Items[i] == null)
						{
							this.TargetShelf.Items[i] = item;
							this.Carrying.RemoveAt(0);
						}
						i++;
					}
					base.Path = this.Parent.Parent.Floor.Map.findPath(base.Location, "Stockers").ToDistributedPoints();
					this.State = ShelfStocker.States.FromStock;
					this.carryWalkStand = "W";
				}
				break;
			case ShelfStocker.States.FromStock:
				if (this.Move())
				{
					this.State = ShelfStocker.States.Idle;
				}
				break;
			case ShelfStocker.States.ToExpire:
				if (this.Move())
				{
					base.Path = this.Parent.Parent.Floor.Map.findPath(base.Location, "Stockers").ToDistributedPoints();
					string comment = A.R.GetString("Oh, boy. I found some expired {0}. I better get rid of that.", new object[]
					{
						this.TargetShelf.ProductType.Name
					});
					this.Comment = comment;
					this.Parent.Parent.Player.SendMessage(comment, this.Parent.Parent.Name, NotificationColor.Yellow);
					this.Parent.Parent.Log.Comment("Stockers", "", comment);
					this.State = ShelfStocker.States.FromExpire;
					this.carryWalkStand = "C";
					for (int i = 0; i < this.TargetShelf.Items.Length; i++)
					{
						Item item = this.TargetShelf.Items[i];
						if (item != null && item.IsExpired)
						{
							this.Carrying.Add(item);
							this.TargetShelf.Items[i] = null;
						}
					}
				}
				break;
			case ShelfStocker.States.FromExpire:
				if (this.Move())
				{
					this.State = ShelfStocker.States.Idle;
					foreach (object obj in this.Carrying)
					{
						Item j = (Item)obj;
						j.ThrowOut(this.Parent.Parent);
					}
					this.Carrying.Clear();
				}
				break;
			}
			return false;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0001E074 File Offset: 0x0001D074
		public override bool Move()
		{
			return base.Move();
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001FF RID: 511 RVA: 0x0001E08C File Offset: 0x0001D08C
		// (set) Token: 0x06000200 RID: 512 RVA: 0x0001E0A4 File Offset: 0x0001D0A4
		public string Comment
		{
			get
			{
				return this.comment;
			}
			set
			{
				if (!A.I.BlockMessage(value))
				{
					this.comment = value;
					this.commentTimer = 40;
				}
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0001E0D8 File Offset: 0x0001D0D8
		protected string DefaultComment()
		{
			string productName = this.FindStaleProduct();
			string @string;
			if (productName == null)
			{
				@string = A.R.GetString("Nice purchasing, Boss. All the stuff on our shelves is nice and fresh.");
			}
			else
			{
				@string = A.R.GetString("Hey, Boss. I noticed some nearly expired {0}.  Maybe we should be ordering less.", new object[]
				{
					productName
				});
			}
			return @string;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0001E12C File Offset: 0x0001D12C
		private string FindStaleProduct()
		{
			foreach (object obj in this.Parent.AllShelves)
			{
				Shelf s = (Shelf)obj;
				foreach (Item i in s.Items)
				{
					if (i != null && i.PercentExpired > 0.66f)
					{
						return i.ProductType.Name;
					}
				}
			}
			return null;
		}

		// Token: 0x040001EC RID: 492
		private const float COMMENT_EXPIRATION_THRESHOLD = 0.66f;

		// Token: 0x040001ED RID: 493
		protected int commentTimer;

		// Token: 0x040001EE RID: 494
		protected string comment;

		// Token: 0x040001EF RID: 495
		public PointF Home;

		// Token: 0x040001F0 RID: 496
		protected string carryWalkStand = "S";

		// Token: 0x040001F1 RID: 497
		protected string genderString = "M";

		// Token: 0x040001F2 RID: 498
		protected string raceString;

		// Token: 0x040001F3 RID: 499
		public ShelfStocker.States State = ShelfStocker.States.Idle;

		// Token: 0x040001F4 RID: 500
		public Floor Parent;

		// Token: 0x040001F5 RID: 501
		public Shelf TargetShelf;

		// Token: 0x040001F6 RID: 502
		public ArrayList Carrying = new ArrayList();

		// Token: 0x040001F7 RID: 503
		public long ID = A.ST.GetNextID();

		// Token: 0x02000042 RID: 66
		public enum States
		{
			// Token: 0x040001F9 RID: 505
			Idle,
			// Token: 0x040001FA RID: 506
			ToStock,
			// Token: 0x040001FB RID: 507
			FromStock,
			// Token: 0x040001FC RID: 508
			ToExpire,
			// Token: 0x040001FD RID: 509
			FromExpire
		}
	}
}
