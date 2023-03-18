using System;
using System.Collections;
using KMI.Sim;

namespace KMI.Biz.Product
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	public class Consumer : Person
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00003274 File Offset: 0x00002274
		protected void MakeImpression(long entityID, float impact, string impressionSourceName)
		{
			string key = entityID + impressionSourceName;
			if (this.impressions.ContainsKey(key))
			{
				this.impressions[key] = impact;
			}
			else
			{
				this.impressions.Add(key, impact);
			}
			if (this.impressionCount.ContainsKey(entityID))
			{
				this.impressionCount[entityID] = (int)this.impressionCount[entityID] + 1;
			}
			else
			{
				this.impressionCount.Add(entityID, 1);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000332C File Offset: 0x0000232C
		public int ImpressionCount(long entityID)
		{
			int result;
			if (this.impressionCount.ContainsKey(entityID))
			{
				result = (int)this.impressionCount[entityID];
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003370 File Offset: 0x00002370
		protected void DecayImpressions(float DecayRate, float MinimumDecay)
		{
			ArrayList arrayList = new ArrayList(this.impressions.Keys);
			foreach (object obj in arrayList)
			{
				string key = (string)obj;
				float num = (float)this.impressions[key];
				this.impressions[key] = Math.Max(0f, Math.Min(num - MinimumDecay, num * DecayRate));
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000341C File Offset: 0x0000241C
		public string MaxImpressionSource(long entityID)
		{
			string result = "";
			float num = 0f;
			foreach (string text in Consumer.ImpressionSources)
			{
				float num2 = this.ImpressionImpact(entityID, text);
				if (num2 > num)
				{
					num = num2;
					result = text;
				}
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003484 File Offset: 0x00002484
		public float ImpressionImpact(long entityID)
		{
			float num = 0f;
			foreach (string source in Consumer.ImpressionSources)
			{
				num += this.ImpressionImpact(entityID, source);
			}
			return num;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000034CC File Offset: 0x000024CC
		public float ImpressionImpact(long entityID, string source)
		{
			string key = entityID + source;
			float result;
			if (this.impressions.ContainsKey(key))
			{
				result = (float)this.impressions[key];
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003518 File Offset: 0x00002518
		public void ClearImpressions(long entityID)
		{
			foreach (string arg in Consumer.ImpressionSources)
			{
				this.impressions.Remove(entityID + arg);
			}
			this.impressionCount.Remove(entityID);
		}

		// Token: 0x04000023 RID: 35
		protected Hashtable impressions = new Hashtable();

		// Token: 0x04000024 RID: 36
		protected Hashtable impressionCount = new Hashtable();

		// Token: 0x04000025 RID: 37
		public static string[] ImpressionSources;
	}
}
