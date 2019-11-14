using System;

namespace ComputerGraphics8
{
    public class Icosahedron : Primitive
    {
        public Icosahedron(double size)
            : base(Construct(size))
        {
        }

        private static Tuple<Vector[], int[][]> Construct(double size)
        {
            var vertices = new Vector[12];
            var indices = new int[20][];
            double R = (size * Math.Sqrt(2.0 * (5.0 + Math.Sqrt(5.0)))) / 4;
            double r = (size * Math.Sqrt(3.0) * (3.0 + Math.Sqrt(5.0))) / 12;
            for (int i = 0; i < 5; ++i)
            {
                vertices[2 * i] = new Vector(
                    r * Math.Cos(2 * Math.PI / 5 * i),
                    R / 2,
                    r * Math.Sin(2 * Math.PI / 5 * i));
                vertices[2 * i + 1] = new Vector(
                    r * Math.Cos(2 * Math.PI / 5 * i + 2 * Math.PI / 10),
                    -R / 2,
                    r * Math.Sin(2 * Math.PI / 5 * i + 2 * Math.PI / 10));
            }
            vertices[10] = new Vector(0, R, 0);
            vertices[11] = new Vector(0, -R, 0);
            for (int i = 0; i < 10; ++i)
                indices[i] = new int[3] { i, (i + 1) % 10, (i + 2) % 10 };
            for (int i = 0; i < 5; ++i)
            {
                indices[10 + 2 * i] = new int[3] { 2 * i, 10, (2 * (i + 1)) % 10 };
                indices[10 + 2 * i + 1] = new int[3] { 2 * i + 1, 11, (2 * (i + 1) + 1) % 10 };
            }
            return new Tuple<Vector[], int[][]>(vertices, indices);
        }
    }
}
