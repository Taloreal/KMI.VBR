namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	// Token: 0x02000023 RID: 35
	public partial class frmBillboard : global::System.Windows.Forms.Form, global::KMI.Sim.IActionForm
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060000E5 RID: 229 RVA: 0x0000DDF4 File Offset: 0x0000CDF4
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
		// Token: 0x060000E6 RID: 230 RVA: 0x0000DE30 File Offset: 0x0000CE30
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.labCostPerWeek = new global::System.Windows.Forms.Label();
			this.labReachPerWeek = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.labCostPerWeek);
			this.groupBox1.Controls.Add(this.labReachPerWeek);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new global::System.Drawing.Point(144, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(216, 80);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Billboard Cost";
			this.labCostPerWeek.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.labCostPerWeek.Location = new global::System.Drawing.Point(128, 48);
			this.labCostPerWeek.Name = "labCostPerWeek";
			this.labCostPerWeek.Size = new global::System.Drawing.Size(80, 16);
			this.labCostPerWeek.TabIndex = 5;
			this.labReachPerWeek.Location = new global::System.Drawing.Point(128, 24);
			this.labReachPerWeek.Name = "labReachPerWeek";
			this.labReachPerWeek.Size = new global::System.Drawing.Size(80, 16);
			this.labReachPerWeek.TabIndex = 4;
			this.label5.Location = new global::System.Drawing.Point(8, 48);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(115, 16);
			this.label5.TabIndex = 2;
			this.label5.Text = "Cost per Week:";
			this.label4.Location = new global::System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(115, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Est. Reach per Week:";
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(192, 0, 0);
			this.label2.Location = new global::System.Drawing.Point(16, 32);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(112, 40);
			this.label2.TabIndex = 0;
			this.label2.Text = "Click on City View to place sign.";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(376, 24);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(376, 56);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(496, 102);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.groupBox1);
			base.Name = "frmBillboard";
			base.ShowInTaskbar = false;
			this.Text = "Promotion - Billboard Advertising";
			base.Closed += new global::System.EventHandler(this.frmBillboard_Closed);
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000100 RID: 256
		public global::System.Windows.Forms.Label labReachPerWeek;

		// Token: 0x04000101 RID: 257
		public global::System.Windows.Forms.Label labCostPerWeek;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.Button btnHelp;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x04000104 RID: 260
		private global::System.ComponentModel.Container components = null;
	}
}
