namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmOpenNewStore.
	/// </summary>
	// Token: 0x0200001F RID: 31
	public partial class frmOpenNewStore : global::System.Windows.Forms.Form, global::KMI.Sim.IActionForm
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060000CE RID: 206 RVA: 0x0000B924 File Offset: 0x0000A924
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
		// Token: 0x060000D1 RID: 209 RVA: 0x0000B9DC File Offset: 0x0000A9DC
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.labMonthlyRent = new global::System.Windows.Forms.Label();
			this.labRent = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.optManual = new global::System.Windows.Forms.RadioButton();
			this.optWizard = new global::System.Windows.Forms.RadioButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.txtName = new global::System.Windows.Forms.TextBox();
			this.updCapital = new global::System.Windows.Forms.NumericUpDown();
			this.cboCapital = new global::System.Windows.Forms.ComboBox();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updCapital).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.labMonthlyRent);
			this.groupBox1.Controls.Add(this.labRent);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new global::System.Drawing.Point(216, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(136, 72);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Rent";
			this.labMonthlyRent.ForeColor = global::System.Drawing.Color.Purple;
			this.labMonthlyRent.Location = new global::System.Drawing.Point(64, 48);
			this.labMonthlyRent.Name = "labMonthlyRent";
			this.labMonthlyRent.Size = new global::System.Drawing.Size(56, 16);
			this.labMonthlyRent.TabIndex = 4;
			this.labMonthlyRent.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labRent.ForeColor = global::System.Drawing.Color.Purple;
			this.labRent.Location = new global::System.Drawing.Point(64, 24);
			this.labRent.Name = "labRent";
			this.labRent.Size = new global::System.Drawing.Size(56, 16);
			this.labRent.TabIndex = 3;
			this.labRent.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label6.Location = new global::System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(56, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "Weekly:";
			this.label5.ImageAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label5.Location = new global::System.Drawing.Point(8, 48);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(56, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Monthly:";
			this.groupBox2.Controls.Add(this.optManual);
			this.groupBox2.Controls.Add(this.optWizard);
			this.groupBox2.Location = new global::System.Drawing.Point(368, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(104, 72);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Start-up Mode";
			this.optManual.Location = new global::System.Drawing.Point(8, 48);
			this.optManual.Name = "optManual";
			this.optManual.Size = new global::System.Drawing.Size(72, 16);
			this.optManual.TabIndex = 1;
			this.optManual.Text = "Manual";
			this.optWizard.Checked = true;
			this.optWizard.Location = new global::System.Drawing.Point(8, 24);
			this.optWizard.Name = "optWizard";
			this.optWizard.Size = new global::System.Drawing.Size(72, 16);
			this.optWizard.TabIndex = 0;
			this.optWizard.TabStop = true;
			this.optWizard.Text = "Wizard";
			this.label1.Location = new global::System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(96, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "New Store Name:";
			this.label2.Location = new global::System.Drawing.Point(8, 32);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(88, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Initial Capital:";
			this.label3.Location = new global::System.Drawing.Point(8, 56);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(88, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Transfer from:";
			this.txtName.Location = new global::System.Drawing.Point(104, 8);
			this.txtName.MaxLength = 12;
			this.txtName.Name = "txtName";
			this.txtName.Size = new global::System.Drawing.Size(96, 20);
			this.txtName.TabIndex = 3;
			this.txtName.Text = "";
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updCapital;
			int[] array = new int[4];
			array[0] = 1000;
			numericUpDown.Increment = new decimal(array);
			this.updCapital.Location = new global::System.Drawing.Point(104, 32);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updCapital;
			array = new int[4];
			array[0] = 1000000;
			numericUpDown2.Maximum = new decimal(array);
			this.updCapital.Name = "updCapital";
			this.updCapital.Size = new global::System.Drawing.Size(96, 20);
			this.updCapital.TabIndex = 4;
			this.updCapital.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updCapital.ThousandsSeparator = true;
			this.cboCapital.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCapital.Location = new global::System.Drawing.Point(104, 56);
			this.cboCapital.Name = "cboCapital";
			this.cboCapital.Size = new global::System.Drawing.Size(96, 21);
			this.cboCapital.TabIndex = 5;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(488, 32);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(72, 20);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(488, 56);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(72, 20);
			this.btnHelp.TabIndex = 10;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnOK.Location = new global::System.Drawing.Point(488, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(72, 20);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(576, 86);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.cboCapital);
			base.Controls.Add(this.updCapital);
			base.Controls.Add(this.txtName);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmOpenNewStore";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Open New Store";
			base.Load += new global::System.EventHandler(this.frmOpenNewStore_Load);
			base.Closed += new global::System.EventHandler(this.frmOpenNewStore_Closed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updCapital).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.TextBox txtName;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.NumericUpDown updCapital;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.ComboBox cboCapital;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.Label labRent;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.Label labMonthlyRent;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.RadioButton optManual;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.RadioButton optWizard;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040000DA RID: 218
		private global::System.ComponentModel.Container components = null;
	}
}
