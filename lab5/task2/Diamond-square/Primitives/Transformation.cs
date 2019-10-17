using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond_square.Primitives
{
    class Transformation
    {
        private float[] matrix = new float[9];

        public Transformation() { }

        public Transformation(float a, float b, float c,
                              float d, float e, float f,
                              float g, float h, float i)
        {
            matrix = new float[9] { a, b, c, d, e, f, g, h, i };
        }

        public Transformation(float[] matrix)
        {
            if (9 != matrix.Count()) throw new Exception("Bad number of elements in matrix.");
            this.matrix = matrix;
        }

        public float Get(int row, int col)
        {
            return matrix[row * 3 + col];
        }

        public void Set(int row, int col, float value)
        {
            matrix[row * 3 + col] = value;
        }

        public static Transformation Scale(float fx, float fy)
        {
            return new Transformation(
                fx, 0, 0,
                 0, fy, 0,
                 0, 0, 1
            );
        }

        public static Transformation Rotate(float angle)
        {
            var sin = (float)Math.Sin(angle);
            var cos = (float)Math.Cos(angle);
            return new Transformation(
                 cos, sin, 0,
                -sin, cos, 0,
                    0, 0, 1
            );
        }

        public static Transformation Translate(float dx, float dy)
        {
            return new Transformation(
                 1, 0, 0,
                 0, 1, 0,
                dx, dy, 1
            );
        }

        public static Transformation operator *(Transformation t1, Transformation t2)
        {
            Transformation result = new Transformation();
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                {
                    float value = 0;
                    for (int k = 0; k < 3; ++k)
                        value += t1.Get(i, k) * t2.Get(k, j);
                    result.Set(i, j, value);
                }
            return result;
        }
    }
}
