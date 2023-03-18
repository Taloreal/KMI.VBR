using System;
using System.Threading;

namespace KMI.Sim
{
	// Token: 0x02000021 RID: 33
	public class SimEngine
	{
		// Token: 0x0600016D RID: 365 RVA: 0x0000C7A1 File Offset: 0x0000B7A1
		public SimEngine()
		{
			this.simulator = Simulator.Instance;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000C7D0 File Offset: 0x0000B7D0
		public void PauseThread()
		{
			this.running = false;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000C7DC File Offset: 0x0000B7DC
		public void ResumeThread()
		{
			lock (this.pauseLock)
			{
				if (this.mainThread == null)
				{
					this.mainThread = new Thread(new ThreadStart(this.MainLoop));
					this.mainThread.IsBackground = true;
					this.mainThread.Priority = ThreadPriority.Lowest;
					this.stopEngine = false;
					this.running = true;
					this.mainThread.Start();
				}
				else
				{
					this.running = true;
					Monitor.Pulse(this.pauseLock);
				}
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000170 RID: 368 RVA: 0x0000C88C File Offset: 0x0000B88C
		public bool Running
		{
			get
			{
				return this.running;
			}
		}

		// Token: 0x17000063 RID: 99
		// (set) Token: 0x06000171 RID: 369 RVA: 0x0000C8A4 File Offset: 0x0000B8A4
		public int Skip
		{
			set
			{
				this.skip = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (set) Token: 0x06000172 RID: 370 RVA: 0x0000C8AE File Offset: 0x0000B8AE
		public int StepPeriod
		{
			set
			{
				this.stepPeriod = value;
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000C8B8 File Offset: 0x0000B8B8
		public void Draw()
		{
			S.MF.UpdateView();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000C8C8 File Offset: 0x0000B8C8
		private void MainLoop()
		{
			while (!this.stopEngine)
			{
				lock (this.pauseLock)
				{
					if (!this.running)
					{
						Monitor.Wait(this.pauseLock);
					}
				}
				S.MF.PlayMacroAction();
				int tickCount = Environment.TickCount;
				lock (S.SA)
				{
					if (!S.I.Client)
					{
						this.ProcessTick();
					}
				}
				int num = tickCount + this.stepPeriod - Environment.TickCount;
				if (num > 0)
				{
					Thread.Sleep(num);
				}
				if (this.skip <= 0 || this.count++ % this.skip == 0)
				{
					S.MF.Invoke(new SimEngine.NoArgDelegate(this.Draw));
				}
			}
			this.mainThread = null;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000C9F0 File Offset: 0x0000B9F0
		public void ProcessTick()
		{
			try
			{
				if (S.ST.Now >= S.SS.StopDate && S.SS.StopDate != DateTime.MinValue)
				{
					Player player = (Player)S.ST.Player[S.I.ThisPlayerName];
					if (S.I.Demo)
					{
						S.MF.DirtySimState = false;
						string @string = S.R.GetString("Simulations in this demo version are limited to {0} simulated days. In the classroom version, simulations can run indefinitely.", new object[]
						{
							S.I.DemoDuration
						});
						this.running = false;
						player.SendModalMessage(new GameOverMessage(S.I.ThisPlayerName, @string));
					}
					else if (S.SS.StudentOrg > 0)
					{
						this.running = false;
						player.SendModalMessage(new StopDateReachedMessage());
					}
				}
				else if (S.ST.Now >= S.ST.RunToDate)
				{
					this.running = false;
					S.ST.RunToDate = DateTime.MaxValue;
					Player player = (Player)S.ST.Player[S.I.ThisPlayerName];
					player.SendModalMessage(new RunToDateReachedMessage());
				}
				else
				{
					SimState simState = Simulator.Instance.SimState;
					simState.Step();
					simState.UpdateEventQueue();
					foreach (object obj in Simulator.FiringOrder)
					{
						Simulator.TimePeriod timePeriod = (Simulator.TimePeriod)obj;
						if (timePeriod == Simulator.TimePeriod.Step)
						{
							simState.NewTimePeriod(timePeriod);
						}
						else if (timePeriod == Simulator.TimePeriod.Hour && simState.NewHour)
						{
							simState.NewTimePeriod(timePeriod);
						}
						else if (timePeriod == Simulator.TimePeriod.Day && simState.NewDay)
						{
							simState.NewTimePeriod(timePeriod);
						}
						else if (timePeriod == Simulator.TimePeriod.Week && simState.NewWeek)
						{
							simState.NewTimePeriod(timePeriod);
						}
						else if (timePeriod == Simulator.TimePeriod.Year && simState.NewYear)
						{
							simState.NewTimePeriod(timePeriod);
						}
					}
				}
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e);
			}
		}

		// Token: 0x040000ED RID: 237
		private object pauseLock = new object();

		// Token: 0x040000EE RID: 238
		protected bool running;

		// Token: 0x040000EF RID: 239
		protected int skip;

		// Token: 0x040000F0 RID: 240
		protected int stepPeriod;

		// Token: 0x040000F1 RID: 241
		private int count = 0;

		// Token: 0x040000F2 RID: 242
		protected Thread mainThread;

		// Token: 0x040000F3 RID: 243
		protected bool stopEngine = false;

		// Token: 0x040000F4 RID: 244
		protected Simulator simulator;

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x06000177 RID: 375
		public delegate void NoArgDelegate();
	}
}
