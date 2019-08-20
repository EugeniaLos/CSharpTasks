using System;
using System.Collections.Generic;
using System.Text;

namespace Task07._1
{
    public class VacationData
    {
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public VacationData(string[] args)
        {
            Name = args[0];
            string[] date = args[1].Split('/');
            StartDate = new DateTime( Convert.ToInt32(date[2]), Convert.ToInt32(date[0]), Convert.ToInt32(date[1]));
            date = args[2].Split('/');
            EndDate = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[0]), Convert.ToInt32(date[1]));
        }

        public IEnumerable<int> GetVacationMonths()
        {
            if (StartDate.Year == EndDate.Year)
            {
                for (int i = StartDate.Month; i <= EndDate.Month; i++)
                {
                    yield return i;
                }
            }
            else
            {
                for (int i = StartDate.Month; i <= 12; i++)
                {
                    yield return i;
                }

                for (int i = 1; i <= EndDate.Month; i++)
                {
                    yield return i;
                }
            }
        }
    }
}
