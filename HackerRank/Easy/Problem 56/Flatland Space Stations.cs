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

class Solution {

    // Complete the flatlandSpaceStations function below.
    static int flatlandSpaceStations(int n, int[] c) {
        if (n == c.Length) {
            return 0;
        }

        Array.Sort(c);

        int maxDistance = c[0]; // Maximum distance from the first city to the nearest space station

        for (int i = 1; i < c.Length; i++) {
            maxDistance = Math.Max(maxDistance, (c[i] - c[i - 1]) / 2);
        }

        // Maximum distance from the last city to the nearest space station
        maxDistance = Math.Max(maxDistance, n - 1 - c[c.Length - 1]);

        return maxDistance;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = flatlandSpaceStations(n, c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
