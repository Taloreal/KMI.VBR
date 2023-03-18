using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x02000061 RID: 97
	public partial class frmScoreboard : Form
	{
		// Token: 0x06000396 RID: 918 RVA: 0x0001A0D2 File Offset: 0x000190D2
		public frmScoreboard()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0001A0E4 File Offset: 0x000190E4
		protected void NewWeekHandler(object sender, EventArgs e)
		{
			if (this.GetData())
			{
				this.SetYScale();
				this.UpdateForm();
			}
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0001A110 File Offset: 0x00019110
		protected bool GetData()
		{
			try
			{
				this.input = S.SA.getScoreboard(frmScoreboard.ShowAIOwnedEntities);
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
			return true;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0001A944 File Offset: 0x00019944
		protected virtual void UpdateForm()
		{
			try
			{
				if (this.input.Scores.Length == 0)
				{
					this.kmiGraph1.Visible = false;
				}
				else
				{
					this.kmiGraph1.Visible = true;
					this.UpdateForm(this.input.Scores[0].Count - 1);
				}
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0001A9C4 File Offset: 0x000199C4
		protected virtual void UpdateForm(int index)
		{
			try
			{
				if (index >= 0)
				{
					object[,] array = new object[this.input.EntityNames.Length + 1, 2];
					for (int i = 0; i < this.input.EntityNames.Length; i++)
					{
						if (index >= this.input.Scores[i].Count)
						{
							return;
						}
						array[i + 1, 0] = this.input.EntityNames[i];
						array[i + 1, 1] = (float)this.input.Scores[i][index];
					}
					this.kmiGraph1.Draw(array);
				}
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e, this);
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0001AAA0 File Offset: 0x00019AA0
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0001AAAC File Offset: 0x00019AAC
		private void frmScoreboard_Resize(object sender, EventArgs e)
		{
			float num = Math.Min((float)base.Size.Width / 264f, (float)base.Size.Height / 280f);
			num = Math.Max(1f, num);
			this.kmiGraph1.TitleFontSize = num * 14f;
			this.kmiGraph1.DataPointLabelFontSize = num * 9f;
			this.kmiGraph1.LegendFontSize = num * 9f;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0001AB2F File Offset: 0x00019B2F
		private void btnPrint_Click(object sender, EventArgs e)
		{
			this.kmiGraph1.Title = this.Text;
			this.kmiGraph1.PrintGraph();
			this.kmiGraph1.Title = "";
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0001AB64 File Offset: 0x00019B64
		private void btnReplay_Click(object sender, EventArgs e)
		{
			if (this.btnReplay.Text == "Stop")
			{
				this.timer1.Stop();
				this.btnReplay.Text = "Replay";
				this.UpdateForm();
			}
			else
			{
				this.step = 0;
				this.btnReplay.Text = "Stop";
				this.timer1.Start();
			}
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0001ABDC File Offset: 0x00019BDC
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (this.input.Scores.Length == 0)
			{
				this.btnReplay.PerformClick();
			}
			else if (this.step < this.input.Scores[0].Count)
			{
				this.UpdateForm(this.step++);
			}
			else
			{
				this.timer1.Stop();
				this.btnReplay.Text = "Replay";
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0001AC6C File Offset: 0x00019C6C
		protected void SetYScale()
		{
			float num = (float)frmScoreboard.DefaultInitialScoreScale;
			float num2 = 0f;
			for (int i = 0; i < this.input.Scores.Length; i++)
			{
				foreach (object obj in this.input.Scores[i])
				{
					float val = (float)obj;
					num = Math.Max(val, num);
					num2 = Math.Min(val, num2);
				}
			}
			this.kmiGraph1.YMax = num;
			this.kmiGraph1.YMin = num2;
			this.kmiGraph1.AutoScaleY = false;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0001AD44 File Offset: 0x00019D44
		private void frmScoreboard_Closed(object sender, EventArgs e)
		{
			S.MF.NewWeek -= this.NewWeekHandler;
			if (frmScoreboard.UpdateDaily)
			{
				S.MF.NewDay -= this.NewWeekHandler;
			}
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0001AD8C File Offset: 0x00019D8C
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Scoreboard");
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0001AD9C File Offset: 0x00019D9C
		private void frmScoreboard_Load(object sender, EventArgs e)
		{
			this.kmiGraph1.DataPointLabels = true;
			this.kmiGraph1.Legend = false;
			this.kmiGraph1.GraphType = 5;
			S.MF.NewWeek += this.NewWeekHandler;
			if (frmScoreboard.UpdateDaily)
			{
				S.MF.NewDay += this.NewWeekHandler;
			}
			if (this.GetData())
			{
				this.Text = "Scoreboard - " + this.input.ScoreFriendlyName;
				this.SetYScale();
				this.UpdateForm();
			}
		}

		// Token: 0x04000249 RID: 585
		protected const int DefaultTitleFontSize = 14;

		// Token: 0x0400024A RID: 586
		protected const int DefaultLegendFontSize = 9;

		// Token: 0x0400024B RID: 587
		protected const int DataPointLabelFontSize = 9;

		// Token: 0x0400024C RID: 588
		protected const int DefaultFormWidth = 264;

		// Token: 0x0400024D RID: 589
		protected const int DefaultFormHeight = 280;

		// Token: 0x04000258 RID: 600
		private frmScoreboard.Input input;

		// Token: 0x04000259 RID: 601
		private int step;

		// Token: 0x0400025A RID: 602
		public static int DefaultInitialScoreScale = 50000;

		// Token: 0x0400025B RID: 603
		public static bool ShowAIOwnedEntities = true;

		// Token: 0x0400025C RID: 604
		public static bool UpdateDaily = false;

		// Token: 0x02000062 RID: 98
		[Serializable]
		public struct Input
		{
			// Token: 0x0400025D RID: 605
			public string[] EntityNames;

			// Token: 0x0400025E RID: 606
			public ArrayList[] Scores;

			// Token: 0x0400025F RID: 607
			public string ScoreFriendlyName;
		}
	}
}
