using System;
using System.Security.Authentication;

namespace csharp_learn
{
    internal class Practice28_array_maticies
    {
        public static void Run()
        {
            bool isOpen = true;
            string[,] books =
            {
                { "Isaac Asimov", "Arthur C. Clarke", "Philip K. Dick" },
                { "Frank Herbert", "Stanislaw Lem", "Ray Bradbury" },
                { "William Gibson", "Neal Stephenson", "Ursula K. Le Guin" }
            };

            while (isOpen)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("\nAvailable books:\n");

                for (int i = 0; i < books.GetLength(0); i++)
                {
                    for (int j = 0; j < books.GetLength(1); j++)
                    {
                        Console.Write(books[i, j] + " | ");
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Book Library System.");
                Console.WriteLine("\n1 - Find autor by book index." +
                                  "\n\n2 - Find book by author.\n\n3 - Exit.");
                Console.Write("\nEnter command number: ");

                switch(Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int line, column;
                        Console.Write("Enter book line: ");
                        line = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.Write("Enter book column: ");
                        column = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine("Author: " + books[line, column]);
                        break;
                    case 2:
                        string author;
                        bool authorIsFound = false;
                        Console.Write("Enter author name: ");
                        author = Console.ReadLine();
                        for (int i = 0; i < books.GetLength(0); i++)
                        {
                            for (int j = 0; j < books.GetLength(1); j++)
                            {
                                if (author.ToLower() == books[i, j].ToLower())
                                {
                                    Console.WriteLine($"Author {books[i, j]} found at line {i + 1}, column {j + 1}.");
                                    authorIsFound = true;
                                }
                            }
                        }
                        if (authorIsFound == false)
                        {
                            Console.WriteLine("Author not found in the library.");
                        }
                        break;
                    case 3:
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
                
                if (isOpen)
                {
                    Console.WriteLine("\nPress any key to continue...");
                }
                Console.ReadKey();
                Console.Clear();
            } 
        }
    }
}