using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmMail.
	/// </summary>
	// Token: 0x02000045 RID: 69
	public partial class frmMail : Form, IActionForm
	{
		// Token: 0x06000209 RID: 521 RVA: 0x0001E478 File Offset: 0x0001D478
		public frmMail()
		{
			this.InitializeComponent();
			this.labCPM.Text = Utilities.FC(450f, A.I.CurrencyConversion);
			A.MF.picMain.Cursor = A.R.GetCursor("Mail");
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0001E4DC File Offset: 0x0001D4DC
		protected void GetData()
		{
			try
			{
				this.input = A.SA.GetMail(A.MF.CurrentEntityID);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0001E528 File Offset: 0x0001D528
		protected void UpdateForm()
		{
			this.lists = this.input.Lists;
			if (this.lists.Length > 0)
			{
				this.optList.Enabled = true;
				this.cboList.Enabled = true;
				foreach (MailingList i in this.lists)
				{
					this.cboList.Items.Add(i.Name);
					if (this.input.MostRecentlyUsedMailingList != null && this.input.MostRecentlyUsedMailingList.Name == i.Name)
					{
						this.cboList.SelectedIndex = this.cboList.Items.Count - 1;
					}
				}
				if (this.cboList.SelectedIndex == -1)
				{
					this.cboList.SelectedIndex = 0;
				}
				this.optList.Checked = true;
			}
			else
			{
				this.optGeo.Checked = true;
			}
			this.labCPM.Text = Utilities.FC(450f, A.I.CurrencyConversion);
			this.chkRepeat.Checked = (this.input.MailingFrequency > 0);
			if (this.chkRepeat.Checked)
			{
				this.updMailingFrequency.Value = this.input.MailingFrequency;
				this.Discounts = this.input.Discounts;
			}
			else
			{
				this.Discounts = null;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600020E RID: 526 RVA: 0x0001F3E4 File Offset: 0x0001E3E4
		// (set) Token: 0x0600020F RID: 527 RVA: 0x0001F3FC File Offset: 0x0001E3FC
		private float[] Discounts
		{
			get
			{
				return this.discounts;
			}
			set
			{
				this.discounts = value;
				if (this.discounts != null)
				{
					bool allZero = true;
					for (int i = 0; i < 25; i++)
					{
						allZero = (allZero && this.discounts[i] == 0f);
					}
					if (allZero)
					{
						this.discounts = null;
					}
				}
				this.btnEdit.Enabled = (this.discounts != null);
				this.optNo.Checked = (this.discounts == null);
				this.optYes.Checked = (this.discounts != null);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000210 RID: 528 RVA: 0x0001F4A0 File Offset: 0x0001E4A0
		// (set) Token: 0x06000211 RID: 529 RVA: 0x0001F4B8 File Offset: 0x0001E4B8
		public MailingList List
		{
			get
			{
				return this.list;
			}
			set
			{
				this.list = value;
				int reach = this.list.RecipientIDs.Count * 20 * 5;
				this.labReach.Text = Utilities.FU(reach);
				this.labCost.Text = Utilities.FC((float)reach * 450f / 1000f, A.I.CurrencyConversion);
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0001F520 File Offset: 0x0001E520
		private void optYes_Click(object sender, EventArgs e)
		{
			frmCoupon f = new frmCoupon(this.discounts);
			if (f.ShowDialog() == DialogResult.OK)
			{
				this.Discounts = f.discounts;
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0001F559 File Offset: 0x0001E559
		private void optNo_Click(object sender, EventArgs e)
		{
			this.Discounts = null;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0001F564 File Offset: 0x0001E564
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.optGeo.Checked)
				{
					this.List.Name = frmMail.GetNameForList(this.lists);
					A.SA.AddMailingList(A.MF.CurrentEntityID, this.List);
				}
				int freq = (int)this.updMailingFrequency.Value;
				A.SA.SetDiscounts(A.MF.CurrentEntityID, this.Discounts);
				base.Close();
				A.MF.BringToFront();
				ArrayList pts = A.SA.ExecuteMailing(A.MF.CurrentEntityID, this.List);
				if (this.chkRepeat.Checked)
				{
					A.SA.SetMailingFrequency(A.MF.CurrentEntityID, freq);
				}
				Graphics g = A.MF.BackBufferGraphics;
				foreach (object obj in pts)
				{
					PointF p = (PointF)obj;
					g.DrawImage(A.R.GetImage("Envelope"), new PointF(p.X, p.Y));
				}
				A.MF.picMain.Refresh();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0001F710 File Offset: 0x0001E710
		private void cboList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.List = this.lists[this.cboList.SelectedIndex];
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0001F72C File Offset: 0x0001E72C
		private void optGeo_CheckedChanged(object sender, EventArgs e)
		{
			if (this.optGeo.Checked)
			{
				this.List = new MailingList();
			}
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0001F758 File Offset: 0x0001E758
		private void optList_CheckedChanged(object sender, EventArgs e)
		{
			if (this.optList.Checked)
			{
				this.List = this.lists[this.cboList.SelectedIndex];
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0001F794 File Offset: 0x0001E794
		private void btnEdit_Click(object sender, EventArgs e)
		{
			frmCoupon f = new frmCoupon(this.discounts);
			if (f.ShowDialog() == DialogResult.OK)
			{
				this.Discounts = f.discounts;
			}
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0001F7D0 File Offset: 0x0001E7D0
		public static string GetNameForList(MailingList[] lists)
		{
			string strDefaultName = frmMail.GenerateUnusedName(lists);
			frmInputString f = new frmInputString(A.R.GetString("Name Mailing List"), A.R.GetString("Please enter a name for this mailing list in case you want to use it again. Use a name like \"Center of town\" or \"Near competitor\"."), strDefaultName);
			f.ShowDialog();
			while (frmMail.ContainsName(f.Response, lists))
			{
				MessageBox.Show(A.R.GetString("You already have a list by this name.  Please try again."), A.R.GetString("Duplicate Name"), MessageBoxButtons.OK);
				f.ShowDialog();
			}
			return f.Response;
		}

		/// <summary>
		/// Create a novel name not in the list of given names
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600021A RID: 538 RVA: 0x0001F85C File Offset: 0x0001E85C
		private static string GenerateUnusedName(MailingList[] lists)
		{
			int i = 1;
			while (frmMail.ContainsName(A.R.GetString("List{0}", new object[]
			{
				i
			}), lists))
			{
				i++;
			}
			return A.R.GetString("List{0}", new object[]
			{
				i
			});
		}

		/// <summary>
		/// Reports whether there is already a mailing list with the given name
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600021B RID: 539 RVA: 0x0001F8C0 File Offset: 0x0001E8C0
		private static bool ContainsName(string name, MailingList[] lists)
		{
			foreach (MailingList list in lists)
			{
				if (list.Name.Equals(name))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0001F90A File Offset: 0x0001E90A
		private void btnCancel_Click(object sender, EventArgs e)
		{
			A.MF.Refresh();
			base.Close();
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0001F920 File Offset: 0x0001E920
		private void frmMail_Closed(object sender, EventArgs e)
		{
			CityView view = (CityView)A.I.Views[0];
			view.Mode = CityView.Modes.Default;
			view.DragOn = false;
			A.MF.picMain.Cursor = Cursors.Default;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0001F964 File Offset: 0x0001E964
		private void chkRepeat_Click(object sender, EventArgs e)
		{
			if (!this.chkRepeat.Checked)
			{
				A.SA.SetMailingFrequency(A.MF.CurrentEntityID, 0);
				MessageBox.Show("Recurring mailings have been stopped. To create another recurring or one-shot mailing, select Direct Mail under Promotion on the Actions menu again.");
				base.Close();
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0001F9AB File Offset: 0x0001E9AB
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Direct Mail");
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0001F9B9 File Offset: 0x0001E9B9
		private void frmMail_Load(object sender, EventArgs e)
		{
			this.GetData();
			this.UpdateForm();
		}

		// Token: 0x04000216 RID: 534
		private MailingList[] lists;

		// Token: 0x04000217 RID: 535
		private float[] discounts;

		// Token: 0x04000218 RID: 536
		protected MailingList list;

		// Token: 0x04000219 RID: 537
		protected frmMail.Input input;

		// Token: 0x02000046 RID: 70
		[Serializable]
		public struct Input
		{
			// Token: 0x0400021A RID: 538
			public MailingList[] Lists;

			// Token: 0x0400021B RID: 539
			public int MailingFrequency;

			// Token: 0x0400021C RID: 540
			public MailingList MostRecentlyUsedMailingList;

			// Token: 0x0400021D RID: 541
			public DateTime DiscountExpiration;

			// Token: 0x0400021E RID: 542
			public float[] Discounts;
		}
	}
}
