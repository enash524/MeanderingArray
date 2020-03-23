using System;
using System.Collections.Generic;

namespace MeanderingArray.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                List<int> unsorted = new List<int> { 7, 5, 2, 7, 8, -2, 25, 25 };
                List<int> result = Result.MeanderingArray(unsorted);

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