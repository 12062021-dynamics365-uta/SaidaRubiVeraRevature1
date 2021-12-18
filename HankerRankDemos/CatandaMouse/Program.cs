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

class Solution
{

    // Complete the catAndMouse function below.
    static string catAndMouse(int x, int y, int z)
    {
        //x = cat A, Y = Cat B, Z = Mouse
        int distanceofCatA;
        int distanceofCatB;

        //Distance of Cat A
        if (x > z)
            distanceofCatA = x - z;
        else
            distanceofCatA = z - x;


        //Distance of Cat b
        if (y > z)
            distanceofCatB = y - z;
        else
            distanceofCatB = z - y;

        //Output

        if (distanceofCatA == distanceofCatB)
            return "Mouse C";
        else
        {
            if (distanceofCatB > distanceofCatA)
                return "Cat A";
            else
                return "Cat B";
        }
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] xyz = Console.ReadLine().Split(' ');

            int x = Convert.ToInt32(xyz[0]);

            int y = Convert.ToInt32(xyz[1]);

            int z = Convert.ToInt32(xyz[2]);

            string result = catAndMouse(x, y, z);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
