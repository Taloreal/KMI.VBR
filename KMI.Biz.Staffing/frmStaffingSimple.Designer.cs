namespace KMI.Biz.Staffing
{
	// Token: 0x02000002 RID: 2
	public partial class frmStaffingSimple : global::System.Windows.Forms.Form
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002224 File Offset: 0x00001224
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

		// Token: 0x06000003 RID: 3 RVA: 0x00002260 File Offset: 0x00001260
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::KMI.Biz.Staffing.frmStaffingSimple));
			this.panBottom = new global::System.Windows.Forms.Panel();
			this.labMinus = new global::System.Windows.Forms.Label();
			this.labPlus = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.labWeeklyPayroll = new global::System.Windows.Forms.Label();
			this.labWage = new global::System.Windows.Forms.Label();
			this.labHours = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.btnHelp = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.labTrash = new global::System.Windows.Forms.Label();
			this.labNewHire = new global::System.Windows.Forms.Label();
			this.panTasks = new global::System.Windows.Forms.Panel();
			this.labTask = new global::System.Windows.Forms.Label();
			this.panMain = new global::System.Windows.Forms.Panel();
			this.picMain = new global::System.Windows.Forms.PictureBox();
			this.labPerson = new global::System.Windows.Forms.Label();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.panBottom.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panTasks.SuspendLayout();
			this.panMain.SuspendLayout();
			this.picMain.SuspendLayout();
			base.SuspendLayout();
			this.panBottom.Controls.Add(this.labMinus);
			this.panBottom.Controls.Add(this.labPlus);
			this.panBottom.Controls.Add(this.panel4);
			this.panBottom.Controls.Add(this.labTrash);
			this.panBottom.Controls.Add(this.labNewHire);
			this.panBottom.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panBottom.Location = new global::System.Drawing.Point(0, 163);
			this.panBottom.Name = "panBottom";
			this.panBottom.Size = new global::System.Drawing.Size(796, 112);
			this.panBottom.TabIndex = 2;
			this.labMinus.AllowDrop = true;
			this.labMinus.Image = (global::System.Drawing.Image)resourceManager.GetObject("labMinus.Image");
			this.labMinus.ImageAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.labMinus.Location = new global::System.Drawing.Point(408, 56);
			this.labMinus.Name = "labMinus";
			this.labMinus.Size = new global::System.Drawing.Size(16, 20);
			this.labMinus.TabIndex = 4;
			this.labMinus.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.labMinus.Visible = false;
			this.labPlus.AllowDrop = true;
			this.labPlus.Image = (global::System.Drawing.Image)resourceManager.GetObject("labPlus.Image");
			this.labPlus.ImageAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.labPlus.Location = new global::System.Drawing.Point(408, 28);
			this.labPlus.Name = "labPlus";
			this.labPlus.Size = new global::System.Drawing.Size(16, 20);
			this.labPlus.TabIndex = 3;
			this.labPlus.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.labPlus.Visible = false;
			this.panel4.Controls.Add(this.groupBox1);
			this.panel4.Controls.Add(this.btnHelp);
			this.panel4.Controls.Add(this.btnCancel);
			this.panel4.Controls.Add(this.btnOK);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel4.Location = new global::System.Drawing.Point(444, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(352, 112);
			this.panel4.TabIndex = 2;
			this.groupBox1.Controls.Add(this.labWeeklyPayroll);
			this.groupBox1.Controls.Add(this.labWage);
			this.groupBox1.Controls.Add(this.labHours);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new global::System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(192, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Weekly Payroll";
			this.labWeeklyPayroll.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.labWeeklyPayroll.Location = new global::System.Drawing.Point(120, 72);
			this.labWeeklyPayroll.Name = "labWeeklyPayroll";
			this.labWeeklyPayroll.Size = new global::System.Drawing.Size(56, 13);
			this.labWeeklyPayroll.TabIndex = 5;
			this.labWeeklyPayroll.Text = "#";
			this.labWeeklyPayroll.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labWage.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.labWage.Location = new global::System.Drawing.Point(120, 48);
			this.labWage.Name = "labWage";
			this.labWage.Size = new global::System.Drawing.Size(56, 13);
			this.labWage.TabIndex = 4;
			this.labWage.Text = "#";
			this.labWage.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labHours.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.labHours.Location = new global::System.Drawing.Point(120, 24);
			this.labHours.Name = "labHours";
			this.labHours.Size = new global::System.Drawing.Size(56, 13);
			this.labHours.TabIndex = 3;
			this.labHours.Text = "#";
			this.labHours.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label4.Location = new global::System.Drawing.Point(16, 72);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(104, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Weekly Payroll:";
			this.label3.Location = new global::System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(104, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Avg. Wage/Hour:";
			this.label2.Location = new global::System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(104, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Total Hours/Wk:";
			this.btnHelp.Location = new global::System.Drawing.Point(248, 80);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new global::System.Drawing.Size(96, 24);
			this.btnHelp.TabIndex = 5;
			this.btnHelp.Text = "Help";
			this.btnHelp.Click += new global::System.EventHandler(this.btnHelp_Click);
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new global::System.Drawing.Point(248, 48);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnOK.Location = new global::System.Drawing.Point(248, 16);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.labTrash.AllowDrop = true;
			this.labTrash.Image = (global::System.Drawing.Image)resourceManager.GetObject("labTrash.Image");
			this.labTrash.ImageAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.labTrash.Location = new global::System.Drawing.Point(160, 32);
			this.labTrash.Name = "labTrash";
			this.labTrash.Size = new global::System.Drawing.Size(56, 56);
			this.labTrash.TabIndex = 1;
			this.labTrash.Text = "Fire";
			this.labTrash.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.labTrash.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.labTrash_DragEnter);
			this.labTrash.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.labTrash_DragDrop);
			this.labNewHire.Image = (global::System.Drawing.Image)resourceManager.GetObject("labNewHire.Image");
			this.labNewHire.ImageAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.labNewHire.Location = new global::System.Drawing.Point(24, 24);
			this.labNewHire.Name = "labNewHire";
			this.labNewHire.Size = new global::System.Drawing.Size(64, 64);
			this.labNewHire.TabIndex = 0;
			this.labNewHire.Text = "New Hire";
			this.labNewHire.TextAlign = global::System.Drawing.ContentAlignment.BottomCenter;
			this.labNewHire.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.labNewHire_MouseDown);
			this.panTasks.Controls.Add(this.labTask);
			this.panTasks.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panTasks.Location = new global::System.Drawing.Point(0, 0);
			this.panTasks.Name = "panTasks";
			this.panTasks.Size = new global::System.Drawing.Size(120, 163);
			this.panTasks.TabIndex = 0;
			this.labTask.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labTask.Location = new global::System.Drawing.Point(8, 16);
			this.labTask.Name = "labTask";
			this.labTask.Size = new global::System.Drawing.Size(104, 24);
			this.labTask.TabIndex = 0;
			this.labTask.Text = "label1sdf asdf sadf dsgfadg adsfg  ";
			this.labTask.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.panMain.AutoScroll = true;
			this.panMain.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.panMain.Controls.Add(this.picMain);
			this.panMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panMain.Location = new global::System.Drawing.Point(120, 0);
			this.panMain.Name = "panMain";
			this.panMain.Size = new global::System.Drawing.Size(676, 163);
			this.panMain.TabIndex = 1;
			this.picMain.BackColor = global::System.Drawing.SystemColors.Control;
			this.picMain.Controls.Add(this.labPerson);
			this.picMain.Location = new global::System.Drawing.Point(24, 0);
			this.picMain.Name = "picMain";
			this.picMain.Size = new global::System.Drawing.Size(288, 160);
			this.picMain.TabIndex = 2;
			this.picMain.TabStop = false;
			this.picMain.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.picMain_DragEnter);
			this.picMain.Paint += new global::System.Windows.Forms.PaintEventHandler(this.picMain_Paint);
			this.picMain.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.picMain_DragDrop);
			this.labPerson.Image = (global::System.Drawing.Image)resourceManager.GetObject("labPerson.Image");
			this.labPerson.Location = new global::System.Drawing.Point(242, 153);
			this.labPerson.Name = "labPerson";
			this.labPerson.Size = new global::System.Drawing.Size(32, 31);
			this.labPerson.TabIndex = 3;
			this.labPerson.Text = "label1";
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(796, 275);
			base.Controls.Add(this.panMain);
			base.Controls.Add(this.panTasks);
			base.Controls.Add(this.panBottom);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmStaffingSimple";
			base.ShowInTaskbar = false;
			this.Text = "Staffing";
			this.panBottom.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panTasks.ResumeLayout(false);
			this.panMain.ResumeLayout(false);
			this.picMain.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.Panel panMain;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.Label labTrash;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Button btnHelp;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Button btnOK;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label labNewHire;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Label labHours;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Label labWage;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label labWeeklyPayroll;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Label labTask;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Panel panTasks;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Panel panBottom;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.PictureBox picMain;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label labPerson;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Label labPlus;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Label labMinus;

		// Token: 0x04000018 RID: 24
		private global::System.ComponentModel.IContainer components;
	}
}
