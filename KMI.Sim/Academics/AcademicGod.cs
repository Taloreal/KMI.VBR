using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Academics
{
	// Token: 0x02000080 RID: 128
	[Serializable]
	public class AcademicGod : ActiveObject
	{
		// Token: 0x060004FB RID: 1275 RVA: 0x00026B68 File Offset: 0x00025B68
		public AcademicGod()
		{
			this.pageBank = PageBank.LoadFromXML(AcademicGod.PageBankPath + Path.DirectorySeparatorChar + "Pages.xml");
			this.AcademicLevel = 0;
			S.I.Subscribe(this, Simulator.TimePeriod.Day);
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x00026BC0 File Offset: 0x00025BC0
		protected Level CurrentLevel
		{
			get
			{
				return this.pageBank.Levels[Math.Min(this.AcademicLevel, this.pageBank.Levels.Length - 1)];
			}
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00026BF8 File Offset: 0x00025BF8
		public override void NewDay()
		{
			Player player = (Player)S.ST.Player[""];
			if (this.TimeForNextLevel())
			{
				string text = this.QuestionPowersLeft();
				if (text != "")
				{
					if (!this.showedQuestionsRemain)
					{
						player.SendModalMessage(S.R.GetString("You've reached the {0} goal for Level {1}. And you didn't even view all the available hints! To officially complete this level, please click {2} to see the remaining hints.", new object[]
						{
							Journal.ScoreSeriesName.ToLower(),
							this.AcademicLevel + 1,
							Utilities.FormatCommaSeries(text)
						}), S.R.GetString("Congratulations"), MessageBoxIcon.Exclamation);
						this.showedQuestionsRemain = true;
					}
				}
				else
				{
					bool lastLevel = this.AcademicLevel == this.pageBank.Levels.Length - 1;
					player.SendModalMessage(new LevelEndTestMessage(player.PlayerName, this.CurrentLevel.LevelIntroMessage, this.AcademicLevel + 1, this.FindAllAskedQuestions(this.AcademicLevel), lastLevel));
					this.AcademicLevel++;
				}
			}
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00026D14 File Offset: 0x00025D14
		protected virtual bool TimeForNextLevel()
		{
			return this.Score > this.CurrentLevel.Goal;
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x00026D3C File Offset: 0x00025D3C
		protected float Score
		{
			get
			{
				ArrayList arrayList = new ArrayList(S.ST.Entity.Values);
				arrayList.AddRange(S.ST.RetiredEntity.Values);
				float num = 0f;
				foreach (object obj in arrayList)
				{
					Entity entity = (Entity)obj;
					if (!entity.AI)
					{
						num += entity.Journal.NumericDataSeriesLastEntry(Journal.ScoreSeriesName);
					}
				}
				return num;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x00026DF4 File Offset: 0x00025DF4
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x00026E0C File Offset: 0x00025E0C
		public int AcademicLevel
		{
			get
			{
				return this.academicLevel;
			}
			set
			{
				this.academicLevel = value;
				this.showedQuestionsRemain = false;
				PropertyInfo[] properties = S.SS.GetType().GetProperties();
				foreach (string str in this.CurrentLevel.Powers)
				{
					foreach (PropertyInfo propertyInfo in properties)
					{
						MethodInfo setMethod = propertyInfo.GetSetMethod();
						if (propertyInfo.Name == str + "EnabledForOwner")
						{
							lock (S.SA)
							{
								setMethod.Invoke(S.SS, new object[]
								{
									true
								});
							}
							break;
						}
					}
				}
				S.MF.EnableDisable();
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00026F18 File Offset: 0x00025F18
		public Question[] FindAllAskedQuestions(int level)
		{
			ArrayList arrayList = new ArrayList();
			foreach (Page page in this.pageBank.Levels[level].Pages)
			{
				foreach (Question question in page.Questions)
				{
					if (question.Answer != null)
					{
						arrayList.Add(question);
					}
				}
			}
			return (Question[])arrayList.ToArray(typeof(Question));
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00026FB8 File Offset: 0x00025FB8
		public static void HandleLevelEnd(LevelEndTestMessage m)
		{
			MessageBox.Show(S.R.GetString("You have completed Level {0}. You will now be asked to answer review questions from this level. Hit Submit only after completing all questions.", new object[]
			{
				m.NewLevel
			}), S.R.GetString("Congratulations!!"));
			new frmQuestions(frmQuestions.Modes.LevelEndTest, m.Questions)
			{
				Text = S.R.GetString("Review Test for Level {0}", new object[]
				{
					m.NewLevel
				})
			}.ShowDialog();
			if (MessageBox.Show(S.R.GetString("We suggest saving after each level. Do you want to save now?"), S.R.GetString("Save Now?"), MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				S.MF.mnuFileSaveAs.PerformClick();
			}
			if (!m.LastLevel && m.Message != "")
			{
				MessageBox.Show(m.Message, S.R.GetString("Welcome to Level {0}", new object[]
				{
					m.NewLevel + 1
				}));
			}
			if (m.LastLevel)
			{
				MessageBox.Show(S.R.GetString("You have completed all the levels. Review your test scores under Options or use File->New to start again."), S.R.GetString("Congratulations"));
				S.MF.StopSimulation();
			}
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00027114 File Offset: 0x00026114
		public float GradeForLevel(int level)
		{
			float num = 0f;
			float num2 = 0f;
			foreach (Page page in this.pageBank.Levels[level].Pages)
			{
				foreach (Question question in page.Questions)
				{
					num2 += 1f;
					if (question.Correct)
					{
						num += 1f;
					}
				}
			}
			float result;
			if (num2 == 0f)
			{
				result = 0f;
			}
			else
			{
				result = num / num2;
			}
			return result;
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x000271D0 File Offset: 0x000261D0
		public static void Prompt(object sender)
		{
			string text = ((MenuItem)sender).Text;
			text = Utilities.NoEllipsis(Utilities.NoAmpersand(text)).Replace(" ", "");
			AcademicGod academicGod = S.SA.GetAcademicGod();
			Page page = academicGod.FindNextPage(text);
			if (page != null)
			{
				Form form = new frmPage(page);
				form.ShowDialog();
			}
			academicGod.NewDay();
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0002723C File Offset: 0x0002623C
		protected Page FindNextPage(string power)
		{
			float score = this.Score;
			foreach (Page page in this.CurrentLevel.Pages)
			{
				if (page.Questions[0].Answer == null && page.Power == power && score >= page.MinScore)
				{
					return page;
				}
			}
			return null;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x000272B4 File Offset: 0x000262B4
		protected string QuestionPowersLeft()
		{
			string text = "";
			foreach (Page page in this.CurrentLevel.Pages)
			{
				if (page.Questions[0].Answer == null)
				{
					text = text + Utilities.AddSpaces(page.Power) + ", ";
				}
			}
			return text;
		}

		// Token: 0x04000373 RID: 883
		protected PageBank pageBank;

		// Token: 0x04000374 RID: 884
		protected int academicLevel = -1;

		// Token: 0x04000375 RID: 885
		public static string PageBankPath;

		// Token: 0x04000376 RID: 886
		protected bool showedQuestionsRemain;
	}
}
