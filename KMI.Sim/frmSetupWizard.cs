using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200006B RID: 107
	public partial class frmSetupWizard : Form
	{
		// Token: 0x060003EA RID: 1002 RVA: 0x0001CA78 File Offset: 0x0001BA78
		public frmSetupWizard(Type[] forms, object[] args, string[] titles, string[] text)
		{
			this.InitializeComponent();
			this.stepIndex = -1;
			this.currentType = null;
			this.formsToShow = forms;
			this.stepArgs = args;
			this.stepTitles = titles;
			this.stepText = text;
			this.stepArgTypes = new object[this.stepArgs.Length];
			int num = 0;
			foreach (object[] array2 in this.stepArgs)
			{
				ArrayList arrayList = new ArrayList();
				for (int j = 0; j < array2.Length; j++)
				{
					arrayList.Add(array2[j].GetType());
				}
				this.stepArgTypes[num++] = arrayList.ToArray(typeof(Type));
			}
			this.panTitles.Controls.Clear();
			for (int j = 0; j < this.stepTitles.Length; j++)
			{
				Label label = new Label();
				label.ForeColor = this.labTitle.ForeColor;
				label.Font = this.labTitle.Font;
				label.Location = new Point(this.labTitle.Left, this.labTitle.Top + j * 45);
				label.Size = this.labTitle.Size;
				label.Text = this.stepTitles[j];
				this.panTitles.Controls.Add(label);
			}
			this.UpdateWizard();
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0001D198 File Offset: 0x0001C198
		protected void UpdateWizard()
		{
			this.labText.Text = this.stepText[this.stepIndex + 1].Replace("\\n", "\n");
			if (this.stepIndex > -1 && this.stepIndex < this.panTitles.Controls.Count)
			{
				this.btnShow.Visible = true;
				this.btnShow.Text = "&Setup " + this.stepTitles[this.stepIndex];
			}
			else
			{
				this.btnShow.Visible = false;
			}
			this.btnBack.Enabled = (this.stepIndex > -1);
			this.btnNext.Enabled = (this.stepIndex < this.panTitles.Controls.Count);
			for (int i = 0; i < this.panTitles.Controls.Count; i++)
			{
				this.panTitles.Controls[i].ForeColor = Color.DarkBlue;
				if (i == this.stepIndex)
				{
					this.panTitles.Controls[i].ForeColor = Color.Yellow;
				}
			}
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0001D2E4 File Offset: 0x0001C2E4
		private void btnShow_Click(object sender, EventArgs e)
		{
			ConstructorInfo constructor = this.formsToShow[this.stepIndex].GetConstructor((Type[])this.stepArgTypes[this.stepIndex]);
			object obj = constructor.Invoke((object[])this.stepArgs[this.stepIndex]);
			if (((Form)obj).ShowDialog() != DialogResult.Cancel)
			{
				this.stepIndex++;
				this.UpdateWizard();
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0001D359 File Offset: 0x0001C359
		private void btnQuit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0001D363 File Offset: 0x0001C363
		private void btnBack_Click(object sender, EventArgs e)
		{
			this.stepIndex--;
			this.UpdateWizard();
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0001D37B File Offset: 0x0001C37B
		private void btnNext_Click(object sender, EventArgs e)
		{
			this.stepIndex++;
			this.UpdateWizard();
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0001D393 File Offset: 0x0001C393
		private void btnFinish_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x040002A4 RID: 676
		protected int stepIndex;

		// Token: 0x040002A5 RID: 677
		protected Type currentType;

		// Token: 0x040002A6 RID: 678
		protected Type[] formsToShow;

		// Token: 0x040002AA RID: 682
		protected string[] stepTitles;

		// Token: 0x040002AC RID: 684
		protected string[] stepText;

		// Token: 0x040002AD RID: 685
		protected object[] stepArgs;

		// Token: 0x040002AE RID: 686
		protected object[] stepArgTypes;
	}
}
