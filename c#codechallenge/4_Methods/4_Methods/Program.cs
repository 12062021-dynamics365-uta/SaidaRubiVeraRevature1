using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(GreetFriend(GetName()));
            GetNumber();
            GetAction();
        }

        public static string GetName()
        {
            Console.WriteLine("Howdy honey, what's your name?");
            string name = Console.ReadLine();
            return name;

            //throw new NotImplementedException("GetName() is not implemented yet0");
        }

        public static string GreetFriend(string name)
        {
            return $"Hello, {name}. You are my friend.";
            //throw new NotImplementedException("GreetFriend() is not implemented yet");
        }

        public static double GetNumber()
        {
            double input;
            bool repeat = true;

            do
            {
                Console.WriteLine("Give me a number");
                string number = Console.ReadLine();
                if (double.TryParse(number, out input))
                {
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("input not valid, try again.");
                }
            } while (repeat);

            return input;
            //throw new NotImplementedException("GetNumber() is not implemented yet");

        }

        public static int GetAction()
        {
            int input;
            bool repeat = true;

            do
            {

                Console.WriteLine(
                        "Please selet an a operation:\n" +
                        "1 - Add\n" +
                        "2 - Subtract\n" +
                        "3 - Multiply\n" +
                        "4 - Divide\n"
                        );
                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            while (repeat);
            return input;
            //throw new NotImplementedException("GetAction() is not implemented yet");
        }

        public static double DoAction(double x, double y, int action)
        {
            switch(action)
            {
                case 1:
                    return x + y;
                case 2:
                    return Math.Abs(x - y);
                case 3:
                    return x * y;
                case 4:
                    return x / y;
                default:
                    throw new FormatException("typeof(System.FormatExcption)");
            }
            //throw new NotImplementedException("DoAction() is not implemented yet");
        }
    }
}