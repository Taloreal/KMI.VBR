using System;
using System.Collections;

namespace KMI.Sim
{
	// Token: 0x0200001E RID: 30
	[Serializable]
	public class ComplaintBuffer
	{
		// Token: 0x06000162 RID: 354 RVA: 0x0000C4B5 File Offset: 0x0000B4B5
		public ComplaintBuffer(Entity parent)
		{
			this.parent = parent;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000C4E0 File Offset: 0x0000B4E0
		public void AddComplaint(string from, string complaintKey)
		{
			string key = from + complaintKey;
			int num;
			if (this.complaints.ContainsKey(key))
			{
				num = (int)this.complaints[key] + 1;
				this.complaints[key] = num;
			}
			else
			{
				num = 1;
				this.complaints.Add(key, num);
			}
			ComplaintBuffer.MessageTable messageTable = (ComplaintBuffer.MessageTable)this.messageTables[key];
			if (messageTable != null)
			{
				for (int i = 0; i < messageTable.levels.Length; i++)
				{
					if (num == messageTable.levels[i])
					{
						this.parent.Player.SendMessage(string.Format(messageTable.messages[i], num), from, messageTable.colors[i]);
						break;
					}
				}
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000C5CC File Offset: 0x0000B5CC
		public int Count(string from, string complaintKey)
		{
			string key = from + complaintKey;
			int result;
			if (this.complaints.ContainsKey(key))
			{
				result = (int)this.complaints[key];
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000C610 File Offset: 0x0000B610
		public void Clear(string from, string complaintKey)
		{
			string key = from + complaintKey;
			this.complaints.Remove(key);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000C634 File Offset: 0x0000B634
		public void AddMessageTable(string from, string complaintKey, int[] levels, string[] messages, NotificationColor[] notificationColors)
		{
			string key = from + complaintKey;
			if (levels.Length != messages.Length)
			{
				throw new Exception("Length of Level, Messages, and NotificationColors do not match in ComplaintBuffer.SetMessages.");
			}
			this.ClearMessageTable(from, complaintKey);
			this.messageTables.Add(key, new ComplaintBuffer.MessageTable(levels, messages, notificationColors));
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000C684 File Offset: 0x0000B684
		public void AddMessageTable(string from, string complaintKey, int[] levels, string[] messages)
		{
			NotificationColor[] array = new NotificationColor[levels.Length];
			for (int i = 0; i < levels.Length; i++)
			{
				array[i] = NotificationColor.Yellow;
			}
			this.AddMessageTable(from, complaintKey, levels, messages, array);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000C6C0 File Offset: 0x0000B6C0
		public void AddMessageTable(string from, string complaintKey, int[] levels, string message)
		{
			string[] array = new string[levels.Length];
			for (int i = 0; i < levels.Length; i++)
			{
				array[i] = message;
			}
			this.AddMessageTable(from, complaintKey, levels, array);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000C6FC File Offset: 0x0000B6FC
		public void AddMessageTable(string from, string complaintKey, int[] levels, string message, NotificationColor[] notificationColors)
		{
			string[] array = new string[levels.Length];
			for (int i = 0; i < levels.Length; i++)
			{
				array[i] = message;
			}
			this.AddMessageTable(from, complaintKey, levels, array, notificationColors);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000C738 File Offset: 0x0000B738
		public void ClearMessageTable(string from, string complaintKey)
		{
			string key = from + complaintKey;
			this.messageTables.Remove(key);
		}

		// Token: 0x040000E4 RID: 228
		protected Hashtable complaints = new Hashtable();

		// Token: 0x040000E5 RID: 229
		protected Hashtable messageTables = new Hashtable();

		// Token: 0x040000E6 RID: 230
		protected Entity parent;

		// Token: 0x0200001F RID: 31
		[Serializable]
		private class MessageTable
		{
			// Token: 0x0600016B RID: 363 RVA: 0x0000C75B File Offset: 0x0000B75B
			public MessageTable(int[] levels, string[] messages, NotificationColor[] colors)
			{
				this.levels = levels;
				this.messages = messages;
				this.colors = colors;
			}

			// Token: 0x040000E7 RID: 231
			public int[] levels;

			// Token: 0x040000E8 RID: 232
			public string[] messages;

			// Token: 0x040000E9 RID: 233
			public NotificationColor[] colors;
		}
	}
}
