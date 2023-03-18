using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using KMI.Sim.Academics;
using KMI.Sim.Drawables;
using KMI.Sim.Surveys;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000039 RID: 57
	public class SimStateAdapter : MarshalByRefObject
	{
		// Token: 0x0600021C RID: 540 RVA: 0x00011644 File Offset: 0x00010644
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool Ping()
		{
			return true;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00011658 File Offset: 0x00010658
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void ProvideCash(long entityID, float amount)
		{
			Entity entity = SimStateAdapter.CheckEntityExists(entityID);
			entity.GL.Post("Cash", amount, "Paid-in Capital");
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00011684 File Offset: 0x00010684
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual SimStateAdapter.ViewUpdate GetViewUpdate(string viewName, long entityID, params object[] args)
		{
			Entity entity = null;
			if (entityID != -1L || !S.I.SafeViewsForNoEntity.Contains(viewName))
			{
				entity = SimStateAdapter.CheckEntityExists(entityID);
			}
			SimStateAdapter.ViewUpdate viewUpdate = new SimStateAdapter.ViewUpdate();
			viewUpdate.Drawables = S.I.View(viewName).BuildDrawables(entityID, args);
			viewUpdate.Now = S.ST.Now;
			viewUpdate.CurrentWeek = S.ST.CurrentWeek;
			if (entity != null)
			{
				viewUpdate.Cash = entity.CriticalResourceBalance();
			}
			viewUpdate.EntityNames = S.ST.EntityNameTable();
			return viewUpdate;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00011720 File Offset: 0x00010720
		[MethodImpl(MethodImplOptions.Synchronized)]
		public GeneralLedger GetGL(long entityID)
		{
			SimStateAdapter.CheckEntityExists(entityID);
			return ((Entity)this.simState.Entity[entityID]).GL;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0001175C File Offset: 0x0001075C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmActionsJournal.Input getActionsJournal(long entityID)
		{
			if (entityID != -1L)
			{
				SimStateAdapter.CheckEntityExists(entityID);
			}
			frmActionsJournal.Input result = default(frmActionsJournal.Input);
			result.Journals = new ArrayList();
			if (entityID == -1L)
			{
				foreach (object obj in S.ST.Entity.Values)
				{
					Entity entity = (Entity)obj;
					result.Journals.Add(entity.Journal);
				}
				foreach (object obj2 in S.ST.RetiredEntity.Values)
				{
					Entity entity = (Entity)obj2;
					result.Journals.Add(entity.Journal);
				}
			}
			else
			{
				Entity entity = (Entity)S.ST.Entity[entityID];
				result.Journals.Add(entity.Journal);
			}
			result.StartDate = S.ST.SimSettings.StartDate;
			result.EndDate = S.ST.Now;
			return result;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000118E4 File Offset: 0x000108E4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int getHumanPlayerCount()
		{
			this.LogMethodCall(new object[0]);
			int num = 0;
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Player.PlayerType == PlayerType.Human)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00011980 File Offset: 0x00010980
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual frmScoreboard.Input getScoreboard(bool showAIOwnedEntities)
		{
			this.LogMethodCall(new object[0]);
			frmScoreboard.Input result = default(frmScoreboard.Input);
			result.ScoreFriendlyName = Journal.ScoreSeriesName;
			Hashtable hashtable = new Hashtable();
			ArrayList arrayList = new ArrayList(S.ST.Entity.Values);
			arrayList.AddRange(S.ST.RetiredEntity.Values);
			foreach (object obj in arrayList)
			{
				Entity entity = (Entity)obj;
				if (showAIOwnedEntities || !entity.AI)
				{
					ArrayList arrayList2 = new ArrayList();
					for (int i = 0; i < S.ST.CurrentWeek; i++)
					{
						arrayList2.Add(0f);
					}
					if (!hashtable.ContainsKey(entity.Player.PlayerName))
					{
						hashtable.Add(entity.Player.PlayerName, arrayList2);
					}
				}
			}
			foreach (object obj2 in arrayList)
			{
				Entity entity = (Entity)obj2;
				if (showAIOwnedEntities || !entity.AI)
				{
					ArrayList arrayList2 = entity.Journal.NumericDataSeries(Journal.ScoreSeriesName);
					string key = entity.Player.PlayerName;
					if (entity.AI)
					{
						key = entity.Name;
					}
					ArrayList arrayList3 = (ArrayList)hashtable[key];
					for (int i = 0; i < arrayList3.Count; i++)
					{
						arrayList3[i] = (float)arrayList3[i] + (float)arrayList2[Math.Min(i, arrayList2.Count - 1)];
					}
				}
			}
			result.EntityNames = new string[hashtable.Count];
			hashtable.Keys.CopyTo(result.EntityNames, 0);
			result.Scores = new ArrayList[hashtable.Count];
			hashtable.Values.CopyTo(result.Scores, 0);
			return result;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00011C14 File Offset: 0x00010C14
		[MethodImpl(MethodImplOptions.Synchronized)]
		public SimSettings getSimSettings()
		{
			this.LogMethodCall(new object[0]);
			return this.simState.SimSettings;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00011C40 File Offset: 0x00010C40
		[MethodImpl(MethodImplOptions.Synchronized)]
		public byte[] getPdfAssignment()
		{
			this.LogMethodCall(new object[0]);
			return this.simState.SimSettings.PdfAssignment;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00011C70 File Offset: 0x00010C70
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool getMultiplayer()
		{
			this.LogMethodCall(new object[0]);
			return this.simState.Multiplayer;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00011C9C File Offset: 0x00010C9C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool RoleBasedMultiplayer()
		{
			this.LogMethodCall(new object[0]);
			return this.simState.RoleBasedMultiplayer;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00011CC8 File Offset: 0x00010CC8
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Player CreateClientPlayer(string playerName, string password)
		{
			if (S.ST.Multiplayer && S.I.UserAdminSettings.PasswordsForMultiplayer && (password.Length < 3 || !S.ST.ValidateMultiplayerTeamPassword(playerName, password)))
			{
				throw new frmJoinMultiplayerSession.BadTeamPasswordException();
			}
			return this.CreatePlayer(playerName, PlayerType.Human);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00011D2C File Offset: 0x00010D2C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Player CreatePlayer(string playerName, PlayerType playerType)
		{
			this.LogMethodCall(new object[]
			{
				playerName,
				playerType
			});
			Player player = null;
			Simulator instance = Simulator.Instance;
			foreach (object obj in this.simState.Player.Values)
			{
				Player player2 = (Player)obj;
				if (player2.PlayerName.ToUpper() == playerName.ToUpper())
				{
					player = player2;
				}
			}
			if (player == null)
			{
				player = S.I.SimFactory.CreatePlayer(playerName, playerType);
				this.simState.Player.Add(playerName, player);
			}
			else if (!this.simState.RoleBasedMultiplayer)
			{
				player.SendMessage(S.R.GetString("Welcome back, {0}.", new object[]
				{
					player.PlayerName
				}), "", NotificationColor.Green);
			}
			return player;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00011E68 File Offset: 0x00010E68
		[MethodImpl(MethodImplOptions.Synchronized)]
		public string GetEntityPlayer(long entityID)
		{
			this.LogMethodCall(new object[]
			{
				entityID
			});
			string result;
			if (this.simState.Entity.Count == 0)
			{
				result = null;
			}
			else
			{
				SimStateAdapter.CheckEntityExists(entityID);
				Entity entity = (Entity)this.simState.Entity[entityID];
				result = entity.Player.PlayerName;
			}
			return result;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00011EE0 File Offset: 0x00010EE0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int getCurrentWeek()
		{
			this.LogMethodCall(new object[0]);
			return Simulator.Instance.SimState.CurrentWeek;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00011F10 File Offset: 0x00010F10
		[MethodImpl(MethodImplOptions.Synchronized)]
		public Entity TryAddEntity(string playerName, string entityName)
		{
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Name.ToUpper() == entityName.ToUpper())
				{
					throw new SimApplicationException(S.R.GetString("That name is already taken. Please try another."));
				}
			}
			foreach (object obj2 in S.ST.RetiredEntity.Values)
			{
				Entity entity = (Entity)obj2;
				if (entity.Name.ToUpper() == entityName.ToUpper())
				{
					throw new SimApplicationException(S.R.GetString("A previously existing {0} had that name. Please try another.", new object[]
					{
						S.I.EntityName.ToLower()
					}));
				}
			}
			Entity entity2 = S.I.SimFactory.CreateEntity((Player)S.ST.Player[playerName], entityName);
			S.ST.Entity.Add(entity2.ID, entity2);
			return entity2;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000120A4 File Offset: 0x000110A4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void CloseEntity(long entityID)
		{
			this.LogMethodCall(new object[0]);
			Entity entity = SimStateAdapter.CheckEntityExists(entityID);
			entity.Retire();
		}

		// Token: 0x0600022D RID: 557 RVA: 0x000120D0 File Offset: 0x000110D0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void ChangeEntityOwner(long entityID, string newOwnerName)
		{
			SimStateAdapter.CheckEntityExists(entityID);
			Entity entity = (Entity)this.simState.Entity[entityID];
			foreach (object obj in this.simState.Player.Values)
			{
				Player player = (Player)obj;
				if (player.PlayerName == newOwnerName)
				{
					entity.Player = player;
					return;
				}
			}
			throw new SimApplicationException("Player name not found.");
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0001218C File Offset: 0x0001118C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual float getHumanScore(string seriesName)
		{
			this.LogMethodCall(new object[]
			{
				seriesName
			});
			float num = 0f;
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Player.PlayerType == PlayerType.Human)
				{
					num += entity.Journal.NumericDataSeriesLastEntry(seriesName);
				}
			}
			foreach (object obj2 in S.ST.RetiredEntity.Values)
			{
				Entity entity = (Entity)obj2;
				if (entity.Player.PlayerType == PlayerType.Human)
				{
					num += entity.Journal.NumericDataSeriesLastEntry(seriesName);
				}
			}
			return num;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x000122D0 File Offset: 0x000112D0
		[MethodImpl(MethodImplOptions.Synchronized)]
		public int Level()
		{
			return S.SS.Level;
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000230 RID: 560 RVA: 0x000122EC File Offset: 0x000112EC
		protected SimState simState
		{
			get
			{
				return Simulator.Instance.SimState;
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00012308 File Offset: 0x00011308
		public static Entity CheckEntityExists(long entityID)
		{
			if (S.ST.Entity.Contains(entityID))
			{
				return (Entity)S.ST.Entity[entityID];
			}
			EntityNotFoundException ex = new EntityNotFoundException(S.R.GetString("{0} no longer exists.", new object[]
			{
				S.I.EntityName
			}));
			throw ex;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00012380 File Offset: 0x00011380
		public Guid GetSimulatorID()
		{
			return S.I.GUID;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0001239C File Offset: 0x0001139C
		protected void LogMethodCall(params object[] args)
		{
			if (S.MF.DesignerMode)
			{
				if (!S.I.Client)
				{
					StackFrame stackFrame = new StackFrame(1);
					MethodBase method = stackFrame.GetMethod();
					ParameterInfo[] parameters = method.GetParameters();
					S.MF.SaveMacroAction(new MacroAction(method, args, S.ST.Now));
				}
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00012400 File Offset: 0x00011400
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList getSurveys(string playerName)
		{
			return ((Player)S.ST.Player[playerName]).Surveys;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0001242C File Offset: 0x0001142C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void RenameEntity(long entityID, string newName)
		{
			Entity entity = SimStateAdapter.CheckEntityExists(entityID);
			entity.Name = newName;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0001244C File Offset: 0x0001144C
		[MethodImpl(MethodImplOptions.Synchronized)]
		public long GetAnEntityIdForPlayer(string playerName)
		{
			Entity[] playersEntities = S.ST.GetPlayersEntities(playerName);
			long result;
			if (playersEntities.Length == 0)
			{
				result = -1L;
			}
			else
			{
				result = playersEntities[0].ID;
			}
			return result;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00012484 File Offset: 0x00011484
		[MethodImpl(MethodImplOptions.Synchronized)]
		public string[] GetOtherOwnedEntities(long entityID)
		{
			Entity entity = SimStateAdapter.CheckEntityExists(entityID);
			ArrayList arrayList = new ArrayList();
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity2 = (Entity)obj;
				if (entity != entity2 && entity.Player == entity2.Player)
				{
					arrayList.Add(entity2.Name);
				}
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00012548 File Offset: 0x00011548
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual Survey ConductAndAddSurvey(string playerName, long entityID, ArrayList questions, int numToSurvey, float cost)
		{
			string[] array = new string[S.ST.Entity.Count];
			int num = 0;
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				array[num++] = entity.Name;
			}
			Survey survey = S.I.SimFactory.CreateSurvey(entityID, this.simState.Now, array, questions);
			survey.Execute(numToSurvey);
			ArrayList surveys = ((Player)S.ST.Player[playerName]).Surveys;
			surveys.Add(survey);
			if (surveys.Count > Survey.MaxSurveys)
			{
				surveys.RemoveAt(0);
			}
			if (entityID != -1L && S.ST.Entity.ContainsKey(entityID))
			{
				Entity entity = (Entity)S.ST.Entity[entityID];
				if (Survey.BillForSurveys)
				{
					entity.GL.Post("Surveys", cost, "Cash");
				}
				entity.Journal.AddEntry(S.R.GetString("Conducted survey of {0} {1}.", new object[]
				{
					Utilities.FU(survey.Responses.Count),
					Survey.SurveyableObjectName
				}));
			}
			return survey;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00012700 File Offset: 0x00011700
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void SendMessage(string fromPlayerName, string toPlayerName, string message)
		{
			Player player = (Player)S.ST.Player[toPlayerName];
			player.SendMessage(message, fromPlayerName, NotificationColor.Blue);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00012730 File Offset: 0x00011730
		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool IsUniqueEntityName(string name)
		{
			foreach (object obj in S.ST.Entity.Values)
			{
				Entity entity = (Entity)obj;
				if (entity.Name == name)
				{
					return false;
				}
			}
			foreach (object obj2 in S.ST.RetiredEntity.Values)
			{
				Entity entity = (Entity)obj2;
				if (entity.Name == name)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00012828 File Offset: 0x00011828
		[MethodImpl(MethodImplOptions.Synchronized)]
		public AcademicGod GetAcademicGod()
		{
			return S.ST.GetAcademicGod();
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00012844 File Offset: 0x00011844
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void SetRunTo(DateTime date)
		{
			S.ST.RunToDate = date;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00012854 File Offset: 0x00011854
		[MethodImpl(MethodImplOptions.Synchronized)]
		public frmRunTo.Input GetRunTo()
		{
			return new frmRunTo.Input
			{
				runTo = S.ST.RunToDate,
				now = S.ST.Now
			};
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00012894 File Offset: 0x00011894
		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void SetRunTo(int daysAhead)
		{
			DateTime dateTime = new DateTime(S.ST.Now.Year, S.ST.Now.Month, S.ST.Now.Day);
			S.ST.RunToDate = dateTime.AddDays((double)daysAhead);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x000128F4 File Offset: 0x000118F4
		[MethodImpl(MethodImplOptions.Synchronized)]
		public ArrayList GetPlayerMessages(string playerName)
		{
			if (S.ST != null)
			{
				Player player = (Player)S.ST.Player[playerName];
				if (player != null)
				{
					return player.GetAllMessages();
				}
			}
			return null;
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0001293C File Offset: 0x0001193C
		public override object InitializeLifetimeService()
		{
			return null;
		}

		// Token: 0x0200003A RID: 58
		[Serializable]
		public class ViewUpdate
		{
			// Token: 0x04000159 RID: 345
			public Drawable[] Drawables;

			// Token: 0x0400015A RID: 346
			public DateTime Now;

			// Token: 0x0400015B RID: 347
			public int CurrentWeek;

			// Token: 0x0400015C RID: 348
			public Hashtable EntityNames;

			// Token: 0x0400015D RID: 349
			public float Cash;

			// Token: 0x0400015E RID: 350
			public object AppData;
		}
	}
}
