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
     * Complete the 'caesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */

    public static string caesarCipher(string s, int k)
{
    // Initialize an empty string to store the encrypted result
    StringBuilder encrypted = new StringBuilder();

    // Iterate through each character in the input string
    foreach (char c in s)
    {
        // Check if the character is a letter
        if (char.IsLetter(c))
        {
            // Determine the base ('a' for lowercase, 'A' for uppercase)
            char baseChar = char.IsLower(c) ? 'a' : 'A';
            
            // Apply Caesar Cipher encryption
            char encryptedChar = (char)(baseChar + (c - baseChar + k) % 26);

            // Append the encrypted character to the result
            encrypted.Append(encryptedChar);
        }
        else
        {
            // If the character is not a letter, leave it unchanged
            encrypted.Append(c);
        }
    }

    // Return the encrypted result string
    return encrypted.ToString();
}


}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
