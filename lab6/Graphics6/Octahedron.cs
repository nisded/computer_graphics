using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics6
{
	class Octahedron : Primitive
	{
		// кол-во вершин = 6
		private List<XYZPoint> points = new List<XYZPoint>();

		// кол-во граней = 8
		private List<Verge> verges = new List<Verge>();

		public List<XYZPoint> Points { get { return points; } }
		public List<Verge> Verges { get { return verges; } }

		public XYZPoint Center
		{
			get
			{
				XYZPoint p = new XYZPoint(0, 0, 0);
				for (int i = 0; i < 6; i++)
				{
					p.X += Points[i].X;
					p.Y += Points[i].Y;
					p.Z += Points[i].Z;
				}
				p.X /= 6;
				p.Y /= 6;
				p.Z /= 6;
				return p;
			}
		}

		public Octahedron(double size)
		{

			points = new List<XYZPoint>();

			points.Add(new XYZPoint(-size / 2, 0, 0));
			points.Add(new XYZPoint(0, -size / 2, 0));
			points.Add(new XYZPoint(0, 0, -size / 2));
			points.Add(new XYZPoint(size / 2, 0, 0));
			points.Add(new XYZPoint(0, size / 2, 0));
			points.Add(new XYZPoint(0, 0, size / 2));


			Verges.Add(new Verge(new XYZPoint[] { points[0], points[2], points[4] }));
			Verges.Add(new Verge(new XYZPoint[] { points[2], points[4], points[3] }));
			Verges.Add(new Verge(new XYZPoint[] { points[4], points[5], points[3] }));
			Verges.Add(new Verge(new XYZPoint[] { points[0], points[5], points[4] }));
			Verges.Add(new Verge(new XYZPoint[] { points[0], points[5], points[1] }));
			Verges.Add(new Verge(new XYZPoint[] { points[5], points[3], points[1] }));
			Verges.Add(new Verge(new XYZPoint[] { points[0], points[2], points[1] }));
			Verges.Add(new Verge(new XYZPoint[] { points[2], points[1], points[3] }));
		}

		public void Apply(Transform t)
		{
			foreach (var point in Points)
				point.Apply(t);
		}

		public void Draw(Graphics g, Transform projection, int width, int height)
		{
			if (Points.Count != 6) return;

			foreach (var Verge in Verges)
				Verge.Draw(g, projection, width, height);
		}
	}
}
