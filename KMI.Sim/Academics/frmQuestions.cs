using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Academics
{
	// Token: 0x02000066 RID: 102
	public partial class frmQuestions : Form
	{
		// Token: 0x060003C0 RID: 960 RVA: 0x0001BE88 File Offset: 0x0001AE88
		public frmQuestions(frmQuestions.Modes mode, Question[] questions)
		{
			this.InitializeComponent();
			this.Mode = mode;
			this.questions = questions;
			int num = 0;
			int num2 = 0;
			foreach (Question question in questions)
			{
				if (this.Mode == frmQuestions.Modes.LevelEndTest)
				{
					question.Answer = null;
				}
				QuestionControl questionControl = new QuestionControl();
				questionControl.Question = question;
				if (num++ % 2 == 0)
				{
					questionControl.BackColor = Color.FromArgb(240, 240, 240);
				}
				else
				{
					questionControl.BackColor = Color.FromArgb(230, 230, 230);
				}
				questionControl.Top = num2;
				num2 += questionControl.Height;
				this.panQuestions.Controls.Add(questionControl);
			}
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0001C4A4 File Offset: 0x0001B4A4
		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (this.Mode == frmQuestions.Modes.LevelEndTest || this.Mode == frmQuestions.Modes.TestReview)
			{
				float num = 0f;
				for (int i = 0; i < this.questions.Length; i++)
				{
					QuestionControl questionControl = (QuestionControl)this.panQuestions.Controls[i];
					this.questions[i].Answer = questionControl.txtAnswer.Text;
					questionControl.Question = this.questions[i];
					questionControl.txtAnswer.Enabled = false;
					if (this.questions[i].Correct)
					{
						num += 1f;
					}
				}
				this.labScore.Text = Utilities.FP(num / (float)this.questions.Length);
				this.btnSubmit.Enabled = false;
				this.btnContinue.Enabled = true;
				this.panScore.Visible = true;
			}
			else
			{
				bool flag = true;
				for (int i = 0; i < this.questions.Length; i++)
				{
					QuestionControl questionControl = (QuestionControl)this.panQuestions.Controls[i];
					this.questions[i].Answer = questionControl.txtAnswer.Text;
					questionControl.Question = this.questions[i];
					flag = (this.questions[i].Correct && flag);
				}
				this.btnSubmit.Enabled = !flag;
				this.btnContinue.Enabled = flag;
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0001C635 File Offset: 0x0001B635
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0001C640 File Offset: 0x0001B640
		private void frmQuestions_Closing(object sender, CancelEventArgs e)
		{
			if (!this.btnContinue.Enabled)
			{
				e.Cancel = true;
			}
			if (base.Owner != null)
			{
				((frmPage)base.Owner).okToClose = true;
				base.Owner.Close();
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0001C694 File Offset: 0x0001B694
		private void frmQuestions_Load(object sender, EventArgs e)
		{
			if (this.Mode == frmQuestions.Modes.TestReview)
			{
				this.btnSubmit.PerformClick();
			}
		}

		// Token: 0x04000281 RID: 641
		public frmQuestions.Modes Mode = frmQuestions.Modes.Quiz;

		// Token: 0x04000282 RID: 642
		private Question[] questions;

		// Token: 0x02000067 RID: 103
		public enum Modes
		{
			// Token: 0x04000284 RID: 644
			Quiz,
			// Token: 0x04000285 RID: 645
			LevelEndTest,
			// Token: 0x04000286 RID: 646
			TestReview
		}
	}
}
