using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200003C RID: 60
	public partial class frmLessonsSimple : Form
	{
		// Token: 0x06000246 RID: 582 RVA: 0x00012ACC File Offset: 0x00011ACC
		public frmLessonsSimple()
		{
			this.InitializeComponent();
			if (!Directory.Exists(Application.StartupPath + "\\Lessons\\"))
			{
				this.NoLessonsFound = true;
			}
			else
			{
				string[] files = Directory.GetFiles(Application.StartupPath + "\\Lessons\\", "*." + S.I.DataFileTypeExtension);
				if (files.Length == 0)
				{
					this.NoLessonsFound = true;
				}
				else
				{
					for (int i = 0; i < files.Length; i++)
					{
						files[i] = Path.GetFileNameWithoutExtension(files[i]);
					}
					Array.Sort(files, new frmLessonsSimple.LessonNameComparer());
					foreach (string text in files)
					{
						if (text.IndexOf(", Sim 1") > -1)
						{
							string text2 = text.Substring(0, text.IndexOf(", Sim "));
							this.lboLesson.Items.Add(text2);
							this.multiSimLessons.Add(text2, 1);
						}
						else if (text.IndexOf(", Sim ") == -1)
						{
							this.lboLesson.Items.Add(text);
						}
						else
						{
							string text2 = text.Substring(0, text.IndexOf(", Sim "));
							this.multiSimLessons[text2] = (int)this.multiSimLessons[text2] + 1;
						}
					}
				}
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00013224 File Offset: 0x00012224
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.lboLesson.SelectedIndex > -1)
			{
				if (this.lboSim.Visible)
				{
					if (this.lboSim.SelectedIndex <= -1)
					{
						MessageBox.Show(S.R.GetString("The lesson you selected has multiple sims associated with it. Please choose one below as directed in your assignment."), S.R.GetString("Choose a Sim"));
						return;
					}
					this.lessonFileName = string.Concat(new object[]
					{
						Application.StartupPath,
						"\\Lessons\\",
						(string)this.lboLesson.SelectedItem,
						", Sim ",
						this.lboSim.SelectedIndex + 1,
						".",
						S.I.DataFileTypeExtension
					});
				}
				else
				{
					this.lessonFileName = string.Concat(new string[]
					{
						Application.StartupPath,
						"\\Lessons\\",
						(string)this.lboLesson.SelectedItem,
						".",
						S.I.DataFileTypeExtension
					});
				}
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("Please choose a lesson or hit cancel.", "No Lesson Selected");
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00013372 File Offset: 0x00012372
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0001337C File Offset: 0x0001237C
		private void lboLesson_DoubleClick(object sender, EventArgs e)
		{
			this.btnOK.PerformClick();
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0001338C File Offset: 0x0001238C
		public string LessonFileName
		{
			get
			{
				return this.lessonFileName;
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x000133A4 File Offset: 0x000123A4
		private void frmLessonsSimple_Load(object sender, EventArgs e)
		{
			if (this.NoLessonsFound)
			{
				MessageBox.Show(S.R.GetString("No lessons found."), S.R.GetString("No Lessons Found"));
				base.Close();
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x000133EC File Offset: 0x000123EC
		private void lboLesson_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lboSim.Visible = this.multiSimLessons.ContainsKey(this.lboLesson.SelectedItem);
			this.labMultiSimLesson.Visible = this.lboSim.Visible;
			if (this.lboSim.Visible)
			{
				this.lboSim.Items.Clear();
				for (int i = 1; i <= (int)this.multiSimLessons[this.lboLesson.SelectedItem]; i++)
				{
					this.lboSim.Items.Add("Sim " + i);
				}
			}
		}

		// Token: 0x0400016E RID: 366
		private Hashtable multiSimLessons = new Hashtable();

		// Token: 0x04000176 RID: 374
		protected string lessonFileName;

		// Token: 0x04000177 RID: 375
		private bool NoLessonsFound = false;

		// Token: 0x0200003D RID: 61
		public class LessonNameComparer : IComparer
		{
			// Token: 0x0600024F RID: 591 RVA: 0x000134A8 File Offset: 0x000124A8
			public int Compare(object x1, object x2)
			{
				string text = (string)x1;
				string text2 = (string)x2;
				int result;
				if (text == text2)
				{
					result = 0;
				}
				else
				{
					string[] array = text.Split(new char[]
					{
						' '
					});
					string[] array2 = text2.Split(new char[]
					{
						' '
					});
					int num = int.Parse(array[1]);
					int num2 = int.Parse(array2[1]);
					if (num != num2)
					{
						result = num - num2;
					}
					else
					{
						int num3 = int.Parse(array[array.Length - 1]);
						int num4 = int.Parse(array2[array2.Length - 1]);
						result = num3 - num4;
					}
				}
				return result;
			}
		}
	}
}
