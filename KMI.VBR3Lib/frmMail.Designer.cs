namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmMail.
	/// </summary>
	// Token: 0x02000045 RID: 69
	public partial class frmMail : global::System.Windows.Forms.Form, global::KMI.Sim.IActionForm
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600020C RID: 524 RVA: 0x0001E6C8 File Offset: 0x0001D6C8
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
		// Token: 0x0600020D RID: 525 RVA: 0x0001E704 File Offset: 0x0001D704
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.btnEdit = new global::System.Windows.Forms.Button();
			this.optNo = new global::System.Windows.Forms.RadioButton();
			this.optYes = new global::System.Windows.Forms.RadioButton();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.updMailingFrequency = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.chkRepeat = new global::System.Windows.Forms.CheckBox();
			this.labCost = new global::System.Windows.Forms.Label();
			this.labReach = new global::System.Windows.Forms.Label();
			this.labCPM = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.cboList = new global::System.Windows.Forms.ComboBox();
			this.optList = new global::System.Windows.Forms.RadioButton();
			this.optGeo = new global::System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updMailingFrequency).BeginInit();
			this.groupBox4.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.btnEdit);
			this.groupBox1.Controls.Add(this.optNo);
			this.groupBox1.Controls.Add(this.optYes);
			this.groupBox1.Location = new global::System.Drawing.Point(200, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(72, 96);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Coupons";
			this.btnEdit.Location = new global::System.Drawing.Point(16, 64);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new global::System.Drawing.Size(40, 24);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new global::System.EventHandler(this.btnEdit_Click);
			this.optNo.Location = new global::System.Drawing.Point(16, 40);
			this.optNo.Name = "optNo";
			this.optNo.Size = new global::System.Drawing.Size(48, 16);
			this.optNo.TabIndex = 1;
			this.optNo.Text = "No";
			this.optNo.Click += new global::System.EventHandler(this.optNo_Click);
			this.optYes.Location = new global::System.Drawing.Point(16, 16);
			this.optYes.Name = "optYes";
			this.optYes.Size = new global::System.Drawing.Size(48, 16);
			this.optYes.TabIndex = 0;
			this.optYes.Text = "Yes";
			this.optYes.Click += new global::System.EventHandler(this.optYes_Click);
			this.groupBox2.Controls.Add(this.updMailingFrequency);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.chkRepeat);
			this.groupBox2.Controls.Add(this.labCost);
			this.groupBox2.Controls.Add(this.labReach);
			this.groupBox2.Controls.Add(this.labCPM);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new global::System.Drawing.Point(288, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(192, 96);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cost && Timing of Mailing";
			this.updMailingFrequency.Location = new global::System.Drawing.Point(104, 68);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updMailingFrequency;
			int[] array = new int[4];
			array[0] = 365;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updMailingFrequency;
			array = new int[4];
			array[0] = 7;
			numericUpDown2.Minimum = new decimal(array);
			this.updMailingFrequency.Name = "updMailingFrequency";
			this.updMailingFrequency.Size = new global::System.Drawing.Size(40, 20);
			this.updMailingFrequency.TabIndex = 13;
			this.updMailingFrequency.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.updMailingFrequency;
			array = new int[4];
			array[0] = 30;
			numericUpDown3.Value = new decimal(array);
			this.label4.Location = new global::System.Drawing.Point(152, 72);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(32, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "days";
			this.chkRepeat.Location = new global::System.Drawing.Point(8, 72);
			this.chkRepeat.Name = "chkRepeat";
			this.chkRepeat.Size = new global::System.Drawing.Size(96, 16);
			this.chkRepeat.TabIndex = 11;
			this.chkRepeat.Text = "Repeat every ";
			this.chkRepeat.Click += new global::System.EventHandler(this.chkRepeat_Click);
			this.labCost.Location = new global::System.Drawing.Point(120, 48);
			this.labCost.Name = "labCost";
			this.labCost.Size = new global::System.Drawing.Size(64, 16);
			this.labCost.TabIndex = 5;
			this.labCost.Text = "#";
			this.labCost.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labReach.Location = new global::System.Drawing.Point(120, 32);
			this.labReach.Name = "labReach";
			this.labReach.Size = new global::System.Drawing.Size(64, 16);
			this.labReach.TabIndex = 4;
			this.labReach.Text = "#";
			this.labReach.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labCPM.Location = new global::System.Drawing.Point(120, 16);
			this.labCPM.Name = "labCPM";
			this.labCPM.Size = new global::System.Drawing.Size(64, 16);
			this.labCPM.TabIndex = 3;
			this.labCPM.Text = "#";
			this.labCPM.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label3.Location = new global::System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(104, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Est. Cost of Mailing";
			this.label2.Location = new global::System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(112, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Est. Reach";
			this.label1.Location = new global::System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(112, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cost per 1000 (CPM)";
			this.btnOK.Location = new global::System.Drawing.Point(504, 16);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(72, 24);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(504, 48);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(504, 80);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(72, 24);
			this.btnHelp.TabIndex = 5;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.groupBox4.Controls.Add(this.cboList);
			this.groupBox4.Controls.Add(this.optList);
			this.groupBox4.Controls.Add(this.optGeo);
			this.groupBox4.Location = new global::System.Drawing.Point(16, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(168, 96);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Choose a List";
			this.cboList.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboList.Enabled = false;
			this.cboList.Location = new global::System.Drawing.Point(24, 66);
			this.cboList.Name = "cboList";
			this.cboList.Size = new global::System.Drawing.Size(128, 21);
			this.cboList.TabIndex = 2;
			this.cboList.SelectedIndexChanged += new global::System.EventHandler(this.cboList_SelectedIndexChanged);
			this.optList.Enabled = false;
			this.optList.Location = new global::System.Drawing.Point(8, 50);
			this.optList.Name = "optList";
			this.optList.Size = new global::System.Drawing.Size(112, 16);
			this.optList.TabIndex = 1;
			this.optList.Text = "Use Existing List";
			this.optList.CheckedChanged += new global::System.EventHandler(this.optList_CheckedChanged);
			this.optGeo.BackColor = global::System.Drawing.Color.Transparent;
			this.optGeo.Location = new global::System.Drawing.Point(8, 16);
			this.optGeo.Name = "optGeo";
			this.optGeo.Size = new global::System.Drawing.Size(160, 32);
			this.optGeo.TabIndex = 0;
			this.optGeo.Text = "Click && Drag Target Zone with Envelope Cursor";
			this.optGeo.CheckedChanged += new global::System.EventHandler(this.optGeo_CheckedChanged);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(592, 110);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Name = "frmMail";
			base.ShowInTaskbar = false;
			this.Text = "Promotion - Direct Mail";
			base.Load += new global::System.EventHandler(this.frmMail_Load);
			base.Closed += new global::System.EventHandler(this.frmMail_Closed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updMailingFrequency).EndInit();
			this.groupBox4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000200 RID: 512
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000201 RID: 513
		private global::System.Windows.Forms.RadioButton optYes;

		// Token: 0x04000202 RID: 514
		private global::System.Windows.Forms.RadioButton optNo;

		// Token: 0x04000203 RID: 515
		private global::System.Windows.Forms.Button btnEdit;

		// Token: 0x04000204 RID: 516
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000205 RID: 517
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000207 RID: 519
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000208 RID: 520
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000209 RID: 521
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400020A RID: 522
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.ComboBox cboList;

		// Token: 0x0400020D RID: 525
		private global::System.Windows.Forms.RadioButton optList;

		// Token: 0x0400020E RID: 526
		public global::System.Windows.Forms.RadioButton optGeo;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.Label labCPM;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.Label labReach;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.Label labCost;

		// Token: 0x04000212 RID: 530
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000213 RID: 531
		private global::System.Windows.Forms.NumericUpDown updMailingFrequency;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.CheckBox chkRepeat;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000215 RID: 533
		private global::System.ComponentModel.Container components = null;
	}
}
