using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using KMI.VBR3Lib;

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
	public partial class frmSplash : Form
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="args">The arguments passed to the
		/// application.</param>
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public frmSplash(string[] args)
		{
			this.InitializeComponent();
			this.args = args;
			Label label = this.labVersion;
			label.Text += Application.ProductVersion;
			this.timer1.Start();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		// Token: 0x06000004 RID: 4 RVA: 0x000022F8 File Offset: 0x000012F8
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				Application.ThreadException += frmSplash.Application_ThreadException;
				Application.Run(new frmSplash(args));
			}
			catch (Exception exception)
			{
				frmMain.HandleError(exception);
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002348 File Offset: 0x00001348
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			frmMain.HandleError(e.Exception);
		}

		/// <summary>
		/// Event handler for the splash form's timer.  Maintain's
		/// the splash screen display for a set interval of time
		/// and loads the application.
		/// </summary>
		// Token: 0x06000006 RID: 6 RVA: 0x00002358 File Offset: 0x00001358
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.timer1.Stop();
			if (this.exit)
			{
				Application.Exit();
			}
			else
			{
				DateTime startTime = DateTime.Now;
				frmMain f = new frmMain(this.args, this.demo, this.vbc, this.academic);
				int splashTime = 0;
				int millisecondsRemaining = splashTime - (DateTime.Now - startTime).Milliseconds;
				if (millisecondsRemaining > 0)
				{
					Thread.Sleep(millisecondsRemaining);
				}
				base.Hide();
				f.Show();
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000023F0 File Offset: 0x000013F0
		private void DrawTrialText(string message)
		{
			Graphics graphics = Graphics.FromImage(this.BackgroundImage);
			int alpha = 122;
			Color hazy = Color.FromArgb(alpha, Color.White);
			Rectangle textBounds = new Rectangle(20, 150, 460, 100);
			Brush brush = new SolidBrush(hazy);
			graphics.FillRectangle(brush, textBounds);
			brush = new SolidBrush(Color.Red);
			StringFormat stringFormat = new StringFormat();
			stringFormat.LineAlignment = StringAlignment.Center;
			stringFormat.Alignment = StringAlignment.Near;
			Font font = new Font("Microsoft Sans Serif", 20f);
			graphics.DrawString(message, font, brush, textBounds, stringFormat);
		}

		/// <summary>
		/// The arguments passed to the application.
		/// </summary>
		// Token: 0x04000005 RID: 5
		private string[] args;

		// Token: 0x04000006 RID: 6
		private bool exit = false;

		// Token: 0x04000007 RID: 7
		protected bool demo = false;

		// Token: 0x04000008 RID: 8
		protected bool vbc = false;

		// Token: 0x04000009 RID: 9
		protected bool academic = false;
	}
}
