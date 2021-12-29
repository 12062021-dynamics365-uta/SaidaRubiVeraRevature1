using System;
using System.Collections.Generic;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            byte b = 0;
            sbyte sb = -128;
            int t = -2147483648; //int32
            uint ui = 4294967295;
            short s = 32767; //int26
            ushort us = 65535;
            long l = -9223372036854775808; //int64
            ulong ul = 18446744073709551615;
            float f = 3238;
            double d = 1.79769313486232;
            char c = 'a';
            bool bol = true;
            object o = "|";
            string str = "abc";
            decimal dec = 3;
      
            string str1 = "I control text";
            string numString = "123456";

            List<object> list = new List<object>() {
                b,sb,t,ui,s,us,l,ul,f,d,c,bol,o,str,dec
            };

            foreach (object i in list)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// This method has an 'object' type parameter. 
        /// 1. Create a switch statement that evaluates for the data type of the parameter
        /// 2. You will need to get the data type of the parameter in the 'case' part of the switch statement
        /// 3. For each data type, return a string of exactly format, "Data type => <type>" 
        /// 4. For example, an 'int' data type will return ,"Data type => int",
        /// 5. A 'ulong' data type will return "Data type => ulong",
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string PrintValues(object obj)
        {
            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Byte:
                    return "Data type => byte";
                case TypeCode.SByte:
                    return "Data type => sbyte";
                case TypeCode.Int32:
                    return "Data type => int";
                case TypeCode.UInt32:
                    return "Data type => uint";
                case TypeCode.Int16:
                    return "Data type => short";
                case TypeCode.UInt16:
                    return "Data type => ushort";
                case TypeCode.Int64:
                    return "Data type => long";
                case TypeCode.UInt64:
                    return "Data type => ulong";
                case TypeCode.Single:
                    return "Data type => float";
                case TypeCode.Double:
                    return "Data type => double";
                case TypeCode.Char:
                    return "Data type => char";
                case TypeCode.Boolean:
                    return "Data type => bool";
                case TypeCode.Object:
                    return "Data type => obj";
                case TypeCode.String:
                    return "Data type => string";
                case TypeCode.Decimal:
                    return "Data type => decimal";
                default:
                    return "nothing";
            }

            //throw new NotImplementedException($"PrintValues() has not been implemented");
        }

        /// <summary>
        /// THis method has a string parameter.
        /// 1. Use the .TryParse() method of the Int32 class (Int32.TryParse()) to convert the string parameter to an integer. 
        /// 2. You'll need to investigate how .TryParse() and 'out' parameters work to implement the body of StringToInt().
        /// 3. If the string cannot be converted to a integer, return 'null'. 
        /// 4. Investigate how to use '?' to make non-nullable types nullable.
        /// </summary>
        /// <param name="numString"></param>
        /// <returns></returns>
        public static int? StringToInt(string numString)
        {
            if (Int32.TryParse(numString, out int integer))
                return integer;
            else
                return null;
            //throw new NotImplementedException($"StringToInt() has not been implemented");

        }
        
    }// end of class
}// End of Namespace
