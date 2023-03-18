namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmRadio.
	/// </summary>
	// Token: 0x02000009 RID: 9
	public partial class frmRadio : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000021 RID: 33 RVA: 0x00003EC4 File Offset: 0x00002EC4
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
		// Token: 0x06000022 RID: 34 RVA: 0x00003F00 File Offset: 0x00002F00
		private void InitializeComponent()
		{
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.labTotalCost = new global::System.Windows.Forms.Label();
			this.labRotations = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panMain = new global::System.Windows.Forms.Panel();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.btnOK.Location = new global::System.Drawing.Point(432, 304);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(432, 336);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnHelp.Location = new global::System.Drawing.Point(432, 368);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 6;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.groupBox2.Controls.Add(this.labTotalCost);
			this.groupBox2.Controls.Add(this.labRotations);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new global::System.Drawing.Point(128, 296);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(248, 96);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Total Radio Budget";
			this.labTotalCost.Location = new global::System.Drawing.Point(168, 64);
			this.labTotalCost.Name = "labTotalCost";
			this.labTotalCost.Size = new global::System.Drawing.Size(72, 16);
			this.labTotalCost.TabIndex = 5;
			this.labTotalCost.Text = "#";
			this.labTotalCost.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labRotations.Location = new global::System.Drawing.Point(168, 32);
			this.labRotations.Name = "labRotations";
			this.labRotations.Size = new global::System.Drawing.Size(72, 16);
			this.labRotations.TabIndex = 4;
			this.labRotations.Text = "#";
			this.labRotations.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label6.Location = new global::System.Drawing.Point(16, 64);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(136, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "Total Cost per Week";
			this.label4.Location = new global::System.Drawing.Point(16, 32);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(136, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Rotations Booked";
			this.panMain.Location = new global::System.Drawing.Point(16, 8);
			this.panMain.Name = "panMain";
			this.panMain.Size = new global::System.Drawing.Size(608, 280);
			this.panMain.TabIndex = 7;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(642, 408);
			base.Controls.Add(this.panMain);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmRadio";
			base.ShowInTaskbar = false;
			this.Text = "Promotion - Radio Advertising";
			base.Closed += new global::System.EventHandler(this.frmRadio_Closed);
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.Label labRotations;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.Label labTotalCost;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.Panel panMain;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400002E RID: 46
		private global::System.ComponentModel.Container components = null;
	}
}
