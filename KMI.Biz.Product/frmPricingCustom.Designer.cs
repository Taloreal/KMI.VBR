namespace KMI.Biz.Product
{
	// Token: 0x0200000D RID: 13
	public partial class frmPricingCustom : global::System.Windows.Forms.Form
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00003FCC File Offset: 0x00002FCC
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

		// Token: 0x06000033 RID: 51 RVA: 0x00004008 File Offset: 0x00003008
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.myToolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.lblLastWeeks = new global::System.Windows.Forms.Label();
			this.lblGlobalPercentage = new global::System.Windows.Forms.Label();
			this.grpMarginExplanation = new global::System.Windows.Forms.GroupBox();
			this.lblMarginDefinition = new global::System.Windows.Forms.Label();
			this.lblPoints = new global::System.Windows.Forms.Label();
			this.lblMarginPoints = new global::System.Windows.Forms.Label();
			this.lblGraphTitle = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.grpLegend = new global::System.Windows.Forms.GroupBox();
			this.lblCurrentCost = new global::System.Windows.Forms.Label();
			this.lblCompetitorPrices = new global::System.Windows.Forms.Label();
			this.lblYourRecentPrices = new global::System.Windows.Forms.Label();
			this.picLegendCanvas = new global::System.Windows.Forms.PictureBox();
			this.txtMargin = new global::System.Windows.Forms.TextBox();
			this.sliPrice = new global::System.Windows.Forms.TrackBar();
			this.lblLo = new global::System.Windows.Forms.Label();
			this.lblHi = new global::System.Windows.Forms.Label();
			this.picGraph = new global::System.Windows.Forms.PictureBox();
			this.labYourCost = new global::System.Windows.Forms.Label();
			this.labYourPrice = new global::System.Windows.Forms.Label();
			this.labYourPriceValue = new global::System.Windows.Forms.Label();
			this.labYourCostValue = new global::System.Windows.Forms.Label();
			this.grpMarginExplanation.SuspendLayout();
			this.grpLegend.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.sliPrice).BeginInit();
			base.SuspendLayout();
			this.lblLastWeeks.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLastWeeks.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblLastWeeks.Location = new global::System.Drawing.Point(56, 232);
			this.lblLastWeeks.Name = "lblLastWeeks";
			this.lblLastWeeks.Size = new global::System.Drawing.Size(88, 16);
			this.lblLastWeeks.TabIndex = 8;
			this.lblLastWeeks.Text = "Last Weeks";
			this.lblLastWeeks.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblGlobalPercentage.AutoSize = true;
			this.lblGlobalPercentage.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblGlobalPercentage.Location = new global::System.Drawing.Point(24, 288);
			this.lblGlobalPercentage.Name = "lblGlobalPercentage";
			this.lblGlobalPercentage.Size = new global::System.Drawing.Size(150, 16);
			this.lblGlobalPercentage.TabIndex = 9;
			this.lblGlobalPercentage.Text = "50.5% of Competitor's Prices";
			this.grpMarginExplanation.Controls.Add(this.lblMarginDefinition);
			this.grpMarginExplanation.Location = new global::System.Drawing.Point(184, 88);
			this.grpMarginExplanation.Name = "grpMarginExplanation";
			this.grpMarginExplanation.Size = new global::System.Drawing.Size(88, 144);
			this.grpMarginExplanation.TabIndex = 6;
			this.grpMarginExplanation.TabStop = false;
			this.grpMarginExplanation.Text = "Margin";
			this.lblMarginDefinition.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMarginDefinition.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblMarginDefinition.Location = new global::System.Drawing.Point(8, 16);
			this.lblMarginDefinition.Name = "lblMarginDefinition";
			this.lblMarginDefinition.Size = new global::System.Drawing.Size(64, 120);
			this.lblMarginDefinition.TabIndex = 0;
			this.lblMarginDefinition.Text = "Margin is the difference between the amount you buy a product for and what you sell it for.  It is how much you make on each unit you sell.";
			this.lblPoints.AutoSize = true;
			this.lblPoints.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblPoints.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblPoints.Location = new global::System.Drawing.Point(240, 72);
			this.lblPoints.Name = "lblPoints";
			this.lblPoints.Size = new global::System.Drawing.Size(16, 14);
			this.lblPoints.TabIndex = 5;
			this.lblPoints.Text = "pts";
			this.lblMarginPoints.AutoSize = true;
			this.lblMarginPoints.Location = new global::System.Drawing.Point(184, 40);
			this.lblMarginPoints.Name = "lblMarginPoints";
			this.lblMarginPoints.Size = new global::System.Drawing.Size(77, 16);
			this.lblMarginPoints.TabIndex = 3;
			this.lblMarginPoints.Text = "Margin &Points:";
			this.lblGraphTitle.AutoSize = true;
			this.lblGraphTitle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblGraphTitle.Location = new global::System.Drawing.Point(72, 32);
			this.lblGraphTitle.Name = "lblGraphTitle";
			this.lblGraphTitle.Size = new global::System.Drawing.Size(52, 16);
			this.lblGraphTitle.TabIndex = 0;
			this.lblGraphTitle.Text = "Set Price";
			this.btnHelp.Location = new global::System.Drawing.Point(192, 392);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.TabIndex = 13;
			this.btnHelp.Text = "&Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(104, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(16, 392);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.grpLegend.Controls.Add(this.lblCurrentCost);
			this.grpLegend.Controls.Add(this.lblCompetitorPrices);
			this.grpLegend.Controls.Add(this.lblYourRecentPrices);
			this.grpLegend.Controls.Add(this.picLegendCanvas);
			this.grpLegend.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.grpLegend.Location = new global::System.Drawing.Point(16, 312);
			this.grpLegend.Name = "grpLegend";
			this.grpLegend.Size = new global::System.Drawing.Size(256, 64);
			this.grpLegend.TabIndex = 10;
			this.grpLegend.TabStop = false;
			this.grpLegend.Text = "Legend";
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
			this.txtMargin.Location = new global::System.Drawing.Point(184, 64);
			this.txtMargin.Name = "txtMargin";
			this.txtMargin.Size = new global::System.Drawing.Size(48, 20);
			this.txtMargin.TabIndex = 4;
			this.txtMargin.Text = "";
			this.txtMargin.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtMargin_Validating);
			this.txtMargin.TextChanged += new global::System.EventHandler(this.txtMargin_TextChanged);
			this.txtMargin.Leave += new global::System.EventHandler(this.txtMargin_Leave);
			this.txtMargin.Enter += new global::System.EventHandler(this.txtMargin_Enter);
			this.sliPrice.LargeChange = 40;
			this.sliPrice.Location = new global::System.Drawing.Point(144, 48);
			this.sliPrice.Maximum = 100;
			this.sliPrice.Name = "sliPrice";
			this.sliPrice.Orientation = global::System.Windows.Forms.Orientation.Vertical;
			this.sliPrice.Size = new global::System.Drawing.Size(45, 192);
			this.sliPrice.SmallChange = 10;
			this.sliPrice.TabIndex = 2;
			this.sliPrice.TickFrequency = 5;
			this.sliPrice.TickStyle = global::System.Windows.Forms.TickStyle.TopLeft;
			this.sliPrice.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.sliPrice_MouseUp);
			this.sliPrice.Scroll += new global::System.EventHandler(this.sliPrice_Scroll);
			this.lblLo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLo.Location = new global::System.Drawing.Point(16, 216);
			this.lblLo.Name = "lblLo";
			this.lblLo.Size = new global::System.Drawing.Size(32, 13);
			this.lblLo.TabIndex = 7;
			this.lblLo.Text = "$0.00";
			this.lblLo.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.lblHi.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblHi.Location = new global::System.Drawing.Point(-8, 56);
			this.lblHi.Name = "lblHi";
			this.lblHi.Size = new global::System.Drawing.Size(56, 13);
			this.lblHi.TabIndex = 1;
			this.lblHi.Text = "$4.50";
			this.lblHi.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.picGraph.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.picGraph.Location = new global::System.Drawing.Point(48, 56);
			this.picGraph.Name = "picGraph";
			this.picGraph.Size = new global::System.Drawing.Size(96, 176);
			this.picGraph.TabIndex = 40;
			this.picGraph.TabStop = false;
			this.picGraph.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
			this.labYourCost.AutoSize = true;
			this.labYourCost.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.labYourCost.Location = new global::System.Drawing.Point(24, 272);
			this.labYourCost.Name = "labYourCost";
			this.labYourCost.Size = new global::System.Drawing.Size(58, 16);
			this.labYourCost.TabIndex = 41;
			this.labYourCost.Text = "Your Cost:";
			this.labYourPrice.AutoSize = true;
			this.labYourPrice.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.labYourPrice.Location = new global::System.Drawing.Point(24, 256);
			this.labYourPrice.Name = "labYourPrice";
			this.labYourPrice.Size = new global::System.Drawing.Size(60, 16);
			this.labYourPrice.TabIndex = 42;
			this.labYourPrice.Text = "Your Price:";
			this.labYourPriceValue.AutoSize = true;
			this.labYourPriceValue.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.labYourPriceValue.Location = new global::System.Drawing.Point(112, 256);
			this.labYourPriceValue.Name = "labYourPriceValue";
			this.labYourPriceValue.Size = new global::System.Drawing.Size(31, 16);
			this.labYourPriceValue.TabIndex = 44;
			this.labYourPriceValue.Text = "$x.xx";
			this.labYourPriceValue.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labYourCostValue.AutoSize = true;
			this.labYourCostValue.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.labYourCostValue.Location = new global::System.Drawing.Point(112, 272);
			this.labYourCostValue.Name = "labYourCostValue";
			this.labYourCostValue.Size = new global::System.Drawing.Size(31, 16);
			this.labYourCostValue.TabIndex = 43;
			this.labYourCostValue.Text = "$x.xx";
			this.labYourCostValue.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(288, 426);
			base.Controls.Add(this.labYourPriceValue);
			base.Controls.Add(this.labYourCostValue);
			base.Controls.Add(this.labYourPrice);
			base.Controls.Add(this.labYourCost);
			base.Controls.Add(this.lblLastWeeks);
			base.Controls.Add(this.lblGlobalPercentage);
			base.Controls.Add(this.lblPoints);
			base.Controls.Add(this.lblMarginPoints);
			base.Controls.Add(this.lblGraphTitle);
			base.Controls.Add(this.txtMargin);
			base.Controls.Add(this.grpMarginExplanation);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.grpLegend);
			base.Controls.Add(this.sliPrice);
			base.Controls.Add(this.lblLo);
			base.Controls.Add(this.lblHi);
			base.Controls.Add(this.picGraph);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmPricingCustom";
			base.ShowInTaskbar = false;
			this.Text = "Custom Pricing";
			base.Load += new global::System.EventHandler(this.Form_Load);
			this.grpMarginExplanation.ResumeLayout(false);
			this.grpLegend.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.sliPrice).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Label labYourCost;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label labYourPrice;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Label labYourPriceValue;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label labYourCostValue;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.Label lblMarginDefinition;

		// Token: 0x0400005E RID: 94
		private global::System.Windows.Forms.Label lblLastWeeks;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.Label lblGlobalPercentage;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.GroupBox grpMarginExplanation;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.Label lblPoints;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.Label lblMarginPoints;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.Label lblGraphTitle;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.GroupBox grpLegend;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.Label lblCurrentCost;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Label lblCompetitorPrices;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.Label lblYourRecentPrices;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.PictureBox picLegendCanvas;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.TextBox txtMargin;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.TrackBar sliPrice;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.Label lblLo;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.Label lblHi;

		// Token: 0x04000070 RID: 112
		private global::System.Windows.Forms.PictureBox picGraph;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.ToolTip myToolTip;

		// Token: 0x04000072 RID: 114
		private global::System.ComponentModel.IContainer components;
	}
}
