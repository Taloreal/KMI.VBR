namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmPhysicalInventory.
	/// </summary>
	// Token: 0x02000004 RID: 4
	public partial class frmPhysicalInventory : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000010 RID: 16 RVA: 0x00002980 File Offset: 0x00001980
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
		// Token: 0x06000011 RID: 17 RVA: 0x000029BC File Offset: 0x000019BC
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.updFrequency = new global::System.Windows.Forms.NumericUpDown();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.labCost = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.updFrequency).BeginInit();
			base.SuspendLayout();
			this.label1.Location = new global::System.Drawing.Point(24, 40);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(176, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Take physical inventory every ";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.updFrequency.Location = new global::System.Drawing.Point(208, 36);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updFrequency;
			int[] array = new int[4];
			array[0] = 500;
			numericUpDown.Maximum = new decimal(array);
			this.updFrequency.Name = "updFrequency";
			this.updFrequency.Size = new global::System.Drawing.Size(48, 20);
			this.updFrequency.TabIndex = 1;
			this.updFrequency.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.btnOK.Location = new global::System.Drawing.Point(16, 152);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(128, 152);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnHelp.Location = new global::System.Drawing.Point(240, 152);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 6;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.label2.Location = new global::System.Drawing.Point(264, 40);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(56, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "weeks";
			this.label3.Location = new global::System.Drawing.Point(32, 120);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(288, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "If you want to cancel physical inventories, enter 0.";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.labCost.Location = new global::System.Drawing.Point(24, 72);
			this.labCost.Name = "labCost";
			this.labCost.Size = new global::System.Drawing.Size(296, 32);
			this.labCost.TabIndex = 3;
			this.labCost.Text = "The cost of each physical inventory is {0}.  This will be charged to the Wages account on your Income Statement.";
			this.labCost.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(354, 184);
			base.Controls.Add(this.labCost);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.updFrequency);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmPhysicalInventory";
			base.ShowInTaskbar = false;
			this.Text = "Physical Inventory";
			((global::System.ComponentModel.ISupportInitialize)this.updFrequency).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Label labCost;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.NumericUpDown updFrequency;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400001C RID: 28
		private global::System.ComponentModel.Container components = null;
	}
}
