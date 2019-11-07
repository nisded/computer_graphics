using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics7
{
    class Transform
    {
        private double[,] matrix = new double[4, 4];

        public double[,] Matrix { get { return matrix; } }

        public Transform()
        {
            matrix = Identity().matrix;
        }

        public Transform(double[,] matrix)
        {
            this.matrix = matrix;
        }

        public static Transform RotateX(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Transform(
                new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, cos, -sin, 0 },
                    { 0, sin, cos, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform RotateY(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Transform(
                new double[,]
                {
                    { cos, 0, sin, 0 },
                    { 0, 1, 0, 0 },
                    { -sin, 0, cos, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform RotateZ(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Transform(
                new double[,]
                {
                    { cos, -sin, 0, 0 },
                    { sin, cos, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform Scale(double fx, double fy, double fz)
        {
            return new Transform(
                new double[,] {
                    { fx, 0, 0, 0 },
                    { 0, fy, 0, 0 },
                    { 0, 0, fz, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform Translate(double dx, double dy, double dz)
        {
            return new Transform(
                new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { dx, dy, dz, 1 },
                });
        }

        public static Transform Identity()
        {
            return new Transform(
                new double[,] {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform OrthographicXYProjection()
        {
            return Identity();
        }

        public static Transform OrthographicXZProjection()
        {
            return Identity() * RotateX(-Math.PI / 2);
        }

        public static Transform OrthographicYZProjection()
        {
            return Identity() * RotateY(Math.PI / 2);
        }

        public static Transform IsometricProjection()
        {
            return Identity() * RotateY(Math.PI / 4) * RotateX(-Math.PI / 4);
        }

        public static Transform PerspectiveProjection()
        {
            return new Transform(
                new double[,] {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 10 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform operator *(Transform t1, Transform t2)
        {
            double[,] matrix = new double[4, 4];
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                {
                    matrix[i, j] = 0;
                    for (int k = 0; k < 4; ++k)
                        matrix[i, j] += t1.matrix[i, k] * t2.matrix[k, j];
                }
            return new Transform(matrix);
        }
    }
}
