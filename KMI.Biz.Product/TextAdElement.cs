using System;
using System.Drawing;

namespace KMI.Biz.Product
{
	// Token: 0x0200001A RID: 26
	[Serializable]
	public class TextAdElement
	{
		// Token: 0x040000F5 RID: 245
		public string Text;

		// Token: 0x040000F6 RID: 246
		public string FontName;

		// Token: 0x040000F7 RID: 247
		public bool Bold;

		// Token: 0x040000F8 RID: 248
		public bool Italic;

		// Token: 0x040000F9 RID: 249
		public bool Underline;

		// Token: 0x040000FA RID: 250
		public Color Color;

		// Token: 0x040000FB RID: 251
		public float FontSize;

		// Token: 0x040000FC RID: 252
		public Point Location;

		// Token: 0x040000FD RID: 253
		public bool Custom;
	}
}
