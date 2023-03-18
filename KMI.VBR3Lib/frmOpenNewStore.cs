using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz.City;
using KMI.Biz.Product;
using KMI.Biz.Staffing;
using KMI.Sim;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for frmOpenNewStore.
	/// </summary>
	// Token: 0x0200001F RID: 31
	public partial class frmOpenNewStore : Form, IActionForm
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000B754 File Offset: 0x0000A754
		public frmOpenNewStore()
		{
			this.InitializeComponent();
			this.input = A.SA.GetOpenNewEntity(A.I.ThisPlayerName);
			if (this.input.Multiplayer)
			{
				if (this.input.EntitiesOwnedNames.Length == 0)
				{
					this.txtName.Text = Simulator.Instance.ThisPlayerName;
				}
				else
				{
					int i = 2;
					while (!A.SA.IsUniqueEntityName(Simulator.Instance.ThisPlayerName + " " + i))
					{
						i++;
					}
					this.txtName.Text = Simulator.Instance.ThisPlayerName + " " + i;
				}
				if (this.input.Rolebased)
				{
					this.optWizard.Enabled = false;
					this.optManual.Checked = true;
				}
				this.txtName.Enabled = false;
			}
			if (this.input.EntitiesOwnedNames.Length == 0)
			{
				this.updCapital.Value = (decimal)this.input.Savings;
				this.updCapital.Enabled = false;
				this.cboCapital.Enabled = false;
			}
			else
			{
				this.updCapital.Value = 5000m;
				foreach (string entityName in this.input.EntitiesOwnedNames)
				{
					this.cboCapital.Items.Add(entityName);
				}
				this.cboCapital.SelectedIndex = 0;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000B960 File Offset: 0x0000A960
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x0000B978 File Offset: 0x0000A978
		public BuildingDrawable SelectedBuilding
		{
			get
			{
				return this.selectedBuilding;
			}
			set
			{
				this.selectedBuilding = value;
				float rent = AppBuilding.RentFromReach(this.selectedBuilding.Reach);
				this.labRent.Text = Utilities.FC(rent, A.I.CurrencyConversion);
				this.labMonthlyRent.Text = Utilities.FC(rent * 4f, A.I.CurrencyConversion);
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000C3D8 File Offset: 0x0000B3D8
		private void btnOK_Click(object sender, EventArgs e)
		{
			float capital = (float)this.updCapital.Value;
			if (this.selectedBuilding == null)
			{
				string message = A.R.GetString("You must select a store location first.  Click on any available store.");
				string title = A.R.GetString("No Store Selected");
				MessageBox.Show(message, title);
			}
			else if (this.txtName.Text == null || this.txtName.Text == "")
			{
				string message = A.R.GetString("You must name your store.  Please type your store's name.");
				string title = A.R.GetString("Store Not Named");
				MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				try
				{
					long entityID;
					if (A.MF.DesignerMode && MessageBox.Show("Do you want to open a competitor store?", "Add New Store", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						string playerName = Guid.NewGuid().ToString();
						Player player = A.SA.CreatePlayer(playerName, PlayerType.AI);
						entityID = A.SA.TryAddEntity(playerName, this.txtName.Text, this.selectedBuilding.Avenue, this.selectedBuilding.Street, this.selectedBuilding.Lot, A.SS.InitialAICapital, null);
						this.optWizard.Checked = false;
					}
					else
					{
						string capitalSourceName = null;
						if (this.cboCapital.Enabled)
						{
							capitalSourceName = this.cboCapital.SelectedItem.ToString();
						}
						entityID = A.SA.TryAddEntity(A.I.ThisPlayerName, this.txtName.Text, this.selectedBuilding.Avenue, this.selectedBuilding.Street, this.selectedBuilding.Lot, capital, capitalSourceName);
					}
					A.MF.OnCurrentEntityChange(entityID);
					A.MF.BringToFront();
					A.MF.UpdateView();
					base.Close();
					if (this.optWizard.Checked)
					{
						Type[] formTypes = new Type[]
						{
							typeof(frmStaffingSimple),
							typeof(frmAutoLayout),
							typeof(frmPurchasing),
							typeof(frmPricing),
							typeof(frmRadio)
						};
						Resource r = Simulator.Instance.Resource;
						string[] formTitles = new string[]
						{
							r.GetString("Staffing"),
							r.GetString("Layout"),
							r.GetString("Purchasing"),
							r.GetString("Pricing"),
							r.GetString("Promotion")
						};
						string[] formText = new string[]
						{
							r.GetString("Welcome! This wizard will guide you’re the most critical steps in getting your business going.\n\nDon’t worry…the decisions you make can all be changed later on by using the commands on the Actions menu."),
							r.GetString("You can’t run a business without employees!\n\nClick the button below to open the Staffing window. This window lets you add both cashiers and shelf stockers.\n\nNote: Anytime there are no cashiers working, your store is closed."),
							r.GetString("You'll need fixtures to display the products in your store. \n\nClick the button below to choose between a basic initial layout or a blank layout that you will design later.\n\nNote: You can edit the basic layout later."),
							r.GetString("Before you can sell product, you need to purchase it!\n\nClick below to open the Purchasing window. Use the slide bar to set your purchasing level across all products."),
							r.GetString("Price too high, no one will buy. Price too low, out of business you go!\n\nClick the button below to open the Pricing window. Use the slide bar to set prices across all your products."),
							r.GetString("Customers won’t come to a store they don’t know about!\n\nYou’ll have lots of promotional choices. Try starting with a little radio advertising."),
							r.GetString("Congratulations! Your store is now setup to operate. With the simulation running, you should see employees, products, and customers. Making a profit may still take some adjustment!\n\nAnd remember...look under the Actions menu if you want to change anything you just selected.")
						};
						object[] staffingArgs = new object[]
						{
							A.R.GetImage("StaffingPic"),
							AppConstants.TaskNames,
							AppConstants.ShiftStartHours,
							AppConstants.ShiftLengths,
							AppConstants.MaxEmployees,
							AppConstants.Wages
						};
						object[] purchasingArgs = new object[]
						{
							AppConstants.ProductTypes,
							-1,
							25000
						};
						object[] pricingArgs = new object[]
						{
							AppConstants.ProductTypes,
							-1,
							false
						};
						object[] args = new object[]
						{
							staffingArgs,
							new object[0],
							purchasingArgs,
							pricingArgs,
							new object[0]
						};
						frmSetupWizard f = new frmSetupWizard(formTypes, args, formTitles, formText);
						f.ShowDialog(A.MF);
					}
					if (A.MF.SoundOn)
					{
						Sound.PlaySoundFromFile("sounds\\Build.wav");
					}
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex, this);
				}
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000C860 File Offset: 0x0000B860
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000C86C File Offset: 0x0000B86C
		private void frmOpenNewStore_Load(object sender, EventArgs e)
		{
			try
			{
				SimSettings ss = A.SA.getSimSettings();
				if (ss.LevelManagementOn)
				{
					if (ss.Level == 1 && this.input.EntitiesOwnedNames.Length > 0)
					{
						MessageBox.Show(A.R.GetString("You can open only one store in Level 1.", new object[]
						{
							Application.ProductName
						}));
						base.Close();
					}
					else if (ss.Level == 2 && this.input.EntitiesOwnedNames.Length > 1)
					{
						MessageBox.Show(A.R.GetString("You can open only two stores in Level 2.", new object[]
						{
							Application.ProductName
						}));
						base.Close();
					}
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex, this);
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000C960 File Offset: 0x0000B960
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp(this.Text);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000C96F File Offset: 0x0000B96F
		private void frmOpenNewStore_Closed(object sender, EventArgs e)
		{
			((CityView)A.I.Views[0]).Mode = CityView.Modes.Default;
		}

		// Token: 0x040000DB RID: 219
		protected BuildingDrawable selectedBuilding;

		// Token: 0x040000DC RID: 220
		public frmOpenNewStore.Input input;

		// Token: 0x02000020 RID: 32
		[Serializable]
		public struct Input
		{
			// Token: 0x040000DD RID: 221
			public bool Multiplayer;

			// Token: 0x040000DE RID: 222
			public bool Rolebased;

			// Token: 0x040000DF RID: 223
			public float Savings;

			// Token: 0x040000E0 RID: 224
			public string[] EntitiesOwnedNames;
		}
	}
}
