using System;
using System.Text;

namespace csharp_learn
{
    internal class Lesson11
    {
        public static void Run()
        {
            // Set console encoding to support Unicode characters
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;


            string name;                                // Initialize a string variable       
            Console.Write("Enter your name: ");         // Prompt the user for their name
            name = Console.ReadLine();                  // Read user input from the console
            Console.WriteLine($"Hello, {name}!");       // Console output with user input

            int age;
            Console.Write("Enter your age: ");
            age = Convert.ToInt32(Console.ReadLine());  // Convert input string to integer

            Console.WriteLine($"You are {age} years old.");

            // Wait for user to press a key before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
