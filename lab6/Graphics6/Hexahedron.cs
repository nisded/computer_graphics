using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics6
{
	class Hexahedron : Primitive
	{
		// кол-во вершин = 8
		private List<XYZPoint> points = new List<XYZPoint>();

		// кол-во граней = 6
		private List<Verge> verges = new List<Verge>();

		public List<XYZPoint> Points { get { return points; } }
		public List<Verge> Verges { get { return verges; } }

		public XYZPoint Center
		{
			get
			{
				XYZPoint p = new XYZPoint(0, 0, 0);
				for (int i = 0; i < 8; i++)
				{
					p.X += Points[i].X;
					p.Y += Points[i].Y;
					p.Z += Points[i].Z;
				}
				p.X /= 8;
				p.Y /= 8;
				p.Z /= 8;
				return p;
			}
		}

		public Hexahedron(double size)
		{
			points = new List<XYZPoint>();

			points.Add(new XYZPoint(-size / 2, -size / 2, -size / 2));
			points.Add(new XYZPoint(-size / 2, -size / 2, size / 2));
			points.Add(new XYZPoint(-size / 2, size / 2, -size / 2));
			points.Add(new XYZPoint(size / 2, -size / 2, -size / 2));
			points.Add(new XYZPoint(-size / 2, size / 2, size / 2));
			points.Add(new XYZPoint(size / 2, -size / 2, size / 2));
			points.Add(new XYZPoint(size / 2, size / 2, -size / 2));
			points.Add(new XYZPoint(size / 2, size / 2, size / 2));

			Verges.Add(new Verge(new XYZPoint[] { points[0], points[1], points[5], points[3] }));
			Verges.Add(new Verge(new XYZPoint[] { points[2], points[6], points[3], points[0] }));
			Verges.Add(new Verge(new XYZPoint[] { points[4], points[1], points[0], points[2] }));
			Verges.Add(new Verge(new XYZPoint[] { points[7], points[5], points[3], points[6] }));
			Verges.Add(new Verge(new XYZPoint[] { points[2], points[4], points[7], points[6] }));
			Verges.Add(new Verge(new XYZPoint[] { points[4], points[1], points[5], points[7] }));

		}

		public void Apply(Transform t)
		{
			foreach (var point in Points)
				point.Apply(t);
		}

		public void Draw(Graphics g, Transform projection, int width, int height)
		{
			if (Points.Count != 8) return;

			foreach (var Verge in Verges)
				Verge.Draw(g, projection, width, height);
		}
	}
}
