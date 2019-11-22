using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Texturing
{
    public class Graphics3D
    {
        public Bitmap ActiveTexture { get; set; }

        /*
         * Clockwise - сторона, на которой вершины идут по часовой стрелки.
         * Counterclockwise - сторона, на которой вершины идут против часовой стрелки.
         * None - никакая сторона.
         */
        //public enum Face { Clockwise, Counterclockwise, None }

        // Свойство, говорящее о том какую сторону треугольника не рисовать.
        //public Face CullFace { get; set; } = Face.Clockwise;

        // Буфер цвета.
        public Bitmap colorBuffer;

        private Graphics graphics;

        private Matrix viewProjection;

        private double Width; 

        private double Height;

        private Vector Center;

        private Vector CamPosition;

        public Graphics3D(Graphics g, Matrix viewProjection, double w, double h, Vector center, Vector camPos)
        {
            graphics = g;
            this.viewProjection = viewProjection;
            Width = w;
            Height = h;
            colorBuffer = new Bitmap((int)Width + 1, (int)Height + 1);
            Center = center;
            CamPosition = camPos;
        }

        private Vector SpaceToClip(Vector v)
        {
            return v * viewProjection;
        }

        private Vector ClipToScreen(Vector v)
        {
            return NormalizedToScreen(Normalize(v));
        }

        private Vector Normalize(Vector v)
        {
            return new Vector(v.X / v.W, v.Y / v.W, v.Z / v.W);
        }

        private Vector NormalizedToScreen(Vector v)
        {
            return new Vector(
                (v.X + 1) / 2 * Width,
                (-v.Y + 1) / 2 * Height,
                v.Z);
        }

        private static double Interpolate(double x0, double x1, double f)
        {
            return x0 + (x1 - x0) * f;
        }

        private static long Interpolate(long x0, long x1, double f)
        {
            return x0 + (long)((x1 - x0) * f);
        }

        private static Color Interpolate(Color a, Color b, double f)
        {
            var R = Interpolate(a.R, b.R, f);
            var G = Interpolate(a.G, b.G, f);
            var B = Interpolate(a.B, b.B, f);
            return Color.FromArgb((byte)R, (byte)G, (byte)B);
        }

        private static Vector Interpolate(Vector a, Vector b, double f)
        {
            return new Vector(
                Interpolate(a.X, b.X, f),
                Interpolate(a.Y, b.Y, f),
                Interpolate(a.Z, b.Z, f),
                Interpolate(a.W, b.W, f));
        }

        private static Vertex Interpolate(Vertex a, Vertex b, double f)
        {
            return new Vertex(
                Interpolate(a.Coordinate, b.Coordinate, f),
                Interpolate(a.Color, b.Color, f),
                Interpolate(a.Normal, b.Normal, f),
                Interpolate(a.UVCoordinate, b.UVCoordinate, f));
        }

        public void DrawPoint(Vertex a)
        {
            a.Coordinate = SpaceToClip(a.Coordinate);
            a.Coordinate = ClipToScreen(a.Coordinate);       
            graphics.FillRectangle(new SolidBrush(a.Color), (float)a.Coordinate.X - 2, (float)a.Coordinate.Y - 2, 5, 5);
        }

        private bool ShouldBeDrawn(Vector vertex)
        {
            return ((vertex.X >= 0 && vertex.X < Width) &&
                   (vertex.Y >= 0 && vertex.Y < Height) &&
                   (vertex.Z < 1) && (vertex.Z > -1));
        }

        public void DrawLine(Vertex a, Vertex b)
        {
            var t = SpaceToClip(a.Coordinate);
            var A = ClipToScreen(t);
            var u = SpaceToClip(b.Coordinate);
            var B = ClipToScreen(u);
            if (ShouldBeDrawn(A))
                graphics.DrawLine(new Pen(a.Color), (float)A.X, (float)A.Y, (float)B.X, (float)B.Y);          
        }

        public void DrawTriangle(Vertex a, Vertex b, Vertex c)
        {
            Vector p1 = a.Coordinate;
            Vector p2 = b.Coordinate;
            Vector p3 = c.Coordinate;

            double[,] matrix = new double[2, 3];
            matrix[0, 0] = p2.X - p1.X;
            matrix[0, 1] = p2.Y - p1.Y;
            matrix[0, 2] = p2.Z - p1.Z;
            matrix[1, 0] = p3.X - p1.X;
            matrix[1, 1] = p3.Y - p1.Y;
            matrix[1, 2] = p3.Z - p1.Z;

            double ni = matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1];
            double nj = matrix[0, 2] * matrix[1, 0] - matrix[0, 0] * matrix[1, 2];
            double nk = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            double d = -(ni * p1.X + nj * p1.Y + nk * p1.Z);

            Vector pp = new Vector(p1.X + ni, p1.Y + nj, p1.Z + nk);
            double val1 = ni * pp.X + nj * pp.Y + nk * pp.Z + d;
            double val2 = ni * Center.X + nj * Center.Y + nk * Center.Z + d;

            if (val1 * val2 > 0)
            {
                ni = -ni;
                nj = -nj;
                nk = -nk;
            }

            if (ni * (-CamPosition.X) + nj * (-CamPosition.Y) + nk * (-CamPosition.Z) + ni * p1.X + nj * p1.Y + nk * p1.Z < 0)               
                DrawTriangleInternal(a, b, c);           
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        private void DrawTriangleInternal(Vertex a, Vertex b, Vertex c)
        {
            a.Coordinate = SpaceToClip(a.Coordinate);
            a.Coordinate = ClipToScreen(a.Coordinate);
            b.Coordinate = SpaceToClip(b.Coordinate);
            b.Coordinate = ClipToScreen(b.Coordinate);
            c.Coordinate = SpaceToClip(c.Coordinate);
            c.Coordinate = ClipToScreen(c.Coordinate);

            /*if (Face.None != CullFace)
            {
                var u = b.Coordinate - a.Coordinate;
                var v = c.Coordinate - a.Coordinate;
                if (Face.Counterclockwise == CullFace)
                    Swap(ref u, ref v);
                if (Vector.AngleBet(new Vector(0, 0, 1), Vector.CrossProduct(u, v)) > 2*Math.PI / 3)
                    return;
            }*/

            if (a.Coordinate.Y > b.Coordinate.Y)
                Swap(ref a, ref b);
            if (a.Coordinate.Y > c.Coordinate.Y)
                Swap(ref a, ref c);
            if (b.Coordinate.Y > c.Coordinate.Y)
                Swap(ref b, ref c);

            for (double y = Math.Ceiling(a.Coordinate.Y); y < c.Coordinate.Y; ++y)
            {
                bool topHalf = y < b.Coordinate.Y;
                var a0 = a;
                var a1 = c;
                var left = Interpolate(a0, a1, (y - a0.Coordinate.Y) / (a1.Coordinate.Y - a0.Coordinate.Y));
                var b0 = topHalf ? a : b;
                var b1 = topHalf ? b : c;
                var right = Interpolate(b0, b1, (y - b0.Coordinate.Y) / (b1.Coordinate.Y - b0.Coordinate.Y));
                if (left.Coordinate.X > right.Coordinate.X)
                    Swap(ref left, ref right);
                for (double x = Math.Ceiling(left.Coordinate.X); x < right.Coordinate.X; ++x)
                {
                    var point = Interpolate(left, right, (x - left.Coordinate.X) / (right.Coordinate.X - left.Coordinate.X));
                    colorBuffer.SetPixel((int)x, (int)y, ActiveTexture.GetPixel(
                            (int)(point.UVCoordinate.X * (ActiveTexture.Width - 1)),
                            (int)(point.UVCoordinate.Y * (ActiveTexture.Height - 1))));                    
                }
            }
        }
    }
}
