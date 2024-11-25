using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Result
{
    /*
    * Complete the 'findMedian' function below.
    * The function is expected to return an INTEGER.
    * The function accepts INTEGER_ARRAY arr as parameter.
    */
    public static int findMedian(List<int> arr)
    {
        // Sort the array
        arr.Sort();
        
        // Find the middle index
        int medianIndex = arr.Count / 2;
        
        // Return the median value
        return arr[medianIndex];
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        // Reading input for array size
        Console.WriteLine("Enter the size of the array:");
        int n = Convert.ToInt32(Console.ReadLine().Trim());
        
        // Reading input for array elements
        Console.WriteLine("Enter the array elements separated by space:");
        List<int> arr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

        // Calling the findMedian function
        int result = Result.findMedian(arr);

        // Outputting the result
        Console.WriteLine("The median is: " + result);
    }
}
