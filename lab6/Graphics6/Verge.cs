using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics6
{
    class Verge
    {

        private IList<XYZPoint> points = new List<XYZPoint>();

        public IList<XYZPoint> Points { get { return points; } set { points = value; } }

        public Verge() { }

        public Verge(IList<XYZPoint> points)
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
    }
}
