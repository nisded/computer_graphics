using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affine_transformations2D
{
    class Matrix
    {
        private double[,] data;

        private int m;
        public int M { get => this.m; }

        private int n;
        public int N { get => this.n; }

        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
        }
        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < this.M; i++)
            {
                for (var j = 0; j < this.N; j++)
                {
                    func(i, j);
                }
            }
        }

        public double this[int x, int y]
        {
            get
            {
                return this.data[x, y];
            }
            set
            {
                this.data[x, y] = value;
            }
        }

        public static Matrix operator *(Matrix matrix, double value)
        {
            var result = new Matrix(matrix.M, matrix.N);
            result.ProcessFunctionOverData((i, j) =>
                result[i, j] = matrix[i, j] * value);
            return result;
        }

        public static Matrix operator *(Matrix matrix, Matrix matrix2)
        {
            if (matrix.N != matrix2.M)
            {
                throw new ArgumentException("matrixes can not be multiplied");
            }
            var result = new Matrix(matrix.M, matrix2.N);
            result.ProcessFunctionOverData((i, j) => {
                for (var k = 0; k < matrix.N; k++)
                {
                    result[i, j] += matrix[i, k] * matrix2[k, j];
                }
            });
            return result;
        }
    }
}
