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
using static System.Console;

class Result
{

    /*
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {

        int y = Convert.ToInt32(s.Remove(2));
        //If is AM just remove the 'AM' expresion
        if (s.Contains('A'))
        {
            if (y == 12)// case 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock
            {
                s = s.Remove(0, 2);
                string result = "00" + s;
                s = result.Remove(8);
            }
            else
                s = s.Remove(8);
        }
        else //case PM, remove the 'PM' expresion and add 12
        {
            if (y != 12)
            {
                s = s.Remove(0, 2);
                y = y + 12;
                s = Convert.ToString(y) + s;
            }
            s = s.Remove(8);
        }
        return s;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
