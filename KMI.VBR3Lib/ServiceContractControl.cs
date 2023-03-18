using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for ServiceContractControl.
	/// </summary>
	// Token: 0x0200002C RID: 44
	public class ServiceContractControl : UserControl
	{
		// Token: 0x0600010E RID: 270 RVA: 0x00010EB8 File Offset: 0x0000FEB8
		public ServiceContractControl()
		{
			this.InitializeComponent();
			foreach (int i in AppConstants.ResponseTimes)
			{
				if (i == -1)
				{
					this.cboHours.Items.Add(A.R.GetString("No Contract"));
				}
				else
				{
					this.cboHours.Items.Add(A.R.GetString("{0} Hours", new object[]
					{
						i
					}));
				}
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600010F RID: 271 RVA: 0x00010F5C File Offset: 0x0000FF5C
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

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x06000110 RID: 272 RVA: 0x00010F98 File Offset: 0x0000FF98
		private void InitializeComponent()
		{
			this.labCost = new Label();
			this.labUnits = new Label();
			this.labEquip = new Label();
			this.cboHours = new ComboBox();
			this.btnRepair = new Button();
			base.SuspendLayout();
			this.labCost.Location = new Point(328, 8);
			this.labCost.Name = "labCost";
			this.labCost.Size = new Size(64, 16);
			this.labCost.TabIndex = 0;
			this.labCost.Text = "0";
			this.labCost.TextAlign = ContentAlignment.TopRight;
			this.labUnits.Location = new Point(288, 8);
			this.labUnits.Name = "labUnits";
			this.labUnits.Size = new Size(32, 16);
			this.labUnits.TabIndex = 1;
			this.labUnits.Text = "0";
			this.labUnits.TextAlign = ContentAlignment.TopRight;
			this.labEquip.Location = new Point(8, 8);
			this.labEquip.Name = "labEquip";
			this.labEquip.Size = new Size(152, 24);
			this.labEquip.TabIndex = 2;
			this.labEquip.Text = "label3";
			this.cboHours.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboHours.Location = new Point(160, 8);
			this.cboHours.Name = "cboHours";
			this.cboHours.Size = new Size(120, 21);
			this.cboHours.TabIndex = 4;
			this.cboHours.SelectedIndexChanged += this.cboHours_SelectedIndexChanged;
			this.btnRepair.Location = new Point(440, 8);
			this.btnRepair.Name = "btnRepair";
			this.btnRepair.Size = new Size(80, 24);
			this.btnRepair.TabIndex = 5;
			this.btnRepair.Text = "Repair Now";
			this.btnRepair.Click += this.btnRepair_Click;
			base.Controls.Add(this.btnRepair);
			base.Controls.Add(this.cboHours);
			base.Controls.Add(this.labEquip);
			base.Controls.Add(this.labUnits);
			base.Controls.Add(this.labCost);
			base.Name = "ServiceContractControl";
			base.Size = new Size(536, 40);
			base.ResumeLayout(false);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00011274 File Offset: 0x00010274
		private void cboHours_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.serviceContract.ResponseTimeIndex = this.cboHours.SelectedIndex;
			this.labCost.Text = Utilities.FC((float)(AppConstants.ServiceContractCosts[this.cboHours.SelectedIndex] * this.serviceContract.UnitsCovered), A.I.CurrencyConversion);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000112D4 File Offset: 0x000102D4
		private void btnRepair_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(A.R.GetString("Immediate repair will cost {0} for each broken unit. Proceed?", new object[]
			{
				Utilities.FC((float)(AppConstants.ServiceContractCosts[1] * 12), A.I.CurrencyConversion)
			}), A.R.GetString("Confirm Repair"), MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				A.SA.SetImmediateRepair(A.MF.CurrentEntityID, this.serviceContract.RackType);
				((Form)base.Parent.Parent).Close();
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00011370 File Offset: 0x00010370
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00011388 File Offset: 0x00010388
		public ServiceContract ServiceContract
		{
			get
			{
				return this.serviceContract;
			}
			set
			{
				this.serviceContract = value;
				this.labEquip.Text = value.RackType + "s";
				this.cboHours.SelectedIndex = this.serviceContract.ResponseTimeIndex;
				this.labUnits.Text = value.UnitsCovered.ToString();
			}
		}

		// Token: 0x0400012D RID: 301
		private ComboBox cboHours;

		// Token: 0x0400012E RID: 302
		private Label labCost;

		// Token: 0x0400012F RID: 303
		public Label labUnits;

		// Token: 0x04000130 RID: 304
		public Label labEquip;

		// Token: 0x04000131 RID: 305
		public Button btnRepair;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000132 RID: 306
		private Container components = null;

		// Token: 0x04000133 RID: 307
		protected ServiceContract serviceContract;
	}
}
