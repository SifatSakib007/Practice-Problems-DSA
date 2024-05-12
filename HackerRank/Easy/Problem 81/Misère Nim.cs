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
     * Complete the 'misereNim' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY s as parameter.
     */

    public static string misereNim(List<int> s)
    {
// In a single pile, if more than one stones exist then first player will
        // always win by leaving the last stone for the second player to pick up
        if (s.Count == 1)
        {
            return s[0] > 1 ? "First" : "Second";
        }

        int totalStones = s[0];
        int xorValue = s[0];

        for (int i = 1; i < s.Count; i++)
        {
            totalStones += s[i];
            xorValue ^= s[i];
        }

        // If sum of all stones equals the total piles, all piles have a single (1)
        // stone. For even number of piles, the first player will always win.
        if (totalStones == s.Count)
        {
            return totalStones % 2 == 0 ? "First" : "Second";
        }

        // For all other cases, the xor value determines the winner. If xor value = 0,
        // then the second player will always win as all piles (stones) can be paired.
        return xorValue > 0 ? "First" : "Second";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            string result = Result.misereNim(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
