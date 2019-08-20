using System;
using System.Collections.Generic;

namespace Task06._1
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix matrix = new SparseMatrix(3, 3)
            {
                [2, 1] = 2,
                [0, 0] = 4,
                [0, 1] = 200,
                [1, 2] = -10
            };

            // matrix[4, 6] = 7;
            Console.WriteLine(matrix.ToString());
            foreach (int element in matrix)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine(matrix.GetCount(0));
            Console.Read();
        }
    }
}
