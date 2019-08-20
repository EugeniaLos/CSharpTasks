using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Task06._2
{
    public static class Helper
    {
        public static IEnumerable<long> Fibonacci(long f0, long f1)
        {
            long first = f0;
            long second = f1;
            if (f0 > f1)
            {
                Swap(ref first, ref second);
            }

            long sum = 0;
            yield return first;
            yield return second;
            while (true)
            {
                sum = first + second;
                first = second;
                second = sum;
                yield return sum;
            }
        }

        private static void Swap(ref long i,ref long j)
        {
            long k = i;
            i = j;
            j = k;
        }
    }
}
