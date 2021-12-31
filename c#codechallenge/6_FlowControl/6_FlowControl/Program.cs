using System;

namespace _6_FlowControl
{
    public class Program
    {

        public static object username;
        public static object password;

        static void Main(string[] args)
        {
            GetValidTemperature();
            //GiveActivityAdvice();
            Register();
            Login();
            //GetTemperatureTernary();
        }

        /// <summary>
        /// This method gets a valid temperature between -40 asnd 135 inclusive from the user
        /// and returns the valid int. 
        /// </summary>
        /// <returns></returns>
        public static int GetValidTemperature()
        {
            int temp;
            do
            {
                Console.WriteLine("Input a number between -40 and 135");
                temp = int.Parse(Console.ReadLine());
            }
            while (temp > 135 && temp < -40);
            return temp;

            //throw new NotImplementedException($"GetValidTemperature() has not been implemented.");
        }

        /// <summary>
        /// This method has one int parameter
        /// It prints outdoor activity advice and temperature opinion to the console 
        /// based on 20 degree increments starting at -20 and ending at 135 
        /// n < -20, Console.Write("hella cold");
        /// -20 <= n < 0, Console.Write("pretty cold");
        ///  0 <= n < 20, Console.Write("cold");
        /// 20 <= n < 40, Console.Write("thawed out");
        /// 40 <= n < 60, Console.Write("feels like Autumn");
        /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
        /// 80 <= n < 90, Console.Write("niiice");
        /// 90 <= n < 100, Console.Write("hella hot");
        /// 100 <= n < 135, Console.Write("hottest");
        /// </summary>
        /// <param name="temp"></param>
        public static void GiveActivityAdvice(int temp)
        {
            Console.WriteLine("Please input a temp between -20 and 135 to get a temp description!");
            temp = Console.Read();

            string output;

            if (temp < -20)
                output = "hella cold";
            else if (temp <= 20 && temp < 0)
                output = "pretty cold";
            else if (temp >= 0 && temp < 20)
                output = "cold";
            else if (temp < 40 && temp > 20)
                output = "thawed out";
            else if (temp < 60 && temp >= 40)
                output = "feels like Autumn";
            else if (temp < 80 && temp >= 60)
                output = "perfect outdoor workout temperature";
            else if (temp < 90 && temp >= 80)
                output = "niiice";
            else if (temp < 100 && temp >= 90)
                output = "hella hot";
            else if (temp < 135 && temp >= 100)
                output = "hottest";
            else
                output = "NULL";

            Console.WriteLine(output);


            //throw new NotImplementedException($"GiveActivityAdvice() has not been implemented.");
        }

        /// <summary>
        /// This method gets a username and password from the user
        /// and stores that data in the global variables of the 
        /// names in the method.
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("Please enter a username:");
            username = Console.ReadLine();
            Console.WriteLine("Please enter a password:");
            password = Console.ReadLine();
            Console.Clear();

            //throw new NotImplementedException($"Register() has not been implemented.");
        }

        /// <summary>
        /// This method gets username and password from the user and
        /// compares them with the username and password names provided in Register().
        /// If the password and username match, the method returns true. 
        /// If they do not match, the user is reprompted for the username and password
        /// until the exact matches are inputted.
        /// </summary>
        /// <returns></returns>
        public static bool Login()
        {
            do
            {

                Console.WriteLine("To login, enter username:");
                object uninputted = Console.ReadLine();
                Console.WriteLine("\nEnter Password:");
                object pinputted = Console.ReadLine();

                if (uninputted == username && pinputted == password)
                    return true;
                else
                    return false;

            }
            while (false);

            //throw new NotImplementedException($"Login() has not been implemented.");
        }

        /// <summary>
        /// This method has one int parameter.
        /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
        /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
        /// or > 78, Console.WriteLine($"{temp} is too hot!");
        /// For each temperature range, a different advice is given. 
        /// </summary>
        /// <param name="temp"></param>
        public static void GetTemperatureTernary(int temp)
        {
            if (temp <= 42)
                Console.WriteLine($"{temp} is too cold!");
            else if (temp >= 43 && temp <= 78)
                Console.WriteLine($"{temp} is an ok temperature");
            else if (temp > 78)
                Console.WriteLine($"{temp} is too hot!");

            //throw new NotImplementedException($"GetTemperatureTernary() has not been implemented.");
        }
    }//EoP
}//EoN
