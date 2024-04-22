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
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        // Check if the year is in the transition year 1918
        if (year == 1918)
        {
            // Day 256 falls on September 26th in the transition year
            return "26.09.1918";
        }
        else if ((year < 1918 && year % 4 == 0) ||                // Julian leap year check
                 (year > 1918 && ((year % 400 == 0) ||            // Gregorian leap year check
                                  (year % 4 == 0 && year % 100 != 0))))
        {
            // Day 256 falls on September 12th in a leap year
            return "12.09." + year;
        }
        else
        {
            // Day 256 falls on September 13th in a non-leap year
            return "13.09." + year;
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
