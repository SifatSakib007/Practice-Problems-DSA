using System;
using System.Collections.Generic;
using System.IO;

class Result
{
    /*
    * Complete the 'balancedSums' function below.
    *
    * The function is expected to return a STRING.
    * The function accepts INTEGER_ARRAY arr as parameter.
    */
    public static string balancedSums(List<int> arr)
    {
        int totalSum = 0; 
        int leftSum = 0;

        // Calculate the total sum of the array
        foreach (var num in arr)
        {
            totalSum += num;
        }

        // Traverse the array and check for the balance point
        foreach (var num in arr)
        {
            // Right sum is calculated as totalSum - leftSum - num
            if (leftSum == (totalSum - leftSum - num))
            {
                return "YES";
            }

            // Update left sum to include the current element
            leftSum += num;
        }

        return "NO";
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse));

            string result = Result.balancedSums(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
