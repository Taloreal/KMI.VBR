using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Staffing
{
	// Token: 0x02000002 RID: 2
	public partial class frmStaffingSimple : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public frmStaffingSimple(Bitmap newHireImage, string[] task, int[] shiftStartHour, int[] shiftLength, int[] maxEmployees, float[] wages)
		{
			this.InitializeComponent();
			this.labNewHire.Image = newHireImage;
			this.labPerson.Width = newHireImage.Width;
			this.EMP_SPACING = newHireImage.Width + 4;
			base.Width = Math.Min(Screen.PrimaryScreen.Bounds.Width, base.Width);
			this.task = task;
			this.shiftStartHour = shiftStartHour;
			this.shiftLength = shiftLength;
			this.maxEmployees = maxEmployees;
			this.wages = wages;
			this.schedule = ((IBizStaffingStateAdapter)S.SA).GetSchedule(S.MF.CurrentEntityID);
			this.schedule = (int[,])this.schedule.Clone();
			this.taskSpacing = this.GetTaskSpacing();
			this.panTasks.Controls.Clear();
			for (int i = 0; i < task.Length; i++)
			{
				Label label = new Label();
				label.Location = new Point(this.labTask.Left, (this.taskSpacing - this.labTask.Height) / 2 + (i + 1) * this.taskSpacing);
				label.Font = this.labTask.Font;
				label.TextAlign = this.labTask.TextAlign;
				label.Text = task[i];
				this.panTasks.Controls.Add(label);
			}
			this.picMain.Location = new Point(0, 0);
			this.picMain.Height = Math.Max((task.Length + 1) * this.taskSpacing, this.picMain.Height);
			this.picMain.AllowDrop = true;
			this.UpdateSchedule();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00003054 File Offset: 0x00002054
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				((IBizStaffingStateAdapter)S.SA).SetSchedule(S.MF.CurrentEntityID, this.schedule);
				if (S.I.DoShowAgain("Staffing Changes"))
				{
					MessageBox.Show("Your staffing changes will take effect at the beginning of the next shift.", "Staffing Changes");
					S.I.DontShowAgain("Staffing Changes");
				}
				base.Close();
			}
			catch (Exception e2)
			{
				frmExceptionHandler.Handle(e2, this);
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000030E4 File Offset: 0x000020E4
		private void UpdateSchedule()
		{
			float num = 0f;
			int num2 = 0;
			for (int i = 0; i < this.task.Length; i++)
			{
				for (int j = 0; j < this.shiftStartHour.Length; j++)
				{
					int num3 = this.schedule[i, j] * this.shiftLength[j] * 7;
					num2 += num3;
					num += (float)num3 * this.wages[i];
				}
			}
			this.labHours.Text = num2.ToString();
			this.labWeeklyPayroll.Text = Utilities.FC(num, S.I.CurrencyConversion);
			this.labWage.Text = Utilities.FC(num / (float)num2, 2, S.I.CurrencyConversion);
			this.shiftSpacing = Math.Max(this.EMP_SPACING * (frmStaffingSimple.DEFAULT_EMPS + 2), this.EMP_SPACING * (this.MaxEmpsPerShift() + 2));
			this.picMain.Width = this.shiftStartHour.Length * this.shiftSpacing;
			Console.WriteLine(this.shiftSpacing);
			this.picMain.Refresh();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00003208 File Offset: 0x00002208
		private void picMain_Paint(object sender, PaintEventArgs e)
		{
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			for (int i = 0; i < this.shiftStartHour.Length; i++)
			{
				DateTime dateTime = new DateTime(1999, 1, 1, this.shiftStartHour[i], 0, 0);
				DateTime dateTime2 = dateTime.AddHours((double)this.shiftLength[i]);
				string s = dateTime.ToShortTimeString() + " - " + dateTime2.ToShortTimeString() + " Shift";
				e.Graphics.DrawString(s, this.labTask.Font, new SolidBrush(Color.Black), new Rectangle(i * this.shiftSpacing, 12, this.shiftSpacing, this.taskSpacing), stringFormat);
			}
			Pen pen = new Pen(Color.DarkGray, 1f);
			pen.DashStyle = DashStyle.Dash;
			for (int j = 1; j < this.task.Length; j++)
			{
				e.Graphics.DrawLine(new Pen(Color.DarkGray, 1f), 0, (j + 1) * this.taskSpacing, this.picMain.Width, (j + 1) * this.taskSpacing);
			}
			for (int i = 1; i < this.shiftStartHour.Length; i++)
			{
				e.Graphics.DrawLine(pen, i * this.shiftSpacing, 0, i * this.shiftSpacing, this.picMain.Height);
			}
			this.picMain.Controls.Clear();
			for (int j = 0; j < this.task.Length; j++)
			{
				for (int i = 0; i < this.shiftStartHour.Length; i++)
				{
					for (int k = 0; k < this.schedule[j, i]; k++)
					{
						Label label = new Label();
						label.Size = this.labPerson.Size;
						label.Location = new Point(i * this.shiftSpacing + (k + 1) * this.EMP_SPACING + 6, (j + 1) * this.taskSpacing + 6);
						label.Image = this.labNewHire.Image;
						label.MouseDown += this.labNewHire_MouseDown;
						this.picMain.Controls.Add(label);
					}
					Label label2 = new Label();
					label2.Image = this.labPlus.Image;
					label2.Size = new Size(14, 14);
					label2.Location = new Point(i * this.shiftSpacing + 6, (j + 1) * this.taskSpacing + 6);
					label2.Tag = new Point(j, i);
					label2.Click += this.labPlus_Click;
					this.picMain.Controls.Add(label2);
					Label label3 = new Label();
					label3.Image = this.labMinus.Image;
					label3.Size = new Size(14, 14);
					label3.Location = new Point(i * this.shiftSpacing + 6, (j + 1) * this.taskSpacing + 6 + 22);
					label3.Tag = new Point(j, i);
					label3.Click += this.labMinus_Click;
					this.picMain.Controls.Add(label3);
				}
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000035A8 File Offset: 0x000025A8
		private void labPlus_Click(object sender, EventArgs e)
		{
			Point point = (Point)((Label)sender).Tag;
			this.schedule[point.X, point.Y]++;
			this.UpdateSchedule();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000035F4 File Offset: 0x000025F4
		private void labMinus_Click(object sender, EventArgs e)
		{
			Point point = (Point)((Label)sender).Tag;
			if (this.schedule[point.X, point.Y] > 0)
			{
				this.schedule[point.X, point.Y]--;
			}
			this.UpdateSchedule();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00003664 File Offset: 0x00002664
		private void picMain_DragDrop(object sender, DragEventArgs e)
		{
			Point point = this.picMain.PointToClient(new Point(e.X, e.Y));
			int num = this.Task(point.Y);
			if (this.schedule[Math.Max(0, num), this.Shift(point.X)] == this.maxEmployees[num])
			{
				MessageBox.Show(string.Concat(new object[]
				{
					"Only ",
					this.maxEmployees[num],
					" ",
					this.task[num],
					"s are needed in this simulation. No more will be added."
				}));
			}
			else
			{
				this.schedule[Math.Max(0, num), this.Shift(point.X)]++;
				if (e.Data.GetDataPresent("System.Drawing.Point"))
				{
					Point left = (Point)e.Data.GetData("System.Drawing.Point");
					if (left != this.labNewHire.Location)
					{
						this.schedule[Math.Max(0, this.Task(left.Y)), this.Shift(left.X)]--;
					}
				}
				this.UpdateSchedule();
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000037D8 File Offset: 0x000027D8
		private int Shift(int x)
		{
			return x / this.shiftSpacing;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000037F4 File Offset: 0x000027F4
		private int Task(int y)
		{
			return y / this.taskSpacing - 1;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00003810 File Offset: 0x00002810
		private int MaxEmpsPerShift()
		{
			int num = int.MinValue;
			for (int i = 0; i <= this.schedule.GetUpperBound(0); i++)
			{
				for (int j = 0; j <= this.schedule.GetUpperBound(1); j++)
				{
					num = Math.Max(num, this.schedule[i, j]);
				}
			}
			return num;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000387F File Offset: 0x0000287F
		private void labNewHire_MouseDown(object sender, MouseEventArgs e)
		{
			((Label)sender).DoDragDrop(((Label)sender).Location, DragDropEffects.Copy);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000389F File Offset: 0x0000289F
		private void picMain_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000038AC File Offset: 0x000028AC
		private void picMain_MouseMove(object sender, MouseEventArgs e)
		{
			this.toolTip1.SetToolTip(this.picMain, this.Task(e.Y) + "," + this.Shift(e.X));
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000038F8 File Offset: 0x000028F8
		protected virtual int GetTaskSpacing()
		{
			return frmStaffingSimple.TASK_SPACING;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003910 File Offset: 0x00002910
		private void labTrash_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("System.Drawing.Point"))
			{
				Point left = (Point)e.Data.GetData("System.Drawing.Point");
				if (left != this.labNewHire.Location)
				{
					this.schedule[Math.Max(0, this.Task(left.Y)), this.Shift(left.X)]--;
				}
			}
			this.UpdateSchedule();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000039A6 File Offset: 0x000029A6
		private void labTrash_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000039B1 File Offset: 0x000029B1
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Staffing");
		}

		// Token: 0x04000001 RID: 1
		protected const int BORDER = 6;

		// Token: 0x04000019 RID: 25
		protected int taskSpacing;

		// Token: 0x0400001A RID: 26
		public static int TASK_SPACING = 48;

		// Token: 0x0400001B RID: 27
		protected int shiftSpacing;

		// Token: 0x0400001C RID: 28
		public int EMP_SPACING = 34;

		// Token: 0x0400001D RID: 29
		public static int DEFAULT_EMPS = 2;

		// Token: 0x0400001E RID: 30
		protected int[,] schedule;

		// Token: 0x0400001F RID: 31
		protected string[] task;

		// Token: 0x04000020 RID: 32
		protected int[] shiftStartHour;

		// Token: 0x04000021 RID: 33
		protected int[] shiftLength;

		// Token: 0x04000022 RID: 34
		protected int[] maxEmployees;

		// Token: 0x04000023 RID: 35
		protected float[] wages;
	}
}
