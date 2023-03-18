using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz;
using KMI.Biz.City;
using KMI.Biz.Product;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Entity for this application.
	/// </summary>
	// Token: 0x0200003E RID: 62
	[Serializable]
	public class AppEntity : Entity
	{
		/// <summary>
		/// Constructor to do any app specific construction.
		/// Most initialization should be done by overriding Init.
		/// </summary>
		/// <param name="player">Player owning entity.</param>
		/// <param name="name">Name of new entity.</param>
		// Token: 0x060001BE RID: 446 RVA: 0x00018364 File Offset: 0x00017364
		public AppEntity(Player player, string name) : base(player, name)
		{
			this.Init();
			S.I.Subscribe(this);
		}

		/// <summary>
		/// Initializes the app-specific entity. Example accounts set up.
		/// </summary>
		// Token: 0x060001BF RID: 447 RVA: 0x0001847C File Offset: 0x0001747C
		public void Init()
		{
			this.Founded = A.ST.Now;
			string[] prodNames = new string[25];
			int i = 0;
			foreach (VBRProductType p in AppConstants.ProductTypes)
			{
				prodNames[i++] = p.Name;
			}
			base.GL = new GeneralLedger(prodNames);
			this.SetupGeneralLedger();
			this.Backroom = new Backroom(this);
			this.Floor = new Floor(this);
			this.Wages = new float[]
			{
				7.5f,
				7.5f
			};
			this.PhysicalInventoryFrequency = 3;
			if (base.AI)
			{
				this.Schedule = new int[,]
				{
					{
						2,
						2,
						2,
						2,
						2,
						2
					},
					{
						2,
						2,
						2,
						2,
						1,
						1
					}
				};
				this.AP.SetPolicy(new string[]
				{
					A.ST.Suppliers[0].Name
				}, new int[]
				{
					15
				});
				this.PricingPolicy = new PricingPolicy(A.SS.InitialAIMargin, A.SS.InitialAIMargin, 25);
				this.PricingPolicy.SetToCustom(22, 0.91f, 0f);
				this.PricingPolicy.SetToCustom(24, 0.86f, 0f);
				this.PurchasingPolicy = new PurchasingPolicy(400, 400, 25);
				this.RadioBookings = new bool[,]
				{
					{
						true,
						false,
						true
					},
					{
						true,
						false,
						false
					},
					{
						false,
						true,
						true
					},
					{
						false,
						true,
						false
					}
				};
				this.Registers = 2;
				if (A.MF.LessonMode)
				{
					this.Registers = 2;
					this.PurchasingPolicy = new PurchasingPolicy(0, 0, 25);
					this.RadioBookings = new bool[,]
					{
						{
							true,
							false,
							false
						},
						{
							false,
							false,
							false
						},
						{
							false,
							false,
							true
						},
						{
							false,
							true,
							false
						}
					};
				}
			}
			else
			{
				int[,] schedule = new int[2, 6];
				this.Schedule = schedule;
				this.AP.SetPolicy(new string[]
				{
					A.ST.Suppliers[0].Name
				}, new int[]
				{
					7
				});
				this.PricingPolicy = new PricingPolicy(0.45f, 0.45f, 25);
				this.PurchasingPolicy = new PurchasingPolicy(0, 0, 25);
			}
			this.SignColor = AppConstants.StoreSignColors[A.ST.Entity.Count % AppConstants.StoreSignColors.Length];
			this.ServiceContracts.Add(typeof(CoolingDuct), new ServiceContract("Backroom Cooling Duct"));
			this.ServiceContracts.Add(typeof(Fridge), new ServiceContract("Refrigeration Unit"));
			this.ServiceContracts.Add(typeof(Coffee), new ServiceContract("Coffee Station"));
			this.ServiceContracts.Add(typeof(Slushy), new ServiceContract("Slushy Machine"));
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00018780 File Offset: 0x00017780
		private void SetupGeneralLedger()
		{
			base.GL.AddAccount("Revenue", GeneralLedger.AccountType.Revenue);
			base.GL.AddAccount("COGS", GeneralLedger.AccountType.COGS);
			base.GL.AddAccount("Actually Sold", GeneralLedger.AccountType.COGS, "COGS");
			base.GL.AddAccount("Expired Goods", GeneralLedger.AccountType.COGS, "COGS");
			base.GL.AddAccount("Stolen Goods", GeneralLedger.AccountType.COGS, "COGS");
			base.GL.AddAccount("Early Pay Discounts", GeneralLedger.AccountType.COGS, "COGS");
			base.GL.AddAccount("Gross Margin", GeneralLedger.AccountType.GrossMargin);
			base.GL.AddAccount("Rent", GeneralLedger.AccountType.Expense);
			base.GL.AddAccount("Wages", GeneralLedger.AccountType.Expense);
			base.GL.AddAccount("Promotion", GeneralLedger.AccountType.Expense);
			base.GL.AddAccount("Radio", GeneralLedger.AccountType.Expense, "Promotion");
			base.GL.AddAccount("Direct Mail", GeneralLedger.AccountType.Expense, "Promotion");
			base.GL.AddAccount("Billboards", GeneralLedger.AccountType.Expense, "Promotion");
			base.GL.AddAccount("Equipment Costs", GeneralLedger.AccountType.Expense);
			base.GL.AddAccount("Registers", GeneralLedger.AccountType.Expense, "Equipment Costs");
			base.GL.AddAccount("Security Cameras", GeneralLedger.AccountType.Expense, "Equipment Costs");
			base.GL.AddAccount("Fixtures", GeneralLedger.AccountType.Expense, "Equipment Costs");
			base.GL.AddAccount("Shelf Racks", GeneralLedger.AccountType.Expense, "Fixtures");
			base.GL.AddAccount("Magazine Racks", GeneralLedger.AccountType.Expense, "Fixtures");
			base.GL.AddAccount("Donut Stations", GeneralLedger.AccountType.Expense, "Fixtures");
			base.GL.AddAccount("Refrigeration Units", GeneralLedger.AccountType.Expense, "Fixtures");
			base.GL.AddAccount("Coffee Stations", GeneralLedger.AccountType.Expense, "Fixtures");
			base.GL.AddAccount("Slushy Machines", GeneralLedger.AccountType.Expense, "Fixtures");
			base.GL.AddAccount("Service Contracts", GeneralLedger.AccountType.Expense, "Equipment Costs");
			base.GL.AddAccount("Refrigeration Units ", GeneralLedger.AccountType.Expense, "Service Contracts");
			base.GL.AddAccount("Coffee Stations ", GeneralLedger.AccountType.Expense, "Service Contracts");
			base.GL.AddAccount("Slushy Machines ", GeneralLedger.AccountType.Expense, "Service Contracts");
			base.GL.AddAccount("Backroom Cooling Ducts ", GeneralLedger.AccountType.Expense, "Service Contracts");
			base.GL.AddAccount("Immediate Repairs", GeneralLedger.AccountType.Expense, "Equipment Costs");
			base.GL.AddAccount("Other", GeneralLedger.AccountType.Expense);
			base.GL.AddAccount("Surveys", GeneralLedger.AccountType.Expense, "Other");
			base.GL.AddAccount("Consulting Fees", GeneralLedger.AccountType.Expense, "Other");
			base.GL.AddAccount("Interest", GeneralLedger.AccountType.Expense, "Other");
			base.GL.AddAccount("Moving Expenses", GeneralLedger.AccountType.Expense, "Other");
			base.GL.AddAccount("Profit", GeneralLedger.AccountType.Profit);
			base.GL.AddAccount("Assets", GeneralLedger.AccountType.Asset);
			base.GL.AddAccount("Cash", GeneralLedger.AccountType.Asset, "Assets");
			base.GL.AddAccount("Inventory", GeneralLedger.AccountType.Asset, "Assets");
			base.GL.AddAccount("Liabilities Plus Equity", GeneralLedger.AccountType.Liability);
			base.GL.AddAccount("Liabilities", GeneralLedger.AccountType.Liability, "Liabilities Plus Equity");
			base.GL.AddAccount("Accounts Payable", GeneralLedger.AccountType.Liability, "Liabilities");
			base.GL.AddAccount("Debt", GeneralLedger.AccountType.Liability, "Liabilities");
			base.GL.AddAccount("Equity", GeneralLedger.AccountType.Liability, "Liabilities Plus Equity");
			base.GL.AddAccount("Paid-in Capital", GeneralLedger.AccountType.Liability, "Equity");
			base.GL.AddAccount("Retained Earnings", GeneralLedger.AccountType.Liability, "Equity");
			base.GL.AddAccount("Sales", GeneralLedger.AccountType.Product);
			base.GL.AddAccount("COGS: Actual Sales", GeneralLedger.AccountType.Product);
			base.GL.AddAccount("Expired Goods", GeneralLedger.AccountType.Product);
			base.GL.AddAccount("Stolen Goods", GeneralLedger.AccountType.Product);
			base.GL.AddAccount("Purchases", GeneralLedger.AccountType.Product);
			base.GL.AddAccount("Inventory", GeneralLedger.AccountType.Product);
			base.GL.AddAccount("Customers", GeneralLedger.AccountType.Other);
			base.GL.AddAccount("Sales Lost Due To Price", GeneralLedger.AccountType.OtherProduct);
			base.GL.AddAccount("Sales Lost Due To Availability", GeneralLedger.AccountType.OtherProduct);
			base.GL.AddAccount("Sales Lost Due To Expired Goods", GeneralLedger.AccountType.Other);
			base.GL.AddAccount("Sales Lost Due To Long Wait", GeneralLedger.AccountType.Other);
			base.GL.AddAccount("Price", GeneralLedger.AccountType.OtherProduct);
		}

		/// <summary>
		/// Journal key data for actions journal and scoreboard. Actual data journaled
		/// may vary for applications.
		/// </summary>
		// Token: 0x060001C1 RID: 449 RVA: 0x00018C40 File Offset: 0x00017C40
		public override void NewWeek()
		{
			float profit = base.GL.AccountBalance("Profit", S.ST.CurrentWeek - 1, GeneralLedger.Frequency.Weekly);
			base.Journal.AddNumericData("Cumulative Profit", profit + base.Journal.NumericDataSeriesLastEntry("Cumulative Profit"));
			base.Journal.AddNumericData("Profit", profit);
			ArrayList paidOffLoans = new ArrayList();
			foreach (object obj in this.Loans.Values)
			{
				Loan loan = (Loan)obj;
				if (loan.Due < A.ST.Now)
				{
					string msg = A.R.GetString("The loan to {0}, due on {1}, is now overdue. The balance of {2} will be deducted from your cash.", new object[]
					{
						base.Name,
						loan.Due.ToLongDateString(),
						Utilities.FC(loan.Balance, A.I.CurrencyConversion)
					});
					base.Player.SendMessage(msg, base.Name, NotificationColor.Red);
					paidOffLoans.Add(loan);
					base.GL.Post("Debt", loan.Balance, "Cash");
				}
				else if (loan.Due < A.ST.Now.AddDays(7.0))
				{
					string msg = A.R.GetString("{0} has a loan coming due within the next week.  The loan amount will be deducted from your account next week.  Try to get a new loan now if you do not have enough cash to pay off the loan coming due.", new object[]
					{
						base.Name
					});
					base.Player.SendMessage(msg, base.Name, NotificationColor.Yellow);
				}
				base.GL.Post("Interest", loan.Balance * loan.InterestRate / 52f, "Cash");
			}
			foreach (object obj2 in paidOffLoans)
			{
				Loan loan = (Loan)obj2;
				this.Loans.Remove(loan.Due);
			}
			if (base.GL.AccountBalance("Cash") < A.SS.InitialHumanCapital / 10f)
			{
				base.Player.SendModalMessage(A.R.GetString("Your store, {0}, is running dangerously low on cash! Transfer cash in, invest more capital or get a loan now! You may want to save your sim before you run out of cash.", new object[]
				{
					base.Name
				}), "Low Cash Warning", MessageBoxIcon.Exclamation);
			}
			else if (base.GL.AccountBalance("Cash") < A.SS.InitialHumanCapital / 4f)
			{
				base.Player.SendModalMessage(A.R.GetString("Your store, {0}, is running low on cash. Consider transferring cash in, investing more capital or getting a loan. You may want to save your sim before you run out of cash.", new object[]
				{
					base.Name
				}), "Low Cash Warning", MessageBoxIcon.Exclamation);
			}
			if (this.PhysicalInventoryFrequency != 0)
			{
				if ((A.ST.CurrentWeek - this.physicalInventoryStartOffset) % this.PhysicalInventoryFrequency == 0)
				{
					this.ConductPhysicalInventory();
					base.GL.Post("Wages", 250f, "Cash");
				}
			}
			foreach (VBRProductType pt in AppConstants.ProductTypes)
			{
				base.GL.PostNonFinancial("Price", this.PricingPolicy.GetPrice(pt.Index, pt.Cost), pt.Name, A.ST.CurrentWeek - 1);
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00019054 File Offset: 0x00018054
		public float GetPriceWithDiscount(int product)
		{
			return this.PricingPolicy.GetPrice(product, AppConstants.ProductTypes[product].Cost) * (1f - this.Discounts[product]);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00019090 File Offset: 0x00018090
		public override void NewDay()
		{
			if (this.CriticalResourceBalance() < 0f)
			{
				this.Retire();
			}
			else
			{
				this.AP.PayInvoices(A.ST.Suppliers, A.ST.Now, base.GL);
				Supplier supplier = A.ST.Suppliers[0];
				if (this.AP.PastDue(supplier) > 0f)
				{
					base.Player.SendMessage(A.R.GetString("Your supplier has halted deliveries to you, because you have not paid your bills on time. Use Trade Credit to adjust payment policies."), base.Name, NotificationColor.Yellow);
				}
				int[] need = new int[25];
				int[] bought = new int[25];
				for (int i = 0; i < 25; i++)
				{
					int have = (int)base.GL.AccountBalance("Inventory - " + AppConstants.ProductTypes[i].Name + " (units)");
					if (have < this.PurchasingPolicy.GetAmount(i) && this.SomeShelfSpaceFor(i))
					{
						need[i] = (int)Math.Ceiling((double)((float)(this.PurchasingPolicy.GetAmount(i) - have) / 20f));
					}
				}
				float invoiceTotal = 0f;
				bool moreToBuy = true;
				while (moreToBuy && !this.Backroom.Full)
				{
					moreToBuy = false;
					for (int i = 0; i < 25; i++)
					{
						ProductType pt = AppConstants.ProductTypes[i];
						if (need[i] > 0)
						{
							moreToBuy = true;
							this.Backroom.Stock(pt, 1);
							base.GL.Post("Inventory", pt.Cost * 20f, "Accounts Payable", pt.Name, 20, new string[]
							{
								"Inventory",
								"Purchases"
							}, new string[0]);
							invoiceTotal += pt.Cost * 20f;
							need[i]--;
							if (this.Backroom.Full)
							{
								break;
							}
						}
					}
				}
				Supplier s = A.ST.Suppliers[0];
				DateTime now = A.ST.Now;
				this.AP.AddInvoice(new Invoice(s.Name, "Goods", invoiceTotal, now, now.AddDays((double)s.DaysToPay), now.AddDays((double)s.EarlyPayDays), s.EarlyPayDiscount));
				if (A.SS.AutoStockInitialShelves)
				{
					foreach (object obj in this.Floor.AllShelves)
					{
						Shelf shelf = (Shelf)obj;
						this.AutoStockShelf(shelf);
					}
					A.SS.AutoStockInitialShelves = false;
				}
				if (this.MailingFrequency > 0 && this.MostRecentlyUsedMailingList != null)
				{
					int days = (A.ST.Now - A.SS.StartDate).Days;
					if ((days - this.mailingStartOffset) % this.MailingFrequency == this.MailingFrequency - 1)
					{
						A.SA.ExecuteMailing(base.ID, this.MostRecentlyUsedMailingList);
					}
				}
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00019438 File Offset: 0x00018438
		public void AutoStockShelf(Shelf shelf)
		{
			for (int i = 0; i < shelf.Items.Length; i++)
			{
				shelf.Items[i] = this.Backroom.TakeItemOfType(shelf.ProductType);
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00019478 File Offset: 0x00018478
		public override void NewHour()
		{
			int shift = -1;
			for (int i = 0; i < AppConstants.ShiftStartHours.Length; i++)
			{
				if (A.ST.Hour == AppConstants.ShiftStartHours[i])
				{
					shift = i;
				}
			}
			if (shift > -1)
			{
				foreach (object obj in this.ShelfStockers)
				{
					ShelfStocker ss = (ShelfStocker)obj;
					ss.ThrowBackProduct();
					ss.Retire();
				}
				this.ShelfStockers.Clear();
				for (int i = 0; i < this.Schedule[1, shift]; i++)
				{
					this.ShelfStockers.Add(new ShelfStocker(this.Floor));
				}
				ArrayList old = (ArrayList)this.Cashiers.Clone();
				this.Cashiers.Clear();
				for (int i = 0; i < this.Schedule[0, shift]; i++)
				{
					this.Cashiers.Add(new Cashier(this.Floor, i));
				}
				for (int i = 0; i < old.Count; i++)
				{
					if (i < this.Cashiers.Count)
					{
						((Cashier)this.Cashiers[i]).LockedBy = ((Cashier)old[i]).LockedBy;
					}
					((Cashier)old[i]).Retire();
				}
			}
			float hoursPerWeek = 168f;
			base.GL.Post("Radio", this.RadioAdvertisingCost() / hoursPerWeek, "Cash");
			base.GL.Post("Wages", (float)(this.Schedule[0, A.ST.Shift] + this.Schedule[1, A.ST.Shift]) * AppConstants.WageRate, "Cash");
			base.GL.Post("Billboards", this.BillboardRent() / hoursPerWeek, "Cash");
			base.GL.Post("Rent", AppBuilding.RentFromReach((float)this.Building.Reach) / hoursPerWeek, "Cash");
			base.GL.Post("Registers", (float)(40 * this.Registers) / hoursPerWeek, "Cash");
			float cameraCount = 0f;
			foreach (bool b in this.Floor.Cameras)
			{
				if (b)
				{
					cameraCount += 1f;
				}
			}
			base.GL.Post("Security Cameras", 25f * cameraCount / hoursPerWeek, "Cash");
			foreach (object obj2 in this.Floor.Sections.Values)
			{
				SectionBase sb = (SectionBase)obj2;
				if (sb.Rent > 0f)
				{
					base.GL.Post(sb.RackType + "s", sb.Rent / hoursPerWeek, "Cash");
				}
			}
			this.SynchUnitCountsOnServiceContracts();
			foreach (object obj3 in this.ServiceContracts.Values)
			{
				ServiceContract sc = (ServiceContract)obj3;
				base.GL.Post(sc.RackType + "s ", (float)(AppConstants.ServiceContractCosts[sc.ResponseTimeIndex] * sc.UnitsCovered) / hoursPerWeek, "Cash");
			}
			foreach (object obj4 in this.Floor.AllShelves)
			{
				Shelf s = (Shelf)obj4;
				if (s.ProductType.FridgeRequired && s.Parent.Broken && (A.ST.Now - s.Parent.DateBroken).Hours > 8)
				{
					foreach (Item item in s.Items)
					{
						if (item != null)
						{
							item.ExpirationDate = DateTime.MinValue;
						}
					}
				}
			}
			if (this.Backroom.CoolingDuct.Broken && (A.ST.Now - this.Backroom.CoolingDuct.DateBroken).Hours > 8)
			{
				this.Backroom.ExpireAll();
			}
			if (!base.AI && A.SS.MachineFailures)
			{
				foreach (object obj5 in new ArrayList(this.Floor.Sections.Values)
				{
					this.Backroom.CoolingDuct
				})
				{
					SectionBase sb = (SectionBase)obj5;
					if ((A.ST.Random.NextDouble() < (double)sb.LikelihoodOfBreakingPerHour || (sb is CoolingDuct && this.BreakCoolerForLesson())) && !sb.Broken)
					{
						sb.Broken = true;
						string description = sb.RackType;
						string msg;
						if (sb is CoolingDuct || sb is Fridge)
						{
							msg = A.R.GetString("Oh, no! Your {0} has broken. Food requiring refrigeration will totally expire in {1} hours.", new object[]
							{
								description,
								8
							});
						}
						else
						{
							msg = A.R.GetString("Oh, no! Your {0} has broken and can't be used until it is repaired.", new object[]
							{
								description
							});
						}
						base.Player.SendMessage(msg, base.Name, NotificationColor.Red);
						this.Log.Comment(A.R.GetString("Stockers"), "", msg);
						ServiceContract sc = (ServiceContract)this.ServiceContracts[sb.GetType()];
						int responseTime = AppConstants.ResponseTimes[sc.ResponseTimeIndex];
						if (responseTime > -1)
						{
							new Repairman(this, sb, responseTime);
						}
					}
				}
			}
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00019C20 File Offset: 0x00018C20
		protected bool BreakCoolerForLesson()
		{
			bool result;
			if (A.SS.CoolerBreakDate < A.ST.Now)
			{
				A.SS.CoolerBreakDate = DateTime.MaxValue;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00019C68 File Offset: 0x00018C68
		public PointF LockCashierLocation(Customer customer)
		{
			for (int i = 0; i < this.Cashiers.Count; i++)
			{
				if (((Cashier)this.Cashiers[i]).LockedBy == null && i < this.Registers)
				{
					((Cashier)this.Cashiers[i]).LockedBy = customer;
					Point p = this.RegisterLocation(i);
					return p;
				}
			}
			return PointF.Empty;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00019CF0 File Offset: 0x00018CF0
		public void UnlockCashier(Customer customer)
		{
			foreach (object obj in this.Cashiers)
			{
				Cashier c = (Cashier)obj;
				if (c.LockedBy == customer)
				{
					c.LockedBy = null;
				}
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00019D64 File Offset: 0x00018D64
		public override bool NewStep()
		{
			MapV2 temp = this.Floor.Map;
			try
			{
			}
			catch (Exception ex)
			{
				this.Floor.Map = temp;
			}
			return false;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00019DAC File Offset: 0x00018DAC
		public override void NewYear()
		{
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00019DB0 File Offset: 0x00018DB0
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00019DC8 File Offset: 0x00018DC8
		public SortedList Loans
		{
			get
			{
				return this.loans;
			}
			set
			{
				this.loans = value;
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00019DD4 File Offset: 0x00018DD4
		public float RadioAdvertisingCost()
		{
			float cost = 0f;
			for (int i = 0; i < this.RadioBookings.GetLength(0); i++)
			{
				for (int j = 0; j < this.RadioBookings.GetLength(1); j++)
				{
					if (this.RadioBookings[i, j])
					{
						cost += (float)A.ST.RadioStations[j].Reach * 20f / 1000f;
					}
				}
			}
			return cost;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00019E64 File Offset: 0x00018E64
		public void CreditReport(ref string[] creditReport, ref int creditRating)
		{
			string[] ratingDescriptions = new string[]
			{
				"Excellent Credit",
				"Good Credit",
				"Moderate Risk",
				"High Risk",
				"Bad Credit"
			};
			creditRating = 1;
			float debt = base.GL.AccountBalance("Debt");
			float equity = base.GL.AccountBalance("Equity");
			float liabilities = base.GL.AccountBalance("Liabilities");
			float liquidAssets = base.GL.AccountBalance("Cash");
			float cashFlow = this.CurrentWeeklyCashFlow;
			string dateStr = A.ST.Now.Date.ToString("MMMM d, yyyy");
			string debtStr = Utilities.FC(debt, A.I.CurrencyConversion);
			string equityStr = Utilities.FC(equity, A.I.CurrencyConversion);
			float debtEquityRatio;
			string debtEquityRatioStr;
			if (equity <= 0f)
			{
				debtEquityRatio = 3f;
				debtEquityRatioStr = "Infinite";
			}
			else
			{
				debtEquityRatio = debt / equity;
				debtEquityRatioStr = debtEquityRatio.ToString("F1");
			}
			string debtEquityRatioEvaluation;
			if (debtEquityRatio > 4f)
			{
				creditRating += 2;
				debtEquityRatioEvaluation = "Very poor";
			}
			else if (debtEquityRatio > 2f)
			{
				creditRating++;
				debtEquityRatioEvaluation = "Poor";
			}
			else
			{
				debtEquityRatioEvaluation = "Good";
			}
			string liquidAssetsStr = Utilities.FC(liquidAssets, A.I.CurrencyConversion);
			string liabilitiesStr = Utilities.FC(liabilities, A.I.CurrencyConversion);
			string cashFlowStr = Utilities.FC(cashFlow, A.I.CurrencyConversion);
			string quickRatioStr;
			string quickRatioEvaluation;
			if (liabilities == 0f)
			{
				quickRatioStr = "Infinite";
				quickRatioEvaluation = "Excellent";
			}
			else
			{
				float quickRatio = liquidAssets / liabilities;
				quickRatioStr = quickRatio.ToString("F1");
				if (quickRatio < 0.5f)
				{
					creditRating++;
					quickRatioEvaluation = "Poor";
				}
				else
				{
					quickRatioEvaluation = "Good";
				}
				quickRatioStr = quickRatio.ToString("F1");
			}
			string cashFlowEvaluation;
			if (cashFlow < 100f)
			{
				cashFlowEvaluation = "Poor";
				creditRating += 2;
			}
			else
			{
				cashFlowEvaluation = "Good";
			}
			creditRating = Math.Min(creditRating, 4);
			string riskEvaluation = ratingDescriptions[creditRating];
			creditReport = (string[])new ArrayList
			{
				"Issued on  " + dateStr,
				"",
				"Loan Sought for Operating Store:  " + base.Name,
				"",
				"Debt:  " + debtStr,
				"Equity:  " + equityStr,
				"Debt to Equity Ratio:  " + debtEquityRatioStr + ":1  " + debtEquityRatioEvaluation,
				"",
				"Liquid Assets:  " + liquidAssetsStr,
				"Current Liabilities:  " + liabilitiesStr,
				"Quick Ratio:  " + quickRatioStr + ":1  " + quickRatioEvaluation,
				"",
				"Cash Flow from Ops(Avg):  " + cashFlowStr + " per week  " + cashFlowEvaluation,
				"",
				"Overall Risk Rating:  " + riskEvaluation
			}.ToArray(typeof(string));
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001CF RID: 463 RVA: 0x0001A1F8 File Offset: 0x000191F8
		private float CurrentWeeklyCashFlow
		{
			get
			{
				int week = A.ST.CurrentWeek;
				float cashFlow = this.CashFlowForWeek(week - 1);
				if (week > 1)
				{
					cashFlow = (cashFlow + this.CashFlowForWeek(week - 2)) / 2f;
				}
				return cashFlow;
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0001A240 File Offset: 0x00019240
		private float CashFlowForWeek(int week)
		{
			float cashFlow = base.GL.AccountBalance("Profit", week);
			cashFlow -= base.GL.AccountBalance("Inventory", week);
			cashFlow += base.GL.AccountBalance("Accounts Payable", week);
			if (week > 0)
			{
				cashFlow += base.GL.AccountBalance("Inventory", week - 1);
				cashFlow -= base.GL.AccountBalance("Accounts Payable", week - 1);
			}
			return cashFlow;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x0001A2C8 File Offset: 0x000192C8
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x0001A2E0 File Offset: 0x000192E0
		public int MailingFrequency
		{
			get
			{
				return this.mailingFrequency;
			}
			set
			{
				this.mailingFrequency = value;
				this.mailingStartOffset = (A.ST.Now - A.SS.StartDate).Days;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x0001A31C File Offset: 0x0001931C
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x0001A334 File Offset: 0x00019334
		public int PhysicalInventoryFrequency
		{
			get
			{
				return this.physicalInventoryFrequency;
			}
			set
			{
				this.physicalInventoryFrequency = value;
				this.physicalInventoryStartOffset = A.ST.CurrentWeek;
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0001A350 File Offset: 0x00019350
		protected void ConductPhysicalInventory()
		{
			string msg = "";
			int[] missing = new int[25];
			for (int i = 0; i < missing.Length; i++)
			{
				ProductType p = AppConstants.ProductTypes[i];
				int inventory = (int)base.GL.AccountBalance("Inventory - " + p.Name + " (units)");
				int physicalCount = this.Backroom.GetUnitCount(p) + this.Floor.GetUnitCount(p);
				missing[i] = inventory - physicalCount * 20;
				if (missing[i] > 0)
				{
					base.GL.Post("Stolen Goods", (float)missing[i] * p.Cost, "Inventory", p.Name, missing[i], new string[]
					{
						"Stolen Goods"
					}, new string[]
					{
						"Inventory"
					});
					string text = msg;
					msg = string.Concat(new string[]
					{
						text,
						missing[i].ToString(),
						" units of ",
						p.Name,
						", "
					});
				}
			}
			NotificationColor color = NotificationColor.Yellow;
			if (msg != "")
			{
				msg = Utilities.FormatCommaSeries(msg);
				msg = A.R.GetString("Your recent physical inventory found that you are missing {0}. The probable cause is shoplifting! The cost of the physical inventory was {1}.", new object[]
				{
					msg,
					Utilities.FC(250f, A.I.CurrencyConversion)
				});
			}
			else
			{
				msg = A.R.GetString("Your recent physical inventory found nothing missing! The cost of the physical inventory was {0}.", new object[]
				{
					Utilities.FC(250f, A.I.CurrencyConversion)
				});
				color = NotificationColor.Green;
			}
			base.Player.SendMessage(msg, base.Name, color);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0001A528 File Offset: 0x00019528
		public Drawable GetDrawableScoreSign(int centerAvenue, int centerStreet)
		{
			return new ScoreSignDrawable(((AppBuilding)this.Building).ScreenLoc(centerAvenue, centerStreet), null, base.ID, base.Name, this.SignColor, base.Journal.NumericDataSeriesLastEntry(Journal.ScoreSeriesName), true);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0001A578 File Offset: 0x00019578
		public Drawable GetDrawableScoreSign()
		{
			return new ScoreSignDrawable(((AppBuilding)this.Building).ScreenLocWholeCity, null, base.ID, base.Name, this.SignColor, base.Journal.NumericDataSeriesLastEntry(Journal.ScoreSeriesName), false);
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x0001A5C4 File Offset: 0x000195C4
		public bool Open
		{
			get
			{
				return this.Cashiers.Count > 0;
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0001A5E4 File Offset: 0x000195E4
		public float BillboardRent()
		{
			float total = 0f;
			foreach (object obj in this.BillboardBuildings)
			{
				Building b = (Building)obj;
				total += AppBuilding.BillboardRentFromReach((float)b.Reach);
			}
			return total;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0001A664 File Offset: 0x00019664
		public int SignColorIndex
		{
			get
			{
				for (int i = 0; i < AppConstants.StoreSignColors.Length; i++)
				{
					if (AppConstants.StoreSignColors[i] == this.SignColor)
					{
						return i;
					}
				}
				return -1;
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0001A6B4 File Offset: 0x000196B4
		public virtual void ExecuteMailing(MailingList list)
		{
			this.MostRecentlyUsedMailingList = list;
			int reach = list.RecipientIDs.Count * 20 * 5;
			float amount = (float)reach * 450f / 1000f;
			base.GL.Post("Direct Mail", amount, "Cash");
			this.DiscountExpiration = A.ST.Now.AddDays(7.0);
			foreach (object obj in list.RecipientIDs)
			{
				long ID = (long)obj;
				Customer customer = (Customer)A.ST.Customers[ID];
				if (customer != null)
				{
					customer.ReceiveMail(this);
				}
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0001A7AC File Offset: 0x000197AC
		public float WeeklyWages()
		{
			float total = 0f;
			int[,] schedule = this.Schedule;
			int upperBound = schedule.GetUpperBound(0);
			int upperBound2 = schedule.GetUpperBound(1);
			for (int j = schedule.GetLowerBound(0); j <= upperBound; j++)
			{
				for (int k = schedule.GetLowerBound(1); k <= upperBound2; k++)
				{
					int i = schedule[j, k];
					total += AppConstants.WageRate * (float)i * 4f * 7f;
				}
			}
			return total;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0001A844 File Offset: 0x00019844
		public override void Retire()
		{
			base.Retire();
			foreach (object obj in this.BillboardBuildings)
			{
				AppBuilding b = (AppBuilding)obj;
				b.BillboardOwner = null;
			}
			this.Building.Owner = null;
			foreach (object obj2 in this.ShelfStockers)
			{
				ShelfStocker ss = (ShelfStocker)obj2;
				ss.Retire();
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0001A918 File Offset: 0x00019918
		public Point RegisterLocation(int index)
		{
			Point c0 = this.Floor.Map.getNode("C0").Location;
			int spacing = (this.Floor.Map.getNode("C1").Location.X - c0.X) / (this.Registers + 1);
			Point p;
			if (index < this.Registers)
			{
				p = new Point(c0.X + 60 + (index + 1) * spacing, c0.Y - 20 + (index + 1) * spacing / 2);
			}
			else
			{
				p = this.Floor.Map.getNode("CashierIdle").DistributedLocation;
			}
			return p;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0001A9D8 File Offset: 0x000199D8
		public void SynchUnitCountsOnServiceContracts()
		{
			foreach (object obj in this.ServiceContracts.Values)
			{
				ServiceContract sc = (ServiceContract)obj;
				if (sc.RackType == "Backroom Cooling Duct")
				{
					sc.UnitsCovered = 1;
				}
				else
				{
					sc.UnitsCovered = 0;
				}
			}
			foreach (object obj2 in this.Floor.Sections.Values)
			{
				SectionBase sb = (SectionBase)obj2;
				Type key = sb.GetType();
				if (this.ServiceContracts.ContainsKey(key))
				{
					((ServiceContract)this.ServiceContracts[key]).UnitsCovered++;
				}
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0001AB04 File Offset: 0x00019B04
		public void ImmediateRepair(string rackType)
		{
			foreach (object obj in new ArrayList(this.Floor.Sections.Values)
			{
				this.Backroom.CoolingDuct
			})
			{
				SectionBase sb = (SectionBase)obj;
				if (sb.Broken && sb.RackType == rackType)
				{
					new Repairman(this, sb, 0);
					base.GL.Post("Immediate Repairs", (float)(AppConstants.ServiceContractCosts[1] * 12), "Cash");
				}
			}
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0001ABD4 File Offset: 0x00019BD4
		public bool SecurityCameraOn(string nodeName)
		{
			int section = int.Parse(nodeName.Substring(1));
			return this.Floor.Cameras[AppConstants.CameraOn[section]];
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0001AC08 File Offset: 0x00019C08
		protected bool SomeShelfSpaceFor(int prod)
		{
			foreach (object obj in this.Floor.AllShelves)
			{
				Shelf s = (Shelf)obj;
				if (s.ProductType.Index == prod)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0001AC8C File Offset: 0x00019C8C
		public ConsultantReport CreateConsultantReport()
		{
			ConsultantReport r = new ConsultantReport(this);
			r.Date = A.ST.Now;
			if ((A.ST.Now - this.Founded).Days < 21)
			{
				throw new SimApplicationException(A.R.GetString("The consultant needs a few weeks to analyze your store. Please try back again in 3 weeks. You were not billed for services."));
			}
			bool flag = !A.SS.LevelManagementOn || A.SS.Level != 0;
			float cc = A.I.CurrencyConversion;
			ConsultantReportSection s = new ConsultantReportSection();
			s.Topic = "Location";
			float myLocAppeal = 0f;
			foreach (object obj in A.ST.Customers.Values)
			{
				Customer c = (Customer)obj;
				myLocAppeal += c.AppealOfLocation(this.Building);
			}
			int totalLocs = 0;
			int betterThanLocs = 0;
			ArrayList buildings = A.ST.OurCity.GetBuildings();
			foreach (object obj2 in buildings)
			{
				AppBuilding b = (AppBuilding)obj2;
				if (b.BuildingType.Index == 0)
				{
					float appeal = 0f;
					foreach (object obj3 in A.ST.Customers.Values)
					{
						Customer c = (Customer)obj3;
						appeal += c.AppealOfLocation(b);
					}
					if (appeal < myLocAppeal)
					{
						betterThanLocs++;
					}
					totalLocs++;
				}
			}
			float pctImBetterThan = (float)betterThanLocs / (float)totalLocs;
			float myRent = AppBuilding.RentFromReach((float)this.Building.Reach);
			float avgRent = 0f;
			foreach (object obj4 in buildings)
			{
				AppBuilding b = (AppBuilding)obj4;
				avgRent += AppBuilding.RentFromReach((float)b.Reach);
			}
			avgRent /= (float)totalLocs;
			ConsultantReportSection consultantReportSection = s;
			consultantReportSection.Finding += "I talked with customers all over town and asked them about possible store locations. ";
			ConsultantReportSection consultantReportSection2 = s;
			consultantReportSection2.Finding = consultantReportSection2.Finding + "Your location was viewed as more convenient than " + Utilities.FP(pctImBetterThan) + " of all possible locations. ";
			ConsultantReportSection consultantReportSection3 = s;
			consultantReportSection3.Finding = consultantReportSection3.Finding + "That's " + this.GoodBadRatio(pctImBetterThan * 2f) + ". ";
			ConsultantReportSection consultantReportSection4 = s;
			consultantReportSection4.Finding = consultantReportSection4.Finding + "After checking around, I calculate that your rent is about " + this.PercentHigherLower(myRent / avgRent) + " than the average for all possible locations.";
			if (myRent / avgRent > 1f)
			{
				if (pctImBetterThan > 0.5f)
				{
					ConsultantReportSection consultantReportSection5 = s;
					consultantReportSection5.Finding += "You've got a nice location, but you're paying for it. Given the high rent, you better drive high customer volume at this store. ";
					s.Grade = 0.85f;
				}
				else
				{
					ConsultantReportSection consultantReportSection6 = s;
					consultantReportSection6.Finding += "Your location isn't that convenient, and the rent is a bit high. That's not a very good location. ";
					ConsultantReportSection consultantReportSection7 = s;
					consultantReportSection7.Finding += "I'd consider moving to a better location. ";
					s.Grade = 0.65f;
				}
			}
			else if (pctImBetterThan > 0.5f)
			{
				ConsultantReportSection consultantReportSection8 = s;
				consultantReportSection8.Finding += "You've got a location that people like with relatively low rent. Hold onto it!";
				s.Grade = 0.95f;
			}
			else
			{
				ConsultantReportSection consultantReportSection9 = s;
				consultantReportSection9.Finding += "You're location isn't that convenient, but the price is right. Stay here only if you can find away to attract customers. ";
				s.Grade = 0.75f;
			}
			r.AddSection(s);
			s = new ConsultantReportSection();
			s.Topic = "Promotion - Overall";
			float myAppeal = 0f;
			float radioAppeal = 0f;
			float billboardsAppeal = 0f;
			float mailAppeal = 0f;
			int walkersBy = 0;
			int turnersIn = 0;
			int aware = 0;
			foreach (object obj5 in A.ST.Customers.Values)
			{
				Customer c = (Customer)obj5;
				if (c.Aware(base.ID))
				{
					myAppeal += c.ImpressionImpact(base.ID);
					radioAppeal += c.ImpressionImpact(base.ID, "Radio");
					billboardsAppeal += c.ImpressionImpact(base.ID, "Billboards");
					mailAppeal += c.ImpressionImpact(base.ID, "Direct Mail");
					aware++;
				}
				if (c.EntityWalkedBy() == this)
				{
					foreach (AdSimple ad in this.Floor.Ads)
					{
						if (ad != null && c.AppealOfAd(this, ad) > 0.75f)
						{
							turnersIn++;
							break;
						}
					}
					walkersBy++;
				}
			}
			float pctAware = (float)aware / (float)Math.Max(A.ST.Customers.Count, 1);
			myAppeal /= (float)Math.Max(aware, 1);
			radioAppeal /= (float)Math.Max(aware, 1);
			billboardsAppeal /= (float)Math.Max(aware, 1);
			mailAppeal /= (float)Math.Max(aware, 1);
			float storefrontAdsAppeal = (float)turnersIn / (float)Math.Max(1, walkersBy);
			s.Finding = "I checked into the overall effectiveness of your promotion/advertising. ";
			ConsultantReportSection consultantReportSection10 = s;
			consultantReportSection10.Finding = consultantReportSection10.Finding + "I found that " + Utilities.FP(pctAware) + " of potential customers were aware of your store. ";
			ConsultantReportSection consultantReportSection11 = s;
			consultantReportSection11.Finding = consultantReportSection11.Finding + "To me, that is " + this.GoodBadRatio(pctAware * 2.5f) + ". ";
			ConsultantReportSection consultantReportSection12 = s;
			consultantReportSection12.Finding += "I also asked customers if your advertising was attractive enough to make them go out of their way to your store. ";
			ConsultantReportSection consultantReportSection13 = s;
			consultantReportSection13.Finding = consultantReportSection13.Finding + "On average, they said they would go an extra " + Utilities.FU((int)(0.5f + myAppeal)) + " blocks out of their way based on the appeal of your advertising. ";
			ConsultantReportSection consultantReportSection14 = s;
			consultantReportSection14.Finding = consultantReportSection14.Finding + "Based on my experience, that is " + this.GoodBadRatio(myAppeal / 3f) + ". ";
			s.Grade = (this.GradeRatio(pctAware * 2.5f) + this.GradeRatio(myAppeal / 3f)) / 2f;
			r.AddSection(s);
			s = new ConsultantReportSection();
			s.Topic = "Promotion - Specifics";
			s.Grade = 0f;
			if ((double)pctAware < 0.1)
			{
				s.Finding = "So few customers are aware of your store, that I can't comment on the effectiveness of any specific promotions. ";
				s.Grade = 0.601f;
			}
			else
			{
				s.Finding = "I also asked customers about the specific elements of your promotional mix. ";
				string opinion = this.BillboardRadioOpinion(radioAppeal);
				s.Grade += this.GradeBasedOnOpinion(opinion);
				if (opinion == "unappealing")
				{
					ConsultantReportSection consultantReportSection15 = s;
					consultantReportSection15.Finding += "It doesn't look like you're doing any radio advertising. You should probably try some. ";
				}
				else
				{
					ConsultantReportSection consultantReportSection16 = s;
					consultantReportSection16.Finding = consultantReportSection16.Finding + "On average, those aware of your store found your radio ads to be " + opinion + ". ";
					if (opinion != "appealing")
					{
						ConsultantReportSection consultantReportSection17 = s;
						consultantReportSection17.Finding += "You may want to boost spending on radio or retarget dollars to better match the listening times of station audiences. ";
					}
					else
					{
						ConsultantReportSection consultantReportSection18 = s;
						consultantReportSection18.Finding += "Good work! ";
					}
				}
				opinion = this.BillboardRadioOpinion(billboardsAppeal);
				s.Grade += this.GradeBasedOnOpinion(opinion);
				if (opinion == "unappealing")
				{
					ConsultantReportSection consultantReportSection19 = s;
					consultantReportSection19.Finding += "You should try some billboards. They can help you reach customers who don't necessarily go by your store. ";
				}
				else
				{
					ConsultantReportSection consultantReportSection20 = s;
					consultantReportSection20.Finding = consultantReportSection20.Finding + "Customers found your billboards to be " + opinion + ". ";
					if (opinion != "appealing")
					{
						ConsultantReportSection consultantReportSection21 = s;
						consultantReportSection21.Finding += "You may want to put up more billboards at the busier intersections in town. ";
					}
					else
					{
						ConsultantReportSection consultantReportSection22 = s;
						consultantReportSection22.Finding += "Your OK here.! ";
					}
				}
				opinion = this.MailStorefrontOpinion(mailAppeal);
				s.Grade += this.GradeBasedOnOpinion(opinion);
				if (opinion == "unappealing")
				{
					ConsultantReportSection consultantReportSection23 = s;
					consultantReportSection23.Finding += "Try some direct mail. It can be one of your most powerful and targeted advertising tools. ";
				}
				else
				{
					ConsultantReportSection consultantReportSection24 = s;
					consultantReportSection24.Finding = consultantReportSection24.Finding + "Your recent mailings were thought by customers to be " + opinion + ". ";
					if (opinion != "very appealing")
					{
						ConsultantReportSection consultantReportSection25 = s;
						consultantReportSection25.Finding += "I recommend including coupons with good discounts on things people really need. That should get you up to a very appealing rating. ";
					}
					else
					{
						ConsultantReportSection consultantReportSection26 = s;
						consultantReportSection26.Finding += "Keep up the strong mailings. ";
					}
				}
				opinion = this.GoodBadRatio(storefrontAdsAppeal * 2f);
				s.Grade += this.GradeRatio(storefrontAdsAppeal * 2f);
				ConsultantReportSection consultantReportSection27 = s;
				consultantReportSection27.Finding += A.R.GetString("I checked with some customers walking by your store and {0} said your storefront signs would cause them to come in. In my opinion that's {1}. ", new object[]
				{
					Utilities.FP(storefrontAdsAppeal),
					opinion
				});
				if (opinion != "really good")
				{
					ConsultantReportSection consultantReportSection28 = s;
					consultantReportSection28.Finding += A.R.GetString("Post more ads or alter existing ads to get the greatest appeal. Concentrate on products customers need, advertised at good prices.");
				}
				s.Grade /= 4f;
			}
			r.AddSection(s);
			float totalRevenue = 0f;
			for (int i = 0; i < 3; i++)
			{
				totalRevenue += base.GL.AccountBalance("Revenue", A.ST.CurrentWeek - 1 - i);
			}
			totalRevenue /= 3f;
			if (totalRevenue == 0f)
			{
				totalRevenue = 0.4f;
			}
			ArrayList impulseList = new ArrayList();
			ArrayList needsList = new ArrayList();
			float totalAmount = 0f;
			float needsAmt = 0f;
			float impulseAmt = 0f;
			float amt;
			foreach (VBRProductType prod in AppConstants.ProductTypes)
			{
				amt = 0f;
				for (int i = 0; i < 3; i++)
				{
					amt += base.GL.AccountBalance("Sales Lost Due To Availability - " + prod.Name, A.ST.CurrentWeek - 1 - i);
				}
				amt /= 3f;
				if (prod.IsImpulseItem)
				{
					impulseList.Add(new AmountNamePair(amt, prod.Name));
					impulseAmt += amt;
				}
				else
				{
					needsList.Add(new AmountNamePair(amt, prod.Name));
					needsAmt += amt;
				}
				totalAmount += amt;
			}
			AmountNamePair[] impulseArray = (AmountNamePair[])impulseList.ToArray(typeof(AmountNamePair));
			AmountNamePair[] needsArray = (AmountNamePair[])needsList.ToArray(typeof(AmountNamePair));
			Array.Sort(impulseArray, new ValueComparer());
			Array.Sort(needsArray, new ValueComparer());
			s = new ConsultantReportSection();
			s.Topic = "Product Availability";
			if (totalRevenue < 1000f)
			{
				s.Finding = "At this point your customer traffic & revenue are so low that I can't even rate you on what products customers might be demanding. Work on building some customer traffic first.";
				s.Grade = 0.65f;
			}
			else
			{
				s.Finding = "I have observed your shelves and talked with customers leaving your store. I estimate that over the last several weeks, you lost around " + Utilities.FC(needsAmt * 3f, cc) + " in potential sales because customers could not find products they were seeking. ";
				ConsultantReportSection consultantReportSection29 = s;
				string finding = consultantReportSection29.Finding;
				consultantReportSection29.Finding = string.Concat(new string[]
				{
					finding,
					"That's ",
					Utilities.FP(needsAmt / totalRevenue),
					" of your actual total sales for the same period. That's ",
					this.GoodBadAsPctOfRevenue(needsAmt / totalRevenue),
					". "
				});
				s.Grade = this.GradeAsPctOfRevenue(needsAmt / totalRevenue);
				if ((double)s.Grade > 0.9)
				{
					ConsultantReportSection consultantReportSection30 = s;
					consultantReportSection30.Finding += "No action necessary on product availability.";
				}
				else
				{
					ConsultantReportSection consultantReportSection31 = s;
					consultantReportSection31.Finding += "The main products that customers can't find are ";
					string prodsList = "";
					for (int i = 0; i < 3; i++)
					{
						if (needsArray[i].Amount > 0f)
						{
							prodsList = prodsList + needsArray[i].Name + ", ";
						}
					}
					ConsultantReportSection consultantReportSection32 = s;
					consultantReportSection32.Finding = consultantReportSection32.Finding + Utilities.FormatCommaSeries(prodsList) + ". ";
					ConsultantReportSection consultantReportSection33 = s;
					consultantReportSection33.Finding += "First, make sure that you have at least one shelf allocated to each of these products, then check that you have enough stockers working to keep the shelves stocked. ";
					ConsultantReportSection consultantReportSection34 = s;
					consultantReportSection34.Finding += "Finally, look in the backroom to be sure that you are not out of stock on any of these items.";
				}
			}
			r.AddSection(s);
			s = new ConsultantReportSection();
			s.Topic = "Merchandising";
			if (totalRevenue < 1000f)
			{
				s.Finding = "At this point your customer traffic & revenue are so low that I can't even rate you on what impulse products customers might buy with better merchandising. Work on building some customer traffic first.";
				s.Grade = 0.65f;
			}
			else
			{
				s.Finding = "Good merchandising involves arranging products so that customers walk by \"impulse\" items on their way to purchase things they really need. ";
				ConsultantReportSection consultantReportSection35 = s;
				consultantReportSection35.Finding = consultantReportSection35.Finding + "I've observed traffic patterns in your store and estimate that customers might purchase " + Utilities.FC(impulseAmt, cc) + " per week more of certain products if the store were arranged differently. ";
				ConsultantReportSection consultantReportSection36 = s;
				string finding = consultantReportSection36.Finding;
				consultantReportSection36.Finding = string.Concat(new string[]
				{
					finding,
					"Given your average weekly revenue of ",
					Utilities.FC(totalRevenue, cc),
					", that means your merchandising is ",
					this.GoodBadAsPctOfRevenue(impulseAmt / totalRevenue),
					". "
				});
				s.Grade = this.GradeAsPctOfRevenue(impulseAmt / totalRevenue);
				if ((double)s.Grade > 0.9)
				{
					ConsultantReportSection consultantReportSection37 = s;
					consultantReportSection37.Finding += "I'd leave your arrangement pretty much the same.";
				}
				else
				{
					ConsultantReportSection consultantReportSection38 = s;
					consultantReportSection38.Finding += "Products they might buy more of include ";
					string prodsList = "";
					for (int i = 0; i < 3; i++)
					{
						if (impulseArray[i].Amount > 0f)
						{
							prodsList = prodsList + impulseArray[i].Name + ", ";
						}
					}
					ConsultantReportSection consultantReportSection39 = s;
					consultantReportSection39.Finding = consultantReportSection39.Finding + Utilities.FormatCommaSeries(prodsList) + ". ";
					ConsultantReportSection consultantReportSection40 = s;
					consultantReportSection40.Finding += "First, make sure there is some shelf space allocated to these products.";
					ConsultantReportSection consultantReportSection41 = s;
					consultantReportSection41.Finding += "Then try arranging shelves so customers must walk by these products to get to needs like milk and cereal.";
				}
			}
			r.AddSection(s);
			amt = 0f;
			for (int i = 0; i < 3; i++)
			{
				amt += base.GL.AccountBalance("Sales Lost Due To Expired Goods", A.ST.CurrentWeek - 1 - i);
			}
			amt /= 3f;
			ArrayList expiredList = new ArrayList();
			totalAmount = 0f;
			foreach (VBRProductType prod2 in AppConstants.ProductTypes)
			{
				amt = 0f;
				for (int i = 0; i < 3; i++)
				{
					amt += base.GL.AccountBalance("Expired Goods - " + prod2.Name, A.ST.CurrentWeek - 1 - i);
				}
				amt /= 3f;
				expiredList.Add(new AmountNamePair(amt, prod2.Name));
				totalAmount += amt;
			}
			AmountNamePair[] expiredArray = (AmountNamePair[])expiredList.ToArray(typeof(AmountNamePair));
			Array.Sort(expiredArray, new ValueComparer());
			s = new ConsultantReportSection();
			s.Topic = "Expired Goods";
			s.Finding = "I checked your product records for goods that are expiring. I found that over the last several weeks, you had to throw out " + Utilities.FC(totalAmount * 3f, cc) + " worth of expired goods.";
			ConsultantReportSection consultantReportSection42 = s;
			consultantReportSection42.Finding = consultantReportSection42.Finding + "That comes to " + Utilities.FP(totalAmount / totalRevenue, 1) + " of total revenue. ";
			ConsultantReportSection consultantReportSection43 = s;
			consultantReportSection43.Finding = consultantReportSection43.Finding + "I'd call that " + this.GoodBadAsPctOfRevenue(totalAmount / totalRevenue) + ". ";
			s.Grade = this.GradeAsPctOfRevenue(totalAmount / totalRevenue);
			if ((double)s.Grade > 0.9)
			{
				ConsultantReportSection consultantReportSection44 = s;
				consultantReportSection44.Finding += "There's no pressing need to make adjustments now.";
			}
			else
			{
				ConsultantReportSection consultantReportSection45 = s;
				consultantReportSection45.Finding += "The products with the highest loss due to expiration are ";
				string prodsList = "";
				for (int i = 0; i < 3; i++)
				{
					if (expiredArray[i].Amount > 0f)
					{
						prodsList = prodsList + expiredArray[i].Name + ", ";
					}
				}
				ConsultantReportSection consultantReportSection46 = s;
				consultantReportSection46.Finding = consultantReportSection46.Finding + Utilities.FormatCommaSeries(prodsList) + ". ";
				ConsultantReportSection consultantReportSection47 = s;
				consultantReportSection47.Finding += "You should try purchasing less of these products and setting a lower reorder point. ";
				ConsultantReportSection consultantReportSection48 = s;
				consultantReportSection48.Finding += "You may also want to try these products on different shelves to see if they sell better there. ";
			}
			r.AddSection(s);
			amt = 0f;
			for (int i = 0; i < 3; i++)
			{
				amt += base.GL.AccountBalance("Sales Lost Due To Long Wait", A.ST.CurrentWeek - 1 - i);
			}
			amt /= 3f;
			s = new ConsultantReportSection();
			s.Topic = "Customer Wait Times";
			if (totalRevenue < 1000f)
			{
				s.Finding = "At this point your customer traffic & revenue are so low that analyzing customer wait times is not meaningful. Work on building some customer traffic first.";
				s.Grade = 0.65f;
			}
			else
			{
				s.Finding = "Customers won't wait in line forever. If the wait gets too long, they will leave in frustration. ";
				ConsultantReportSection consultantReportSection49 = s;
				consultantReportSection49.Finding += "That means you'll lose all the revenue from the products they would have bought. ";
				ConsultantReportSection consultantReportSection50 = s;
				consultantReportSection50.Finding = consultantReportSection50.Finding + "Based on my observations, you are losing about " + Utilities.FC(amt, cc) + " per week because of long lines. ";
				ConsultantReportSection consultantReportSection51 = s;
				string finding = consultantReportSection51.Finding;
				consultantReportSection51.Finding = string.Concat(new string[]
				{
					finding,
					"At ",
					Utilities.FP(amt / totalRevenue),
					" of total revenue, that is ",
					this.GoodBadAsPctOfRevenue(amt / totalRevenue),
					". "
				});
				s.Grade = this.GradeAsPctOfRevenue(amt / totalRevenue);
				if ((double)s.Grade > 0.9)
				{
					ConsultantReportSection consultantReportSection52 = s;
					consultantReportSection52.Finding += "I wouldn't change your staffing at this time.";
				}
				else
				{
					ConsultantReportSection consultantReportSection53 = s;
					consultantReportSection53.Finding += "You should try adding more cashiers and/or registers at busy times. ";
				}
			}
			r.AddSection(s);
			ArrayList priceList = new ArrayList();
			totalAmount = 0f;
			foreach (VBRProductType prod2 in AppConstants.ProductTypes)
			{
				amt = 0f;
				for (int i = 0; i < 3; i++)
				{
					amt += base.GL.AccountBalance("Sales Lost Due To Price - " + prod2.Name, A.ST.CurrentWeek - 1 - i);
				}
				amt /= 3f;
				priceList.Add(new AmountNamePair(amt, prod2.Name));
				totalAmount += amt;
			}
			AmountNamePair[] priceArray = (AmountNamePair[])priceList.ToArray(typeof(AmountNamePair));
			Array.Sort(priceArray, new ValueComparer());
			s = new ConsultantReportSection();
			s.Topic = "Attractiveness of Prices";
			s.Finding = "Attractive pricing can cause customers to buy extra of an item. Unattractive prices may keep them from buying an item. ";
			ConsultantReportSection consultantReportSection54 = s;
			consultantReportSection54.Finding += "I talked to some of your customers and found that on average your prices caused them to buy ";
			s.Grade = Utilities.Clamp(0.85f + -totalAmount / totalRevenue);
			if (totalAmount < 0f)
			{
				ConsultantReportSection consultantReportSection55 = s;
				consultantReportSection55.Finding = consultantReportSection55.Finding + Utilities.FC(-totalAmount, cc) + " more ";
			}
			else if (totalAmount > 0f)
			{
				ConsultantReportSection consultantReportSection56 = s;
				consultantReportSection56.Finding = consultantReportSection56.Finding + Utilities.FC(totalAmount, cc) + " less ";
			}
			else
			{
				ConsultantReportSection consultantReportSection57 = s;
				consultantReportSection57.Finding += "no more or no less ";
			}
			ConsultantReportSection consultantReportSection58 = s;
			consultantReportSection58.Finding += "goods per week than they otherwise would have. ";
			if (priceArray[0].Amount > 0f)
			{
				ConsultantReportSection consultantReportSection59 = s;
				consultantReportSection59.Finding += "Items they bought less of due to price include ";
				string prodsList = "";
				for (int i = 0; i < 3; i++)
				{
					if (priceArray[i].Amount > 0f)
					{
						prodsList = prodsList + priceArray[i].Name + ", ";
					}
				}
				ConsultantReportSection consultantReportSection60 = s;
				consultantReportSection60.Finding = consultantReportSection60.Finding + Utilities.FormatCommaSeries(prodsList) + ". ";
			}
			if (priceArray[priceArray.Length - 1].Amount < 0f)
			{
				ConsultantReportSection consultantReportSection61 = s;
				consultantReportSection61.Finding += "Items they bought more of due to price include ";
				string prodsList = "";
				for (int i = 0; i < 3; i++)
				{
					if (priceArray[priceArray.Length - 1 - i].Amount < 0f)
					{
						prodsList = prodsList + priceArray[priceArray.Length - 1 - i].Name + ", ";
					}
				}
				ConsultantReportSection consultantReportSection62 = s;
				consultantReportSection62.Finding = consultantReportSection62.Finding + Utilities.FormatCommaSeries(prodsList) + ". ";
			}
			if ((double)s.Grade > 0.9)
			{
				ConsultantReportSection consultantReportSection63 = s;
				consultantReportSection63.Finding += "Your prices are very attractive. Just MAKE SURE THAT YOUR MARGINS ARE HIGH ENOUGH to make money. ";
			}
			else if ((double)s.Grade > 0.83)
			{
				ConsultantReportSection consultantReportSection64 = s;
				consultantReportSection64.Finding += "Your prices are acceptable to customers. I don't see any immediate need for change. ";
			}
			else
			{
				ConsultantReportSection consultantReportSection65 = s;
				consultantReportSection65.Finding += "Your prices are, on average, unattractive. You may want to consider lowering them to stimulate demand. ";
			}
			r.AddSection(s);
			s = new ConsultantReportSection();
			s.Topic = "Risk Management";
			int missing = 0;
			foreach (VBRProductType p in AppConstants.ProductTypes)
			{
				int inventory = (int)base.GL.AccountBalance("Inventory - " + p.Name + " (units)");
				int physicalCount = this.Backroom.GetUnitCount(p) + this.Floor.GetUnitCount(p);
				missing += inventory - physicalCount * 20;
			}
			ConsultantReportSection consultantReportSection66 = s;
			consultantReportSection66.Finding += A.R.GetString("I took a look around your shelves and backroom. It looks to me like ");
			if (missing == 0)
			{
				ConsultantReportSection consultantReportSection67 = s;
				consultantReportSection67.Finding += A.R.GetString("you're not missing any items since your last physical inventory. Excellent loss prevention. Keep it up. ");
				s.Grade = 0.95f;
			}
			else
			{
				float normalStock = 500f;
				float pctMissing = (float)missing / normalStock;
				float goodBad = 1f / (pctMissing / 0.1f);
				ConsultantReportSection consultantReportSection68 = s;
				consultantReportSection68.Finding += A.R.GetString("your missing {0} units that have probably been stolen. ", new object[]
				{
					missing
				});
				ConsultantReportSection consultantReportSection69 = s;
				consultantReportSection69.Finding += A.R.GetString("I consider that {0}. ", new object[]
				{
					this.GoodBadRatio(goodBad)
				});
				if (goodBad <= 1f)
				{
					ConsultantReportSection consultantReportSection70 = s;
					consultantReportSection70.Finding += A.R.GetString("You may want to consider additional security cameras and putting high theft items behind the counter. ");
					if (this.PhysicalInventoryFrequency == 0 || this.PhysicalInventoryFrequency > 4)
					{
						ConsultantReportSection consultantReportSection71 = s;
						consultantReportSection71.Finding += A.R.GetString("You may also want to conduct physical inventories more frequently to identify products being shoplifte. ");
					}
				}
				s.Grade = this.GradeRatio(goodBad);
			}
			string unservicedMachines = "";
			int count = 0;
			foreach (object obj6 in new ArrayList(this.Floor.Sections.Values)
			{
				this.Backroom.CoolingDuct
			})
			{
				SectionBase sb = (SectionBase)obj6;
				if (sb != null && sb.LikelihoodOfBreakingPerHour > 0f && ((ServiceContract)this.ServiceContracts[sb.GetType()]).ResponseTimeIndex == 0 && unservicedMachines.IndexOf(sb.RackType) == -1)
				{
					unservicedMachines = unservicedMachines + sb.RackType + "s, ";
					count++;
				}
			}
			ConsultantReportSection consultantReportSection72 = s;
			consultantReportSection72.Finding += A.R.GetString("I also reviewed your service contracts. It looks like you ");
			if (count == 0)
			{
				ConsultantReportSection consultantReportSection73 = s;
				consultantReportSection73.Finding += A.R.GetString("have service contracts on all machines that can break. I think that's a good idea.");
				s.Grade += 0.95f;
			}
			else
			{
				ConsultantReportSection consultantReportSection74 = s;
				consultantReportSection74.Finding += A.R.GetString("are missing service contracts on {0}. Consider adding them.", new object[]
				{
					Utilities.FormatCommaSeries(unservicedMachines)
				});
				s.Grade += 0.95f - (float)count * 0.05f;
			}
			s.Grade /= 2f;
			r.AddSection(s);
			s = new ConsultantReportSection();
			s.Topic = "Financing";
			float deltaCash = base.GL.AccountBalance("Cash", A.ST.CurrentWeek - 1) - base.GL.AccountBalance("Cash", A.ST.CurrentWeek - 3);
			float deltaDebt = base.GL.AccountBalance("Debt", A.ST.CurrentWeek - 1) - base.GL.AccountBalance("Debt", A.ST.CurrentWeek - 3);
			float cashFromOps = (deltaCash - deltaDebt) / 2f;
			ConsultantReportSection consultantReportSection75 = s;
			consultantReportSection75.Finding += "I reviewed your cash flow from operations over the last several weeks. ";
			if (cashFromOps >= 0f)
			{
				ConsultantReportSection consultantReportSection76 = s;
				consultantReportSection76.Finding += "Congratulations! You are generating cash. This means that you have no immediate need to borrow money. Keep up the good work. ";
				s.Grade = 0.95f;
			}
			else
			{
				int weeksToNoCash = (int)(base.GL.AccountBalance("Cash") / -cashFromOps);
				ConsultantReportSection consultantReportSection77 = s;
				consultantReportSection77.Finding = consultantReportSection77.Finding + "You are burning through cash at a rate of " + Utilities.FC(-cashFromOps, cc) + " per week. ";
				ConsultantReportSection consultantReportSection78 = s;
				consultantReportSection78.Finding = consultantReportSection78.Finding + "At this rate, you will run out of cash in " + Utilities.FU(weeksToNoCash) + " weeks. You have ";
				if (weeksToNoCash < 5)
				{
					ConsultantReportSection consultantReportSection79 = s;
					consultantReportSection79.Finding += "very little time! Cut expenses where possible. Pay your supplier as late as possible. Try to get a loan from the bank. Act now! Loan terms will only get worse in the future.";
				}
				else if (weeksToNoCash < 13)
				{
					ConsultantReportSection consultantReportSection80 = s;
					consultantReportSection80.Finding += "breathing room but not much more. Consider cutting expenses to boost profitability. If you haven't already, check the trade credit offered to you by your suppliers and consider paying them later. Be thinking about borrowing money in the near future. ";
				}
				else
				{
					ConsultantReportSection consultantReportSection81 = s;
					consultantReportSection81.Finding += "quite a bit of time. You should act quickly to make your operations more profitable, but you don't need to worry about raising additional capital just yet.";
				}
				s.Grade = Utilities.Clamp((float)weeksToNoCash / 26f, 0.85f);
			}
			r.AddSection(s);
			r.Finish(new string[]
			{
				"Location",
				"Promotion - Overall",
				"Promotion - Specifics",
				"Attractiveness of Prices",
				"Customer Wait Times",
				"Product Availability",
				"Expired Goods",
				"Merchandising",
				"Risk Management",
				"Financing"
			});
			return r;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0001CA94 File Offset: 0x0001BA94
		private string BillboardRadioOpinion(float n)
		{
			string result;
			if (n == 0f)
			{
				result = "unappealing";
			}
			else if (n < 1.1f)
			{
				result = "somewhat appealing";
			}
			else
			{
				result = "appealing";
			}
			return result;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0001CADC File Offset: 0x0001BADC
		private string MailStorefrontOpinion(float n)
		{
			string result;
			if (n == 0f)
			{
				result = "unappealing";
			}
			else if (n < 0.6f)
			{
				result = "somewhat appealing";
			}
			else if (n < 1.1f)
			{
				result = "appealing";
			}
			else
			{
				result = "very appealing";
			}
			return result;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0001CB38 File Offset: 0x0001BB38
		private float GradeBasedOnOpinion(string opinion)
		{
			float result;
			if (opinion == "unappealing")
			{
				result = 0.65f;
			}
			else if (opinion == "somewhat appealing")
			{
				result = 0.75f;
			}
			else if (opinion == "appealing")
			{
				result = 0.85f;
			}
			else
			{
				result = 0.95f;
			}
			return result;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0001CBA0 File Offset: 0x0001BBA0
		public string GoodBadAsPctOfRevenue(float amount)
		{
			string result;
			if ((double)amount > 0.2)
			{
				result = "really bad";
			}
			else if ((double)amount > 0.15)
			{
				result = "pretty bad";
			}
			else if ((double)amount > 0.1)
			{
				result = "OK";
			}
			else if ((double)amount > 0.05)
			{
				result = "pretty good";
			}
			else
			{
				result = "very good";
			}
			return result;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0001CC28 File Offset: 0x0001BC28
		public string GoodBadRatio(float amount)
		{
			string result;
			if ((double)amount < 0.5)
			{
				result = "really bad";
			}
			else if ((double)amount < 0.85)
			{
				result = "pretty bad";
			}
			else if ((double)amount < 1.25)
			{
				result = "OK";
			}
			else if (amount < 2f)
			{
				result = "pretty good";
			}
			else
			{
				result = "really good";
			}
			return result;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0001CCAC File Offset: 0x0001BCAC
		public float GradeRatio(float amount)
		{
			float result;
			if ((double)amount < 0.5)
			{
				result = 0.6f;
			}
			else if ((double)amount < 0.85)
			{
				result = 0.7f;
			}
			else if ((double)amount < 1.25)
			{
				result = 0.8f;
			}
			else if (amount < 2f)
			{
				result = 0.9f;
			}
			else
			{
				result = 1f;
			}
			return result;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0001CD30 File Offset: 0x0001BD30
		public float GradeAsPctOfRevenue(float amount)
		{
			return Utilities.Clamp(1f - 2f * amount);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0001CD54 File Offset: 0x0001BD54
		public string PercentHigherLower(float amount)
		{
			string result;
			if (amount == 1f)
			{
				result = "no higher or lower";
			}
			else
			{
				string hl;
				if (amount > 1f)
				{
					hl = "higher";
				}
				else
				{
					hl = "lower";
				}
				result = Utilities.FP(Math.Abs(amount - 1f)) + " " + hl;
			}
			return result;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0001CDB8 File Offset: 0x0001BDB8
		public void AddBillboardNear()
		{
			int ave = -1;
			int street = -1;
			int lot = -1;
			A.ST.OurCity.GetGoodBillBoardLocation((AppBuilding)this.Building, ref ave, ref street, ref lot);
			if (ave > -1)
			{
				A.SA.SetBillboard(base.ID, ave, street, lot);
			}
		}

		// Token: 0x040001C5 RID: 453
		public Backroom Backroom;

		// Token: 0x040001C6 RID: 454
		public Building Building;

		// Token: 0x040001C7 RID: 455
		public Floor Floor;

		// Token: 0x040001C8 RID: 456
		public PricingPolicy PricingPolicy;

		// Token: 0x040001C9 RID: 457
		public PurchasingPolicy PurchasingPolicy;

		// Token: 0x040001CA RID: 458
		public int[,] Schedule;

		// Token: 0x040001CB RID: 459
		public float[] Wages;

		// Token: 0x040001CC RID: 460
		public ArrayList ShelfStockers = new ArrayList();

		// Token: 0x040001CD RID: 461
		public ArrayList Cashiers = new ArrayList();

		// Token: 0x040001CE RID: 462
		public ArrayList Customers = new ArrayList();

		// Token: 0x040001CF RID: 463
		public AccountsPayable AP = new AccountsPayable();

		// Token: 0x040001D0 RID: 464
		protected SortedList loans = new SortedList();

		// Token: 0x040001D1 RID: 465
		public DateTime Founded;

		// Token: 0x040001D2 RID: 466
		public bool[,] RadioBookings = new bool[4, A.ST.RadioStations.Length];

		// Token: 0x040001D3 RID: 467
		public DateTime DiscountExpiration;

		// Token: 0x040001D4 RID: 468
		public float[] Discounts = new float[25];

		/// <summary>
		/// Repeat mailings: 2 elements, how often, when to start.
		/// HowOften=0 means turned off. All in days.
		/// </summary>
		// Token: 0x040001D5 RID: 469
		protected int mailingStartOffset;

		// Token: 0x040001D6 RID: 470
		protected int mailingFrequency = 0;

		// Token: 0x040001D7 RID: 471
		public MailingList MostRecentlyUsedMailingList;

		// Token: 0x040001D8 RID: 472
		public ArrayList MailingLists = new ArrayList();

		/// <summary>
		/// Physical Inventory Policy: 2 elements, how often, when to start.
		/// HowOften=0 means turned off. All in weeks.
		/// </summary>
		// Token: 0x040001D9 RID: 473
		protected int physicalInventoryFrequency = 0;

		// Token: 0x040001DA RID: 474
		protected int physicalInventoryStartOffset;

		// Token: 0x040001DB RID: 475
		public Color SignColor;

		// Token: 0x040001DC RID: 476
		public ArrayList BillboardBuildings = new ArrayList();

		// Token: 0x040001DD RID: 477
		public int Registers = 1;

		// Token: 0x040001DE RID: 478
		public Hashtable ServiceContracts = new Hashtable();

		// Token: 0x040001DF RID: 479
		public CommentLog Log = new CommentLog(1, 30);
	}
}
