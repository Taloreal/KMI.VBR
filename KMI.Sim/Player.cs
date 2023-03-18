using System;
using System.Collections;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x02000070 RID: 112
	[Serializable]
	public class Player
	{
		// Token: 0x06000417 RID: 1047 RVA: 0x0001DE81 File Offset: 0x0001CE81
		public Player(string playerName, PlayerType playerType)
		{
			this.playerName = playerName;
			this.playerType = playerType;
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x0001DEA8 File Offset: 0x0001CEA8
		public string PlayerName
		{
			get
			{
				return this.playerName;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0001DEC0 File Offset: 0x0001CEC0
		public PlayerType PlayerType
		{
			get
			{
				return this.playerType;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x0001DED8 File Offset: 0x0001CED8
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x0001DF0B File Offset: 0x0001CF0B
		public ArrayList pendingMessages
		{
			get
			{
				if (this._pendingMessages == null)
				{
					this._pendingMessages = new ArrayList();
				}
				return this._pendingMessages;
			}
			set
			{
				this._pendingMessages = value;
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0001DF18 File Offset: 0x0001CF18
		public ArrayList GetAllMessages()
		{
			ArrayList result;
			lock (this)
			{
				ArrayList arrayList = (ArrayList)this.pendingMessages.Clone();
				this.pendingMessages.Clear();
				result = arrayList;
			}
			return result;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0001DF6C File Offset: 0x0001CF6C
		public void SendMessage(string message, string from, NotificationColor notificationColor)
		{
			if (!S.I.BlockMessage(message))
			{
				if (this.playerType != PlayerType.AI || S.MF.DesignerMode)
				{
					lock (this)
					{
						PlayerMessage playerMessage = new PlayerMessage(this.PlayerName, message, from, S.ST.Now, notificationColor);
						this.pendingMessages.Add(playerMessage);
						if (S.I.Multiplayer && this.PlayerName != "")
						{
							Player player = (Player)S.ST.Player[""];
							if (player != null && !player.pendingMessages.Contains(playerMessage))
							{
								player.pendingMessages.Add(playerMessage);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0001E064 File Offset: 0x0001D064
		public void SendPeriodicMessage(string message, string from, NotificationColor notificationColor, float daysBetweenMessages)
		{
			string key = message + this.PlayerName + from;
			if (S.I.PeriodicMessageTable.ContainsKey(key))
			{
				DateTime d = (DateTime)S.I.PeriodicMessageTable[key];
				if ((S.ST.Now - d).TotalSeconds / 86400.0 < (double)daysBetweenMessages)
				{
					return;
				}
				S.I.PeriodicMessageTable[key] = S.ST.Now;
			}
			else
			{
				S.I.PeriodicMessageTable.Add(key, S.ST.Now);
			}
			this.SendMessage(message, from, notificationColor);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0001E12B File Offset: 0x0001D12B
		public void SendModalMessage(string message, string title, MessageBoxIcon icon)
		{
			this.SendModalMessage(new ModalMessage(this.PlayerName, message, title, icon));
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0001E144 File Offset: 0x0001D144
		public void SendModalMessage(ModalMessage modalMessage)
		{
			if (this.playerType != PlayerType.AI || S.MF.DesignerMode)
			{
				lock (this)
				{
					this.pendingMessages.Add(modalMessage);
				}
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x0001E1A4 File Offset: 0x0001D1A4
		public ArrayList Surveys
		{
			get
			{
				return this.surveys;
			}
		}

		// Token: 0x040002BB RID: 699
		protected string playerName;

		// Token: 0x040002BC RID: 700
		protected PlayerType playerType;

		// Token: 0x040002BD RID: 701
		protected ArrayList _pendingMessages;

		// Token: 0x040002BE RID: 702
		protected ArrayList surveys = new ArrayList();
	}
}
