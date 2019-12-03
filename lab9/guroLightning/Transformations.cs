using System;

namespace GuroLightning
{
    public static class Transformations
    {
        public static Matrix RotateX(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Matrix(
                new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, cos, sin, 0 },
                    { 0, -sin, cos, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Matrix RotateY(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Matrix(
                new double[,]
                {
                    { cos, 0, -sin, 0 },
                    { 0, 1, 0, 0 },
                    { sin, 0, cos, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Matrix RotateZ(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Matrix(
                new double[,]
                {
                    { cos, sin, 0, 0 },
                    { -sin, cos, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Matrix Scale(double fx, double fy, double fz)
        {
            return new Matrix(
                new double[,] {
                    { fx, 0, 0, 0 },
                    { 0, fy, 0, 0 },
                    { 0, 0, fz, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Matrix Translate(Vector v)
        {
            return Translate(v.X, v.Y, v.Z);
        }

        public static Matrix Translate(double dx, double dy, double dz)
        {
            return new Matrix(
                new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { dx, dy, dz, 1 },
                });
        }

        public static Matrix Identity()
        {
            return new Matrix(
                new double[,] {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Matrix OrthogonalProjection()
        {
            return new Matrix(
                new double[4, 4] {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, -1, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Matrix PerspectiveProjection(double left, double right, double bottom, double top, double near, double far)
        {
            var a = 2 * near / (right - left);
            var b = (right + left) / (right - left);
            var c = 2 * near / (top - bottom);
            var d = (top + bottom) / (top - bottom);
            var e = -(far + near) / (far - near);
            var f = -2 * far * near / (far - near);
            return new Matrix(
                new double[4, 4] {
                    { a, 0, 0, 0 },
                    { 0, c, 0, 0 },
                    { b, d, e, -1 },
                    { 0, 0, f, 0 }
                });
        }
    }
}
