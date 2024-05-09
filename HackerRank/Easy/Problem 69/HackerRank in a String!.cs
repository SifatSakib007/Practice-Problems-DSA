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
     * Complete the 'hackerrankInString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string hackerrankInString(string s)
{
    // Word "hackerrank" as a subsequence
    string word = "hackerrank";
    
    // Initialize the index for the current expected character
    int expectedIndex = 0;

    // Iterate through the characters of the input string
    foreach (char c in s)
    {
        // If the current character matches the expected character
        if (c == word[expectedIndex])
        {
            // Move to the next expected character
            expectedIndex++;
        }

        // If we reach the end of the word "hackerrank", return "YES"
        if (expectedIndex == word.Length)
        {
            return "YES";
        }
    }

    // If we didn't find the word "hackerrank" as a subsequence, return "NO"
    return "NO";
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

            string result = Result.hackerrankInString(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
