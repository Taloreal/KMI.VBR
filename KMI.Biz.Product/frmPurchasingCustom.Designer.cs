namespace KMI.Biz.Product
{
	// Token: 0x02000010 RID: 16
	public partial class frmPurchasingCustom : global::System.Windows.Forms.Form
	{
		// Token: 0x0600004D RID: 77 RVA: 0x0000672C File Offset: 0x0000572C
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

		// Token: 0x0600004E RID: 78 RVA: 0x00006768 File Offset: 0x00005768
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.lblUnits3 = new global::System.Windows.Forms.Label();
			this.lblUnits2 = new global::System.Windows.Forms.Label();
			this.lblAmountToOrder = new global::System.Windows.Forms.Label();
			this.lblUnits1 = new global::System.Windows.Forms.Label();
			this.lblGraphTitle = new global::System.Windows.Forms.Label();
			this.txtBelow = new global::System.Windows.Forms.TextBox();
			this.lblWhenToOrder = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.grpLegend = new global::System.Windows.Forms.GroupBox();
			this.lblAverageDailySales = new global::System.Windows.Forms.Label();
			this.picLegendCanvas = new global::System.Windows.Forms.PictureBox();
			this.txtUnits = new global::System.Windows.Forms.TextBox();
			this.sliAmount = new global::System.Windows.Forms.TrackBar();
			this.lblLo = new global::System.Windows.Forms.Label();
			this.lblHi = new global::System.Windows.Forms.Label();
			this.picBarGraph = new global::System.Windows.Forms.PictureBox();
			this.myToolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.btnDiscard = new global::System.Windows.Forms.Button();
			this.grpLegend.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picLegendCanvas).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.sliAmount).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.picBarGraph).BeginInit();
			base.SuspendLayout();
			this.lblUnits3.AutoSize = true;
			this.lblUnits3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblUnits3.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblUnits3.Location = new global::System.Drawing.Point(240, 153);
			this.lblUnits3.Name = "lblUnits3";
			this.lblUnits3.Size = new global::System.Drawing.Size(30, 13);
			this.lblUnits3.TabIndex = 10;
			this.lblUnits3.Text = "Units";
			this.lblUnits2.AutoSize = true;
			this.lblUnits2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblUnits2.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblUnits2.Location = new global::System.Drawing.Point(219, 233);
			this.lblUnits2.Name = "lblUnits2";
			this.lblUnits2.Size = new global::System.Drawing.Size(30, 13);
			this.lblUnits2.TabIndex = 7;
			this.lblUnits2.Text = "Units";
			this.lblUnits2.Visible = false;
			this.lblAmountToOrder.Location = new global::System.Drawing.Point(184, 113);
			this.lblAmountToOrder.Name = "lblAmountToOrder";
			this.lblAmountToOrder.Size = new global::System.Drawing.Size(91, 34);
			this.lblAmountToOrder.TabIndex = 5;
			this.lblAmountToOrder.Text = "&Target Inventory Level:";
			this.lblUnits1.AutoSize = true;
			this.lblUnits1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblUnits1.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblUnits1.Location = new global::System.Drawing.Point(8, 168);
			this.lblUnits1.Name = "lblUnits1";
			this.lblUnits1.Size = new global::System.Drawing.Size(30, 13);
			this.lblUnits1.TabIndex = 2;
			this.lblUnits1.Text = "Units";
			this.lblGraphTitle.AutoSize = true;
			this.lblGraphTitle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblGraphTitle.Location = new global::System.Drawing.Point(33, 64);
			this.lblGraphTitle.Name = "lblGraphTitle";
			this.lblGraphTitle.Size = new global::System.Drawing.Size(136, 13);
			this.lblGraphTitle.TabIndex = 0;
			this.lblGraphTitle.Text = "Target Inventory Level";
			this.txtBelow.Location = new global::System.Drawing.Point(187, 252);
			this.txtBelow.Name = "txtBelow";
			this.txtBelow.Size = new global::System.Drawing.Size(48, 20);
			this.txtBelow.TabIndex = 9;
			this.txtBelow.Visible = false;
			this.txtBelow.TextChanged += new global::System.EventHandler(this.txtBelow_TextChanged);
			this.txtBelow.Enter += new global::System.EventHandler(this.txtBelow_Enter);
			this.txtBelow.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtBelow_Validating);
			this.lblWhenToOrder.Location = new global::System.Drawing.Point(195, 252);
			this.lblWhenToOrder.Name = "lblWhenToOrder";
			this.lblWhenToOrder.Size = new global::System.Drawing.Size(88, 32);
			this.lblWhenToOrder.TabIndex = 8;
			this.lblWhenToOrder.Text = "&When Inventory Falls Below:";
			this.lblWhenToOrder.Visible = false;
			this.btnHelp.Location = new global::System.Drawing.Point(192, 392);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 15;
			this.btnHelp.Text = "&Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(104, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.Location = new global::System.Drawing.Point(16, 392);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
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
			this.txtUnits.Location = new global::System.Drawing.Point(187, 147);
			this.txtUnits.Name = "txtUnits";
			this.txtUnits.Size = new global::System.Drawing.Size(48, 20);
			this.txtUnits.TabIndex = 6;
			this.txtUnits.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.txtUnits.TextChanged += new global::System.EventHandler(this.txtUnits_TextChanged);
			this.txtUnits.Enter += new global::System.EventHandler(this.txtUnits_Enter);
			this.txtUnits.Validating += new global::System.ComponentModel.CancelEventHandler(this.txtUnits_Validating);
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
			this.sliAmount.Scroll += new global::System.EventHandler(this.sliAmount_Scroll);
			this.sliAmount.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.sliAmount_MouseUp);
			this.lblLo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLo.Location = new global::System.Drawing.Point(8, 248);
			this.lblLo.Name = "lblLo";
			this.lblLo.Size = new global::System.Drawing.Size(32, 13);
			this.lblLo.TabIndex = 3;
			this.lblLo.Text = "0";
			this.lblLo.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.lblHi.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblHi.Location = new global::System.Drawing.Point(8, 88);
			this.lblHi.Name = "lblHi";
			this.lblHi.Size = new global::System.Drawing.Size(32, 13);
			this.lblHi.TabIndex = 1;
			this.lblHi.Text = "100";
			this.lblHi.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.picBarGraph.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.picBarGraph.Location = new global::System.Drawing.Point(40, 88);
			this.picBarGraph.Name = "picBarGraph";
			this.picBarGraph.Size = new global::System.Drawing.Size(104, 176);
			this.picBarGraph.TabIndex = 17;
			this.picBarGraph.TabStop = false;
			this.picBarGraph.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picBarGraph_Paint);
			this.btnDiscard.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.btnDiscard.Location = new global::System.Drawing.Point(192, 296);
			this.btnDiscard.Name = "btnDiscard";
			this.btnDiscard.Size = new global::System.Drawing.Size(75, 64);
			this.btnDiscard.TabIndex = 12;
			this.btnDiscard.Text = "Discard All";
			this.btnDiscard.Click += new global::System.EventHandler(this.btnDiscard_Click);
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(288, 426);
			base.Controls.Add(this.btnDiscard);
			base.Controls.Add(this.lblUnits3);
			base.Controls.Add(this.lblUnits2);
			base.Controls.Add(this.lblAmountToOrder);
			base.Controls.Add(this.lblUnits1);
			base.Controls.Add(this.lblGraphTitle);
			base.Controls.Add(this.txtBelow);
			base.Controls.Add(this.lblWhenToOrder);
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
			base.Name = "frmPurchasingCustom";
			base.ShowInTaskbar = false;
			this.Text = "Custom Purchasing";
			base.Load += new global::System.EventHandler(this.Form_Load);
			this.grpLegend.ResumeLayout(false);
			this.grpLegend.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.picLegendCanvas).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.sliAmount).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.picBarGraph).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Label lblUnits3;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.Label lblUnits2;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.Label lblAmountToOrder;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Label lblUnits1;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Label lblGraphTitle;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.TextBox txtBelow;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.Label lblWhenToOrder;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.GroupBox grpLegend;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.Label lblAverageDailySales;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.PictureBox picLegendCanvas;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.TextBox txtUnits;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.TrackBar sliAmount;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Label lblLo;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.Label lblHi;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.PictureBox picBarGraph;

		// Token: 0x040000A0 RID: 160
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.Button btnDiscard;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.ToolTip myToolTip;
	}
}
