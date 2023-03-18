namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmOpenNewStore.
	/// </summary>
	// Token: 0x02000015 RID: 21
	public partial class frmMoveStore : global::System.Windows.Forms.Form, global::KMI.Sim.IActionForm
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000094 RID: 148 RVA: 0x00009604 File Offset: 0x00008604
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
		// Token: 0x06000097 RID: 151 RVA: 0x000096BC File Offset: 0x000086BC
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.labMonthlyRent = new global::System.Windows.Forms.Label();
			this.labRent = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
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
			this.label2.Location = new global::System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(176, 56);
			this.label2.TabIndex = 1;
			this.label2.Text = "It will cost you {0} to move your store. You will also lose all customer awareness.";
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(384, 32);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(72, 20);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(384, 56);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(72, 20);
			this.btnHelp.TabIndex = 10;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnOK.Location = new global::System.Drawing.Point(384, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(72, 20);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(474, 86);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmOpenNewStore";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Move Store";
			base.Closed += new global::System.EventHandler(this.frmOpenNewStore_Closed);
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.Label labRent;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Label labMonthlyRent;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400008A RID: 138
		private global::System.ComponentModel.Container components = null;
	}
}
