using System;
using System.Collections;
using System.Drawing;
using KMI.Biz.City;
using KMI.Biz.Product;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// The application specific SimState object, this is the object
	/// that gets serialized during a save.
	/// </summary>
	// Token: 0x0200003D RID: 61
	[Serializable]
	public class AppSimState : SimState
	{
		/// <summary>
		/// Constructs a new SimState for the application.
		/// </summary>
		/// <param name="simSettings">The SimSettings object to use
		/// for the application's state.</param>
		/// <param name="multiplayer">Whether or not this state
		/// is for a multiplayer game.</param>
		// Token: 0x060001B0 RID: 432 RVA: 0x00017760 File Offset: 0x00016760
		public AppSimState(SimSettings simSettings, bool multiplayer) : base(simSettings, multiplayer)
		{
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000177E4 File Offset: 0x000167E4
		protected override void CreateSpeeds()
		{
			this.speeds = new SimSpeed[]
			{
				new SimSpeed(125, 1),
				new SimSpeed(0, 1),
				new SimSpeed(0, 3),
				new SimSpeed(0, 11),
				new SimSpeed(0, 101)
			};
		}

		/// <summary>
		/// Initializes various aspects of this AppSimState object.
		/// </summary>
		/// <remarks>
		/// This override must call base.Init().
		/// </remarks>
		// Token: 0x060001B2 RID: 434 RVA: 0x00017838 File Offset: 0x00016838
		public override void Init()
		{
			base.Init();
			base.SimulatedTimePerStep = 30000;
			if (A.MF.LessonMode)
			{
				A.SS.ExpireGoods = false;
				A.SS.Shoplifting = false;
				A.SS.Seasonality = false;
				A.SS.LevelManagementOn = false;
				A.SS.MaxImpressionsNeeded = 0;
				A.SS.MinAcceptableUtility = -2f;
				A.SS.AutoStockInitialShelves = true;
			}
			this.LayOutCity();
			A.I.Subscribe(this.OurCity, Simulator.TimePeriod.Week);
			this.Suppliers = (Supplier[])TableReader.Read(typeof(frmMain).Assembly, typeof(Supplier), "KMI.VBR3Lib.Data.Suppliers.txt");
			int initialCustomers = A.SS.InitialCustomers;
			if (base.Multiplayer)
			{
				initialCustomers = (int)((float)initialCustomers * 1.5f);
			}
			this.MigrateInCustomers(initialCustomers);
			this.OurCity.RecomputeReachForBuildings(2000f);
			this.RecomputeReachForRadioStations();
			if (!base.Multiplayer)
			{
				for (int i = 0; i < A.SS.InitialAIPlayers; i++)
				{
					this.AddCompetitor();
				}
			}
			God god = new God();
			A.I.Subscribe(god, Simulator.TimePeriod.Week);
			A.I.Subscribe(god, Simulator.TimePeriod.Day);
			A.SS.Level = 1;
			if (base.Multiplayer)
			{
				A.SS.MachineFailures = true;
				A.SS.SnowStorms = true;
				A.SS.NextConstruction = A.ST.Now.AddDays((double)(365 + A.ST.Random.Next(180)));
				A.SS.LevelManagementOn = false;
				A.SS.MinAcceptableUtility = -1f;
			}
		}

		/// <summary>
		/// Try adding an AI competitor player with store
		/// </summary>
		// Token: 0x060001B3 RID: 435 RVA: 0x00017A20 File Offset: 0x00016A20
		public void AddCompetitor()
		{
			Player player = A.SA.CreatePlayer(Guid.NewGuid().ToString(), PlayerType.AI);
			int tries = 0;
			for (;;)
			{
				try
				{
					string storeName = Utilities.MakePossessive(Utilities.GetRandomFirstName(A.ST.Random));
					int ave = -1;
					int st = -1;
					int lot = -1;
					if (A.SA.getHumanPlayerCount() > 0 && A.ST.Random.NextDouble() < 0.6)
					{
						A.ST.OurCity.PickLocationNearUserStore(ref ave, ref st, ref lot);
					}
					else
					{
						do
						{
							A.ST.OurCity.PickVacantBuilding(0, ref ave, ref st, ref lot);
						}
						while (!this.TooNearOtherHubs(new Point(ave, st), 1) && tries++ < 1000);
					}
					if (ave > -1)
					{
						A.SA.TryAddEntity(player.PlayerName, storeName, ave, st, lot, A.SS.InitialAICapital, null);
					}
				}
				catch (SimApplicationException ex)
				{
					continue;
				}
				break;
			}
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00017B48 File Offset: 0x00016B48
		protected void LayOutCity()
		{
			this.OurCity = new AppCity();
			((CityView)A.I.Views[0]).ViewerOptions = A.ST.CityViewerOptions;
			this.OurCity.VacantLotImageName = "GrassPlot";
			this.OurCity.VacantLotImages = 8;
			this.OurCity.VacantLotImageIndices = new int[City.NUM_AVENUES, City.NUM_STREETS, City.LOTS_PER_BLOCK[0]];
			for (int a = 0; a < City.NUM_AVENUES; a++)
			{
				for (int s = 0; s < City.NUM_STREETS; s++)
				{
					for (int l = 0; l < City.LOTS_PER_BLOCK[0]; l++)
					{
						this.OurCity.VacantLotImageIndices[a, s, l] = A.ST.Random.Next(this.OurCity.VacantLotImages);
					}
				}
			}
			int rzones = 0;
			for (int i = 0; i < 2; i++)
			{
				foreach (string zone in new string[]
				{
					"Commercial",
					"Senior Residential",
					"Campus"
				})
				{
					int tries = 0;
					int a2;
					int s2;
					do
					{
						a2 = A.ST.Random.Next(City.NUM_AVENUES - 2) + 1;
						s2 = A.ST.Random.Next(City.NUM_STREETS - 2) + 1;
					}
					while (this.TooNearOtherHubs(new Point(a2, s2), 6 - tries++ / 20));
					this.OurCity.Hubs.Add(zone + i, new Point(a2, s2));
					if (zone == "Commercial")
					{
						int da = A.ST.Random.Next(2) * 2 - 1;
						int ds = A.ST.Random.Next(2) * 2 - 1;
						this.OurCity.Hubs.Add("Residential" + rzones++, new Point(a2 + da, s2 + ds));
					}
				}
			}
			int storesOnAves = 20;
			int storesElsewhere = 15;
			if (base.Multiplayer)
			{
				storesOnAves += 4;
				storesElsewhere += 4;
			}
			this.DistributeStores(this.OurCity, storesOnAves, storesElsewhere);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00017DDC File Offset: 0x00016DDC
		public bool TooNearOtherHubs(Point p2, int separation)
		{
			foreach (object obj in this.OurCity.Hubs.Values)
			{
				Point p3 = (Point)obj;
				if (2 * Math.Abs(p2.X - p3.X) + Math.Abs(p2.Y - p3.Y) < separation)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00017E88 File Offset: 0x00016E88
		public void DistributeStores(City city, int numStoresOnAves, int numStoresElsewhere)
		{
			Random rnd = A.ST.Random;
			int tries = 0;
			while (numStoresOnAves > 0 && tries < 1000)
			{
				int ai = rnd.Next(City.NUM_AVENUES);
				int si = rnd.Next(City.NUM_STREETS);
				CityBlock cityBlock = city[ai, si];
				int bi = rnd.Next(2) * (cityBlock.NumLots - 1);
				if (cityBlock[bi] == null && (this.TooNearOtherHubs(new Point(ai, si), 2) || A.ST.Random.NextDouble() < 0.4))
				{
					BuildingType buildingType = City.BuildingTypes[0];
					cityBlock[bi] = new AppBuilding(cityBlock, bi, buildingType);
					((AppCity)city).Stores.Add(cityBlock[bi]);
					numStoresOnAves--;
				}
				tries++;
			}
			tries = 0;
			while (numStoresElsewhere > 0 && tries < 1000)
			{
				int ai = rnd.Next(City.NUM_AVENUES);
				int si = rnd.Next(City.NUM_STREETS);
				CityBlock cityBlock = city[ai, si];
				int bi = rnd.Next(1, cityBlock.NumLots - 1);
				if (cityBlock[bi] == null && (this.TooNearOtherHubs(new Point(ai, si), 2) || A.ST.Random.NextDouble() < 0.4))
				{
					BuildingType buildingType = City.BuildingTypes[0];
					cityBlock[bi] = new AppBuilding(cityBlock, bi, buildingType);
					((AppCity)city).Stores.Add(cityBlock[bi]);
					numStoresElsewhere--;
				}
				tries++;
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00018064 File Offset: 0x00017064
		public void MigrateInCustomers(int count)
		{
			for (int i = 0; i < count; i++)
			{
				Customer newCustomer = new Customer();
				newCustomer.Init();
				int workplaceBuildingTypeIndex = -1;
				int homeBuildingTypeIndex = newCustomer.DemographicType.PreferredHome;
				if (newCustomer.DemographicType.PreferredWorkplace != -1)
				{
					workplaceBuildingTypeIndex = newCustomer.DemographicType.PreferredWorkplace;
				}
				bool succeeded;
				if (newCustomer.DemographicType.PreferredWorkplace != -1)
				{
					succeeded = this.OurCity.AddOccupant(newCustomer, homeBuildingTypeIndex, workplaceBuildingTypeIndex);
				}
				else
				{
					succeeded = this.OurCity.AddOccupant(newCustomer, homeBuildingTypeIndex);
				}
				if (succeeded)
				{
					this.Customers.Add(newCustomer.ID, newCustomer);
					A.I.Subscribe(newCustomer, newCustomer.WakeupTime);
				}
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00018134 File Offset: 0x00017134
		public void MigrateOutCustomers(int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (A.ST.Customers.Count > 0)
				{
					Customer dummy = A.ST.GetRandomCustomer();
					int homeBuildingTypeIndex = dummy.Home.BuildingType.Index;
					Customer droppedPerson = this.OurCity.DropOccupant(homeBuildingTypeIndex);
					if (droppedPerson != null)
					{
						A.ST.Customers.Remove(droppedPerson.ID);
						A.I.UnSubscribe(droppedPerson);
					}
				}
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x000181D4 File Offset: 0x000171D4
		// (set) Token: 0x060001BA RID: 442 RVA: 0x000181EC File Offset: 0x000171EC
		public Supplier[] Suppliers
		{
			get
			{
				return this.suppliers;
			}
			set
			{
				this.suppliers = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000181F8 File Offset: 0x000171F8
		public int Shift
		{
			get
			{
				for (int i = 0; i < AppConstants.ShiftStartHours.Length; i++)
				{
					if (A.ST.Hour >= AppConstants.ShiftStartHours[i] && A.ST.Hour % 24 < AppConstants.ShiftStartHours[i] + AppConstants.ShiftLengths[i])
					{
						return i;
					}
				}
				return 4;
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00018260 File Offset: 0x00017260
		public Customer GetRandomCustomer()
		{
			ArrayList customerList = new ArrayList(this.Customers.Values);
			return (Customer)customerList[A.ST.Random.Next(this.Customers.Count)];
		}

		// Token: 0x060001BD RID: 445 RVA: 0x000182A8 File Offset: 0x000172A8
		public void RecomputeReachForRadioStations()
		{
			foreach (RadioStation r in this.RadioStations)
			{
				r.Reach = 0;
				foreach (object obj in this.Customers.Values)
				{
					Customer c = (Customer)obj;
					this.RadioStations[c.DemographicType.PreferredRadioStation].Reach += 100;
				}
			}
		}

		// Token: 0x040001BE RID: 446
		public object[] CityViewerOptions = new object[]
		{
			1,
			1,
			false
		};

		// Token: 0x040001BF RID: 447
		protected Supplier[] suppliers;

		// Token: 0x040001C0 RID: 448
		public AppCity OurCity;

		// Token: 0x040001C1 RID: 449
		public Hashtable Customers = new Hashtable();

		// Token: 0x040001C2 RID: 450
		public ArrayList PopulationHistory = new ArrayList();

		// Token: 0x040001C3 RID: 451
		public DateTime NextStorm = DateTime.MinValue;

		// Token: 0x040001C4 RID: 452
		public RadioStation[] RadioStations = (RadioStation[])TableReader.Read(typeof(RadioStation), "KMI.VBR3Lib.Data.RadioStations.txt");
	}
}
