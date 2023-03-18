using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmServiceContracts.
	/// </summary>
	// Token: 0x0200001E RID: 30
	public partial class frmServiceContracts : Form
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x0000AF3C File Offset: 0x00009F3C
		public frmServiceContracts()
		{
			this.InitializeComponent();
			this.serviceContracts = A.SA.GetServiceContracts(A.MF.CurrentEntityID);
			int i = 0;
			foreach (object obj in this.serviceContracts.Values)
			{
				ServiceContract sc = (ServiceContract)obj;
				ServiceContractControl c = new ServiceContractControl();
				c.ServiceContract = sc;
				c.Location = new Point(0, i++ * c.Height);
				this.panel1.Controls.Add(c);
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000B6DC File Offset: 0x0000A6DC
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000B6E6 File Offset: 0x0000A6E6
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(A.R.GetString("Service and Repairs"));
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000B700 File Offset: 0x0000A700
		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				A.SA.SetServiceContracts(A.MF.CurrentEntityID, this.serviceContracts);
				base.Close();
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x040000C8 RID: 200
		public Hashtable serviceContracts;
	}
}
