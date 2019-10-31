using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics6
{
    class XYZLine : Primitive
    {
        private XYZPoint a;
        private XYZPoint b;
        private List<XYZPoint> points = new List<XYZPoint>();
        private List<Verge> verges = new List<Verge>();
        public XYZPoint A { get { return a; } set { a = value; } }
        public XYZPoint B { get { return b; } set { b = value; } }

        public List<XYZPoint> Points { get { return points; } set { points = value; } }
        public List<Verge> Verges { get { return verges; } set { verges = value; } }

        public XYZLine(XYZPoint a, XYZPoint b)
        {
            A = a;
            B = b;
        }

        public void Apply(Transform t)
        {
            A = A.Transform(t);
            B = B.Transform(t);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            var c = A.Transform(projection).NormalizedToDisplay(width, height);
            var d = B.Transform(projection).NormalizedToDisplay(width, height);
            g.DrawLine(Pens.Black, (float)c.X, (float)c.Y, (float)d.X, (float)d.Y);
        }
        override public string ToString()
        {
            return "Line";
        }
    }
}
