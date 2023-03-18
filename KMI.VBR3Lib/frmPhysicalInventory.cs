using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmPhysicalInventory.
	/// </summary>
	// Token: 0x02000004 RID: 4
	public partial class frmPhysicalInventory : Form
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <exception cref="T:System.Net.Sockets.SocketException">Thrown if host session is disconnected in multiplayer mode</exception>
		/// <exception cref="T:KMI.Sim.EntityNotFoundException">Thrown if entity has gone away before this action can be processed</exception>
		// Token: 0x0600000F RID: 15 RVA: 0x00002904 File Offset: 0x00001904
		public frmPhysicalInventory()
		{
			this.InitializeComponent();
			this.labCost.Text = string.Format(this.labCost.Text, Utilities.FC(250f, A.I.CurrencyConversion));
			this.updFrequency.Value = A.SA.GetPhysicalInventory(A.MF.CurrentEntityID);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002EA8 File Offset: 0x00001EA8
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				A.SA.SetPhysicalInventory(A.MF.CurrentEntityID, (int)this.updFrequency.Value);
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
				return;
			}
			base.Close();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002F04 File Offset: 0x00001F04
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Physical Inventory");
		}
	}
}
