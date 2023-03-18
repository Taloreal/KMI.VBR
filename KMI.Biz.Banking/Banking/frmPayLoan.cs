using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Banking
{
	// Token: 0x02000006 RID: 6
	public partial class frmPayLoan : Form
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002D58 File Offset: 0x00001D58
		public frmPayLoan()
		{
			this.InitializeComponent();
			this.input = ((IBizBankingStateAdapter)S.SA).GetLoanInfo(S.MF.CurrentEntityID);
			this.panLoans.Controls.Clear();
			int num = 0;
			foreach (object obj in this.input.Loans.Values)
			{
				Loan loan = (Loan)obj;
				Label label = new Label();
				label.Size = this.labLoan.Size;
				label.Location = new Point(this.labLoan.Left, this.labLoan.Top + num * 28);
				label.Text = string.Concat(new string[]
				{
					Utilities.FC(loan.Balance, S.I.CurrencyConversion),
					" at ",
					Utilities.FP(loan.InterestRate),
					" interest due ",
					loan.Due.ToShortDateString()
				});
				this.panLoans.Controls.Add(label);
				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Size = numericUpDown.Size;
				numericUpDown.Location = new Point(this.updAmount.Left, this.updAmount.Top + num++ * 28);
				numericUpDown.Value = 0m;
				numericUpDown.Increment = 1000m;
				numericUpDown.Maximum = (decimal)loan.Balance;
				numericUpDown.TextAlign = this.updAmount.TextAlign;
				numericUpDown.Tag = loan.Due;
				this.panLoans.Controls.Add(numericUpDown);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003458 File Offset: 0x00002458
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				foreach (object obj in this.panLoans.Controls)
				{
					Control control = (Control)obj;
					if (control is NumericUpDown)
					{
						NumericUpDown numericUpDown = (NumericUpDown)control;
						if (numericUpDown.Value > 0m)
						{
							arrayList.Add(numericUpDown.Tag);
							arrayList2.Add((float)numericUpDown.Value);
						}
					}
				}
				((IBizBankingStateAdapter)S.SA).PayLoan(S.MF.CurrentEntityID, arrayList, arrayList2);
				base.Close();
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003578 File Offset: 0x00002578
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003588 File Offset: 0x00002588
		private void frmPayLoan_Load(object sender, EventArgs e)
		{
			if (this.input.Loans.Count == 0)
			{
				MessageBox.Show(S.R.GetString("You have no outstanding loans at this time."), S.R.GetString("Pay Loan"));
				base.Close();
			}
		}

		// Token: 0x0400001E RID: 30
		protected frmGetLoan.Input input;
	}
}
