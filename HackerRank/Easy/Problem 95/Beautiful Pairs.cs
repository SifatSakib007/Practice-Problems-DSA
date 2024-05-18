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
     * Complete the 'beautifulPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY A
     *  2. INTEGER_ARRAY B
     */

    public static int beautifulPairs(List<int> A, List<int> B)
    {
// Dictionary to count the occurrences of elements in A
        Dictionary<int, int> countA = new Dictionary<int, int>();
        
        // Count occurrences of each element in A
        foreach (int a in A)
        {
            if (countA.ContainsKey(a))
                countA[a]++;
            else
                countA[a] = 1;
        }

        int initialBeautifulPairs = 0;
        
        // Count the initial number of beautiful pairs
        foreach (int b in B)
        {
            if (countA.ContainsKey(b) && countA[b] > 0)
            {
                initialBeautifulPairs++;
                countA[b]--;  // Decrease the count to ensure pairwise disjoint
            }
        }

        // If initial pairs are already all elements, changing one will decrease by 1
        // Otherwise, we can always increase by 1 by making a change
        int maxPairs = (initialBeautifulPairs == A.Count) ? initialBeautifulPairs - 1 : initialBeautifulPairs + 1;

        return maxPairs;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

        List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

        int result = Result.beautifulPairs(A, B);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
