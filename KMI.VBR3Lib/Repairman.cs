using System;
using System.Collections;
using KMI.Sim;
using KMI.Sim.Drawables;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// Summary description for Repairman.
	/// </summary>
	// Token: 0x0200001C RID: 28
	[Serializable]
	public class Repairman : Person
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x0000AC0C File Offset: 0x00009C0C
		public Repairman(AppEntity entity, SectionBase sb, int hours)
		{
			this.Entity = entity;
			this.Equip = sb;
			base.Speed = 8f;
			A.I.Subscribe(this, A.ST.Now.AddHours((double)hours));
			this.raceString = (new string[]
			{
				"B",
				"C",
				"H"
			})[(int)this.race];
			if (this.raceString == "H")
			{
				this.genderString = "F";
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000ACC8 File Offset: 0x00009CC8
		public override bool NewStep()
		{
			switch (this.State)
			{
			case Repairman.States.Init:
				if (this.Equip is CoolingDuct)
				{
					this.Entity.Backroom.Repairmen.Add(this);
					this.map = this.Entity.Backroom.Map;
				}
				else
				{
					this.Entity.Floor.Repairmen.Add(this);
					this.map = this.Entity.Floor.Map;
				}
				base.Location = this.map.getNode("EX0").Location;
				base.Path = this.map.findPath(base.Location, this.Equip.node.name).ToPoints();
				this.State = Repairman.States.ToEquip;
				break;
			case Repairman.States.ToEquip:
				if (this.Move())
				{
					this.State = Repairman.States.FixEquip;
				}
				break;
			case Repairman.States.FixEquip:
				if (this.Counter-- < 0)
				{
					this.Equip.Broken = false;
					base.Path = this.map.findPath(base.Location, "EX0").ToPoints();
					this.State = Repairman.States.Exit;
				}
				break;
			case Repairman.States.Exit:
				if (this.Move())
				{
					this.Entity.Floor.Repairmen.Remove(this);
					this.Entity.Backroom.Repairmen.Remove(this);
					A.I.UnSubscribe(this);
				}
				break;
			}
			return false;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000AE88 File Offset: 0x00009E88
		public ArrayList GetDrawables()
		{
			ArrayList temp = new ArrayList();
			string WalkFix = "W";
			if (this.State == Repairman.States.FixEquip)
			{
				WalkFix = "F";
			}
			string name = "R" + this.genderString + WalkFix + this.raceString;
			PageDrawable pd = new PageDrawable(base.Location, name, "");
			bool flipX = false;
			pd.Row = base.OrientationIndexWithFlip(ref flipX);
			if (this.State == Repairman.States.FixEquip)
			{
				pd.Row = 0;
			}
			pd.FlipX = flipX;
			pd.Col = A.ST.FrameCounter % 9;
			temp.Add(pd);
			return temp;
		}

		// Token: 0x040000B0 RID: 176
		private MapV2 map;

		// Token: 0x040000B1 RID: 177
		private string raceString;

		// Token: 0x040000B2 RID: 178
		private string genderString = "M";

		// Token: 0x040000B3 RID: 179
		public Repairman.States State = Repairman.States.Init;

		// Token: 0x040000B4 RID: 180
		public AppEntity Entity;

		// Token: 0x040000B5 RID: 181
		public SectionBase Equip;

		// Token: 0x040000B6 RID: 182
		public int Counter = 400;

		// Token: 0x0200001D RID: 29
		public enum States
		{
			// Token: 0x040000B8 RID: 184
			Init,
			// Token: 0x040000B9 RID: 185
			ToEquip,
			// Token: 0x040000BA RID: 186
			FixEquip,
			// Token: 0x040000BB RID: 187
			Exit
		}
	}
}
