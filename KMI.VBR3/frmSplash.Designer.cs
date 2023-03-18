namespace KMI.VBR3
{
	/// <summary>
	/// The purpose of frmSplash is to display a splash screen quickly.
	/// Therefore, it is the only thing in the application's executable.
	/// All other functionality is located in one or more dlls.
	/// To modify frmSplash for your application:
	/// Step 1: Insert your own this.BackgroundImage in design mode.
	/// Step 2: If necessary, move labVersion over a white area.
	/// Step 3: In timer1_Tick, make call to load bulk of application and show main form and startchoices.
	/// Step 4: Add a project reference to your main application dll, KMI.Sim.dll, KMI.Utility.dll, and other dependencies.
	/// </summary>
	// Token: 0x02000002 RID: 2
	public partial class frmSplash : global::System.Windows.Forms.Form
	{
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		// Token: 0x06000002 RID: 2 RVA: 0x000020BC File Offset: 0x000010BC
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
		// Token: 0x06000003 RID: 3 RVA: 0x000020F8 File Offset: 0x000010F8
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.Resources.ResourceManager resources = new global::System.Resources.ResourceManager(typeof(global::KMI.VBR3.frmSplash));
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.labVersion = new global::System.Windows.Forms.Label();
			this.labCopyright = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.timer1.Interval = 50;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.labVersion.BackColor = global::System.Drawing.Color.White;
			this.labVersion.Location = new global::System.Drawing.Point(40, 56);
			this.labVersion.Name = "labVersion";
			this.labVersion.Size = new global::System.Drawing.Size(144, 16);
			this.labVersion.TabIndex = 1;
			this.labVersion.Text = "Version ";
			this.labCopyright.BackColor = global::System.Drawing.Color.White;
			this.labCopyright.Location = new global::System.Drawing.Point(32, 256);
			this.labCopyright.Name = "labCopyright";
			this.labCopyright.Size = new global::System.Drawing.Size(240, 40);
			this.labCopyright.TabIndex = 2;
			this.labCopyright.Text = "Copyright 1999-2009 Knowledge Matters, Inc. All rights reserved worldwide.";
			this.labCopyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			this.BackgroundImage = (global::System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			base.ClientSize = new global::System.Drawing.Size(500, 320);
			base.Controls.Add(this.labCopyright);
			base.Controls.Add(this.labVersion);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmSplash";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmSplashAbout";
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.Label labVersion;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.Label labCopyright;

		// Token: 0x04000004 RID: 4
		private global::System.ComponentModel.IContainer components;
	}
}
