using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ComputerGraphics7
{
    class Verge : Primitive
    {

        private List<XYZPoint> points = new List<XYZPoint>();

        private List<Verge> verges = new List<Verge>();

        public List<XYZPoint> Points { get { return points; } set { points = value; } }

        public List<Verge> Verges { get { return verges; } set { verges = value; } }

        public Verge() { }

        public Verge(List<XYZPoint> points)
        {
            this.points = points;
        }

        public void AddPoint(XYZPoint p)
        {
            points.Add(p);
        }

        public void Apply(Transform t)
        {
            foreach (var point in Points)
                point.Apply(t);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            if (Points.Count == 1)
                Points[0].Draw(g, projection, width, height);
            else
            {
                for (int i = 0; i < Points.Count - 1; ++i)
                {
                    var line = new XYZLine(Points[i], Points[i + 1]);
                    line.Draw(g, projection, width, height);
                }
                (new XYZLine(Points[Points.Count - 1], Points[0])).Draw(g, projection, width, height);
            }
        }

        override public string ToString()
        {
            return "Verge";
        }
    }
}
