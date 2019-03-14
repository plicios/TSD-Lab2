using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RandomCollection
{
    class Third
    {
        delegate bool del(int i); 
        public void LeapYearLambda()
        {
            del leapYear = year => year % 4 == 0 && year % 200 != 0;
        }

        public bool IsLeapYear(int year)
        {
            return year % 4 == 0  && year % 200 != 0;
        }

        public void UseLeapYear(Predicate<int> method)
        {
            Console.WriteLine(method(1996) ? "true" : "false");
        }

        public static void Run()
        {
            Third third = new Third();
            third.UseLeapYear(third.IsLeapYear);

            Console.WriteLine("{0} MB", Process.GetProcesses().GetMemoryUsage());
        }
    }

    public static class ProcessListExtension
    {
        public static int GetMemoryUsage(this IEnumerable<Process> processes)
        {
            int ramUsage = 0;
            foreach (Process process in processes)
            {
                PerformanceCounter PC = new PerformanceCounter();
                try
                {
                    PC.CategoryName = "Process";
                    PC.CounterName = "Working Set - Private";
                    PC.InstanceName = process.ProcessName;
                    ramUsage += Convert.ToInt32(PC.NextValue()) / 1024;
                }
                catch (Exception e)
                {

                }
                finally
                {
                    PC.Close();
                    PC.Dispose();
                }
            }
            ramUsage /= 1024;

            return ramUsage;
        }
    }

}
