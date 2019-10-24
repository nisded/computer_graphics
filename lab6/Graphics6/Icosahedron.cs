using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics6
{
    class Icosahedron : Primitive
    {
        // кол-во вершин = 12
        private List<XYZPoint> points = new List<XYZPoint>();

        // кол-во граней = 20
        private List<Verge> verges = new List<Verge>();

        public List<XYZPoint> Points { get { return points; } }
        public List<Verge> Verges { get { return verges; } }

        public XYZPoint Center
        {
            get
            {
                XYZPoint p = new XYZPoint(0, 0, 0);
                for (int i = 0; i < 12; i++)
                {
                    p.X += Points[i].X;
                    p.Y += Points[i].Y;
                    p.Z += Points[i].Z;
                }
                p.X /= 12;
                p.Y /= 12;
                p.Z /= 12;
                return p;
            }
        }

        public Icosahedron(double size)
        {
            // радиус описанной сферы
            double R = (size * Math.Sqrt(2.0 * (5.0 + Math.Sqrt(5.0)))) / 4;

            // радиус вписанной сферы
            double r = (size * Math.Sqrt(3.0) * (3.0 + Math.Sqrt(5.0))) / 12;

            points = new List<XYZPoint>();

            for (int i = 0; i < 5; ++i)
            {
                points.Add(new XYZPoint(
                    r * Math.Cos(2 * Math.PI / 5 * i),
                    R / 2,
                    r * Math.Sin(2 * Math.PI / 5 * i)));
                points.Add(new XYZPoint(
                    r * Math.Cos(2 * Math.PI / 5 * i + 2 * Math.PI / 10),
                    -R / 2,
                    r * Math.Sin(2 * Math.PI / 5 * i + 2 * Math.PI / 10)));
            }

            points.Add(new XYZPoint(0, R, 0));
            points.Add(new XYZPoint(0, -R, 0));

            // середина
            for (int i = 0; i < 10; ++i)
                Verges.Add(new Verge(new XYZPoint[] { points[i], points[(i + 1) % 10], points[(i + 2) % 10] }));

            for (int i = 0; i < 5; ++i)
            {
                // верхняя часть
                Verges.Add(new Verge(new XYZPoint[] { points[2 * i], points[10], points[(2 * (i + 1)) % 10] }));
                // нижняя часть
                Verges.Add(new Verge(new XYZPoint[] { points[2 * i + 1], points[11], points[(2 * (i + 1) + 1) % 10] }));
            }
        }

        public void Apply(Transform t)
        {
            foreach (var point in Points)
                point.Apply(t);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            if (Points.Count != 12) return;

            foreach (var Verge in Verges)
                Verge.Draw(g, projection, width, height);
        }
    }
}
