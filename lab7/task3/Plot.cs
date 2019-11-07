using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphics7
{
    class Plot : Primitive
    {
        private List<XYZPoint> points = new List<XYZPoint>();

        private List<Verge> verges = new List<Verge>();

        private IList<XYZLine> lines = new List<XYZLine>();

        public List<XYZPoint> Points { get { return points; } }

        public List<Verge> Verges { get { return verges; } }

        public IList<XYZLine> Lines { get { return lines; } }

        public string func;

        private double F(double x, double y)
        {
            switch (func)
            {
                case "(x * x * y) / ((x * x * x * x + y * y) - 0.01)":
                    {
                        return (x * x * y) / ((x * x * x * x + y * y) - 0.01);
                    }
                case "(x * x) + (y * y)":
                    {
                        return Math.Sqrt((x * x) + (y * y));
                    }
                case "x + y":
                    {
                        return x + y;
                    }
                default:
                    {
                        return (x * x * y) / ((x * x * x * x + y * y) - 0.01);
                    }
            }
        }

        public Plot(List<XYZPoint> p)
        {
            points.Add(p[0]);
            int cur = 1;
            lines = new List<XYZLine>();
            for (double i = 0.1; i < 1; i += 0.03)
                for (double j = 0.1; j < 1; j += 0.03)
                {
                    points.Add(p[cur]);
                    cur++;
                    if (j > 0.1)
                    {
                        lines.Add(new XYZLine(points[points.Count - 2], points[points.Count - 1]));
                    }
                }
        }

        public XYZPoint Center
        {
            get
            {
                var x = (Lines[0].A.X + Lines[0].B.X) / 2;
                var y = (Lines[0].A.Y + Lines[0].B.Y) / 2;
                var z = (Lines[0].A.Z + Lines[0].B.Z) / 2;
                return new XYZPoint(x, y, z);
            }
        }

        public Plot(string function, Tuple<double, double, double, double> span, double step)
        {
            func = function;

            points.Add(new XYZPoint(0, 0, F(0, 0)));

            for (double i = span.Item1; i < span.Item2; i += step)
                for (double j = span.Item3; j < span.Item4; j += step)
                {
                    points.Add(new XYZPoint(i, j, F(i, j)));
                    if (j > 0.1)
                    {
                        lines.Add(new XYZLine(points[points.Count - 2], points[points.Count - 1]));
                    }
                }
        }

        public void Apply(Transform t)
        {
            foreach (var point in Points)
                point.Apply(t);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                var c = lines[i].A.Transform(projection).NormalizedToDisplay(width, height);
                var d = lines[i].B.Transform(projection).NormalizedToDisplay(width, height);
                g.DrawLine(Pens.Black, (float)c.X, (float)c.Y, (float)d.X, (float)d.Y);
            }
        }

        override public string ToString()
        {
            return "Plot";
        }
    }
}
