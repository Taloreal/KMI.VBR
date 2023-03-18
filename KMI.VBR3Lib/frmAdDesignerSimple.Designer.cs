namespace KMI.VBR3Lib
{
	// Token: 0x0200004D RID: 77
	public partial class frmAdDesignerSimple : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x060002F4 RID: 756 RVA: 0x00022368 File Offset: 0x00021368
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
		// Token: 0x060002F5 RID: 757 RVA: 0x000223A4 File Offset: 0x000213A4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KMI.VBR3Lib.frmAdDesignerSimple));
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.pnlToolbar = new global::System.Windows.Forms.Panel();
			this.panProd = new global::System.Windows.Forms.Panel();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.grpToolbar = new global::System.Windows.Forms.GroupBox();
			this.pnlCanvas = new global::System.Windows.Forms.Panel();
			this.ColorDialog = new global::System.Windows.Forms.ColorDialog();
			this.toolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.btnDeleteAd = new global::System.Windows.Forms.Button();
			this.btnPricing = new global::System.Windows.Forms.Button();
			this.pnlToolbar.SuspendLayout();
			this.grpToolbar.SuspendLayout();
			base.SuspendLayout();
			this.btnOK.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnOK.ForeColor = global::System.Drawing.Color.Black;
			this.btnOK.Location = new global::System.Drawing.Point(208, 416);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.ForeColor = global::System.Drawing.Color.Black;
			this.btnCancel.Location = new global::System.Drawing.Point(296, 416);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnHelp.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnHelp.ForeColor = global::System.Drawing.Color.Black;
			this.btnHelp.Location = new global::System.Drawing.Point(384, 416);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 4;
			this.btnHelp.Text = "&Help";
			this.btnHelp.UseVisualStyleBackColor = false;
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.pnlToolbar.AutoScroll = true;
			this.pnlToolbar.Controls.Add(this.panProd);
			this.pnlToolbar.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnlToolbar.Location = new global::System.Drawing.Point(3, 16);
			this.pnlToolbar.Name = "pnlToolbar";
			this.pnlToolbar.Size = new global::System.Drawing.Size(162, 341);
			this.pnlToolbar.TabIndex = 4;
			this.panProd.Location = new global::System.Drawing.Point(8, 16);
			this.panProd.Name = "panProd";
			this.panProd.Size = new global::System.Drawing.Size(136, 320);
			this.panProd.TabIndex = 13;
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.White;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			this.imageList1.Images.SetKeyName(2, "");
			this.imageList1.Images.SetKeyName(3, "");
			this.grpToolbar.Controls.Add(this.pnlToolbar);
			this.grpToolbar.Location = new global::System.Drawing.Point(8, 8);
			this.grpToolbar.Name = "grpToolbar";
			this.grpToolbar.Size = new global::System.Drawing.Size(168, 360);
			this.grpToolbar.TabIndex = 46;
			this.grpToolbar.TabStop = false;
			this.grpToolbar.Text = "Select Product";
			this.pnlCanvas.AllowDrop = true;
			this.pnlCanvas.BackColor = global::System.Drawing.Color.White;
			this.pnlCanvas.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlCanvas.Location = new global::System.Drawing.Point(216, 8);
			this.pnlCanvas.Name = "pnlCanvas";
			this.pnlCanvas.Size = new global::System.Drawing.Size(240, 360);
			this.pnlCanvas.TabIndex = 48;
			this.pnlCanvas.Paint += new global::System.Windows.Forms.PaintEventHandler(this.pnlCanvas_Paint);
			this.toolTip.AutomaticDelay = 0;
			this.toolTip.AutoPopDelay = 5000;
			this.toolTip.InitialDelay = 0;
			this.toolTip.ReshowDelay = 0;
			this.btnDeleteAd.Location = new global::System.Drawing.Point(48, 416);
			this.btnDeleteAd.Name = "btnDeleteAd";
			this.btnDeleteAd.Size = new global::System.Drawing.Size(88, 23);
			this.btnDeleteAd.TabIndex = 1;
			this.btnDeleteAd.Text = "Delete Ad";
			this.btnDeleteAd.Click += new global::System.EventHandler(this.btnDeleteAd_Click);
			this.btnPricing.Location = new global::System.Drawing.Point(48, 384);
			this.btnPricing.Name = "btnPricing";
			this.btnPricing.Size = new global::System.Drawing.Size(88, 23);
			this.btnPricing.TabIndex = 0;
			this.btnPricing.Text = "Change Price";
			this.btnPricing.Click += new global::System.EventHandler(this.btnPricing_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(490, 464);
			base.Controls.Add(this.btnPricing);
			base.Controls.Add(this.btnDeleteAd);
			base.Controls.Add(this.pnlCanvas);
			base.Controls.Add(this.grpToolbar);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(624, 496);
			base.MinimizeBox = false;
			base.Name = "frmAdDesignerSimple";
			base.ShowInTaskbar = false;
			this.Text = "Ad Designer";
			this.pnlToolbar.ResumeLayout(false);
			this.grpToolbar.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400027E RID: 638
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x0400027F RID: 639
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000280 RID: 640
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000281 RID: 641
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000282 RID: 642
		private global::System.Windows.Forms.GroupBox grpToolbar;

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.ColorDialog ColorDialog;

		// Token: 0x04000284 RID: 644
		private global::System.Windows.Forms.Panel pnlToolbar;

		// Token: 0x04000285 RID: 645
		private global::System.Windows.Forms.ToolTip toolTip;

		// Token: 0x04000286 RID: 646
		private global::System.Windows.Forms.Button btnDeleteAd;

		// Token: 0x04000287 RID: 647
		private global::System.Windows.Forms.Panel panProd;

		// Token: 0x04000288 RID: 648
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x04000289 RID: 649
		private global::System.Windows.Forms.Button btnPricing;

		// Token: 0x0400028A RID: 650
		private global::System.Windows.Forms.Panel pnlCanvas;
	}
}
