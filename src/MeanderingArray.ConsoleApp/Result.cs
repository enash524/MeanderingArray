using System.Collections.Generic;
using System.Linq;

namespace MeanderingArray.ConsoleApp
{
    public static class Result
    {
        public static List<int> MeanderingArray(List<int> unsorted)
        {
            List<int> result = new List<int>();
            unsorted.Sort();

            result.Add(unsorted[unsorted.Count - 1]);
            unsorted.RemoveAt(unsorted.Count - 1);

            result.Add(unsorted[0]);
            unsorted.RemoveAt(0);

            unsorted = unsorted.Distinct().ToList();
            int count = unsorted.Count;
            int[] output = new int[count];
            int idx = 0;

            for (int i = 0, j = unsorted.Count - 1; i <= count / 2 || j > count / 2; i++, j--)
            {
                if (idx < count)
                {
                    output[idx] = unsorted[j];
                    idx++;
                }

                if (idx < count)
                {
                    output[idx] = unsorted[i];
                    idx++;
                }
            }

            result.AddRange(output);

            return result;
        }
    }
}