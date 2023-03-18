using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz.Product.CustomControls;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x02000012 RID: 18
	public partial class frmReportsAR : Form
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00007C30 File Offset: 0x00006C30
		public frmReportsAR()
		{
			this.InitializeComponent();
			Hashtable reportsAR = ((IBizProductStateAdapter)S.SA).GetReportsAR(S.MF.CurrentEntityID);
			int num = 0;
			foreach (object obj in reportsAR.Keys)
			{
				string text = (string)obj;
				float[] array = (float[])reportsAR[text];
				ARInfo arinfo = new ARInfo();
				arinfo.CustomerName.Text = text;
				arinfo.Current.Text = Utilities.FC(array[0], S.I.CurrencyConversion);
				arinfo.Days0To30.Text = Utilities.FC(array[1], S.I.CurrencyConversion);
				arinfo.Days30To60.Text = Utilities.FC(array[2], S.I.CurrencyConversion);
				arinfo.Days60To90.Text = Utilities.FC(array[3], S.I.CurrencyConversion);
				arinfo.Over90.Text = Utilities.FC(array[4], S.I.CurrencyConversion);
				arinfo.Location = new Point(0, num++ * arinfo.Height);
				this.panel1.Controls.Add(arinfo);
			}
			this.Header.Underline = true;
			this.Header.Bold = true;
			this.Header.CustomerName.Text = S.R.GetString("Customer");
			this.Header.Current.Text = S.R.GetString("Current");
			this.Header.Days0To30.Text = S.R.GetString("0-30 Days");
			this.Header.Days30To60.Text = S.R.GetString("30-60 Days");
			this.Header.Days60To90.Text = S.R.GetString("60-90 Days");
			this.Header.Over90.Text = S.R.GetString("> 90 Days");
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00008179 File Offset: 0x00007179
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00008183 File Offset: 0x00007183
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}
	}
}
