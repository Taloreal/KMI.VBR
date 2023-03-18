using System;
using System.Collections;
using KMI.Sim;
using KMI.Utility;

namespace KMI.Biz.Product
{
	// Token: 0x02000015 RID: 21
	[Serializable]
	public class Order
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00008430 File Offset: 0x00007430
		public string GetDescription(ProductType[] productTypes)
		{
			string text = "";
			foreach (object obj in this.Items)
			{
				Item item = (Item)obj;
				text = text + productTypes[item.Cat].Name.ToLower() + ", ";
			}
			return S.R.GetString("The order includes {0}.", new object[]
			{
				Utilities.FormatCommaSeriesDuplicatesToNumbers(text)
			});
		}

		// Token: 0x040000B8 RID: 184
		public CustomerBase Customer;

		// Token: 0x040000B9 RID: 185
		public int OrderNumber;

		// Token: 0x040000BA RID: 186
		public DateTime OrderDateTime;

		// Token: 0x040000BB RID: 187
		public bool Electronic;

		// Token: 0x040000BC RID: 188
		public DateTime NeededBy;

		// Token: 0x040000BD RID: 189
		public ArrayList Items = new ArrayList();

		// Token: 0x040000BE RID: 190
		public ArrayList ItemsShipped = new ArrayList();

		// Token: 0x040000BF RID: 191
		public ArrayList NotInStock = new ArrayList();
	}
}
