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
     * Complete the 'alternate' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int alternate(string s)
    {
// If the string has only one character, return 0
    if (s.Length <= 1)
    {
        return 0;
    }

    int maxAlternateLength = 0;

    // Iterate through all possible pairs of distinct characters
    for (char c1 = 'a'; c1 <= 'z'; c1++)
    {
        for (char c2 = (char)(c1 + 1); c2 <= 'z'; c2++)
        {
            // Filter out characters other than c1 and c2
            string filteredString = new string(s.Where(c => c == c1 || c == c2).ToArray());

            // Check if the filtered string is alternating
            bool isAlternating = true;
            for (int i = 0; i < filteredString.Length - 1; i++)
            {
                if (filteredString[i] == filteredString[i + 1])
                {
                    isAlternating = false;
                    break;
                }
            }

            // Update the maximum alternating length if the current pair is valid
            if (isAlternating)
            {
                maxAlternateLength = Math.Max(maxAlternateLength, filteredString.Length);
            }
        }
    }

    return maxAlternateLength;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int l = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int result = Result.alternate(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
