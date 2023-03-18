using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml;
using KMI.Utility;

namespace KMI.Sim
{
	// Token: 0x0200004D RID: 77
	[Serializable]
	public class MapV2 : ActiveObject
	{
		// Token: 0x060002B5 RID: 693 RVA: 0x000154AC File Offset: 0x000144AC
		public void addNode(NodeV2 n, ArrayList connections)
		{
			this.nodes.Add(n);
			if (connections != null)
			{
				n.nodes.AddRange(connections);
				foreach (object obj in connections)
				{
					NodeV2 nodeV = (NodeV2)obj;
					nodeV.nodes.Add(n);
				}
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00015538 File Offset: 0x00014538
		public bool load(string filename)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(filename);
			return this.load(xmlDocument);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00015560 File Offset: 0x00014560
		public bool load(XmlDocument doc)
		{
			try
			{
				XmlElement documentElement = doc.DocumentElement;
				string innerText = documentElement.SelectSingleNode("background").InnerText;
				XmlElement xmlElement = (XmlElement)documentElement.SelectSingleNode("network");
				XmlElement xmlElement2 = (XmlElement)xmlElement.SelectSingleNode("nodes");
				foreach (object obj in xmlElement2.ChildNodes)
				{
					XmlElement xmlElement3 = (XmlElement)obj;
					NodeV2 nodeV = new NodeV2();
					nodeV.name = xmlElement3.SelectSingleNode("name").InnerText;
					nodeV.width = int.Parse(xmlElement3.SelectSingleNode("width").InnerText);
					nodeV.height = int.Parse(xmlElement3.SelectSingleNode("height").InnerText);
					nodeV.centerx = float.Parse(xmlElement3.SelectSingleNode("centerx").InnerText);
					nodeV.centery = float.Parse(xmlElement3.SelectSingleNode("centery").InnerText);
					nodeV.x = int.Parse(xmlElement3.SelectSingleNode("x").InnerText);
					nodeV.y = int.Parse(xmlElement3.SelectSingleNode("y").InnerText);
					nodeV.weight = int.Parse(xmlElement3.SelectSingleNode("weight").InnerText);
					this.nodes.Add(nodeV);
				}
				XmlElement xmlElement4 = (XmlElement)xmlElement.SelectSingleNode("links");
				foreach (object obj2 in xmlElement4.ChildNodes)
				{
					XmlElement xmlElement5 = (XmlElement)obj2;
					NodeV2 nodeV2 = (NodeV2)this.nodes[int.Parse(xmlElement5.SelectSingleNode("n1").InnerText)];
					NodeV2 nodeV3 = (NodeV2)this.nodes[int.Parse(xmlElement5.SelectSingleNode("n2").InnerText)];
					nodeV2.nodes.Add(nodeV3);
					nodeV3.nodes.Add(nodeV2);
				}
			}
			catch (Exception e)
			{
				frmExceptionHandler.Handle(e);
				return false;
			}
			return true;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00015830 File Offset: 0x00014830
		public bool load(Assembly assembly, string resource)
		{
			XmlDocument xmlDocument = new XmlDocument();
			Stream manifestResourceStream = assembly.GetManifestResourceStream(resource);
			xmlDocument.Load(manifestResourceStream);
			manifestResourceStream.Close();
			return this.load(xmlDocument);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00015868 File Offset: 0x00014868
		public NodeV2 getNode(string name)
		{
			foreach (object obj in this.nodes)
			{
				NodeV2 nodeV = (NodeV2)obj;
				if (nodeV.name.ToUpper() == name.ToUpper())
				{
					return nodeV;
				}
			}
			throw new Exception("Could not find node '" + name + "' in place map.");
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00015904 File Offset: 0x00014904
		public bool atNode(PointF currentLocation, string name)
		{
			return this.atNode(currentLocation, this.getNode(name));
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00015924 File Offset: 0x00014924
		public bool atNode(PointF currentLocation, NodeV2 node)
		{
			return currentLocation.X == (float)node.x && currentLocation.Y == (float)node.y;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0001595C File Offset: 0x0001495C
		public bool atDistributedNode(PointF currentLocation, string name)
		{
			return this.atDistributedNode(currentLocation, this.getNode(name));
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0001597C File Offset: 0x0001497C
		public bool atDistributedNode(PointF currentLocation, NodeV2 node)
		{
			PointF[] array = new PointF[4];
			int num = -1;
			int num2 = -1;
			PointF pointF = Utilities.cartesianToIsometric(node.centerx * (float)node.width / 1f, node.centery * (float)node.height / 1f, 0f, 0f, 1f, 1f);
			array[0] = Utilities.cartesianToIsometric((float)num, (float)num2, (float)node.x - pointF.X, (float)node.y - pointF.Y, 1f, 1f);
			num = node.width + 1;
			num2 = -1;
			pointF = Utilities.cartesianToIsometric(node.centerx * (float)node.width / 1f, node.centery * (float)node.height / 1f, 0f, 0f, 1f, 1f);
			array[1] = Utilities.cartesianToIsometric((float)num, (float)num2, (float)node.x - pointF.X, (float)node.y - pointF.Y, 1f, 1f);
			num = node.width + 1;
			num2 = node.height + 1;
			pointF = Utilities.cartesianToIsometric(node.centerx * (float)node.width / 1f, node.centery * (float)node.height / 1f, 0f, 0f, 1f, 1f);
			array[2] = Utilities.cartesianToIsometric((float)num, (float)num2, (float)node.x - pointF.X, (float)node.y - pointF.Y, 1f, 1f);
			num = -1;
			num2 = node.height + 1;
			pointF = Utilities.cartesianToIsometric(node.centerx * (float)node.width / 1f, node.centery * (float)node.height / 1f, 0f, 0f, 1f, 1f);
			array[3] = Utilities.cartesianToIsometric((float)num, (float)num2, (float)node.x - pointF.X, (float)node.y - pointF.Y, 1f, 1f);
			return Utilities.PolygonContains(currentLocation, array);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00015BD0 File Offset: 0x00014BD0
		public PathV2 findPath(string beg, string end)
		{
			return this.findPath(this.getNode(beg), this.getNode(end));
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00015BF8 File Offset: 0x00014BF8
		public PathV2 findPath(NodeV2 start, NodeV2 end)
		{
			foreach (object obj in this.nodes)
			{
				NodeV2 nodeV = (NodeV2)obj;
				nodeV.distance = 2147483646;
				nodeV.isDead = false;
				nodeV.nextLink = null;
			}
			start.distance = 0;
			start.isDead = false;
			start.nextLink = null;
			for (int i = 0; i < this.nodes.Count; i++)
			{
				int index = 0;
				int num = int.MaxValue;
				for (int j = 0; j < this.nodes.Count; j++)
				{
					if (!((NodeV2)this.nodes[j]).isDead && ((NodeV2)this.nodes[j]).distance < num)
					{
						index = j;
						num = ((NodeV2)this.nodes[j]).distance;
					}
				}
				NodeV2 nodeV2 = (NodeV2)this.nodes[index];
				for (int j = 0; j < nodeV2.nodes.Count; j++)
				{
					NodeV2 nodeV3 = (NodeV2)nodeV2.nodes[j];
					float num2 = (float)(nodeV3.x - nodeV2.x);
					float num3 = (float)(nodeV3.y - nodeV2.y);
					float num4 = (float)Math.Sqrt((double)(num2 * num2 + num3 * num3 * 4f));
					num4 += (float)nodeV3.weight;
					int num5 = (int)Utilities.Clamp(num4, 0f, 2.1474836E+09f);
					if (nodeV3.distance > nodeV2.distance + num5 && !nodeV2.blocked)
					{
						nodeV3.distance = nodeV2.distance + num5;
						nodeV3.nextLink = nodeV2;
					}
				}
				nodeV2.isDead = true;
			}
			PathV2 result;
			if (end.distance < 0 || end.distance >= 2147483646)
			{
				result = null;
			}
			else
			{
				PathV2 pathV = new PathV2();
				for (NodeV2 nodeV2 = end; nodeV2 != null; nodeV2 = nodeV2.nextLink)
				{
					pathV.nodes.Insert(0, nodeV2);
				}
				result = pathV;
			}
			return result;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00015E84 File Offset: 0x00014E84
		public PathV2 findPath(PointF currentLocation, string end)
		{
			ArrayList arrayList = new ArrayList();
			PathV2 pathV;
			do
			{
				float num = float.MaxValue;
				NodeV2 nodeV = null;
				foreach (object obj in this.nodes)
				{
					NodeV2 nodeV2 = (NodeV2)obj;
					float num2 = Utilities.DistanceBetweenIsometric(currentLocation, nodeV2.Location);
					if (num2 < num && !arrayList.Contains(nodeV2))
					{
						nodeV = nodeV2;
						num = num2;
					}
				}
				pathV = this.findPath(nodeV, this.getNode(end));
				if (pathV == null)
				{
					arrayList.Add(nodeV);
				}
			}
			while (pathV == null && arrayList.Count < this.nodes.Count);
			return pathV;
		}

		// Token: 0x040001BA RID: 442
		public ArrayList nodes = new ArrayList();
	}
}
