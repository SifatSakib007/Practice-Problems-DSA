using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'strangeCounter' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts LONG_INTEGER t as parameter.
     */

    public static long strangeCounter(long t)
{
    long initial_value = 3; // Initial value of the counter
    long cycle_duration = initial_value; // Duration of each cycle
    long cycle_start = 1; // Start time of the current cycle

    while (cycle_start + cycle_duration - 1 < t)
    {
        // Move to the next cycle
        cycle_start += cycle_duration;
        cycle_duration *= 2;
    }

    // Calculate the value displayed by the counter at time t
    long time_in_cycle = t - cycle_start + 1;
    long counter_value = cycle_duration - time_in_cycle + 1;

    return counter_value;
}


}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        long t = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.strangeCounter(t);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
