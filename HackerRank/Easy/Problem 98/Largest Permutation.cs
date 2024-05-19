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
     * Complete the 'largestPermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */

    public static List<int> largestPermutation(int k, List<int> arr)
{
    int n = arr.Count;

    // Create an array to store the index of each element
    List<int> elementIndexMap = new List<int>(n);
    for (int i = 0; i < n; i++)
    {
        elementIndexMap.Add(0); // Initialize with 0 for clarity
    }

    // Fill the element index map
    for (int i = 0; i < n; i++)
    {
        elementIndexMap[arr[i] - 1] = i;
    }

    // Perform swaps from the beginning of the array
    for (int i = 0; i < n && k > 0; i++)
    {
        // Check if the element needs swapping (not already in its position)
        int correctIndex = n - i - 1; // Calculate correct index based on position
        if (arr[i] != (correctIndex + 1))
        {
            int indexToSwap = elementIndexMap[correctIndex];

            // Swap elements and update index map
            elementIndexMap[arr[i] - 1] = indexToSwap;
            elementIndexMap[correctIndex] = i;
            swap(arr, i, indexToSwap);

            k--;
        }
    }

    return arr;
}

private static void swap(List<int> arr, int i, int j)
{
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.largestPermutation(k, arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
