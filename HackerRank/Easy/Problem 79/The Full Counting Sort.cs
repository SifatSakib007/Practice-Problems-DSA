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
    public static void countSort(List<List<string>> arr)
    {
        int n = arr.Count;
        StringBuilder[] result = new StringBuilder[n];

        // Initialize the StringBuilder array
        for (int i = 0; i < n; i++)
        {
            result[i] = new StringBuilder();
        }

        // Append "-" to the first half and the string to the second half
        for (int i = 0; i < n; i++)
        {
            int index = int.Parse(arr[i][0]);
            string value = arr[i][1];
            if (i < n / 2)
            {
                result[index].Append("- ");
            }
            else
            {
                result[index].Append(value + " ");
            }
        }

        // Print the result
        foreach (var item in result)
        {
            Console.Write(item.ToString());
        }
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> arr = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        Result.countSort(arr);
    }
}
