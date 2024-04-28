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
    public static int getTotalX(List<int> a, List<int> b)
    {
        // Find the LCM of all elements in array a
        int lcm = a.Aggregate(LCM);

        // Find the GCD of all elements in array b
        int gcd = b.Aggregate(GCD);

        // Count the multiples of the LCM that evenly divide the GCD
        return Enumerable.Range(1, gcd / lcm).Count(i => gcd % (lcm * i) == 0);
    }

    // Function to calculate the LCM of two integers
    private static int LCM(int a, int b)
    {
        return (a * b) / GCD(a, b);
    }

    // Function to calculate the GCD of two integers using Euclidean algorithm
    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);
        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).ToList();
        List<int> b = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).ToList();

        int total = Result.getTotalX(a, b);

        Console.WriteLine(total);
    }
}
