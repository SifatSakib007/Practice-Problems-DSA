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
     * Complete the 'minimumDistances' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int minimumDistances(List<int> a)
    {
Dictionary<int, int> lastIndex = new Dictionary<int, int>(); // Store the last seen index of each element
    int minDistance = int.MaxValue; // Initialize the minimum distance

    for (int i = 0; i < a.Count; i++)
    {
        int currentElement = a[i];

        if (lastIndex.ContainsKey(currentElement))
        {
            int distance = i - lastIndex[currentElement];
            minDistance = Math.Min(minDistance, distance);
        }

        lastIndex[currentElement] = i; // Update the last seen index of the current element
    }

    return minDistance == int.MaxValue ? -1 : minDistance; // Return -1 if no matching elements found

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.minimumDistances(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
