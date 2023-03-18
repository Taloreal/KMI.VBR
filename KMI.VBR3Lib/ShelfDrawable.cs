using System;
using System.Drawing;
using System.Windows.Forms;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for ItemDrawable.
	/// </summary>
	// Token: 0x02000007 RID: 7
	[Serializable]
	public class ShelfDrawable : PolygonDrawable
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00003421 File Offset: 0x00002421
		public ShelfDrawable(Point[] points, long shelfID, string rackType, int productTypeIndex) : base(points)
		{
			this.ShelfID = shelfID;
			this.RackType = rackType;
			this.clickString = " ";
			this.ProductTypeIndex = productTypeIndex;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003450 File Offset: 0x00002450
		public override void Drawable_Click(object sender, EventArgs e)
		{
			if (A.MF.mnuActionsMerchandising.Enabled)
			{
				PictureBox p = (PictureBox)sender;
				ContextMenu i = new ContextMenu();
				foreach (VBRProductType pt in AppConstants.ProductTypes)
				{
					MenuItem itm = new MenuItem(pt.Name, new EventHandler(this.AssignProduct));
					if (pt.Name == "Eggs" || pt.Name == "Whipped Cream")
					{
						i.MenuItems.Add(2, itm);
					}
					else
					{
						i.MenuItems.Add(itm);
					}
					if (this.ProductTypeIndex == pt.Index)
					{
						itm.Checked = true;
					}
					if (!A.I.Client && A.SS.RestrictFixtures)
					{
						itm.Enabled = (this.RackType == pt.RackType);
					}
				}
				i.MenuItems.Add("-");
				i.MenuItems.Add(A.R.GetString("Remove Fixture"), new EventHandler(this.AssignProduct));
				if (!A.I.Client && A.SS.RestrictFixtures)
				{
					i.MenuItems[i.MenuItems.Count - 1].Enabled = false;
				}
				i.Show(p, this.location);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000035FC File Offset: 0x000025FC
		private void AssignProduct(object sender, EventArgs e)
		{
			try
			{
				MenuItem i = (MenuItem)sender;
				if (i.Index < AppConstants.ProductTypes.Length)
				{
					VBRProductType pt = null;
					foreach (VBRProductType p in AppConstants.ProductTypes)
					{
						if (i.Text == p.Name)
						{
							pt = p;
						}
					}
					if (this.RackType == "" || pt.RackType == this.RackType || MessageBox.Show(A.R.GetString("This product requires a {0} which leases for {1} per week. Do you want to replace your {2} with a {0}? (Items on the {2} will be returned to the backroom.", new object[]
					{
						pt.RackType,
						Utilities.FC(SectionBase.RentForRackType(pt.RackType), A.I.CurrencyConversion),
						this.RackType
					}), A.R.GetString("Change Fixture"), MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						A.SA.ReassignShelf(A.MF.CurrentEntityID, "", this.ShelfID, pt.Index);
						A.MF.UpdateView();
					}
				}
				else if (MessageBox.Show(A.R.GetString("This will eliminate the fixture. Do you want to proceed?"), A.R.GetString("Remove Fixture"), MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					A.SA.ReassignShelf(A.MF.CurrentEntityID, "", this.ShelfID, i.Index);
					A.MF.UpdateView();
				}
			}
			catch (Exception ex)
			{
				frmExceptionHandler.Handle(ex);
			}
		}

		// Token: 0x04000022 RID: 34
		public long ShelfID;

		// Token: 0x04000023 RID: 35
		public string RackType;

		// Token: 0x04000024 RID: 36
		public int ProductTypeIndex;
	}
}
