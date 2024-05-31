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
     * Complete the 'icecreamParlor' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER m
     *  2. INTEGER_ARRAY arr
     */

    public static List<int> icecreamParlor(int m, List<int> arr)
    {
// Using a dictionary as a hashmap to store the cost and its index
        var costToIndex = new Dictionary<int, int>();

        for (int i = 0; i < arr.Count; i++)
        {
            int cost = arr[i];
            int complement = m - cost;

            // Check if the complement cost is already in the hashmap
            if (costToIndex.ContainsKey(complement))
            {
                // Return 1-based indices
                return new List<int> { costToIndex[complement] + 1, i + 1 };
            }

            // Add the current cost and its index to the hashmap if not already present
            if (!costToIndex.ContainsKey(cost))
            {
                costToIndex[cost] = i;
            }
        }

        return new List<int>(); // This line is not expected to be reached as per the problem constraints
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int m = Convert.ToInt32(Console.ReadLine().Trim());

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.icecreamParlor(m, arr);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
