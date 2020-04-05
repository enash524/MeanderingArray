using System;
using System.Collections.Generic;

namespace MeanderingArray.ConsoleApp
{
    public class ConsoleApplication
    {
        private readonly IResult _result;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleApplication`1"/> class.
        /// </summary>
        public ConsoleApplication(IResult result)
        {
            _result = result;
        }

        /// <summary>
        /// Run the program
        /// </summary>
        public void Run()
        {
            try
            {
                List<int> unsorted = new List<int> { 7, 5, 2, 7, 8, -2, 25, 25 };
                List<int> result = _result.MeanderingArray(unsorted);

                Console.WriteLine("Result: {0}", string.Join(' ', result));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
            finally
            {
                Console.WriteLine("--- Press Any Key To Continue ---");
                Console.ReadKey(true);
            }
        }
    }
}