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
     * Complete the 'divisibleSumPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER_ARRAY ar
     */

    public static int divisibleSumPairs(int n, int k, List<int> ar)
    {
    // Initialize an array to store the count of remainders
    int[] remaindersCount = new int[k];

    // Iterate over the input array and update the remaindersCount array
    foreach (int num in ar)
    {
        int remainder = num % k;
        remaindersCount[remainder]++;
    }

    // Count the pairs
    int pairs = 0;
    for (int i = 1; i <= k / 2; i++)
    {
        // For each remainder, find its complement
        int complement = (k - i) % k;

        // If the remainder and its complement are different, count the pairs
        if (i != complement)
        {
            pairs += remaindersCount[i] * remaindersCount[complement];
        }
        else
        {
            // If the remainder and its complement are the same, count half the pairs
            pairs += remaindersCount[i] * (remaindersCount[i] - 1) / 2;
        }
    }

    // Add the pairs where the remainder is 0
    pairs += remaindersCount[0] * (remaindersCount[0] - 1) / 2;

    return pairs;

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

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.divisibleSumPairs(n, k, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
