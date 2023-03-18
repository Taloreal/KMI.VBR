namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmRadio.
	/// </summary>
	// Token: 0x02000021 RID: 33
	public partial class frmEquipment : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060000D8 RID: 216 RVA: 0x0000CA58 File Offset: 0x0000BA58
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
		// Token: 0x060000D9 RID: 217 RVA: 0x0000CA94 File Offset: 0x0000BA94
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KMI.VBR3Lib.frmEquipment));
			this.grpStation0 = new global::System.Windows.Forms.GroupBox();
			this.labRegCost = new global::System.Windows.Forms.Label();
			this.updRegisters = new global::System.Windows.Forms.NumericUpDown();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.labCamCost = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.grpStation0.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updRegisters).BeginInit();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.grpStation0.Controls.Add(this.labRegCost);
			this.grpStation0.Controls.Add(this.updRegisters);
			this.grpStation0.Controls.Add(this.label1);
			this.grpStation0.Location = new global::System.Drawing.Point(24, 16);
			this.grpStation0.Name = "grpStation0";
			this.grpStation0.Size = new global::System.Drawing.Size(320, 96);
			this.grpStation0.TabIndex = 0;
			this.grpStation0.TabStop = false;
			this.grpStation0.Text = "Cash Registers";
			this.labRegCost.Location = new global::System.Drawing.Point(48, 24);
			this.labRegCost.Name = "labRegCost";
			this.labRegCost.Size = new global::System.Drawing.Size(248, 16);
			this.labRegCost.TabIndex = 2;
			this.labRegCost.Text = "The weekly lease cost per cash register is {0}.";
			this.updRegisters.Location = new global::System.Drawing.Point(176, 56);
			this.updRegisters.Name = "updRegisters";
			this.updRegisters.Size = new global::System.Drawing.Size(56, 20);
			this.updRegisters.TabIndex = 0;
			this.updRegisters.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.label1.Location = new global::System.Drawing.Point(64, 56);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(112, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Number of Registers:";
			this.btnOK.Location = new global::System.Drawing.Point(24, 272);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(136, 272);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnHelp.Location = new global::System.Drawing.Point(248, 272);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.labCamCost);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new global::System.Drawing.Point(25, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(320, 128);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Security Cameras";
			this.label5.BackColor = global::System.Drawing.SystemColors.Control;
			this.label5.Image = (global::System.Drawing.Image)resources.GetObject("label5.Image");
			this.label5.Location = new global::System.Drawing.Point(224, 16);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(80, 104);
			this.label5.TabIndex = 3;
			this.labCamCost.Location = new global::System.Drawing.Point(16, 24);
			this.labCamCost.Name = "labCamCost";
			this.labCamCost.Size = new global::System.Drawing.Size(168, 32);
			this.labCamCost.TabIndex = 2;
			this.labCamCost.Text = "The weekly lease cost per cash security camera is {0}.";
			this.label4.Location = new global::System.Drawing.Point(16, 64);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(192, 40);
			this.label4.TabIndex = 0;
			this.label4.Text = "To add a camera, click on an camera mount on the top of the store walls.";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(370, 312);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.grpStation0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmEquipment";
			base.ShowInTaskbar = false;
			this.Text = "Equipment";
			this.grpStation0.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updRegisters).EndInit();
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.GroupBox grpStation0;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.NumericUpDown updRegisters;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Label labRegCost;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.Label labCamCost;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040000EC RID: 236
		private global::System.ComponentModel.Container components = null;
	}
}
