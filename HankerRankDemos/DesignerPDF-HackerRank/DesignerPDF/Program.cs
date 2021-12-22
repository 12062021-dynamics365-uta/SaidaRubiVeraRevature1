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
     * Complete the 'designerPdfViewer' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY h
     *  2. STRING word
     */

    public static int designerPdfViewer(List<int> h, string word)
    {
        //solution with less code

        //new list to hold values of heights associated with letters in given word
        List<int> letterIndex = new List<int>(); 
      
        foreach (var letter in word)
        {
            char c = letter; //grabs each letter of given word
            int index = char.ToUpper(c) - 64; //converts letters to convert to decimal, subtract to get a number for the alphabet
            letterIndex.Add(h[index - 1]);//converting letter to number in corresponding alphabet
        }

        return letterIndex.Max() * letterIndex.Count();
        
        
        /*
        //array of alphabet
        char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        //array for word heights
        int[] heights = new int[h.Count];
        //array version of the word
        char[] wordArray = word.ToCharArray();

        //loop to find the give word's letters heights
        for (int i = 0; i < wordArray.Count(); i++)
        {
            for (int j = 0; j < alphabet.Count(); j++)
            {
                if (alphabet[j] == wordArray[i])
                {
                    heights[i] = h[j];
                    break;
                }
            }
        }

        return heights.Max() * word.Count();
        */
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<int> h = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(hTemp => Convert.ToInt32(hTemp)).ToList();

        string word = Console.ReadLine();

        int result = Result.designerPdfViewer(h, word);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
