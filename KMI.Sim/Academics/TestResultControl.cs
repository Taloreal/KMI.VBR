using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Academics
{
	// Token: 0x02000043 RID: 67
	public class TestResultControl : UserControl
	{
		// Token: 0x06000271 RID: 625 RVA: 0x00014C2A File Offset: 0x00013C2A
		public TestResultControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00014C44 File Offset: 0x00013C44
		public TestResultControl(int index, float score, AcademicGod g)
		{
			this.InitializeComponent();
			this.index = index;
			this.g = g;
			this.labResult.Text = S.R.GetString("Level {0} - {1}", new object[]
			{
				index + 1,
				Utilities.FP(score)
			});
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00014CB0 File Offset: 0x00013CB0
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00014CEC File Offset: 0x00013CEC
		private void InitializeComponent()
		{
			this.labResult = new Label();
			this.labDetails = new Label();
			base.SuspendLayout();
			this.labResult.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.labResult.Location = new Point(16, 8);
			this.labResult.Name = "labResult";
			this.labResult.Size = new Size(120, 16);
			this.labResult.TabIndex = 0;
			this.labResult.Text = "label1";
			this.labResult.TextAlign = ContentAlignment.BottomLeft;
			this.labDetails.Cursor = Cursors.Hand;
			this.labDetails.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Underline, GraphicsUnit.Point, 0);
			this.labDetails.ForeColor = Color.FromArgb(0, 0, 192);
			this.labDetails.Location = new Point(152, 6);
			this.labDetails.Name = "labDetails";
			this.labDetails.Size = new Size(64, 16);
			this.labDetails.TabIndex = 1;
			this.labDetails.Text = "Details";
			this.labDetails.TextAlign = ContentAlignment.BottomLeft;
			this.labDetails.Click += this.labDetails_Click;
			base.Controls.Add(this.labDetails);
			base.Controls.Add(this.labResult);
			base.Name = "TestResultControl";
			base.Size = new Size(264, 32);
			base.ResumeLayout(false);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00014EB4 File Offset: 0x00013EB4
		private void labDetails_Click(object sender, EventArgs e)
		{
			frmQuestions frmQuestions = new frmQuestions(frmQuestions.Modes.TestReview, this.g.FindAllAskedQuestions(this.index));
			frmQuestions.ShowDialog();
		}

		// Token: 0x0400019C RID: 412
		private Label labResult;

		// Token: 0x0400019D RID: 413
		private Label labDetails;

		// Token: 0x0400019E RID: 414
		private Container components = null;

		// Token: 0x0400019F RID: 415
		private int index;

		// Token: 0x040001A0 RID: 416
		private AcademicGod g;
	}
}
