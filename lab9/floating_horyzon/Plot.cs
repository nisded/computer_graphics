using floating_horyzon.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace floating_horyzon
{
    public static class Plot
    {
        private static double Func(double x, double y)
        {
            double r = x * x + y * y;
            return Math.Cos(r) / (r + 1);
        }
        public static Mesh get_plot(
            double x0, double x1, double dx, double z0, double z1, double dz,
            double AngleX = Math.PI/4, double AngleY = Math.PI / 2, double AngleZ = Math.PI / 4)
        {
            int nx = (int)((x1 - x0) / dx);
            int nz = (int)((z1 - z0) / dz);
            var vertices = new Vector[nx * nz];
            var indices = new int[(nx - 1) * (nz - 1)][];
            for (int i = 0; i < nx; ++i)
                for (int j = 0; j < nz; ++j)
                {
                    var x = x0 + dx * i;
                    var z = z0 + dz * j;
                    vertices[i * nz + j] = new Vector(x, Func(x, z), z);
                }
            for (int i = 0; i < nx - 1; ++i)
                for (int j = 0; j < nz - 1; j++)
                {
                    indices[i * (nz - 1) + j] = new int[4] {
                        i * nz + j,
                        (i + 1) * nz + j,
                        (i + 1) * nz + j + 1,
                        i * nz + j + 1
                    };
                }

			Mesh m = new Mesh(vertices, indices);

			m.Apply(Transformations.RotateX(-AngleX) *
					Transformations.RotateY(0) *
					Transformations.RotateZ(0));

			m.Apply(Transformations.RotateX(0) *
					Transformations.RotateY(0) *
					Transformations.RotateZ(-AngleZ));
			
			m.Apply(Transformations.RotateX(0) *
					Transformations.RotateY(-AngleY) *
					Transformations.RotateZ(0));

			int[][] del_y = DelBadY(vertices, indices, nz, nx);

			m = new Mesh(vertices, del_y);


			m.Apply(Transformations.RotateX(0) *
					Transformations.RotateY(AngleY) *
					Transformations.RotateZ(0));

			m.Apply(Transformations.RotateX(0) *
					Transformations.RotateY(0) *
					Transformations.RotateZ(AngleZ));

			m.Apply(Transformations.RotateX(AngleX) *
					Transformations.RotateY(0) *
					Transformations.RotateZ(0));

			return m;
        }

        private static int[][] DelBadY(Vector[] vertices, int[][] indices, int nz, int nx)
        {
            List<int[]> res_indices = new List<int[]>();

            for (int i = 0; i < nx - 1; ++i)
            {
                double y_max = double.MinValue;
                double y_min = double.MaxValue;
                for (int j = 0; j < i; ++j)
                {
                    if ((vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][0]].Y > y_max ||
                        vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][2]].Y > y_max) &&
                        (vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][1]].Y > y_max ||
                        vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][3]].Y > y_max))
                    {
                        res_indices.Add(indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)]);
                        y_max = Math.Max(Math.Max(vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][0]].Y,
                                                  vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][1]].Y),
                                         Math.Max(vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][2]].Y,
                                                  vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][3]].Y));
                    }

                    if ((vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][0]].Y < y_min ||
                        vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][2]].Y < y_min )&&
                        (vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][1]].Y < y_min ||
                        vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][3]].Y < y_min))
                    {
                        res_indices.Add(indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)]);
                        y_min = Math.Min(Math.Min(vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][0]].Y,
                                                  vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][1]].Y),
                                         Math.Min(vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][2]].Y,
                                                  vertices[indices[(nz - (2 + j)) * (nz - 1) + (i - j - 1)][3]].Y));
                    }
                }
            }


            for (int i = 0; i < nx - 1; ++i)
            {
                double y_max = double.MinValue;
                double y_min = double.MaxValue;
                for (int j = i; j >= 0; --j)
                {
                    if ((vertices[indices[(j + 1) * nx - (i + 2)][0]].Y > y_max ||
                        vertices[indices[(j + 1) * nx - (i + 2)][2]].Y > y_max) &&
                        (vertices[indices[(j + 1) * nx - (i + 2)][1]].Y > y_max ||
                        vertices[indices[(j + 1) * nx - (i + 2)][3]].Y > y_max))
                    {
                        res_indices.Add(indices[(j + 1) * nx - (i + 2)]);
                        y_max = Math.Max(Math.Max(vertices[indices[(j + 1) * nx - (i + 2)][0]].Y,
                                                  vertices[indices[(j + 1) * nx - (i + 2)][1]].Y),
                                         Math.Max(vertices[indices[(j + 1) * nx - (i + 2)][2]].Y,
                                                  vertices[indices[(j + 1) * nx - (i + 2)][3]].Y));
                    }

                    if ((vertices[indices[(j + 1) * nx - (i + 2)][0]].Y < y_min ||
                        vertices[indices[(j + 1) * nx - (i + 2)][2]].Y < y_min) &&
                        (vertices[indices[(j + 1) * nx - (i + 2)][1]].Y < y_min ||
                        vertices[indices[(j + 1) * nx - (i + 2)][3]].Y < y_min))
                    {
                        res_indices.Add(indices[(j + 1) * nx - (i + 2)]);
                        y_min = Math.Min(Math.Min(vertices[indices[(j + 1) * nx - (i + 2)][0]].Y,
                                                  vertices[indices[(j + 1) * nx - (i + 2)][1]].Y),
                                         Math.Min(vertices[indices[(j + 1) * nx - (i + 2)][2]].Y,
                                                  vertices[indices[(j + 1) * nx - (i + 2)][3]].Y));
                    }
                }
            }
            return res_indices.ToArray();
        }
    }
}
