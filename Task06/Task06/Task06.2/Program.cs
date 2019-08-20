using System;
using System.Collections.Generic;

namespace Task06._2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<long> numbers = Helper.Fibonacci(1, 0);
            foreach (var number in numbers)
            {
                if (number == 13)
                {
                    break;
                }

                Console.WriteLine(number);
            }

            Console.Read();
            numbers = Helper.Fibonacci(4000000000000, 23500000000000);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        
    }
}
