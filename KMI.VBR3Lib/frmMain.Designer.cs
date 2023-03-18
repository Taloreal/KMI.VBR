namespace KMI.VBR3Lib
{
	/// <summary>
	/// The applications Main Form.
	/// </summary>
	// Token: 0x0200003C RID: 60
	public partial class frmMain : global::KMI.Sim.frmMainBase
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000188 RID: 392 RVA: 0x00015690 File Offset: 0x00014690
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x06000189 RID: 393 RVA: 0x000156CC File Offset: 0x000146CC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KMI.VBR3Lib.frmMain));
			this.toolBarButton1 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton8 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton9 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton10 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton11 = new global::System.Windows.Forms.ToolBarButton();
			this.mnuReportsVitalSigns = new global::System.Windows.Forms.MenuItem();
			this.mnuReportsFinancials = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsNewEntity = new global::System.Windows.Forms.MenuItem();
			this.menuItem1 = new global::System.Windows.Forms.MenuItem();
			this.mnuReportsActionsJournal = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsCloseEntity = new global::System.Windows.Forms.MenuItem();
			this.menuItem2 = new global::System.Windows.Forms.MenuItem();
			this.mnuReportsMarketShare = new global::System.Windows.Forms.MenuItem();
			this.toolBarButton12 = new global::System.Windows.Forms.ToolBarButton();
			this.toolBarButton13 = new global::System.Windows.Forms.ToolBarButton();
			this.menuItem4 = new global::System.Windows.Forms.MenuItem();
			this.menuItem5 = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsMarketResearch = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsNewSurvey = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsSurveyResults = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsPricing = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsPromotion = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsPromotionStorefrontAds = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsPromotionRadioAdvertising = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsPromotionDirectMail = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsPromotionBillboardAdvertising = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsMerchandising = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsStaffing = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsPurchasing = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsPhysicalInventory = new global::System.Windows.Forms.MenuItem();
			this.menuItem13 = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsTradeCredit = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsBankDebt = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsBankDebtGetLoan = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsBankDebtPayLoan = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsTransferCash = new global::System.Windows.Forms.MenuItem();
			this.menuItem19 = new global::System.Windows.Forms.MenuItem();
			this.mnuActionsConsultant = new global::System.Windows.Forms.MenuItem();
			this.mnuReportsProducts = new global::System.Windows.Forms.MenuItem();
			this.menuItem7 = new global::System.Windows.Forms.MenuItem();
			this.mnuReportsProductAging = new global::System.Windows.Forms.MenuItem();
			this.mnuReportsPopulation = new global::System.Windows.Forms.MenuItem();
			this.toolBarButton14 = new global::System.Windows.Forms.ToolBarButton();
			this.mnuActionsEquipment = new global::System.Windows.Forms.MenuItem();
			this.frmServiceContracts = new global::System.Windows.Forms.MenuItem();
			this.toolBarButton15 = new global::System.Windows.Forms.ToolBarButton();
			this.mnuActionsMoveStore = new global::System.Windows.Forms.MenuItem();
			this.menuItem6 = new global::System.Windows.Forms.MenuItem();
			this.mnuReportsAutoGrader = new global::System.Windows.Forms.MenuItem();
			this.mnuReportsMultiStore = new global::System.Windows.Forms.MenuItem();
			this.menuItem9 = new global::System.Windows.Forms.MenuItem();
			((global::System.ComponentModel.ISupportInitialize)this.NewMessagesPanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.DatePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.DayOfWeekPanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.TimePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.CurrentEntityNamePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.CurrentEntityPanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.EntityCriticalResourceNamePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.EntityCriticalResourcePanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.SpacerPanel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.picMain).BeginInit();
			base.SuspendLayout();
			this.SpacerPanel.Width = 186;
			this.mnuReports.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuReportsVitalSigns,
				this.mnuReportsFinancials,
				this.mnuReportsProducts,
				this.menuItem7,
				this.mnuReportsProductAging,
				this.menuItem1,
				this.mnuReportsMarketShare,
				this.mnuReportsPopulation,
				this.menuItem6,
				this.mnuReportsAutoGrader,
				this.menuItem9,
				this.mnuReportsMultiStore,
				this.menuItem2,
				this.mnuReportsActionsJournal
			});
			this.mnuActions.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuActionsNewEntity,
				this.mnuActionsMoveStore,
				this.mnuActionsCloseEntity,
				this.menuItem4,
				this.mnuActionsPricing,
				this.mnuActionsPromotion,
				this.mnuActionsMerchandising,
				this.mnuActionsMarketResearch,
				this.menuItem5,
				this.mnuActionsStaffing,
				this.mnuActionsPurchasing,
				this.mnuActionsEquipment,
				this.frmServiceContracts,
				this.mnuActionsPhysicalInventory,
				this.menuItem13,
				this.mnuActionsTradeCredit,
				this.mnuActionsBankDebt,
				this.mnuActionsTransferCash,
				this.menuItem19,
				this.mnuActionsConsultant
			});
			this.staMain.Location = new global::System.Drawing.Point(0, 342);
			this.staMain.Size = new global::System.Drawing.Size(717, 16);
			this.tlbMain.Buttons.AddRange(new global::System.Windows.Forms.ToolBarButton[]
			{
				this.toolBarButton1,
				this.toolBarButton2,
				this.toolBarButton3,
				this.toolBarButton5,
				this.toolBarButton6,
				this.toolBarButton4,
				this.toolBarButton12,
				this.toolBarButton13,
				this.toolBarButton7,
				this.toolBarButton8,
				this.toolBarButton9,
				this.toolBarButton14,
				this.toolBarButton10,
				this.toolBarButton11,
				this.toolBarButton15
			});
			this.tlbMain.Size = new global::System.Drawing.Size(717, 50);
			this.picMain.Location = new global::System.Drawing.Point(202, 54);
			this.ilsMainToolBar.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ilsMainToolBar.ImageStream = (global::System.Windows.Forms.ImageListStreamer)resources.GetObject("ilsMainToolBar.ImageStream");
			this.ilsMainToolBar.Images.SetKeyName(0, "");
			this.ilsMainToolBar.Images.SetKeyName(1, "");
			this.ilsMainToolBar.Images.SetKeyName(2, "");
			this.ilsMainToolBar.Images.SetKeyName(3, "");
			this.ilsMainToolBar.Images.SetKeyName(4, "");
			this.ilsMainToolBar.Images.SetKeyName(5, "");
			this.ilsMainToolBar.Images.SetKeyName(6, "");
			this.ilsMainToolBar.Images.SetKeyName(7, "");
			this.ilsMainToolBar.Images.SetKeyName(8, "");
			this.ilsMainToolBar.Images.SetKeyName(9, "");
			this.ilsMainToolBar.Images.SetKeyName(10, "");
			this.ilsMainToolBar.Images.SetKeyName(11, "");
			this.toolBarButton1.ImageIndex = 0;
			this.toolBarButton1.Name = "toolBarButton1";
			this.toolBarButton1.Text = "Go";
			this.toolBarButton2.ImageIndex = 2;
			this.toolBarButton2.Name = "toolBarButton2";
			this.toolBarButton2.Text = "Faster";
			this.toolBarButton3.ImageIndex = 3;
			this.toolBarButton3.Name = "toolBarButton3";
			this.toolBarButton3.Text = "Slower";
			this.toolBarButton5.Name = "toolBarButton5";
			this.toolBarButton5.Style = global::System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.toolBarButton6.ImageIndex = 8;
			this.toolBarButton6.Name = "toolBarButton6";
			this.toolBarButton6.Text = "City";
			this.toolBarButton4.Name = "toolBarButton4";
			this.toolBarButton4.Text = "Storefront";
			this.toolBarButton4.Visible = false;
			this.toolBarButton7.Name = "toolBarButton7";
			this.toolBarButton7.Style = global::System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.toolBarButton8.ImageIndex = 4;
			this.toolBarButton8.Name = "toolBarButton8";
			this.toolBarButton8.Text = "Vital Signs";
			this.toolBarButton9.ImageIndex = 11;
			this.toolBarButton9.Name = "toolBarButton9";
			this.toolBarButton9.Text = "Financials";
			this.toolBarButton10.Name = "toolBarButton10";
			this.toolBarButton10.Style = global::System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.toolBarButton11.ImageIndex = 6;
			this.toolBarButton11.Name = "toolBarButton11";
			this.toolBarButton11.Text = "Assignment";
			this.mnuReportsVitalSigns.Index = 0;
			this.mnuReportsVitalSigns.Text = "&Vital Signs";
			this.mnuReportsVitalSigns.Click += new global::System.EventHandler(this.mnuReportsVitalSigns_Click);
			this.mnuReportsFinancials.Index = 1;
			this.mnuReportsFinancials.Text = "&Financials";
			this.mnuReportsFinancials.Click += new global::System.EventHandler(this.mnuReportsFinancials_Click);
			this.mnuActionsNewEntity.Index = 0;
			this.mnuActionsNewEntity.Text = "&Open New Store...";
			this.mnuActionsNewEntity.Click += new global::System.EventHandler(this.mnuActionsNewEntity_Click);
			this.menuItem1.Index = 5;
			this.menuItem1.Text = "-";
			this.mnuReportsActionsJournal.Index = 13;
			this.mnuReportsActionsJournal.Text = "&Actions Journal";
			this.mnuReportsActionsJournal.Click += new global::System.EventHandler(this.mnuReportsActionsJournal_Click);
			this.mnuActionsCloseEntity.Index = 2;
			this.mnuActionsCloseEntity.Text = "&Close Store...";
			this.mnuActionsCloseEntity.Click += new global::System.EventHandler(this.mnuActionsCloseEntity_Click);
			this.menuItem2.Index = 12;
			this.menuItem2.Text = "-";
			this.mnuReportsMarketShare.Index = 6;
			this.mnuReportsMarketShare.Text = "&Market Share";
			this.mnuReportsMarketShare.Click += new global::System.EventHandler(this.mnuReportsMarketShare_Click);
			this.toolBarButton12.ImageIndex = 9;
			this.toolBarButton12.Name = "toolBarButton12";
			this.toolBarButton12.Text = "Store";
			this.toolBarButton13.ImageIndex = 10;
			this.toolBarButton13.Name = "toolBarButton13";
			this.toolBarButton13.Text = "Backroom";
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "-";
			this.menuItem5.Index = 8;
			this.menuItem5.Text = "-";
			this.mnuActionsMarketResearch.Index = 7;
			this.mnuActionsMarketResearch.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuActionsNewSurvey,
				this.mnuActionsSurveyResults
			});
			this.mnuActionsMarketResearch.Text = "Market Research";
			this.mnuActionsNewSurvey.Index = 0;
			this.mnuActionsNewSurvey.Text = "New Survey";
			this.mnuActionsNewSurvey.Click += new global::System.EventHandler(this.mnuActionsNewSurvey_Click);
			this.mnuActionsSurveyResults.Index = 1;
			this.mnuActionsSurveyResults.Text = "Survey Results";
			this.mnuActionsSurveyResults.Click += new global::System.EventHandler(this.mnuActionsSurveyResults_Click);
			this.mnuActionsPricing.Index = 4;
			this.mnuActionsPricing.Text = "Pricing...";
			this.mnuActionsPricing.Click += new global::System.EventHandler(this.mnuActionsPricing_Click);
			this.mnuActionsPromotion.Index = 5;
			this.mnuActionsPromotion.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuActionsPromotionStorefrontAds,
				this.mnuActionsPromotionRadioAdvertising,
				this.mnuActionsPromotionDirectMail,
				this.mnuActionsPromotionBillboardAdvertising
			});
			this.mnuActionsPromotion.Text = "Promotion";
			this.mnuActionsPromotionStorefrontAds.Index = 0;
			this.mnuActionsPromotionStorefrontAds.Text = "Storefront Ads...";
			this.mnuActionsPromotionStorefrontAds.Click += new global::System.EventHandler(this.mnuActionsPromotionStorefrontAds_Click);
			this.mnuActionsPromotionRadioAdvertising.Index = 1;
			this.mnuActionsPromotionRadioAdvertising.Text = "Radio Advertising...";
			this.mnuActionsPromotionRadioAdvertising.Click += new global::System.EventHandler(this.mnuActionsPromotionRadioAdvertising_Click);
			this.mnuActionsPromotionDirectMail.Index = 2;
			this.mnuActionsPromotionDirectMail.Text = "Direct Mail...";
			this.mnuActionsPromotionDirectMail.Click += new global::System.EventHandler(this.mnuActionsPromotionDirectMail_Click);
			this.mnuActionsPromotionBillboardAdvertising.Index = 3;
			this.mnuActionsPromotionBillboardAdvertising.Text = "Billboard Advertising...";
			this.mnuActionsPromotionBillboardAdvertising.Click += new global::System.EventHandler(this.mnuActionsPromotionBillboardAdvertising_Click);
			this.mnuActionsMerchandising.Index = 6;
			this.mnuActionsMerchandising.Text = "Merchandising...";
			this.mnuActionsMerchandising.Click += new global::System.EventHandler(this.mnuActionsMerchandising_Click);
			this.mnuActionsStaffing.Index = 9;
			this.mnuActionsStaffing.Text = "Staffing...";
			this.mnuActionsStaffing.Click += new global::System.EventHandler(this.mnuActionsStaffing_Click);
			this.mnuActionsPurchasing.Index = 10;
			this.mnuActionsPurchasing.Text = "Purchasing...";
			this.mnuActionsPurchasing.Click += new global::System.EventHandler(this.mnuActionsPurchasing_Click);
			this.mnuActionsPhysicalInventory.Index = 13;
			this.mnuActionsPhysicalInventory.Text = "Physical Inventory...";
			this.mnuActionsPhysicalInventory.Click += new global::System.EventHandler(this.mnuActionsPhysicalInventory_Click);
			this.menuItem13.Index = 14;
			this.menuItem13.Text = "-";
			this.mnuActionsTradeCredit.Index = 15;
			this.mnuActionsTradeCredit.Text = "Trade Credit...";
			this.mnuActionsTradeCredit.Click += new global::System.EventHandler(this.mnuActionsTradeCredit_Click);
			this.mnuActionsBankDebt.Index = 16;
			this.mnuActionsBankDebt.MenuItems.AddRange(new global::System.Windows.Forms.MenuItem[]
			{
				this.mnuActionsBankDebtGetLoan,
				this.mnuActionsBankDebtPayLoan
			});
			this.mnuActionsBankDebt.Text = "Bank Debt";
			this.mnuActionsBankDebtGetLoan.Index = 0;
			this.mnuActionsBankDebtGetLoan.Text = "Get Loan...";
			this.mnuActionsBankDebtGetLoan.Click += new global::System.EventHandler(this.mnuActionsBankDebtGetLoan_Click);
			this.mnuActionsBankDebtPayLoan.Index = 1;
			this.mnuActionsBankDebtPayLoan.Text = "Pay Loan...";
			this.mnuActionsBankDebtPayLoan.Click += new global::System.EventHandler(this.mnuActionsBankDebtPayLoan_Click);
			this.mnuActionsTransferCash.Index = 17;
			this.mnuActionsTransferCash.Text = "Transfer Cash...";
			this.mnuActionsTransferCash.Click += new global::System.EventHandler(this.mnuActionsTransferCash_Click);
			this.menuItem19.Index = 18;
			this.menuItem19.Text = "-";
			this.mnuActionsConsultant.Index = 19;
			this.mnuActionsConsultant.Text = "Consultant...";
			this.mnuActionsConsultant.Click += new global::System.EventHandler(this.mnuActionsConsultant_Click);
			this.mnuReportsProducts.Index = 2;
			this.mnuReportsProducts.Text = "Products";
			this.mnuReportsProducts.Click += new global::System.EventHandler(this.mnuReportsProducts_Click);
			this.menuItem7.Index = 3;
			this.menuItem7.Text = "-";
			this.mnuReportsProductAging.Index = 4;
			this.mnuReportsProductAging.Text = "Product Aging";
			this.mnuReportsProductAging.Click += new global::System.EventHandler(this.mnuReportsProductAging_Click);
			this.mnuReportsPopulation.Index = 7;
			this.mnuReportsPopulation.Text = "Population";
			this.mnuReportsPopulation.Click += new global::System.EventHandler(this.mnuReportsPopulation_Click);
			this.toolBarButton14.ImageIndex = 5;
			this.toolBarButton14.Name = "toolBarButton14";
			this.toolBarButton14.Text = "Products";
			this.mnuActionsEquipment.Index = 11;
			this.mnuActionsEquipment.Text = "Equipment...";
			this.mnuActionsEquipment.Click += new global::System.EventHandler(this.mnuActionsEquipment_Click);
			this.frmServiceContracts.Index = 12;
			this.frmServiceContracts.Text = "Service && Repairs...";
			this.frmServiceContracts.Click += new global::System.EventHandler(this.frmServiceContracts_Click);
			this.toolBarButton15.ImageIndex = 7;
			this.toolBarButton15.Name = "toolBarButton15";
			this.toolBarButton15.Text = "Scoreboard";
			this.mnuActionsMoveStore.Index = 1;
			this.mnuActionsMoveStore.Text = "Move Store...";
			this.mnuActionsMoveStore.Click += new global::System.EventHandler(this.mnuActionsMoveStore_Click);
			this.menuItem6.Index = 8;
			this.menuItem6.Text = "-";
			this.mnuReportsAutoGrader.Index = 9;
			this.mnuReportsAutoGrader.Text = "Auto-Grader...";
			this.mnuReportsAutoGrader.Click += new global::System.EventHandler(this.mnuReportsAutoGrader_Click);
			this.mnuReportsMultiStore.Index = 11;
			this.mnuReportsMultiStore.Text = "Multi-Store Report...";
			this.mnuReportsMultiStore.Click += new global::System.EventHandler(this.mnuReportsMultiStore_Click);
			this.menuItem9.Index = 10;
			this.menuItem9.Text = "-";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(717, 358);
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "frmMain";
			this.Text = "";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			((global::System.ComponentModel.ISupportInitialize)this.NewMessagesPanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.DatePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.DayOfWeekPanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.TimePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.CurrentEntityNamePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.CurrentEntityPanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.EntityCriticalResourceNamePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.EntityCriticalResourcePanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.SpacerPanel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.picMain).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000181 RID: 385
		public global::System.Windows.Forms.MenuItem mnuActionsEquipment;

		// Token: 0x04000182 RID: 386
		private global::System.Windows.Forms.MenuItem frmServiceContracts;

		// Token: 0x04000183 RID: 387
		private global::System.Windows.Forms.ToolBarButton toolBarButton15;

		// Token: 0x04000184 RID: 388
		private global::System.Windows.Forms.MenuItem mnuActionsMoveStore;

		// Token: 0x04000185 RID: 389
		private global::System.Windows.Forms.MenuItem menuItem6;

		// Token: 0x04000186 RID: 390
		private global::System.Windows.Forms.MenuItem mnuReportsAutoGrader;

		// Token: 0x04000187 RID: 391
		private global::System.Windows.Forms.MenuItem menuItem9;

		// Token: 0x04000188 RID: 392
		private global::System.Windows.Forms.MenuItem mnuReportsMultiStore;

		// Token: 0x0400018C RID: 396
		private global::System.Windows.Forms.ToolBarButton toolBarButton1;

		// Token: 0x0400018D RID: 397
		private global::System.Windows.Forms.ToolBarButton toolBarButton2;

		// Token: 0x0400018E RID: 398
		private global::System.Windows.Forms.ToolBarButton toolBarButton3;

		// Token: 0x0400018F RID: 399
		private global::System.Windows.Forms.ToolBarButton toolBarButton5;

		// Token: 0x04000190 RID: 400
		private global::System.Windows.Forms.ToolBarButton toolBarButton6;

		// Token: 0x04000191 RID: 401
		private global::System.Windows.Forms.ToolBarButton toolBarButton4;

		// Token: 0x04000192 RID: 402
		private global::System.Windows.Forms.ToolBarButton toolBarButton7;

		// Token: 0x04000193 RID: 403
		private global::System.Windows.Forms.ToolBarButton toolBarButton8;

		// Token: 0x04000194 RID: 404
		private global::System.Windows.Forms.ToolBarButton toolBarButton9;

		// Token: 0x04000195 RID: 405
		private global::System.Windows.Forms.ToolBarButton toolBarButton10;

		// Token: 0x04000196 RID: 406
		private global::System.Windows.Forms.ToolBarButton toolBarButton11;

		// Token: 0x04000197 RID: 407
		private global::System.Windows.Forms.MenuItem mnuReportsVitalSigns;

		// Token: 0x04000198 RID: 408
		private global::System.Windows.Forms.MenuItem mnuReportsFinancials;

		// Token: 0x04000199 RID: 409
		private global::System.Windows.Forms.MenuItem mnuActionsNewEntity;

		// Token: 0x0400019A RID: 410
		private global::System.Windows.Forms.MenuItem menuItem1;

		// Token: 0x0400019B RID: 411
		private global::System.Windows.Forms.MenuItem mnuReportsActionsJournal;

		// Token: 0x0400019C RID: 412
		private global::System.Windows.Forms.MenuItem mnuActionsCloseEntity;

		// Token: 0x0400019D RID: 413
		private global::System.Windows.Forms.MenuItem menuItem2;

		// Token: 0x0400019E RID: 414
		private global::System.Windows.Forms.MenuItem mnuReportsMarketShare;

		// Token: 0x0400019F RID: 415
		private global::System.Windows.Forms.ToolBarButton toolBarButton12;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.ToolBarButton toolBarButton13;

		// Token: 0x040001A1 RID: 417
		private global::System.Windows.Forms.MenuItem menuItem4;

		// Token: 0x040001A2 RID: 418
		private global::System.Windows.Forms.MenuItem menuItem5;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.MenuItem mnuActionsMarketResearch;

		// Token: 0x040001A4 RID: 420
		private global::System.Windows.Forms.MenuItem mnuActionsNewSurvey;

		// Token: 0x040001A5 RID: 421
		private global::System.Windows.Forms.MenuItem mnuActionsSurveyResults;

		// Token: 0x040001A6 RID: 422
		public global::System.Windows.Forms.MenuItem mnuActionsPricing;

		// Token: 0x040001A7 RID: 423
		private global::System.Windows.Forms.MenuItem mnuActionsPromotion;

		// Token: 0x040001A8 RID: 424
		public global::System.Windows.Forms.MenuItem mnuActionsMerchandising;

		// Token: 0x040001A9 RID: 425
		private global::System.Windows.Forms.MenuItem mnuActionsStaffing;

		// Token: 0x040001AA RID: 426
		public global::System.Windows.Forms.MenuItem mnuActionsPurchasing;

		// Token: 0x040001AB RID: 427
		private global::System.Windows.Forms.MenuItem mnuActionsPhysicalInventory;

		// Token: 0x040001AC RID: 428
		private global::System.Windows.Forms.MenuItem menuItem13;

		// Token: 0x040001AD RID: 429
		private global::System.Windows.Forms.MenuItem mnuActionsTradeCredit;

		// Token: 0x040001AE RID: 430
		private global::System.Windows.Forms.MenuItem mnuActionsBankDebt;

		// Token: 0x040001AF RID: 431
		private global::System.Windows.Forms.MenuItem mnuActionsBankDebtGetLoan;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.MenuItem mnuActionsBankDebtPayLoan;

		// Token: 0x040001B1 RID: 433
		private global::System.Windows.Forms.MenuItem mnuActionsTransferCash;

		// Token: 0x040001B2 RID: 434
		private global::System.Windows.Forms.MenuItem menuItem19;

		// Token: 0x040001B3 RID: 435
		private global::System.Windows.Forms.MenuItem mnuActionsConsultant;

		// Token: 0x040001B4 RID: 436
		private global::System.Windows.Forms.MenuItem mnuActionsPromotionRadioAdvertising;

		// Token: 0x040001B5 RID: 437
		public global::System.Windows.Forms.MenuItem mnuActionsPromotionStorefrontAds;

		// Token: 0x040001B6 RID: 438
		private global::System.Windows.Forms.MenuItem mnuActionsPromotionDirectMail;

		// Token: 0x040001B7 RID: 439
		private global::System.Windows.Forms.MenuItem mnuActionsPromotionBillboardAdvertising;

		// Token: 0x040001B8 RID: 440
		private global::System.Windows.Forms.MenuItem menuItem7;

		// Token: 0x040001B9 RID: 441
		private global::System.Windows.Forms.ToolBarButton toolBarButton14;

		// Token: 0x040001BA RID: 442
		private global::System.Windows.Forms.MenuItem mnuReportsProducts;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.MenuItem mnuReportsProductAging;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.MenuItem mnuReportsPopulation;

		// Token: 0x040001BD RID: 445
		private global::System.ComponentModel.IContainer components = null;
	}
}
