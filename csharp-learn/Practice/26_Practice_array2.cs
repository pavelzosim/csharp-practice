using System;
using System.Security.Authentication;

namespace csharp_learn
{
    internal class Practice26_array2
    {
        public static void Run()
        {
            // Array declaration and initialization
            // We create an array of integers that stores the number of available seats in each sector
            // Index:  0   1   2   3   4
            // Value: [6, 27, 15, 15, 17]
            int[] sectors = { 6, 27, 15, 15, 17 };

            // Boolean flag to control the main program loop
            // While isOpen is true, the program continues to run
            // When isOpen becomes false, the program will exit
            bool isOpen = true;

            // Main program loop - runs until user chooses to exit
            while (isOpen)
            {
                // Set cursor position to row 18, column 0 for displaying sector information
                // This helps keep the display organized on the screen
                Console.SetCursorPosition(0, 18);

                // Loop through all sectors and display available seats
                // We use sectors.Length to get the total number of sectors (5 in this case)
                for (int i = 0; i < sectors.Length; i++)
                {
                    // Display sector number (i+1 because users count from 1, not 0)
                    // and the number of available seats in that sector
                    Console.WriteLine($"In sector [{i + 1}] there are {sectors[i]} places.");
                }

                // Move cursor back to top of screen for main menu
                Console.SetCursorPosition(0, 0);

                // Display the main menu
                Console.WriteLine("Registration of the place.");
                Console.WriteLine("\n\n1 - Book places.\n \n2 - Exit from the program.\n\n");
                Console.Write("Enter command number: ");

                // Read user's menu choice and convert it to an integer
                // Then use switch statement to handle different options
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: // User wants to book seats
                        // Declare variables to store user's sector choice and number of seats
                        int userSector, userPlaceAmount;

                        // Ask user which sector they want to book
                        Console.Write("In which sector you want to fly? ");
                        // Read sector number and subtract 1 to convert to array index
                        // (User enters 1-5, but array uses indices 0-4)
                        userSector = Convert.ToInt32(Console.ReadLine()) - 1;

                        // Validate that the sector number is within valid range
                        // Check if index is negative OR greater than/equal to array length
                        if (userSector >= sectors.Length || userSector < 0)
                        {
                            Console.WriteLine("Wrong sector.");
                            break; // Exit this case and return to main menu
                        }

                        // Ask how many seats the user wants to book
                        Console.Write("How many places you want to book? ");
                        userPlaceAmount = Convert.ToInt32(Console.ReadLine());

                        // Validate the booking request
                        // Check if requested amount is more than available OR is negative
                        if (sectors[userSector] < userPlaceAmount || userPlaceAmount < 0)
                        {
                            // Display error message with sector number (add 1 to show user-friendly number)
                            // and show how many seats are actually available
                            Console.WriteLine($"In sector {userSector + 1} not enough places. " +
                                $"Left {sectors[userSector]}");
                            break; // Exit this case and return to main menu
                        }

                        // Booking is valid - subtract booked seats from available seats
                        // This is equivalent to: sectors[userSector] = sectors[userSector] - userPlaceAmount;
                        sectors[userSector] -= userPlaceAmount;
                        Console.WriteLine("Successfully booked!");
                        break;

                    case 2: // User wants to exit the program
                        // Set flag to false, which will end the while loop
                        isOpen = false;
                        break;
                }

                // Wait for user to press any key before clearing the screen
                // This allows user to see the result of their action
                Console.ReadKey();

                // Clear the entire console screen for the next iteration
                Console.Clear();
            }
        }
    }
}