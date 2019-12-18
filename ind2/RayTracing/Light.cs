using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Light: Figure
    {
        public Point3D point_light;       // точка, где находится источник света
        public Point3D color_light;       // цвет источника света

        public Light(Point3D p, Point3D c)
        {
            point_light = new Point3D(p);
            color_light = new Point3D(c);
        }

        // вычисление локальной модели освещения
        public Point3D shade(Point3D hit_point, Point3D normal, Point3D color_obj, float diffuse_coef)
        {
            Point3D dir = point_light - hit_point;
            dir = Point3D.norm(dir);                // направление луча из источника света в точку удара

            Point3D diff = diffuse_coef * color_light * Math.Max(Point3D.scalar(normal, dir), 0);
            return new Point3D(diff.x * color_obj.x, diff.y * color_obj.y, diff.z * color_obj.z);
        }
    }
}
