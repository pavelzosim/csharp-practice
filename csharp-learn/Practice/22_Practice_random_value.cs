using System;
using System.Security.Authentication;

namespace csharp_learn
{
    internal class Practice22_random_value
    {
        public static void Run()
        {
            int number;
            int lower, higher;
            int triesCont = 5;
            int userInput;
            Random rand = new Random();

            number = rand.Next(0, 101);
            lower = rand.Next(number - 10, number);
            higher = rand.Next(number + 1, number + 10);

            Console.WriteLine($"Guess the number between {lower} and {higher}!");
            Console.WriteLine($"You have {triesCont} tries.");

            while (triesCont-- > 0)
            {
                Console.Write("Your answer is: ");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == number)
                {
                    Console.WriteLine("Congratulations! You guessed the number! " + number + ".");
                    break;
                }

                else
                {
                    Console.WriteLine("Your number is wrong. Try again. Tries left: " + triesCont);
                }

            }

            if (triesCont < 0)
            {
                Console.WriteLine("Your tries are over. The number was " + number + ".");
            }
        }
    }
}