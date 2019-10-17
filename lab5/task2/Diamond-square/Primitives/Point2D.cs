using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Diamond_square.Primitives
{
    class Point2D : Primitive
    {
        private static float POINT_SIZE = 6;

        private float[] coords = new float[] { 0, 0, 1 };

        public float X { get { return coords[0]; } set { coords[0] = value; } }
        public float Y { get { return coords[1]; } set { coords[1] = value; } }

        public Point2D() { }

        public Point2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Point2D FromPoint(Point point)
        {
            return new Point2D(point.X, point.Y);
        }

        public void Draw(Graphics g, bool selected = true)
        {
            var brush = selected ? Brushes.Red : Brushes.Black;
            g.FillRectangle(brush, X - POINT_SIZE / 2, Y - POINT_SIZE / 2, POINT_SIZE, POINT_SIZE);
        }

        public void Apply(Transformation t)
        {
            float[] newCoords = new float[3];
            for (int i = 0; i < 3; ++i)
            {
                newCoords[i] = 0;
                for (int j = 0; j < 3; ++j)
                    newCoords[i] += coords[j] * t.Get(j, i);
            }
            coords = newCoords;
        }
    }
}
