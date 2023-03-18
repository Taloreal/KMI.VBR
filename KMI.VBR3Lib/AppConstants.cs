using System;
using System.Drawing;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for AppConstants.
	/// </summary>
	// Token: 0x02000038 RID: 56
	public class AppConstants
	{
		// Token: 0x06000177 RID: 375 RVA: 0x00014E94 File Offset: 0x00013E94
		static AppConstants()
		{
			AppConstants.PriceElasticity = new ResponseCurve();
			AppConstants.PriceElasticity.Variance = 0.5f;
			AppConstants.PriceElasticity.Points = new PointF[]
			{
				new PointF(-50f, 10f),
				new PointF(-25f, 8f),
				new PointF(0f, 4f),
				new PointF(10f, 2f),
				new PointF(20f, 1.3f),
				new PointF(25f, 1.2f),
				new PointF(35f, 1f),
				new PointF(40f, 0.5f),
				new PointF(50f, 0.3f),
				new PointF(70f, 0f)
			};
			AppConstants.Wages = new float[AppConstants.TaskNames.Length];
			for (int i = 0; i < AppConstants.Wages.Length; i++)
			{
				AppConstants.Wages[i] = AppConstants.WageRate;
			}
			AppConstants.StoreSignColors = new Color[6];
			AppConstants.StoreSignColors[0] = Color.Red;
			AppConstants.StoreSignColors[1] = Color.LightGreen;
			AppConstants.StoreSignColors[2] = Color.Orange;
			AppConstants.StoreSignColors[3] = Color.LightBlue;
			AppConstants.StoreSignColors[4] = Color.Yellow;
			AppConstants.StoreSignColors[5] = Color.Purple;
		}

		// Token: 0x0400014B RID: 331
		public const int ScaleFactor = 20;

		// Token: 0x0400014C RID: 332
		public const int ReachScaling = 5;

		// Token: 0x0400014D RID: 333
		public const int ProductTypeCount = 25;

		// Token: 0x0400014E RID: 334
		public const int DaysBetweenShopping = 4;

		// Token: 0x0400014F RID: 335
		public const float PercentShoplifters = 0.1f;

		// Token: 0x04000150 RID: 336
		public const float PercentSignRequired = 0.5f;

		// Token: 0x04000151 RID: 337
		public const float PctWillShopOnBlockWithoutAds = 0.5f;

		// Token: 0x04000152 RID: 338
		public const int StationStages = 5;

		// Token: 0x04000153 RID: 339
		public const int ConstructionDays = 180;

		// Token: 0x04000154 RID: 340
		public const int MaxPurchasingUnits = 25000;

		// Token: 0x04000155 RID: 341
		public const float CpmRadio = 20f;

		// Token: 0x04000156 RID: 342
		public const float CpmMailing = 450f;

		// Token: 0x04000157 RID: 343
		public const int CouponLifeDays = 7;

		// Token: 0x04000158 RID: 344
		public const float PhysicalInventoryCost = 250f;

		// Token: 0x04000159 RID: 345
		public const int CpmBillboard = 75;

		// Token: 0x0400015A RID: 346
		public const int BillboardRentMinimum = 100;

		// Token: 0x0400015B RID: 347
		public const int CpmStoreRent = 100;

		// Token: 0x0400015C RID: 348
		public const int StoreRentMinimum = 200;

		// Token: 0x0400015D RID: 349
		public const int RegisterLeaseCost = 40;

		// Token: 0x0400015E RID: 350
		public const float ConsultantCost = 1000f;

		// Token: 0x0400015F RID: 351
		public const float ImpressionDecayRate = 0.8f;

		// Token: 0x04000160 RID: 352
		public const float ImpressionMinimumDecay = 0.1f;

		// Token: 0x04000161 RID: 353
		public const int Level2AICompetitors = 4;

		// Token: 0x04000162 RID: 354
		public const int HoursToExpireNoFridge = 8;

		// Token: 0x04000163 RID: 355
		public const int CamMountLocs = 5;

		// Token: 0x04000164 RID: 356
		public const float CameraCost = 25f;

		// Token: 0x04000165 RID: 357
		public const int VacantLotImages = 8;

		// Token: 0x04000166 RID: 358
		public const float CostToMoveBusiness = 25000f;

		// Token: 0x04000167 RID: 359
		public static VBRProductType[] ProductTypes;

		// Token: 0x04000168 RID: 360
		public static DemographicType[] DemographicTypes;

		// Token: 0x04000169 RID: 361
		public static string[] TaskNames = new string[]
		{
			"Cashier",
			"Shelf Stocker"
		};

		// Token: 0x0400016A RID: 362
		public static int[] ShiftStartHours = new int[]
		{
			7,
			11,
			15,
			19,
			23,
			3
		};

		// Token: 0x0400016B RID: 363
		public static int[] ShiftLengths = new int[]
		{
			4,
			4,
			4,
			4,
			4,
			4
		};

		// Token: 0x0400016C RID: 364
		public static int[] MaxEmployees = new int[]
		{
			100,
			100
		};

		// Token: 0x0400016D RID: 365
		public static float WageRate = 8.5f;

		// Token: 0x0400016E RID: 366
		public static float[] Wages;

		// Token: 0x0400016F RID: 367
		public static ResponseCurve PriceElasticity;

		// Token: 0x04000170 RID: 368
		public static Color[] StoreSignColors;

		// Token: 0x04000171 RID: 369
		public static int[] LevelChangeScoreDuration = new int[]
		{
			8,
			16
		};

		// Token: 0x04000172 RID: 370
		public static int[] LevelChangeScoreLevel = new int[]
		{
			100000,
			500000
		};

		// Token: 0x04000173 RID: 371
		public static int[] ServiceContractCosts = new int[]
		{
			0,
			20,
			10,
			5,
			3
		};

		// Token: 0x04000174 RID: 372
		public static int[] ResponseTimes = new int[]
		{
			-1,
			4,
			24,
			48,
			72
		};

		// Token: 0x04000175 RID: 373
		public static int[] CameraOn = new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			3,
			4,
			4,
			4,
			4
		};

		// Token: 0x02000039 RID: 57
		public enum Tasks
		{
			// Token: 0x04000177 RID: 375
			Cashier,
			// Token: 0x04000178 RID: 376
			ShelfStocker
		}
	}
}
