using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Biz.Product.CustomControls
{
	// Token: 0x02000007 RID: 7
	public class ARInfo : UserControl
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00003575 File Offset: 0x00002575
		public ARInfo()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003590 File Offset: 0x00002590
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

		// Token: 0x06000020 RID: 32 RVA: 0x000035CC File Offset: 0x000025CC
		private void InitializeComponent()
		{
			this.CustomerName = new Label();
			this.Days0To30 = new Label();
			this.Days30To60 = new Label();
			this.Days60To90 = new Label();
			this.Over90 = new Label();
			this.Current = new Label();
			base.SuspendLayout();
			this.CustomerName.Location = new Point(0, 8);
			this.CustomerName.Name = "CustomerName";
			this.CustomerName.Size = new Size(96, 16);
			this.CustomerName.TabIndex = 0;
			this.CustomerName.Text = "Name";
			this.Days0To30.Location = new Point(192, 8);
			this.Days0To30.Name = "Days0To30";
			this.Days0To30.Size = new Size(80, 16);
			this.Days0To30.TabIndex = 1;
			this.Days0To30.Text = "0";
			this.Days0To30.TextAlign = ContentAlignment.TopRight;
			this.Days30To60.Location = new Point(280, 8);
			this.Days30To60.Name = "Days30To60";
			this.Days30To60.Size = new Size(80, 16);
			this.Days30To60.TabIndex = 2;
			this.Days30To60.Text = "0";
			this.Days30To60.TextAlign = ContentAlignment.TopRight;
			this.Days60To90.Location = new Point(368, 8);
			this.Days60To90.Name = "Days60To90";
			this.Days60To90.Size = new Size(80, 16);
			this.Days60To90.TabIndex = 3;
			this.Days60To90.Text = "0";
			this.Days60To90.TextAlign = ContentAlignment.TopRight;
			this.Over90.Location = new Point(456, 8);
			this.Over90.Name = "Over90";
			this.Over90.Size = new Size(80, 16);
			this.Over90.TabIndex = 4;
			this.Over90.Text = "0";
			this.Over90.TextAlign = ContentAlignment.TopRight;
			this.Current.Location = new Point(104, 8);
			this.Current.Name = "Current";
			this.Current.Size = new Size(80, 16);
			this.Current.TabIndex = 5;
			this.Current.Text = "0";
			this.Current.TextAlign = ContentAlignment.TopRight;
			base.Controls.Add(this.Current);
			base.Controls.Add(this.Over90);
			base.Controls.Add(this.Days60To90);
			base.Controls.Add(this.Days30To60);
			base.Controls.Add(this.Days0To30);
			base.Controls.Add(this.CustomerName);
			base.Name = "ARInfo";
			base.Size = new Size(544, 24);
			base.ResumeLayout(false);
		}

		// Token: 0x17000006 RID: 6
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00003914 File Offset: 0x00002914
		public bool Underline
		{
			set
			{
				foreach (object obj in base.Controls)
				{
					Control control = (Control)obj;
					control.Font = new Font(control.Font, control.Font.Style | FontStyle.Underline);
				}
			}
		}

		// Token: 0x17000007 RID: 7
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00003990 File Offset: 0x00002990
		public bool Bold
		{
			set
			{
				foreach (object obj in base.Controls)
				{
					Control control = (Control)obj;
					control.Font = new Font(control.Font, control.Font.Style | FontStyle.Bold);
				}
			}
		}

		// Token: 0x0400002E RID: 46
		public Label CustomerName;

		// Token: 0x0400002F RID: 47
		public Label Days0To30;

		// Token: 0x04000030 RID: 48
		public Label Days30To60;

		// Token: 0x04000031 RID: 49
		public Label Days60To90;

		// Token: 0x04000032 RID: 50
		public Label Over90;

		// Token: 0x04000033 RID: 51
		public Label Current;

		// Token: 0x04000034 RID: 52
		private Container components = null;
	}
}
