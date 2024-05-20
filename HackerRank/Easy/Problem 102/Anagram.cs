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
     * Complete the 'anagram' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int anagram(string s)
    {
        int n = s.Length;
        if (n % 2 != 0) return -1;  // Return -1 if the string length is odd

        int mid = n / 2;
        string s1 = s.Substring(0, mid);
        string s2 = s.Substring(mid);

        int[] charCount = new int[26];

        // Count frequencies of characters in the first half
        foreach (char c in s1)
        {
            charCount[c - 'a']++;
        }

        // Subtract frequencies of characters in the second half
        foreach (char c in s2)
        {
            charCount[c - 'a']--;
        }

        // Calculate the number of changes needed
        int changes = 0;
        foreach (int count in charCount)
        {
            if (count > 0)
            {
                changes += count;
            }
        }

        return changes;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.anagram(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
