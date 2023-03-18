using System;
using System.Collections;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace KMI.Sim
{
	// Token: 0x0200005C RID: 92
	public class Resource
	{
		// Token: 0x06000359 RID: 857 RVA: 0x000195B8 File Offset: 0x000185B8
		public Resource(params ResourceManager[] rms)
		{
			foreach (ResourceManager value in rms)
			{
				this.resourceManagers.Add(value);
			}
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00019624 File Offset: 0x00018624
		public string GetString(string Name)
		{
			if (this.resourceManagers.Count == 0)
			{
				throw new Exception("No string resource files were added to this solution.");
			}
			foreach (object obj in this.resourceManagers)
			{
				ResourceManager resourceManager = (ResourceManager)obj;
				string @string = resourceManager.GetString(Name);
				if (@string != null)
				{
					return @string;
				}
			}
			return Name;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x000196C8 File Offset: 0x000186C8
		public string GetString(string Name, params object[] args)
		{
			string @string = this.GetString(Name);
			return string.Format(@string, args);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000196EC File Offset: 0x000186EC
		public string GetStringByIndex(string Name, int index)
		{
			string @string = this.GetString(Name);
			string[] array = @string.Split(new char[]
			{
				'|'
			});
			return array[index];
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00019720 File Offset: 0x00018720
		public string GetRandomSubString(string resource, char[] delimiter)
		{
			string[] array = this.GetString(resource).Split(delimiter);
			return array[Simulator.Instance.SimState.Random.Next(array.GetLength(0))];
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00019760 File Offset: 0x00018760
		public Bitmap GetImage(string imageName)
		{
			Bitmap bitmap = (Bitmap)this.imageTable[imageName];
			if (bitmap != null)
			{
				return bitmap;
			}
			throw new Exception("Could not find image " + imageName);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000197A0 File Offset: 0x000187A0
		public Page GetPage(string pageName)
		{
			Page page = (Page)this.pageTable[pageName];
			if (page != null)
			{
				return page;
			}
			throw new Exception("Could not find page " + pageName);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000197E0 File Offset: 0x000187E0
		public Cursor GetCursor(string cursorName)
		{
			Cursor cursor = (Cursor)this.cursorTable[cursorName];
			if (cursor != null)
			{
				return cursor;
			}
			throw new Exception("Could not find cursor " + cursorName);
		}

		// Token: 0x170000CB RID: 203
		// (set) Token: 0x06000361 RID: 865 RVA: 0x00019824 File Offset: 0x00018824
		public SortedList ImageTable
		{
			set
			{
				this.imageTable = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (set) Token: 0x06000362 RID: 866 RVA: 0x0001982E File Offset: 0x0001882E
		public SortedList PageTable
		{
			set
			{
				this.pageTable = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00019838 File Offset: 0x00018838
		public SortedList CursorTable
		{
			set
			{
				this.cursorTable = value;
			}
		}

		// Token: 0x0400022A RID: 554
		private ArrayList resourceManagers = new ArrayList();

		// Token: 0x0400022B RID: 555
		protected SortedList imageTable = new SortedList();

		// Token: 0x0400022C RID: 556
		protected SortedList pageTable = new SortedList();

		// Token: 0x0400022D RID: 557
		protected SortedList cursorTable = new SortedList();
	}
}
