using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for RadioStationControl.
	/// </summary>
	// Token: 0x02000016 RID: 22
	public class RadioStationControl : UserControl
	{
		// Token: 0x0600009C RID: 156 RVA: 0x00009D57 File Offset: 0x00008D57
		public RadioStationControl()
		{
			this.InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x0600009D RID: 157 RVA: 0x00009D70 File Offset: 0x00008D70
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

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		// Token: 0x0600009E RID: 158 RVA: 0x00009DAC File Offset: 0x00008DAC
		private void InitializeComponent()
		{
			this.grpStation = new GroupBox();
			this.labListeners = new Label();
			this.labCost = new Label();
			this.label5 = new Label();
			this.labLabListeners0 = new Label();
			this.labFormat = new Label();
			this.btnSample = new Button();
			this.label3 = new Label();
			this.checkBox4 = new CheckBox();
			this.checkBox3 = new CheckBox();
			this.checkBox2 = new CheckBox();
			this.label1 = new Label();
			this.checkBox1 = new CheckBox();
			this.panChk = new Panel();
			this.grpStation.SuspendLayout();
			this.panChk.SuspendLayout();
			base.SuspendLayout();
			this.grpStation.Controls.Add(this.labListeners);
			this.grpStation.Controls.Add(this.labCost);
			this.grpStation.Controls.Add(this.label5);
			this.grpStation.Controls.Add(this.labLabListeners0);
			this.grpStation.Controls.Add(this.labFormat);
			this.grpStation.Controls.Add(this.btnSample);
			this.grpStation.Controls.Add(this.label3);
			this.grpStation.Controls.Add(this.label1);
			this.grpStation.Controls.Add(this.panChk);
			this.grpStation.Location = new Point(0, 0);
			this.grpStation.Name = "grpStation";
			this.grpStation.Size = new Size(184, 264);
			this.grpStation.TabIndex = 1;
			this.grpStation.TabStop = false;
			this.grpStation.Text = "Station: #";
			this.labListeners.Location = new Point(128, 80);
			this.labListeners.Name = "labListeners";
			this.labListeners.Size = new Size(48, 16);
			this.labListeners.TabIndex = 11;
			this.labListeners.Text = "#";
			this.labListeners.TextAlign = ContentAlignment.TopRight;
			this.labCost.Location = new Point(128, 104);
			this.labCost.Name = "labCost";
			this.labCost.Size = new Size(48, 16);
			this.labCost.TabIndex = 10;
			this.labCost.Text = "#";
			this.labCost.TextAlign = ContentAlignment.TopRight;
			this.label5.Location = new Point(8, 104);
			this.label5.Name = "label5";
			this.label5.Size = new Size(120, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Weekly Cost/Rotation:";
			this.labLabListeners0.Location = new Point(8, 80);
			this.labLabListeners0.Name = "labLabListeners0";
			this.labLabListeners0.Size = new Size(120, 16);
			this.labLabListeners0.TabIndex = 8;
			this.labLabListeners0.Text = "Avg. Daily Listeners:";
			this.labFormat.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.labFormat.Location = new Point(80, 24);
			this.labFormat.Name = "labFormat";
			this.labFormat.Size = new Size(72, 16);
			this.labFormat.TabIndex = 1;
			this.labFormat.Text = "#";
			this.btnSample.Location = new Point(32, 48);
			this.btnSample.Name = "btnSample";
			this.btnSample.Size = new Size(96, 24);
			this.btnSample.TabIndex = 2;
			this.btnSample.Tag = "0";
			this.btnSample.Text = "Hear Sample";
			this.btnSample.Click += this.btnSample_Click;
			this.label3.Location = new Point(16, 24);
			this.label3.Name = "label3";
			this.label3.Size = new Size(56, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Format:";
			this.checkBox4.Location = new Point(8, 80);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new Size(128, 16);
			this.checkBox4.TabIndex = 7;
			this.checkBox4.Tag = "3";
			this.checkBox4.Text = "Late Night";
			this.checkBox3.Location = new Point(8, 56);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new Size(128, 16);
			this.checkBox3.TabIndex = 6;
			this.checkBox3.Tag = "2";
			this.checkBox3.Text = "Evening Drivetime";
			this.checkBox2.Location = new Point(8, 32);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new Size(128, 16);
			this.checkBox2.TabIndex = 5;
			this.checkBox2.Tag = "1";
			this.checkBox2.Text = "Daytime";
			this.label1.Location = new Point(16, 136);
			this.label1.Name = "label1";
			this.label1.Size = new Size(128, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Book Rotations:";
			this.checkBox1.Location = new Point(8, 8);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new Size(128, 16);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Tag = "0";
			this.checkBox1.Text = "Morning Drivetime";
			this.panChk.Controls.Add(this.checkBox1);
			this.panChk.Controls.Add(this.checkBox2);
			this.panChk.Controls.Add(this.checkBox3);
			this.panChk.Controls.Add(this.checkBox4);
			this.panChk.Location = new Point(16, 152);
			this.panChk.Name = "panChk";
			this.panChk.Size = new Size(144, 104);
			this.panChk.TabIndex = 12;
			base.Controls.Add(this.grpStation);
			base.Name = "RadioStationControl";
			base.Size = new Size(184, 264);
			this.grpStation.ResumeLayout(false);
			this.panChk.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600009F RID: 159 RVA: 0x0000A594 File Offset: 0x00009594
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x0000A5AC File Offset: 0x000095AC
		public RadioStation RadioStation
		{
			get
			{
				return this.radioStation;
			}
			set
			{
				this.radioStation = value;
				this.grpStation.Text = this.radioStation.Name;
				this.labFormat.Text = this.radioStation.Format;
				this.labListeners.Text = Utilities.FU(this.radioStation.Reach);
				this.labCost.Text = Utilities.FC((float)this.radioStation.Reach * 20f / 1000f, A.I.CurrencyConversion);
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000A640 File Offset: 0x00009640
		private void btnSample_Click(object sender, EventArgs e)
		{
			if (!A.I.UserAdminSettings.NoSound)
			{
				int i = Convert.ToInt32(((Button)sender).Tag);
				Sound.PlayMidiFromFile(this.RadioStation.SampleSongFilename);
			}
		}

		// Token: 0x0400008C RID: 140
		private Label labListeners;

		// Token: 0x0400008D RID: 141
		private Label labCost;

		// Token: 0x0400008E RID: 142
		private Label label5;

		// Token: 0x0400008F RID: 143
		private Label labLabListeners0;

		// Token: 0x04000090 RID: 144
		private Label labFormat;

		// Token: 0x04000091 RID: 145
		private Button btnSample;

		// Token: 0x04000092 RID: 146
		private Label label3;

		// Token: 0x04000093 RID: 147
		private CheckBox checkBox4;

		// Token: 0x04000094 RID: 148
		private CheckBox checkBox3;

		// Token: 0x04000095 RID: 149
		private CheckBox checkBox2;

		// Token: 0x04000096 RID: 150
		private Label label1;

		// Token: 0x04000097 RID: 151
		private CheckBox checkBox1;

		// Token: 0x04000098 RID: 152
		public Panel panChk;

		// Token: 0x04000099 RID: 153
		private GroupBox grpStation;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		// Token: 0x0400009A RID: 154
		private Container components = null;

		// Token: 0x0400009B RID: 155
		public RadioStation radioStation;
	}
}
