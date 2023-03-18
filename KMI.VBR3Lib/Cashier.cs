using System;
using System.Collections;
using System.Drawing;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Cashier.
	/// </summary>
	// Token: 0x0200001A RID: 26
	[Serializable]
	public class Cashier : Person
	{
		// Token: 0x060000AA RID: 170 RVA: 0x0000A844 File Offset: 0x00009844
		public Cashier(Floor parent, int index)
		{
			this.Parent = parent;
			base.Location = this.Parent.Parent.RegisterLocation(index);
			base.Location = new PointF(base.Location.X, base.Location.Y - 10f);
			if (base.Gender == Person.GenderType.Female)
			{
				this.genderString = "F";
			}
			this.raceString = (new string[]
			{
				"B",
				"C",
				"H"
			})[(int)this.race];
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000A900 File Offset: 0x00009900
		public ArrayList GetDrawables()
		{
			ArrayList d = new ArrayList();
			string name = "W" + this.genderString + "S" + this.raceString;
			d.Add(new PageDrawable(base.Location, name, this.DefaultComment())
			{
				Row = 1
			});
			return d;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000A958 File Offset: 0x00009958
		public string DefaultComment()
		{
			int cashiers = Math.Max(1, this.Parent.Parent.Cashiers.Count);
			int lineLength = 0;
			foreach (object obj in this.Parent.Parent.Customers)
			{
				Customer c = (Customer)obj;
				if (c.State == Customer.States.NextToBeServed || c.State == Customer.States.ToLine)
				{
					lineLength++;
				}
			}
			string @string;
			if (lineLength / cashiers > 6)
			{
				@string = A.R.GetString("Hey, Boss! I'm getting killed out here.  Get some more help!");
			}
			else if (lineLength / cashiers > 3)
			{
				@string = A.R.GetString("This pace is OK, but I hope it doesn't get much busier, or we'll be swamped.");
			}
			else
			{
				@string = A.R.GetString("Wow!  What an easy job.  I can't believe they pay me for this.  Maybe I'll get a little homework done.");
			}
			return @string;
		}

		// Token: 0x040000A1 RID: 161
		public Floor Parent;

		// Token: 0x040000A2 RID: 162
		protected string genderString = "M";

		// Token: 0x040000A3 RID: 163
		protected string raceString;

		// Token: 0x040000A4 RID: 164
		public Customer LockedBy;
	}
}
