using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Side
    {
        public Figure host = null;
        public List<int> points = new List<int>();
        public Pen drawing_pen = new Pen(Color.Black);
        public Point3D Normal;

        public Side(Figure h = null)
        {
            host = h;
        }
        public Side(Side s)
        {
            points = new List<int>(s.points);
            host = s.host;
            drawing_pen = s.drawing_pen.Clone() as Pen;
            Normal = new Point3D(s.Normal);
        }
        public Point3D get_point(int ind)
        {
            if (host != null)
                return host.points[points[ind]];
            return null;
        }

        public static Point3D norm(Side S)
        {
            if (S.points.Count() < 3)
                return new Point3D(0, 0, 0);
            Point3D U = S.get_point(1) - S.get_point(0);
            Point3D V = S.get_point(S.points.Count - 1) - S.get_point(0);
            Point3D normal = U * V;
            return Point3D.norm(normal);
        }
    }
}
