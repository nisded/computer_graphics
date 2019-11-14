using System;

namespace ComputerGraphics8
{
	public class Plot : Primitive
	{
		private static double F(double x, double y)
		{
            if (x == 0 && y == 0)
                return 0;
			return (x * x * y) / (x * x * x * x + y * y);
		}

        public Plot()
            : this(-0.8, 0.8, 0.05, -0.8, 0.8, 0.05, F)
        {
        }

		public Plot(double x0, double x1, double dx, 
                double z0, double z1, double dz,
                Func<double, double, double> function)
            : base(Construct(x0, x1, dx, z0, z1, dz, function))
		{
		}

        private static Tuple<Vector[], int[][]> Construct(
            double x0, double x1, double dx, double z0, double z1, double dz,
            Func<double, double, double> function)
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
                    vertices[i * nz + j] = new Vector(x, function(x, z), z);
                }
            for (int i = 0; i < nx - 1; ++i)
                for (int j = 0; j < nz - 1; ++j)
                {
                    indices[i * (nz - 1) + j] = new int[4] {
                        i * nz + j,
                        (i + 1) * nz + j,
                        (i + 1) * nz + j + 1,
                        i * nz + j + 1 };
                }
            return new Tuple<Vector[], int[][]>(vertices, indices);
        }
	}
};

