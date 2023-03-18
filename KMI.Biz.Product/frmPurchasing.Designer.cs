namespace KMI.Biz.Product
{
	// Token: 0x0200001B RID: 27
	public partial class frmPurchasing : global::System.Windows.Forms.Form
	{
		// Token: 0x060000C0 RID: 192 RVA: 0x0000BBD4 File Offset: 0x0000ABD4
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

		// Token: 0x060000C1 RID: 193 RVA: 0x0000BC10 File Offset: 0x0000AC10
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.picBarGraph = new global::System.Windows.Forms.PictureBox();
			this.lblGraphTitle = new global::System.Windows.Forms.Label();
			this.lblHi = new global::System.Windows.Forms.Label();
			this.lblLo = new global::System.Windows.Forms.Label();
			this.lblUnits1 = new global::System.Windows.Forms.Label();
			this.sliAmount = new global::System.Windows.Forms.TrackBar();
			this.lblAmountToOrder = new global::System.Windows.Forms.Label();
			this.txtUnits = new global::System.Windows.Forms.TextBox();
			this.lblUnits2 = new global::System.Windows.Forms.Label();
			this.grpLegend = new global::System.Windows.Forms.GroupBox();
			this.lblAverageDailySales = new global::System.Windows.Forms.Label();
			this.picLegendCanvas = new global::System.Windows.Forms.PictureBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnAdvanced = new global::System.Windows.Forms.Button();
			this.grpCustom = new global::System.Windows.Forms.GroupBox();
			this.panCustom = new global::System.Windows.Forms.Panel();
			this.lblInstructions = new global::System.Windows.Forms.Label();
			this.myToolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.lblWhenToOrder = new global::System.Windows.Forms.Label();
			this.txtBelow = new global::System.Windows.Forms.TextBox();
			this.lblUnits3 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.picBarGraph).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.sliAmount).BeginInit();
			this.grpLegend.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picLegendCanvas).BeginInit();
			this.grpCustom.SuspendLayout();
			base.SuspendLayout();
			this.picBarGraph.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.picBarGraph.Location = new global::System.Drawing.Point(40, 88);
			this.picBarGraph.Name = "picBarGraph";
			this.picBarGraph.Size = new global::System.Drawing.Size(104, 176);
			this.picBarGraph.TabIndex = 0;
			this.picBarGraph.TabStop = false;
			this.picBarGraph.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picBarGraph_Paint);
			this.lblGraphTitle.AutoSize = true;
			this.lblGraphTitle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblGraphTitle.Location = new global::System.Drawing.Point(33, 64);
			this.lblGraphTitle.Name = "lblGraphTitle";
			this.lblGraphTitle.Size = new global::System.Drawing.Size(136, 13);
			this.lblGraphTitle.TabIndex = 0;
			this.lblGraphTitle.Text = "Target Inventory Level";
			this.lblHi.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblHi.Location = new global::System.Drawing.Point(8, 88);
			this.lblHi.Name = "lblHi";
			this.lblHi.Size = new global::System.Drawing.Size(32, 13);
			this.lblHi.TabIndex = 1;
			this.lblHi.Text = "100";
			this.lblHi.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.lblLo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLo.Location = new global::System.Drawing.Point(8, 248);
			this.lblLo.Name = "lblLo";
			this.lblLo.Size = new global::System.Drawing.Size(32, 13);
			this.lblLo.TabIndex = 3;
			this.lblLo.Text = "0";
			this.lblLo.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.lblUnits1.AutoSize = true;
			this.lblUnits1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblUnits1.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblUnits1.Location = new global::System.Drawing.Point(8, 168);
			this.lblUnits1.Name = "lblUnits1";
			this.lblUnits1.Size = new global::System.Drawing.Size(30, 13);
			this.lblUnits1.TabIndex = 2;
			this.lblUnits1.Text = "Units";
			this.sliAmount.LargeChange = 40;
			this.sliAmount.Location = new global::System.Drawing.Point(144, 80);
			this.sliAmount.Maximum = 1000;
			this.sliAmount.Name = "sliAmount";
			this.sliAmount.Orientation = global::System.Windows.Forms.Orientation.Vertical;
			this.sliAmount.Size = new global::System.Drawing.Size(45, 192);
			this.sliAmount.SmallChange = 10;
			this.sliAmount.TabIndex = 4;
			this.sliAmount.TickFrequency = 40;
			this.sliAmount.TickStyle = global::System.Windows.Forms.TickStyle.TopLeft;
			this.sliAmount.Scroll += new global::System.EventHandler(this.SliAmount_Scroll);
			this.sliAmount.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.sliAmount_MouseUp);
			this.lblAmountToOrder.Location = new global::System.Drawing.Point(184, 111);
			this.lblAmountToOrder.Name = "lblAmountToOrder";
			this.lblAmountToOrder.Size = new global::System.Drawing.Size(90, 31);
			this.lblAmountToOrder.TabIndex = 5;
			this.lblAmountToOrder.Text = "&Target Inventory Level:";
			this.txtUnits.Location = new global::System.Drawing.Point(187, 145);
			this.txtUnits.Name = "txtUnits";
			this.txtUnits.Size = new global::System.Drawing.Size(48, 20);
			this.txtUnits.TabIndex = 6;
			this.txtUnits.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.txtUnits.TextChanged += new global::System.EventHandler(this.txtUnits_TextChanged);
			this.txtUnits.Enter += new global::System.EventHandler(this.txtUnits_Enter);
			this.txtUnits.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtUnits_Validating);
			this.lblUnits2.AutoSize = true;
			this.lblUnits2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblUnits2.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblUnits2.Location = new global::System.Drawing.Point(202, 280);
			this.lblUnits2.Name = "lblUnits2";
			this.lblUnits2.Size = new global::System.Drawing.Size(30, 13);
			this.lblUnits2.TabIndex = 7;
			this.lblUnits2.Text = "Units";
			this.lblUnits2.Visible = false;
			this.grpLegend.Controls.Add(this.lblAverageDailySales);
			this.grpLegend.Controls.Add(this.picLegendCanvas);
			this.grpLegend.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.grpLegend.Location = new global::System.Drawing.Point(40, 288);
			this.grpLegend.Name = "grpLegend";
			this.grpLegend.Size = new global::System.Drawing.Size(128, 72);
			this.grpLegend.TabIndex = 11;
			this.grpLegend.TabStop = false;
			this.grpLegend.Text = "Legend";
			this.lblAverageDailySales.AutoSize = true;
			this.lblAverageDailySales.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblAverageDailySales.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblAverageDailySales.Location = new global::System.Drawing.Point(16, 24);
			this.lblAverageDailySales.Name = "lblAverageDailySales";
			this.lblAverageDailySales.Size = new global::System.Drawing.Size(102, 13);
			this.lblAverageDailySales.TabIndex = 0;
			this.lblAverageDailySales.Text = "Average Daily Sales";
			this.picLegendCanvas.Location = new global::System.Drawing.Point(8, 40);
			this.picLegendCanvas.Name = "picLegendCanvas";
			this.picLegendCanvas.Size = new global::System.Drawing.Size(112, 16);
			this.picLegendCanvas.TabIndex = 22;
			this.picLegendCanvas.TabStop = false;
			this.picLegendCanvas.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picLegendCanvas_Paint);
			this.btnOK.Location = new global::System.Drawing.Point(16, 392);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(104, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnHelp.Location = new global::System.Drawing.Point(192, 392);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 15;
			this.btnHelp.Text = "&Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnAdvanced.Location = new global::System.Drawing.Point(192, 336);
			this.btnAdvanced.Name = "btnAdvanced";
			this.btnAdvanced.Size = new global::System.Drawing.Size(75, 23);
			this.btnAdvanced.TabIndex = 12;
			this.btnAdvanced.Text = "&More >>";
			this.btnAdvanced.Click += new global::System.EventHandler(this.btnAdvanced_Click);
			this.grpCustom.Controls.Add(this.panCustom);
			this.grpCustom.Controls.Add(this.lblInstructions);
			this.grpCustom.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.grpCustom.Location = new global::System.Drawing.Point(280, 8);
			this.grpCustom.Name = "grpCustom";
			this.grpCustom.Size = new global::System.Drawing.Size(472, 408);
			this.grpCustom.TabIndex = 16;
			this.grpCustom.TabStop = false;
			this.grpCustom.Text = "Custom Policies";
			this.panCustom.AutoScroll = true;
			this.panCustom.Location = new global::System.Drawing.Point(2, 44);
			this.panCustom.Name = "panCustom";
			this.panCustom.Size = new global::System.Drawing.Size(462, 356);
			this.panCustom.TabIndex = 2;
			this.lblInstructions.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblInstructions.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblInstructions.Location = new global::System.Drawing.Point(16, 16);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Size = new global::System.Drawing.Size(288, 24);
			this.lblInstructions.TabIndex = 0;
			this.lblInstructions.Text = "Check off each product you want to custom order, or click on the product name to set an amount.";
			this.lblWhenToOrder.Location = new global::System.Drawing.Point(195, 248);
			this.lblWhenToOrder.Name = "lblWhenToOrder";
			this.lblWhenToOrder.Size = new global::System.Drawing.Size(88, 32);
			this.lblWhenToOrder.TabIndex = 8;
			this.lblWhenToOrder.Text = "&When Inventory Falls Below:";
			this.lblWhenToOrder.Visible = false;
			this.txtBelow.Location = new global::System.Drawing.Point(174, 283);
			this.txtBelow.Name = "txtBelow";
			this.txtBelow.Size = new global::System.Drawing.Size(48, 20);
			this.txtBelow.TabIndex = 9;
			this.txtBelow.Visible = false;
			this.txtBelow.TextChanged += new global::System.EventHandler(this.txtBelow_TextChanged);
			this.txtBelow.Enter += new global::System.EventHandler(this.txtBelow_Enter);
			this.txtBelow.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtBelow_Validating);
			this.lblUnits3.AutoSize = true;
			this.lblUnits3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblUnits3.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblUnits3.Location = new global::System.Drawing.Point(236, 152);
			this.lblUnits3.Name = "lblUnits3";
			this.lblUnits3.Size = new global::System.Drawing.Size(30, 13);
			this.lblUnits3.TabIndex = 10;
			this.lblUnits3.Text = "Units";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(758, 424);
			base.Controls.Add(this.lblUnits3);
			base.Controls.Add(this.lblUnits2);
			base.Controls.Add(this.lblAmountToOrder);
			base.Controls.Add(this.lblUnits1);
			base.Controls.Add(this.lblGraphTitle);
			base.Controls.Add(this.txtBelow);
			base.Controls.Add(this.lblWhenToOrder);
			base.Controls.Add(this.grpCustom);
			base.Controls.Add(this.btnAdvanced);
			base.Controls.Add(this.btnHelp);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.grpLegend);
			base.Controls.Add(this.txtUnits);
			base.Controls.Add(this.sliAmount);
			base.Controls.Add(this.lblLo);
			base.Controls.Add(this.lblHi);
			base.Controls.Add(this.picBarGraph);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmPurchasing";
			base.ShowInTaskbar = false;
			this.Text = "Purchasing";
			base.Load += new global::System.EventHandler(this.Form_Load);
			((global::System.ComponentModel.ISupportInitialize)this.picBarGraph).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.sliAmount).EndInit();
			this.grpLegend.ResumeLayout(false);
			this.grpLegend.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picLegendCanvas).EndInit();
			this.grpCustom.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.Panel panCustom;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.PictureBox picBarGraph;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.Label lblGraphTitle;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.Label lblHi;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.Label lblLo;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.TrackBar sliAmount;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.GroupBox grpLegend;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.Button btnAdvanced;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.Label lblAmountToOrder;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.TextBox txtUnits;

		// Token: 0x0400011A RID: 282
		private global::System.Windows.Forms.Label lblAverageDailySales;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.GroupBox grpCustom;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.Label lblInstructions;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.PictureBox picLegendCanvas;

		// Token: 0x0400011E RID: 286
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.Label lblUnits1;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Label lblUnits2;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Label lblWhenToOrder;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.TextBox txtBelow;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.Label lblUnits3;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.ToolTip myToolTip;
	}
}
