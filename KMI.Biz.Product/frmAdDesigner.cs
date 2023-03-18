using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x02000017 RID: 23
	public partial class frmAdDesigner : Form
	{
		// Token: 0x0600008C RID: 140 RVA: 0x0000854C File Offset: 0x0000754C
		public frmAdDesigner(ProductType[] ProductTypes, int adNumber)
		{
			this.InitializeComponent();
			this.adNumber = adNumber;
			this.ProductTypes = ProductTypes;
			for (int i = 0; i < ProductTypes.Length; i++)
			{
				Label label = new Label();
				label.Tag = ProductTypes[i];
				label.Size = new Size(32, 32);
				label.Cursor = Cursors.Hand;
				label.Image = S.R.GetImage("Prod" + i);
				this.toolTip.SetToolTip(label, ProductTypes[i].Name);
				int num = (int)Math.Floor((double)(i / 3));
				int num2 = i % 3;
				label.Location = new Point(num2 * label.Width + 8, num * label.Height + 8);
				label.MouseDown += this.tools_MouseDown;
				this.panProd.Height = Math.Max(label.Location.Y + label.Height + 4, this.panProd.Height);
				this.panProd.Controls.Add(label);
			}
			foreach (object obj in this.panText.Controls)
			{
				Label label = (Label)obj;
				label.MouseDown += this.tools_MouseDown;
			}
			this.cboFont.Items.Add("Times New Roman");
			this.cboFont.Items.Add("Arial");
			this.cboFont.Items.Add("Verdana");
			this.cboFont.Items.Add("Microsoft Sans Serif");
			this.cboFont.Sorted = true;
			foreach (int num3 in new int[]
			{
				7,
				8,
				9,
				10,
				11,
				12,
				14,
				16,
				20,
				24,
				26,
				28,
				32,
				36,
				48
			})
			{
				this.cboFontSize.Items.Add(num3);
			}
			this.cboFontSize.SelectedIndex = 3;
			this.radProductSmall.Tag = GraphicAdElement.Sizes.Small;
			this.radProductMedium.Tag = GraphicAdElement.Sizes.Medium;
			this.radProductLarge.Tag = GraphicAdElement.Sizes.Large;
			this.input = ((IBizProductStateAdapter)S.SA).GetAd(S.MF.CurrentEntityID, adNumber);
			if (this.input.Ad == null)
			{
				this.input.Ad = new Ad();
			}
			foreach (object obj2 in this.input.Ad.TextAdElements)
			{
				TextAdElement e = (TextAdElement)obj2;
				this.pnlCanvas.Controls.Add(this.TextAdElementToControl(e));
			}
			foreach (object obj3 in this.input.Ad.GraphicAdElements)
			{
				GraphicAdElement e2 = (GraphicAdElement)obj3;
				this.pnlCanvas.Controls.Add(this.GraphicAdElementToControl(e2));
			}
			foreach (object obj4 in this.pnlCanvas.Controls)
			{
				Control control = (Control)obj4;
				control.MouseDown += this.allObjects_MouseDown;
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000089A8 File Offset: 0x000079A8
		public void SelectObject(Control obj)
		{
			foreach (object obj2 in this.pnlCanvas.Controls)
			{
				Control control = (Control)obj2;
				if (control is Label)
				{
					((Label)control).BorderStyle = BorderStyle.None;
				}
				else
				{
					((GraphicAdElementControl)control).panel1.BorderStyle = BorderStyle.None;
				}
			}
			this.selected = obj;
			if (this.selected is GraphicAdElementControl)
			{
				GraphicAdElementControl graphicAdElementControl = (GraphicAdElementControl)this.selected;
				graphicAdElementControl.panel1.BorderStyle = BorderStyle.FixedSingle;
				this.grpTextProperties.Visible = false;
				this.grpProductProperties.Visible = true;
				this.SynchProductProperties();
			}
			else if (this.selected is Label)
			{
				Label label = (Label)this.selected;
				label.BorderStyle = BorderStyle.FixedSingle;
				this.grpProductProperties.Visible = false;
				this.grpTextProperties.Visible = true;
				this.SynchTextProperties();
			}
			this.btnDelete.Enabled = true;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00008AFC File Offset: 0x00007AFC
		protected void DeleteSelectedObject()
		{
			this.pnlCanvas.Controls.Remove(this.selected);
			this.selected = null;
			this.pnlCanvas.Refresh();
			this.btnDelete.Enabled = false;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00008B36 File Offset: 0x00007B36
		protected void DeleteAllObjects()
		{
			this.pnlCanvas.Controls.Clear();
			this.selected = null;
			this.pnlCanvas.Refresh();
			this.btnDelete.Enabled = false;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00008B6C File Offset: 0x00007B6C
		protected void SynchTextProperties()
		{
			Label label = (Label)this.selected;
			this.tbbBold.Pushed = label.Font.Bold;
			this.tbbItalic.Pushed = label.Font.Italic;
			this.tbbUnderline.Pushed = label.Font.Underline;
			this.supressFontUpdates = true;
			this.cboFontSize.Text = this.selected.Font.Size.ToString();
			this.supressFontUpdates = false;
			this.cboFont.Text = this.selected.Font.Name;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00008C1C File Offset: 0x00007C1C
		protected void SynchProductProperties()
		{
			GraphicAdElementControl graphicAdElementControl = (GraphicAdElementControl)this.selected;
			switch (graphicAdElementControl.ProductSize)
			{
			case GraphicAdElement.Sizes.Small:
				this.radProductSmall.Checked = true;
				break;
			case GraphicAdElement.Sizes.Medium:
				this.radProductMedium.Checked = true;
				break;
			case GraphicAdElement.Sizes.Large:
				this.radProductLarge.Checked = true;
				break;
			}
			this.chkProductName.Checked = graphicAdElementControl.labName.Visible;
			this.chkProductPrice.Checked = graphicAdElementControl.labPrice.Visible;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00008CB0 File Offset: 0x00007CB0
		protected Point AlignToGrid(Point p)
		{
			return new Point(p.X / this.gridSize * this.gridSize, p.Y / this.gridSize * this.gridSize);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000A2E3 File Offset: 0x000092E3
		private void btnHelp_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000A2E6 File Offset: 0x000092E6
		private void tools_MouseDown(object sender, MouseEventArgs e)
		{
			((Control)sender).DoDragDrop(sender, DragDropEffects.Copy);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000A2F8 File Offset: 0x000092F8
		private void pnlCanvas_DragDrop(object sender, DragEventArgs e)
		{
			this.dragOffset = Point.Empty;
			if (e.Data.GetDataPresent(typeof(Label)))
			{
				Label label = (Label)e.Data.GetData(typeof(Label));
				if (this.panText.Contains(label) || this.panProd.Contains(label))
				{
					Control control;
					if (this.panText.Contains(label))
					{
						Label label2 = new Label();
						control = label2;
						label2.Cursor = Cursors.Hand;
						label2.AutoSize = true;
						label2.Tag = label.Tag;
						label2.Text = label.Text;
						if (label2.Text == "{Name}")
						{
							label2.Text = this.input.EntityName;
						}
						if (label2.Text == "{Location}")
						{
							label2.Text = this.input.OurLocation;
						}
						if (label2.Text == "{Custom}")
						{
							label2.Text = "Default custom text";
						}
					}
					else
					{
						GraphicAdElementControl graphicAdElementControl = new GraphicAdElementControl(this);
						control = graphicAdElementControl;
						ProductType productType = (ProductType)label.Tag;
						graphicAdElementControl.ProductType = productType;
						graphicAdElementControl.labImage.Image = label.Image;
						graphicAdElementControl.labName.Text = productType.Name;
						graphicAdElementControl.labPrice.Text = Utilities.FC(this.input.OurPrices[productType.Index], 2, S.I.CurrencyConversion);
						graphicAdElementControl.ProductSize = GraphicAdElement.Sizes.Small;
						graphicAdElementControl.labPrice.Visible = false;
					}
					control.Location = this.AlignToGrid(this.pnlCanvas.PointToClient(new Point(e.X, e.Y)));
					control.Cursor = Cursors.Hand;
					this.pnlCanvas.Controls.Add(control);
					control.MouseDown += this.allObjects_MouseDown;
					this.SelectObject(control);
				}
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000A536 File Offset: 0x00009536
		private void pnlCanvas_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000A544 File Offset: 0x00009544
		private void pnlCanvas_DragOver(object sender, DragEventArgs e)
		{
			if (!this.dragOffset.IsEmpty)
			{
				Point point = this.pnlCanvas.PointToClient(new Point(e.X, e.Y));
				this.selected.Location = this.AlignToGrid(new Point(point.X + this.dragOffset.X, point.Y + this.dragOffset.Y));
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000A5C0 File Offset: 0x000095C0
		public void allObjects_MouseDown(object sender, MouseEventArgs e)
		{
			Control control = (Control)sender;
			this.SelectObject(control);
			this.dragOffset = new Point(-e.X, -e.Y);
			control.DoDragDrop(sender, DragDropEffects.Copy);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000A600 File Offset: 0x00009600
		private void picColor_Click(object sender, EventArgs e)
		{
			if (this.selected != null && this.selected.GetType().Name == "Label")
			{
				this.ColorDialog.ShowDialog();
				this.selected.ForeColor = this.ColorDialog.Color;
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000A660 File Offset: 0x00009660
		private void chkProductName_CheckedChanged(object sender, EventArgs e)
		{
			if (this.selected != null && this.selected is GraphicAdElementControl)
			{
				((GraphicAdElementControl)this.selected).labName.Visible = this.chkProductName.Checked;
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000A6B0 File Offset: 0x000096B0
		private void chkProductPrice_CheckedChanged(object sender, EventArgs e)
		{
			if (this.selected != null && this.selected is GraphicAdElementControl)
			{
				((GraphicAdElementControl)this.selected).labPrice.Visible = this.chkProductPrice.Checked;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000A700 File Offset: 0x00009700
		private void radProductSize_Click(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked && this.selected != null && this.selected is GraphicAdElementControl)
			{
				((GraphicAdElementControl)this.selected).ProductSize = (GraphicAdElement.Sizes)radioButton.Tag;
				this.SelectObject(this.selected);
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000A768 File Offset: 0x00009768
		private void btnDelete_Click(object sender, EventArgs e)
		{
			this.DeleteSelectedObject();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000A774 File Offset: 0x00009774
		public TextAdElement ControlToTextAdElement(Label ctl)
		{
			TextAdElement textAdElement = new TextAdElement();
			textAdElement.Text = ctl.Text;
			textAdElement.FontName = ctl.Font.Name;
			textAdElement.Bold = ctl.Font.Bold;
			textAdElement.Italic = ctl.Font.Italic;
			textAdElement.Underline = ctl.Font.Underline;
			textAdElement.Color = ctl.ForeColor;
			textAdElement.FontSize = ctl.Font.Size;
			textAdElement.Location = ctl.Location;
			if (ctl.Tag != null)
			{
				textAdElement.Custom = (bool)ctl.Tag;
			}
			return textAdElement;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000A824 File Offset: 0x00009824
		public GraphicAdElement ControlToGraphicAdElement(GraphicAdElementControl ctl)
		{
			return new GraphicAdElement
			{
				ProductType = ctl.ProductType,
				ShowPrice = ctl.labPrice.Visible,
				ShowName = ctl.labName.Visible,
				Size = ctl.ProductSize,
				Location = ctl.Location
			};
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000A884 File Offset: 0x00009884
		public Label TextAdElementToControl(TextAdElement e)
		{
			return new Label
			{
				Text = e.Text,
				Font = new Font(e.FontName, e.FontSize, frmAdDesigner.FontStyleFromBools(e.Bold, e.Italic, e.Underline)),
				ForeColor = e.Color,
				Location = e.Location,
				Tag = e.Custom,
				AutoSize = true
			};
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000A910 File Offset: 0x00009910
		public GraphicAdElementControl GraphicAdElementToControl(GraphicAdElement e)
		{
			return new GraphicAdElementControl(this)
			{
				ProductType = e.ProductType,
				labPrice = 
				{
					Visible = e.ShowPrice,
					Text = Utilities.FC(this.input.OurPrices[e.ProductType.Index], 2, S.I.CurrencyConversion)
				},
				labName = 
				{
					Visible = e.ShowName,
					Text = e.ProductType.Name
				},
				Location = e.Location,
				ProductSize = e.Size
			};
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000A9C0 File Offset: 0x000099C0
		public static FontStyle FontStyleFromBools(bool bold, bool italic, bool underline)
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (bold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (italic)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (underline)
			{
				fontStyle |= FontStyle.Underline;
			}
			return fontStyle;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000A9F9 File Offset: 0x000099F9
		private void btnDeleteAd_Click(object sender, EventArgs e)
		{
			this.DeleteAllObjects();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000AA04 File Offset: 0x00009A04
		private void UserFontChanged(object sender, EventArgs e)
		{
			if (!this.supressFontUpdates)
			{
				if (this.selected != null && this.selected is Label)
				{
					this.selected.Font = new Font(this.cboFont.Text, (float)((int)this.cboFontSize.SelectedItem), frmAdDesigner.FontStyleFromBools(this.tbbBold.Pushed, this.tbbItalic.Pushed, this.tbbUnderline.Pushed));
				}
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000AA94 File Offset: 0x00009A94
		private void btnOK_Click(object sender, EventArgs e)
		{
			Ad ad = null;
			if (this.pnlCanvas.Controls.Count > 0)
			{
				ad = new Ad();
				ad.Index = this.adNumber;
				foreach (object obj in this.pnlCanvas.Controls)
				{
					Control control = (Control)obj;
					if (control is Label)
					{
						ad.TextAdElements.Add(this.ControlToTextAdElement((Label)control));
					}
					else
					{
						ad.GraphicAdElements.Add(this.ControlToGraphicAdElement((GraphicAdElementControl)control));
					}
				}
			}
			try
			{
				((IBizProductStateAdapter)S.SA).SetAd(S.MF.CurrentEntityID, this.adNumber, ad);
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2, this);
			}
			base.Close();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000ABB8 File Offset: 0x00009BB8
		private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tbbColor && this.selected != null)
			{
				if (this.ColorDialog.ShowDialog(this) == DialogResult.OK)
				{
					this.selected.ForeColor = this.ColorDialog.Color;
				}
			}
			else
			{
				this.UserFontChanged(sender, new EventArgs());
			}
		}

		// Token: 0x040000E8 RID: 232
		private int adNumber;

		// Token: 0x040000E9 RID: 233
		private bool supressFontUpdates = false;

		// Token: 0x040000EA RID: 234
		protected ProductType[] ProductTypes;

		// Token: 0x040000EB RID: 235
		protected Point dragOffset = Point.Empty;

		// Token: 0x040000EC RID: 236
		protected int gridSize = 8;

		// Token: 0x040000ED RID: 237
		protected Control selected;

		// Token: 0x040000EE RID: 238
		public frmAdDesigner.Input input;

		// Token: 0x02000018 RID: 24
		public struct Input
		{
			// Token: 0x040000EF RID: 239
			public Ad Ad;

			// Token: 0x040000F0 RID: 240
			public string EntityName;

			// Token: 0x040000F1 RID: 241
			public string OurLocation;

			// Token: 0x040000F2 RID: 242
			public float[] OurPrices;
		}
	}
}
