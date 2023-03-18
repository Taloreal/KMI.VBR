using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using KMI.Biz.City;
using KMI.Sim;
using KMI.Sim.Drawables;
using KMI.Utility;

namespace KMI.VBR3Lib
{
	/// <summary>
	/// An example View for an application.
	/// </summary>
	// Token: 0x02000026 RID: 38
	public class CityView : KMI.Sim.View
	{
		/// <summary>
		/// Contructs a new instance of this View with the given name
		/// and background image.
		/// </summary>
		/// <param name="name">The name for this View as it is to
		/// appear in the application.</param>
		/// <param name="background">The background image to use
		/// for this View in the application.</param>
		// Token: 0x060000EE RID: 238 RVA: 0x0000E628 File Offset: 0x0000D628
		public CityView(string name, Bitmap background) : base(name, background)
		{
			City.NUM_AVENUES = 9;
			City.NUM_STREETS = 18;
			City.LOTS_PER_BLOCK = new int[9];
			City.BLOCK_HEIGHTS = new float[9];
			City.AVENUE_SPACING = new float[9];
			City.ORIGIN = new PointF(428f, 237f);
			City.WHOLE_CITY_OFFSET = new Point(243, -38);
			City.LOT_SPACING = 32f;
			City.STREET_SPACING = 65f;
			for (int i = 0; i < 9; i++)
			{
				City.LOTS_PER_BLOCK[i] = 3;
				City.AVENUE_SPACING[i] = 130.4f;
			}
			City.AVENUE_VIEWING_REGIONS = 3;
			City.STREET_VIEWING_REGIONS = 3;
			City.AVENUE_REGION_OFFSET = 1170;
			City.STREET_REGION_OFFSET = 1167;
			City.AVENUE_INVERSE_ADJUSTMENT = 65;
			City.STREET_INVERSE_ADJUSTMENT = 65;
			this.ViewerOptions = new object[]
			{
				1,
				1,
				false
			};
			CityView.snowResponse = new ResponseCurve();
			CityView.snowResponse.Points = new PointF[]
			{
				new PointF(-2f, 0f),
				new PointF(-1.5f, 5f),
				new PointF(-0.3f, 25f),
				new PointF(0f - 1, 2f),
				new PointF(1f, 0f)
			};
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000E808 File Offset: 0x0000D808
		public override Drawable[] BuildDrawables(long entityID, params object[] args)
		{
			ArrayList d = new ArrayList();
			int centerAvenue = (int)args[0];
			int centerStreet = (int)args[1];
			bool zoomed = (bool)args[2];
			if (zoomed)
			{
				d.Add(new Drawable(new Point(0, 0), "City"));
			}
			else
			{
				d.Add(new Drawable(new Point(0, 0), "CitySmall"));
			}
			int dy = 34;
			int dx = 100;
			int i = 0;
			d.Add(new TextDrawable(new Point(0, 0), A.R.GetString("Building Types:"), "Microsoft Sans Serif", 8, Color.Black));
			foreach (BuildingType bt in City.BuildingTypes)
			{
				int x = dx * (i / 4);
				int y = 16 + dy * (i % 4);
				if (i == 2)
				{
					y -= 7;
				}
				d.Add(new Drawable(new Point(x, y), "BuildingMedium" + i));
				d.Add(new TextDrawable(new Point(x + 36, y + 10), bt.Name, "Microsoft Sans Serif", 8, Color.Black));
				i++;
			}
			string playerName = A.I.ThisPlayerName;
			if (args.Length > 3)
			{
				playerName = (string)args[3];
			}
			int bx = 635;
			i = 1;
			Entity[] competitors = A.ST.GetOtherPlayersEntities(playerName);
			d.Add(new TextDrawable(new Point(bx, 0), A.R.GetString("Competitor Stores:"), "Microsoft Sans Serif", 8, Color.Black));
			foreach (AppEntity e in competitors)
			{
				d.Add(new RectangleDrawable(new Point(bx + 3, i * 16), new Size(12, 12), e.SignColor, true));
				d.Add(new TextDrawable(new Point(bx + 18, i * 16), e.Name, "Microsoft Sans Serif", 8, Color.Black));
				i++;
			}
			i = 1;
			Entity[] ourStores = A.ST.GetPlayersEntities(playerName);
			d.Add(new TextDrawable(new Point(bx, 335), A.R.GetString("Your Stores:"), "Microsoft Sans Serif", 8, Color.Black));
			foreach (AppEntity e in ourStores)
			{
				d.Add(new RectangleDrawable(new Point(bx + 3, 335 + i * 16), new Size(12, 12), e.SignColor, true));
				d.Add(new TextDrawable(new Point(bx + 18, 335 + i * 16), e.Name, "Microsoft Sans Serif", 8, Color.Black));
				i++;
			}
			if (zoomed)
			{
				d.AddRange(A.ST.OurCity.GetDrawablesCenteredOn(centerAvenue, centerStreet));
			}
			else
			{
				d.AddRange(A.ST.OurCity.GetDrawablesWholeCity());
			}
			TimeSpan ts = A.ST.NextStorm - A.ST.Now;
			float SnowIntensity = CityView.snowResponse.Response((float)ts.TotalDays);
			Console.WriteLine(string.Concat(new object[]
			{
				A.ST.Now.ToShortDateString(),
				" ",
				A.ST.Now.ToShortTimeString(),
				" ",
				ts.TotalDays,
				" ",
				SnowIntensity
			}));
			int j = 0;
			while ((float)j < SnowIntensity)
			{
				int offsetX = (int)((float)j / SnowIntensity * 39f);
				int offsetY = (int)((float)j / SnowIntensity * 74f);
				d.Add(new Drawable(new Point(20 - (offsetX + A.ST.FrameCounter) % 39, -30 + 2 * (offsetY + A.ST.FrameCounter) % 74), "Snow")
				{
					Hittable = false
				});
				j++;
			}
			return (Drawable[])d.ToArray(typeof(Drawable));
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000ECB0 File Offset: 0x0000DCB0
		public override void View_MouseMove(object sender, MouseEventArgs e)
		{
			Control c = (Control)sender;
			Drawable ch = KMI.Sim.View.currentHit;
			switch (this.Mode)
			{
			case CityView.Modes.Default:
				base.View_MouseMove(sender, e);
				if (this.Zoomed)
				{
					if (ch == null || ch.ClickString == "" || ch.ClickString == null)
					{
						c.Cursor = A.R.GetCursor("ZoomOut");
					}
				}
				else
				{
					int a = 0;
					int s = 0;
					int i = 0;
					if (City.InverseTransformWholeCity(new PointF((float)e.X, (float)e.Y), ref a, ref s, ref i) && (ch == null || ch.ClickString == "" || ch.ClickString == null))
					{
						c.Cursor = A.R.GetCursor("ZoomIn");
					}
				}
				break;
			case CityView.Modes.Billboard:
			{
				c.Cursor = A.R.GetCursor("NoBillboard");
				frmBillboard f = (frmBillboard)this.Form;
				if (ch is BuildingDrawable)
				{
					BuildingDrawable bd = (BuildingDrawable)ch;
					if (bd.BuildingType.CanTakeSign && (bd.BillboardOwnerName == null || bd.BillboardOwnerName == ""))
					{
						c.Cursor = A.R.GetCursor("Billboard");
						f.labReachPerWeek.Text = Utilities.FU((int)bd.Reach);
						f.labCostPerWeek.Text = Utilities.FC(bd.Reach * 75f / 1000f, A.I.CurrencyConversion);
						break;
					}
				}
				f.labReachPerWeek.Text = "";
				f.labCostPerWeek.Text = "";
				break;
			}
			case CityView.Modes.Mail:
				if (this.DragOn)
				{
					int a = this.endMailAvenue;
					int s = this.endMailStreet;
					int i = this.endMailLot;
					City.InverseTransformWholeCity(new PointF((float)e.X, (float)e.Y), ref this.endMailAvenue, ref this.endMailStreet, ref this.endMailLot);
					if (a != this.endMailAvenue || s != this.endMailStreet || i != this.endMailLot)
					{
						c.Refresh();
						c.CreateGraphics().DrawPolygon(new Pen(Color.Yellow, 2f), new Point[]
						{
							Point.Round(City.TransformWholeCity((float)this.beginMailAvenue, (float)this.beginMailStreet, (float)this.beginMailLot)),
							Point.Round(City.TransformWholeCity((float)this.beginMailAvenue, (float)this.endMailStreet, (float)this.beginMailLot)),
							Point.Round(City.TransformWholeCity((float)this.endMailAvenue, (float)this.endMailStreet, (float)this.endMailLot)),
							Point.Round(City.TransformWholeCity((float)this.endMailAvenue, (float)this.beginMailStreet, (float)this.endMailLot))
						});
					}
				}
				break;
			case CityView.Modes.NewStore:
			case CityView.Modes.MoveStore:
				c.Cursor = Cursors.Default;
				if (ch is BuildingDrawable)
				{
					BuildingDrawable bd = (BuildingDrawable)ch;
					if (bd.BuildingType == City.BuildingTypes[0] && bd.OwnerID == -1L)
					{
						c.Cursor = Cursors.Hand;
					}
				}
				break;
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000F088 File Offset: 0x0000E088
		public override void View_MouseDown(object sender, MouseEventArgs e)
		{
			CityView.Modes mode = this.Mode;
			if (mode != CityView.Modes.Mail)
			{
				base.View_MouseDown(sender, e);
			}
			else
			{
				City.InverseTransformWholeCity(new PointF((float)e.X, (float)e.Y), ref this.beginMailAvenue, ref this.beginMailStreet, ref this.beginMailLot);
				this.endMailAvenue = this.beginMailAvenue;
				this.endMailStreet = this.beginMailStreet;
				this.endMailLot = this.beginMailLot;
				this.DragOn = true;
				((frmMail)this.Form).optGeo.Checked = true;
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000F120 File Offset: 0x0000E120
		public override void View_MouseUp(object sender, MouseEventArgs e)
		{
			Drawable ch = KMI.Sim.View.currentHit;
			switch (this.Mode)
			{
			case CityView.Modes.Default:
				if (!(ch is BillboardDrawable))
				{
					if (this.Zoomed)
					{
						((CityView)A.I.Views[0]).ViewerOptions[2] = false;
						if (!A.I.Client)
						{
							A.ST.CityViewerOptions = ((CityView)A.I.Views[0]).ViewerOptions;
						}
						A.MF.UpdateView();
					}
					else
					{
						int a = -1;
						int s = -1;
						int i = -1;
						if (City.InverseTransformWholeCity(new PointF((float)e.X, (float)e.Y), ref a, ref s, ref i))
						{
							City.BoundCenteringAveAndStreet(ref a, ref s);
							KMI.Sim.View view = A.I.Views[0];
							view.ViewerOptions[0] = a;
							view.ViewerOptions[1] = s;
							view.ViewerOptions[2] = true;
							if (!A.I.Client)
							{
								A.ST.CityViewerOptions = view.ViewerOptions;
							}
							A.MF.UpdateView();
						}
					}
				}
				break;
			case CityView.Modes.Billboard:
				if (ch is BuildingDrawable)
				{
					BuildingDrawable bd = (BuildingDrawable)ch;
					if (bd.BuildingType.CanTakeSign && (bd.BillboardOwnerName == null || bd.BillboardOwnerName == ""))
					{
						try
						{
							A.SA.SetBillboard(A.MF.CurrentEntityID, bd.Avenue, bd.Street, bd.Lot);
							if (A.MF.SoundOn)
							{
								Sound.PlaySoundFromFile("sounds\\Build.wav");
							}
							this.Form.Close();
						}
						catch (Exception ex)
						{
							frmExceptionHandler.Handle(ex);
							break;
						}
						A.MF.UpdateView();
					}
				}
				break;
			case CityView.Modes.Mail:
			{
				this.DragOn = false;
				try
				{
					((frmMail)this.Form).List = A.SA.CreateMailingList(this.beginMailAvenue, this.beginMailStreet, this.beginMailLot, this.endMailAvenue, this.endMailStreet, this.endMailLot);
				}
				catch (Exception ex)
				{
					frmExceptionHandler.Handle(ex, this.Form);
				}
				Control c = (Control)sender;
				c.CreateGraphics().DrawPolygon(new Pen(Color.Yellow, 2f), new Point[]
				{
					Point.Round(City.TransformWholeCity((float)this.beginMailAvenue, (float)this.beginMailStreet, (float)this.beginMailLot)),
					Point.Round(City.TransformWholeCity((float)this.beginMailAvenue, (float)this.endMailStreet, (float)this.beginMailLot)),
					Point.Round(City.TransformWholeCity((float)this.endMailAvenue, (float)this.endMailStreet, (float)this.endMailLot)),
					Point.Round(City.TransformWholeCity((float)this.endMailAvenue, (float)this.beginMailStreet, (float)this.endMailLot))
				});
				break;
			}
			case CityView.Modes.NewStore:
				if (ch is BuildingDrawable)
				{
					BuildingDrawable bd = (BuildingDrawable)ch;
					if (bd.BuildingType == City.BuildingTypes[0] && bd.OwnerID == -1L)
					{
						((frmOpenNewStore)this.Form).SelectedBuilding = bd;
					}
				}
				break;
			case CityView.Modes.MoveStore:
				if (ch is BuildingDrawable)
				{
					BuildingDrawable bd = (BuildingDrawable)ch;
					if (bd.BuildingType == City.BuildingTypes[0] && bd.OwnerID == -1L)
					{
						((frmMoveStore)this.Form).SelectedBuilding = bd;
					}
				}
				break;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000F570 File Offset: 0x0000E570
		public bool Zoomed
		{
			get
			{
				return (bool)this.ViewerOptions[2];
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000F590 File Offset: 0x0000E590
		public Point OffsetToBuildingCenter(bool zoomed)
		{
			Point result;
			if (zoomed)
			{
				result = new Point(32, -40);
			}
			else
			{
				result = new Point(10, -12);
			}
			return result;
		}

		// Token: 0x0400010B RID: 267
		public static ResponseCurve snowResponse;

		// Token: 0x0400010C RID: 268
		public CityView.Modes Mode = CityView.Modes.Default;

		// Token: 0x0400010D RID: 269
		public int beginMailAvenue = -1;

		// Token: 0x0400010E RID: 270
		public int beginMailStreet = -1;

		// Token: 0x0400010F RID: 271
		public int beginMailLot = -1;

		// Token: 0x04000110 RID: 272
		public int endMailAvenue = -1;

		// Token: 0x04000111 RID: 273
		public int endMailStreet = -1;

		// Token: 0x04000112 RID: 274
		public int endMailLot = -1;

		// Token: 0x04000113 RID: 275
		public Form Form;

		// Token: 0x04000114 RID: 276
		public bool DragOn = false;

		// Token: 0x02000027 RID: 39
		public enum Modes
		{
			// Token: 0x04000116 RID: 278
			Default,
			// Token: 0x04000117 RID: 279
			Billboard,
			// Token: 0x04000118 RID: 280
			Mail,
			// Token: 0x04000119 RID: 281
			NewStore,
			// Token: 0x0400011A RID: 282
			MoveStore
		}
	}
}
