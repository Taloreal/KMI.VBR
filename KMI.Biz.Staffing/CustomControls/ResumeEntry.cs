using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KMI.Biz.Staffing.CustomControls
{
	// Token: 0x02000004 RID: 4
	public class ResumeEntry : UserControl
	{
		// Token: 0x06000019 RID: 25 RVA: 0x000039CE File Offset: 0x000029CE
		public ResumeEntry()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000039E8 File Offset: 0x000029E8
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

		// Token: 0x0600001B RID: 27 RVA: 0x00003A24 File Offset: 0x00002A24
		private void InitializeComponent()
		{
			this.Place = new Label();
			this.Dates = new Label();
			this.Description = new Label();
			base.SuspendLayout();
			this.Place.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Place.Location = new Point(0, 0);
			this.Place.Name = "Place";
			this.Place.Size = new Size(152, 32);
			this.Place.TabIndex = 0;
			this.Dates.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Dates.Location = new Point(160, 0);
			this.Dates.Name = "Dates";
			this.Dates.Size = new Size(136, 32);
			this.Dates.TabIndex = 1;
			this.Dates.TextAlign = ContentAlignment.TopRight;
			this.Description.Location = new Point(0, 32);
			this.Description.Name = "Description";
			this.Description.Size = new Size(312, 32);
			this.Description.TabIndex = 2;
			this.BackColor = Color.White;
			base.Controls.Add(this.Description);
			base.Controls.Add(this.Dates);
			base.Controls.Add(this.Place);
			base.Name = "ResumeEntry";
			base.Size = new Size(320, 72);
			base.ResumeLayout(false);
		}

		// Token: 0x04000024 RID: 36
		public Label Place;

		// Token: 0x04000025 RID: 37
		public Label Dates;

		// Token: 0x04000026 RID: 38
		public Label Description;

		// Token: 0x04000027 RID: 39
		private Container components = null;
	}
}
