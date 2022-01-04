using System;
using System.Collections.Generic;

namespace SweetnSalty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Create a C# console application that does the following:
             * 
                - Print the numbers 1 to 1000 to the console.
                - Print them in groups of 20 per line with one space separating each number.
                - When the number is a multiple of three, print “sweet” (instead of the number) to the console.
                - If the number is a multiple of five, print “salty” (instead of the number) to the console.
                - For numbers which are multiples of both three and five, print “sweet’nSalty” to the console (instead of the number).
                - After the numbers have all been printed, print to the console on 3 separate lines, how many "sweet", how many "salty", 
                  and how many "sweet’nSalty" numbers there were. These are three separate groups, 
                  so "sweet’nSalty" does not increment "sweet" or "salty" (and vice versa).
                - Include verbose commentary in the source code to tell me what each few lines are doing. 
            *
            */

            //These keep count of each type of word
            int sweetCounter = 0;
            int saltyCounter = 0;
            int snsCounter = 0;

            //for loop to print each number/word
            for (int i = 1; i <= 1000; i++)
            {
                if (i%20 == 0)
                {
                    Console.WriteLine();
                }
                if (i % 3 == 0 && i % 5 == 0) //print sweet and salty if multiple of 3 and 5
                {
                    Console.Write(" Sweet'nSalty");
                    snsCounter++;
                }
                else if (i % 3 == 0) //printing sweet if multiple of 3
                {
                    Console.Write(" Sweet");
                    sweetCounter++;
                }
                else if (i % 5 == 0) //printing salty if multiple of 5
                {
                    Console.Write(" Salty");
                    saltyCounter++;
                }
                else //if not a multiple of 3 or 5 just print number
                    Console.Write($" {i}");
            }

            Console.WriteLine();//just an empty line to make the console prettier
            Console.WriteLine();//just an empty line to make the console
                                
            //Printing the counters of each word
            Console.WriteLine($"# of Sweet: {sweetCounter}");
            Console.WriteLine($"# of Salty: {saltyCounter}");
            Console.WriteLine($"# of Sweet'nSalty: {snsCounter}");
        }
    }
}
