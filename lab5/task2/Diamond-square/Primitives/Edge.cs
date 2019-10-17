using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Diamond_square.Primitives
{
    class Edge : Primitive
    {
        private Point2D a;
        private Point2D b;

        public Point2D A { get { return a; } set { a = value; } }
        public Point2D B { get { return b; } set { b = value; } }

        public Point2D Center
        {
            get
            {
                return new Point2D((A.X + B.X) / 2, (A.Y + B.Y) / 2);
            }
        }

        public Edge(Point2D a, Point2D b)
        {
            this.a = a;
            this.b = b;
        }

        public void Draw(Graphics g, bool selected = true)
        {
            Pen pen = new Pen(selected ? Color.Red : Color.Black);
            pen.Width = 2;
            g.DrawLine(pen, A.X, A.Y, B.X, B.Y);
        }

        public void Apply(Transformation t)
        {
            A.Apply(t);
            B.Apply(t);
        }

        /* Определяет расстояние до точки. Справа от прямой расстояние положительное, 
         * слева - отрицательное. */
        public float Distance(Point2D point)
        {
            var dx = B.X - A.X;
            var dy = B.Y - A.Y;
            var n = (float)Math.Sqrt(dy * dy + dx * dx);
            return (dx * point.Y - dy * point.X - dx * A.Y + dy * A.X) / n;
        }
    }
}
