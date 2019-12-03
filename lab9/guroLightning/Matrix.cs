using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GuroLightning
{
    public class Matrix
    {
        private double[,] data;

        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public Matrix()
        {
            data = new double[,] {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                };
        }

        public Matrix(double[,] data)
        {
            Debug.Assert(4 == data.GetLength(0));
            Debug.Assert(4 == data.GetLength(1));
            this.data = data;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            double[,] data = new double[4, 4];
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                {
                    data[i, j] = 0;
                    for (int k = 0; k < 4; ++k)
                        data[i, j] += m1[i, k] * m2[k, j];
                }
            return new Matrix(data);
        }

        private static double[,] Exclude(double [,] matrix, int row, int col)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n - 1, n - 1];
            for (int r = 0; r < n; ++r)
            {
                if (r == row) continue;
                int i = r - (r < row ? 0 : 1);
                for (int c = 0; c < n; ++c)
                {
                    if (c == col) continue;
                    int j = c - (c < col ? 0 : 1);
                    result[i, j] = matrix[r, c];
                }
            }
            return result;
        }

        private static double Minor(double[,] matrix, int i, int j)
        {
            return Determinant(Exclude(matrix, i, j));
        }

        private static double Cofactor(double[,] matrix, int i, int j)
        {
            return (0 == (i + j) % 2 ? 1 : -1) * Minor(matrix, i, j);
        }

        private static double Determinant(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (2 == n)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            return Enumerable.Range(0, n)
                .Select(i => matrix[0, i] * Cofactor(matrix, 0, i))
                .Sum();
        }

        public double Determinant()
        {
            return Determinant(data);
        }

        private static double[,] CofactorMatrix(double [,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    result[i, j] = Cofactor(matrix, i, j);
            return result;
        }

        private static double[,] Adjoint(double[,] matrix)
        {
            return Transpose(CofactorMatrix(matrix));
        }

        private double[,] Scale(double[,] matrix, double factor)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    result[i, j] = matrix[i, j] * factor;
            return result;
        }

        public Matrix Inverse()
        {
            return new Matrix(Scale(Adjoint(data), 1 / Determinant(data)));
        }

        private static double[,] Transpose(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    result[i, j] = matrix[j, i];
            return result;
        }

        public Matrix Transpose()
        {
            return new Matrix(Transpose(data));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    builder.Append(data[i, j]);
                    builder.Append(' ');
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
