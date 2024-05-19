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
     * Complete the 'toys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY w as parameter.
     */

    public static int toys(List<int> w)
    {
        // Sort the list of weights in ascending order
        w.Sort();

        int minWeight = w[0]; // Get the minimum weight
        int containerCount = 1; // Initialize container count to 1

        int currentMaxWeight = minWeight + 4; // Set the current max weight for the first container

        for (int i = 1; i < w.Count; i++)
        {
            // Check if the current weight exceeds the limit for the current container
            if (w[i] > currentMaxWeight)
            {
                containerCount++; // Increase container count if weight exceeds limit
                currentMaxWeight = w[i] + 4; // Update max weight for the new container
            }
        }

        return containerCount;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> w = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(wTemp => Convert.ToInt32(wTemp)).ToList();

        int result = Result.toys(w);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
