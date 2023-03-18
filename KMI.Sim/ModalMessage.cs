using System;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200001A RID: 26
	[Serializable]
	public class ModalMessage
	{
		// Token: 0x06000143 RID: 323 RVA: 0x0000A877 File Offset: 0x00009877
		public ModalMessage(string to, string message, string title, MessageBoxIcon icon)
		{
			this.to = to;
			this.message = message;
			this.title = title;
			this.icon = icon;
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000144 RID: 324 RVA: 0x0000A8A0 File Offset: 0x000098A0
		public string To
		{
			get
			{
				return this.to;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0000A8B8 File Offset: 0x000098B8
		public string Message
		{
			get
			{
				return this.message;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000146 RID: 326 RVA: 0x0000A8D0 File Offset: 0x000098D0
		public string Title
		{
			get
			{
				return this.title;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000147 RID: 327 RVA: 0x0000A8E8 File Offset: 0x000098E8
		public MessageBoxIcon Icon
		{
			get
			{
				return this.icon;
			}
		}

		// Token: 0x040000C3 RID: 195
		protected string to;

		// Token: 0x040000C4 RID: 196
		protected string message;

		// Token: 0x040000C5 RID: 197
		protected string title;

		// Token: 0x040000C6 RID: 198
		protected MessageBoxIcon icon;
	}
}
