using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmRadio.
	/// </summary>
	// Token: 0x02000009 RID: 9
	public partial class frmRadio : Form
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <exception cref="T:System.Net.Sockets.SocketException">Thrown if host session is disconnected in multiplayer mode</exception>
		/// <exception cref="T:KMI.Sim.EntityNotFoundException">Thrown if entity has gone away before this action can be processed</exception>
		// Token: 0x06000020 RID: 32 RVA: 0x00003D7C File Offset: 0x00002D7C
		public frmRadio()
		{
			this.InitializeComponent();
			this.input = A.SA.GetRadio(A.MF.CurrentEntityID);
			for (int i = 0; i < this.input.RadioStations.Length; i++)
			{
				RadioStationControl c = new RadioStationControl();
				c.RadioStation = this.input.RadioStations[i];
				c.Left = 200 * i;
				foreach (object obj in c.panChk.Controls)
				{
					CheckBox c2 = (CheckBox)obj;
					c2.Checked = this.input.Bookings[c.panChk.Controls.IndexOf(c2), i];
					c2.CheckedChanged += this.UpdateCost;
				}
				this.panMain.Controls.Add(c);
			}
			this.UpdateCost(new object(), new EventArgs());
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000446C File Offset: 0x0000346C
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (object obj in this.panMain.Controls)
				{
					RadioStationControl c = (RadioStationControl)obj;
					foreach (object obj2 in c.panChk.Controls)
					{
						CheckBox c2 = (CheckBox)obj2;
						this.input.Bookings[c.panChk.Controls.IndexOf(c2), this.panMain.Controls.IndexOf(c)] = c2.Checked;
					}
				}
				A.SA.SetRadio(A.MF.CurrentEntityID, this.input.Bookings);
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000045D8 File Offset: 0x000035D8
		private void UpdateCost(object sender, EventArgs e)
		{
			int rotations = 0;
			float cost = 0f;
			foreach (object obj in this.panMain.Controls)
			{
				RadioStationControl c = (RadioStationControl)obj;
				foreach (object obj2 in c.panChk.Controls)
				{
					CheckBox c2 = (CheckBox)obj2;
					if (c2.Checked)
					{
						rotations++;
						cost += (float)c.RadioStation.Reach * 20f / 1000f;
					}
				}
			}
			this.labRotations.Text = rotations.ToString();
			this.labTotalCost.Text = Utilities.FC(cost, A.I.CurrencyConversion);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00004714 File Offset: 0x00003714
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Radio Advertising");
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00004722 File Offset: 0x00003722
		private void frmRadio_Closed(object sender, EventArgs e)
		{
			Sound.StopMidi();
		}

		// Token: 0x0400002F RID: 47
		private frmRadio.Input input;

		// Token: 0x0200000A RID: 10
		[Serializable]
		public struct Input
		{
			// Token: 0x04000030 RID: 48
			public RadioStation[] RadioStations;

			// Token: 0x04000031 RID: 49
			public bool[,] Bookings;
		}
	}
}
