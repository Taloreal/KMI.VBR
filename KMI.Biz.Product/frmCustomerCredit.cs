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
	// Token: 0x02000003 RID: 3
	public partial class frmCustomerCredit : Form
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002160 File Offset: 0x00001160
		public frmCustomerCredit()
		{
			this.InitializeComponent();
			this.input = ((IBizProductStateAdapter)S.SA).GetCustomerCredit(S.MF.CurrentEntityID);
			int num = 0;
			foreach (object obj in this.input.ARInfo.Keys)
			{
				string text = (string)obj;
				float[] array = (float[])this.input.ARInfo[text];
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
			this.lstCredit.Items.AddRange(this.input.Credit.ToArray());
			this.lstNoCredit.Items.AddRange(this.input.NoCredit.ToArray());
			this.updEarlyPayDiscount.Value = (decimal)this.input.EarlyPayDiscount;
			this.updEarlyPayDays.Value = this.input.EarlyPayDays;
			this.updNetPayDays.Value = this.input.NetPayDays;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000030BF File Offset: 0x000020BF
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000030CC File Offset: 0x000020CC
		private void btnOK_Click(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(this.lstNoCredit.Items);
			((IBizProductStateAdapter)S.SA).SetCustomerCredit(S.MF.CurrentEntityID, arrayList, (float)this.updEarlyPayDiscount.Value, (int)this.updEarlyPayDays.Value, (int)this.updNetPayDays.Value);
			base.Close();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003145 File Offset: 0x00002145
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Customer Credit");
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003154 File Offset: 0x00002154
		private void btnCredit_Click(object sender, EventArgs e)
		{
			object[] array = new object[this.lstNoCredit.SelectedItems.Count];
			this.lstNoCredit.SelectedItems.CopyTo(array, 0);
			foreach (string text in array)
			{
				this.lstCredit.Items.Add(text);
				this.lstNoCredit.Items.Remove(text);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000031D4 File Offset: 0x000021D4
		private void btnNoCredit_Click(object sender, EventArgs e)
		{
			object[] array = new object[this.lstCredit.SelectedItems.Count];
			this.lstCredit.SelectedItems.CopyTo(array, 0);
			foreach (string text in array)
			{
				this.lstNoCredit.Items.Add(text);
				this.lstCredit.Items.Remove(text);
			}
		}

		// Token: 0x0400001C RID: 28
		protected frmCustomerCredit.Input input;

		// Token: 0x02000004 RID: 4
		public struct Input
		{
			// Token: 0x0400001D RID: 29
			public Hashtable ARInfo;

			// Token: 0x0400001E RID: 30
			public ArrayList Credit;

			// Token: 0x0400001F RID: 31
			public ArrayList NoCredit;

			// Token: 0x04000020 RID: 32
			public int EarlyPayDays;

			// Token: 0x04000021 RID: 33
			public float EarlyPayDiscount;

			// Token: 0x04000022 RID: 34
			public int NetPayDays;
		}
	}
}
