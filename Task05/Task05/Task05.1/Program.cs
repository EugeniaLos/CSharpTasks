using System;

namespace Task05._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> f = Helper.AddingInt;
            int[] diagonal1 = new[] { 1, 8, 10 };
            int[] diagonal2 = new[] { 1, 9, -4, 25, 7 };
            Matrix<int> m1 = new Matrix<int>(diagonal1);
            Matrix<int> m2 = new Matrix<int>(diagonal2);
            Matrix<int> m3 = m1.Add<int>(m2, f);
            for (int i = 0; i < m3.Size; i++)
            {
                Console.WriteLine(m3[i, i]);
            }
            Console.Read();
        }
    }
}
