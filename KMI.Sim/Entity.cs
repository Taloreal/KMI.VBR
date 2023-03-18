using System;
using System.Collections;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200007E RID: 126
	[Serializable]
	public class Entity : ActiveObject
	{
		// Token: 0x060004E8 RID: 1256 RVA: 0x00026568 File Offset: 0x00025568
		public Entity(Player player, string name)
		{
			Simulator instance = Simulator.Instance;
			this.player = player;
			this.name = name;
			this.ID = S.ST.GetNextID();
			this.journal = new Journal(name, Journal.JournalNumericDataSeriesNames, (float)Journal.JournalDaysPerPeriod);
			this.complaintBuffer = new ComplaintBuffer(this);
			foreach (string seriesName in this.journal.NumericDataSeriesNames)
			{
				for (int j = 0; j < S.ST.CurrentWeek; j++)
				{
					this.journal.AddNumericData(seriesName, 0f);
				}
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x00026620 File Offset: 0x00025620
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x00026638 File Offset: 0x00025638
		public Player Player
		{
			get
			{
				return this.player;
			}
			set
			{
				this.player = value;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x00026644 File Offset: 0x00025644
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x0002665C File Offset: 0x0002565C
		public long ID
		{
			get
			{
				return this.iD;
			}
			set
			{
				this.iD = value;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x00026668 File Offset: 0x00025668
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x00026680 File Offset: 0x00025680
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x0002668C File Offset: 0x0002568C
		public Journal Journal
		{
			get
			{
				return this.journal;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x000266A4 File Offset: 0x000256A4
		// (set) Token: 0x060004F1 RID: 1265 RVA: 0x000266BC File Offset: 0x000256BC
		public GeneralLedger GL
		{
			get
			{
				return this.gl;
			}
			set
			{
				this.gl = value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x000266C8 File Offset: 0x000256C8
		public bool Retired
		{
			get
			{
				return S.ST.RetiredEntity.ContainsValue(this);
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x000266EC File Offset: 0x000256EC
		public bool AI
		{
			get
			{
				return this.Player.PlayerType == PlayerType.AI;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x0002670C File Offset: 0x0002570C
		public ComplaintBuffer ComplaintBuffer
		{
			get
			{
				return this.complaintBuffer;
			}
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00026724 File Offset: 0x00025724
		public void Retire(ModalMessage message)
		{
			base.Retire();
			S.ST.Entity.Remove(this.ID);
			S.ST.RetiredEntity.Add(this.ID, this);
			this.Player.SendModalMessage(message);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00026780 File Offset: 0x00025780
		public override void Retire()
		{
			base.Retire();
			S.ST.Entity.Remove(this.ID);
			S.ST.RetiredEntity.Add(this.ID, this);
			if (this.GL.AccountBalance("Cash") <= 0f)
			{
				if (this.AI)
				{
					PlayerMessage.Broadcast(S.R.GetString("The {0} named {1} has gone out of business!!", new object[]
					{
						S.I.EntityName.ToLower(),
						this.Name
					}), "", NotificationColor.Green);
				}
				else
				{
					PlayerMessage.BroadcastAllBut(this.Player.PlayerName, S.R.GetString("The {0} named {1} has gone out of business!!", new object[]
					{
						S.I.EntityName.ToLower(),
						this.Name
					}), "", NotificationColor.Green);
					if (S.ST.EntityCount(this.Player) > 0)
					{
						this.Player.SendModalMessage(S.R.GetString("Your {0} named {1} has run out of cash and is now out of business. Keep a close eye on your existing businesses! The net worth of the {0} (positive or negative) will be transferred to your remaining {0}(s).", new object[]
						{
							S.I.EntityName.ToLower(),
							this.Name
						}), S.R.GetString("Out of Business"), MessageBoxIcon.Exclamation);
						this.TransferNetWorthUponRetirement();
					}
					else
					{
						this.Player.SendModalMessage(new GameOverMessage(this.Player.PlayerName, S.R.GetString("Your {0} has run out of cash and is now out of business! That's all part of learning. Give it another try!", new object[]
						{
							S.I.EntityName.ToLower()
						})));
					}
				}
			}
			else if (S.ST.EntityCount(this.Player) == 0)
			{
				this.Player.SendModalMessage(new GameOverMessage(this.Player.PlayerName, S.R.GetString("You have closed your only {0}. This simulation is over. Give it another try!", new object[]
				{
					S.I.EntityName.ToLower()
				})));
			}
			else
			{
				this.Player.SendModalMessage(S.R.GetString("The net worth of the {0} (positive or negative) will be transferred to your remaining {0}(s).", new object[]
				{
					S.I.EntityName.ToLower(),
					this.Name
				}), S.R.GetString("Business Closed"), MessageBoxIcon.Exclamation);
				this.TransferNetWorthUponRetirement();
			}
			this.Journal.AddEntry(S.R.GetString("Closed {0} named {1} on {2}.", new string[]
			{
				S.I.EntityName.ToLower(),
				this.Name.ToLower(),
				S.ST.Now.ToLongDateString()
			}));
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00026A60 File Offset: 0x00025A60
		protected virtual void TransferNetWorthUponRetirement()
		{
			Entity[] playersEntities = S.ST.GetPlayersEntities(this.Player.PlayerName);
			float num = this.GL.AccountBalance("Cash");
			num -= this.GL.AccountBalance("Liabilities", S.ST.CurrentWeek - 1);
			float amount = num / (float)Math.Max(1, playersEntities.Length);
			foreach (Entity entity in playersEntities)
			{
				entity.GL.Post("Cash", amount, "Paid-in Capital");
			}
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00026AFC File Offset: 0x00025AFC
		public virtual float CriticalResourceBalance()
		{
			return this.GL.AccountBalance("Cash");
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x00026B20 File Offset: 0x00025B20
		public Hashtable Reserved
		{
			get
			{
				if (this.reserved == null)
				{
					this.reserved = new Hashtable();
				}
				return this.reserved;
			}
		}

		// Token: 0x0400036C RID: 876
		protected Player player;

		// Token: 0x0400036D RID: 877
		protected long iD;

		// Token: 0x0400036E RID: 878
		protected string name;

		// Token: 0x0400036F RID: 879
		protected Journal journal;

		// Token: 0x04000370 RID: 880
		protected GeneralLedger gl;

		// Token: 0x04000371 RID: 881
		protected ComplaintBuffer complaintBuffer;

		// Token: 0x04000372 RID: 882
		protected Hashtable reserved;
	}
}
