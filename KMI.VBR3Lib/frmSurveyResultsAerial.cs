using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz.City;
using KMI.Sim.Surveys;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmSurveyResultsAerial.
	/// </summary>
	// Token: 0x02000011 RID: 17
	public partial class frmSurveyResultsAerial : Form
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		// Token: 0x0600007B RID: 123 RVA: 0x00007A90 File Offset: 0x00006A90
		public frmSurveyResultsAerial(Survey survey)
		{
			this.InitializeComponent();
			this.survey = survey;
			this.optHomes.Enabled = false;
			this.optWorkplaces.Enabled = false;
			int i = 0;
			foreach (object obj in survey.SurveyQuestions)
			{
				SurveyQuestion q = (SurveyQuestion)obj;
				if (q.ShortName == "live")
				{
					this.optHomes.Enabled = true;
					this.liveQuestionIndex = i;
				}
				if (q.ShortName == "work")
				{
					this.optWorkplaces.Enabled = true;
					this.workQuestionIndex = i;
				}
				i++;
			}
			this.optBoth.Enabled = (this.optHomes.Enabled && this.optWorkplaces.Enabled);
			if (this.optHomes.Enabled)
			{
				this.optHomes.Checked = true;
			}
			else
			{
				this.optWorkplaces.Checked = true;
			}
			this.PlotResults();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00007F89 File Offset: 0x00006F89
		private void btnReturn_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00007F93 File Offset: 0x00006F93
		private void optHomes_Click(object sender, EventArgs e)
		{
			this.PlotResults();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00007F9D File Offset: 0x00006F9D
		private void optWorkplaces_Click(object sender, EventArgs e)
		{
			this.PlotResults();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00007FA7 File Offset: 0x00006FA7
		private void optBoth_Click(object sender, EventArgs e)
		{
			this.PlotResults();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00007FB4 File Offset: 0x00006FB4
		protected virtual void PlotResults()
		{
			ArrayList homes = new ArrayList();
			ArrayList workplaces = new ArrayList();
			foreach (object obj in this.survey.Responses)
			{
				SurveyResponse r = (SurveyResponse)obj;
				if (this.survey.InAllSegments(r))
				{
					int[] home = (int[])r.Answers[this.liveQuestionIndex];
					int[] workplace = (int[])r.Answers[this.workQuestionIndex];
					homes.Add(home);
					if (workplace[0] != -1)
					{
						workplaces.Add(workplace);
					}
					else
					{
						workplaces.Add(null);
					}
				}
			}
			A.MF.UpdateView();
			Graphics g = A.MF.BackBufferGraphics;
			Color color = Color.FromArgb(128, 0, 0, 255);
			Random spreader = new Random();
			if (this.optHomes.Checked)
			{
				foreach (object obj2 in homes)
				{
					int[] avestlot = (int[])obj2;
					PointF screenLoc = Utilities.SpreadOut(City.TransformWholeCity((float)avestlot[0], (float)avestlot[1], (float)avestlot[2]), 10f, spreader);
					g.FillEllipse(new SolidBrush(color), screenLoc.X + 12f, screenLoc.Y - 20f, 10f, 10f);
				}
			}
			if (this.optWorkplaces.Checked)
			{
				foreach (object obj3 in workplaces)
				{
					int[] avestlot = (int[])obj3;
					if (avestlot != null)
					{
						PointF screenLoc = Utilities.SpreadOut(City.TransformWholeCity((float)avestlot[0], (float)avestlot[1], (float)avestlot[2]), 10f, spreader);
						g.FillEllipse(new SolidBrush(color), screenLoc.X + 12f, screenLoc.Y - 20f, 10f, 10f);
					}
				}
			}
			if (this.optBoth.Checked)
			{
				for (int i = 0; i < homes.Count; i++)
				{
					if (workplaces[i] != null)
					{
						int[] home = (int[])homes[i];
						int[] workplace = (int[])workplaces[i];
						PointF screenLoc2 = Utilities.SpreadOut(City.TransformWholeCity((float)home[0], (float)home[1], (float)home[2]), 6f, spreader);
						PointF screenLoc3 = Utilities.SpreadOut(City.TransformWholeCity((float)workplace[0], (float)workplace[1], (float)workplace[2]), 10f, spreader);
						g.DrawLine(new Pen(color, 3f), new PointF(screenLoc2.X + 12f, screenLoc2.Y - 20f), new PointF(screenLoc3.X + 12f, screenLoc3.Y - 20f));
					}
				}
			}
			A.MF.picMain.Refresh();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000836C File Offset: 0x0000736C
		private void frmSurveyResultsAerial_Closed(object sender, EventArgs e)
		{
			A.MF.UpdateView();
		}

		// Token: 0x04000078 RID: 120
		protected Survey survey;

		// Token: 0x04000079 RID: 121
		private int liveQuestionIndex;

		// Token: 0x0400007A RID: 122
		private int workQuestionIndex;
	}
}
