using System;

namespace Texturing
{
    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }

        public Vector(double x, double y, double z = 0, double w = 1)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Vector operator *(double x, Vector v)
        {
            for (int i = 0; i < 3; ++i)
                v[i] *= x;
            return v;
        }

        public static Vector operator *(Vector v, double x)
        {
            return x * v;
        }

        public static Vector operator /(Vector v, double x)
        {
            return v * (1 / x);
        }

        public static Vector operator +(Vector u, Vector v)
        {
            Vector result = new Vector();
            for (int i = 0; i < 3; ++i)
                result[i] = u[i] * v.W + v[i] * u.W;
            result.W = u.W * v.W;
            return result;
        }

        public static Vector operator +(double x, Vector v)
        {
            return v + x;
        }

        public static Vector operator +(Vector v, double x)
        {
            for (int i = 0; i < 3; ++i)
                v[i] += x * v.W;
            return v;
        }

        public static Vector operator -(Vector v, double x)
        {
            return v + (-x);
        }

        public static Vector operator -(double x, Vector v)
        {
            return x + (-v);
        }

        public static Vector operator -(Vector v)
        {
            return -1 * v;
        }

        public Vector Normalize()
        {
            var length = Modul() * W;
            if (0 == length) return new Vector(0, 0, 0);
            var result = new Vector(X / length, Y / length, Z / length, 1);
            var resultLength = result.Modul();
            if (0.1e6 < Math.Abs(1 - resultLength)) throw new Exception("You shouldn't see these words.");
            return result;
        }

        // Скалярное произведение векторов
        public static double DotProduct(Vector u, Vector v)
        {
            double result = 0;
            for (int i = 0; i < 3; ++i)
                result += u[i] * v[i];
            return result / (u.W * v.W);
        }

        public static double DotProduct4(Vector u, Vector v)
        {
            double result = 0;
            for (int i = 0; i < 4; ++i)
                result += u[i] * v[i];
            return result;
        }

        // Векторное произведение векторов
        public static Vector CrossProduct(Vector u, Vector v)
        {
            return new Vector(
                (u[1] * v[2] - u[2] * v[1]) / (u.W * v.W),
                (u[2] * v[0] - u[0] * v[2]) / (u.W * v.W),
                (u[0] * v[1] - u[1] * v[0]) / (u.W * v.W));
        }

        public static Vector operator *(Vector v, Matrix m)
        {
            var result = v;
            for (int i = 0; i < 4; ++i)
            {
                result[i] = 0;
                for (int j = 0; j < 4; ++j)
                    result[i] += v[j] * m[j, i];
            }
            return result;
        }

        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    case 3: return W;
                    default: throw new IndexOutOfRangeException("Vertex has only 4 coordinates");
                }
            }
            set
            {
                switch (i)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    case 3: W = value; break;
                    default: throw new IndexOutOfRangeException("Vertex has only 4 coordinates");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        // Модуль
        public double Modul()
        {
            return Math.Sqrt(DotProduct(this, this));
        }

        // Угол между векторами
        public static double AngleBet(Vector u, Vector v)
        {
            return Math.Acos(DotProduct(u, v) / (u.Modul() * v.Modul()));
        }

        public static double Dist(Vector u, Vector v)
        {
            return Math.Sqrt((u.X - v.X) * (u.X - v.X) +
                             (u.Y - v.Y) * (u.Y - v.Y) +
                             (u.Z - v.Z) * (u.Z - v.Z));
        }

        public static Vector operator -(Vector u, Vector v)
        {
            return u + (-v);
        }
    }
}
