using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmReportSingleTimeSeries.
	/// </summary>
	// Token: 0x02000019 RID: 25
	public partial class frmPopulation : frmDrawnReport
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x0000A6CC File Offset: 0x000096CC
		public frmPopulation()
		{
			this.Graph.Title = A.R.GetString("Population");
			this.Graph.Legend = false;
			this.Graph.GraphType = 1;
			this.Graph.YLabelFormat = "{0:N0}";
			this.picReport.Controls.Add(this.Graph);
			this.Graph.Size = new Size(this.picReport.Width - 1, this.picReport.Height - 1);
			this.Text = A.R.GetString("Population");
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000A78B File Offset: 0x0000978B
		protected override void DrawReportVirtual(Graphics g)
		{
			this.Graph.Draw(this.data);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000A7A0 File Offset: 0x000097A0
		protected override void GetDataVirtual()
		{
			ArrayList pop = A.SA.GetPopulation();
			this.simStartDate = A.SA.getSimSettings().StartDate;
			this.data = new object[2, pop.Count + 1];
			for (int w = 0; w < pop.Count; w++)
			{
				this.data[0, w + 1] = this.simStartDate.AddDays((double)(w * 7));
				this.data[1, w + 1] = pop[w];
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000A832 File Offset: 0x00009832
		protected override void btnPrint_Click(object sender, EventArgs e)
		{
			this.Graph.PrintGraph();
		}

		// Token: 0x0400009E RID: 158
		protected KMIGraph Graph = new KMIGraph();

		// Token: 0x0400009F RID: 159
		protected object[,] data;

		// Token: 0x040000A0 RID: 160
		protected DateTime simStartDate;
	}
}
