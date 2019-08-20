using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using KNearestClassLibrary;

namespace Task07._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<(double, double), string> input = new Dictionary<(double, double), string>
            {
                {(2, 2), "lemon"},
                {(2, 3), "lemon"},
                {(4, 2), "lemon"},
                {(-10, 1), "pear"},
                {(0, 0), "pear"}
            };
            Console.WriteLine(KNearest.Algorithm(input, (-9, 0), 3));

            string[] records = File.ReadAllLines(@"..\..\..\data.txt");
            Dictionary<(double, double), string> data = new Dictionary<(double, double), string>();
            foreach (string record in records)
            {
                string[] recordData = record.Split(',');
                double characteristic1 = double.Parse("1.0", CultureInfo.InvariantCulture);
                data.Add((double.Parse(recordData[1], CultureInfo.InvariantCulture),
                        double.Parse(recordData[2], CultureInfo.InvariantCulture)),
                    recordData[0]);
            }

            Console.WriteLine(KNearest.Algorithm(data, (0, 0), 5));
            Console.Read();
        }
    }
}
