using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RotationFigure
{
    class RotationFigure : Primitive
    {
        private List<XYZPoint> points = new List<XYZPoint>();

        private List<Verge> verges = new List<Verge>();

        private int count_start_points;

        public List<XYZPoint> Points { get { return points; } }
        public List<Verge> Verges { get { return verges; } }

        public int Count_start_poinits { get { return count_start_points; } }

        public RotationFigure(List<XYZPoint> p, List<Verge> v, int count_start_points)
        {
            points = p;
            verges = new List<Verge>();

            int density = v.Count / (count_start_points - 1);
            for (int i = 0; i < density; ++i)
                for (int j = 0; j < count_start_points - 1; ++j)
                    verges.Add(new Verge(new List<XYZPoint> {
                        points[i * count_start_points + j], points[(i + 1) % density * count_start_points + j],
                        points[(i + 1) % density * count_start_points + j + 1], points[i * count_start_points + j + 1] }));
        }

        public RotationFigure(IList<XYZPoint> p, int axis, int density)
        {
            if (axis < 0 || axis > 2)
                return;

            points.AddRange(p);
            List<XYZPoint> rotatedPoints = new List<XYZPoint>();
            Func<double, Transform> rotation;

            switch (axis)
            {
                case 0: rotation = Transform.RotateX; break;
                case 1: rotation = Transform.RotateY; break;
                default: rotation = Transform.RotateZ; break;
            }

            for (int i = 0; i < density; ++i)
            {
                double angle = 2 * Math.PI * i / (density - 1);
                foreach (var point in p)
                    rotatedPoints.Add(point.Transform(rotation(angle)));
                points.AddRange(rotatedPoints);
                rotatedPoints.Clear();
            }
            var n = p.Count;
            for (int i = 0; i < density; ++i)
                for (int j = 0; j < n - 1; ++j)
                    verges.Add(new Verge(new List<XYZPoint> {
                        points[i * n + j], points[(i + 1) % density * n + j],
                        points[(i + 1) % density * n + j + 1], points[i * n + j + 1] }));
        }

        public void Apply(Transform t)
        {
            foreach (var point in Points)
                point.Apply(t);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            foreach (var Verge in Verges)
                Verge.Draw(g, projection, width, height);
        }

        override public string ToString()
        {
            return "Rotation Figure";
        }
    }
}
