using Algorithm.Problems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            try
            {
                watch.Start();
                GetMaxAndMinOfCoins.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Task failed, with the following exception(s):");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (watch.IsRunning) watch.Stop();
                Console.WriteLine("The task took {0} second(s).", watch.Elapsed.TotalSeconds.ToString());
                Console.ReadLine();
            }
        }
    }
}