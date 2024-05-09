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
     * Complete the 'marsExploration' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int marsExploration(string s)
    {
                // Initialize a variable to keep track of the number of characters changed
    int count = 0;

    // Iterate through the received signal string in steps of 3
    for (int i = 0; i < s.Length; i += 3)
    {
        // Check each character in the current group
        for (int j = 0; j < 3; j++)
        {
            // Compare the character with the corresponding character in the "SOS" pattern
            if (s[i + j] != "SOS"[j])
            {
                // If the characters are different, increment the count
                count++;
            }
        }
    }

    // Return the total count of characters changed during transmission
    return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = Result.marsExploration(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
