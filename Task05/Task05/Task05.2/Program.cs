using System;

namespace Task05._2
{
    class Program
    {
        static void Main(string[] args)
        {
            object K = new Interval(2, 3);
            Interval L = new Interval(2, 3);
            Console.WriteLine(L.Equals(K));
            Interval j = new Interval(-3, 6);
            L = L + j;
            Console.WriteLine(L.Length());
            Console.Read();
        }
    }
}
