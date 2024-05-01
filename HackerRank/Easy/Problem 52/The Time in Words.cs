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
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

public static string timeInWords(int h, int m)
{
    string[] numbers = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                         "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty" };
    string[] tens = { "", "", "twenty", "thirty", "forty", "fifty" };

    string timeString;
    
    if (m == 0)
    {
        timeString = $"{numbers[h]} o' clock";
    }
    else if (m == 15)
    {
        timeString = $"quarter past {numbers[h]}";
    }
    else if (m == 30)
    {
        timeString = $"half past {numbers[h]}";
    }
    else if (m == 45)
    {
        timeString = $"quarter to {numbers[(h % 12) + 1]}";
    }
    else if (m < 30)
    {
        string minutesString = m < 20 ? numbers[m] : $"{tens[m / 10]}{(m % 10 != 0 ? " " + numbers[m % 10] : "")}";
        timeString = $"{minutesString} minute{(m == 1 ? "" : "s")} past {numbers[h]}";
    }
    else // for m > 30
    {
        int remainingMinutes = 60 - m;
        string minutesString = remainingMinutes < 20 ? numbers[remainingMinutes] : $"{tens[remainingMinutes / 10]}{(remainingMinutes % 10 != 0 ? " " + numbers[remainingMinutes % 10] : "")}";
        int nextHour = (h % 12) + 1;
        timeString = $"{minutesString} minute{(remainingMinutes == 1 ? "" : "s")} to {numbers[nextHour]}";
    }

    return timeString;
}


}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
