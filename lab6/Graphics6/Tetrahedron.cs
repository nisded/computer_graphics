using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics6
{
    class Tetrahedron : Primitive
    {
        // первые три точки - основание тетраэдра, четвертая точка - его вершина
        private List<XYZPoint> points = new List<XYZPoint>();

        private List<Verge> verges = new List<Verge>();

        public List<XYZPoint> Points { get { return points; } }
        public List<Verge> Verges { get { return verges; } }

        public XYZPoint Center
        {
            get
            {
                XYZPoint p = new XYZPoint(0, 0, 0);
                for (int i = 0; i < 4; i++)
                {
                    p.X += Points[i].X;
                    p.Y += Points[i].Y;
                    p.Z += Points[i].Z;
                }
                p.X /= 4;
                p.Y /= 4;
                p.Z /= 4;
                return p;
            }
        }

        public Tetrahedron(double size)
        {
            double h = Math.Sqrt(2.0 / 3.0) * size;
            points = new List<XYZPoint>();

            points.Add(new XYZPoint(-size / 2, 0, h / 3));
            points.Add(new XYZPoint(0, 0, -h * 2 / 3));
            points.Add(new XYZPoint(size / 2, 0, h / 3));
            points.Add(new XYZPoint(0, h, 0));

            // Основание тетраэдра
            Verges.Add(new Verge(new XYZPoint[] { points[0], points[1], points[2] }));
            // Левая грань
            Verges.Add(new Verge(new XYZPoint[] { points[1], points[3], points[0] }));
            // Правая грань
            Verges.Add(new Verge(new XYZPoint[] { points[2], points[3], points[1] }));
            // Передняя грань
            Verges.Add(new Verge(new XYZPoint[] { points[0], points[3], points[2] }));
        }

        public void Apply(Transform t)
        {
            foreach (var point in Points)
                point.Apply(t);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            foreach (var Verge in Verges)
                Verge.Draw(g, projection, width, height);
        }
    }
}
