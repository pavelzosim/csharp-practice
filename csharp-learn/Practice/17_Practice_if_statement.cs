using System;

namespace csharp_learn
{
    internal class Practice17_if_statement
    {
        public static void Run()
        {
            string password = "123qwe";
            string userInput;

            Console.Write("Enter Password: ");
            userInput = Console.ReadLine();

            if(userInput == password)
            {
                Console.WriteLine("Password accepted.");
            }
            else
            {
                Console.WriteLine("Wrong Passwor");
            }
        }
    }
}