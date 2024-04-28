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
     * Complete the 'kaprekarNumbers' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER q
     */

    public static void kaprekarNumbers(int p, int q)
    {
 bool found = false;
    for (int i = p; i <= q; i++)
    {
        long square = (long)i * i;
        string squareStr = square.ToString();

        int d = squareStr.Length / 2;
        int left = (d > 0) ? int.Parse(squareStr.Substring(0, d)) : 0;
        int right = int.Parse(squareStr.Substring(d));

        if (left + right == i)
        {
            Console.Write(i + " ");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("INVALID RANGE");
    }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        Result.kaprekarNumbers(p, q);
    }
}
