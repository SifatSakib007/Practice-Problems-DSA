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
     * Complete the 'funnyString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string funnyString(string s)
    {
        // Get the reverse of the string
        string reversed = ReverseString(s);

        // Check if the absolute differences are the same
        for (int i = 1; i < s.Length; i++)
        {
            int diff1 = Math.Abs(s[i] - s[i - 1]);
            int diff2 = Math.Abs(reversed[i] - reversed[i - 1]);

            if (diff1 != diff2)
            {
                return "Not Funny";
            }
        }

        return "Funny";
    }

    // Function to reverse a string
    private static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
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

            string result = Result.funnyString(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
