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
     * Complete the 'separateNumbers' function below.
     *
     * The function accepts STRING s as parameter.
     */

    public static void separateNumbers(string s)
    {
bool beautiful = false;
        long firstNum = 0;

        // Iterate through the string
        for (int i = 1; i <= s.Length / 2 && !beautiful; i++)
        {
            // Convert substring to long
            long num = long.Parse(s.Substring(0, i));
            firstNum = num;

            // Generate the sequence
            string seq = num.ToString();
            long next = num + 1;

            // Check if the sequence matches the string
            while (seq.Length < s.Length)
            {
                seq += next.ToString();
                next++;
            }

            if (seq == s)
                beautiful = true;
        }

        Console.WriteLine(beautiful ? $"YES {firstNum}" : "NO");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            Result.separateNumbers(s);
        }
    }
}
