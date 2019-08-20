using System;
using System.Collections.Generic;

namespace Task07._1
{
    class Program
    {
        static void Main(string[] args)
        {
            VacationAnalyze vac = new VacationAnalyze(@"../../../data.txt");
            Console.WriteLine(vac.AverageOverallDuration().TotalDays);
            IEnumerable<string> k = vac.GetStatisticForEachMonth();
            foreach (string kl in k)
            {
                Console.WriteLine(kl);
            }

            Console.WriteLine(vac.AverageDuration("Abasw Jzysgbyx").TotalDays);
           /* IEnumerable<DateTime> t = vac.GetDaysWithNoVacation();
            foreach (var VARIABLE in t)
            {
                Console.WriteLine(VARIABLE);
            }*/
            Console.Read();
        }
    }
}
