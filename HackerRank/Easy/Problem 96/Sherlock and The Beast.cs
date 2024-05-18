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
     * Complete the 'decentNumber' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void decentNumber(int n)
    {
int threes = 0;
        int fives = 0;
        int originalN = n;

        while (n > 0)
        {
            if (n % 5 == 0 && n % 3 != 0)
            {
                n -= 5;
                fives += 5;
            }
            else
            {
                n -= 3;
                threes += 3;
            }
        }

        if (n == 0)
        {
            StringBuilder result = new StringBuilder();
            result.Append('5', threes);
            result.Append('3', fives);
            Console.WriteLine(result.ToString());
        }
        else
        {
            Console.WriteLine("-1");
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            Result.decentNumber(n);
        }
    }
}
