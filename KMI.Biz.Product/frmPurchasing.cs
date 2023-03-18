using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x0200001B RID: 27
	public partial class frmPurchasing : Form
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x0000B284 File Offset: 0x0000A284
		public frmPurchasing()
		{
			this.InitForm();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000B2A0 File Offset: 0x0000A2A0
		public frmPurchasing(ProductType[] productTypes, int productTypeIndex, int maxPurchasingUnits)
		{
			this.productTypes = productTypes;
			this.maxPurchasingUnits = maxPurchasingUnits;
			this.InitForm();
			if (productTypeIndex != -1)
			{
				this.Customize(productTypeIndex);
				this.exitAfterCustomProduct = true;
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000B2EC File Offset: 0x0000A2EC
		public void InitForm()
		{
			this.InitializeComponent();
			this.chkCustom = new ControlArray(this);
			this.lblProductImage = new ControlArray(this);
			this.lblProductName = new ControlArray(this);
			this.lblAmount = new ControlArray(this);
			this.lblWhen = new ControlArray(this);
			this.localData = ((IBizProductStateAdapter)S.SA).GetPurchasing(S.MF.CurrentEntityID);
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				frmPurchasing.advanced = (frmPurchasing.advanced || this.localData.PurchasingPolicy.GetCustom(i));
			}
			this.ResizeForm();
			this.InitializeGraphics();
			this.CreateCustomSection();
			this.RegisterEvents();
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				((Label)this.lblProductName[i]).Text = this.productTypes[i].Name;
				((CheckBox)this.chkCustom[i]).Checked = this.localData.PurchasingPolicy.GetCustom(i);
				((Label)this.lblAmount[i]).Text = "Target Level " + this.localData.PurchasingPolicy.GetAmount(i).ToString() + " Units";
			}
			this.txtUnits.Text = this.localData.PurchasingPolicy.GlobalAmount.ToString();
			this.txtBelow.Text = this.localData.PurchasingPolicy.GlobalWhen.ToString();
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000B4A4 File Offset: 0x0000A4A4
		protected void SetAmounts()
		{
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				if (!this.localData.PurchasingPolicy.GetCustom(i))
				{
					((Label)this.lblAmount[i]).Text = "Target Level " + this.localData.PurchasingPolicy.GlobalAmount.ToString() + " Units";
				}
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000B520 File Offset: 0x0000A520
		protected float ComputeAverageDailySales()
		{
			float num = 0f;
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				num += this.localData.AverageDailySales[i];
			}
			return num / (float)this.productTypes.Length;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000B56A File Offset: 0x0000A56A
		protected void InitializeGraphics()
		{
			this.redBrush = new SolidBrush(Color.Red);
			this.darkGrayPen = new Pen(Color.FromArgb(64, 64, 64));
			this.darkGrayPen.DashStyle = DashStyle.Dash;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000B5A0 File Offset: 0x0000A5A0
		protected void ResizeForm()
		{
			if (frmPurchasing.advanced)
			{
				base.Width = 768;
				this.btnAdvanced.Text = "&Less <<";
				this.grpCustom.Enabled = true;
			}
			else
			{
				base.Width = 288;
				this.btnAdvanced.Text = "&More >>";
				this.grpCustom.Enabled = false;
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000B614 File Offset: 0x0000A614
		protected void CreateCustomSection()
		{
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				int left = 16 + i % 3 * 156;
				int top = 4 + i / 3 * 36;
				this.chkCustom.AddNewControl(new CheckBox());
				((CheckBox)this.chkCustom[i]).Name = "chkCustom" + (i + 1).ToString();
				((CheckBox)this.chkCustom[i]).Width = 16;
				((CheckBox)this.chkCustom[i]).Height = 24;
				((CheckBox)this.chkCustom[i]).Text = "";
				((CheckBox)this.chkCustom[i]).Parent = this.panCustom;
				((CheckBox)this.chkCustom[i]).Left = left;
				((CheckBox)this.chkCustom[i]).Top = top;
			}
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				int left = 64 + i % 3 * 156;
				int top = i / 3 * 36;
				this.lblProductName.AddNewControl(new Label());
				((Label)this.lblProductName[i]).Name = "lblProductName" + (i + 1).ToString();
				((Label)this.lblProductName[i]).Cursor = Cursors.Hand;
				((Label)this.lblProductName[i]).ForeColor = Color.Blue;
				((Label)this.lblProductName[i]).AutoSize = true;
				((Label)this.lblProductName[i]).Font = new Font("Microsoft Sans Serif", 7f);
				((Label)this.lblProductName[i]).Parent = this.panCustom;
				((Label)this.lblProductName[i]).Left = left;
				((Label)this.lblProductName[i]).Top = top;
			}
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				int left = 32 + i % 3 * 156;
				int top = i / 3 * 36;
				this.lblProductImage.AddNewControl(new Label());
				((Label)this.lblProductImage[i]).Name = "lblProductImage" + (i + 1).ToString();
				((Label)this.lblProductImage[i]).Cursor = Cursors.Hand;
				((Label)this.lblProductImage[i]).Width = 32;
				((Label)this.lblProductImage[i]).Height = 32;
				((Label)this.lblProductImage[i]).Image = S.R.GetImage(ProductType.ImageBaseName + i);
				((Label)this.lblProductImage[i]).ImageAlign = ContentAlignment.MiddleCenter;
				((Label)this.lblProductImage[i]).Text = "";
				((Label)this.lblProductImage[i]).Parent = this.panCustom;
				((Label)this.lblProductImage[i]).Left = left;
				((Label)this.lblProductImage[i]).Top = top;
			}
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				int left = 64 + i % 3 * 156;
				int top = 12 + i / 3 * 36;
				this.lblAmount.AddNewControl(new Label());
				((Label)this.lblAmount[i]).Name = "lblAmount" + (i + 1).ToString();
				((Label)this.lblAmount[i]).Cursor = Cursors.Hand;
				((Label)this.lblAmount[i]).ForeColor = Color.FromArgb(64, 64, 64);
				((Label)this.lblAmount[i]).AutoSize = true;
				((Label)this.lblAmount[i]).Font = new Font("Microsoft Sans Serif", 7f);
				((Label)this.lblAmount[i]).Parent = this.panCustom;
				((Label)this.lblAmount[i]).Left = left;
				((Label)this.lblAmount[i]).Top = top;
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000BB18 File Offset: 0x0000AB18
		protected void RegisterEvents()
		{
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				((CheckBox)this.chkCustom[i]).Click += this.chkCustom_Click;
				((Label)this.lblProductImage[i]).Click += this.CustomLabels_Click;
				((Label)this.lblProductName[i]).Click += this.CustomLabels_Click;
				((Label)this.lblAmount[i]).Click += this.CustomLabels_Click;
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000CBB4 File Offset: 0x0000BBB4
		private void Form_Load(object sender, EventArgs e)
		{
			if (this.exitAfterCustomProduct)
			{
				base.Close();
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000CBD6 File Offset: 0x0000BBD6
		private void picLegendCanvas_Paint(object sender, PaintEventArgs e)
		{
			this.legend = e.Graphics;
			this.legend.DrawLine(this.darkGrayPen, 16, 8, 86, 8);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000CC00 File Offset: 0x0000BC00
		private void picBarGraph_Paint(object sender, PaintEventArgs e)
		{
			this.barGraph = e.Graphics;
			int height = this.picBarGraph.Height;
			int x = 30;
			int width = 44;
			int num = (int)((float)this.sliAmount.Value / (float)this.sliAmount.Maximum * (float)height);
			int y = height - num;
			int num2 = (int)Math.Max(5f, this.ComputeAverageDailySales() / (float)this.sliAmount.Maximum * (float)height);
			int num3 = height - num2;
			try
			{
				this.barGraph.Clear(SystemColors.Control);
				this.barGraph.FillRectangle(this.redBrush, x, y, width, num);
				this.barGraph.DrawLine(this.darkGrayPen, 0, num3, this.picBarGraph.Width, num3);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000CCE0 File Offset: 0x0000BCE0
		private void CustomLabels_Click(object sender, EventArgs e)
		{
			int index;
			if (this.chkCustom.IndexOf(sender) != -1)
			{
				index = this.chkCustom.IndexOf(sender);
			}
			else if (this.lblProductImage.IndexOf(sender) != -1)
			{
				index = this.lblProductImage.IndexOf(sender);
			}
			else if (this.lblProductName.IndexOf(sender) != -1)
			{
				index = this.lblProductName.IndexOf(sender);
			}
			else if (this.lblAmount.IndexOf(sender) != -1)
			{
				index = this.lblAmount.IndexOf(sender);
			}
			else if (this.lblWhen.IndexOf(sender) != -1)
			{
				index = this.lblWhen.IndexOf(sender);
			}
			else
			{
				index = 0;
			}
			this.Customize(index);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000CDB4 File Offset: 0x0000BDB4
		private void Customize(int index)
		{
			frmPurchasingCustom frmPurchasingCustom = new frmPurchasingCustom(this.productTypes, index, this.maxPurchasingUnits, this.localData.PurchasingPolicy.GetAmount(index), this.localData.PurchasingPolicy.GetWhen(index), this.localData.AverageDailySales[index]);
			if (frmPurchasingCustom.ShowDialog() == DialogResult.OK)
			{
				this.localData.PurchasingPolicy.SetToCustom(index, frmPurchasingCustom.amountToOrder, frmPurchasingCustom.whenToOrder);
				((Label)this.lblAmount[index]).Text = "Target Level " + this.localData.PurchasingPolicy.GetAmount(index).ToString() + " Units";
				((CheckBox)this.chkCustom[index]).Checked = true;
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000CE8C File Offset: 0x0000BE8C
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				((IBizProductStateAdapter)S.SA).SetPurchasing(S.MF.CurrentEntityID, this.localData.PurchasingPolicy);
				base.Close();
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000CEE0 File Offset: 0x0000BEE0
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000CEEA File Offset: 0x0000BEEA
		private void btnAdvanced_Click(object sender, EventArgs e)
		{
			frmPurchasing.advanced = !frmPurchasing.advanced;
			this.ResizeForm();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000CF04 File Offset: 0x0000BF04
		private void chkCustom_Click(object sender, EventArgs e)
		{
			int num = this.chkCustom.IndexOf(sender);
			if (((CheckBox)sender).Checked)
			{
				this.Customize(num);
			}
			else
			{
				this.localData.PurchasingPolicy.SetToGlobal(num);
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000CF54 File Offset: 0x0000BF54
		private void sliAmount_MouseUp(object sender, MouseEventArgs e)
		{
			this.txtUnits.Text = this.sliAmount.Value.ToString();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000CF84 File Offset: 0x0000BF84
		private void SliAmount_Scroll(object sender, EventArgs e)
		{
			this.myToolTip.SetToolTip(this.sliAmount, this.sliAmount.Value + " Units");
			for (int i = 0; i < this.productTypes.Length; i++)
			{
				if (!this.localData.PurchasingPolicy.GetCustom(i))
				{
					((Label)this.lblAmount[i]).Text = this.sliAmount.Value + " Units";
				}
			}
			this.picBarGraph.Refresh();
			if (S.MF.IsWin98)
			{
				base.BringToFront();
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000D044 File Offset: 0x0000C044
		private void txtUnits_TextChanged(object sender, EventArgs e)
		{
			bool flag = false;
			try
			{
				if (long.Parse(this.txtUnits.Text) >= 0L && long.Parse(this.txtUnits.Text) < (long)this.maxPurchasingUnits)
				{
					flag = true;
				}
				else
				{
					this.txtUnits.Text = this.validationString;
					MessageBox.Show("You must enter an amount greater than or equal to 0 and less than " + Utilities.FU(this.maxPurchasingUnits) + ".");
					this.txtUnits.Focus();
					this.txtUnits.SelectAll();
				}
			}
			catch (Exception)
			{
				if (this.txtUnits.Text != "")
				{
					this.txtUnits.Text = this.validationString;
					MessageBox.Show("Please enter a valid numeric expression for your amount.");
					this.txtUnits.Focus();
					this.txtUnits.SelectAll();
				}
			}
			finally
			{
				if (flag)
				{
					this.localData.PurchasingPolicy.GlobalAmount = int.Parse(this.txtUnits.Text);
					this.sliAmount.Maximum = Math.Max(this.localData.PurchasingPolicy.GlobalAmount, 500) + 250;
					this.sliAmount.TickFrequency = this.sliAmount.Maximum / 20;
					this.sliAmount.Value = this.localData.PurchasingPolicy.GlobalAmount;
					this.lblHi.Text = this.sliAmount.Maximum.ToString();
					this.SetAmounts();
					this.picBarGraph.Refresh();
				}
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000D224 File Offset: 0x0000C224
		private void txtUnits_Enter(object sender, EventArgs e)
		{
			this.validationString = this.txtUnits.Text;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000D238 File Offset: 0x0000C238
		private void txtUnits_Validating(object sender, CancelEventArgs e)
		{
			if (this.txtUnits.Text == "")
			{
				MessageBox.Show("Please enter a target inventory level.");
				e.Cancel = true;
				this.txtUnits.Focus();
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000D284 File Offset: 0x0000C284
		private void txtBelow_TextChanged(object sender, EventArgs e)
		{
			bool flag = false;
			try
			{
				if (long.Parse(this.txtBelow.Text) >= 0L && long.Parse(this.txtBelow.Text) < (long)this.maxPurchasingUnits)
				{
					flag = true;
				}
				else
				{
					this.txtBelow.Text = this.validationString;
					MessageBox.Show("You must enter an amount greater than or equal to 0 and less than " + Utilities.FU(this.maxPurchasingUnits) + ".");
					this.txtBelow.Focus();
					this.txtBelow.SelectAll();
				}
			}
			catch (Exception)
			{
				if (this.txtBelow.Text != "")
				{
					this.txtBelow.Text = this.validationString;
					MessageBox.Show("Please enter a valid numeric expression for your amount.");
					this.txtBelow.Focus();
					this.txtBelow.SelectAll();
				}
			}
			finally
			{
				if (flag)
				{
					this.localData.PurchasingPolicy.GlobalWhen = int.Parse(this.txtBelow.Text);
					for (int i = 0; i < this.productTypes.Length; i++)
					{
						if (!this.localData.PurchasingPolicy.GetCustom(i))
						{
						}
					}
				}
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000D3F8 File Offset: 0x0000C3F8
		private void txtBelow_Enter(object sender, EventArgs e)
		{
			this.validationString = this.txtBelow.Text;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000D40C File Offset: 0x0000C40C
		private void txtBelow_Validating(object sender, CancelEventArgs e)
		{
			if (this.txtBelow.Text == "")
			{
				MessageBox.Show("Please enter an amount at which you would like to re-order your products.");
				e.Cancel = true;
				this.txtBelow.Focus();
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000D457 File Offset: 0x0000C457
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Purchasing");
		}

		// Token: 0x040000FF RID: 255
		private bool exitAfterCustomProduct = false;

		// Token: 0x04000100 RID: 256
		protected ProductType[] productTypes;

		// Token: 0x04000101 RID: 257
		protected int maxPurchasingUnits;

		// Token: 0x04000102 RID: 258
		protected frmPurchasing.Input localData;

		// Token: 0x04000103 RID: 259
		public static bool advanced;

		// Token: 0x04000104 RID: 260
		protected string validationString;

		// Token: 0x04000105 RID: 261
		protected Graphics legend;

		// Token: 0x04000106 RID: 262
		protected Graphics barGraph;

		// Token: 0x04000107 RID: 263
		protected SolidBrush redBrush;

		// Token: 0x04000108 RID: 264
		protected Pen darkGrayPen;

		// Token: 0x04000109 RID: 265
		protected ControlArray chkCustom;

		// Token: 0x0400010A RID: 266
		protected ControlArray lblProductImage;

		// Token: 0x0400010B RID: 267
		protected ControlArray lblProductName;

		// Token: 0x0400010C RID: 268
		protected ControlArray lblAmount;

		// Token: 0x0400010D RID: 269
		protected ControlArray lblWhen;

		// Token: 0x0200001C RID: 28
		[Serializable]
		public struct Input
		{
			// Token: 0x04000125 RID: 293
			public PurchasingPolicy PurchasingPolicy;

			// Token: 0x04000126 RID: 294
			public float[] AverageDailySales;
		}
	}
}
