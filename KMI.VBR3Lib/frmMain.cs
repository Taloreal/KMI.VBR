using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz;
using KMI.Biz.Banking;
using KMI.Biz.City;
using KMI.Biz.Product;
using KMI.Biz.Staffing;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Sim.Surveys;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// The applications Main Form.
	/// </summary>
	// Token: 0x0200003C RID: 60
	public partial class frmMain : frmMainBase
	{
		/// <summary>
		/// Default Constructor.
		/// </summary>
		// Token: 0x06000183 RID: 387 RVA: 0x0001538A File Offset: 0x0001438A
		public frmMain()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Constructs the application's Main Form using the given
		/// Icon and arguments.
		/// </summary>
		// Token: 0x06000184 RID: 388 RVA: 0x000153AA File Offset: 0x000143AA
		public frmMain(string[] args, bool demo, bool vbc, bool academic) : base(args, demo, vbc, academic)
		{
			this.InitializeComponent();
			this.Init();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000153D6 File Offset: 0x000143D6
		public static void HandleError(Exception ex)
		{
			frmExceptionHandler.Handle(ex);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000153E0 File Offset: 0x000143E0
		public void Init()
		{
			base.DesignerMode = false;
			this.LessonMode = false;
			KMIHelp.RemotePath = "http://help.knowledgematters.com/vbr3/Help/index.htm";
			S.I.DataFileTypeExtension = "VBR3";
			S.I.EntityName = A.R.GetString("Store");

			City.BuildingTypes = (BuildingType[])TableReader.Read(base.GetType().Assembly, typeof(BuildingType), "KMI.VBR3Lib.Data.BuildingTypes.txt");
			AppConstants.ProductTypes = (VBRProductType[])TableReader.Read(typeof(VBRProductType), "KMI.VBR3Lib.Data.ProductTypes.txt");
			for (int i = 0; i < AppConstants.ProductTypes.Length; i++)
			{
				AppConstants.ProductTypes[i].Width = A.R.GetImage("Prod" + i).Width;
			}
			AppConstants.DemographicTypes = (DemographicType[])TableReader.Read(typeof(DemographicType), "KMI.VBR3Lib.Data.DemographicTypes.txt");
			Survey.LoadQuestionsFromTable(typeof(frmMain), "KMI.VBR3Lib.Data.SurveyQuestions.txt");
			Survey.SurveyableObjectName = A.R.GetString("Customers");
			Survey.ShowAllSurveyedWhenSegmented = true;
			Survey.ShowBuyMailingList = true;
			GeneralLedger.FirstLevelSubaccountsWhenUndetailed = false;
			Consumer.ImpressionSources = new string[]
			{
				A.R.GetString("Radio"),
				A.R.GetString("Direct Mail"),
				A.R.GetString("Billboards"),
				A.R.GetString("Storefront Ads")
			};
			this.ScoreboardButton = this.toolBarButton15;
			S.I.AllowRoleBasedMultiplayer = true;
			MultiplayerRole.LoadRolesFromTable(typeof(frmMain), "KMI.VBR3Lib.Data.MultiplayerRoles.txt");
			this.mnuOptionsShowComments = new MenuItem(A.R.GetString("Show Comments"), new EventHandler(this.mnuOptionsShowComments_Click));
			this.mnuOptionsShowComments.Checked = true;
			this.mnuOptions.MenuItems.Add(6, this.mnuOptionsShowComments);
			this.mnuReports.MenuItems.Add(3, new MenuItem("-"));
			this.mnuReportsCommentLog = new MenuItem(A.R.GetString("Comment Log"), new EventHandler(this.mnuReportsComments_Click));
			this.mnuReports.MenuItems.Add(4, this.mnuReportsCommentLog);
			this.mnuReportsPricing = new MenuItem(A.R.GetString("Competitive Prices"), new EventHandler(this.mnuReportsPricing_Click));
			this.mnuReports.MenuItems.Add(8, this.mnuReportsPricing);
			base.WindowState = FormWindowState.Maximized;
		}

		/// <summary>
		/// Constructs the application's Simulator.
		/// </summary>
		// Token: 0x06000187 RID: 391 RVA: 0x0001567F File Offset: 0x0001467F
		protected override void ConstructSimulator()
		{
			Simulator.InitSimulator(new AppFactory());
		}

		/// <summary>
		/// Displays the vital signs report for the current entity.
		/// </summary>
		// Token: 0x0600018A RID: 394 RVA: 0x00016980 File Offset: 0x00015980
		private void mnuReportsVitalSigns_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmVitalSigns
			{
				EnablingReference = this.mnuReportsVitalSigns
			});
		}

		/// <summary>
		/// Displays the financials report for the current entity.
		/// </summary>
		// Token: 0x0600018B RID: 395 RVA: 0x000169AC File Offset: 0x000159AC
		private void mnuReportsFinancials_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmFinancials
			{
				EnablingReference = this.mnuReportsFinancials
			});
		}

		/// <summary>
		/// Brings up the dialog for creating a new entity.
		/// </summary>
		// Token: 0x0600018C RID: 396 RVA: 0x000169D8 File Offset: 0x000159D8
		private void mnuActionsNewEntity_Click(object sender, EventArgs e)
		{
			CityView view = (CityView)S.I.Views[0];
			base.OnViewChange(view.Name);
			view.Mode = CityView.Modes.NewStore;
			try
			{
				Form f = new frmOpenNewStore();
				view.Form = f;
				base.ShowNonModalForm(f);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		/// <summary>
		/// Displays the actions journal for the current entity.
		/// </summary>
		// Token: 0x0600018D RID: 397 RVA: 0x00016A44 File Offset: 0x00015A44
		private void mnuReportsActionsJournal_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmActionsJournal(true)
			{
				EnablingReference = this.mnuReportsActionsJournal
			});
		}

		/// <summary>
		/// Brings up the dialog for closing the current entity.
		/// </summary>
		// Token: 0x0600018E RID: 398 RVA: 0x00016A70 File Offset: 0x00015A70
		private void mnuActionsCloseEntity_Click(object sender, EventArgs e)
		{
			string message = A.R.GetString("Are you sure you want to close {0}?", new object[]
			{
				A.MF.EntityIDToName(A.MF.CurrentEntityID)
			});
			string title = A.R.GetString("Close {0}", new object[]
			{
				S.I.EntityName
			});
			if (DialogResult.Yes == MessageBox.Show(this, message, title, MessageBoxButtons.YesNo))
			{
				try
				{
					A.SA.CloseEntity(base.CurrentEntityID);
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex);
					return;
				}
				if (base.SoundOn)
				{
					Sound.PlaySoundFromFile("sounds\\Destroy.wav");
				}
				base.UpdateView();
			}
		}

		/// <summary>
		/// Displays the market share report for the current entity.
		/// </summary>
		// Token: 0x0600018F RID: 399 RVA: 0x00016B3C File Offset: 0x00015B3C
		private void mnuReportsMarketShare_Click(object sender, EventArgs e)
		{
			Form f = new frmMarketShare();
			base.ShowNonModalForm(f);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00016B58 File Offset: 0x00015B58
		private void mnuReportsAutoGrader_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmAutoGrader
			{
				EnablingReference = this.mnuReportsAutoGrader
			});
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00016B80 File Offset: 0x00015B80
		private void mnuActionsNewSurvey_Click(object sender, EventArgs e)
		{
			try
			{
				frmSurvey f = new frmSurvey();
				f.updNumToSurvey.Value = 300m;
				f.ShowDialog(this);
				if (f.DialogResult == DialogResult.OK)
				{
					this.mnuActionsSurveyResults.PerformClick();
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00016BF0 File Offset: 0x00015BF0
		private void mnuActionsSurveyResults_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmAppSurveyResults(S.I.ThisPlayerName, null);
				base.ShowNonModalForm(f);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00016C38 File Offset: 0x00015C38
		private void mnuActionsPricing_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmPricing(AppConstants.ProductTypes, -1, false);
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00016C7C File Offset: 0x00015C7C
		private void mnuActionsStaffing_Click(object sender, EventArgs e)
		{
			try
			{
				frmStaffingSimple.DEFAULT_EMPS = 3;
				frmStaffingSimple f = new frmStaffingSimple(A.R.GetImage("StaffingPic"), AppConstants.TaskNames, AppConstants.ShiftStartHours, AppConstants.ShiftLengths, AppConstants.MaxEmployees, AppConstants.Wages);
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00016CE8 File Offset: 0x00015CE8
		private void mnuActionsTradeCredit_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmTradeCredit();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00016D28 File Offset: 0x00015D28
		private void mnuActionsPurchasing_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmPurchasing(AppConstants.ProductTypes, -1, 25000);
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00016D70 File Offset: 0x00015D70
		private void mnuActionsTransferCash_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmTransferCash();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00016DB0 File Offset: 0x00015DB0
		private void mnuActionsBankDebtGetLoan_Click(object sender, EventArgs e)
		{
			try
			{
				frmGetLoan f = new frmGetLoan();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00016DF0 File Offset: 0x00015DF0
		private void mnuActionsBankDebtPayLoan_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmPayLoan();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00016E30 File Offset: 0x00015E30
		private void mnuActionsPromotionRadioAdvertising_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmRadio();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00016E70 File Offset: 0x00015E70
		private void mnuActionsPromotionBillboardAdvertising_Click(object sender, EventArgs e)
		{
			CityView view = (CityView)S.I.Views[0];
			base.OnViewChange(view.Name);
			view.Mode = CityView.Modes.Billboard;
			Form f = new frmBillboard();
			view.Form = f;
			base.ShowNonModalForm(f);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00016EBC File Offset: 0x00015EBC
		private void mnuActionsPromotionDirectMail_Click(object sender, EventArgs e)
		{
			CityView view = (CityView)S.I.Views[0];
			view.ViewerOptions[2] = false;
			if (!A.I.Client)
			{
				A.ST.CityViewerOptions = view.ViewerOptions;
			}
			base.OnViewChange(view.Name);
			view.Mode = CityView.Modes.Mail;
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop.PerformClick();
			}
			Form f = new frmMail();
			view.Form = f;
			base.ShowNonModalForm(f);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00016F50 File Offset: 0x00015F50
		private void mnuActionsMerchandising_Click(object sender, EventArgs e)
		{
			base.OnViewChange(S.I.Views[1].Name);
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop.PerformClick();
			}
			MessageBox.Show(A.R.GetString("To assign a product to a shelf or change a fixture, click on the shelf or fixture and select from the menu."), A.R.GetString("Merchandising"));
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00016FB7 File Offset: 0x00015FB7
		private void mnuActionsPromotionStorefrontAds_Click(object sender, EventArgs e)
		{
			base.OnViewChange(S.I.Views[1].Name);
			MessageBox.Show(A.R.GetString("To create or edit a storefront ad, click an open window space or an existing storefront ad."), A.R.GetString("Create Storefront Ads"));
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00016FF8 File Offset: 0x00015FF8
		private void mnuReportsProducts_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmProductReport
			{
				EnablingReference = this.mnuReportsProducts
			});
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00017024 File Offset: 0x00016024
		private void mnuReportsProductAging_Click(object sender, EventArgs e)
		{
			if (S.I.SimTimeRunning)
			{
				this.mnuOptionsGoStop.PerformClick();
			}
			Application.DoEvents();
			if (this.currentView != S.I.Views[1] && this.currentView != S.I.Views[2])
			{
				frmDualChoiceDialog dlgPickTwo = new frmDualChoiceDialog(A.R.GetString("In which view would you like to see product aging?"), A.R.GetString("Store"), A.R.GetString("Backroom"), true);
				DialogResult returnValue = dlgPickTwo.ShowDialog(this);
				if (returnValue == DialogResult.Yes)
				{
					base.OnViewChange(S.I.Views[1].Name);
				}
				else
				{
					if (returnValue != DialogResult.No)
					{
						return;
					}
					base.OnViewChange(S.I.Views[2].Name);
				}
			}
			Graphics g = A.MF.BackBufferGraphics;
			ArrayList allDrawables = new ArrayList();
			foreach (Drawable d in this.currentView.Drawables)
			{
				allDrawables.Add(d);
				if (d is CompoundDrawable)
				{
					allDrawables.AddRange(((CompoundDrawable)d).Drawables);
				}
			}
			foreach (object obj in allDrawables)
			{
				Drawable d = (Drawable)obj;
				if (d is IPctExpired)
				{
					float pct = ((IPctExpired)d).PercentExpired();
					if (pct > -1f)
					{
						int index = (int)Math.Floor((double)(pct * 3f));
						Point offset = new Point(-4, -19);
						if (d is BackroomDrawable)
						{
							offset = new Point(26, -22);
						}
						if (d is StationDrawable)
						{
							offset = new Point(51, 36);
						}
						g.DrawImageUnscaled(A.R.GetImage("ShelfLife" + index), new Point(d.Location.X + offset.X, d.Location.Y + offset.Y));
					}
				}
			}
			A.MF.picMain.Refresh();
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000172F4 File Offset: 0x000162F4
		private void mnuReportsPopulation_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmPopulation
			{
				EnablingReference = this.mnuReportsPopulation
			});
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0001731C File Offset: 0x0001631C
		private void mnuActionsPhysicalInventory_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmPhysicalInventory();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0001735C File Offset: 0x0001635C
		private void mnuActionsConsultant_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show(A.R.GetString("The consultant charges {0} for a report. Do you want to purchase the report?", new object[]
				{
					Utilities.FC(1000f, A.I.CurrencyConversion)
				}), A.R.GetString("Confirm Consultant Purchase"), MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Form form = new frmConsultant();
					form.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000173E8 File Offset: 0x000163E8
		protected void mnuOptionsShowComments_Click(object sender, EventArgs e)
		{
			this.mnuOptionsShowComments.Checked = !this.mnuOptionsShowComments.Checked;
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00017408 File Offset: 0x00016408
		public bool ShowComments
		{
			get
			{
				return this.mnuOptionsShowComments.Checked;
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00017428 File Offset: 0x00016428
		protected override void ClientJoinHook(Player p)
		{
			base.ClientJoinHook(p);
			object[] vo = A.I.Views[0].ViewerOptions;
			A.I.Views[0].ViewerOptions = new object[]
			{
				vo[0],
				vo[1],
				vo[2],
				p.PlayerName
			};
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00017484 File Offset: 0x00016484
		protected override void LoadStateHook()
		{
			((CityView)A.I.Views[0]).ViewerOptions = A.ST.CityViewerOptions;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000174A8 File Offset: 0x000164A8
		private void mnuActionsEquipment_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmEquipment();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000174E8 File Offset: 0x000164E8
		private void frmServiceContracts_Click(object sender, EventArgs e)
		{
			try
			{
				Form f = new frmServiceContracts();
				f.ShowDialog(this);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00017528 File Offset: 0x00016528
		public override void EnableDisable()
		{
			base.EnableDisable();
			try
			{
				long id = A.SA.GetAnEntityIdForPlayer(A.I.ThisPlayerName);
				bool hasNoEntities = id == -1L;
				if (!A.I.Host && hasNoEntities && (A.I.MultiplayerRole == null || !A.I.MultiplayerRole.DisableListContains(this.mnuActionsNewEntity.Text)))
				{
					this.mnuActionsNewEntity.Enabled = ((AppSimSettings)A.SA.getSimSettings()).OpenNewStoreEnabledForOwner;
					if (this.mnuActionsNewEntity.Enabled)
					{
						this.mnuActionsNewSurvey.Enabled = true;
						this.mnuActionsSurveyResults.Enabled = true;
						this.mnuActionsMarketResearch.Enabled = true;
					}
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00017618 File Offset: 0x00016618
		private void mnuActionsMoveStore_Click(object sender, EventArgs e)
		{
			base.OnViewChange(S.I.Views[0].Name);
			CityView view = (CityView)A.I.Views[0];
			view.Mode = CityView.Modes.MoveStore;
			if (A.I.SimTimeRunning)
			{
				base.mnuOptionsGoStop_Click(new object(), new EventArgs());
			}
			try
			{
				frmMoveStore f = new frmMoveStore();
				view.Form = f;
				base.ShowNonModalForm(f);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000176B0 File Offset: 0x000166B0
		private void mnuReportsMultiStore_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmMultiStoreReport
			{
				EnablingReference = this.mnuReportsMultiStore
			});
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000176D8 File Offset: 0x000166D8
		private void mnuReportsComments_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmViewComments
			{
				EnablingReference = this.mnuReportsCommentLog,
				Height = 300
			});
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0001770C File Offset: 0x0001670C
		private void mnuReportsPricing_Click(object sender, EventArgs e)
		{
			base.ShowNonModalForm(new frmPricingReport
			{
				EnablingReference = this.mnuReportsPricing,
				Height = 490,
				Width = 640
			});
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0001774C File Offset: 0x0001674C
		public override int GetVBCStudentOrgCode()
		{
			return 1;
		}

		// Token: 0x04000180 RID: 384
		public bool LessonMode = false;

		// Token: 0x04000189 RID: 393
		private MenuItem mnuOptionsShowComments;

		// Token: 0x0400018A RID: 394
		private MenuItem mnuReportsCommentLog;

		// Token: 0x0400018B RID: 395
		private MenuItem mnuReportsPricing;
	}
}
