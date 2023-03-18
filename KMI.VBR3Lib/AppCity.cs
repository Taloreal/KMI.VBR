using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Sim;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for AppCity.
	/// </summary>
	// Token: 0x02000048 RID: 72
	[Serializable]
	public class AppCity : City
	{
		// Token: 0x06000224 RID: 548 RVA: 0x0001FB00 File Offset: 0x0001EB00
		public void AddBillboard(AppEntity e, int avenue, int street, int lot)
		{
			AppBuilding bldg = (AppBuilding)this.blocks[avenue, street][lot];
			if (bldg.BillboardOwner != null)
			{
				throw new SimApplicationException(A.R.GetString("{0} already has a billboard on that building.", new object[]
				{
					bldg.BillboardOwner.Name
				}));
			}
			bldg.BillboardOwner = e;
			e.BillboardBuildings.Add(bldg);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0001FB78 File Offset: 0x0001EB78
		public void KillBillboard(AppEntity e, int avenue, int street, int lot)
		{
			AppBuilding bldg = (AppBuilding)this.blocks[avenue, street][lot];
			if (bldg.BillboardOwner != e && !A.SS.BillboardAdvertisingEnabledForNonOwner)
			{
				throw new SimApplicationException(A.R.GetString("You do not have permission to remove this billboard."));
			}
			bldg.BillboardOwner = null;
			e.BillboardBuildings.Remove(bldg);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0001FBE8 File Offset: 0x0001EBE8
		protected AppBuilding AddBuilding(int buildingTypeIndex, Building near)
		{
			string zone = "";
			if (A.ST.Random.NextDouble() < (double)A.SS.ZoningDistinctness)
			{
				switch (buildingTypeIndex)
				{
				case 1:
					zone = "Residential";
					break;
				case 2:
					zone = "Commercial";
					break;
				case 3:
					zone = "Senior Residential";
					break;
				case 4:
					zone = "Campus";
					break;
				case 5:
					zone = "Campus";
					break;
				default:
					zone = "";
					break;
				}
			}
			ArrayList points = new ArrayList();
			foreach (object obj in this.Hubs.Keys)
			{
				string key = (string)obj;
				if (key.StartsWith(zone))
				{
					points.Add(this.Hubs[key]);
				}
			}
			if (near != null)
			{
				float dist2 = float.MaxValue;
				Point nearest = Point.Empty;
				foreach (object obj2 in points)
				{
					Point p = (Point)obj2;
					float temp = (float)(2 * Math.Abs(near.Avenue - p.X) + Math.Abs(near.Street - p.Y));
					if (temp < dist2)
					{
						dist2 = temp;
						nearest = p;
					}
				}
				points = new ArrayList();
				points.Add(nearest);
			}
			CityBlock closest = null;
			ArrayList cityBlocks = new ArrayList();
			float dist3 = float.MaxValue;
			foreach (object obj3 in points)
			{
				Point p = (Point)obj3;
				for (int ai = 0; ai < City.NUM_AVENUES; ai++)
				{
					for (int si = 0; si < City.NUM_STREETS; si++)
					{
						for (int bi = 0; bi < base[ai, si].NumLots; bi++)
						{
							if (base[ai, si, bi] == null)
							{
								cityBlocks.Add(base[ai, si]);
								float temp = (float)(2 * Math.Abs(ai - p.X) + Math.Abs(si - p.Y));
								if (temp < dist3 && A.ST.Random.NextDouble() < (double)A.SS.ZoningDistinctness)
								{
									closest = base[ai, si];
									dist3 = temp;
								}
								break;
							}
						}
					}
				}
			}
			if (A.ST.Random.NextDouble() < (double)A.SS.ZoningRandomness && cityBlocks.Count > 0)
			{
				closest = (CityBlock)cityBlocks[A.ST.Random.Next(cityBlocks.Count)];
			}
			AppBuilding result;
			if (closest == null)
			{
				result = null;
			}
			else
			{
				CityBlock block = closest;
				int index = A.ST.Random.Next(block.NumLots);
				while (block[index % block.NumLots] != null)
				{
					index++;
				}
				BuildingType buildingType = City.BuildingTypes[buildingTypeIndex];
				AppBuilding bldg = new AppBuilding(block, index % block.NumLots, buildingType);
				block[index % block.NumLots] = bldg;
				float reach = 0f;
				if (bldg.OnAvenue > -1)
				{
					reach += base[bldg.OnAvenue, block.Street].AvenueTraffic.GetDensity();
				}
				reach += block.StreetTraffic.GetDensity();
				bldg.Reach = (int)(reach * 20f * 5f * 20f);
				result = bldg;
			}
			return result;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x000200A0 File Offset: 0x0001F0A0
		public void AdjustTrafficDensity(Customer customer, int upOrDown)
		{
			int demoType = customer.DemographicType.Index;
			float amount = 0.05f * (float)upOrDown;
			ArrayList blocksPassed = new ArrayList();
			ArrayList blocksStreetPassed = new ArrayList();
			ArrayList blocksAvenuePassed = new ArrayList();
			blocksPassed.Add(customer.Home.Block);
			if (customer.Workplace != null)
			{
				blocksPassed.Add(customer.Workplace.Block);
				int si = customer.Home.Street;
				int ai;
				for (ai = customer.Home.Avenue; ai != customer.Workplace.Avenue; ai += Math.Sign(customer.Workplace.Avenue - ai))
				{
					if (base[ai, si] != customer.Home.Block)
					{
						blocksStreetPassed.Add(base[ai, si]);
					}
				}
				while (si != customer.Workplace.Street)
				{
					if (base[ai, si] != customer.Home.Block)
					{
						blocksAvenuePassed.Add(base[ai, si]);
					}
					si += Math.Sign(customer.Workplace.Street - si);
				}
			}
			ArrayList hours = new ArrayList();
			hours.Add(customer.WakeupTime.Hour);
			if (demoType == 1 && A.ST.Random.NextDouble() < 0.25)
			{
				hours.Add(A.ST.Random.Next(7, 10));
			}
			foreach (object obj in hours)
			{
				int hour = (int)obj;
				int hourBefore = (hour - 1 + 24) % 24;
				int hourAfter = (hour + 1) % 24;
				foreach (object obj2 in blocksPassed)
				{
					CityBlock block = (CityBlock)obj2;
					block.AvenueTraffic.IncrementDensity(hourBefore, demoType, amount / 2f);
					block.StreetTraffic.IncrementDensity(hourBefore, demoType, amount / 2f);
					block.AvenueTraffic.IncrementDensity(hour, demoType, amount);
					block.StreetTraffic.IncrementDensity(hour, demoType, amount);
					block.AvenueTraffic.IncrementDensity(hourAfter, demoType, amount / 2f);
					block.StreetTraffic.IncrementDensity(hourAfter, demoType, amount / 2f);
				}
				foreach (object obj3 in blocksStreetPassed)
				{
					CityBlock block = (CityBlock)obj3;
					block.StreetTraffic.IncrementDensity(hourBefore, demoType, amount / 2f);
					block.StreetTraffic.IncrementDensity(hour, demoType, amount);
					block.StreetTraffic.IncrementDensity(hourAfter, demoType, amount / 2f);
				}
				foreach (object obj4 in blocksAvenuePassed)
				{
					CityBlock block = (CityBlock)obj4;
					block.AvenueTraffic.IncrementDensity(hourBefore, demoType, amount / 2f);
					block.AvenueTraffic.IncrementDensity(hour, demoType, amount);
					block.AvenueTraffic.IncrementDensity(hourAfter, demoType, amount / 2f);
				}
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x000204FC File Offset: 0x0001F4FC
		public bool AddOccupant(Customer customer, int homeBuildingTypeIndex, int workplaceBuildingTypeIndex)
		{
			bool newHomeCreated = false;
			AppBuilding home;
			if (this.currentBuilding[homeBuildingTypeIndex] != null && this.currentBuilding[homeBuildingTypeIndex].Occupants.Count < this.currentBuilding[homeBuildingTypeIndex].BuildingType.MaxOccupants)
			{
				home = this.currentBuilding[homeBuildingTypeIndex];
			}
			else
			{
				home = this.AddBuilding(homeBuildingTypeIndex, null);
				if (home == null)
				{
					return false;
				}
				newHomeCreated = true;
				this.currentBuilding[homeBuildingTypeIndex] = home;
			}
			AppBuilding workplace = this.FindWorkplaceWithRoomNear(home, workplaceBuildingTypeIndex);
			if (workplace == null)
			{
				workplace = this.AddBuilding(workplaceBuildingTypeIndex, home);
				if (workplace == null)
				{
					if (newHomeCreated)
					{
						this.RemoveBuilding(home);
					}
					return false;
				}
				this.currentBuilding[workplaceBuildingTypeIndex] = workplace;
			}
			home.Occupants.Add(customer);
			customer.Home = home;
			workplace.Occupants.Add(customer);
			customer.Workplace = workplace;
			this.AdjustTrafficDensity(customer, 1);
			return true;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00020608 File Offset: 0x0001F608
		private ArrayList GetBuildings(int buildingTypeIndex)
		{
			ArrayList temp = new ArrayList();
			for (int ai = 0; ai < City.NUM_AVENUES; ai++)
			{
				for (int si = 0; si < City.NUM_STREETS; si++)
				{
					for (int bi = 0; bi < base[ai, si].NumLots; bi++)
					{
						if (base[ai, si, bi] != null && base[ai, si, bi].BuildingType.Index == buildingTypeIndex)
						{
							temp.Add(base[ai, si, bi]);
						}
					}
				}
			}
			return temp;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000206B0 File Offset: 0x0001F6B0
		private AppBuilding FindWorkplaceWithRoomNear(AppBuilding home, int buildingTypeIndex)
		{
			ArrayList temp = this.GetBuildings(buildingTypeIndex);
			foreach (object obj in temp)
			{
				AppBuilding b = (AppBuilding)obj;
				if (b.Occupants.Count < b.BuildingType.MaxOccupants && this.Distance(b, home) < 10f)
				{
					return b;
				}
			}
			return null;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00020754 File Offset: 0x0001F754
		private float Distance(AppBuilding b1, AppBuilding b2)
		{
			return (float)(2 * Math.Abs(b1.Avenue - b2.Avenue) + Math.Abs(b1.Street - b2.Street));
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00020790 File Offset: 0x0001F790
		public bool AddOccupant(Customer customer, int homeBuildingTypeIndex)
		{
			AppBuilding home;
			if (this.currentBuilding[homeBuildingTypeIndex] != null && this.currentBuilding[homeBuildingTypeIndex].Occupants.Count < this.currentBuilding[homeBuildingTypeIndex].BuildingType.MaxOccupants)
			{
				home = this.currentBuilding[homeBuildingTypeIndex];
			}
			else
			{
				home = this.AddBuilding(homeBuildingTypeIndex, null);
				if (home == null)
				{
					return false;
				}
				this.currentBuilding[homeBuildingTypeIndex] = home;
			}
			home.Occupants.Add(customer);
			customer.Home = home;
			this.AdjustTrafficDensity(customer, 1);
			return true;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0002082C File Offset: 0x0001F82C
		public Customer DropOccupant(int homeBuildingTypeIndex)
		{
			AppBuilding bldg = this.currentBuilding[homeBuildingTypeIndex];
			foreach (object obj in bldg.Occupants)
			{
				Customer customer = (Customer)obj;
				if (customer.State == Customer.States.Idle)
				{
					bldg.Occupants.Remove(customer);
					if (bldg.Occupants.Count == 0)
					{
						this.RemoveBuilding(bldg);
					}
					if (customer.Workplace != null)
					{
						bldg = customer.Workplace;
						bldg.Occupants.Remove(customer);
						if (bldg.Occupants.Count == 0)
						{
							this.RemoveBuilding(bldg);
						}
					}
					this.AdjustTrafficDensity(customer, -1);
					return customer;
				}
			}
			return null;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00020938 File Offset: 0x0001F938
		private void MigrateCustomers()
		{
			A.ST.PopulationHistory.Add(A.ST.Customers.Count * 20 * 5);
			float rate = A.SS.MigrationRate / 52f;
			string migrationType = A.SS.MigrationType;
			float weeklyMigrationIn;
			float weeklyMigrationOut;
			if (migrationType != null)
			{
				if (migrationType == "Up")
				{
					weeklyMigrationIn = rate * 1.2f;
					weeklyMigrationOut = rate * 0.2f;
					goto IL_145;
				}
				if (migrationType == "Down")
				{
					weeklyMigrationIn = rate * 0.2f;
					weeklyMigrationOut = rate * 1.2f;
					goto IL_145;
				}
				if (migrationType == "Cycle")
				{
					if (this.directionOfMigration == 1)
					{
						weeklyMigrationIn = rate * 1.2f;
						weeklyMigrationOut = rate * 0.2f;
					}
					else
					{
						weeklyMigrationIn = rate * 0.2f;
						weeklyMigrationOut = rate * 1.2f;
					}
					if ((double)A.ST.Customers.Count < (double)A.SS.InitialCustomers * 0.2)
					{
						this.directionOfMigration = 1;
					}
					if (base.Filled)
					{
						this.directionOfMigration = -1;
					}
					goto IL_145;
				}
			}
			weeklyMigrationOut = 0f;
			weeklyMigrationIn = 0f;
			IL_145:
			int totalIn = (int)(2.0 * A.ST.Random.NextDouble() * (double)weeklyMigrationIn * (double)A.SS.InitialCustomers);
			int totalOut = (int)(2.0 * A.ST.Random.NextDouble() * (double)weeklyMigrationOut * (double)A.SS.InitialCustomers);
			if (totalIn > totalOut)
			{
				A.ST.MigrateInCustomers(totalIn - totalOut);
			}
			else
			{
				A.ST.MigrateOutCustomers(totalOut - totalIn);
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00020B0C File Offset: 0x0001FB0C
		protected void RemoveBuilding(AppBuilding bldg)
		{
			AppEntity e = (AppEntity)bldg.BillboardOwner;
			if (e != null)
			{
				e.BillboardBuildings.Remove(bldg);
				e.Player.SendMessage(A.R.GetString("A building on which you had a billboard was demolished due to population declines. You may want to place a billboard elsewhere."), null, NotificationColor.Yellow);
			}
			base[bldg.Avenue, bldg.Street, bldg.Lot] = null;
			this.currentBuilding[bldg.BuildingType.Index] = (AppBuilding)base.GetRandomBuilding(bldg.BuildingType.Index);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00020B9C File Offset: 0x0001FB9C
		public override void NewWeek()
		{
			this.MigrateCustomers();
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00020BA8 File Offset: 0x0001FBA8
		public ArrayList GetBuildings()
		{
			ArrayList i = new ArrayList();
			CityBlock[,] blocks = this.blocks;
			int upperBound = blocks.GetUpperBound(0);
			int upperBound2 = blocks.GetUpperBound(1);
			for (int k = blocks.GetLowerBound(0); k <= upperBound; k++)
			{
				for (int l = blocks.GetLowerBound(1); l <= upperBound2; l++)
				{
					CityBlock block = blocks[k, l];
					for (int j = 0; j < block.NumLots; j++)
					{
						if (block[j] != null)
						{
							i.Add(block[j]);
						}
					}
				}
			}
			return i;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00020C64 File Offset: 0x0001FC64
		public void RelocateStore()
		{
			Building b = new AppBuilding(this.blocks[8, 10], 0, City.BuildingTypes[0]);
			this.Stores.Add(b);
			this.blocks[8, 10][0] = b;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00020CB4 File Offset: 0x0001FCB4
		public void GetGoodBillBoardLocation(AppBuilding bldg, ref int ave, ref int street, ref int lot)
		{
			ArrayList temp = new ArrayList();
			for (int ai = 0; ai < City.NUM_AVENUES; ai++)
			{
				for (int si = 0; si < City.NUM_STREETS; si++)
				{
					for (int bi = 0; bi < base[ai, si].NumLots; bi++)
					{
						AppBuilding b = (AppBuilding)base[ai, si, bi];
						if (b != null && b.BuildingType.CanTakeSign && b.BillboardOwner == null && this.Distance(bldg, b) < 4f)
						{
							ave = b.Avenue;
							street = b.Street;
							lot = b.Lot;
						}
					}
				}
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00020D94 File Offset: 0x0001FD94
		public void PickLocationNearUserStore(ref int ave, ref int street, ref int lot)
		{
			float min = float.MaxValue;
			for (int ai = 0; ai < City.NUM_AVENUES; ai++)
			{
				for (int si = 0; si < City.NUM_STREETS; si++)
				{
					for (int bi = 0; bi < base[ai, si].NumLots; bi++)
					{
						foreach (object obj in A.ST.Entity.Values)
						{
							AppEntity e = (AppEntity)obj;
							if (!e.AI)
							{
								AppBuilding bldg = (AppBuilding)e.Building;
								AppBuilding b = (AppBuilding)base[ai, si, bi];
								if (b != null && b.Owner == null && b.BuildingType.Index == 0 && this.Distance(bldg, b) < min)
								{
									ave = b.Avenue;
									street = b.Street;
									lot = b.Lot;
									min = this.Distance(bldg, b);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0400021F RID: 543
		public const int SignColors = 6;

		// Token: 0x04000220 RID: 544
		public Hashtable Hubs = new Hashtable();

		// Token: 0x04000221 RID: 545
		protected AppBuilding[] currentBuilding = new AppBuilding[City.BuildingTypeCount];

		// Token: 0x04000222 RID: 546
		public ArrayList Stores = new ArrayList();
	}
}
