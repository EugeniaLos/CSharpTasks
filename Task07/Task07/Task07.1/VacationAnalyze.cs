using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task07._1
{
    public class VacationAnalyze
    {
        public List<VacationData> VacationDataRecords = new List<VacationData>();

        public VacationAnalyze(string fileName)
        {
            string[] records = File.ReadAllLines(fileName);
            foreach (string record in records)
            {
                string[] recordData = record.Split(',');
                VacationData vacationData = new VacationData(recordData);
                if (IsValidateVacationRecord(vacationData)) VacationDataRecords.Add(vacationData);
            }
        }

        public TimeSpan AverageOverallDuration()
        {
            IEnumerable<TimeSpan> selected = VacationDataRecords.Select(v => v.EndDate - v.StartDate);
            return TimeSpan.FromDays(selected.Average(x => x.TotalDays));
        }

        public TimeSpan AverageDuration(string Name)
        {
            IEnumerable<TimeSpan> selected = VacationDataRecords.Where(v => v.Name.Equals(Name))
                .Select(v => v.EndDate - v.StartDate);
            return TimeSpan.FromDays(selected.Average(x => x.TotalDays));
        }

        public IEnumerable<string> AverageDuration()
        {
            HashSet<string> Names = new HashSet<string>();
            foreach (VacationData record in VacationDataRecords) Names.Add(record.Name);

            foreach (string name in Names)
                yield return name + " - Average amount of vacation days:" + AverageDuration(name).Days;
        }

        public IEnumerable<string> GetStatisticForEachMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                IEnumerable<int> selected = VacationDataRecords
                    .SelectMany(v => v.GetVacationMonths(), (v, m) => new {v, m})
                    .Where(@t => @t.m == i)
                    .Select(@t => @t.m);
                yield return "On the " + i + "th month there were " + selected.Count() + " case(s) of having vacation";
            }
        }

        public IEnumerable<DateTime> GetDaysWithNoVacation()
        {
            IEnumerable<DateTime> vacation = VacationDataRecords
                .SelectMany(x =>
                    Enumerable.Range(0, 1 + x.EndDate.Subtract(x.StartDate).Days)
                        .Select(offset => x.StartDate.AddDays(offset)))
                .GroupBy(x => x)
                .Select(x => x.Key);
            DateTime start = vacation.Min(x => x);
            DateTime end = vacation.Max(x => x);

            IEnumerable<DateTime> allDates = Enumerable.Range(0, 1 + end.Subtract(start).Days).Select(offset => start.AddDays(offset));
            return allDates.Where(d => !vacation.Any(v => v == d));
        }

        private bool IsValidateVacationRecord(VacationData vacationData)
        {
            bool check = true;
            foreach (VacationData record in VacationDataRecords)
                if (record.Name == vacationData.Name)
                    check = check &&
                            (record.EndDate < vacationData.StartDate || vacationData.EndDate < record.StartDate);

            return check;
        }
    }
}
