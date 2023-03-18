using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim.Surveys;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmAppSurveyResults.
	/// </summary>
	// Token: 0x02000033 RID: 51
	public partial class frmAppSurveyResults : frmSurveyResults
	{
		// Token: 0x06000167 RID: 359 RVA: 0x00013ED5 File Offset: 0x00012ED5
		public frmAppSurveyResults(string playerName, string qualifyingQuestionResponse) : base(playerName, qualifyingQuestionResponse)
		{
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00013EE4 File Offset: 0x00012EE4
		protected override void cboQuestion_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.question = (SurveyQuestion)this.survey.SurveyQuestions[this.cboQuestion.SelectedIndex];
			if (this.question.ShortName == "live" || this.question.ShortName == "work")
			{
				this.kmiGraph1.Visible = false;
				this.btnSegment.Enabled = false;
				this.btnPrint.Enabled = false;
				if (this.btnAerial == null)
				{
					this.InitializeComponent();
				}
				this.labAerial.Left = Math.Max(1, (this.panMain.ClientRectangle.Width - this.labAerial.Width) / 2);
				this.btnAerial.Left = Math.Max(1, (this.panMain.ClientRectangle.Width - this.btnAerial.Width) / 2);
			}
			else
			{
				this.kmiGraph1.Visible = true;
				this.btnSegment.Enabled = true;
				this.btnPrint.Enabled = true;
				base.UpdateGraph();
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00014204 File Offset: 0x00013204
		private void btnAerial_Click(object sender, EventArgs e)
		{
			if (A.I.SimTimeRunning)
			{
				A.MF.mnuOptionsGoStop_Click(sender, e);
			}
			((CityView)A.I.Views[0]).ViewerOptions[2] = false;
			if (!A.I.Client)
			{
				A.ST.CityViewerOptions = ((CityView)A.I.Views[0]).ViewerOptions;
			}
			A.MF.OnViewChange(A.I.Views[0].Name);
			int oldTop = base.Top;
			base.Top = 2000;
			frmSurveyResultsAerial f = new frmSurveyResultsAerial(this.survey);
			f.ShowDialog();
			base.Top = oldTop;
		}
	}
}
