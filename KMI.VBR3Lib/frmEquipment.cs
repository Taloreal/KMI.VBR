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
	// Token: 0x02000021 RID: 33
	public partial class frmEquipment : Form
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <exception cref="T:System.Net.Sockets.SocketException">Thrown if host session is disconnected in multiplayer mode</exception>
		/// <exception cref="T:KMI.Sim.EntityNotFoundException">Thrown if entity has gone away before this action can be processed</exception>
		// Token: 0x060000D7 RID: 215 RVA: 0x0000C98C File Offset: 0x0000B98C
		public frmEquipment()
		{
			this.InitializeComponent();
			this.updRegisters.Value = A.SA.GetEquipment(A.MF.CurrentEntityID);
			this.labRegCost.Text = A.R.GetString(this.labRegCost.Text, new object[]
			{
				Utilities.FC(40f, A.I.CurrencyConversion)
			});
			this.labCamCost.Text = A.R.GetString(this.labCamCost.Text, new object[]
			{
				Utilities.FC(25f, A.I.CurrencyConversion)
			});
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000D13C File Offset: 0x0000C13C
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				A.SA.SetEquipment(A.MF.CurrentEntityID, (int)this.updRegisters.Value);
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000D198 File Offset: 0x0000C198
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}
	}
}
