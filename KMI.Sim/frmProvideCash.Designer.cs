namespace KMI.Sim
{
	// Token: 0x02000052 RID: 82
	public partial class frmProvideCash : global::System.Windows.Forms.Form
	{
		// Token: 0x06000304 RID: 772 RVA: 0x00017E44 File Offset: 0x00016E44
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

		// Token: 0x06000305 RID: 773 RVA: 0x00017E80 File Offset: 0x00016E80
		private void InitializeComponent()
		{
			this.btnOk = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.updCash = new global::System.Windows.Forms.NumericUpDown();
			this.labStore = new global::System.Windows.Forms.Label();
			this.labDescription = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.updCash).BeginInit();
			base.SuspendLayout();
			this.btnOk.Location = new global::System.Drawing.Point(72, 144);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new global::System.Drawing.Size(96, 24);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(192, 144);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updCash;
			int[] array = new int[4];
			array[0] = 10000;
			numericUpDown.Increment = new decimal(array);
			this.updCash.Location = new global::System.Drawing.Point(208, 88);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updCash;
			array = new int[4];
			array[0] = 100000000;
			numericUpDown2.Maximum = new decimal(array);
			this.updCash.Minimum = new decimal(new int[]
			{
				100000000,
				0,
				0,
				int.MinValue
			});
			this.updCash.Name = "updCash";
			this.updCash.Size = new global::System.Drawing.Size(88, 20);
			this.updCash.TabIndex = 2;
			this.updCash.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.updCash.ThousandsSeparator = true;
			this.labStore.Location = new global::System.Drawing.Point(24, 88);
			this.labStore.Name = "labStore";
			this.labStore.Size = new global::System.Drawing.Size(184, 16);
			this.labStore.TabIndex = 1;
			this.labStore.Text = "Amount to give to XXX:";
			this.labStore.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labDescription.Location = new global::System.Drawing.Point(24, 8);
			this.labDescription.Name = "labDescription";
			this.labDescription.Size = new global::System.Drawing.Size(304, 64);
			this.labDescription.TabIndex = 0;
			this.labDescription.Text = "This feature lets you \"bail out\" the current XXX by providing cash.  The students' equity is not reduced.  This feature can be used by Instructors to keep students involved and encouraged.";
			base.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(352, 190);
			base.Controls.Add(this.labDescription);
			base.Controls.Add(this.labStore);
			base.Controls.Add(this.updCash);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmProvideCash";
			base.ShowInTaskbar = false;
			this.Text = "Provide Cash";
			((global::System.ComponentModel.ISupportInitialize)this.updCash).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.Button btnOk;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.NumericUpDown updCash;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.Label labStore;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.Label labDescription;

		// Token: 0x040001E5 RID: 485
		private global::System.ComponentModel.Container components = null;
	}
}
