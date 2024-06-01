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
     * Complete the 'closestNumbers' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

     public static int[] closestNumbers(int[] arr)
    {
        // Step 1: Sort the array
        Array.Sort(arr);

        // Step 2: Find the minimum absolute difference
        int minDiff = int.MaxValue;
        for (int i = 1; i < arr.Length; i++)
        {
            int diff = arr[i] - arr[i - 1];
            if (diff < minDiff)
            {
                minDiff = diff;
            }
        }

        // Step 3: Collect all pairs with the minimum absolute difference
        List<int> result = new List<int>();
        for (int i = 1; i < arr.Length; i++)
        {
            int diff = arr[i] - arr[i - 1];
            if (diff == minDiff)
            {
                result.Add(arr[i - 1]);
                result.Add(arr[i]);
            }
        }

        // Convert the list to an array and return
        return result.ToArray();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        // Reading input from the console
        int n = Convert.ToInt32(Console.ReadLine().Trim());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        // Calling the function and getting the result
        int[] result = Result.closestNumbers(arr);

        // Writing the result to the console
        Console.WriteLine(string.Join(" ", result));
    }
}
