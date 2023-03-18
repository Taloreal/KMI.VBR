using System;
using KMI.Sim;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// A collection of fields and properpties that alter simulation
	/// settings for the application.  These properties can be
	/// altered during runtime via reflectiona and a hidden screen that
	/// exposes these properties and their values. 
	/// </summary>
	// Token: 0x02000049 RID: 73
	[Serializable]
	public class AppSimSettings : SimSettings
	{
		/// <summary>
		/// Default Constructor.
		/// </summary>
		// Token: 0x06000235 RID: 565 RVA: 0x00020F04 File Offset: 0x0001FF04
		public AppSimSettings()
		{
			this.startDate = new DateTime(2011, 12, 31, 23, 59, 59);
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000236 RID: 566 RVA: 0x000211E0 File Offset: 0x000201E0
		// (set) Token: 0x06000237 RID: 567 RVA: 0x000211F8 File Offset: 0x000201F8
		public bool ExpireGoods
		{
			get
			{
				return this.expireGoods;
			}
			set
			{
				this.expireGoods = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00021204 File Offset: 0x00020204
		// (set) Token: 0x06000239 RID: 569 RVA: 0x0002121C File Offset: 0x0002021C
		public bool Shoplifting
		{
			get
			{
				return this.shoplifting;
			}
			set
			{
				this.shoplifting = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600023A RID: 570 RVA: 0x00021228 File Offset: 0x00020228
		// (set) Token: 0x0600023B RID: 571 RVA: 0x00021240 File Offset: 0x00020240
		public bool MachineFailures
		{
			get
			{
				return this.machineFailures;
			}
			set
			{
				this.machineFailures = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0002124C File Offset: 0x0002024C
		// (set) Token: 0x0600023D RID: 573 RVA: 0x00021264 File Offset: 0x00020264
		public float PctNeedsDesired
		{
			get
			{
				return this.pctNeedsDesired;
			}
			set
			{
				this.pctNeedsDesired = value;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00021270 File Offset: 0x00020270
		// (set) Token: 0x0600023F RID: 575 RVA: 0x00021288 File Offset: 0x00020288
		public float PctImpulseDesired
		{
			get
			{
				return this.pctImpulseDesired;
			}
			set
			{
				this.pctImpulseDesired = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000240 RID: 576 RVA: 0x00021294 File Offset: 0x00020294
		// (set) Token: 0x06000241 RID: 577 RVA: 0x000212AC File Offset: 0x000202AC
		public float InitialAIMargin
		{
			get
			{
				return this.initialAIMargin;
			}
			set
			{
				this.initialAIMargin = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000242 RID: 578 RVA: 0x000212B8 File Offset: 0x000202B8
		// (set) Token: 0x06000243 RID: 579 RVA: 0x000212D0 File Offset: 0x000202D0
		public float MinAcceptableUtility
		{
			get
			{
				return this.minAcceptableUtility;
			}
			set
			{
				this.minAcceptableUtility = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000244 RID: 580 RVA: 0x000212DC File Offset: 0x000202DC
		// (set) Token: 0x06000245 RID: 581 RVA: 0x000212F4 File Offset: 0x000202F4
		public int MaxImpressionsNeeded
		{
			get
			{
				return this.maxImpressionsNeeded;
			}
			set
			{
				this.maxImpressionsNeeded = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00021300 File Offset: 0x00020300
		// (set) Token: 0x06000247 RID: 583 RVA: 0x00021318 File Offset: 0x00020318
		public float AdvertisingMultiplier
		{
			get
			{
				return this.advertisingMultiplier;
			}
			set
			{
				this.advertisingMultiplier = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000248 RID: 584 RVA: 0x00021324 File Offset: 0x00020324
		// (set) Token: 0x06000249 RID: 585 RVA: 0x0002133C File Offset: 0x0002033C
		public float MaxDistPasserBy
		{
			get
			{
				return this.maxDistPasserBy;
			}
			set
			{
				this.maxDistPasserBy = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00021348 File Offset: 0x00020348
		// (set) Token: 0x0600024B RID: 587 RVA: 0x00021360 File Offset: 0x00020360
		public float PercentWindowShoppers
		{
			get
			{
				return this.percentWindowShoppers;
			}
			set
			{
				this.percentWindowShoppers = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0002136C File Offset: 0x0002036C
		// (set) Token: 0x0600024D RID: 589 RVA: 0x00021384 File Offset: 0x00020384
		public bool AutoStockInitialShelves
		{
			get
			{
				return this.autoStockInitialShelves;
			}
			set
			{
				this.autoStockInitialShelves = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600024E RID: 590 RVA: 0x00021390 File Offset: 0x00020390
		// (set) Token: 0x0600024F RID: 591 RVA: 0x000213A8 File Offset: 0x000203A8
		public float InitialAICapital
		{
			get
			{
				return this.initialAICapital;
			}
			set
			{
				this.initialAICapital = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000250 RID: 592 RVA: 0x000213B4 File Offset: 0x000203B4
		// (set) Token: 0x06000251 RID: 593 RVA: 0x000213CC File Offset: 0x000203CC
		public float InitialHumanCapital
		{
			get
			{
				return this.initialHumanCapital;
			}
			set
			{
				this.initialHumanCapital = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000252 RID: 594 RVA: 0x000213D8 File Offset: 0x000203D8
		// (set) Token: 0x06000253 RID: 595 RVA: 0x000213F0 File Offset: 0x000203F0
		public string MigrationType
		{
			get
			{
				return this.migrationType;
			}
			set
			{
				this.migrationType = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000254 RID: 596 RVA: 0x000213FC File Offset: 0x000203FC
		// (set) Token: 0x06000255 RID: 597 RVA: 0x00021414 File Offset: 0x00020414
		public float MigrationRate
		{
			get
			{
				return this.migrationRate;
			}
			set
			{
				this.migrationRate = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00021420 File Offset: 0x00020420
		// (set) Token: 0x06000257 RID: 599 RVA: 0x00021438 File Offset: 0x00020438
		public int PreferredMigrationDemographic
		{
			get
			{
				return this.preferredMigrationDemographic;
			}
			set
			{
				this.preferredMigrationDemographic = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00021444 File Offset: 0x00020444
		// (set) Token: 0x06000259 RID: 601 RVA: 0x0002145C File Offset: 0x0002045C
		public DateTime NextConstruction
		{
			get
			{
				return this.nextConstruction;
			}
			set
			{
				this.nextConstruction = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600025A RID: 602 RVA: 0x00021468 File Offset: 0x00020468
		// (set) Token: 0x0600025B RID: 603 RVA: 0x00021480 File Offset: 0x00020480
		public DateTime CoolerBreakDate
		{
			get
			{
				return this.coolerBreakDate;
			}
			set
			{
				this.coolerBreakDate = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600025C RID: 604 RVA: 0x0002148C File Offset: 0x0002048C
		// (set) Token: 0x0600025D RID: 605 RVA: 0x000214A4 File Offset: 0x000204A4
		public int ConstructionDays
		{
			get
			{
				return this.constructionDays;
			}
			set
			{
				this.constructionDays = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600025E RID: 606 RVA: 0x000214B0 File Offset: 0x000204B0
		// (set) Token: 0x0600025F RID: 607 RVA: 0x000214C8 File Offset: 0x000204C8
		public bool SnowStorms
		{
			get
			{
				return this.snowStorms;
			}
			set
			{
				this.snowStorms = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000260 RID: 608 RVA: 0x000214D4 File Offset: 0x000204D4
		// (set) Token: 0x06000261 RID: 609 RVA: 0x000214EC File Offset: 0x000204EC
		public float ZoningDistinctness
		{
			get
			{
				return this.zoningDistinctness;
			}
			set
			{
				this.zoningDistinctness = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000262 RID: 610 RVA: 0x000214F8 File Offset: 0x000204F8
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00021510 File Offset: 0x00020510
		public float ZoningRandomness
		{
			get
			{
				return this.zoningRandomness;
			}
			set
			{
				this.zoningRandomness = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000264 RID: 612 RVA: 0x0002151C File Offset: 0x0002051C
		// (set) Token: 0x06000265 RID: 613 RVA: 0x00021534 File Offset: 0x00020534
		public int InitialCustomers
		{
			get
			{
				return this.initialCustomers;
			}
			set
			{
				this.initialCustomers = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000266 RID: 614 RVA: 0x00021540 File Offset: 0x00020540
		// (set) Token: 0x06000267 RID: 615 RVA: 0x00021558 File Offset: 0x00020558
		public int InitialAIPlayers
		{
			get
			{
				return this.initialAIPlayers;
			}
			set
			{
				this.initialAIPlayers = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00021564 File Offset: 0x00020564
		// (set) Token: 0x06000269 RID: 617 RVA: 0x0002157C File Offset: 0x0002057C
		public bool RestrictFixtures
		{
			get
			{
				return this.restrictFixtures;
			}
			set
			{
				this.restrictFixtures = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00021588 File Offset: 0x00020588
		// (set) Token: 0x0600026B RID: 619 RVA: 0x000215A0 File Offset: 0x000205A0
		public bool StoreEnabledForOwner
		{
			get
			{
				return this.floorEnabledForOwner;
			}
			set
			{
				this.floorEnabledForOwner = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600026C RID: 620 RVA: 0x000215AC File Offset: 0x000205AC
		// (set) Token: 0x0600026D RID: 621 RVA: 0x000215C4 File Offset: 0x000205C4
		public bool BackroomEnabledForOwner
		{
			get
			{
				return this.backroomEnabledForOwner;
			}
			set
			{
				this.backroomEnabledForOwner = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600026E RID: 622 RVA: 0x000215D0 File Offset: 0x000205D0
		// (set) Token: 0x0600026F RID: 623 RVA: 0x000215E8 File Offset: 0x000205E8
		public bool VitalSignsEnabledForOwner
		{
			get
			{
				return this.vitalSignsEnabledForOwner;
			}
			set
			{
				this.vitalSignsEnabledForOwner = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000270 RID: 624 RVA: 0x000215F4 File Offset: 0x000205F4
		// (set) Token: 0x06000271 RID: 625 RVA: 0x0002160C File Offset: 0x0002060C
		public bool FinancialsEnabledForOwner
		{
			get
			{
				return this.financialsEnabledForOwner;
			}
			set
			{
				this.financialsEnabledForOwner = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000272 RID: 626 RVA: 0x00021618 File Offset: 0x00020618
		// (set) Token: 0x06000273 RID: 627 RVA: 0x00021630 File Offset: 0x00020630
		public bool ProductsEnabledForOwner
		{
			get
			{
				return this.productsEnabledForOwner;
			}
			set
			{
				this.productsEnabledForOwner = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000274 RID: 628 RVA: 0x0002163C File Offset: 0x0002063C
		// (set) Token: 0x06000275 RID: 629 RVA: 0x00021654 File Offset: 0x00020654
		public bool CommentLogEnabledForOwner
		{
			get
			{
				return this.commentLogEnabledForOwner;
			}
			set
			{
				this.commentLogEnabledForOwner = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000276 RID: 630 RVA: 0x00021660 File Offset: 0x00020660
		// (set) Token: 0x06000277 RID: 631 RVA: 0x00021678 File Offset: 0x00020678
		public bool ProductAgingEnabledForOwner
		{
			get
			{
				return this.productAgingEnabledForOwner;
			}
			set
			{
				this.productAgingEnabledForOwner = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000278 RID: 632 RVA: 0x00021684 File Offset: 0x00020684
		// (set) Token: 0x06000279 RID: 633 RVA: 0x0002169C File Offset: 0x0002069C
		public bool AutoGraderEnabledForOwner
		{
			get
			{
				return this.autoGraderEnabledForOwner;
			}
			set
			{
				this.autoGraderEnabledForOwner = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600027A RID: 634 RVA: 0x000216A8 File Offset: 0x000206A8
		// (set) Token: 0x0600027B RID: 635 RVA: 0x000216C0 File Offset: 0x000206C0
		public bool MultiStoreReportEnabledForOwner
		{
			get
			{
				return this.multiStoreReportEnabledForOwner;
			}
			set
			{
				this.multiStoreReportEnabledForOwner = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600027C RID: 636 RVA: 0x000216CC File Offset: 0x000206CC
		// (set) Token: 0x0600027D RID: 637 RVA: 0x000216E4 File Offset: 0x000206E4
		public bool ActionsJournalEnabledForOwner
		{
			get
			{
				return this.actionsJournalEnabledForOwner;
			}
			set
			{
				this.actionsJournalEnabledForOwner = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600027E RID: 638 RVA: 0x000216F0 File Offset: 0x000206F0
		// (set) Token: 0x0600027F RID: 639 RVA: 0x00021708 File Offset: 0x00020708
		public bool OpenNewStoreEnabledForOwner
		{
			get
			{
				return this.openNewStoreEnabledForOwner;
			}
			set
			{
				this.openNewStoreEnabledForOwner = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00021714 File Offset: 0x00020714
		// (set) Token: 0x06000281 RID: 641 RVA: 0x0002172C File Offset: 0x0002072C
		public bool MoveStoreEnabledForOwner
		{
			get
			{
				return this.moveStoreEnabledForOwner;
			}
			set
			{
				this.moveStoreEnabledForOwner = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000282 RID: 642 RVA: 0x00021738 File Offset: 0x00020738
		// (set) Token: 0x06000283 RID: 643 RVA: 0x00021750 File Offset: 0x00020750
		public bool CloseStoreEnabledForOwner
		{
			get
			{
				return this.closeStoreEnabledForOwner;
			}
			set
			{
				this.closeStoreEnabledForOwner = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000284 RID: 644 RVA: 0x0002175C File Offset: 0x0002075C
		// (set) Token: 0x06000285 RID: 645 RVA: 0x00021774 File Offset: 0x00020774
		public bool PricingEnabledForOwner
		{
			get
			{
				return this.pricingEnabledForOwner;
			}
			set
			{
				this.pricingEnabledForOwner = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00021780 File Offset: 0x00020780
		// (set) Token: 0x06000287 RID: 647 RVA: 0x00021798 File Offset: 0x00020798
		public bool StorefrontAdsEnabledForOwner
		{
			get
			{
				return this.storefrontAdsEnabledForOwner;
			}
			set
			{
				this.storefrontAdsEnabledForOwner = value;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000288 RID: 648 RVA: 0x000217A4 File Offset: 0x000207A4
		// (set) Token: 0x06000289 RID: 649 RVA: 0x000217BC File Offset: 0x000207BC
		public bool DirectMailEnabledForOwner
		{
			get
			{
				return this.directMailEnabledForOwner;
			}
			set
			{
				this.directMailEnabledForOwner = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600028A RID: 650 RVA: 0x000217C8 File Offset: 0x000207C8
		// (set) Token: 0x0600028B RID: 651 RVA: 0x000217E0 File Offset: 0x000207E0
		public bool RadioAdvertisingEnabledForOwner
		{
			get
			{
				return this.radioAdvertisingEnabledForOwner;
			}
			set
			{
				this.radioAdvertisingEnabledForOwner = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600028C RID: 652 RVA: 0x000217EC File Offset: 0x000207EC
		// (set) Token: 0x0600028D RID: 653 RVA: 0x00021804 File Offset: 0x00020804
		public bool BillboardAdvertisingEnabledForOwner
		{
			get
			{
				return this.billboardAdvertisingEnabledForOwner;
			}
			set
			{
				this.billboardAdvertisingEnabledForOwner = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600028E RID: 654 RVA: 0x00021810 File Offset: 0x00020810
		// (set) Token: 0x0600028F RID: 655 RVA: 0x00021828 File Offset: 0x00020828
		public bool MerchandisingEnabledForOwner
		{
			get
			{
				return this.merchandisingEnabledForOwner;
			}
			set
			{
				this.merchandisingEnabledForOwner = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000290 RID: 656 RVA: 0x00021834 File Offset: 0x00020834
		// (set) Token: 0x06000291 RID: 657 RVA: 0x0002184C File Offset: 0x0002084C
		public bool NewSurveyEnabledForOwner
		{
			get
			{
				return this.newSurveyEnabledForOwner;
			}
			set
			{
				this.newSurveyEnabledForOwner = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00021858 File Offset: 0x00020858
		// (set) Token: 0x06000293 RID: 659 RVA: 0x00021870 File Offset: 0x00020870
		public bool SurveyResultsEnabledForOwner
		{
			get
			{
				return this.surveyResultsEnabledForOwner;
			}
			set
			{
				this.surveyResultsEnabledForOwner = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000294 RID: 660 RVA: 0x0002187C File Offset: 0x0002087C
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00021894 File Offset: 0x00020894
		public bool StaffingEnabledForOwner
		{
			get
			{
				return this.staffingEnabledForOwner;
			}
			set
			{
				this.staffingEnabledForOwner = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000296 RID: 662 RVA: 0x000218A0 File Offset: 0x000208A0
		// (set) Token: 0x06000297 RID: 663 RVA: 0x000218B8 File Offset: 0x000208B8
		public bool PurchasingEnabledForOwner
		{
			get
			{
				return this.purchasingEnabledForOwner;
			}
			set
			{
				this.purchasingEnabledForOwner = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000298 RID: 664 RVA: 0x000218C4 File Offset: 0x000208C4
		// (set) Token: 0x06000299 RID: 665 RVA: 0x000218DC File Offset: 0x000208DC
		public bool EquipmentEnabledForOwner
		{
			get
			{
				return this.equipmentEnabledForOwner;
			}
			set
			{
				this.equipmentEnabledForOwner = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600029A RID: 666 RVA: 0x000218E8 File Offset: 0x000208E8
		// (set) Token: 0x0600029B RID: 667 RVA: 0x00021900 File Offset: 0x00020900
		public bool ServiceRepairsEnabledForOwner
		{
			get
			{
				return this.serviceRepairsEnabledForOwner;
			}
			set
			{
				this.serviceRepairsEnabledForOwner = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600029C RID: 668 RVA: 0x0002190C File Offset: 0x0002090C
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00021924 File Offset: 0x00020924
		public bool PhysicalInventoryEnabledForOwner
		{
			get
			{
				return this.physicalInventoryEnabledForOwner;
			}
			set
			{
				this.physicalInventoryEnabledForOwner = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600029E RID: 670 RVA: 0x00021930 File Offset: 0x00020930
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00021948 File Offset: 0x00020948
		public bool TradeCreditEnabledForOwner
		{
			get
			{
				return this.tradeCreditEnabledForOwner;
			}
			set
			{
				this.tradeCreditEnabledForOwner = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00021954 File Offset: 0x00020954
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x0002196C File Offset: 0x0002096C
		public bool GetLoanEnabledForOwner
		{
			get
			{
				return this.getLoanEnabledForOwner;
			}
			set
			{
				this.getLoanEnabledForOwner = value;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x00021978 File Offset: 0x00020978
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00021990 File Offset: 0x00020990
		public bool PayLoanEnabledForOwner
		{
			get
			{
				return this.payLoanEnabledForOwner;
			}
			set
			{
				this.payLoanEnabledForOwner = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x0002199C File Offset: 0x0002099C
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x000219B4 File Offset: 0x000209B4
		public bool TransferCashEnabledForOwner
		{
			get
			{
				return this.transferCashEnabledForOwner;
			}
			set
			{
				this.transferCashEnabledForOwner = value;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x000219C0 File Offset: 0x000209C0
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x000219D8 File Offset: 0x000209D8
		public bool ConsultantEnabledForOwner
		{
			get
			{
				return this.consultantEnabledForOwner;
			}
			set
			{
				this.consultantEnabledForOwner = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x000219E4 File Offset: 0x000209E4
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x000219FC File Offset: 0x000209FC
		public bool StoreEnabledForNonOwner
		{
			get
			{
				return this.floorEnabledForNonOwner;
			}
			set
			{
				this.floorEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00021A08 File Offset: 0x00020A08
		// (set) Token: 0x060002AB RID: 683 RVA: 0x00021A20 File Offset: 0x00020A20
		public bool BackroomEnabledForNonOwner
		{
			get
			{
				return this.backroomEnabledForNonOwner;
			}
			set
			{
				this.backroomEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00021A2C File Offset: 0x00020A2C
		// (set) Token: 0x060002AD RID: 685 RVA: 0x00021A44 File Offset: 0x00020A44
		public bool VitalSignsEnabledForNonOwner
		{
			get
			{
				return this.vitalSignsEnabledForNonOwner;
			}
			set
			{
				this.vitalSignsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002AE RID: 686 RVA: 0x00021A50 File Offset: 0x00020A50
		// (set) Token: 0x060002AF RID: 687 RVA: 0x00021A68 File Offset: 0x00020A68
		public bool FinancialsEnabledForNonOwner
		{
			get
			{
				return this.financialsEnabledForNonOwner;
			}
			set
			{
				this.financialsEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00021A74 File Offset: 0x00020A74
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x00021A8C File Offset: 0x00020A8C
		public bool ProductsEnabledForNonOwner
		{
			get
			{
				return this.productsEnabledForNonOwner;
			}
			set
			{
				this.productsEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00021A98 File Offset: 0x00020A98
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x00021AB0 File Offset: 0x00020AB0
		public bool CommentLogEnabledForNonOwner
		{
			get
			{
				return this.commentLogEnabledForNonOwner;
			}
			set
			{
				this.commentLogEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x00021ABC File Offset: 0x00020ABC
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x00021AD4 File Offset: 0x00020AD4
		public bool ProductAgingEnabledForNonOwner
		{
			get
			{
				return this.productAgingEnabledForNonOwner;
			}
			set
			{
				this.productAgingEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x00021AE0 File Offset: 0x00020AE0
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x00021AF8 File Offset: 0x00020AF8
		public bool AutoGraderEnabledForNonOwner
		{
			get
			{
				return this.autoGraderEnabledForNonOwner;
			}
			set
			{
				this.autoGraderEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00021B04 File Offset: 0x00020B04
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00021B1C File Offset: 0x00020B1C
		public bool MultiStoreReportEnabledForNonOwner
		{
			get
			{
				return this.multiStoreReportEnabledForNonOwner;
			}
			set
			{
				this.multiStoreReportEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00021B28 File Offset: 0x00020B28
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00021B40 File Offset: 0x00020B40
		public bool ActionsJournalEnabledForNonOwner
		{
			get
			{
				return this.actionsJournalEnabledForNonOwner;
			}
			set
			{
				this.actionsJournalEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00021B4C File Offset: 0x00020B4C
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00021B64 File Offset: 0x00020B64
		public bool OpenNewStoreEnabledForNonOwner
		{
			get
			{
				return this.openNewStoreEnabledForNonOwner;
			}
			set
			{
				this.openNewStoreEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00021B70 File Offset: 0x00020B70
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00021B88 File Offset: 0x00020B88
		public bool MoveStoreEnabledForNonOwner
		{
			get
			{
				return this.moveStoreEnabledForNonOwner;
			}
			set
			{
				this.moveStoreEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00021B94 File Offset: 0x00020B94
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00021BAC File Offset: 0x00020BAC
		public bool CloseStoreEnabledForNonOwner
		{
			get
			{
				return this.closeStoreEnabledForNonOwner;
			}
			set
			{
				this.closeStoreEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00021BB8 File Offset: 0x00020BB8
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00021BD0 File Offset: 0x00020BD0
		public bool PricingEnabledForNonOwner
		{
			get
			{
				return this.pricingEnabledForNonOwner;
			}
			set
			{
				this.pricingEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00021BDC File Offset: 0x00020BDC
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00021BF4 File Offset: 0x00020BF4
		public bool StorefrontAdsEnabledForNonOwner
		{
			get
			{
				return this.storefrontAdsEnabledForNonOwner;
			}
			set
			{
				this.storefrontAdsEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00021C00 File Offset: 0x00020C00
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00021C18 File Offset: 0x00020C18
		public bool DirectMailEnabledForNonOwner
		{
			get
			{
				return this.directMailEnabledForNonOwner;
			}
			set
			{
				this.directMailEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00021C24 File Offset: 0x00020C24
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00021C3C File Offset: 0x00020C3C
		public bool RadioAdvertisingEnabledForNonOwner
		{
			get
			{
				return this.radioAdvertisingEnabledForNonOwner;
			}
			set
			{
				this.radioAdvertisingEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00021C48 File Offset: 0x00020C48
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00021C60 File Offset: 0x00020C60
		public bool BillboardAdvertisingEnabledForNonOwner
		{
			get
			{
				return this.billboardAdvertisingEnabledForNonOwner;
			}
			set
			{
				this.billboardAdvertisingEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00021C6C File Offset: 0x00020C6C
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00021C84 File Offset: 0x00020C84
		public bool MerchandisingEnabledForNonOwner
		{
			get
			{
				return this.merchandisingEnabledForNonOwner;
			}
			set
			{
				this.merchandisingEnabledForNonOwner = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002CE RID: 718 RVA: 0x00021C90 File Offset: 0x00020C90
		// (set) Token: 0x060002CF RID: 719 RVA: 0x00021CA8 File Offset: 0x00020CA8
		public bool NewSurveyEnabledForNonOwner
		{
			get
			{
				return this.newSurveyEnabledForNonOwner;
			}
			set
			{
				this.newSurveyEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x00021CB4 File Offset: 0x00020CB4
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x00021CCC File Offset: 0x00020CCC
		public bool SurveyResultsEnabledForNonOwner
		{
			get
			{
				return this.surveyResultsEnabledForNonOwner;
			}
			set
			{
				this.surveyResultsEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00021CD8 File Offset: 0x00020CD8
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00021CF0 File Offset: 0x00020CF0
		public bool StaffingEnabledForNonOwner
		{
			get
			{
				return this.staffingEnabledForNonOwner;
			}
			set
			{
				this.staffingEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00021CFC File Offset: 0x00020CFC
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x00021D14 File Offset: 0x00020D14
		public bool PurchasingEnabledForNonOwner
		{
			get
			{
				return this.purchasingEnabledForNonOwner;
			}
			set
			{
				this.purchasingEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00021D20 File Offset: 0x00020D20
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00021D38 File Offset: 0x00020D38
		public bool EquipmentEnabledForNonOwner
		{
			get
			{
				return this.equipmentEnabledForNonOwner;
			}
			set
			{
				this.equipmentEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00021D44 File Offset: 0x00020D44
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00021D5C File Offset: 0x00020D5C
		public bool ServiceRepairsEnabledForNonOwner
		{
			get
			{
				return this.serviceRepairsEnabledForNonOwner;
			}
			set
			{
				this.serviceRepairsEnabledForNonOwner = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002DA RID: 730 RVA: 0x00021D68 File Offset: 0x00020D68
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00021D80 File Offset: 0x00020D80
		public bool PhysicalInventoryEnabledForNonOwner
		{
			get
			{
				return this.physicalInventoryEnabledForNonOwner;
			}
			set
			{
				this.physicalInventoryEnabledForNonOwner = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002DC RID: 732 RVA: 0x00021D8C File Offset: 0x00020D8C
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00021DA4 File Offset: 0x00020DA4
		public bool TradeCreditEnabledForNonOwner
		{
			get
			{
				return this.tradeCreditEnabledForNonOwner;
			}
			set
			{
				this.tradeCreditEnabledForNonOwner = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00021DB0 File Offset: 0x00020DB0
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00021DC8 File Offset: 0x00020DC8
		public bool GetLoanEnabledForNonOwner
		{
			get
			{
				return this.getLoanEnabledForNonOwner;
			}
			set
			{
				this.getLoanEnabledForNonOwner = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00021DD4 File Offset: 0x00020DD4
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00021DEC File Offset: 0x00020DEC
		public bool PayLoanEnabledForNonOwner
		{
			get
			{
				return this.payLoanEnabledForNonOwner;
			}
			set
			{
				this.payLoanEnabledForNonOwner = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00021DF8 File Offset: 0x00020DF8
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x00021E10 File Offset: 0x00020E10
		public bool TransferCashEnabledForNonOwner
		{
			get
			{
				return this.transferCashEnabledForNonOwner;
			}
			set
			{
				this.transferCashEnabledForNonOwner = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x00021E1C File Offset: 0x00020E1C
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x00021E34 File Offset: 0x00020E34
		public bool ConsultantEnabledForNonOwner
		{
			get
			{
				return this.consultantEnabledForNonOwner;
			}
			set
			{
				this.consultantEnabledForNonOwner = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x00021E40 File Offset: 0x00020E40
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x00021E58 File Offset: 0x00020E58
		public override int Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
				if (this.level == 2)
				{
					A.SS.SnowStorms = true;
					A.SS.MachineFailures = true;
				}
				if (this.level == 3)
				{
					this.MigrationType = "Cycle";
					A.SS.NextConstruction = A.ST.Now.AddDays((double)(90 + A.ST.Random.Next(90)));
				}
			}
		}

		// Token: 0x04000223 RID: 547
		protected bool expireGoods = true;

		// Token: 0x04000224 RID: 548
		protected bool shoplifting = true;

		// Token: 0x04000225 RID: 549
		protected bool machineFailures = false;

		// Token: 0x04000226 RID: 550
		protected float pctNeedsDesired = 0.5f;

		// Token: 0x04000227 RID: 551
		protected float pctImpulseDesired = 0.5f;

		// Token: 0x04000228 RID: 552
		protected float initialAIMargin = 0.35f;

		// Token: 0x04000229 RID: 553
		protected float minAcceptableUtility = 0f;

		// Token: 0x0400022A RID: 554
		protected int maxImpressionsNeeded = 6;

		// Token: 0x0400022B RID: 555
		protected float advertisingMultiplier = 1f;

		// Token: 0x0400022C RID: 556
		protected float maxDistPasserBy = 5f;

		// Token: 0x0400022D RID: 557
		protected float percentWindowShoppers = 0.25f;

		// Token: 0x0400022E RID: 558
		protected bool autoStockInitialShelves = false;

		// Token: 0x0400022F RID: 559
		protected float initialAICapital = 800000f;

		// Token: 0x04000230 RID: 560
		protected float initialHumanCapital = 100000f;

		// Token: 0x04000231 RID: 561
		protected string migrationType = "None";

		// Token: 0x04000232 RID: 562
		protected float migrationRate = 2f;

		// Token: 0x04000233 RID: 563
		protected int preferredMigrationDemographic = -1;

		// Token: 0x04000234 RID: 564
		protected DateTime nextConstruction = DateTime.MaxValue;

		// Token: 0x04000235 RID: 565
		protected DateTime coolerBreakDate = DateTime.MaxValue;

		// Token: 0x04000236 RID: 566
		protected int constructionDays = 180;

		// Token: 0x04000237 RID: 567
		protected bool snowStorms = false;

		// Token: 0x04000238 RID: 568
		protected float zoningDistinctness = 1f;

		// Token: 0x04000239 RID: 569
		protected float zoningRandomness = 0f;

		// Token: 0x0400023A RID: 570
		protected int initialCustomers = 600;

		// Token: 0x0400023B RID: 571
		protected int initialAIPlayers = 1;

		// Token: 0x0400023C RID: 572
		protected bool restrictFixtures = false;

		// Token: 0x0400023D RID: 573
		protected bool floorEnabledForOwner = true;

		// Token: 0x0400023E RID: 574
		protected bool backroomEnabledForOwner = true;

		// Token: 0x0400023F RID: 575
		protected bool vitalSignsEnabledForOwner = true;

		// Token: 0x04000240 RID: 576
		protected bool financialsEnabledForOwner = true;

		// Token: 0x04000241 RID: 577
		protected bool productsEnabledForOwner = true;

		// Token: 0x04000242 RID: 578
		protected bool commentLogEnabledForOwner = true;

		// Token: 0x04000243 RID: 579
		protected bool productAgingEnabledForOwner = true;

		// Token: 0x04000244 RID: 580
		protected bool autoGraderEnabledForOwner = true;

		// Token: 0x04000245 RID: 581
		protected bool multiStoreReportEnabledForOwner = true;

		// Token: 0x04000246 RID: 582
		protected bool actionsJournalEnabledForOwner = true;

		// Token: 0x04000247 RID: 583
		protected bool openNewStoreEnabledForOwner = true;

		// Token: 0x04000248 RID: 584
		protected bool moveStoreEnabledForOwner = true;

		// Token: 0x04000249 RID: 585
		protected bool closeStoreEnabledForOwner = true;

		// Token: 0x0400024A RID: 586
		protected bool pricingEnabledForOwner = true;

		// Token: 0x0400024B RID: 587
		protected bool storefrontAdsEnabledForOwner = true;

		// Token: 0x0400024C RID: 588
		protected bool directMailEnabledForOwner = true;

		// Token: 0x0400024D RID: 589
		protected bool radioAdvertisingEnabledForOwner = true;

		// Token: 0x0400024E RID: 590
		protected bool billboardAdvertisingEnabledForOwner = true;

		// Token: 0x0400024F RID: 591
		protected bool merchandisingEnabledForOwner = true;

		// Token: 0x04000250 RID: 592
		protected bool newSurveyEnabledForOwner = true;

		// Token: 0x04000251 RID: 593
		protected bool surveyResultsEnabledForOwner = true;

		// Token: 0x04000252 RID: 594
		protected bool staffingEnabledForOwner = true;

		// Token: 0x04000253 RID: 595
		protected bool purchasingEnabledForOwner = true;

		// Token: 0x04000254 RID: 596
		protected bool equipmentEnabledForOwner = true;

		// Token: 0x04000255 RID: 597
		protected bool serviceRepairsEnabledForOwner = true;

		// Token: 0x04000256 RID: 598
		protected bool physicalInventoryEnabledForOwner = true;

		// Token: 0x04000257 RID: 599
		protected bool tradeCreditEnabledForOwner = true;

		// Token: 0x04000258 RID: 600
		protected bool getLoanEnabledForOwner = true;

		// Token: 0x04000259 RID: 601
		protected bool payLoanEnabledForOwner = true;

		// Token: 0x0400025A RID: 602
		protected bool transferCashEnabledForOwner = true;

		// Token: 0x0400025B RID: 603
		protected bool consultantEnabledForOwner = true;

		// Token: 0x0400025C RID: 604
		protected bool floorEnabledForNonOwner = true;

		// Token: 0x0400025D RID: 605
		protected bool backroomEnabledForNonOwner = false;

		// Token: 0x0400025E RID: 606
		protected bool vitalSignsEnabledForNonOwner = false;

		// Token: 0x0400025F RID: 607
		protected bool financialsEnabledForNonOwner = true;

		// Token: 0x04000260 RID: 608
		protected bool productsEnabledForNonOwner = false;

		// Token: 0x04000261 RID: 609
		protected bool commentLogEnabledForNonOwner = false;

		// Token: 0x04000262 RID: 610
		protected bool productAgingEnabledForNonOwner = false;

		// Token: 0x04000263 RID: 611
		protected bool autoGraderEnabledForNonOwner = false;

		// Token: 0x04000264 RID: 612
		protected bool multiStoreReportEnabledForNonOwner = false;

		// Token: 0x04000265 RID: 613
		protected bool actionsJournalEnabledForNonOwner = false;

		// Token: 0x04000266 RID: 614
		protected bool openNewStoreEnabledForNonOwner = true;

		// Token: 0x04000267 RID: 615
		protected bool moveStoreEnabledForNonOwner = false;

		// Token: 0x04000268 RID: 616
		protected bool closeStoreEnabledForNonOwner = false;

		// Token: 0x04000269 RID: 617
		protected bool pricingEnabledForNonOwner = false;

		// Token: 0x0400026A RID: 618
		protected bool storefrontAdsEnabledForNonOwner = false;

		// Token: 0x0400026B RID: 619
		protected bool directMailEnabledForNonOwner = false;

		// Token: 0x0400026C RID: 620
		protected bool radioAdvertisingEnabledForNonOwner = false;

		// Token: 0x0400026D RID: 621
		protected bool billboardAdvertisingEnabledForNonOwner = false;

		// Token: 0x0400026E RID: 622
		protected bool merchandisingEnabledForNonOwner = false;

		// Token: 0x0400026F RID: 623
		protected bool newSurveyEnabledForNonOwner = false;

		// Token: 0x04000270 RID: 624
		protected bool surveyResultsEnabledForNonOwner = false;

		// Token: 0x04000271 RID: 625
		protected bool staffingEnabledForNonOwner = false;

		// Token: 0x04000272 RID: 626
		protected bool purchasingEnabledForNonOwner = false;

		// Token: 0x04000273 RID: 627
		protected bool equipmentEnabledForNonOwner = false;

		// Token: 0x04000274 RID: 628
		protected bool serviceRepairsEnabledForNonOwner = false;

		// Token: 0x04000275 RID: 629
		protected bool physicalInventoryEnabledForNonOwner = false;

		// Token: 0x04000276 RID: 630
		protected bool tradeCreditEnabledForNonOwner = false;

		// Token: 0x04000277 RID: 631
		protected bool getLoanEnabledForNonOwner = false;

		// Token: 0x04000278 RID: 632
		protected bool payLoanEnabledForNonOwner = false;

		// Token: 0x04000279 RID: 633
		protected bool transferCashEnabledForNonOwner = false;

		// Token: 0x0400027A RID: 634
		protected bool consultantEnabledForNonOwner = false;
	}
}
