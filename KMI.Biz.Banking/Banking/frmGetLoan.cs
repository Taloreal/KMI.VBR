using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Banking
{
	// Token: 0x02000004 RID: 4
	public partial class frmGetLoan : Form
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002318 File Offset: 0x00001318
		public frmGetLoan()
		{
			this.InitializeComponent();
			this.input = ((IBizBankingStateAdapter)S.SA).GetLoanInfo(S.MF.CurrentEntityID);
			this.txtCreditReport.Lines = this.input.CreditReport;
			this.GenerateLoanOptions(this.input.CreditRating);
			if (this.amount.Length == 0)
			{
				this.labCreditDenied.Visible = true;
			}
			else
			{
				this.grpOptions.Controls.Clear();
				for (int i = 0; i < this.amount.Length; i++)
				{
					RadioButton radioButton = new RadioButton();
					radioButton.Size = this.optLoan.Size;
					radioButton.Location = new Point(this.optLoan.Left, this.optLoan.Top + 32 * i);
					radioButton.Text = string.Concat(new object[]
					{
						Utilities.FC(this.amount[i], S.I.CurrencyConversion),
						" for ",
						this.term[i],
						" months at ",
						Utilities.FP(this.rate[i]),
						" interest rate"
					});
					radioButton.Visible = true;
					this.grpOptions.Controls.Add(radioButton);
				}
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002A0B File Offset: 0x00001A0B
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002A44 File Offset: 0x00001A44
		protected virtual void GenerateLoanOptions(int creditRating)
		{
			switch (creditRating)
			{
			case 0:
				this.amount = new float[]
				{
					50000f,
					100000f,
					15000f
				};
				this.term = new int[]
				{
					24,
					12,
					6
				};
				this.rate = new float[]
				{
					0.09f,
					0.09f,
					0.09f
				};
				break;
			case 1:
				this.amount = new float[]
				{
					50000f,
					100000f
				};
				this.term = new int[]
				{
					12,
					6
				};
				this.rate = new float[]
				{
					0.11f,
					0.11f
				};
				break;
			case 2:
				this.amount = new float[]
				{
					50000f,
					25000f
				};
				this.term = new int[]
				{
					3,
					6
				};
				this.rate = new float[]
				{
					0.13f,
					0.13f
				};
				break;
			case 3:
				this.amount = new float[]
				{
					25000f
				};
				this.term = new int[]
				{
					3
				};
				this.rate = new float[]
				{
					0.18f
				};
				break;
			case 4:
				this.amount = new float[0];
				this.term = new int[0];
				this.rate = new float[0];
				break;
			default:
				throw new Exception("Unexpected bad credit rating found.");
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002BDC File Offset: 0x00001BDC
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.amount.Length; i++)
				{
					if (((RadioButton)this.grpOptions.Controls[i]).Checked)
					{
						((IBizBankingStateAdapter)S.SA).GetLoan(S.MF.CurrentEntityID, this.amount[i], this.term[i], this.rate[i]);
					}
				}
				base.Close();
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002C80 File Offset: 0x00001C80
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002C90 File Offset: 0x00001C90
		private void frmGetLoan_Load(object sender, EventArgs e)
		{
			foreach (object obj in this.input.Loans.Values)
			{
				Loan loan = (Loan)obj;
				if ((this.input.CurrentDate - loan.Origination).Days < Loan.DaysBetweenLoans)
				{
					MessageBox.Show("The bank requires a minimum of " + Loan.DaysBetweenLoans + " days operating history since the last loan to your business.  No additional loan available at this time.", "Loan Not Available");
					base.Close();
					break;
				}
			}
		}

		// Token: 0x0400000E RID: 14
		protected float[] amount;

		// Token: 0x0400000F RID: 15
		protected int[] term;

		// Token: 0x04000010 RID: 16
		protected float[] rate;

		// Token: 0x04000011 RID: 17
		protected frmGetLoan.Input input;

		// Token: 0x02000005 RID: 5
		[Serializable]
		public struct Input
		{
			// Token: 0x04000012 RID: 18
			public int CreditRating;

			// Token: 0x04000013 RID: 19
			public string[] CreditReport;

			// Token: 0x04000014 RID: 20
			public SortedList Loans;

			// Token: 0x04000015 RID: 21
			public DateTime CurrentDate;
		}
	}
}
