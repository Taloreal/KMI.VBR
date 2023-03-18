using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Resources;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Sim.Surveys;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Creates app-specific versions of common inherited objects.
	/// </summary>
	// Token: 0x02000013 RID: 19
	public class AppFactory : SimFactory
	{
		/// <summary>
		/// Creates a SimState.
		/// </summary>
		/// <param name="simSettings">Initialization settings that can be changed in DesignerMode.</param>
		/// <param name="multiplayer">True if multiplayer, false otherwise.</param>
		/// <returns>A new SimState.</returns>
		// Token: 0x06000087 RID: 135 RVA: 0x000084E4 File Offset: 0x000074E4
		public override SimState CreateSimState(SimSettings simSettings, bool multiplayer)
		{
			return new AppSimState(simSettings, multiplayer);
		}

		/// <summary>
		/// Creates the table of images to use in the application.
		/// </summary>
		/// <remarks>
		/// When developing all images to be used in the program should
		/// be added in this method.
		/// </remarks>
		/// <returns>A SortedList of all the images used in this application,
		/// keyed by the name for the image created by the programmer.</returns>
		// Token: 0x06000088 RID: 136 RVA: 0x00008500 File Offset: 0x00007500
		public override SortedList CreateImageTable()
		{
			SortedList table = new SortedList();
			Type t = typeof(frmMain);
			table.Add("City", base.CBmp(t, "Images.CityView.City.png"));
			table.Add("CitySmall", base.CBmp(t, "Images.CityView.CitySmall.png"));
			table.Add("CarNESW", base.CBmp(t, "Images.CityView.CarNESW.png"));
			table.Add("CarNWSE", base.CBmp(t, "Images.CityView.CarNWSE.png"));
			table.Add("CarSmallNESW", base.CBmp(t, "Images.CityView.CarSmallNESW.png"));
			table.Add("CarSmallNWSE", base.CBmp(t, "Images.CityView.CarSmallNWSE.png"));
			for (int i = 0; i < City.BuildingTypeCount; i++)
			{
				table.Add("Building" + i, base.CBmp(t, "Images.CityView.Building" + i + ".png"));
				table.Add("BuildingSmall" + i, base.CBmp(t, "Images.CityView.BuildingSmall" + i + ".png"));
				table.Add("BuildingMedium" + i, base.CBmp(t, "Images.CityView.BuildingMedium" + i + ".png"));
			}
			for (int i = 0; i < 6; i++)
			{
				table.Add("BB" + i, base.CBmp(t, "Images.CityView.BB" + i + ".png"));
				table.Add("BB" + i + "Small", base.CBmp(t, "Images.CityView.BB" + i + "Small.png"));
			}
			table.Add("Envelope", base.CBmp(t, "Images.Cursors.Mail.gif"));
			table.Add("Snow", base.CBmp(t, "Images.CityView.Snow.png"));
			for (int i = 0; i < 8; i++)
			{
				table.Add("GrassPlot" + i, base.CBmp(t, "Images.CityView.GrassPlot" + i + ".png"));
				table.Add("GrassPlot" + i + "Small", base.CBmp(t, "Images.CityView.GrassPlot" + i + "Small.png"));
			}
			table.Add("Construction", base.CBmp(t, "Images.CityView.Construction.png"));
			table.Add("ConstructionSmall", base.CBmp(t, "Images.CityView.ConstructionSmall.png"));
			table.Add("Storefront", base.CBmp(t, "Images.StorefrontView.Storefront.png"));
			table.Add("Floor", base.CBmp(t, "Images.FloorView.Floor.png"));
			for (int i = 0; i < 25; i++)
			{
				Bitmap b = base.CBmp(t, "Images.FloorView.Products.Prod" + i + ".png");
				table.Add("Prod" + i, b);
				Bitmap b2 = new Bitmap(b);
				b2.RotateFlip(RotateFlipType.RotateNoneFlipX);
				table.Add("ProdF" + i, b2);
				table.Add("ProdLarge" + i, base.CBmp(t, "Images.FloorView.ProductsLarge.Prod" + i + ".png"));
			}
			table.Add("Counter", base.CBmp(t, "Images.FloorView.Counter.png"));
			table.Add("CashRegister", base.CBmp(t, "Images.FloorView.CashRegister.png"));
			table.Add("Windows", base.CBmp(t, "Images.FloorView.Windows.png"));
			table.Add("Rack", base.CBmp(t, "Images.FloorView.Rack.png"));
			table.Add("RackShelf", base.CBmp(t, "Images.FloorView.RackShelf.png"));
			table.Add("Magazine", base.CBmp(t, "Images.FloorView.Magazine.png"));
			table.Add("MagazineShelf", base.CBmp(t, "Images.FloorView.MagazineShelf.png"));
			table.Add("Fridge", base.CBmp(t, "Images.FloorView.Fridge.png"));
			table.Add("FridgeShelf", base.CBmp(t, "Images.FloorView.FridgeShelf.png"));
			table.Add("FridgeTop", base.CBmp(t, "Images.FloorView.FridgeTop.png"));
			table.Add("FridgeFront", base.CBmp(t, "Images.FloorView.FridgeFront.png"));
			table.Add("FridgeSide", base.CBmp(t, "Images.FloorView.FridgeSide.png"));
			for (int i = 0; i < 5; i++)
			{
				table.Add("Coffee" + i, base.CBmp(t, "Images.FloorView.Coffee" + i + ".png"));
				table.Add("Donut" + i, base.CBmp(t, "Images.FloorView.Donut" + i + ".png"));
				table.Add("Slushie" + i, base.CBmp(t, "Images.FloorView.Slushie" + i + ".png"));
			}
			for (int i = 0; i < 2; i++)
			{
				table.Add("CoffeeBroken" + i, base.CBmp(t, "Images.FloorView.CoffeeBroken" + i + ".png"));
				table.Add("FridgeBroken" + i, base.CBmp(t, "Images.FloorView.FridgeBroken" + i + ".png"));
				table.Add("SlushieBroken" + i, base.CBmp(t, "Images.FloorView.SlushieBroken" + i + ".png"));
			}
			for (int i = 0; i < 4; i++)
			{
				table.Add("ShelfLife" + i, base.CBmp(t, "Images.FloorView.ShelfLife" + i + ".gif"));
			}
			table.Add("CameraMount", base.CBmp(t, "Images.FloorView.CameraMount.png"));
			table.Add("Camera", base.CBmp(t, "Images.FloorView.Camera.png"));
			table.Add("CameraMountSE", base.CBmp(t, "Images.FloorView.CameraMountSE.png"));
			table.Add("CameraSE", base.CBmp(t, "Images.FloorView.CameraSE.png"));
			table.Add("Backroom", base.CBmp(t, "Images.BackroomView.Backroom.png"));
			table.Add("Vent", base.CBmp(t, "Images.BackroomView.Vent.png"));
			for (int i = 0; i < 25; i++)
			{
				table.Add("Case" + i, base.CBmp(t, "Images.BackroomView.Case" + i + ".png"));
			}
			for (int i = 0; i < 6; i++)
			{
				table.Add("Flaps" + i, base.CBmp(t, "Images.BackroomView.FlapsOn" + i + ".png"));
			}
			table.Add("FlapsOff", base.CBmp(t, "Images.BackroomView.FlapsOff.png"));
			table.Add("StaffingPic", base.CBmp(t, "Images.FloorView.Characters.StaffingPic.png"));
			return table;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00008CC0 File Offset: 0x00007CC0
		public override SortedList CreatePageTable()
		{
			SortedList table = new SortedList();
			Type t = typeof(frmMain);
			foreach (string g in new string[]
			{
				"M",
				"F"
			})
			{
				foreach (string r in new string[]
				{
					"B",
					"C",
					"H"
				})
				{
					foreach (string cws in new string[]
					{
						"C",
						"W",
						"S"
					})
					{
						int cols = 9;
						if (cws == "S")
						{
							cols = 1;
						}
						string name = "W" + g + cws + r;
						table.Add(name, base.CPage(t, "Images.FloorView.Characters." + name + ".png", cols, 2, 41, 84));
					}
				}
			}
			foreach (string d in new string[]
			{
				"S",
				"B",
				"E"
			})
			{
				foreach (string g in new string[]
				{
					"F",
					"M"
				})
				{
					foreach (string r in new string[]
					{
						"B",
						"H",
						"C"
					})
					{
						foreach (string cws in new string[]
						{
							"C",
							"W",
							"S",
							"H"
						})
						{
							int cols = 9;
							if (cws == "S" || cws == "H")
							{
								cols = 1;
							}
							string name = d + g + cws + r;
							table.Add(name, base.CPage(t, "Images.FloorView.Characters." + name + ".png", cols, 2, 41, 84));
						}
					}
				}
			}
			foreach (string r in new string[]
			{
				"B",
				"H",
				"C"
			})
			{
				foreach (string cws in new string[]
				{
					"W",
					"S",
					"F"
				})
				{
					int rows = 2;
					int cols = 9;
					if (cws == "S")
					{
						cols = 1;
					}
					if (cws == "F")
					{
						rows = 1;
					}
					string gender = "M";
					if (r == "H")
					{
						gender = "F";
					}
					string name = "R" + gender + cws + r;
					table.Add(name, base.CPage(t, "Images.FloorView.Characters." + name + ".png", cols, rows, 37, 80));
				}
			}
			return table;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000090DC File Offset: 0x000080DC
		public override SortedList CreateCursorTable()
		{
			SortedList table = new SortedList();
			Type t = typeof(frmMain);
			table.Add("Billboard", base.CCursor(t, "Images.Cursors.Billboard.gif"));
			table.Add("NoBillboard", base.CCursor(t, "Images.Cursors.NoBillboard.gif"));
			table.Add("Mail", base.CCursor(t, "Images.Cursors.Mail.gif"));
			table.Add("ZoomIn", base.CCursor(t, "Images.Cursors.ZoomIn.png"));
			table.Add("ZoomOut", base.CCursor(t, "Images.Cursors.ZoomOut.png"));
			return table;
		}

		/// <summary>
		/// Creates the application's Views.  The developper should
		/// explicitly create the Views and return them as a View[]
		/// object in this method.
		/// </summary>
		/// <returns>A View[] object that is the collection of the
		/// application's Views.</returns>
		// Token: 0x0600008B RID: 139 RVA: 0x00009178 File Offset: 0x00008178
		public override View[] CreateViews()
		{
			View[] views = new View[3];
			views[0] = new CityView("City", S.R.GetImage("CitySmall"));
			views[1] = new FloorView("Store", S.R.GetImage("Floor"));
			views[1].ClearDrawSelectedOnMouseMove = true;
			views[2] = new BackroomView("Backroom", S.R.GetImage("Backroom"));
			return views;
		}

		/// <summary>
		/// Creates the application's Resource handling object.
		/// </summary>
		/// <returns>The application's Resource handling object.</returns>
		// Token: 0x0600008C RID: 140 RVA: 0x000091F0 File Offset: 0x000081F0
		public override Resource CreateResource()
		{
			ResourceManager rm0 = new ResourceManager("KMI.Sim.Sim", Assembly.GetAssembly(typeof(SimFactory)));
			ResourceManager rm = new ResourceManager("KMI.VBR3Lib.App", Assembly.GetAssembly(typeof(AppFactory)));
			return new Resource(new ResourceManager[]
			{
				rm0,
				rm
			});
		}

		/// <summary>
		/// Creates and returns a new AppEntity for the given Player
		/// and entity name.
		/// </summary>
		/// <param name="player">The Player to own the Entity.</param>
		/// <param name="entityName">The Entity's name.</param>
		/// <returns>A new AppEntity for the given Player
		/// and entity name.</returns>
		// Token: 0x0600008D RID: 141 RVA: 0x0000924C File Offset: 0x0000824C
		public override Entity CreateEntity(Player player, string entityName)
		{
			return new AppEntity(player, entityName);
		}

		/// <summary>
		/// Creates a new state adapter for the application.
		/// </summary>
		/// <returns>A new state adapter for the application.</returns>
		// Token: 0x0600008E RID: 142 RVA: 0x00009268 File Offset: 0x00008268
		public override SimStateAdapter CreateSimStateAdapter()
		{
			return new AppStateAdapter();
		}

		/// <summary>
		/// Creates the application's SimSettings object.
		/// </summary>
		/// <returns>The application's SimSettings object.</returns>
		// Token: 0x0600008F RID: 143 RVA: 0x00009280 File Offset: 0x00008280
		public override SimSettings CreateSimSettings()
		{
			return new AppSimSettings();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00009298 File Offset: 0x00008298
		public override Survey CreateSurvey(long entityID, DateTime date, string[] entityNames, ArrayList surveyQuestions)
		{
			return new AppSurvey(entityID, date, entityNames, surveyQuestions);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000092B4 File Offset: 0x000082B4
		public SectionBase CreateSection(VBRProductType pt, SectionBase sb)
		{
			SectionBase sbNew = null;
			SectionBase result;
			if (pt == null)
			{
				result = new SectionBase(sb.node, sb.dy);
			}
			else
			{
				string rackType = pt.RackType;
				if (rackType != null)
				{
					if (!(rackType == "Shelf Rack"))
					{
						if (!(rackType == "Refrigeration Unit"))
						{
							if (!(rackType == "Magazine Rack"))
							{
								if (!(rackType == "Coffee Station"))
								{
									if (!(rackType == "Donut Station"))
									{
										if (rackType == "Slushy Machine")
										{
											sbNew = new Slushy(sb.node, sb.dy);
										}
									}
									else
									{
										sbNew = new Donut(sb.node, sb.dy);
									}
								}
								else
								{
									sbNew = new Coffee(sb.node, sb.dy);
								}
							}
							else
							{
								sbNew = new MagazineRack(sb.node, sb.dy);
							}
						}
						else
						{
							sbNew = new Fridge(sb.node, sb.dy);
						}
					}
					else
					{
						sbNew = new Rack(sb.node, sb.dy);
					}
				}
				result = sbNew;
			}
			return result;
		}
	}
}
