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
     * Complete the 'weightedUniformStrings' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER_ARRAY queries
     */

    public static List<string> weightedUniformStrings(string s, List<int> queries)
    {
        HashSet<int> weights = new HashSet<int>();
        int currentWeight = 0;
        char prevChar = '\0';

        // Calculate the weights of all possible uniform contiguous substrings
        foreach (char c in s)
        {
            currentWeight = c == prevChar ? currentWeight + c - 'a' + 1 : c - 'a' + 1;
            weights.Add(currentWeight);
            prevChar = c;
        }

        // Create the result list based on whether each query exists in the set of weights
        return queries.Select(query => weights.Contains(query) ? "Yes" : "No").ToList();

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> queries = new List<int>();

        for (int i = 0; i < queriesCount; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<string> result = Result.weightedUniformStrings(s, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
