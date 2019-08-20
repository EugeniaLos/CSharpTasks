using System;

namespace Task05._1
{
    public static class Helper
    {
        public static Matrix<T> Add<T>(this Matrix<T> matrix, Matrix<T> m, Func<T, T, T> f)
        {
            if (m == null)
            {
                m = new Matrix<T>();
            }

            if (matrix.Size < m.Size)
            {
                return m.Add(matrix, f);
            }

            T[] data = new T[matrix.Size];
            Matrix<T> result = new Matrix<T>(data);

            for (int i = 0; i < matrix.Size; i++)
            {
                result[i, i] = matrix[i, i];
            }

            for (int i = 0; i < m.Size; i++)
            {
                result[i, i] = f(result[i, i], m[i, i]);
            }

            return result;
        }

        public static int AddingInt(int i, int k) => i + k;
    }
}
