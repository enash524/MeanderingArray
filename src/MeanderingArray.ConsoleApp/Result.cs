using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace MeanderingArray.ConsoleApp
{
    public class Result : IResult
    {
        private readonly ILogger<Result> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result`1"/> class.
        /// </summary>
        /// <param name="logger">DI injected logger</param>
        public Result(ILogger<Result> logger)
        {
            _logger = logger;
        }

        public List<int> MeanderingArray(List<int> unsorted)
        {
            if (unsorted == null)
            {
                _logger.LogError($"Collection cannot be null (Parameter '{nameof(unsorted)}')");
                throw new ArgumentNullException(nameof(unsorted), "Collection cannot be null");
            }

            if (unsorted.Count == 0)
            {
                _logger.LogError($"Collection cannot be empty (Parameter '{nameof(unsorted)}')");
                throw new ArgumentException("Collection cannot be empty", nameof(unsorted));
            }

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