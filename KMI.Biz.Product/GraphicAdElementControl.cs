using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using KMI.Sim;

namespace KMI.Biz.Product
{
	// Token: 0x0200000F RID: 15
	public class GraphicAdElementControl : UserControl
	{
		// Token: 0x06000045 RID: 69 RVA: 0x000060CF File Offset: 0x000050CF
		public GraphicAdElementControl(frmAdDesigner parent)
		{
			this.InitializeComponent();
			this.parent = parent;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000060F0 File Offset: 0x000050F0
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

		// Token: 0x06000047 RID: 71 RVA: 0x0000612C File Offset: 0x0000512C
		private void InitializeComponent()
		{
			ResourceManager resourceManager = new ResourceManager(typeof(GraphicAdElementControl));
			this.labName = new Label();
			this.labPrice = new Label();
			this.labImage = new Label();
			this.panel1 = new Panel();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.labName.AutoSize = true;
			this.labName.Location = new Point(16, 16);
			this.labName.Name = "labName";
			this.labName.Size = new Size(76, 16);
			this.labName.TabIndex = 0;
			this.labName.Text = "Product Name";
			this.labName.TextAlign = ContentAlignment.TopCenter;
			this.labName.MouseDown += this.Component_MouseDown;
			this.labPrice.AutoSize = true;
			this.labPrice.Location = new Point(16, 96);
			this.labPrice.Name = "labPrice";
			this.labPrice.Size = new Size(33, 16);
			this.labPrice.TabIndex = 1;
			this.labPrice.Text = "$1.23";
			this.labPrice.TextAlign = ContentAlignment.MiddleCenter;
			this.labPrice.MouseDown += this.Component_MouseDown;
			this.labImage.Image = (Image)resourceManager.GetObject("labImage.Image");
			this.labImage.Location = new Point(32, 48);
			this.labImage.Name = "labImage";
			this.labImage.Size = new Size(32, 32);
			this.labImage.TabIndex = 2;
			this.labImage.MouseDown += this.Component_MouseDown;
			this.panel1.Controls.Add(this.labPrice);
			this.panel1.Controls.Add(this.labName);
			this.panel1.Controls.Add(this.labImage);
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(104, 128);
			this.panel1.TabIndex = 3;
			this.panel1.MouseDown += this.Component_MouseDown;
			base.Controls.Add(this.panel1);
			base.Name = "GraphicAdElementControl";
			base.Size = new Size(104, 128);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00006408 File Offset: 0x00005408
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00006420 File Offset: 0x00005420
		public GraphicAdElement.Sizes ProductSize
		{
			get
			{
				return this.productSize;
			}
			set
			{
				this.productSize = value;
				this.labPrice.Font = GraphicAdElement.Fonts[(int)value];
				this.labName.Font = this.labPrice.Font;
				Bitmap image = S.R.GetImage("ProdLarge" + this.ProductType.Index);
				float num = GraphicAdElement.ImageScales[(int)value];
				this.labImage.Image = new Bitmap(image, (int)((float)image.Width * num), (int)((float)image.Height * num));
				this.labImage.Size = this.labImage.Image.Size;
				int width = Math.Max(this.labPrice.Width, Math.Max(this.labName.Width, this.labImage.Image.Width));
				int height = this.labPrice.Height + this.labName.Height + this.labImage.Image.Height;
				base.Size = new Size(width, height);
				this.panel1.Size = base.Size;
				this.labName.Location = new Point((base.Size.Width - this.labName.Width) / 2, 0);
				this.labImage.Location = new Point((base.Size.Width - this.labImage.Width) / 2, this.labName.Bottom);
				this.labPrice.Location = new Point((base.Size.Width - this.labPrice.Width) / 2, this.labImage.Bottom);
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000065EC File Offset: 0x000055EC
		private void Component_MouseDown(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num2 = 0;
			if (!(sender is Panel))
			{
				Control control = (Control)sender;
				num = control.Location.X;
				num2 = control.Location.Y;
			}
			this.parent.allObjects_MouseDown(this, new MouseEventArgs(e.Button, e.Clicks, e.X + num, e.Y + num2, e.Delta));
		}

		// Token: 0x0400007A RID: 122
		public Label labName;

		// Token: 0x0400007B RID: 123
		public Label labPrice;

		// Token: 0x0400007C RID: 124
		public Label labImage;

		// Token: 0x0400007D RID: 125
		public Panel panel1;

		// Token: 0x0400007E RID: 126
		private Container components = null;

		// Token: 0x0400007F RID: 127
		public ProductType ProductType;

		// Token: 0x04000080 RID: 128
		public GraphicAdElement.Sizes productSize;

		// Token: 0x04000081 RID: 129
		protected frmAdDesigner parent;
	}
}
