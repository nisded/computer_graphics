using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics6
{
    class XYZPoint : Primitive
    {
        private double[] coords = new double[] { 0, 0, 0, 1 };

        public double X { get { return coords[0]; } set { coords[0] = value; } }
        public double Y { get { return coords[1]; } set { coords[1] = value; } }
        public double Z { get { return coords[2]; } set { coords[2] = value; } }

        public XYZPoint() { }

        public XYZPoint(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        private XYZPoint(double[] arr)
        {
            coords = arr;
        }

        public static XYZPoint FromPoint(Point point)
        {
            return new XYZPoint(point.X, point.Y, 0);
        }

        public void Apply(Transform t)
        {
            double[] newCoords = new double[4];
            for (int i = 0; i < 4; ++i)
            {
                newCoords[i] = 0;
                for (int j = 0; j < 4; ++j)
                    newCoords[i] += coords[j] * t.Matrix[j, i];
            }
            coords = newCoords;
        }

        public XYZPoint Transform(Transform t)
        {
            var p = new XYZPoint(X, Y, Z);
            p.Apply(t);
            return p;
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            var projected = Transform(projection);
            if (Z < -1 || 1 < Z) return;
            var x = (projected.X + 1) / 2 * width;
            var y = (-projected.Y + 1) / 2 * height;
            g.DrawEllipse(new Pen(Color.Black, 2), (float)x, (float)y, 2, 2);
        }

        /*
         * Преобразует координаты из ([-1, 1], [-1, 1], [-1, 1]) в ([0, width), [0, height), [-1, 1]).
         */
        public XYZPoint NormalizedToDisplay(int width, int height)
        {
            var x = (X + 1) / 2 * width;
            var y = (-Y + 1) / 2 * height;
            return new XYZPoint(x, y, Z);
        }
    }
}
