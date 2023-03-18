using System;
using System.Collections;
using System.Windows.Forms;
using KMI.Sim;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for God.
	/// </summary>
	// Token: 0x02000008 RID: 8
	[Serializable]
	public class God : ActiveObject
	{
		// Token: 0x0600001E RID: 30 RVA: 0x000037DC File Offset: 0x000027DC
		public override void NewWeek()
		{
			if (A.SS.Level == 2 && A.ST.GetOtherPlayersEntities("").Length < 4)
			{
				A.ST.AddCompetitor();
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003820 File Offset: 0x00002820
		public override void NewDay()
		{
			if (A.SS.LevelManagementOn && A.SS.Level < 3)
			{
				float score = A.SA.getHumanScore("Cumulative Profit");
				if (score > (float)AppConstants.LevelChangeScoreLevel[A.SS.Level - 1])
				{
					A.SS.Level++;
					Player humanPlayer = (Player)A.ST.Player[""];
					string hints = "";
					if (A.SS.Level == 2)
					{
						hints = "In this level, you will need to deal with additional surprises. Watch out for snow storms and problems with your equipment. You will also be challenged by new competitors. You can now open a second store!";
					}
					if (A.SS.Level == 3)
					{
						hints = "In this level, the population of your city may change and road construction could hamper customer access to your store(s). Again, new competitors may spring up around you. You can now open as many stores as you would like.";
					}
					humanPlayer.SendModalMessage(A.R.GetString("Congratulations! You have reached Level {0}. {1}", new object[]
					{
						A.SS.Level,
						hints
					}), A.R.GetString("Challenge Level Change"), MessageBoxIcon.Exclamation);
				}
			}
			if (A.SS.SnowStorms)
			{
				if (A.ST.NextStorm.AddDays(2.0) < A.ST.Now)
				{
					if (A.ST.Now.Month == 12 || A.ST.Month < 4)
					{
						A.ST.NextStorm = A.ST.Now.AddDays((double)A.ST.Random.Next(5, 28));
					}
					else
					{
						A.ST.NextStorm = DateTime.MinValue;
					}
				}
				TimeSpan ts = A.ST.NextStorm - A.ST.Now;
				if (ts.Days == 3)
				{
					PlayerMessage.Broadcast(A.R.GetString("A major winter storm is expected in 3 days. Expect shoppers to be stocking up for the storm!"), A.R.GetString("National Weather Service"), NotificationColor.Yellow);
				}
				if (ts.Days == 1)
				{
					DateTime db = A.ST.NextStorm.AddDays(-1.0);
					foreach (object obj in A.ST.Customers.Values)
					{
						Customer c = (Customer)obj;
						if (c.State == Customer.States.Idle && c.WakeupTime > A.ST.NextStorm)
						{
							c.backupWakeUpTime = c.WakeupTime.AddDays(2.0);
							c.WakeupTime = new DateTime(db.Year, db.Month, db.Day, c.WakeupTime.Hour, c.WakeupTime.Minute, c.WakeupTime.Second);
							S.I.UnSubscribe(c, Simulator.TimePeriod.Step);
							S.I.Subscribe(c, c.WakeupTime);
						}
					}
				}
			}
			DateTime i = A.ST.Now;
			DateTime c2 = A.SS.NextConstruction;
			if (i.Year == c2.Year && i.Month == c2.Month && i.Day == c2.Day)
			{
				ArrayList temp = new ArrayList();
				foreach (object obj2 in A.ST.Entity.Values)
				{
					AppEntity e = (AppEntity)obj2;
					if (!e.AI)
					{
						temp.Add(e);
					}
				}
				if (temp.Count > 0)
				{
					AppEntity e = (AppEntity)temp[A.ST.Random.Next(temp.Count)];
					e.Building.Block.SetConstruction(A.SS.ConstructionDays / 7);
					A.I.Subscribe(e.Building.Block, Simulator.TimePeriod.Week);
					e.Player.SendMessage(A.R.GetString("Construction has started near your store. This may affect customer traffic. Construction is expected to last for about {0} weeks.", new object[]
					{
						A.SS.ConstructionDays / 7
					}), e.Name, NotificationColor.Red);
					A.SS.NextConstruction = A.ST.Now.AddDays((double)(180 + A.ST.Random.Next(180)));
				}
			}
		}
	}
}
