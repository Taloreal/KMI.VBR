using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Surveys
{
	// Token: 0x02000065 RID: 101
	public partial class frmSurveySegment : Form
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x0001AFC0 File Offset: 0x00019FC0
		public frmSurveySegment()
		{
			this.InitializeComponent();
			this.btnBuyMailingList.Visible = Survey.ShowBuyMailingList;
			this.labTotal.Text = "Total " + Survey.SurveyableObjectName + " in Survey";
		}

		// Token: 0x170000E3 RID: 227
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x0001B91C File Offset: 0x0001A91C
		public Survey Survey
		{
			set
			{
				this.survey = value;
				this.survey = this.survey;
				this.cboQuestion.Items.Clear();
				foreach (object obj in this.survey.SurveyQuestions)
				{
					SurveyQuestion surveyQuestion = (SurveyQuestion)obj;
					if (surveyQuestion.ShortName != "live" && surveyQuestion.ShortName != "work" && surveyQuestion.ShortName != "lastmovie")
					{
						this.cboQuestion.Items.Add(surveyQuestion.Question);
					}
				}
				this.cboQuestion.SelectedIndex = 0;
				foreach (string item in this.survey.EntityNames)
				{
					this.cboEntity.Items.Add(item);
				}
				if (this.survey.EntityNames.Length > 0)
				{
					this.cboEntity.SelectedIndex = 0;
				}
			}
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0001BA6C File Offset: 0x0001AA6C
		private void btnOK_Click(object sender, EventArgs e)
		{
			this.btnApply.PerformClick();
			base.Close();
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0001BA82 File Offset: 0x0001AA82
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0001BA8C File Offset: 0x0001AA8C
		private void btnClear_Click(object sender, EventArgs e)
		{
			this.survey.ClearSegmenters();
			this.picCanvas.Refresh();
			this.cboQuestion_SelectedIndexChanged(new object(), new EventArgs());
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0001BAB8 File Offset: 0x0001AAB8
		private void btnApply_Click(object sender, EventArgs e)
		{
			int num = 0;
			bool[] array = new bool[this.question.PossibleResponses.Length];
			foreach (object obj in this.panel1.Controls)
			{
				CheckBox checkBox = (CheckBox)obj;
				array[num] = checkBox.Checked;
				num++;
			}
			if (this.question.MultiEntity)
			{
				this.survey.AddUpdateSegmenter(this.question, array, this.cboEntity.SelectedIndex);
			}
			else
			{
				this.survey.AddUpdateSegmenter(this.question, array);
			}
			this.picCanvas.Refresh();
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0001BB9C File Offset: 0x0001AB9C
		private void picCanvas_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.Clear(this.picCanvas.BackColor);
			this.currentSegmentIDs = this.survey.DrawSegments(graphics, this.picCanvas.ClientRectangle);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0001BBE0 File Offset: 0x0001ABE0
		private void cboQuestion_SelectedIndexChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < this.survey.SurveyQuestions.Count; i++)
			{
				this.question = (SurveyQuestion)this.survey.SurveyQuestions[i];
				if (this.question.Question == (string)this.cboQuestion.Items[this.cboQuestion.SelectedIndex])
				{
					break;
				}
			}
			this.cboEntity.Visible = this.question.MultiEntity;
			this.labEntity.Visible = this.question.MultiEntity;
			this.panel1.BorderStyle = BorderStyle.None;
			for (int i = this.panel1.Controls.Count - 1; i > 0; i--)
			{
				this.panel1.Controls.RemoveAt(i);
			}
			for (int i = 0; i < this.question.PossibleResponses.Length; i++)
			{
				SurveySegmenter segmenter;
				if (this.question.MultiEntity)
				{
					segmenter = this.survey.GetSegmenter(this.question, this.cboEntity.SelectedIndex);
				}
				else
				{
					segmenter = this.survey.GetSegmenter(this.question);
				}
				if (i > 0)
				{
					CheckBox checkBox = new CheckBox();
					checkBox.Size = this.chkAnswer.Size;
					checkBox.Left = this.chkAnswer.Left;
					checkBox.Top = i * 20 + this.chkAnswer.Top;
					this.panel1.Controls.Add(checkBox);
					checkBox.Text = this.question.PossibleResponses[i];
					if (segmenter != null)
					{
						checkBox.Checked = segmenter.IncludesAnswer[i];
					}
					else
					{
						checkBox.Checked = true;
					}
				}
				else
				{
					this.chkAnswer.Text = this.question.PossibleResponses[i];
					if (segmenter != null)
					{
						this.chkAnswer.Checked = segmenter.IncludesAnswer[i];
					}
					else
					{
						this.chkAnswer.Checked = true;
					}
				}
			}
			if (this.question.PossibleResponses.Length > 8)
			{
				this.panel1.BorderStyle = BorderStyle.Fixed3D;
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0001BE49 File Offset: 0x0001AE49
		private void cboEntity_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cboQuestion_SelectedIndexChanged(new object(), new EventArgs());
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0001BE5D File Offset: 0x0001AE5D
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(frmSurveySegment.HelpTopic);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0001BE6B File Offset: 0x0001AE6B
		private void btnBuyMailingList_Click(object sender, EventArgs e)
		{
			this.survey.BuyMailingListHook();
		}

		// Token: 0x04000275 RID: 629
		protected SurveyQuestion question;

		// Token: 0x04000276 RID: 630
		protected long[] currentSegmentIDs;

		// Token: 0x04000277 RID: 631
		protected Survey survey;

		// Token: 0x04000278 RID: 632
		public static string HelpTopic = "Market Research Example";
	}
}
