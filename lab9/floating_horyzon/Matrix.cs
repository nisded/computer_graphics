using System.Diagnostics;
using System.Linq;
using System.Text;

namespace floating_horyzon
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

        private double[,] Scale(double[,] matrix, double factor)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    result[i, j] = matrix[i, j] * factor;
            return result;
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
