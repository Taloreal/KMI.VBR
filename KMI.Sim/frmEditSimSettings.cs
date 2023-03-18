using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200001C RID: 28
	public partial class frmEditSimSettings : Form
	{
		// Token: 0x06000149 RID: 329 RVA: 0x0000A920 File Offset: 0x00009920
		public frmEditSimSettings()
		{
			this.InitializeComponent();
			SimSettings simSettings = S.SA.getSimSettings();
			this.LoadSettingsIntoTextBoxes(simSettings);
			this.pdfAssignment = simSettings.PdfAssignment;
			this.btnReset.Visible = S.MF.DesignerMode;
			this.btnDisableAllActions.Visible = S.MF.DesignerMode;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000B550 File Offset: 0x0000A550
		private void panel3_Resize(object sender, EventArgs e)
		{
			foreach (object obj in this.panel3.Controls)
			{
				Control control = (Control)obj;
				if (control.Left == this.txtValue.Left)
				{
					control.Width = this.panel3.ClientRectangle.Right - control.Left - 1;
				}
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000B5F4 File Offset: 0x0000A5F4
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000B600 File Offset: 0x0000A600
		private void InsertRow(int i, int j, string name, string val, bool changed)
		{
			TextBox textBox = new TextBox();
			textBox.Size = this.txtName.Size;
			textBox.Left = this.txtName.Left;
			textBox.Top = i * (this.txtName.Height - 1) + this.txtName.Top;
			textBox.ReadOnly = true;
			textBox.BackColor = this.txtName.BackColor;
			textBox.BorderStyle = this.txtName.BorderStyle;
			textBox.Text = name;
			this.panel3.Controls.Add(textBox);
			TextBox textBox2 = new TextBox();
			textBox2.Size = this.txtValue.Size;
			textBox2.Left = this.txtValue.Left;
			textBox2.Top = i * (this.txtValue.Height - 1) + this.txtValue.Top;
			textBox2.BackColor = this.txtValue.BackColor;
			textBox2.BorderStyle = this.txtValue.BorderStyle;
			textBox2.Tag = j;
			textBox2.Text = val;
			if (changed)
			{
				textBox2.Font = new Font(textBox2.Font, FontStyle.Bold);
			}
			this.panel3.Controls.Add(textBox2);
			textBox2.Validating += this.txtValue_Validating;
			textBox2.Enter += this.txtValue_Enter;
			textBox2.DoubleClick += this.txtValue_DoubleClick;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000B790 File Offset: 0x0000A790
		private void txtValue_Validating(object sender, CancelEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			if (this.ConvertStringToPropertyType(textBox.Text, (int)textBox.Tag) == null)
			{
				MessageBox.Show("Invalid entry. Please try again.");
				textBox.Text = this.lastEntry;
				textBox.SelectAll();
				e.Cancel = true;
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000B7F0 File Offset: 0x0000A7F0
		private object ConvertStringToPropertyType(string s, int propertyIndex)
		{
			MethodInfo getMethod = this.propertyInfo[propertyIndex].GetGetMethod();
			object obj;
			lock (S.SA)
			{
				obj = getMethod.Invoke(Simulator.Instance.SimState.SimSettings, new object[0]);
			}
			try
			{
				if (obj is int)
				{
					return Convert.ToInt32(s);
				}
				if (obj is float)
				{
					return Convert.ToSingle(s);
				}
				if (obj is DateTime)
				{
					return Convert.ToDateTime(s);
				}
				if (obj is bool)
				{
					return Convert.ToBoolean(s);
				}
				if (obj is string)
				{
					return Convert.ToString(s);
				}
			}
			catch
			{
				return null;
			}
			return null;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000B914 File Offset: 0x0000A914
		private void btnOK_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.panel3.Controls)
			{
				Control control = (Control)obj;
				if (control.Left == this.txtValue.Left)
				{
					object obj2 = this.ConvertStringToPropertyType(control.Text, (int)control.Tag);
					MethodInfo setMethod = this.propertyInfo[(int)control.Tag].GetSetMethod();
					lock (S.SA)
					{
						setMethod.Invoke(Simulator.Instance.SimState.SimSettings, new object[]
						{
							obj2
						});
					}
				}
			}
			lock (S.SA)
			{
				S.SS.PdfAssignment = this.pdfAssignment;
				if (S.ST.Reserved.ContainsKey("LocalLanguageAssignments"))
				{
					S.ST.Reserved["LocalLanguageAssignments"] = this.localLanguageAssignments;
				}
				else
				{
					S.ST.Reserved.Add("LocalLanguageAssignments", this.localLanguageAssignments);
				}
			}
			base.Close();
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000BAB4 File Offset: 0x0000AAB4
		private void txtValue_Enter(object sender, EventArgs e)
		{
			this.lastEntry = ((TextBox)sender).Text;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000BAC8 File Offset: 0x0000AAC8
		private void btnReset_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure you want to reset all settings?", "Confirm Reset", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.LoadSettingsIntoTextBoxes(S.I.DefaultSimSettings);
				this.pdfAssignment = S.I.DefaultSimSettings.PdfAssignment;
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000BB1C File Offset: 0x0000AB1C
		private void LoadSettingsIntoTextBoxes(SimSettings simSettings)
		{
			this.panel3.Controls.Clear();
			this.propertyInfo = simSettings.GetType().GetProperties();
			int num = 0;
			int num2 = 0;
			foreach (PropertyInfo propertyInfo in this.propertyInfo)
			{
				MethodInfo getMethod = propertyInfo.GetGetMethod();
				object obj = getMethod.Invoke(simSettings, new object[0]);
				object obj2 = getMethod.Invoke(S.I.DefaultSimSettings, new object[0]);
				bool changed = true;
				if (obj != null && obj2 != null)
				{
					changed = (obj.ToString() != obj2.ToString());
				}
				if (obj != null && !obj.GetType().IsArray)
				{
					if (propertyInfo.Name.IndexOf("Enabled") > -1 || S.MF.DesignerMode || simSettings.AllowInstructorToEdit(propertyInfo.Name))
					{
						if (propertyInfo.Name != "Assignment")
						{
							this.InsertRow(num, num2, Utilities.AddSpaces(propertyInfo.Name), obj.ToString(), changed);
							num++;
						}
					}
				}
				num2++;
			}
			this.panel3_Resize(new object(), new EventArgs());
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000BC80 File Offset: 0x0000AC80
		private void btnLoadAssignment_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
			openFileDialog.DefaultExt = ".pdf";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (File.Exists(openFileDialog.FileName))
				{
					FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
					BinaryReader binaryReader = new BinaryReader(fileStream);
					byte[] value = binaryReader.ReadBytes((int)fileStream.Length);
					if (this.txtCountryCode.Text == "")
					{
						this.pdfAssignment = value;
					}
					else if (this.localLanguageAssignments.ContainsKey(this.txtCountryCode.Text))
					{
						this.localLanguageAssignments[this.txtCountryCode.Text] = value;
					}
					else
					{
						this.localLanguageAssignments.Add(this.txtCountryCode.Text, value);
					}
					fileStream.Close();
				}
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000BD7F File Offset: 0x0000AD7F
		private void btnHelp_Click(object sender, EventArgs e)
		{
			KMIHelp.OpenHelp("Instructor's Area");
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000BD8D File Offset: 0x0000AD8D
		private void frmEditSimSettings_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000BD90 File Offset: 0x0000AD90
		private void btnDeleteAssignment_Click(object sender, EventArgs e)
		{
			this.pdfAssignment = null;
			this.localLanguageAssignments = new Hashtable();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000BDA8 File Offset: 0x0000ADA8
		private void btnDisableAllActions_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.panel3.Controls.Count; i += 2)
			{
				string text = this.panel3.Controls[i].Text;
				int num = text.IndexOf("Enabled For");
				if (num > -1)
				{
					text = text.Substring(0, num);
					text = text.TrimEnd(new char[]
					{
						' '
					});
					if (S.MF.IsActionMenuItem(text))
					{
						this.panel3.Controls[i + 1].Text = "False";
					}
				}
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000BE60 File Offset: 0x0000AE60
		private void txtValue_DoubleClick(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			if (textBox.Text.ToUpper() == "TRUE")
			{
				textBox.Text = "False";
			}
			else if (textBox.Text.ToUpper() == "FALSE")
			{
				textBox.Text = "True";
			}
		}

		// Token: 0x040000DA RID: 218
		private PropertyInfo[] propertyInfo;

		// Token: 0x040000DB RID: 219
		private string lastEntry;

		// Token: 0x040000DC RID: 220
		private byte[] pdfAssignment;

		// Token: 0x040000DD RID: 221
		private Hashtable localLanguageAssignments = new Hashtable();
	}
}
