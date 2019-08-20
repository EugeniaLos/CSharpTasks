using System;
using System.Collections.Generic;
using System.Linq;

namespace KNearestClassLibrary
{
    public static class KNearest
    {
        public static string Algorithm(Dictionary<(double, double), string> inputDictionary, (double, double) characteristic, int k)
        {
            IOrderedEnumerable<KeyValuePair<(double, double), string>> near = inputDictionary.OrderBy(input =>
                Math.Sqrt((characteristic.Item1 - input.Key.Item1) * (characteristic.Item1 - input.Key.Item1) +
                          (characteristic.Item2 - input.Key.Item2) * (characteristic.Item2 - input.Key.Item2)));
            if (k == 0) throw new Exception();
            Dictionary<string, int> neighbors = new Dictionary<string, int>();
            foreach (string key in inputDictionary.Values)
                if (!neighbors.ContainsKey(key))
                    neighbors.Add(key, 0);
            int counter = 0;
            foreach (KeyValuePair<(double, double), string> nearest in near)
            {
                neighbors[nearest.Value]++;
                counter++;

                if (counter == k) break;
            }

            string result = null;
            int frequency = 0;
            foreach (KeyValuePair<string, int> neighbor in neighbors)
                if (neighbor.Value > frequency)
                {
                    frequency = neighbor.Value;
                    result = neighbor.Key;
                }

            return result;
        }
    }
}
