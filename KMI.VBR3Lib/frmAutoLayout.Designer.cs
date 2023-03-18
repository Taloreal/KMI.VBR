namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmAutoLayout.
	/// </summary>
	// Token: 0x0200003F RID: 63
	public partial class frmAutoLayout : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060001EE RID: 494 RVA: 0x0001CE28 File Offset: 0x0001BE28
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
		// Token: 0x060001EF RID: 495 RVA: 0x0001CE64 File Offset: 0x0001BE64
		private void InitializeComponent()
		{
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.radAuto = new global::System.Windows.Forms.RadioButton();
			this.radioButton2 = new global::System.Windows.Forms.RadioButton();
			base.SuspendLayout();
			this.btnHelp.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnHelp.ForeColor = global::System.Drawing.Color.Black;
			this.btnHelp.Location = new global::System.Drawing.Point(208, 128);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 4;
			this.btnHelp.Text = "&Help";
			this.btnHelp.UseVisualStyleBackColor = false;
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.ForeColor = global::System.Drawing.Color.Black;
			this.btnCancel.Location = new global::System.Drawing.Point(120, 128);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnOK.ForeColor = global::System.Drawing.Color.Black;
			this.btnOK.Location = new global::System.Drawing.Point(32, 128);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.radAuto.Checked = true;
			this.radAuto.Location = new global::System.Drawing.Point(40, 16);
			this.radAuto.Name = "radAuto";
			this.radAuto.Size = new global::System.Drawing.Size(264, 48);
			this.radAuto.TabIndex = 0;
			this.radAuto.TabStop = true;
			this.radAuto.Text = "Start me out with a basic, random layout. Make sure there is a shelf for each type of product.";
			this.radioButton2.Location = new global::System.Drawing.Point(40, 72);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new global::System.Drawing.Size(264, 32);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Start me out with an empty floor. I'll do my own layout later.";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(320, 174);
			base.Controls.Add(this.radioButton2);
			base.Controls.Add(this.radAuto);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Name = "frmAutoLayout";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Store Layout";
			base.ResumeLayout(false);
		}

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.RadioButton radioButton2;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.RadioButton radAuto;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040001E5 RID: 485
		private global::System.ComponentModel.Container components = null;
	}
}
