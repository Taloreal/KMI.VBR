namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmServiceContracts.
	/// </summary>
	// Token: 0x0200001E RID: 30
	public partial class frmServiceContracts : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060000C8 RID: 200 RVA: 0x0000B014 File Offset: 0x0000A014
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
		// Token: 0x060000C9 RID: 201 RVA: 0x0000B050 File Offset: 0x0000A050
		private void InitializeComponent()
		{
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnHelp.Location = new global::System.Drawing.Point(464, 280);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 9;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(352, 280);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(232, 280);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.label2.Location = new global::System.Drawing.Point(184, 24);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(64, 32);
			this.label2.TabIndex = 11;
			this.label2.Text = "Response Time";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label3.Location = new global::System.Drawing.Point(360, 24);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(64, 32);
			this.label3.TabIndex = 12;
			this.label3.Text = "Weekly Cost";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label4.Location = new global::System.Drawing.Point(24, 24);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(72, 32);
			this.label4.TabIndex = 13;
			this.label4.Text = "Equipment Type";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label5.Location = new global::System.Drawing.Point(280, 24);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(64, 32);
			this.label5.TabIndex = 14;
			this.label5.Text = "Units Leased";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.panel1.Location = new global::System.Drawing.Point(24, 64);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(536, 192);
			this.panel1.TabIndex = 15;
			this.label1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Location = new global::System.Drawing.Point(24, 56);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(536, 3);
			this.label1.TabIndex = 16;
			this.label1.Text = "label1";
			this.label6.Location = new global::System.Drawing.Point(464, 24);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(64, 32);
			this.label6.TabIndex = 17;
			this.label6.Text = "Immediate Repair";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.label7.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.DimGray;
			this.label7.Location = new global::System.Drawing.Point(24, 272);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(184, 40);
			this.label7.TabIndex = 18;
			this.label7.Text = "Hint: A service contract lets you pay a weekly fee in exchange for a guarantee to fix equipment within a specified time.";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(578, 320);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.label6);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmServiceContracts";
			base.ShowInTaskbar = false;
			this.Text = "Service & Repairs";
			base.ResumeLayout(false);
		}

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.Label label7;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040000C7 RID: 199
		private global::System.ComponentModel.Container components = null;
	}
}
