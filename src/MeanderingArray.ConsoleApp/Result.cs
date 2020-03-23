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
            result.Add(unsorted[0]);
            int[] temp = unsorted.GetRange(1, unsorted.Count - 2).Distinct().ToArray();

            int count = temp.Length;
            int[] output = new int[count];
            int idx = 0;

            for (int i = 0, j = count - 1; i <= count / 2 || j > count / 2; i++, j--)
            {
                if (idx < count)
                {
                    output[idx] = temp[j];
                    idx++;
                }

                if (idx < count)
                {
                    output[idx] = temp[i];
                    idx++;
                }
            }

            result.AddRange(output);

            return result;
        }
    }
}