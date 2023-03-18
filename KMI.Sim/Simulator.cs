using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.GZip;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200005A RID: 90
	public class Simulator
	{
		// Token: 0x0600032F RID: 815 RVA: 0x00018C8C File Offset: 0x00017C8C
		public Simulator(SimFactory simFactory)
		{
			this.simFactory = simFactory;
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00018D74 File Offset: 0x00017D74
		public static void InitSimulator(SimFactory simFactory)
		{
			Simulator.instance = simFactory.CreateSimulator();
			Simulator.Instance.resource = Simulator.Instance.simFactory.CreateResource();
			Simulator.Instance.simEngine = Simulator.Instance.simFactory.CreateSimEngine();
			Simulator.Instance.userAdminSettings = Simulator.Instance.simFactory.CreateUserAdminSettings();
			Simulator.Instance.resource.ImageTable = Simulator.Instance.simFactory.CreateImageTable();
			Simulator.Instance.resource.PageTable = Simulator.Instance.simFactory.CreatePageTable();
			Simulator.Instance.resource.CursorTable = Simulator.Instance.simFactory.CreateCursorTable();
			Simulator.Instance.views = Simulator.Instance.simFactory.CreateViews();
			S.I.SafeViewsForNoEntity.Add(Simulator.Instance.Views[0].Name);
			S.I.DefaultSimSettings = Simulator.Instance.SimFactory.CreateSimSettings();
			Simulator.compressSaves = true;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00018E90 File Offset: 0x00017E90
		public void NewState(SimSettings simSettings, bool multiplayer)
		{
			SimSettings simSettings2 = (SimSettings)Utilities.DeepCopyBySerialization(simSettings);
			this.SimState = this.simFactory.CreateSimState(simSettings2, multiplayer);
			this.SimState.Init();
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00018ECC File Offset: 0x00017ECC
		public void LoadState(string filename)
		{
			lock (S.SA)
			{
				Stream stream = null;
				CryptoStream cryptoStream = null;
				try
				{
					DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
					byte[] bytes = Encoding.ASCII.GetBytes("A8C3q97w");
					byte[] bytes2 = Encoding.ASCII.GetBytes("pK8J6Gfe");
					ICryptoTransform transform = descryptoServiceProvider.CreateDecryptor(bytes, bytes2);
					IFormatter formatter = new BinaryFormatter();
					stream = new GZipInputStream(File.OpenRead(filename));
					try
					{
						this.simState = (SimState)formatter.Deserialize(stream);
					}
					catch (GZipException ex)
					{
						stream.Close();
						cryptoStream = new CryptoStream(File.OpenRead(filename), transform, CryptoStreamMode.Read);
						stream = new GZipInputStream(cryptoStream);
						this.simState = (SimState)formatter.Deserialize(stream);
					}
				}
				finally
				{
					if (stream != null)
					{
						stream.Close();
					}
					if (cryptoStream != null)
					{
						cryptoStream.Close();
					}
				}
			}
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00018FE0 File Offset: 0x00017FE0
		public void SaveState(string filename)
		{
			lock (S.SA)
			{
				Stream stream = null;
				CryptoStream cryptoStream = null;
				try
				{
					IFormatter formatter = new BinaryFormatter();
					DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
					byte[] bytes = Encoding.ASCII.GetBytes("A8C3q97w");
					byte[] bytes2 = Encoding.ASCII.GetBytes("pK8J6Gfe");
					ICryptoTransform transform = descryptoServiceProvider.CreateEncryptor(bytes, bytes2);
					Stream baseOutputStream;
					if (S.SS.StudentOrg == 0)
					{
						baseOutputStream = File.Create(filename);
					}
					else
					{
						baseOutputStream = new CryptoStream(File.Create(filename), transform, CryptoStreamMode.Write);
					}
					stream = new GZipOutputStream(baseOutputStream);
					formatter.Serialize(stream, this.simState);
				}
				finally
				{
					if (cryptoStream != null)
					{
						cryptoStream.Close();
					}
					else if (stream != null)
					{
						stream.Close();
					}
				}
			}
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000190D8 File Offset: 0x000180D8
		public void StartSimTimeRunning()
		{
			this.simEngine.ResumeThread();
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000335 RID: 821 RVA: 0x000190E8 File Offset: 0x000180E8
		public bool SimTimeRunning
		{
			get
			{
				return this.simEngine.Running;
			}
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00019105 File Offset: 0x00018105
		public void StopSimTimeRunning()
		{
			this.simEngine.PauseThread();
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00019114 File Offset: 0x00018114
		public static Simulator Instance
		{
			get
			{
				return Simulator.instance;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000338 RID: 824 RVA: 0x0001912C File Offset: 0x0001812C
		// (set) Token: 0x06000339 RID: 825 RVA: 0x0001915C File Offset: 0x0001815C
		public SimState SimState
		{
			get
			{
				if (this.Client)
				{
					throw new Exception("SimState accessed from client");
				}
				return this.simState;
			}
			set
			{
				this.simState = value;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600033A RID: 826 RVA: 0x00019168 File Offset: 0x00018168
		// (set) Token: 0x0600033B RID: 827 RVA: 0x00019180 File Offset: 0x00018180
		public SimStateAdapter SimStateAdapter
		{
			get
			{
				return this.simStateAdapter;
			}
			set
			{
				this.simStateAdapter = value;
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0001918A File Offset: 0x0001818A
		public void Subscribe(ActiveObject activeObject)
		{
			this.simState.SubscribeTimedEvent(activeObject);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0001919A File Offset: 0x0001819A
		public void Subscribe(ActiveObject activeObject, Simulator.TimePeriod timePeriod)
		{
			this.simState.SubscribeTimedEvent(activeObject, timePeriod);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000191AC File Offset: 0x000181AC
		public void Subscribe(ActiveObject activeObject, DateTime wakeupTime)
		{
			activeObject.WakeupTime = wakeupTime;
			if (!this.simState.eventQueue.ContainsValue(activeObject))
			{
				this.simState.eventQueue.Add(activeObject, activeObject);
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x000191EA File Offset: 0x000181EA
		public void UnSubscribe(ActiveObject activeObject)
		{
			this.simState.UnSubscribeTimedEvent(activeObject);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x000191FA File Offset: 0x000181FA
		public void UnSubscribe(ActiveObject activeObject, Simulator.TimePeriod timePeriod)
		{
			this.simState.UnSubscribeTimedEvent(activeObject, timePeriod);
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0001920C File Offset: 0x0001820C
		public Resource Resource
		{
			get
			{
				return this.resource;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000342 RID: 834 RVA: 0x00019224 File Offset: 0x00018224
		public View[] Views
		{
			get
			{
				return this.views;
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0001923C File Offset: 0x0001823C
		public View View(string name)
		{
			foreach (View view in this.Views)
			{
				if (view.Name == name)
				{
					return view;
				}
			}
			throw new Exception("View " + name + " not found.");
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0001929C File Offset: 0x0001829C
		public UserAdminSettings UserAdminSettings
		{
			get
			{
				return this.userAdminSettings;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000345 RID: 837 RVA: 0x000192B4 File Offset: 0x000182B4
		public SimFactory SimFactory
		{
			get
			{
				return this.simFactory;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000346 RID: 838 RVA: 0x000192CC File Offset: 0x000182CC
		// (set) Token: 0x06000347 RID: 839 RVA: 0x000192E4 File Offset: 0x000182E4
		public bool Client
		{
			get
			{
				return this.client;
			}
			set
			{
				this.client = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000348 RID: 840 RVA: 0x000192F0 File Offset: 0x000182F0
		public bool Host
		{
			get
			{
				return this.Multiplayer && !this.Client;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00019318 File Offset: 0x00018318
		public bool Multiplayer
		{
			get
			{
				return S.I.Client || S.ST.Multiplayer;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600034A RID: 842 RVA: 0x0001934C File Offset: 0x0001834C
		// (set) Token: 0x0600034B RID: 843 RVA: 0x00019364 File Offset: 0x00018364
		public string ThisPlayerName
		{
			get
			{
				return this.thisPlayerName;
			}
			set
			{
				this.thisPlayerName = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00019370 File Offset: 0x00018370
		// (set) Token: 0x0600034D RID: 845 RVA: 0x00019388 File Offset: 0x00018388
		public string SessionName
		{
			get
			{
				return this.sessionName;
			}
			set
			{
				this.sessionName = value;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00019394 File Offset: 0x00018394
		// (set) Token: 0x0600034F RID: 847 RVA: 0x000193AC File Offset: 0x000183AC
		public string MultiplayerRoleName
		{
			get
			{
				return this.multiplayerRoleName;
			}
			set
			{
				this.multiplayerRoleName = value;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000350 RID: 848 RVA: 0x000193B8 File Offset: 0x000183B8
		public MultiplayerRole MultiplayerRole
		{
			get
			{
				if (this.Client && this.MultiplayerRoleName != "")
				{
					foreach (MultiplayerRole multiplayerRole in MultiplayerRole.Roles)
					{
						if (multiplayerRole.RoleName == this.MultiplayerRoleName)
						{
							return multiplayerRole;
						}
					}
				}
				return null;
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0001942C File Offset: 0x0001842C
		public bool DoShowAgain(string messageTitle)
		{
			return !this.dontShowAgain.ContainsKey(messageTitle);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00019450 File Offset: 0x00018450
		public void DontShowAgain(string messageTitle)
		{
			if (!this.dontShowAgain.ContainsKey(messageTitle))
			{
				this.dontShowAgain.Add(messageTitle, messageTitle);
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0001947C File Offset: 0x0001847C
		public void SetSimEngineSpeed(SimSpeed speed)
		{
			this.simEngine.StepPeriod = speed.StepPeriod;
			this.simEngine.Skip = speed.SkipFactor;
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000354 RID: 852 RVA: 0x000194A4 File Offset: 0x000184A4
		public Guid GUID
		{
			get
			{
				return this.guid;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000355 RID: 853 RVA: 0x000194BC File Offset: 0x000184BC
		// (set) Token: 0x06000356 RID: 854 RVA: 0x000194D3 File Offset: 0x000184D3
		public static bool CompressSaves
		{
			get
			{
				return Simulator.compressSaves;
			}
			set
			{
				Simulator.compressSaves = value;
			}
		}

		// Token: 0x06000357 RID: 855 RVA: 0x000194DC File Offset: 0x000184DC
		public bool BlockMessage(string message)
		{
			bool result;
			if (message == null)
			{
				result = false;
			}
			else if (S.SS.BlockMessagesContaining == null || S.SS.BlockMessagesContaining == "")
			{
				result = false;
			}
			else
			{
				string[] array = S.SS.BlockMessagesContaining.Split(new char[]
				{
					'|'
				});
				foreach (string value in array)
				{
					if (message.IndexOf(value) > -1)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00019588 File Offset: 0x00018588
		// Note: this type is marked as 'beforefieldinit'.
		static Simulator()
		{
			Simulator.TimePeriod[] array = new Simulator.TimePeriod[5];
			array[0] = Simulator.TimePeriod.Year;
			array[1] = Simulator.TimePeriod.Week;
			array[2] = Simulator.TimePeriod.Day;
			array[3] = Simulator.TimePeriod.Hour;
			Simulator.FiringOrder = new ArrayList(array);
		}

		// Token: 0x04000200 RID: 512
		private const int COMPRESSION_BUFFER_SIZE = 2048;

		// Token: 0x04000201 RID: 513
		public static ArrayList FiringOrder;

		// Token: 0x04000202 RID: 514
		protected static Simulator instance;

		// Token: 0x04000203 RID: 515
		protected SimState simState;

		// Token: 0x04000204 RID: 516
		protected SimStateAdapter simStateAdapter;

		// Token: 0x04000205 RID: 517
		protected SimEngine simEngine;

		// Token: 0x04000206 RID: 518
		protected Resource resource;

		// Token: 0x04000207 RID: 519
		protected View[] views;

		// Token: 0x04000208 RID: 520
		protected UserAdminSettings userAdminSettings;

		// Token: 0x04000209 RID: 521
		protected SimFactory simFactory;

		// Token: 0x0400020A RID: 522
		protected bool client = false;

		// Token: 0x0400020B RID: 523
		protected string thisPlayerName = "";

		// Token: 0x0400020C RID: 524
		protected string sessionName;

		// Token: 0x0400020D RID: 525
		protected string multiplayerRoleName;

		// Token: 0x0400020E RID: 526
		protected Hashtable imageTable;

		// Token: 0x0400020F RID: 527
		protected Hashtable dontShowAgain = new Hashtable();

		// Token: 0x04000210 RID: 528
		public int DemoDuration = 120;

		// Token: 0x04000211 RID: 529
		public string EntityName = "Business";

		// Token: 0x04000212 RID: 530
		public string DataFileTypeExtension = "vxx";

		// Token: 0x04000213 RID: 531
		public string DataFileTypeName = Application.ProductName;

		// Token: 0x04000214 RID: 532
		public int BackgroundMusicLength = 98500;

		// Token: 0x04000215 RID: 533
		public SimSettings DefaultSimSettings = new SimSettings();

		// Token: 0x04000216 RID: 534
		public float CurrencyConversion = 1f;

		// Token: 0x04000217 RID: 535
		public bool Messages = true;

		// Token: 0x04000218 RID: 536
		public string NewWhatName = "City";

		// Token: 0x04000219 RID: 537
		public bool NewStandardProjectFromFile = true;

		// Token: 0x0400021A RID: 538
		public bool VBC = false;

		// Token: 0x0400021B RID: 539
		public bool Demo = false;

		// Token: 0x0400021C RID: 540
		public bool Academic = false;

		// Token: 0x0400021D RID: 541
		public bool AllowRoleBasedMultiplayer = false;

		// Token: 0x0400021E RID: 542
		public bool AllowIntraTeamMessaging = false;

		// Token: 0x0400021F RID: 543
		public ArrayList SafeViewsForNoEntity = new ArrayList();

		// Token: 0x04000220 RID: 544
		public DayOfWeek FirstDayOfWeek = DayOfWeek.Sunday;

		// Token: 0x04000221 RID: 545
		protected Guid guid = Guid.NewGuid();

		// Token: 0x04000222 RID: 546
		protected static bool compressSaves;

		// Token: 0x04000223 RID: 547
		public Hashtable PeriodicMessageTable = new Hashtable();

		// Token: 0x0200005B RID: 91
		public enum TimePeriod
		{
			// Token: 0x04000225 RID: 549
			Step,
			// Token: 0x04000226 RID: 550
			Hour,
			// Token: 0x04000227 RID: 551
			Day,
			// Token: 0x04000228 RID: 552
			Week,
			// Token: 0x04000229 RID: 553
			Year
		}
	}
}
