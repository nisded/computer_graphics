using System;

namespace ComputerGraphics8
{
    public class Tetrahedron : Primitive
    {
        public Tetrahedron(double size)
            : base(Construct(size))
        {
        }

        private static Tuple<Vector[], int[][]> Construct(double size)
        {
            var vertices = new Vector[4];
            var indices = new int[4][];
            double h = Math.Sqrt(2.0 / 3.0) * size;
            vertices[0] = new Vector(-size / 2, 0, h / 3);
            vertices[1] = new Vector(0, 0, -h * 2 / 3);
            vertices[2] = new Vector(size / 2, 0, h / 3);
            vertices[3] = new Vector(0, h, 0);

            
            indices[0] = new int[3] { 0, 1, 2 };
            indices[1] = new int[3] { 1, 3, 0 };
            indices[2] = new int[3] { 0, 3, 2 };
            indices[3] = new int[3] { 2, 3, 1 };
            return new Tuple<Vector[], int[][]>(vertices, indices);
        }
    }
}
