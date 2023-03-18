using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using KMI.Biz;
using KMI.Biz.Banking;
using KMI.Biz.City;
using KMI.Biz.Product;
using KMI.Biz.Staffing;
using KMI.Sim;
using KMI.Sim.Surveys;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Used as a "front end" to the application's sim state, this
	/// class provides a way to get a chunk of sim state data all at once.
	/// This is especially useful for avoiding fine-grained accesses to a 
	/// remote sim state.
	/// </summary>
	// Token: 0x0200002E RID: 46
	public class AppStateAdapter : BizStateAdapter, IBizStaffingStateAdapter, IBizProductStateAdapter, IBizBankingStateAdapter
	{
		// Token: 0x0600011F RID: 287 RVA: 0x00011A5C File Offset: 0x00010A5C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public long TryAddEntity(string playerName, string storeName, int avenue, int street, int lot, float initialCapital, string capitalSourceName)
		{
			Player player = (Player)A.ST.Player[playerName];
			Entity capitalSource = null;
			if (capitalSourceName != null)
			{
				capitalSource = A.ST.GetEntityByName(capitalSourceName);
			}
			Building building = A.ST.OurCity[avenue, street, lot];
			if (building.Owner != null)
			{
				throw new SimApplicationException("Store has been rented. Try choosing another location.");
			}
			if (capitalSource != null && initialCapital > capitalSource.GL.AccountBalance("Cash"))
			{
				throw new SimApplicationException(A.R.GetString("The store that you are transferring cash from has less cash than the amount specified. Try transfering significantly less than {0} to the new store.", new object[]
				{
					Utilities.FC(capitalSource.GL.AccountBalance("Cash"), A.I.CurrencyConversion)
				}));
			}
			AppEntity store = (AppEntity)A.SA.TryAddEntity(playerName, storeName);
			store.Building = building;
			store.Building.Owner = store;
			if (store.AI)
			{
				store.AddBillboardNear();
			}
			if (capitalSource != null)
			{
				capitalSource.GL.Post("Cash", -initialCapital, "Paid-in Capital");
			}
			store.GL.Post("Cash", initialCapital, "Paid-in Capital");
			PlayerMessage.Broadcast(A.R.GetString("The store {0} just opened.", new object[]
			{
				store.Name
			}), null, NotificationColor.Yellow);
			store.Journal.AddEntry(A.R.GetString("Opened for business! Weekly rent is {0}.", new object[]
			{
				Utilities.FC(AppBuilding.RentFromReach((float)store.Building.Reach), A.I.CurrencyConversion)
			}));
			return store.ID;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00011C28 File Offset: 0x00010C28
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int[,] GetSchedule(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.Schedule;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00011C4C File Offset: 0x00010C4C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetSchedule(long entityID, int[,] schedule)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.Schedule = schedule;
			e.Journal.AddEntry(A.R.GetString("Changed staffing level. Weekly wages are now at {0}.", new object[]
			{
				Utilities.FC(e.WeeklyWages(), A.I.CurrencyConversion)
			}));
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00011CA8 File Offset: 0x00010CA8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Hashtable GetWages(long entityID)
		{
			return null;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00011CBC File Offset: 0x00010CBC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int GetEquipment(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.Registers;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00011CE0 File Offset: 0x00010CE0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetEquipment(long entityID, int registers)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (registers > e.Registers)
			{
				e.Journal.AddEntry(A.R.GetString("Increased number of registers from {0} to {1}.", new object[]
				{
					e.Registers,
					registers
				}));
			}
			else
			{
				e.Journal.AddEntry(A.R.GetString("Decreased number of registers from {0} to {1}.", new object[]
				{
					e.Registers,
					registers
				}));
			}
			e.Registers = registers;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00011D87 File Offset: 0x00010D87
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetWages(long entityID, float[] wages)
		{
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00011D8C File Offset: 0x00010D8C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmCustomerCredit.Input GetCustomerCredit(long entityID)
		{
			return default(frmCustomerCredit.Input);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00011DA7 File Offset: 0x00010DA7
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetCustomerCredit(long entityID, ArrayList noCredit, float earlyPayDiscount, int earlyPayDays, int netPayDays)
		{
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00011DAC File Offset: 0x00010DAC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmGetLoan.Input GetLoanInfo(long entityID)
		{
			frmGetLoan.Input input = default(frmGetLoan.Input);
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.CreditReport(ref input.CreditReport, ref input.CreditRating);
			input.Loans = e.Loans;
			input.CurrentDate = S.ST.Now;
			return input;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00011E08 File Offset: 0x00010E08
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void GetLoan(long entityID, float amount, int term, float rate)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			Loan.GetLoan(e.GL, e.Loans, amount, term, rate);
			e.Journal.AddEntry(A.R.GetString("Got a new loan for {0}.", new object[]
			{
				Utilities.FC(amount, A.I.CurrencyConversion)
			}));
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00011E70 File Offset: 0x00010E70
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void PayLoan(long entityID, ArrayList loanDue, ArrayList payAmount)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			Loan.PayLoan(e.GL, e.Loans, loanDue, payAmount);
			e.Journal.AddEntry(A.R.GetString("Payments made toward loan(s)."));
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00011EBC File Offset: 0x00010EBC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmTradeCredit.Input GetTradeCredit(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			frmTradeCredit.Input input = default(frmTradeCredit.Input);
			int suppliers = A.ST.Suppliers.Length;
			input.Name = new string[suppliers];
			input.PaymentTerms = new string[suppliers];
			input.TotalOwed = new float[suppliers];
			input.PastDue = new float[suppliers];
			input.OldestInvoice = new DateTime[suppliers];
			input.DaysToPay = new int[suppliers];
			for (int i = 0; i < suppliers; i++)
			{
				Supplier s = A.ST.Suppliers[i];
				input.Name[i] = s.Name;
				input.PaymentTerms[i] = string.Concat(new string[]
				{
					((int)(s.EarlyPayDiscount * 100f)).ToString(),
					"/",
					s.EarlyPayDays.ToString(),
					"/N/",
					s.DaysToPay.ToString()
				});
				input.TotalOwed[i] = e.AP.TotalOwed(s);
				input.PastDue[i] = e.AP.PastDue(s);
				input.OldestInvoice[i] = e.AP.OldestInvoice(s);
				input.DaysToPay[i] = e.AP.GetPolicy(input.Name[i]);
			}
			return input;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00012050 File Offset: 0x00011050
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetTradeCredit(long entityID, int[] daysToPay)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			string[] supplierNames = new string[A.ST.Suppliers.Length];
			for (int i = 0; i < A.ST.Suppliers.Length; i++)
			{
				supplierNames[i] = A.ST.Suppliers[i].Name;
			}
			e.AP.SetPolicy(supplierNames, daysToPay);
			e.Journal.AddEntry(A.R.GetString("Changed policy for paying supplier. Supplier will now be paid in {0} days.", new object[]
			{
				daysToPay[0]
			}));
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000120EC File Offset: 0x000110EC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetPricing(long entityID, PricingPolicy policy)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.PricingPolicy = policy;
			e.Journal.AddEntry(A.R.GetString("Changed prices. Overall pricing for non-custom priced products is now at {0} margin points.", new object[]
			{
				(100f * policy.GlobalMargin).ToString("F1")
			}));
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0001214C File Offset: 0x0001114C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmPricing.Input GetPricing(long entityID)
		{
			frmPricing.Input input = default(frmPricing.Input);
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			input.PricingPolicy = (PricingPolicy)Utilities.DeepCopyBySerialization(e.PricingPolicy);
			Entity[] competitors = A.ST.GetOtherPlayersEntities(e.Player.PlayerName);
			input.OurPrices = new float[AppConstants.ProductTypes.Length, 8];
			int numProds = AppConstants.ProductTypes.Length;
			for (int i = 0; i < numProds; i++)
			{
				input.OurPrices[i, 0] = e.PricingPolicy.GetPrice(i, AppConstants.ProductTypes[i].Cost);
				for (int wk = 1; wk < Math.Min(8, A.ST.CurrentWeek + 1); wk++)
				{
					input.OurPrices[i, wk] = e.GL.AccountBalance("Price - " + AppConstants.ProductTypes[i].Name, A.ST.CurrentWeek - wk);
				}
			}
			if (competitors.Length > 0)
			{
				input.MinCompetitivePrices = new float[numProds, 8];
				for (int i = 0; i < numProds; i++)
				{
					for (int wk = 0; wk < Math.Min(8, A.ST.CurrentWeek + 1); wk++)
					{
						input.MinCompetitivePrices[i, wk] = float.MaxValue;
					}
				}
				foreach (AppEntity c in competitors)
				{
					for (int i = 0; i < numProds; i++)
					{
						input.MinCompetitivePrices[i, 0] = Math.Min(c.PricingPolicy.GetPrice(i, AppConstants.ProductTypes[i].Cost), input.MinCompetitivePrices[i, 0]);
						for (int wk = 1; wk < Math.Min(8, A.ST.CurrentWeek + 1); wk++)
						{
							input.MinCompetitivePrices[i, wk] = Math.Min(c.GL.AccountBalance("Price - " + AppConstants.ProductTypes[i].Name, A.ST.CurrentWeek - wk), input.MinCompetitivePrices[i, wk]);
						}
					}
				}
			}
			return input;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000123E8 File Offset: 0x000113E8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetPurchasing(long entityID, PurchasingPolicy policy)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.PurchasingPolicy = policy;
			e.Journal.AddEntry(A.R.GetString("Changed purchasing policies. Target inventory level for non-custom purchased products is now {0} units.", new object[]
			{
				Utilities.FU(policy.GlobalAmount)
			}));
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0001243C File Offset: 0x0001143C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmPurchasing.Input GetPurchasing(long entityID)
		{
			frmPurchasing.Input input = default(frmPurchasing.Input);
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			input.PurchasingPolicy = (PurchasingPolicy)Utilities.DeepCopyBySerialization(e.PurchasingPolicy);
			input.AverageDailySales = new float[e.GL.ProductNames.Length];
			for (int i = 0; i < e.GL.ProductNames.Length; i++)
			{
				input.AverageDailySales[i] = e.GL.AccountBalance("Sales - " + e.GL.ProductNames[i], A.ST.CurrentWeek - 1) / 7f;
			}
			return input;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x000124F0 File Offset: 0x000114F0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void DiscardAllProduct(long entityID, int index)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.Backroom.ThrowAwayAll(index);
			e.Journal.AddEntry(A.R.GetString("Discarded all {0} in the backroom.", new object[]
			{
				AppConstants.ProductTypes[index].Name
			}));
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0001254C File Offset: 0x0001154C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmRadio.Input GetRadio(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return new frmRadio.Input
			{
				RadioStations = A.ST.RadioStations,
				Bookings = (bool[,])Utilities.DeepCopyBySerialization(e.RadioBookings)
			};
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0001259C File Offset: 0x0001159C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetRadio(long entityID, bool[,] radioBookings)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			float oldRadioCost = e.RadioAdvertisingCost();
			e.RadioBookings = radioBookings;
			if (e.RadioAdvertisingCost() - oldRadioCost > 0f)
			{
				e.Journal.AddEntry(A.R.GetString("Increased radio advertising spending by {0} per week.", new object[]
				{
					Utilities.FC(e.RadioAdvertisingCost() - oldRadioCost, A.I.CurrencyConversion)
				}));
			}
			else
			{
				e.Journal.AddEntry(A.R.GetString("Decreased radio advertising spending by {0} per week.", new object[]
				{
					Utilities.FC(-(e.RadioAdvertisingCost() - oldRadioCost), A.I.CurrencyConversion)
				}));
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00012658 File Offset: 0x00011658
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetBillboard(long entityID, int avenue, int street, int lot)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			A.ST.OurCity.AddBillboard(e, avenue, street, lot);
			e.Journal.AddEntry(A.R.GetString("Added a new billboard."));
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000126A4 File Offset: 0x000116A4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void KillBillboard(long entityID, int avenue, int street, int lot)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			A.ST.OurCity.KillBillboard(e, avenue, street, lot);
			e.Journal.AddEntry(A.R.GetString("Dropped a billboard."));
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000126F0 File Offset: 0x000116F0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmMail.Input GetMail(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return new frmMail.Input
			{
				DiscountExpiration = e.DiscountExpiration,
				Lists = (MailingList[])e.MailingLists.ToArray(typeof(MailingList)),
				MostRecentlyUsedMailingList = e.MostRecentlyUsedMailingList,
				MailingFrequency = e.MailingFrequency,
				Discounts = (float[])e.Discounts.Clone()
			};
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00012778 File Offset: 0x00011778
		[MethodImpl(MethodImplOptions.Synchronized)]
		public MailingList[] GetMailingLists(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return (MailingList[])e.MailingLists.ToArray(typeof(MailingList));
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000127B0 File Offset: 0x000117B0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetMailingFrequency(long entityID, int frequency)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.MailingFrequency = frequency;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000127D4 File Offset: 0x000117D4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void ReassignShelf(long entityID, string nodeName, long shelfID, int prodIndex)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			SectionBase sb = (SectionBase)e.Floor.Sections[nodeName];
			NodeV2 node = e.Floor.Map.getNode(nodeName);
			VBRProductType ptNew = null;
			if (prodIndex < AppConstants.ProductTypes.Length)
			{
				ptNew = AppConstants.ProductTypes[prodIndex];
			}
			if (shelfID > -1L)
			{
				Shelf shelf = null;
				foreach (object obj in e.Floor.AllShelves)
				{
					Shelf s = (Shelf)obj;
					if (s.ID == shelfID)
					{
						shelf = s;
						break;
					}
				}
				sb = shelf.Parent;
				node = sb.node;
				if (ptNew != null && shelf.Parent.RackType == ptNew.RackType)
				{
					foreach (Item item in shelf.Items)
					{
						if (item != null)
						{
							e.Backroom.Restock(item);
						}
					}
					shelf.ProductType = AppConstants.ProductTypes[prodIndex];
					e.AutoStockShelf(shelf);
					e.Journal.AddEntry(A.R.GetString("Allocated more space to {0}.", new object[]
					{
						shelf.ProductType.Name
					}));
					return;
				}
			}
			if (sb.Broken)
			{
				throw new SimApplicationException(A.R.GetString("Upon switching out the fixture, it was discovered that it is broken. You cannot switch out a broken fixture. Please repair it, then switch it out."));
			}
			foreach (Shelf sh in sb.Shelves)
			{
				foreach (Item item in sh.Items)
				{
					if (item != null)
					{
						e.Backroom.Restock(item);
					}
				}
			}
			sb = ((AppFactory)A.I.SimFactory).CreateSection(ptNew, sb);
			e.Floor.Sections[node.name] = sb;
			if (ptNew != null)
			{
				foreach (Shelf shelf in sb.Shelves)
				{
					shelf.ProductType = ptNew;
					for (int i = 0; i < shelf.Items.Length; i++)
					{
						shelf.Items[i] = e.Backroom.TakeItemOfType(shelf.ProductType);
					}
				}
				e.Journal.AddEntry(A.R.GetString("Allocated more space to {0}.", new object[]
				{
					ptNew.Name
				}));
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00012B00 File Offset: 0x00011B00
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int GetPhysicalInventory(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.PhysicalInventoryFrequency;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00012B24 File Offset: 0x00011B24
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetPhysicalInventory(long entityID, int frequency)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.PhysicalInventoryFrequency = frequency;
			if (frequency == 0)
			{
				e.Journal.AddEntry(A.R.GetString("Cancelled physical inventories."));
			}
			else
			{
				e.Journal.AddEntry(A.R.GetString("Set physical inventory policies to conduct inventory every {0} weeks.", new object[]
				{
					Utilities.FU(frequency)
				}));
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00012B9C File Offset: 0x00011B9C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmAdDesigner.Input GetAd(long entityID, int adNumber)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return default(frmAdDesigner.Input);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00012BC3 File Offset: 0x00011BC3
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetAd(long entityID, int adNumber, Ad ad)
		{
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00012BC8 File Offset: 0x00011BC8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SortedList GetReportsAP(long entityID)
		{
			return null;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00012BDC File Offset: 0x00011BDC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Hashtable GetReportsAR(long entityID)
		{
			return null;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00012BEF File Offset: 0x00011BEF
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetWages(long entityID, Hashtable wages)
		{
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00012BF4 File Offset: 0x00011BF4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetPopulation()
		{
			return A.ST.PopulationHistory;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00012C10 File Offset: 0x00011C10
		[MethodImpl(MethodImplOptions.Synchronized)]
		public override ConsultantReport GetConsultantReport(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			ConsultantReport report = e.CreateConsultantReport();
			e.GL.Post("Consulting Fees", 1000f, "Cash");
			e.Journal.AddEntry("Purchased consultant report for " + Utilities.FC(1000f, A.I.CurrencyConversion) + ".");
			return report;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00012C80 File Offset: 0x00011C80
		[MethodImpl(MethodImplOptions.Synchronized)]
		public override ConsultantReport[] GetGrades(long entityID)
		{
			ArrayList reports = new ArrayList();
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			foreach (object obj in A.ST.Entity.Values)
			{
				AppEntity e2 = (AppEntity)obj;
				if (e.Player == e2.Player)
				{
					try
					{
						ConsultantReport r = e2.CreateConsultantReport();
						reports.Add(r);
					}
					catch
					{
						throw new SimApplicationException("One or more of your stores has not been open long enough to grade. Run the sim another several weeks.");
					}
				}
			}
			return (ConsultantReport[])reports.ToArray(typeof(ConsultantReport));
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00012D64 File Offset: 0x00011D64
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmOpenNewStore.Input GetOpenNewEntity(string playerName)
		{
			frmOpenNewStore.Input input = default(frmOpenNewStore.Input);
			input.Multiplayer = base.simState.Multiplayer;
			Player p = (Player)base.simState.Player[playerName];
			ArrayList temp = new ArrayList();
			foreach (object obj in base.simState.Entity.Values)
			{
				Entity e = (Entity)obj;
				if (e.Player == p)
				{
					temp.Add(e.Name);
				}
			}
			input.EntitiesOwnedNames = (string[])temp.ToArray(typeof(string));
			input.Savings = A.SS.InitialHumanCapital;
			if (A.ST.Multiplayer)
			{
				input.Savings *= 5f;
				if (A.ST.RoleBasedMultiplayer)
				{
					input.Rolebased = true;
				}
			}
			return input;
		}

		/// <summary>
		/// Sends direct mail
		/// </summary>
		/// <param name="entityID"></param>
		/// <param name="list"></param>
		/// <returns>Arraylist of PointFs for drawing envelopes.</returns>
		// Token: 0x06000145 RID: 325 RVA: 0x00012EA4 File Offset: 0x00011EA4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList ExecuteMailing(long entityID, MailingList list)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.ExecuteMailing(list);
			ArrayList customerLocations = new ArrayList();
			foreach (object obj in list.RecipientIDs)
			{
				long ID = (long)obj;
				Customer customer = (Customer)A.ST.Customers[ID];
				if (customer != null)
				{
					customerLocations.Add(Utilities.SpreadOut(customer.Home.ScreenLocWholeCity, 10f, A.ST.Random));
				}
			}
			e.Journal.AddEntry(A.R.GetString("Sent direct mail using list {0}. Total recipients were {1}.", new object[]
			{
				list.Name,
				Utilities.FU(list.RecipientIDs.Count * 20 * 5)
			}));
			return customerLocations;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00012FCC File Offset: 0x00011FCC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public MailingList CreateMailingList(int beginMailAvenue, int beginMailStreet, int beginMailLot, int endMailAvenue, int endMailStreet, int endMailLot)
		{
			MailingList list = new MailingList();
			foreach (object obj in A.ST.Customers.Values)
			{
				Customer customer = (Customer)obj;
				Building home = customer.Home;
				PointF[] p = new PointF[]
				{
					City.TransformWholeCity((float)beginMailAvenue, (float)beginMailStreet, (float)beginMailLot),
					City.TransformWholeCity((float)beginMailAvenue, (float)endMailStreet, (float)beginMailLot),
					City.TransformWholeCity((float)endMailAvenue, (float)endMailStreet, (float)endMailLot),
					City.TransformWholeCity((float)endMailAvenue, (float)beginMailStreet, (float)endMailLot)
				};
				if (Utilities.PolygonContains(new Point(customer.Home.ScreenLocWholeCity.X, customer.Home.ScreenLocWholeCity.Y), p))
				{
					list.RecipientIDs.Add(customer.ID);
				}
			}
			return list;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00013124 File Offset: 0x00012124
		[MethodImpl(MethodImplOptions.Synchronized)]
		public MailingList CreateMailingList(Survey survey)
		{
			MailingList list = new MailingList();
			foreach (object obj in survey.Responses)
			{
				SurveyResponse r = (SurveyResponse)obj;
				if (survey.InAllSegments(r))
				{
					list.RecipientIDs.Add(r.RespondantID);
				}
			}
			return list;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000131BC File Offset: 0x000121BC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void AddMailingList(long entityID, MailingList list)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.MailingLists.Add(list);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000131E4 File Offset: 0x000121E4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetDiscounts(long entityID, float[] discounts)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (discounts == null)
			{
				e.Discounts = new float[25];
			}
			else
			{
				e.Discounts = discounts;
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00013220 File Offset: 0x00012220
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Hashtable GetServiceContracts(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.SynchUnitCountsOnServiceContracts();
			return (Hashtable)Utilities.DeepCopyBySerialization(e.ServiceContracts);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00013258 File Offset: 0x00012258
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetServiceContracts(long entityID, Hashtable serviceContracts)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			string s = "";
			foreach (object obj in serviceContracts.Values)
			{
				ServiceContract sc = (ServiceContract)obj;
				if (sc.ResponseTimeIndex > 0)
				{
					object obj2 = s;
					s = string.Concat(new object[]
					{
						obj2,
						AppConstants.ResponseTimes[sc.ResponseTimeIndex],
						" hour response on ",
						sc.RackType.ToLower(),
						"s, "
					});
				}
			}
			if (s == "")
			{
				s = A.R.GetString("no contracts");
			}
			else
			{
				s = Utilities.FormatCommaSeries(s);
			}
			e.Journal.AddEntry(A.R.GetString("Modified service contracts to include {0}.", new object[]
			{
				s
			}));
			e.ServiceContracts = serviceContracts;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00013390 File Offset: 0x00012390
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetImmediateRepair(long entityID, string rackType)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.Journal.AddEntry(A.R.GetString("Purchased an immediate repair of a {0}.", new object[]
			{
				rackType.ToLower()
			}));
			e.ImmediateRepair(rackType);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000133E0 File Offset: 0x000123E0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetCamera(long entityID, int index, bool installed)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.Floor.Cameras[index] = installed;
			string s = A.R.GetString("installed");
			if (!installed)
			{
				s = A.R.GetString("uninstalled");
			}
			e.Journal.AddEntry(A.R.GetString("A security camera was {0}.", new object[]
			{
				s
			}));
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00013454 File Offset: 0x00012454
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmAdDesignerSimple.Input GetAdSimple(long entityID, int adNumber)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			frmAdDesignerSimple.Input input = default(frmAdDesignerSimple.Input);
			input.Ad = e.Floor.Ads[adNumber];
			input.OurPrices = new float[25];
			for (int i = 0; i < 25; i++)
			{
				input.OurPrices[i] = e.PricingPolicy.GetPrice(i, AppConstants.ProductTypes[i].Cost);
			}
			return input;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000134D4 File Offset: 0x000124D4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SetAdSimple(long entityID, int adNumber, AdSimple ad)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (ad == null)
			{
				e.Journal.AddEntry(A.R.GetString("Deleted a storefront ad."));
			}
			else if (e.Floor.Ads[adNumber] == null)
			{
				e.Journal.AddEntry(A.R.GetString("Added a new storefront ad."));
			}
			else
			{
				e.Journal.AddEntry(A.R.GetString("Changed a storefront ad."));
			}
			e.Floor.Ads[adNumber] = ad;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00013574 File Offset: 0x00012574
		[MethodImpl(MethodImplOptions.Synchronized)]
		public float GetPrice(long entityID, ProductType pt)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			return e.PricingPolicy.GetPrice(pt.Index, pt.Cost);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000135AC File Offset: 0x000125AC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void MoveEntity(long entityID, int ave, int street, int lot)
		{
			AppBuilding building = (AppBuilding)A.ST.OurCity[ave, street, lot];
			if (building == null || building.Owner != null)
			{
				throw new SimApplicationException("That location is taken. Try choosing another location.");
			}
			AppEntity w = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			w.Building.Owner = null;
			w.Building = building;
			building.Owner = w;
			foreach (object obj in A.ST.Customers.Values)
			{
				Customer c = (Customer)obj;
				c.ClearImpressions(entityID);
			}
			w.GL.Post("Moving Expenses", 25000f, "Cash");
			w.Journal.AddEntry(A.R.GetString("Moved {0} to a new location with rent {1}. Moving expenses were {2}.", new object[]
			{
				w.Name,
				Utilities.FC((float)building.Rent, A.I.CurrencyConversion),
				Utilities.FC(25000f, A.I.CurrencyConversion)
			}));
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000136FC File Offset: 0x000126FC
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmMultiStoreReport.Input[] GetMultiStoreReport(long entityID)
		{
			ArrayList inputs = new ArrayList();
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			foreach (object obj in A.ST.Entity.Values)
			{
				AppEntity e2 = (AppEntity)obj;
				if (e.Player == e2.Player)
				{
					inputs.Add(new frmMultiStoreReport.Input
					{
						Name = e2.Name,
						ID = e2.ID,
						gl = (GeneralLedger)Utilities.DeepCopyBySerialization(e2.GL),
						CurrentWeek = A.ST.CurrentWeek
					});
				}
			}
			if (inputs.Count < 2)
			{
				throw new SimApplicationException(A.R.GetString("This report compares multiple stores that you own. Right now you only have one store."));
			}
			return (frmMultiStoreReport.Input[])inputs.ToArray(typeof(frmMultiStoreReport.Input));
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00013834 File Offset: 0x00012834
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void AutoLayout(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			e.Floor.AutoLayout();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0001385C File Offset: 0x0001285C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public override CommentLog GetComments(long entityID)
		{
			AppEntity e = (AppEntity)SimStateAdapter.CheckEntityExists(entityID);
			if (e.Log.Comments.Count <= 2)
			{
				throw new SimApplicationException(A.R.GetString("There are currently no comments to view."));
			}
			return (CommentLog)Utilities.DeepCopyBySerialization(e.Log);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000138B8 File Offset: 0x000128B8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmPricingReport.Input GetPricingReport()
		{
			frmPricingReport.Input input = default(frmPricingReport.Input);
			input.StoreNames = new string[A.ST.Entity.Count];
			input.PricingPolicies = new PricingPolicy[A.ST.Entity.Count];
			int i = 0;
			foreach (object obj in A.ST.Entity.Values)
			{
				AppEntity e = (AppEntity)obj;
				input.StoreNames[i] = e.Name;
				input.PricingPolicies[i] = e.PricingPolicy;
				i++;
			}
			return input;
		}
	}
}
