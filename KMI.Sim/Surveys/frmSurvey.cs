using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Surveys
{
	// Token: 0x0200007A RID: 122
	public partial class frmSurvey : Form
	{
		// Token: 0x06000451 RID: 1105 RVA: 0x0001F90C File Offset: 0x0001E90C
		public frmSurvey()
		{
			this.InitializeComponent();
			if (!Survey.BillForSurveys)
			{
				this.grpBoxCost.Visible = false;
				this.grpBoxNumber.Visible = false;
				base.Width -= this.grpBoxCost.Width;
				this.cmdOK.Left -= this.grpBoxCost.Width / 2;
				this.cmdCancel.Left -= this.grpBoxCost.Width / 2;
				this.cmdHelp.Left -= this.grpBoxCost.Width / 2;
			}
			for (int i = 0; i < Survey.PossibleSurveyQuestions.Length; i++)
			{
				if (i > 0)
				{
					CheckBox checkBox = new CheckBox();
					checkBox.Size = this.chkQuestion.Size;
					checkBox.Left = this.chkQuestion.Left;
					checkBox.Top = i * 20 + this.chkQuestion.Top;
					this.panel1.Controls.Add(checkBox);
					checkBox.Text = Survey.PossibleSurveyQuestions[i].Question;
					checkBox.CheckedChanged += this.chkQuestion_CheckedChanged;
				}
				else
				{
					this.chkQuestion.Text = Survey.PossibleSurveyQuestions[i].Question;
				}
			}
			this.labQuestions.Text = "Questions to Ask " + Survey.SurveyableObjectName;
			this.grpBoxNumber.Text = "Number of " + Survey.SurveyableObjectName + " to Survey";
			this.UpdateCosts();
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00020654 File Offset: 0x0001F654
		private void cmdOK_Click(object sender, EventArgs e)
		{
			try
			{
				ArrayList arrayList = new ArrayList();
				int num = 0;
				foreach (object obj in this.panel1.Controls)
				{
					CheckBox checkBox = (CheckBox)obj;
					if (checkBox.Checked)
					{
						arrayList.Add(Survey.PossibleSurveyQuestions[num]);
					}
					num++;
				}
				if (arrayList.Count == 0)
				{
					MessageBox.Show("You must ask at least one question in a survey. Please try again.", "No Question Checked");
				}
				else
				{
					Survey survey = S.SA.ConductAndAddSurvey(S.I.ThisPlayerName, S.MF.CurrentEntityID, arrayList, (int)this.updNumToSurvey.Value, this.totalCost);
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2);
			}
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00020778 File Offset: 0x0001F778
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00020782 File Offset: 0x0001F782
		private void chkQuestion_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateCosts();
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0002078C File Offset: 0x0001F78C
		private void updNumToSurvey_ValueChanged(object sender, EventArgs e)
		{
			this.UpdateCosts();
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00020798 File Offset: 0x0001F798
		private void UpdateCosts()
		{
			int num = 0;
			foreach (object obj in this.panel1.Controls)
			{
				CheckBox checkBox = (CheckBox)obj;
				if (checkBox.Checked)
				{
					num++;
				}
			}
			float num2 = Survey.RecruitingCostPerPerson * (float)this.updNumToSurvey.Value;
			float num3 = Survey.ExecutionCostPerQuestionPerPerson * (float)num * (float)this.updNumToSurvey.Value;
			this.totalCost = Survey.BaseCost + num2 + num3;
			this.labBaseCost.Text = Utilities.FC(Survey.BaseCost, S.I.CurrencyConversion);
			this.labRecruitingCosts.Text = Utilities.FC(num2, S.I.CurrencyConversion);
			this.labExecutionCosts.Text = Utilities.FC(num3, S.I.CurrencyConversion);
			this.labTotalCost.Text = Utilities.FC(this.totalCost, S.I.CurrencyConversion);
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x000208D8 File Offset: 0x0001F8D8
		private void cmdHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(frmSurvey.HelpTopic);
		}

		// Token: 0x040002FE RID: 766
		private float totalCost = 0f;

		// Token: 0x040002FF RID: 767
		public static string HelpTopic = "Market Research";
	}
}
