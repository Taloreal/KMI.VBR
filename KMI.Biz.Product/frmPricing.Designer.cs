namespace KMI.Biz.Product
{
	// Token: 0x02000022 RID: 34
	public partial class frmPricing : global::System.Windows.Forms.Form
	{
		// Token: 0x06000100 RID: 256 RVA: 0x0000F244 File Offset: 0x0000E244
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

		// Token: 0x06000101 RID: 257 RVA: 0x0000F280 File Offset: 0x0000E280
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.lblPoints = new global::System.Windows.Forms.Label();
			this.lblMarginPoints = new global::System.Windows.Forms.Label();
			this.lblGraphTitle = new global::System.Windows.Forms.Label();
			this.grpCustom = new global::System.Windows.Forms.GroupBox();
			this.lblInstructions = new global::System.Windows.Forms.Label();
			this.panCustom = new global::System.Windows.Forms.Panel();
			this.btnAdvanced = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.grpLegend = new global::System.Windows.Forms.GroupBox();
			this.lblIntlPrices = new global::System.Windows.Forms.Label();
			this.picIntlLegend = new global::System.Windows.Forms.PictureBox();
			this.lblCurrentCost = new global::System.Windows.Forms.Label();
			this.lblCompetitorPrices = new global::System.Windows.Forms.Label();
			this.lblYourRecentPrices = new global::System.Windows.Forms.Label();
			this.picLegendCanvas = new global::System.Windows.Forms.PictureBox();
			this.txtMargin = new global::System.Windows.Forms.TextBox();
			this.sliPrice = new global::System.Windows.Forms.TrackBar();
			this.lblLo = new global::System.Windows.Forms.Label();
			this.lblHi = new global::System.Windows.Forms.Label();
			this.picGraph = new global::System.Windows.Forms.PictureBox();
			this.grpMarginExplanation = new global::System.Windows.Forms.GroupBox();
			this.lblMarginDefinition = new global::System.Windows.Forms.Label();
			this.lblGlobalPercentage = new global::System.Windows.Forms.Label();
			this.myToolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.lblLastWeeks = new global::System.Windows.Forms.Label();
			this.lblPoints2 = new global::System.Windows.Forms.Label();
			this.labIntlMarginPoints = new global::System.Windows.Forms.Label();
			this.txtIntlMargin = new global::System.Windows.Forms.TextBox();
			this.grpCustom.SuspendLayout();
			this.grpLegend.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.sliPrice).BeginInit();
			this.grpMarginExplanation.SuspendLayout();
			base.SuspendLayout();
			this.lblPoints.AutoSize = true;
			this.lblPoints.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblPoints.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblPoints.Location = new global::System.Drawing.Point(237, 72);
			this.lblPoints.Name = "lblPoints";
			this.lblPoints.Size = new global::System.Drawing.Size(16, 14);
			this.lblPoints.TabIndex = 7;
			this.lblPoints.Text = "pts";
			this.lblMarginPoints.Location = new global::System.Drawing.Point(185, 16);
			this.lblMarginPoints.Name = "lblMarginPoints";
			this.lblMarginPoints.Size = new global::System.Drawing.Size(77, 40);
			this.lblMarginPoints.TabIndex = 5;
			this.lblMarginPoints.Text = "Margin &Points:";
			this.lblMarginPoints.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.lblGraphTitle.AutoSize = true;
			this.lblGraphTitle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblGraphTitle.Location = new global::System.Drawing.Point(72, 32);
			this.lblGraphTitle.Name = "lblGraphTitle";
			this.lblGraphTitle.Size = new global::System.Drawing.Size(52, 16);
			this.lblGraphTitle.TabIndex = 2;
			this.lblGraphTitle.Text = "Set Price";
			this.grpCustom.Controls.Add(this.lblInstructions);
			this.grpCustom.Controls.Add(this.panCustom);
			this.grpCustom.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.grpCustom.Location = new global::System.Drawing.Point(281, 8);
			this.grpCustom.Name = "grpCustom";
			this.grpCustom.Size = new global::System.Drawing.Size(471, 408);
			this.grpCustom.TabIndex = 15;
			this.grpCustom.TabStop = false;
			this.grpCustom.Text = "Custom Policies";
			this.lblInstructions.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblInstructions.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblInstructions.Location = new global::System.Drawing.Point(16, 16);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Size = new global::System.Drawing.Size(288, 24);
			this.lblInstructions.TabIndex = 0;
			this.lblInstructions.Text = "Check off each product you want to custom price, or click on the product name to set a price.";
			this.panCustom.AutoScroll = true;
			this.panCustom.Location = new global::System.Drawing.Point(2, 44);
			this.panCustom.Name = "panCustom";
			this.panCustom.Size = new global::System.Drawing.Size(462, 360);
			this.panCustom.TabIndex = 1;
			this.btnAdvanced.Location = new global::System.Drawing.Point(192, 248);
			this.btnAdvanced.Name = "btnAdvanced";
			this.btnAdvanced.TabIndex = 10;
			this.btnAdvanced.Text = "&More >>";
			this.btnAdvanced.Click += new global::System.EventHandler(this.btnAdvanced_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(193, 392);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.TabIndex = 14;
			this.btnHelp.Text = "&Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(105, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(17, 392);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.grpLegend.Controls.Add(this.lblIntlPrices);
			this.grpLegend.Controls.Add(this.picIntlLegend);
			this.grpLegend.Controls.Add(this.lblCurrentCost);
			this.grpLegend.Controls.Add(this.lblCompetitorPrices);
			this.grpLegend.Controls.Add(this.lblYourRecentPrices);
			this.grpLegend.Controls.Add(this.picLegendCanvas);
			this.grpLegend.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.grpLegend.Location = new global::System.Drawing.Point(16, 280);
			this.grpLegend.Name = "grpLegend";
			this.grpLegend.Size = new global::System.Drawing.Size(256, 64);
			this.grpLegend.TabIndex = 11;
			this.grpLegend.TabStop = false;
			this.grpLegend.Text = "Legend";
			this.lblIntlPrices.AutoSize = true;
			this.lblIntlPrices.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblIntlPrices.ForeColor = global::System.Drawing.Color.DarkViolet;
			this.lblIntlPrices.Location = new global::System.Drawing.Point(8, 56);
			this.lblIntlPrices.Name = "lblIntlPrices";
			this.lblIntlPrices.Size = new global::System.Drawing.Size(86, 14);
			this.lblIntlPrices.TabIndex = 23;
			this.lblIntlPrices.Text = "International Prices";
			this.lblIntlPrices.Visible = false;
			this.picIntlLegend.Location = new global::System.Drawing.Point(8, 72);
			this.picIntlLegend.Name = "picIntlLegend";
			this.picIntlLegend.Size = new global::System.Drawing.Size(240, 16);
			this.picIntlLegend.TabIndex = 24;
			this.picIntlLegend.TabStop = false;
			this.picIntlLegend.Visible = false;
			this.picIntlLegend.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picIntlLegend_Paint);
			this.lblCurrentCost.AutoSize = true;
			this.lblCurrentCost.BackColor = global::System.Drawing.Color.Transparent;
			this.lblCurrentCost.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblCurrentCost.Location = new global::System.Drawing.Point(184, 24);
			this.lblCurrentCost.Name = "lblCurrentCost";
			this.lblCurrentCost.Size = new global::System.Drawing.Size(58, 14);
			this.lblCurrentCost.TabIndex = 2;
			this.lblCurrentCost.Text = "Current Cost";
			this.lblCompetitorPrices.AutoSize = true;
			this.lblCompetitorPrices.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblCompetitorPrices.ForeColor = global::System.Drawing.Color.Green;
			this.lblCompetitorPrices.Location = new global::System.Drawing.Point(96, 24);
			this.lblCompetitorPrices.Name = "lblCompetitorPrices";
			this.lblCompetitorPrices.Size = new global::System.Drawing.Size(80, 14);
			this.lblCompetitorPrices.TabIndex = 1;
			this.lblCompetitorPrices.Text = "Competitor Prices";
			this.lblYourRecentPrices.AutoSize = true;
			this.lblYourRecentPrices.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblYourRecentPrices.ForeColor = global::System.Drawing.Color.Blue;
			this.lblYourRecentPrices.Location = new global::System.Drawing.Point(8, 24);
			this.lblYourRecentPrices.Name = "lblYourRecentPrices";
			this.lblYourRecentPrices.Size = new global::System.Drawing.Size(86, 14);
			this.lblYourRecentPrices.TabIndex = 0;
			this.lblYourRecentPrices.Text = "Your Recent Prices";
			this.picLegendCanvas.Location = new global::System.Drawing.Point(8, 40);
			this.picLegendCanvas.Name = "picLegendCanvas";
			this.picLegendCanvas.Size = new global::System.Drawing.Size(240, 16);
			this.picLegendCanvas.TabIndex = 22;
			this.picLegendCanvas.TabStop = false;
			this.picLegendCanvas.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picLegendCanvas_Paint);
			this.txtMargin.Location = new global::System.Drawing.Point(185, 64);
			this.txtMargin.Name = "txtMargin";
			this.txtMargin.Size = new global::System.Drawing.Size(48, 20);
			this.txtMargin.TabIndex = 6;
			this.txtMargin.Text = "";
			this.txtMargin.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtMargin_Validating);
			this.txtMargin.TextChanged += new global::System.EventHandler(this.txtMargin_TextChanged);
			this.txtMargin.Leave += new global::System.EventHandler(this.txtMargin_Leave);
			this.txtMargin.Enter += new global::System.EventHandler(this.txtMargin_Enter);
			this.sliPrice.LargeChange = 40;
			this.sliPrice.Location = new global::System.Drawing.Point(145, 48);
			this.sliPrice.Maximum = 100;
			this.sliPrice.Name = "sliPrice";
			this.sliPrice.Orientation = global::System.Windows.Forms.Orientation.Vertical;
			this.sliPrice.Size = new global::System.Drawing.Size(45, 192);
			this.sliPrice.SmallChange = 10;
			this.sliPrice.TabIndex = 4;
			this.sliPrice.TickFrequency = 5;
			this.sliPrice.TickStyle = global::System.Windows.Forms.TickStyle.TopLeft;
			this.sliPrice.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.sliPrice_MouseUp);
			this.sliPrice.Scroll += new global::System.EventHandler(this.sliPrice_Scroll);
			this.lblLo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLo.Location = new global::System.Drawing.Point(16, 216);
			this.lblLo.Name = "lblLo";
			this.lblLo.Size = new global::System.Drawing.Size(32, 13);
			this.lblLo.TabIndex = 1;
			this.lblLo.Text = "$0.00";
			this.lblLo.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.lblHi.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblHi.Location = new global::System.Drawing.Point(-8, 56);
			this.lblHi.Name = "lblHi";
			this.lblHi.Size = new global::System.Drawing.Size(56, 13);
			this.lblHi.TabIndex = 0;
			this.lblHi.Text = "$4.50";
			this.lblHi.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.picGraph.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.picGraph.Location = new global::System.Drawing.Point(48, 56);
			this.picGraph.Name = "picGraph";
			this.picGraph.Size = new global::System.Drawing.Size(96, 176);
			this.picGraph.TabIndex = 18;
			this.picGraph.TabStop = false;
			this.picGraph.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
			this.grpMarginExplanation.Controls.Add(this.lblMarginDefinition);
			this.grpMarginExplanation.Location = new global::System.Drawing.Point(184, 88);
			this.grpMarginExplanation.Name = "grpMarginExplanation";
			this.grpMarginExplanation.Size = new global::System.Drawing.Size(88, 144);
			this.grpMarginExplanation.TabIndex = 8;
			this.grpMarginExplanation.TabStop = false;
			this.grpMarginExplanation.Text = "Margin";
			this.lblMarginDefinition.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMarginDefinition.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblMarginDefinition.Location = new global::System.Drawing.Point(8, 16);
			this.lblMarginDefinition.Name = "lblMarginDefinition";
			this.lblMarginDefinition.Size = new global::System.Drawing.Size(64, 120);
			this.lblMarginDefinition.TabIndex = 0;
			this.lblMarginDefinition.Text = "Margin is the difference between the amount you buy a product for and what you sell it for.  It is how much you make on each unit you sell.";
			this.lblGlobalPercentage.AutoSize = true;
			this.lblGlobalPercentage.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblGlobalPercentage.Location = new global::System.Drawing.Point(24, 256);
			this.lblGlobalPercentage.Name = "lblGlobalPercentage";
			this.lblGlobalPercentage.Size = new global::System.Drawing.Size(142, 16);
			this.lblGlobalPercentage.TabIndex = 9;
			this.lblGlobalPercentage.Text = "50.5% of Competitor Prices";
			this.lblLastWeeks.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLastWeeks.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblLastWeeks.Location = new global::System.Drawing.Point(56, 232);
			this.lblLastWeeks.Name = "lblLastWeeks";
			this.lblLastWeeks.Size = new global::System.Drawing.Size(88, 16);
			this.lblLastWeeks.TabIndex = 3;
			this.lblLastWeeks.Text = "Last Weeks";
			this.lblLastWeeks.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblPoints2.AutoSize = true;
			this.lblPoints2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblPoints2.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblPoints2.Location = new global::System.Drawing.Point(240, 152);
			this.lblPoints2.Name = "lblPoints2";
			this.lblPoints2.Size = new global::System.Drawing.Size(16, 14);
			this.lblPoints2.TabIndex = 21;
			this.lblPoints2.Text = "pts";
			this.lblPoints2.Visible = false;
			this.labIntlMarginPoints.Location = new global::System.Drawing.Point(184, 96);
			this.labIntlMarginPoints.Name = "labIntlMarginPoints";
			this.labIntlMarginPoints.Size = new global::System.Drawing.Size(77, 40);
			this.labIntlMarginPoints.TabIndex = 19;
			this.labIntlMarginPoints.Text = "&International Margin Points:";
			this.labIntlMarginPoints.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.labIntlMarginPoints.Visible = false;
			this.txtIntlMargin.Location = new global::System.Drawing.Point(184, 144);
			this.txtIntlMargin.Name = "txtIntlMargin";
			this.txtIntlMargin.Size = new global::System.Drawing.Size(48, 20);
			this.txtIntlMargin.TabIndex = 20;
			this.txtIntlMargin.Text = "";
			this.txtIntlMargin.Visible = false;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(758, 424);
			base.Controls.Add(this.lblPoints2);
			base.Controls.Add(this.labIntlMarginPoints);
			base.Controls.Add(this.txtIntlMargin);
			base.Controls.Add(this.lblLastWeeks);
			base.Controls.Add(this.lblGlobalPercentage);
			base.Controls.Add(this.lblPoints);
			base.Controls.Add(this.lblMarginPoints);
			base.Controls.Add(this.lblGraphTitle);
			base.Controls.Add(this.grpMarginExplanation);
			base.Controls.Add(this.grpCustom);
			base.Controls.Add(this.btnAdvanced);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.grpLegend);
			base.Controls.Add(this.txtMargin);
			base.Controls.Add(this.sliPrice);
			base.Controls.Add(this.lblLo);
			base.Controls.Add(this.lblHi);
			base.Controls.Add(this.picGraph);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmPricing";
			base.ShowInTaskbar = false;
			this.Text = "Pricing";
			base.Load += new global::System.EventHandler(this.Form_Load);
			this.grpCustom.ResumeLayout(false);
			this.grpLegend.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.sliPrice).EndInit();
			this.grpMarginExplanation.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400015F RID: 351
		private global::System.Windows.Forms.Label lblPoints;

		// Token: 0x04000160 RID: 352
		private global::System.Windows.Forms.Label lblMarginPoints;

		// Token: 0x04000161 RID: 353
		private global::System.Windows.Forms.Label lblGraphTitle;

		// Token: 0x04000162 RID: 354
		private global::System.Windows.Forms.GroupBox grpCustom;

		// Token: 0x04000163 RID: 355
		private global::System.Windows.Forms.Label lblInstructions;

		// Token: 0x04000164 RID: 356
		private global::System.Windows.Forms.Button btnAdvanced;

		// Token: 0x04000165 RID: 357
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000166 RID: 358
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000167 RID: 359
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000168 RID: 360
		private global::System.Windows.Forms.GroupBox grpLegend;

		// Token: 0x04000169 RID: 361
		private global::System.Windows.Forms.TextBox txtMargin;

		// Token: 0x0400016A RID: 362
		private global::System.Windows.Forms.Label lblLo;

		// Token: 0x0400016B RID: 363
		private global::System.Windows.Forms.Label lblHi;

		// Token: 0x0400016C RID: 364
		private global::System.Windows.Forms.GroupBox grpMarginExplanation;

		// Token: 0x0400016D RID: 365
		private global::System.Windows.Forms.Label lblYourRecentPrices;

		// Token: 0x0400016E RID: 366
		private global::System.Windows.Forms.Label lblCompetitorPrices;

		// Token: 0x0400016F RID: 367
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000170 RID: 368
		private global::System.Windows.Forms.TrackBar sliPrice;

		// Token: 0x04000171 RID: 369
		private global::System.Windows.Forms.Label lblGlobalPercentage;

		// Token: 0x04000172 RID: 370
		private global::System.Windows.Forms.Label lblLastWeeks;

		// Token: 0x04000173 RID: 371
		private global::System.Windows.Forms.Label lblCurrentCost;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.PictureBox picLegendCanvas;

		// Token: 0x04000175 RID: 373
		private global::System.Windows.Forms.Label lblMarginDefinition;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.ToolTip myToolTip;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.Label lblPoints2;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.Label labIntlMarginPoints;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.TextBox txtIntlMargin;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.Label lblIntlPrices;

		// Token: 0x0400017B RID: 379
		private global::System.Windows.Forms.PictureBox picIntlLegend;

		// Token: 0x0400017C RID: 380
		private global::System.Windows.Forms.Panel panCustom;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.PictureBox picGraph;
	}
}
