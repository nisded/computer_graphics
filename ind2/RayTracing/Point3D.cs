using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Point3D
    {
        public float x, y, z;

        public Point3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Point3D(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Point3D(Point3D p)
        {
            if (p == null)
                return;
            x = p.x;
            y = p.y;
            z = p.z;
        }

        public override string ToString()
        {
            return String.Format("X:{0:f1} Y:{1:f1} Z:{2:f1}", x, y, z);
        }

        public float length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public static Point3D operator -(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);

        }

        public static float scalar(Point3D p1, Point3D p2)
        {
            return p1.x * p2.x + p1.y * p2.y + p1.z * p2.z;
        }

        public static Point3D norm(Point3D p)
        {
            float z = (float)Math.Sqrt((float)(p.x * p.x + p.y * p.y + p.z * p.z));
            if (z == 0)
                return new Point3D(p);
            return new Point3D(p.x / z, p.y / z, p.z / z);
        }

        public static Point3D operator +(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);

        }

        public static Point3D operator *(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.y * p2.z - p1.z * p2.y, p1.z * p2.x - p1.x * p2.z, p1.x * p2.y - p1.y * p2.x);
        }

        public static Point3D operator *(float t, Point3D p1)
        {
            return new Point3D(p1.x * t, p1.y * t, p1.z * t);
        }


        public static Point3D operator *(Point3D p1, float t)
        {
            return new Point3D(p1.x * t, p1.y * t, p1.z * t);
        }

        public static Point3D operator -(Point3D p1, float t)
        {
            return new Point3D(p1.x - t, p1.y - t, p1.z - t);
        }

        public static Point3D operator -(float t, Point3D p1)
        {
            return new Point3D(t - p1.x, t - p1.y, t - p1.z);
        }

        public static Point3D operator +(Point3D p1, float t)
        {
            return new Point3D(p1.x + t, p1.y + t, p1.z + t);
        }

        public static Point3D operator +(float t, Point3D p1)
        {
            return new Point3D(p1.x + t, p1.y + t, p1.z + t);
        }

        public static Point3D operator /(Point3D p1, float t)
        {
            return new Point3D(p1.x / t, p1.y / t, p1.z / t);
        }

        public static Point3D operator /(float t, Point3D p1)
        {
            return new Point3D(t / p1.x, t / p1.y, t / p1.z);
        }
    }
}
