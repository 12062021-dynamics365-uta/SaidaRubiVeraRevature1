using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            int randomNum = GetRandomNumber();
            int userGuess = GetUsersGuess();

            List<int> userGuesses = new List<int>();

            do
            {
                if (randomNum < userGuess)
                    Console.WriteLine($"{userGuess} is higher than my number");
                else if (randomNum == userGuess)
                    Console.WriteLine($"You guessed my number!! It was {userGuess}");
                else if (randomNum > userGuess)
                    Console.WriteLine($"{userGuess} is lower than my number");
                GetUsersGuess();
            }
            while (randomNum != userGuess);
            */
             
            
        }

        /// <summary>
        /// This method returns a randomly chosen number between 1 and 100, inclusive.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNumber()
        {
            Console.WriteLine("Welcome to the guessing game! I will pick a random number and you get 10 trys to guess it. If you don't, you lose.\n" +
                "Okay I have my number, let the game begin!");
            Random random = new Random(); 
            return random.Next(1,101);

            //throw new NotImplementedException();
        }

        /// <summary>
        /// This method gets input from the user, 
        /// verifies that the input is valid and 
        /// returns an int.
        /// </summary>
        /// <returns></returns>
        public static int GetUsersGuess()
        {
            int input;

            do
            {
                Console.WriteLine("What is your guess?");
                input = Console.Read();
                Console.Clear();
            }
            while (input > 1 && input <= 100);
            return input;

            //throw new NotImplementedException();
        }

        /// <summary>
        /// This method has two int parameters.
        /// It will:
        /// 1) compare the first number to the second number
        /// 2) return -1 if the first number is less than the second number
        /// 3) return 0 if the numbers are equal
        /// 4) return 1 if the first number is greater than the second number
        /// </summary>
        /// <param name="randomNum"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static int CompareNums(int randomNum, int guess)
        {

            if (randomNum < guess)
            {
                return -1;
            }
            else if (randomNum == guess)
            {
                return 0;
            }
            else if (randomNum > guess)
            {
                return 1;
            }
            else
                return 2;

            if (randomNum < guess)
            {
                Console.WriteLine($"{guess} is higher than my number");
            }
            else if (randomNum == guess)
                Console.WriteLine($"You guessed my number!! It was {guess}");
            else if (randomNum > guess)
                Console.WriteLine($"{guess} is lower than my number");


            //throw new NotImplementedException();
        }

        /// <summary>
        /// This method offers the user the chance to play again. 
        /// It returns true if they want to play again and false if they do not.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool PlayGameAgain()
        {
            Console.WriteLine("Want to play again? \nPress 1 for YES\nPress anything else for NO");
            int choice = Console.Read();

            if (choice == 1)
                return true;
            else
                return false;

            
            //throw new NotImplementedException();
        }
    }
}
