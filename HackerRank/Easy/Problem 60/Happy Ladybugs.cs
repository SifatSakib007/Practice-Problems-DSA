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
     * Complete the 'happyLadybugs' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING b as parameter.
     */

    public static string happyLadybugs(string b)
    {
 int[] lookup = new int[31];
        int len = b.Length;
        
        foreach (char c in b)
        {
            lookup[c - 65]++;
        }
        
        for (int i = 0; i < 26; ++i)
        {
            if (lookup[i] == 1)
                return "NO";
        }
        
        if (lookup[30] == 0) // No empty cells ('_')
        {
            char prev = b[0];
            int occ = 1;
            
            for (int i = 1; i < len; ++i)
            {
                if (b[i] == prev)
                {
                    ++occ;
                }
                else if (occ == 1)
                {
                    return "NO";
                }
                else
                {
                    occ = 1;
                }
                prev = b[i];
            }
            
            return "YES"; // String is arranged in the desired order
        }
        
        return "YES"; // String can be arranged in the desired order
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string b = Console.ReadLine();

            string result = Result.happyLadybugs(b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
