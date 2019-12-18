using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Figure
    {
        public static float EPS = 0.0001f;
        public List<Point3D> points = new List<Point3D>(); // точки 
        public List<Side> sides = new List<Side>();        // стороны
        public Material figure_material;
        public bool isRoom = false;                       // данный куб - комната?
        public Material front_wall_material;               // материалы для стен комнаты
        public Material back_wall_material;
        public Material left_wall_material;
        public Material right_wall_material;
        public Material up_wall_material;
        public Material down_wall_material;

        public Figure() { }

        public Figure(Figure f)
        {
            foreach (Point3D p in f.points)
                points.Add(new Point3D(p));

            foreach (Side s in f.sides)
            {
                sides.Add(new Side(s));
                sides.Last().host = this;
            }
        }

        public bool ray_intersects_triangle(Ray r, Point3D p0, Point3D p1, Point3D p2, out float intersect)
        {
            intersect = -1;

            Point3D edge1 = p1 - p0;
            Point3D edge2 = p2 - p0;
            Point3D h = r.direction * edge2;
            float a = Point3D.scalar(edge1, h);

            if (a > -EPS && a < EPS)
                return false;       // This ray is parallel to this triangle.

            float f = 1.0f / a;
            Point3D s = r.start - p0;
            float u = f * Point3D.scalar(s, h);

            if (u < 0 || u > 1)
                return false;

            Point3D q = s * edge1;
            float v = f * Point3D.scalar(r.direction, q);

            if (v < 0 || u + v > 1)
                return false;
            // At this stage we can compute t to find out where the intersection point is on the line.
            float t = f * Point3D.scalar(edge2, q);
            if (t > EPS)
            {
                intersect = t;
                return true;
            }
            else      // This means that there is a line intersection but not a ray intersection.
                return false;
        }

        // пересечение луча с фигурой
        public virtual bool figure_intersection(Ray r, out float intersect, out Point3D normal)
        {
            intersect = 0;
            normal = null;
            Side sd = null;
            int fm = -1;         // номер стены комнаты, которую пересек луч

            for (int i = 0; i < sides.Count; ++i)
            {
                
                if (sides[i].points.Count == 3)
                {
                    if (ray_intersects_triangle(r, sides[i].get_point(0), sides[i].get_point(1), sides[i].get_point(2), out float t) && (intersect == 0 || t < intersect))
                    {
                        intersect = t;
                        sd = sides[i];
                    }
                }
                else if (sides[i].points.Count == 4)
                {
                    if (ray_intersects_triangle(r, sides[i].get_point(0), sides[i].get_point(1), sides[i].get_point(3), out float t) && (intersect == 0 || t < intersect))
                    {
                        fm = i;
                        intersect = t;
                        sd = sides[i];
                    }
                    else if (ray_intersects_triangle(r, sides[i].get_point(1), sides[i].get_point(2), sides[i].get_point(3), out t) && (intersect == 0 || t < intersect))
                    {
                        fm = i;
                        intersect = t;
                        sd = sides[i];
                    }
                }
            }

            if (intersect != 0)
            {
                normal = Side.norm(sd);
                if (isRoom)
                    switch (fm)
                    {
                        case 0:
                            figure_material = new Material(back_wall_material);
                            break;
                        case 1:
                            figure_material = new Material(front_wall_material);
                            break;
                        case 2:
                            figure_material = new Material(right_wall_material);
                            break;
                        case 3:
                            figure_material = new Material(left_wall_material);
                            break;
                        case 4:
                            figure_material = new Material(up_wall_material);
                            break;
                        case 5:
                            figure_material = new Material(down_wall_material);
                            break;
                        default:
                            break;
                    }
                figure_material.clr = new Point3D(sd.drawing_pen.Color.R / 255f, sd.drawing_pen.Color.G / 255f, sd.drawing_pen.Color.B / 255f);
                return true;
            }

            return false;
        }


        ///
        /// ----------------------------- TRANSFORMS SUPPORT METHODS --------------------------------
        ///

        public float[,] get_matrix()
        {
            var res = new float[points.Count, 4];
            for (int i = 0; i < points.Count; i++)
            {
                res[i, 0] = points[i].x;
                res[i, 1] = points[i].y;
                res[i, 2] = points[i].z;
                res[i, 3] = 1;
            }
            return res;
        }

        public void apply_matrix(float[,] matrix)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].x = matrix[i, 0] / matrix[i, 3];
                points[i].y = matrix[i, 1] / matrix[i, 3];
                points[i].z = matrix[i, 2] / matrix[i, 3];

            }
        }

        private Point3D get_center()
        {
            Point3D res = new Point3D(0, 0, 0);
            foreach (Point3D p in points)
            {
                res.x += p.x;
                res.y += p.y;
                res.z += p.z;

            }
            res.x /= points.Count();
            res.y /= points.Count();
            res.z /= points.Count();
            return res;
        }

        ///
        /// ----------------------------- APHINE TRANSFORMS METHODS --------------------------------
        ///

        public void rotate_around_rad(float rangle, string type)
        {
            float[,] mt = get_matrix();
            Point3D center = get_center();
            switch (type)
            {
                case "CX":
                    mt = apply_offset(mt, -center.x, -center.y, -center.z);
                    mt = apply_rotation_X(mt, rangle);
                    mt = apply_offset(mt, center.x, center.y, center.z);
                    break;
                case "CY":
                    mt = apply_offset(mt, -center.x, -center.y, -center.z);
                    mt = apply_rotation_Y(mt, rangle);
                    mt = apply_offset(mt, center.x, center.y, center.z);
                    break;
                case "CZ":
                    mt = apply_offset(mt, -center.x, -center.y, -center.z);
                    mt = apply_rotation_Z(mt, rangle);
                    mt = apply_offset(mt, center.x, center.y, center.z);
                    break;
                case "X":
                    mt = apply_rotation_X(mt, rangle);
                    break;
                case "Y":
                    mt = apply_rotation_Y(mt, rangle);
                    break;
                case "Z":
                    mt = apply_rotation_Z(mt, rangle);
                    break;
                default:
                    break;
            }
            apply_matrix(mt);
        }

        public void rotate_around(float angle, string type)
        {
            rotate_around_rad(angle * (float)Math.PI / 180, type);
        }

        public void scale_axis(float xs, float ys, float zs)
        {
            float[,] pnts = get_matrix();
            pnts = apply_scale(pnts, xs, ys, zs);
            apply_matrix(pnts);
        }

        public void offset(float xs, float ys, float zs)
        {
            apply_matrix(apply_offset(get_matrix(), xs, ys, zs));
        }

        public virtual void set_pen(Pen dw)
        {
            foreach (Side s in sides)
                s.drawing_pen = dw;

        }

        public void scale_around_center(float xs, float ys, float zs)
        {
            float[,] pnts = get_matrix();
            Point3D p = get_center();
            pnts = apply_offset(pnts, -p.x, -p.y, -p.z);
            pnts = apply_scale(pnts, xs, ys, zs);
            pnts = apply_offset(pnts, p.x, p.y, p.z);
            apply_matrix(pnts);
        }

        public void line_rotate_rad(float rang, Point3D p1, Point3D p2)
        {

            p2 = new Point3D(p2.x - p1.x, p2.y - p1.y, p2.z - p1.z);
            p2 = Point3D.norm(p2);

            float[,] mt = get_matrix();
            apply_matrix(rotate_around_line(mt, p1, p2, rang));
        }

        /// <summary>
        /// rotate figure line
        /// </summary>
        /// <param name="ang">angle in degrees</param>
        /// <param name="p1">line start</param>
        /// <param name="p2">line end</param>
        public void line_rotate(float ang, Point3D p1, Point3D p2)
        {
            ang = ang * (float)Math.PI / 180;
            line_rotate_rad(ang, p1, p2);
        }


        ///
        /// ----------------------------- STATIC BACKEND FOR TRANSFROMS --------------------------------
        ///

        private static float[,] rotate_around_line(float[,] transform_matrix, Point3D start, Point3D dir, float angle)
        {
            float cos_angle = (float)Math.Cos(angle);
            float sin_angle = (float)Math.Sin(angle);
            float val00 = dir.x * dir.x + cos_angle * (1 - dir.x * dir.x);
            float val01 = dir.x * (1 - cos_angle) * dir.y + dir.z * sin_angle;
            float val02 = dir.x * (1 - cos_angle) * dir.z - dir.y * sin_angle;
            float val10 = dir.x * (1 - cos_angle) * dir.y - dir.z * sin_angle;
            float val11 = dir.y * dir.y + cos_angle * (1 - dir.y * dir.y);
            float val12 = dir.y * (1 - cos_angle) * dir.z + dir.x * sin_angle;
            float val20 = dir.x * (1 - cos_angle) * dir.z + dir.y * sin_angle;
            float val21 = dir.y * (1 - cos_angle) * dir.z - dir.x * sin_angle;
            float val22 = dir.z * dir.z + cos_angle * (1 - dir.z * dir.z);
            float[,] rotateMatrix = new float[,] { { val00, val01, val02, 0 }, { val10, val11, val12, 0 }, { val20, val21, val22, 0 }, { 0, 0, 0, 1 } };
            return apply_offset(multiply_matrix(apply_offset(transform_matrix, -start.x, -start.y, -start.z), rotateMatrix), start.x, start.y, start.z);
        }

        private static float[,] multiply_matrix(float[,] m1, float[,] m2)
        {
            float[,] res = new float[m1.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    for (int k = 0; k < m2.GetLength(0); k++)
                    {
                        res[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return res;
        }

        private static float[,] apply_offset(float[,] transform_matrix, float offset_x, float offset_y, float offset_z)
        {
            float[,] translationMatrix = new float[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { offset_x, offset_y, offset_z, 1 } };
            return multiply_matrix(transform_matrix, translationMatrix);
        }

        private static float[,] apply_rotation_X(float[,] transform_matrix, float angle)
        {
            float[,] rotationMatrix = new float[,] { { 1, 0, 0, 0 }, { 0, (float)Math.Cos(angle), (float)Math.Sin(angle), 0 },
                { 0, -(float)Math.Sin(angle), (float)Math.Cos(angle), 0}, { 0, 0, 0, 1} };
            return multiply_matrix(transform_matrix, rotationMatrix);
        }

        private static float[,] apply_rotation_Y(float[,] transform_matrix, float angle)
        {
            float[,] rotationMatrix = new float[,] { { (float)Math.Cos(angle), 0, -(float)Math.Sin(angle), 0 }, { 0, 1, 0, 0 },
                { (float)Math.Sin(angle), 0, (float)Math.Cos(angle), 0}, { 0, 0, 0, 1} };
            return multiply_matrix(transform_matrix, rotationMatrix);
        }

        private static float[,] apply_rotation_Z(float[,] transform_matrix, float angle)
        {
            float[,] rotationMatrix = new float[,] { { (float)Math.Cos(angle), (float)Math.Sin(angle), 0, 0 }, { -(float)Math.Sin(angle), (float)Math.Cos(angle), 0, 0 },
                { 0, 0, 1, 0 }, { 0, 0, 0, 1} };
            return multiply_matrix(transform_matrix, rotationMatrix);
        }

        private static float[,] apply_scale(float[,] transform_matrix, float scale_x, float scale_y, float scale_z)
        {
            float[,] scaleMatrix = new float[,] { { scale_x, 0, 0, 0 }, { 0, scale_y, 0, 0 }, { 0, 0, scale_z, 0 }, { 0, 0, 0, 1 } };
            return multiply_matrix(transform_matrix, scaleMatrix);
        }


        ///
        /// ------------------------STATIC READY FIGURES-----------------------------
        ///

        static public Figure get_Hexahedron(float sz)
        {
            Figure res = new Figure();
            res.points.Add(new Point3D(sz / 2, sz / 2, sz / 2)); // 0 
            res.points.Add(new Point3D(-sz / 2, sz / 2, sz / 2)); // 1
            res.points.Add(new Point3D(-sz / 2, sz / 2, -sz / 2)); // 2
            res.points.Add(new Point3D(sz / 2, sz / 2, -sz / 2)); //3

            res.points.Add(new Point3D(sz / 2, -sz / 2, sz / 2)); // 4
            res.points.Add(new Point3D(-sz / 2, -sz / 2, sz / 2)); //5
            res.points.Add(new Point3D(-sz / 2, -sz / 2, -sz / 2)); // 6
            res.points.Add(new Point3D(sz / 2, -sz / 2, -sz / 2)); // 7

            Side s = new Side(res);
            s.points.AddRange(new int[] { 3, 2, 1, 0 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 4, 5, 6, 7 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 2, 6, 5, 1 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 0, 4, 7, 3 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 1, 5, 4, 0 });
            res.sides.Add(s);

            s = new Side(res);
            s.points.AddRange(new int[] { 2, 3, 7, 6 });
            res.sides.Add(s);

            return res;
        }
    }
}
