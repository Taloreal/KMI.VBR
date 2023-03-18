using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim.Academics
{
	// Token: 0x02000057 RID: 87
	public partial class frmTestResults : Form
	{
		// Token: 0x06000315 RID: 789 RVA: 0x000186A8 File Offset: 0x000176A8
		public frmTestResults()
		{
			this.InitializeComponent();
			this.g = S.SA.GetAcademicGod();
			float num = 0f;
			for (int i = 0; i < this.g.AcademicLevel; i++)
			{
				float num2 = this.g.GradeForLevel(i);
				num += num2;
				TestResultControl testResultControl = new TestResultControl(i, num2, this.g);
				testResultControl.Top = (i + 1) * testResultControl.Height;
				testResultControl.Left = 24;
				this.panResults.Controls.Add(testResultControl);
			}
			if (this.g.AcademicLevel > 0)
			{
				this.labAverage.Text = S.R.GetString("Average: {0}", new object[]
				{
					Utilities.FP(num / (float)this.g.AcademicLevel)
				});
			}
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000189E2 File Offset: 0x000179E2
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040001F7 RID: 503
		private AcademicGod g;
	}
}
