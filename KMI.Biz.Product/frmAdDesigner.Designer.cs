namespace KMI.Biz.Product
{
	// Token: 0x02000017 RID: 23
	public partial class frmAdDesigner : global::System.Windows.Forms.Form
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00008CF4 File Offset: 0x00007CF4
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

		// Token: 0x06000094 RID: 148 RVA: 0x00008D30 File Offset: 0x00007D30
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::KMI.Biz.Product.frmAdDesigner));
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.pnlToolbar = new global::System.Windows.Forms.Panel();
			this.panProd = new global::System.Windows.Forms.Panel();
			this.lblProductInfo = new global::System.Windows.Forms.Label();
			this.lblText = new global::System.Windows.Forms.Label();
			this.panText = new global::System.Windows.Forms.Panel();
			this.lblLowestPrices = new global::System.Windows.Forms.Label();
			this.lblSpecial = new global::System.Windows.Forms.Label();
			this.lblClearance = new global::System.Windows.Forms.Label();
			this.lblOnSaleNow = new global::System.Windows.Forms.Label();
			this.grpTextProperties = new global::System.Windows.Forms.GroupBox();
			this.lblSize = new global::System.Windows.Forms.Label();
			this.lblFont = new global::System.Windows.Forms.Label();
			this.cboFontSize = new global::System.Windows.Forms.ComboBox();
			this.cboFont = new global::System.Windows.Forms.ComboBox();
			this.toolBar1 = new global::System.Windows.Forms.ToolBar();
			this.tbbBold = new global::System.Windows.Forms.ToolBarButton();
			this.tbbItalic = new global::System.Windows.Forms.ToolBarButton();
			this.tbbUnderline = new global::System.Windows.Forms.ToolBarButton();
			this.tbbColor = new global::System.Windows.Forms.ToolBarButton();
			this.imageList1 = new global::System.Windows.Forms.ImageList(this.components);
			this.grpProductProperties = new global::System.Windows.Forms.GroupBox();
			this.lblProductSize = new global::System.Windows.Forms.Label();
			this.lblProductShow = new global::System.Windows.Forms.Label();
			this.chkProductPrice = new global::System.Windows.Forms.CheckBox();
			this.chkProductName = new global::System.Windows.Forms.CheckBox();
			this.radProductLarge = new global::System.Windows.Forms.RadioButton();
			this.radProductMedium = new global::System.Windows.Forms.RadioButton();
			this.radProductSmall = new global::System.Windows.Forms.RadioButton();
			this.grpToolbar = new global::System.Windows.Forms.GroupBox();
			this.grpInstructions = new global::System.Windows.Forms.GroupBox();
			this.lblInstructions = new global::System.Windows.Forms.Label();
			this.pnlCanvas = new global::System.Windows.Forms.Panel();
			this.ColorDialog = new global::System.Windows.Forms.ColorDialog();
			this.toolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.btnDelete = new global::System.Windows.Forms.Button();
			this.btnDeleteAd = new global::System.Windows.Forms.Button();
			this.pnlToolbar.SuspendLayout();
			this.panText.SuspendLayout();
			this.grpTextProperties.SuspendLayout();
			this.grpProductProperties.SuspendLayout();
			this.grpToolbar.SuspendLayout();
			this.grpInstructions.SuspendLayout();
			base.SuspendLayout();
			this.btnOK.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnOK.ForeColor = global::System.Drawing.Color.Black;
			this.btnOK.Location = new global::System.Drawing.Point(352, 408);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.ForeColor = global::System.Drawing.Color.Black;
			this.btnCancel.Location = new global::System.Drawing.Point(440, 408);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnHelp.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnHelp.ForeColor = global::System.Drawing.Color.Black;
			this.btnHelp.Location = new global::System.Drawing.Point(528, 408);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.TabIndex = 3;
			this.btnHelp.Text = "&Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.pnlToolbar.AutoScroll = true;
			this.pnlToolbar.Controls.Add(this.panProd);
			this.pnlToolbar.Controls.Add(this.lblProductInfo);
			this.pnlToolbar.Controls.Add(this.lblText);
			this.pnlToolbar.Controls.Add(this.panText);
			this.pnlToolbar.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnlToolbar.Location = new global::System.Drawing.Point(3, 16);
			this.pnlToolbar.Name = "pnlToolbar";
			this.pnlToolbar.Size = new global::System.Drawing.Size(146, 341);
			this.pnlToolbar.TabIndex = 4;
			this.panProd.Location = new global::System.Drawing.Point(8, 248);
			this.panProd.Name = "panProd";
			this.panProd.Size = new global::System.Drawing.Size(120, 128);
			this.panProd.TabIndex = 13;
			this.lblProductInfo.AutoSize = true;
			this.lblProductInfo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblProductInfo.Location = new global::System.Drawing.Point(8, 232);
			this.lblProductInfo.Name = "lblProductInfo";
			this.lblProductInfo.Size = new global::System.Drawing.Size(68, 16);
			this.lblProductInfo.TabIndex = 11;
			this.lblProductInfo.Text = "Product Info";
			this.lblText.AutoSize = true;
			this.lblText.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblText.Location = new global::System.Drawing.Point(8, 16);
			this.lblText.Name = "lblText";
			this.lblText.Size = new global::System.Drawing.Size(27, 16);
			this.lblText.TabIndex = 2;
			this.lblText.Text = "Text";
			this.panText.Controls.Add(this.lblLowestPrices);
			this.panText.Controls.Add(this.lblSpecial);
			this.panText.Controls.Add(this.lblClearance);
			this.panText.Controls.Add(this.lblOnSaleNow);
			this.panText.Location = new global::System.Drawing.Point(24, 32);
			this.panText.Name = "panText";
			this.panText.Size = new global::System.Drawing.Size(96, 200);
			this.panText.TabIndex = 12;
			this.lblLowestPrices.AutoSize = true;
			this.lblLowestPrices.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.lblLowestPrices.Location = new global::System.Drawing.Point(8, 32);
			this.lblLowestPrices.Name = "lblLowestPrices";
			this.lblLowestPrices.Size = new global::System.Drawing.Size(78, 16);
			this.lblLowestPrices.TabIndex = 5;
			this.lblLowestPrices.Text = "Lowest Prices!";
			this.lblSpecial.AutoSize = true;
			this.lblSpecial.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.lblSpecial.Location = new global::System.Drawing.Point(8, 56);
			this.lblSpecial.Name = "lblSpecial";
			this.lblSpecial.Size = new global::System.Drawing.Size(45, 16);
			this.lblSpecial.TabIndex = 6;
			this.lblSpecial.Text = "Special!";
			this.lblClearance.AutoSize = true;
			this.lblClearance.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.lblClearance.Location = new global::System.Drawing.Point(8, 80);
			this.lblClearance.Name = "lblClearance";
			this.lblClearance.Size = new global::System.Drawing.Size(59, 16);
			this.lblClearance.TabIndex = 7;
			this.lblClearance.Text = "Clearance!";
			this.lblOnSaleNow.AutoSize = true;
			this.lblOnSaleNow.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.lblOnSaleNow.Location = new global::System.Drawing.Point(8, 8);
			this.lblOnSaleNow.Name = "lblOnSaleNow";
			this.lblOnSaleNow.Size = new global::System.Drawing.Size(74, 16);
			this.lblOnSaleNow.TabIndex = 4;
			this.lblOnSaleNow.Text = "On Sale Now!";
			this.grpTextProperties.Controls.Add(this.lblSize);
			this.grpTextProperties.Controls.Add(this.lblFont);
			this.grpTextProperties.Controls.Add(this.cboFontSize);
			this.grpTextProperties.Controls.Add(this.cboFont);
			this.grpTextProperties.Controls.Add(this.toolBar1);
			this.grpTextProperties.Location = new global::System.Drawing.Point(440, 8);
			this.grpTextProperties.Name = "grpTextProperties";
			this.grpTextProperties.Size = new global::System.Drawing.Size(160, 248);
			this.grpTextProperties.TabIndex = 44;
			this.grpTextProperties.TabStop = false;
			this.grpTextProperties.Text = "Properties";
			this.grpTextProperties.Visible = false;
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new global::System.Drawing.Point(16, 108);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new global::System.Drawing.Size(29, 16);
			this.lblSize.TabIndex = 50;
			this.lblSize.Text = "&Size:";
			this.lblSize.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.lblFont.AutoSize = true;
			this.lblFont.Location = new global::System.Drawing.Point(16, 76);
			this.lblFont.Name = "lblFont";
			this.lblFont.Size = new global::System.Drawing.Size(30, 16);
			this.lblFont.TabIndex = 49;
			this.lblFont.Text = "&Font:";
			this.lblFont.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cboFontSize.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFontSize.Location = new global::System.Drawing.Point(48, 104);
			this.cboFontSize.Name = "cboFontSize";
			this.cboFontSize.Size = new global::System.Drawing.Size(56, 21);
			this.cboFontSize.TabIndex = 47;
			this.cboFontSize.SelectedIndexChanged += new global::System.EventHandler(this.UserFontChanged);
			this.cboFont.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFont.Location = new global::System.Drawing.Point(48, 72);
			this.cboFont.Name = "cboFont";
			this.cboFont.Size = new global::System.Drawing.Size(104, 21);
			this.cboFont.TabIndex = 46;
			this.cboFont.SelectedIndexChanged += new global::System.EventHandler(this.UserFontChanged);
			this.toolBar1.Buttons.AddRange(new global::System.Windows.Forms.ToolBarButton[]
			{
				this.tbbBold,
				this.tbbItalic,
				this.tbbUnderline,
				this.tbbColor
			});
			this.toolBar1.ButtonSize = new global::System.Drawing.Size(24, 24);
			this.toolBar1.Divider = false;
			this.toolBar1.Dock = global::System.Windows.Forms.DockStyle.None;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new global::System.Drawing.Point(24, 24);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new global::System.Drawing.Size(112, 28);
			this.toolBar1.TabIndex = 53;
			this.toolBar1.ButtonClick += new global::System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			this.tbbBold.ImageIndex = 0;
			this.tbbBold.Style = global::System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbbBold.Text = "B";
			this.tbbItalic.ImageIndex = 2;
			this.tbbItalic.Style = global::System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbbItalic.Text = "I";
			this.tbbUnderline.ImageIndex = 3;
			this.tbbUnderline.Style = global::System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbbUnderline.Text = "U";
			this.tbbColor.ImageIndex = 1;
			this.imageList1.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new global::System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = (global::System.Windows.Forms.ImageListStreamer)resourceManager.GetObject("imageList1.ImageStream");
			this.imageList1.TransparentColor = global::System.Drawing.Color.White;
			this.grpProductProperties.Controls.Add(this.lblProductSize);
			this.grpProductProperties.Controls.Add(this.lblProductShow);
			this.grpProductProperties.Controls.Add(this.chkProductPrice);
			this.grpProductProperties.Controls.Add(this.chkProductName);
			this.grpProductProperties.Controls.Add(this.radProductLarge);
			this.grpProductProperties.Controls.Add(this.radProductMedium);
			this.grpProductProperties.Controls.Add(this.radProductSmall);
			this.grpProductProperties.Location = new global::System.Drawing.Point(440, 8);
			this.grpProductProperties.Name = "grpProductProperties";
			this.grpProductProperties.Size = new global::System.Drawing.Size(160, 248);
			this.grpProductProperties.TabIndex = 45;
			this.grpProductProperties.TabStop = false;
			this.grpProductProperties.Text = "Properties";
			this.lblProductSize.AutoSize = true;
			this.lblProductSize.Location = new global::System.Drawing.Point(16, 120);
			this.lblProductSize.Name = "lblProductSize";
			this.lblProductSize.Size = new global::System.Drawing.Size(71, 16);
			this.lblProductSize.TabIndex = 6;
			this.lblProductSize.Text = "Product Si&ze:";
			this.lblProductShow.AutoSize = true;
			this.lblProductShow.Location = new global::System.Drawing.Point(16, 40);
			this.lblProductShow.Name = "lblProductShow";
			this.lblProductShow.Size = new global::System.Drawing.Size(36, 16);
			this.lblProductShow.TabIndex = 5;
			this.lblProductShow.Text = "S&how:";
			this.chkProductPrice.Location = new global::System.Drawing.Point(24, 80);
			this.chkProductPrice.Name = "chkProductPrice";
			this.chkProductPrice.TabIndex = 1;
			this.chkProductPrice.Text = "Product &Price";
			this.chkProductPrice.CheckedChanged += new global::System.EventHandler(this.chkProductPrice_CheckedChanged);
			this.chkProductName.Location = new global::System.Drawing.Point(24, 56);
			this.chkProductName.Name = "chkProductName";
			this.chkProductName.TabIndex = 0;
			this.chkProductName.Text = "Product &Name";
			this.chkProductName.CheckedChanged += new global::System.EventHandler(this.chkProductName_CheckedChanged);
			this.radProductLarge.Location = new global::System.Drawing.Point(24, 184);
			this.radProductLarge.Name = "radProductLarge";
			this.radProductLarge.TabIndex = 4;
			this.radProductLarge.Text = "&Large";
			this.radProductLarge.CheckedChanged += new global::System.EventHandler(this.radProductSize_Click);
			this.radProductMedium.Location = new global::System.Drawing.Point(24, 160);
			this.radProductMedium.Name = "radProductMedium";
			this.radProductMedium.TabIndex = 3;
			this.radProductMedium.Text = "&Medium";
			this.radProductMedium.CheckedChanged += new global::System.EventHandler(this.radProductSize_Click);
			this.radProductSmall.Location = new global::System.Drawing.Point(24, 136);
			this.radProductSmall.Name = "radProductSmall";
			this.radProductSmall.TabIndex = 2;
			this.radProductSmall.Text = "&Small";
			this.radProductSmall.CheckedChanged += new global::System.EventHandler(this.radProductSize_Click);
			this.grpToolbar.Controls.Add(this.pnlToolbar);
			this.grpToolbar.Location = new global::System.Drawing.Point(8, 8);
			this.grpToolbar.Name = "grpToolbar";
			this.grpToolbar.Size = new global::System.Drawing.Size(152, 360);
			this.grpToolbar.TabIndex = 46;
			this.grpToolbar.TabStop = false;
			this.grpToolbar.Text = "Tool Bar";
			this.grpInstructions.Controls.Add(this.lblInstructions);
			this.grpInstructions.Location = new global::System.Drawing.Point(8, 376);
			this.grpInstructions.Name = "grpInstructions";
			this.grpInstructions.Size = new global::System.Drawing.Size(328, 56);
			this.grpInstructions.TabIndex = 47;
			this.grpInstructions.TabStop = false;
			this.grpInstructions.Text = "Instructions";
			this.lblInstructions.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblInstructions.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblInstructions.Location = new global::System.Drawing.Point(16, 20);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Size = new global::System.Drawing.Size(304, 24);
			this.lblInstructions.TabIndex = 0;
			this.lblInstructions.Text = "To create your Ad drag any of the objects on the left onto your canvas.  You can then edit these objects using the properties on the right.";
			this.pnlCanvas.AllowDrop = true;
			this.pnlCanvas.BackColor = global::System.Drawing.Color.White;
			this.pnlCanvas.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlCanvas.Location = new global::System.Drawing.Point(216, 8);
			this.pnlCanvas.Name = "pnlCanvas";
			this.pnlCanvas.Size = new global::System.Drawing.Size(168, 360);
			this.pnlCanvas.TabIndex = 48;
			this.pnlCanvas.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.pnlCanvas_DragEnter);
			this.pnlCanvas.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.pnlCanvas_DragDrop);
			this.pnlCanvas.DragOver += new global::System.Windows.Forms.DragEventHandler(this.pnlCanvas_DragOver);
			this.toolTip.AutomaticDelay = 0;
			this.toolTip.AutoPopDelay = 5000;
			this.toolTip.InitialDelay = 0;
			this.toolTip.ReshowDelay = 0;
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new global::System.Drawing.Point(352, 376);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new global::System.Drawing.Size(160, 23);
			this.btnDelete.TabIndex = 49;
			this.btnDelete.Text = "&Delete Selected Object";
			this.btnDelete.Click += new global::System.EventHandler(this.btnDelete_Click);
			this.btnDeleteAd.Location = new global::System.Drawing.Point(528, 376);
			this.btnDeleteAd.Name = "btnDeleteAd";
			this.btnDeleteAd.TabIndex = 50;
			this.btnDeleteAd.Text = "Delete Ad";
			this.btnDeleteAd.Click += new global::System.EventHandler(this.btnDeleteAd_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(618, 464);
			base.Controls.Add(this.btnDeleteAd);
			base.Controls.Add(this.grpTextProperties);
			base.Controls.Add(this.btnDelete);
			base.Controls.Add(this.pnlCanvas);
			base.Controls.Add(this.grpInstructions);
			base.Controls.Add(this.grpToolbar);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.grpProductProperties);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(624, 496);
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(624, 496);
			base.Name = "frmAdDesigner";
			base.ShowInTaskbar = false;
			this.Text = "Ad Designer";
			this.pnlToolbar.ResumeLayout(false);
			this.panText.ResumeLayout(false);
			this.grpTextProperties.ResumeLayout(false);
			this.grpProductProperties.ResumeLayout(false);
			this.grpToolbar.ResumeLayout(false);
			this.grpInstructions.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x040000C3 RID: 195
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.GroupBox grpTextProperties;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.GroupBox grpProductProperties;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.CheckBox chkProductName;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.CheckBox chkProductPrice;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.RadioButton radProductSmall;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.RadioButton radProductMedium;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.RadioButton radProductLarge;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Label lblProductShow;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.Label lblProductSize;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.GroupBox grpToolbar;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.GroupBox grpInstructions;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.Label lblOnSaleNow;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.Label lblLowestPrices;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.Label lblSpecial;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Label lblClearance;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.ColorDialog ColorDialog;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Label lblSize;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Label lblFont;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.Label lblInstructions;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.Panel pnlToolbar;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.ComboBox cboFontSize;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.ComboBox cboFont;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.ToolTip toolTip;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.Button btnDelete;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.Label lblProductInfo;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Label lblText;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.Button btnDeleteAd;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Panel panText;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Panel panProd;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.ToolBar toolBar1;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.ToolBarButton tbbBold;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.ToolBarButton tbbItalic;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.ToolBarButton tbbUnderline;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.ToolBarButton tbbColor;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.ImageList imageList1;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.Panel pnlCanvas;
	}
}
