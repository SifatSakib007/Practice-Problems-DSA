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
     * Complete the 'superReducedString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string superReducedString(string s)
    {
    StringBuilder sb = new StringBuilder();

    foreach (char c in s)
    {
        if (sb.Length > 0 && sb[^1] == c)
        {
            sb.Length--; // Remove the last character from the StringBuilder
        }
        else
        {
            sb.Append(c); // Append the current character to the StringBuilder
        }
    }

    string reducedString = sb.ToString();

    return reducedString.Length > 0 ? reducedString : "Empty String";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.superReducedString(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
