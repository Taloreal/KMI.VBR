using System;
using System.Drawing;

namespace KMI.Biz.Product
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public class GraphicAdElement
	{
		// Token: 0x04000041 RID: 65
		public ProductType ProductType;

		// Token: 0x04000042 RID: 66
		public bool ShowPrice;

		// Token: 0x04000043 RID: 67
		public bool ShowName;

		// Token: 0x04000044 RID: 68
		public GraphicAdElement.Sizes Size;

		// Token: 0x04000045 RID: 69
		public Point Location;

		// Token: 0x04000046 RID: 70
		public static float[] ImageScales = new float[]
		{
			0.33f,
			0.66f,
			1f
		};

		// Token: 0x04000047 RID: 71
		public static Font[] Fonts = new Font[]
		{
			new Font("Arial", 10f),
			new Font("Arial", 14f),
			new Font("Arial", 18f)
		};

		// Token: 0x04000048 RID: 72
		public float Price;

		// Token: 0x0200000C RID: 12
		public enum Sizes
		{
			// Token: 0x0400004A RID: 74
			Small,
			// Token: 0x0400004B RID: 75
			Medium,
			// Token: 0x0400004C RID: 76
			Large
		}
	}
}
