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
     * Complete the 'serviceLane' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY cases
     */

    public static List<int> serviceLane(int n, List<List<int>> cases, List<int> width)
    {
    List<int> maxVehicleWidths = new List<int>();

    foreach (List<int> segment in cases)
    {
        int startIdx = segment[0];
        int endIdx = segment[1];

        int minWidth = int.MaxValue;
        for (int i = startIdx; i <= endIdx; i++)
        {
            minWidth = Math.Min(minWidth, width[i]);
        }

        maxVehicleWidths.Add(minWidth);
    }

    return maxVehicleWidths;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int t = Convert.ToInt32(firstMultipleInput[1]);

        List<int> width = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(widthTemp => Convert.ToInt32(widthTemp)).ToList();

        List<List<int>> cases = new List<List<int>>();

        for (int i = 0; i < t; i++)
        {
            cases.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(casesTemp => Convert.ToInt32(casesTemp)).ToList());
        }

        List<int> result = Result.serviceLane(n, cases, width);


        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
