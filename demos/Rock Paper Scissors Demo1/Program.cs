using System;

namespace Rock_Paper_Scissors_Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //get input from user
            Console.WriteLine("Hello, welcome to a game of Rock-Paper-Scissors");

            //validate user input as 1,2, or 3
            int convertedNumber;
            bool conversionBool;

            do
            {
                Console.WriteLine("Please enter a 1 for Rock, 2 for Paper, 3 for Scissors.");
                string userInput = Console.ReadLine();

                //validate the use input as a 1, 2, or 3
                //this version of TryParse() takes a string and the second argument is an out variable that is instantiated in that moment.
                conversionBool = Int32.TryParse(userInput, out convertedNumber);

                if (!conversionBool || convertedNumber < 1 || convertedNumber > 3)
                {
                    Console.WriteLine("Bless your heart, that wasn't a 1, 2, or 3!");
                }

            } while (!(convertedNumber > 0 && convertedNumber < 4));

            //Input is vaild, let the games begin!

            Random compRandNum = new Random();
            int compChoice = compRandNum.Next(1, 4);
            int userCounter = 0;
            int cpuCounter = 0;
            int ties = 0;

            do
            {
                if (convertedNumber == 1 && compChoice == 2)
                {
                    Console.WriteLine($"I chose {compChoice}, I win! Again?");
                    cpuCounter++;
                    string userInput = Console.ReadLine();
                    compChoice = compRandNum.Next(1, 4);
                }
                else if (convertedNumber == 1 && compChoice == 3)
                {
                    Console.WriteLine($"I chose {compChoice}, you win! Again?");
                    userCounter++;
                    string userInput = Console.ReadLine();
                    compChoice = compRandNum.Next(1, 4);
                }
                else if (convertedNumber == 2 && compChoice == 3)
                {
                    Console.WriteLine($"I chose {compChoice}, I win! Again?");
                    cpuCounter++;
                    string userInput = Console.ReadLine();
                    compChoice = compRandNum.Next(1, 4);
                }
                else if (convertedNumber == 2 && compChoice == 1)
                {
                    Console.WriteLine($"I chose {compChoice}, you win! Again?");
                    userCounter++;
                    string userInput = Console.ReadLine();
                    compChoice = compRandNum.Next(1, 4);
                }
                else if (convertedNumber == 3 && compChoice == 2)
                {
                    Console.WriteLine($"I chose {compChoice}, you win! Again?");
                    userCounter++;
                    string userInput = Console.ReadLine();
                    compChoice = compRandNum.Next(1, 4);
                }
                else if (convertedNumber == 3 && compChoice == 1)
                {
                    Console.WriteLine($"I chose {compChoice}, I win! Again?");
                    cpuCounter++;
                    string userInput = Console.ReadLine();
                    compChoice = compRandNum.Next(1, 4);
                }
                else if (convertedNumber == compChoice)
                {
                    Console.WriteLine($"I chose{compChoice},it's a Tie! Again?");
                    ties++;
                    string userInput = Console.ReadLine();
                    compChoice = compRandNum.Next(1, 4);
                }
            } while (userCounter < 2 || cpuCounter < 2);

            //Determining the winner after 2/3 games
            if (userCounter == 2 && cpuCounter < 2)
            {
                Console.WriteLine($"You win! Great job!\nThe number of ties were {ties}.");
            }
            else if (cpuCounter == 2)
            {
                Console.WriteLine($"I win! Yay me!\nThe number of ties were {ties}.");
            }


            Console.WriteLine("Thanks for playing!");
        }

    }

}
