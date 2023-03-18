using System;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using KMI.Sim.Surveys;

namespace KMI.Sim
{
	// Token: 0x0200006E RID: 110
	public class SimFactory
	{
		// Token: 0x06000404 RID: 1028 RVA: 0x0001D964 File Offset: 0x0001C964
		public virtual Simulator CreateSimulator()
		{
			return new Simulator(this);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0001D97C File Offset: 0x0001C97C
		public virtual SimState CreateSimState(SimSettings simSettings, bool multiplayer)
		{
			return new SimState(simSettings, multiplayer);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0001D998 File Offset: 0x0001C998
		public virtual View[] CreateViews()
		{
			return new View[0];
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0001D9B0 File Offset: 0x0001C9B0
		public virtual SortedList CreateImageTable()
		{
			return null;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0001D9C4 File Offset: 0x0001C9C4
		public virtual SortedList CreatePageTable()
		{
			return null;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0001D9D8 File Offset: 0x0001C9D8
		public virtual SortedList CreateCursorTable()
		{
			return null;
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0001D9EC File Offset: 0x0001C9EC
		public virtual UserAdminSettings CreateUserAdminSettings()
		{
			UserAdminSettings userAdminSettings = new UserAdminSettings();
			AppSettingsReader appSettingsReader = new AppSettingsReader();
			userAdminSettings.DefaultDirectory = (string)appSettingsReader.GetValue("DefaultDirectory", typeof(string));
			userAdminSettings.P = (int)appSettingsReader.GetValue("P", typeof(int));
			userAdminSettings.ProxyAddress = (string)appSettingsReader.GetValue("ProxyAddress", typeof(string));
			userAdminSettings.ProxyBypassList = (string)appSettingsReader.GetValue("ProxyBypassList", typeof(string));
			userAdminSettings.NoSound = (bool)appSettingsReader.GetValue("NoSound", typeof(bool));
			userAdminSettings.MultiplayerBasePort = (int)appSettingsReader.GetValue("MultiplayerBasePort", typeof(int));
			userAdminSettings.MultiplayerPortCount = (int)appSettingsReader.GetValue("MultiplayerPortCount", typeof(int));
			userAdminSettings.ClientDrawStepPeriod = (int)appSettingsReader.GetValue("ClientDrawStepPeriod", typeof(int));
			userAdminSettings.PasswordsForMultiplayer = (bool)appSettingsReader.GetValue("PasswordsForMultiplayer", typeof(bool));
			return userAdminSettings;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0001DB34 File Offset: 0x0001CB34
		public virtual SimEngine CreateSimEngine()
		{
			return new SimEngine();
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0001DB4C File Offset: 0x0001CB4C
		public virtual Resource CreateResource()
		{
			ResourceManager resourceManager = new ResourceManager("KMI.Sim.Sim", Assembly.GetAssembly(typeof(SimFactory)));
			return new Resource(new ResourceManager[]
			{
				resourceManager
			});
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0001DB8C File Offset: 0x0001CB8C
		public virtual Entity CreateEntity(Player player, string entityName)
		{
			return new Entity(player, entityName);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0001DBA8 File Offset: 0x0001CBA8
		public virtual Player CreatePlayer(string playerName, PlayerType playerType)
		{
			return new Player(playerName, playerType);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0001DBC4 File Offset: 0x0001CBC4
		public virtual SimStateAdapter CreateSimStateAdapter()
		{
			return new SimStateAdapter();
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0001DBDC File Offset: 0x0001CBDC
		protected Bitmap CBmp(Type typeFromAssembly, string filename)
		{
			Bitmap bitmap = new Bitmap(typeFromAssembly, filename);
			bitmap.SetResolution(96f, 96f);
			if (bitmap == null)
			{
				throw new Exception("In SimFactory.CreateCompatibleBitmap, could not get image from filename " + filename);
			}
			Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, S.MF.picMain.CreateGraphics());
			Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImageUnscaled(bitmap, 0, 0);
			return bitmap2;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0001DC60 File Offset: 0x0001CC60
		protected Page CPage(Type typeFromAssembly, string filename, int cols, int rows, int anchorX, int anchorY)
		{
			return new Page(this.CBmp(typeFromAssembly, filename), cols, rows, anchorX, anchorY);
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0001DC88 File Offset: 0x0001CC88
		protected Cursor CCursor(Type typeFromAssembly, string filename)
		{
			Bitmap bitmap = this.CBmp(typeFromAssembly, filename);
			return new Cursor(bitmap.GetHicon());
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0001DCB0 File Offset: 0x0001CCB0
		public virtual SimSettings CreateSimSettings()
		{
			return new SimSettings();
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0001DCC8 File Offset: 0x0001CCC8
		public virtual Survey CreateSurvey(long entityID, DateTime date, string[] entityNames, ArrayList surveyQuestions)
		{
			return new Survey(entityID, date, entityNames, surveyQuestions);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0001DCE4 File Offset: 0x0001CCE4
		protected void LoadWithCompassPoints(SortedList table, Type type, string baseResourceName, string fileExtension)
		{
			string[] array = baseResourceName.Split(new char[]
			{
				'.'
			});
			string str = array[array.Length - 1];
			foreach (string text in new string[]
			{
				"N",
				"S"
			})
			{
				foreach (string text2 in new string[]
				{
					"E",
					"W"
				})
				{
					table.Add(str + text + text2, this.CBmp(type, string.Concat(new string[]
					{
						baseResourceName,
						text,
						text2,
						".",
						fileExtension
					})));
				}
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0001DDD8 File Offset: 0x0001CDD8
		protected void LoadWith8CompassPoints(SortedList table, Type type, string baseResourceName, string fileExtension)
		{
			this.LoadWithCompassPoints(table, type, baseResourceName, fileExtension);
			string[] array = baseResourceName.Split(new char[]
			{
				'.'
			});
			string str = array[array.Length - 1];
			foreach (string str2 in new string[]
			{
				"N",
				"S",
				"E",
				"W"
			})
			{
				table.Add(str + str2, this.CBmp(type, baseResourceName + str2 + "." + fileExtension));
			}
		}
	}
}
