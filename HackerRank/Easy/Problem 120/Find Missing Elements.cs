using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    public static List<int> missingNumbers(List<int> arr, List<int> brr)
    {
        // Create a dictionary to store the frequencies of elements in brr
        Dictionary<int, int> freqBrr = new Dictionary<int, int>();

        // Populate the frequency dictionary for brr
        foreach (var num in brr)
        {
            if (freqBrr.ContainsKey(num))
                freqBrr[num]++;
            else
                freqBrr[num] = 1;
        }

        // Subtract elements of arr from the frequency dictionary
        foreach (var num in arr)
        {
            if (freqBrr.ContainsKey(num))
            {
                freqBrr[num]--;
                if (freqBrr[num] == 0)
                    freqBrr.Remove(num); // Remove the number if its count reaches zero
            }
        }

        // Find the missing numbers, which are still in the dictionary
        List<int> missing = freqBrr.Keys.ToList();
        missing.Sort(); // Sort the missing numbers in ascending order

        return missing;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        // Read the input
        int n = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        
        int m = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        // Call the missingNumbers function
        List<int> result = Result.missingNumbers(arr, brr);

        // Output the result
        Console.WriteLine(String.Join(" ", result));
    }
}
