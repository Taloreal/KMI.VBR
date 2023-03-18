namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmCoupon.
	/// </summary>
	// Token: 0x02000022 RID: 34
	public partial class frmCoupon : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060000DD RID: 221 RVA: 0x0000D280 File Offset: 0x0000C280
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
		// Token: 0x060000DE RID: 222 RVA: 0x0000D2BC File Offset: 0x0000C2BC
		private void InitializeComponent()
		{
			this.picCoupons = new global::System.Windows.Forms.PictureBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnClear = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.button4 = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.labValidFor = new global::System.Windows.Forms.Label();
			this.btnInsertCoupons = new global::System.Windows.Forms.Button();
			this.updPercentOff = new global::System.Windows.Forms.NumericUpDown();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cboProduct = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.updPercentOff).BeginInit();
			base.SuspendLayout();
			this.picCoupons.Location = new global::System.Drawing.Point(32, 16);
			this.picCoupons.Name = "picCoupons";
			this.picCoupons.Size = new global::System.Drawing.Size(560, 184);
			this.picCoupons.TabIndex = 0;
			this.picCoupons.TabStop = false;
			this.picCoupons.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picCoupons_Paint);
			this.btnOK.Location = new global::System.Drawing.Point(96, 328);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "Done";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnClear.Location = new global::System.Drawing.Point(208, 328);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new global::System.Drawing.Size(96, 24);
			this.btnClear.TabIndex = 4;
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new global::System.EventHandler(this.btnClear_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(320, 328);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.button4.Location = new global::System.Drawing.Point(432, 328);
			this.button4.Name = "button4";
			this.button4.Size = new global::System.Drawing.Size(96, 24);
			this.button4.TabIndex = 6;
			this.button4.Text = "Help";
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.groupBox1.Controls.Add(this.labValidFor);
			this.groupBox1.Controls.Add(this.btnInsertCoupons);
			this.groupBox1.Controls.Add(this.updPercentOff);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cboProduct);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new global::System.Drawing.Point(160, 216);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(296, 96);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Next Coupon(s)";
			this.labValidFor.Location = new global::System.Drawing.Point(216, 32);
			this.labValidFor.Name = "labValidFor";
			this.labValidFor.Size = new global::System.Drawing.Size(72, 48);
			this.labValidFor.TabIndex = 5;
			this.labValidFor.Text = "All coupons are valid for # days.";
			this.btnInsertCoupons.Location = new global::System.Drawing.Point(24, 64);
			this.btnInsertCoupons.Name = "btnInsertCoupons";
			this.btnInsertCoupons.Size = new global::System.Drawing.Size(152, 24);
			this.btnInsertCoupons.TabIndex = 2;
			this.btnInsertCoupons.Text = "Insert Coupon(s)";
			this.btnInsertCoupons.Click += new global::System.EventHandler(this.btnInsertCoupons_Click);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.updPercentOff;
			int[] array = new int[4];
			array[0] = 5;
			numericUpDown.Increment = new decimal(array);
			this.updPercentOff.Location = new global::System.Drawing.Point(144, 32);
			this.updPercentOff.Name = "updPercentOff";
			this.updPercentOff.Size = new global::System.Drawing.Size(40, 20);
			this.updPercentOff.TabIndex = 1;
			this.updPercentOff.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.updPercentOff;
			array = new int[4];
			array[0] = 25;
			numericUpDown2.Value = new decimal(array);
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(144, 16);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(40, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "% Off";
			this.cboProduct.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboProduct.Location = new global::System.Drawing.Point(16, 32);
			this.cboProduct.Name = "cboProduct";
			this.cboProduct.Size = new global::System.Drawing.Size(112, 21);
			this.cboProduct.TabIndex = 0;
			this.label1.Location = new global::System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Product";
			base.AcceptButton = this.btnInsertCoupons;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(624, 368);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.button4);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnClear);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.picCoupons);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmCoupon";
			base.ShowInTaskbar = false;
			this.Text = "Create Coupons";
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.updPercentOff).EndInit();
			base.ResumeLayout(false);
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		// Token: 0x040000ED RID: 237
		private global::System.ComponentModel.Container components = null;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.Button button4;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.ComboBox cboProduct;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.NumericUpDown updPercentOff;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.Button btnInsertCoupons;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.PictureBox picCoupons;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.Button btnClear;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.Label labValidFor;
	}
}
