using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Biz.Product;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Customer.
	/// </summary>
	// Token: 0x0200000D RID: 13
	[Serializable]
	public class Customer : Consumer
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00004BB8 File Offset: 0x00003BB8
		public void Init()
		{
			float pctOfPopIsProfessional = 0.4f;
			float pctOfPopIsRetiree = 0.2f;
			Random rnd = A.ST.Random;
			this.id = A.ST.GetNextID();
			double r = rnd.NextDouble();
			if (A.SS.PreferredMigrationDemographic > -1 && r < 0.8)
			{
				this.demographicType = AppConstants.DemographicTypes[A.SS.PreferredMigrationDemographic];
			}
			else if (r < (double)pctOfPopIsProfessional)
			{
				this.demographicType = AppConstants.DemographicTypes[1];
			}
			else if (r < (double)(pctOfPopIsProfessional + pctOfPopIsRetiree))
			{
				this.demographicType = AppConstants.DemographicTypes[2];
			}
			else
			{
				this.demographicType = AppConstants.DemographicTypes[0];
			}
			this.age = (int)Utilities.GetNormalDistribution((float)this.demographicType.AvgAge, (float)this.demographicType.StdDevAge, rnd);
			this.income = (int)Utilities.GetNormalDistribution((float)this.demographicType.AvgIncome, (float)this.demographicType.StdDevIncome, rnd);
			this.WillShoplift = (rnd.NextDouble() < 0.10000000149011612);
			this.SignRequired = (rnd.NextDouble() < 0.5);
			this.willShopOnBlockWithoutAds = (rnd.NextDouble() < 0.5);
			DateTime t = A.ST.Now.AddDays((double)rnd.Next(4));
			t = new DateTime(t.Year, t.Month, t.Day);
			r = (double)((float)rnd.NextDouble());
			for (int i = 0; i < this.demographicType.ShoppingTimeDist.Length; i++)
			{
				if (r < (double)this.demographicType.ShoppingTimeDist[i])
				{
					t = t.AddHours((double)(i * 2 + A.ST.Random.Next(2)));
					t = t.AddMinutes((double)A.ST.Random.Next(60));
					break;
				}
			}
			base.Speed = 8f;
			this.wakeupTime = t;
			this.side = rnd.Next(2);
			this.windowShopper = (rnd.NextDouble() < (double)A.SS.PercentWindowShoppers);
			if (base.Gender == Person.GenderType.Female)
			{
				this.genderString = "F";
			}
			this.demographicTypeString = (new string[]
			{
				"S",
				"B",
				"E"
			})[this.DemographicType.Index];
			this.raceString = (new string[]
			{
				"B",
				"C",
				"H"
			})[(int)this.race];
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00004E8C File Offset: 0x00003E8C
		protected string carryWalkStand
		{
			get
			{
				string result;
				if (this.blocked || this.State == Customer.States.NextToBeServed || this.State == Customer.States.AtCashier || this.lookingAtAd)
				{
					if (this.Items.Count > 0)
					{
						result = "H";
					}
					else
					{
						result = "S";
					}
				}
				else if (this.Items.Count > 0)
				{
					result = "C";
				}
				else
				{
					result = "W";
				}
				return result;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00004F10 File Offset: 0x00003F10
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00004F28 File Offset: 0x00003F28
		public AppBuilding Home
		{
			get
			{
				return this.home;
			}
			set
			{
				this.home = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00004F34 File Offset: 0x00003F34
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00004F4C File Offset: 0x00003F4C
		public AppBuilding Workplace
		{
			get
			{
				return this.workplace;
			}
			set
			{
				this.workplace = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00004F58 File Offset: 0x00003F58
		public long ID
		{
			get
			{
				return this.id;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00004F70 File Offset: 0x00003F70
		public DemographicType DemographicType
		{
			get
			{
				return this.demographicType;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00004F88 File Offset: 0x00003F88
		public int Age
		{
			get
			{
				return this.age;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00004FA0 File Offset: 0x00003FA0
		public int Income
		{
			get
			{
				return this.income;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00004FB8 File Offset: 0x00003FB8
		public bool WillShopOnBlockWithoutAds
		{
			get
			{
				return this.willShopOnBlockWithoutAds;
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004FD0 File Offset: 0x00003FD0
		public ArrayList GetDrawables()
		{
			int dx = 1;
			int dy = 1;
			int xOffset = 5;
			int yOffset = -40;
			string o = base.Orientation();
			if (o.StartsWith("S"))
			{
				dy = -1;
				yOffset += 5;
			}
			if (o.EndsWith("W"))
			{
				dx = -1;
				xOffset -= 10;
			}
			ArrayList temp = new ArrayList();
			int i = 0;
			foreach (object obj in this.Items)
			{
				Item item = (Item)obj;
				int r = i / 3;
				int c = i % 3;
				PointF loc = new PointF((float)((int)base.Location.X + xOffset + c * dx * 10), (float)((int)base.Location.Y + yOffset + r * -14 + c * dy * 10 / 2));
				temp.Add(new FlexDrawable(loc, "Prod" + item.ProductType.Index)
				{
					VerticalAlignment = FlexDrawable.VerticalAlignments.Bottom,
					HorizontalAlignment = FlexDrawable.HorizontalAlignments.Center
				});
				i++;
			}
			temp.Reverse();
			string clickString = this.DefaultComment();
			if (this.Comment != null)
			{
				clickString = this.Comment;
			}
			string name = this.demographicTypeString + this.genderString + this.carryWalkStand + this.raceString;
			PageDrawable pd = new PageDrawable(base.Location, name, "");
			bool flipX = false;
			pd.Row = base.OrientationIndexWithFlip(ref flipX);
			pd.FlipX = flipX;
			if (this.carryWalkStand != "S" && this.carryWalkStand != "H")
			{
				pd.Col = A.ST.FrameCounter % 9;
			}
			if (this.lookingAtAd)
			{
				pd.Row = 0;
				pd.FlipX = false;
			}
			if (base.Orientation() == "NE" || base.Orientation() == "NW")
			{
				temp.Add(pd);
			}
			else
			{
				temp.Insert(0, pd);
			}
			Point topCenter = new Point(pd.Location.X, pd.Location.Y - 81);
			return new ArrayList
			{
				new CompoundDrawable(Point.Round(base.Location), temp, clickString)
				{
					ClickStringLocation = topCenter
				}
			};
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000052B8 File Offset: 0x000042B8
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

		// Token: 0x0600005B RID: 91 RVA: 0x00005328 File Offset: 0x00004328
		protected void PrepareToEnterStore()
		{
			this.CurrentStore.Customers.Add(this);
			base.Location = this.CurrentStore.Floor.Map.getNode("EX" + this.side).Location;
			this.AgreedUponPrices.Clear();
			foreach (VBRProductType p in AppConstants.ProductTypes)
			{
				this.AgreedUponPrices.Add(p.Index, this.CurrentStore.GetPriceWithDiscount(p.Index));
			}
			this.Needs = this.SetAmounts(this.DemographicType.Needs, A.SS.PctNeedsDesired);
			this.ImpulseItems = this.SetAmounts(this.DemographicType.ImpulseItems, A.SS.PctImpulseDesired);
			if (A.SS.RestrictFixtures)
			{
				this.Needs.Remove(22);
			}
			this.nodesAlreadyInspected = new ArrayList();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000544C File Offset: 0x0000444C
		public override bool NewStep()
		{
			if (this.commentTimer > 0)
			{
				this.commentTimer--;
			}
			else
			{
				this.comment = null;
			}
			switch (this.State)
			{
			case Customer.States.Idle:
				if (this.backupWakeUpTime > DateTime.MinValue)
				{
					this.WakeupTime = this.backupWakeUpTime;
					this.backupWakeUpTime = DateTime.MinValue;
				}
				else
				{
					this.WakeupTime = this.WakeupTime.AddDays(4.0);
				}
				if (!this.windowShopper)
				{
					base.DecayImpressions(0.8f, 0.1f);
					this.ExperienceAdvertising();
					this.CurrentStore = this.ChooseEntity();
					if (this.CurrentStore == null)
					{
						return true;
					}
					this.PrepareToEnterStore();
					this.CurrentStore.GL.PostNonFinancial("Customers", 20f);
					this.State = Customer.States.FindNearestSectionToInspect;
				}
				else
				{
					this.CurrentStore = this.EntityWalkedBy();
					if (this.CurrentStore == null)
					{
						return true;
					}
					this.PrepareToEnterStore();
					base.Path = this.CurrentStore.Floor.Map.findPath(base.Location, "EX" + (1 - this.side)).ToPoints();
					this.State = Customer.States.WalkBy;
				}
				break;
			case Customer.States.WalkBy:
				this.lookingAtAd = false;
				for (int i = 0; i < 3; i++)
				{
					if (base.Location == this.CurrentStore.Floor.Map.getNode("A" + i).Location)
					{
						if (this.CurrentStore.Floor.Ads[i] != null)
						{
							this.lookingAtAd = true;
							if (this.CurrentStore.Open && this.AppealOfAd(this.CurrentStore, this.CurrentStore.Floor.Ads[i]) > 0.75f)
							{
								this.Comment = "What a deal! I'm going in.";
								this.CurrentStore.GL.PostNonFinancial("Customers", 20f);
								this.State = Customer.States.FindNearestSectionToInspect;
								return false;
							}
						}
					}
				}
				if (this.Move())
				{
					this.CurrentStore.Customers.Remove(this);
					this.CurrentStore = null;
					this.State = Customer.States.Idle;
					return true;
				}
				break;
			case Customer.States.ToLine:
				if (this.waitCount > this.DemographicType.WaitTolerance)
				{
					this.CurrentStore.GL.PostNonFinancial("Sales Lost Due To Long Wait", this.ValueOfGoodsHeld() * 20f);
					this.LeaveInDisgust(A.R.GetString("I'm leaving.  This line is too long."));
				}
				else if (this.Move())
				{
					this.currSection = (SectionBase)this.CurrentStore.Floor.Sections["S11"];
					while (!this.ShopSection())
					{
					}
					this.currSection = (SectionBase)this.CurrentStore.Floor.Sections["S12"];
					while (!this.ShopSection())
					{
					}
					if (this.State == Customer.States.Exit)
					{
						return false;
					}
					if (this.Needs.Count > 0)
					{
						if (this.Items.Count == 0)
						{
							this.LeaveInDisgust(A.R.GetString("This store had nothing I needed!"));
							return false;
						}
						ArrayList deDup = new ArrayList();
						foreach (object obj in this.Needs)
						{
							int index = (int)obj;
							ProductType pt = AppConstants.ProductTypes[index];
							this.CurrentStore.GL.PostNonFinancial("Sales Lost Due To Availability", (float)this.AgreedUponPrices[pt.Index] * 20f, pt.Name);
							if (!deDup.Contains(pt))
							{
								deDup.Add(pt);
							}
						}
						string s = "";
						foreach (object obj2 in deDup)
						{
							ProductType pt = (ProductType)obj2;
							s = s + pt.Name + ", ";
							this.CurrentStore.Log.Comment("Customers", "", A.R.GetString("I couldn't find {0}.", new object[]
							{
								pt.Name
							}));
							this.CurrentStore.Player.SendMessage(A.R.GetString("A customer couldn't find {0}.", new object[]
							{
								pt.Name
							}), this.CurrentStore.Name, NotificationColor.Yellow);
						}
						string msg = A.R.GetString("I couldn't find {0}.", new object[]
						{
							Utilities.FormatCommaSeries(s)
						});
						this.Comment = msg;
					}
					this.State = Customer.States.NextToBeServed;
				}
				break;
			case Customer.States.NextToBeServed:
			{
				if (this.CurrentStore.Cashiers.Count == 0)
				{
					this.LeaveInDisgust(A.R.GetString("How do they expect me to shop here with no cashiers?"));
					return false;
				}
				PointF loc = this.CurrentStore.LockCashierLocation(this);
				if (!loc.IsEmpty)
				{
					loc = new PointF(loc.X - 48f, loc.Y + 24f);
					base.Path = new ArrayList(new PointF[]
					{
						loc,
						new PointF(loc.X + 10f, loc.Y - 5f)
					});
					this.footForward = 0;
					this.State = Customer.States.MoveToCashier;
				}
				break;
			}
			case Customer.States.FindNearestSectionToInspect:
			{
				this.lookingAtAd = false;
				string nodeName = this.FindNearestSectionToInspect(this.nodesAlreadyInspected);
				if (nodeName == null || this.Needs.Count == 0)
				{
					this.State = Customer.States.ToLine;
					base.Path = this.CurrentStore.Floor.Map.findPath(base.Location, "Line").ToPoints();
					this.LineID = A.ST.GetNextID();
				}
				else
				{
					base.Path = this.CurrentStore.Floor.Map.findPath(base.Location, nodeName).ToPoints();
					this.nodesAlreadyInspected.Add(nodeName);
					this.currSection = (SectionBase)this.CurrentStore.Floor.Sections[nodeName];
					this.State = Customer.States.MoveToSection;
				}
				break;
			}
			case Customer.States.MoveToSection:
				if (this.Move())
				{
					this.State = Customer.States.ShopSection;
				}
				break;
			case Customer.States.ShopSection:
				if (this.ShopSection() && this.State != Customer.States.Exit)
				{
					this.State = Customer.States.FindNearestSectionToInspect;
				}
				break;
			case Customer.States.MoveToCashier:
				if (this.Move())
				{
					this.cashierSteps = 20;
					this.footForward = 0;
					this.State = Customer.States.AtCashier;
				}
				break;
			case Customer.States.AtCashier:
				if (this.cashierSteps-- == 0)
				{
					foreach (object obj3 in this.Items)
					{
						Item item = (Item)obj3;
						int bmp = (int)(0.5f + this.BargainMultiplier((VBRProductType)item.ProductType, (float)this.AgreedUponPrices[item.ProductType.Index]));
						if (bmp < 1)
						{
							this.CurrentStore.Backroom.Restock(item);
						}
						else
						{
							this.CurrentStore.GL.Post("Cash", (float)this.AgreedUponPrices[item.ProductType.Index] * 20f, "Revenue", item.ProductType.Name, 20, new string[]
							{
								"Sales"
							}, new string[0]);
							this.CurrentStore.GL.Post("Actually Sold", item.ProductType.Cost * 20f, "Inventory", item.ProductType.Name, 20, new string[]
							{
								"COGS: Actual Sales"
							}, new string[]
							{
								"Inventory"
							});
						}
					}
					this.CurrentStore.UnlockCashier(this);
					base.Path = this.CurrentStore.Floor.Map.findPath("Merge", "EX" + this.side).ToPoints();
					this.State = Customer.States.Exit;
				}
				break;
			case Customer.States.Exit:
				if (this.Move())
				{
					this.Items.Clear();
					this.CurrentStore.Customers.Remove(this);
					this.waitCount = 0;
					this.State = Customer.States.Idle;
					return true;
				}
				break;
			}
			return false;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00005F20 File Offset: 0x00004F20
		protected bool ShopSection()
		{
			bool result;
			if (this.currSection.Broken)
			{
				string comment = A.R.GetString("Oh, man! This {0} is not working. That's a bummer.", new object[]
				{
					this.currSection.RackType
				});
				this.Comment = comment;
				this.CurrentStore.Log.Comment("Customers", "", comment);
				result = true;
			}
			else
			{
				bool itemFound = false;
				bool expired = false;
				foreach (Shelf s in this.currSection.Shelves)
				{
					int index = 0;
					foreach (Item i in s.Items)
					{
						if (i != null && (this.Needs.Contains(i.ProductType.Index) || this.ImpulseItems.Contains(i.ProductType.Index)))
						{
							itemFound = true;
							expired = this.GrabAndTestExpired(i, s, index);
							if (!expired)
							{
								expired = this.TryToBuyComplementerAndTestExpired(i);
							}
							break;
						}
						if (itemFound)
						{
							break;
						}
						index++;
					}
				}
				result = (!itemFound || expired);
			}
			return result;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000060A4 File Offset: 0x000050A4
		protected void LeaveInDisgust(string comment)
		{
			this.Comment = comment;
			this.CurrentStore.Player.SendMessage(comment, this.CurrentStore.Name, NotificationColor.Yellow);
			this.CurrentStore.Log.Comment("Customers", "", comment);
			foreach (object obj in this.Items)
			{
				Item item = (Item)obj;
				this.CurrentStore.Backroom.Restock(item);
			}
			this.Items.Clear();
			base.Path = this.CurrentStore.Floor.Map.findPath(base.Location, "EX" + this.side).ToPoints();
			this.State = Customer.States.Exit;
			this.CurrentStore.UnlockCashier(this);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000061B4 File Offset: 0x000051B4
		protected AppEntity ChooseEntity()
		{
			AppEntity chosenEntity = null;
			float highestUtility = float.MinValue;
			foreach (object obj in S.ST.Entity.Values)
			{
				AppEntity entity = (AppEntity)obj;
				if (entity.Open && this.Aware(entity.ID))
				{
					float u = this.UtilityOfEntity(entity);
					if (u > highestUtility && u > A.SS.MinAcceptableUtility)
					{
						chosenEntity = entity;
						highestUtility = u;
					}
				}
			}
			return chosenEntity;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006284 File Offset: 0x00005284
		public AppEntity EntityWalkedBy()
		{
			float[] probs = new float[A.ST.Entity.Values.Count];
			int i = 0;
			float total = 0f;
			ArrayList entities = new ArrayList(A.ST.Entity.Values);
			foreach (object obj in entities)
			{
				AppEntity e = (AppEntity)obj;
				float appeal = this.AppealOfLocationConsideringConstruction(e.ID) + A.SS.MaxDistPasserBy;
				probs[i++] = Math.Max(0f, appeal);
				total += Math.Max(0f, appeal);
			}
			AppEntity result;
			if (total == 0f)
			{
				result = null;
			}
			else
			{
				result = (AppEntity)entities[Utilities.PickFromDistribution(probs, A.ST.Random)];
			}
			return result;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00006398 File Offset: 0x00005398
		public bool Aware(long entityID)
		{
			return A.SS.MaxImpressionsNeeded == 0 || base.ImpressionCount(entityID) > A.ST.Random.Next(A.SS.MaxImpressionsNeeded) + 1;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000063E8 File Offset: 0x000053E8
		private float UtilityOfEntity(AppEntity e)
		{
			float locAppeal = this.AppealOfLocationConsideringConstruction(e.ID);
			float impressionAppeal = base.ImpressionImpact(e.ID);
			float appeal = locAppeal + impressionAppeal;
			return Utilities.Vary(appeal, 0.001f, A.ST.Random);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00006430 File Offset: 0x00005430
		protected ArrayList SetAmounts(ICollection productTypeIndices, float pctIncluded)
		{
			TimeSpan ts = A.ST.NextStorm - A.ST.Now;
			ArrayList prelim = new ArrayList();
			foreach (object obj in productTypeIndices)
			{
				int index = (int)obj;
				if (A.ST.Random.NextDouble() < (double)pctIncluded)
				{
					int sd = this.SeasonalDemand(AppConstants.ProductTypes[index]);
					if (A.SS.SnowStorms && ts.TotalDays >= 0.0 && ts.Days <= 1)
					{
						sd *= 3;
					}
					for (int i = 0; i < sd; i++)
					{
						prelim.Add(index);
					}
				}
			}
			ArrayList list = new ArrayList();
			foreach (object obj2 in prelim)
			{
				int index = (int)obj2;
				int bmp = (int)(0.5f + this.BargainMultiplier(AppConstants.ProductTypes[index], (float)this.AgreedUponPrices[index]));
				for (int i = 0; i < Math.Max(1, bmp); i++)
				{
					list.Add(index);
				}
			}
			return list;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000065F8 File Offset: 0x000055F8
		protected int SeasonalDemand(ProductType product)
		{
			int result;
			if (!A.SS.Seasonality)
			{
				result = 1;
			}
			else if (product.Seasonality == 0f)
			{
				result = 1;
			}
			else
			{
				double rv = A.ST.Random.NextDouble();
				if (rv < (double)(product.Seasonality * A.ST.Season() / 2f) + 0.5)
				{
					result = 2;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00006678 File Offset: 0x00005678
		protected bool GrabAndTestExpired(Item item, Shelf shelf, int index)
		{
			bool result;
			if (item.IsExpired)
			{
				this.CurrentStore.GL.PostNonFinancial("Sales Lost Due To Expired Goods", this.ValueOfGoodsHeld() * 20f);
				this.LeaveInDisgust(A.R.GetString("Yechh! This product has expired!"));
				result = true;
			}
			else
			{
				VBRProductType pt = (VBRProductType)item.ProductType;
				int bmp = (int)(0.5f + this.BargainMultiplier(pt, this.CurrentStore.GetPriceWithDiscount(pt.Index)));
				if (!this.IsStolen(this.currSection.node.name, item))
				{
					if (bmp < 1)
					{
						string comment = A.R.GetString("This price is way too high on the {0}!", new object[]
						{
							pt.Name
						});
						this.Comment = comment;
						this.CurrentStore.Log.Comment("Customers", "", comment);
						this.CurrentStore.GL.PostNonFinancial("Sales Lost Due To Price", (float)this.AgreedUponPrices[pt.Index] * 20f, pt.Name);
					}
					else
					{
						if (bmp > 1)
						{
							string comment = A.R.GetString("What a great deal on {0}!", new object[]
							{
								item.ProductType.Name
							});
							this.Comment = comment;
							this.CurrentStore.Log.Comment("Customers", "", comment);
						}
						this.Items.Add(item);
					}
				}
				if (bmp > 0)
				{
					shelf.Items[index] = null;
				}
				if (this.Needs.Contains(pt.Index))
				{
					this.Needs.Remove(pt.Index);
				}
				if (this.ImpulseItems.Contains(pt.Index))
				{
					this.ImpulseItems.Remove(pt.Index);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000068B8 File Offset: 0x000058B8
		protected bool TryToBuyComplementerAndTestExpired(Item item)
		{
			int i = ((VBRProductType)item.ProductType).ComplementedBy;
			bool result;
			if (i == -1)
			{
				result = false;
			}
			else
			{
				foreach (Shelf s in this.currSection.Shelves)
				{
					if (s.ProductType.Index == i)
					{
						int index = 0;
						foreach (Item j in s.Items)
						{
							if (j != null)
							{
								return this.GrabAndTestExpired(j, s, index);
							}
							index++;
						}
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00006980 File Offset: 0x00005980
		public override bool Move()
		{
			this.blocked = false;
			foreach (object obj in this.CurrentStore.Customers)
			{
				Customer c = (Customer)obj;
				if (c != this && this.State == Customer.States.ToLine && (c.State == Customer.States.ToLine || c.State == Customer.States.NextToBeServed) && c.LineID < this.LineID && Utilities.DistanceBetween(c.Location, base.Location) < 20f)
				{
					this.waitCount++;
					this.blocked = true;
					return false;
				}
			}
			return base.Move();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00006A60 File Offset: 0x00005A60
		public float AppealOfLocationConsideringConstruction(long entityID)
		{
			AppEntity e = (AppEntity)A.ST.Entity[entityID];
			float appeal = this.AppealOfLocation(e.Building);
			if (e.Building.Block.GetConstruction())
			{
				appeal -= 4f;
			}
			return appeal;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00006ABC File Offset: 0x00005ABC
		public float AppealOfLocation(Building storeBldg)
		{
			CityBlock storeBlock = storeBldg.Block;
			CityBlock homeBlock = this.Home.Block;
			float result;
			if (storeBlock == homeBlock)
			{
				if (this.WillShopOnBlockWithoutAds)
				{
					result = 0.5f;
				}
				else
				{
					result = -0.5f;
				}
			}
			else
			{
				if (this.Workplace != null)
				{
					CityBlock workplaceBlock = this.Workplace.Block;
					if (storeBlock == workplaceBlock)
					{
						return -0.5f;
					}
					City city = A.ST.OurCity;
					int si = this.Home.Street;
					int ai;
					for (ai = this.Home.Avenue; ai != this.Workplace.Avenue; ai += Math.Sign(this.Workplace.Avenue - ai))
					{
						if (city[ai, si] == storeBlock)
						{
							return -0.5f;
						}
					}
					while (si != this.Workplace.Street)
					{
						if (city[ai, si] == storeBlock && storeBldg.Lot == storeBlock.NumLots - 1)
						{
							return -0.5f;
						}
						if (ai + 1 < City.NUM_AVENUES && city[ai + 1, si] == storeBlock && storeBldg.Lot == 0)
						{
							return -0.5f;
						}
						si += Math.Sign(this.Workplace.Street - si);
					}
				}
				result = -City.Distance(storeBlock, homeBlock);
			}
			return result;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00006C84 File Offset: 0x00005C84
		public float BargainMultiplier(VBRProductType productType, float price)
		{
			float margin = (float)((double)(price - productType.Cost) / Math.Max(0.01, (double)price)) * 100f;
			if (productType.MarginMultiplier > 0f)
			{
				if (productType.MarginMultiplier == 3f)
				{
					margin = (float)((double)(price - productType.Cost * 7.7f) / Math.Max(0.01, (double)price)) * 100f;
				}
				if (productType.MarginMultiplier == 4f)
				{
					margin = (float)((double)(price - productType.Cost * 5.6f) / Math.Max(0.01, (double)price)) * 100f;
				}
			}
			if (A.I.Multiplayer)
			{
				margin -= 5f;
			}
			float bm = AppConstants.PriceElasticity.Response(margin, A.ST.Random);
			if (productType.MarginMultiplier > 0f && bm > 1f)
			{
				bm = 1f;
			}
			return bm;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00006DA0 File Offset: 0x00005DA0
		public void ReceiveMail(Entity entity)
		{
			if (!this.gotMail.ContainsKey(entity.Name))
			{
				this.gotMail.Add(entity.Name, new object());
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00006DDC File Offset: 0x00005DDC
		public void ExperienceAdvertising()
		{
			foreach (object obj in A.ST.Entity.Values)
			{
				AppEntity e = (AppEntity)obj;
				if (this.gotMail.ContainsKey(e.Name))
				{
					this.MakeImpressionWithMail(e);
				}
			}
			this.gotMail.Clear();
			int stationID;
			if (A.ST.Random.NextDouble() < (double)this.DemographicType.PctPreferredRadioStation)
			{
				stationID = this.DemographicType.PreferredRadioStation;
			}
			else
			{
				stationID = A.ST.Random.Next(A.ST.RadioStations.Length);
			}
			int rotation = (int)RadioStation.InRotation(A.ST.Hour);
			foreach (object obj2 in A.ST.Entity.Values)
			{
				AppEntity e = (AppEntity)obj2;
				if (e.RadioBookings[rotation, stationID])
				{
					this.MakeImpressionWithRadio(e);
				}
			}
			ArrayList buildingsSeen = new ArrayList();
			CityBlock homeBlock = this.Home.Block;
			for (int i = 0; i < homeBlock.NumLots; i++)
			{
				if (homeBlock[i] != null)
				{
					buildingsSeen.Add(homeBlock[i]);
				}
			}
			if (this.Workplace != null)
			{
				CityBlock workplaceBlock = this.Workplace.Block;
				for (int i = 0; i < workplaceBlock.NumLots; i++)
				{
					if (workplaceBlock[i] != null)
					{
						buildingsSeen.Add(workplaceBlock[i]);
					}
				}
				int si = this.Home.Street;
				int ai;
				for (ai = this.Home.Avenue; ai != this.Workplace.Avenue; ai += Math.Sign(this.Workplace.Avenue - ai))
				{
					CityBlock block = A.ST.OurCity[ai, si];
					for (int i = 0; i < block.NumLots; i++)
					{
						if (block[i] != null && !buildingsSeen.Contains(block[i]))
						{
							buildingsSeen.Add(block[i]);
						}
					}
				}
				while (si != this.Workplace.Street)
				{
					CityBlock block = A.ST.OurCity[ai, si];
					if (block[block.NumLots - 1] != null && !buildingsSeen.Contains(block[block.NumLots - 1]))
					{
						buildingsSeen.Add(block[block.NumLots - 1]);
					}
					if (ai + 1 < City.NUM_AVENUES)
					{
						block = A.ST.OurCity[ai + 1, si];
						if (block[0] != null && !buildingsSeen.Contains(block[0]))
						{
							buildingsSeen.Add(block[0]);
						}
					}
					si += Math.Sign(this.Workplace.Street - si);
				}
			}
			Hashtable billboardsSeen = new Hashtable();
			foreach (object obj3 in buildingsSeen)
			{
				AppBuilding b = (AppBuilding)obj3;
				if (b.BillboardOwner != null)
				{
					if (!billboardsSeen.ContainsKey(b.BillboardOwner))
					{
						billboardsSeen.Add(b.BillboardOwner, 0);
					}
					billboardsSeen[b.BillboardOwner] = (int)billboardsSeen[b.BillboardOwner] + 1;
				}
			}
			foreach (object obj4 in billboardsSeen.Keys)
			{
				AppEntity e = (AppEntity)obj4;
				this.MakeImpressionWithBillboards(e, (int)billboardsSeen[e]);
			}
		}

		/// <summary>
		/// Touch the customer now (in simulated time), making an impression and
		/// raising the customer's awareness of the given entity.
		/// </summary>
		/// <param name="entity"></param>
		// Token: 0x0600006D RID: 109 RVA: 0x000072F4 File Offset: 0x000062F4
		public void MakeImpressionWithMail(AppEntity entity)
		{
			int couponsNoticed = 0;
			float impact = 0f;
			int numProducts = 25;
			int seed = A.ST.Random.Next(numProducts);
			for (int i = 0; i < numProducts; i++)
			{
				int iProduct = (seed + i) % numProducts;
				if (entity.Discounts[iProduct] != 0f)
				{
					couponsNoticed++;
					if (this.DemographicType.Needs.Contains(iProduct))
					{
						float price = entity.GetPriceWithDiscount(iProduct);
						float curImpact = this.BargainMultiplier(AppConstants.ProductTypes[iProduct], price) - 1f;
						curImpact = Utilities.Clamp(curImpact, -2f, 2f);
						impact += curImpact;
					}
					if (couponsNoticed >= 3)
					{
						break;
					}
				}
			}
			impact = Utilities.Clamp(impact, -4f, 4f);
			base.MakeImpression(entity.ID, A.SS.AdvertisingMultiplier * impact, "Direct Mail");
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000073FC File Offset: 0x000063FC
		public void MakeImpressionWithRadio(Entity entity)
		{
			float impact = 1.5f;
			base.MakeImpression(entity.ID, A.SS.AdvertisingMultiplier * impact, "Radio");
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00007430 File Offset: 0x00006430
		public float AppealOfAd(AppEntity entity, AdSimple ad)
		{
			float appeal = 0f;
			int iProduct = ad.ProductIndex;
			if (this.DemographicType.Needs.Contains(iProduct))
			{
				float price = entity.GetPriceWithDiscount(iProduct);
				float curImpact = this.BargainMultiplier(AppConstants.ProductTypes[iProduct], price) - 1f;
				appeal = Utilities.Clamp(curImpact, -3f, 3f);
			}
			return appeal;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000074A4 File Offset: 0x000064A4
		public void MakeImpressionWithBillboards(Entity entity, int count)
		{
			float impact = 3f;
			if (count > 1)
			{
				impact += 1f;
			}
			if (count > 2)
			{
				impact += 0.5f;
			}
			base.MakeImpression(entity.ID, A.SS.AdvertisingMultiplier * impact, "Billboards");
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000074FC File Offset: 0x000064FC
		protected bool IsStolen(string nodeName, Item item)
		{
			bool result;
			if (!A.SS.Shoplifting)
			{
				result = false;
			}
			else if (!this.WillShoplift)
			{
				result = false;
			}
			else
			{
				ArrayList nonStealableSections = new ArrayList(new string[]
				{
					"S11",
					"S12"
				});
				if (nonStealableSections.Contains(nodeName))
				{
					result = false;
				}
				else
				{
					switch (((VBRProductType)item.ProductType).Stealability)
					{
					case 0:
						return false;
					case 1:
						if (this.CurrentStore.SecurityCameraOn(nodeName))
						{
							return false;
						}
						break;
					case 2:
						if (this.CurrentStore.SecurityCameraOn(nodeName) && A.ST.Random.NextDouble() < 0.800000011920929)
						{
							return false;
						}
						break;
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000075E8 File Offset: 0x000065E8
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00007600 File Offset: 0x00006600
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

		// Token: 0x06000074 RID: 116 RVA: 0x00007634 File Offset: 0x00006634
		public string DefaultComment()
		{
			string maxImpactSource = null;
			if (this.CurrentStore != null)
			{
				string[] impactSources = new string[]
				{
					"Direct Mail",
					"Storefront Ads",
					"Billboards",
					"Radio"
				};
				float maxImpact = 0f;
				foreach (string impactSource in impactSources)
				{
					float impact = base.ImpressionImpact(this.CurrentStore.ID, impactSource);
					if (impact > maxImpact)
					{
						maxImpact = impact;
						maxImpactSource = impactSource;
					}
				}
			}
			string @string;
			if (maxImpactSource != null)
			{
				@string = A.R.GetString("I heard about you through {0}.", new object[]
				{
					A.R.GetString(maxImpactSource).ToLower()
				});
			}
			else
			{
				@string = A.R.GetString("Hello.");
			}
			return @string;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000772C File Offset: 0x0000672C
		protected float ValueOfGoodsHeld()
		{
			float total = 0f;
			foreach (object obj in this.Items)
			{
				Item i = (Item)obj;
				total += (float)this.AgreedUponPrices[i.ProductType.Index];
			}
			return total;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000077C0 File Offset: 0x000067C0
		protected string FindNearestSectionToInspect(ArrayList nodesAlreadyInspected)
		{
			string nodeName = null;
			float minDistance = float.MaxValue;
			for (int i = 0; i < 11; i++)
			{
				if (!nodesAlreadyInspected.Contains("S" + i))
				{
					float temp = this.PathLength(this.CurrentStore.Floor.Map.findPath(base.Location, "S" + i).ToPoints());
					if (temp < minDistance)
					{
						minDistance = temp;
						nodeName = "S" + i;
					}
				}
			}
			return nodeName;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000786C File Offset: 0x0000686C
		protected float PathLength(ArrayList points)
		{
			float distance = 0f;
			PointF loc = base.Location;
			foreach (object obj in points)
			{
				PointF p = (PointF)obj;
				distance += Utilities.DistanceBetween(loc, p);
				loc = p;
			}
			return distance;
		}

		// Token: 0x04000047 RID: 71
		private int side = 0;

		// Token: 0x04000048 RID: 72
		private bool windowShopper;

		// Token: 0x04000049 RID: 73
		private string raceString;

		// Token: 0x0400004A RID: 74
		private string demographicTypeString;

		/// The building that a person calls home. Should be set only by AddOccupant.
		// Token: 0x0400004B RID: 75
		protected AppBuilding home;

		/// <summary>
		/// The building where a person works. Should be set only by AddOccupant.
		/// </summary>
		// Token: 0x0400004C RID: 76
		protected AppBuilding workplace;

		// Token: 0x0400004D RID: 77
		protected long id;

		// Token: 0x0400004E RID: 78
		protected DemographicType demographicType;

		// Token: 0x0400004F RID: 79
		protected int age;

		// Token: 0x04000050 RID: 80
		protected int income;

		// Token: 0x04000051 RID: 81
		protected bool willShopOnBlockWithoutAds;

		/// <summary>
		/// Reports whether this particular customer will shoplift if given the chance
		/// </summary>
		// Token: 0x04000052 RID: 82
		public bool WillShoplift;

		// Token: 0x04000053 RID: 83
		public bool SignRequired = false;

		// Token: 0x04000054 RID: 84
		protected string genderString = "M";

		// Token: 0x04000055 RID: 85
		protected ArrayList nodesAlreadyInspected;

		// Token: 0x04000056 RID: 86
		public DateTime backupWakeUpTime = DateTime.MinValue;

		// Token: 0x04000057 RID: 87
		public long LineID;

		// Token: 0x04000058 RID: 88
		protected bool blocked = false;

		// Token: 0x04000059 RID: 89
		private Hashtable AgreedUponPrices = new Hashtable();

		// Token: 0x0400005A RID: 90
		protected int waitCount = 0;

		// Token: 0x0400005B RID: 91
		public ArrayList Needs = new ArrayList();

		// Token: 0x0400005C RID: 92
		public ArrayList ImpulseItems = new ArrayList();

		// Token: 0x0400005D RID: 93
		public Customer.States State = Customer.States.Idle;

		// Token: 0x0400005E RID: 94
		public AppEntity CurrentStore;

		// Token: 0x0400005F RID: 95
		public ArrayList Items = new ArrayList();

		// Token: 0x04000060 RID: 96
		protected ArrayList SectionsToShop = new ArrayList();

		// Token: 0x04000061 RID: 97
		protected SectionBase currSection;

		// Token: 0x04000062 RID: 98
		protected int cashierSteps;

		// Token: 0x04000063 RID: 99
		protected Hashtable gotMail = new Hashtable();

		// Token: 0x04000064 RID: 100
		protected int commentTimer;

		// Token: 0x04000065 RID: 101
		protected string comment;

		// Token: 0x04000066 RID: 102
		private bool lookingAtAd;

		// Token: 0x0200000E RID: 14
		public enum States
		{
			// Token: 0x04000068 RID: 104
			Idle,
			// Token: 0x04000069 RID: 105
			WalkBy,
			// Token: 0x0400006A RID: 106
			ToLine,
			// Token: 0x0400006B RID: 107
			NextToBeServed,
			// Token: 0x0400006C RID: 108
			FindNearestSectionToInspect,
			// Token: 0x0400006D RID: 109
			MoveToSection,
			// Token: 0x0400006E RID: 110
			ShopSection,
			// Token: 0x0400006F RID: 111
			MoveToCashier,
			// Token: 0x04000070 RID: 112
			AtCashier,
			// Token: 0x04000071 RID: 113
			Exit
		}
	}
}
