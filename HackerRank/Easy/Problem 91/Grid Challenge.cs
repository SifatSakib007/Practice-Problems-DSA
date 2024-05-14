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
     * Complete the 'gridChallenge' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static string gridChallenge(List<string> grid)
    {
        char[] characterArray = new char[grid[0].Length];
        for (int i = 0; i < grid.Count; i++)
        {
            characterArray = grid[i].ToCharArray();
            Array.Sort(characterArray);
            grid[i] = new string(characterArray);
        }
        for (int i = 0; i < grid[0].Length; i++)
        {
            for (int j = 0; j < grid.Count - 1; j++)
            {
                if (grid[j][i] > grid[j + 1][i])
                {
                    return "NO";
                }
            }
        }
        return "YES";
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

            List<string> grid = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            string result = Result.gridChallenge(grid);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
