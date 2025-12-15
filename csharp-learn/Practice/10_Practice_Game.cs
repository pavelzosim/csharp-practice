using System;
using System.Security.Authentication;

/*
 * SIMPLE CONSOLE GAME - Learning Example
 * 
 * This program demonstrates a basic 2D console game where a player (@) moves around a map,
 * collects treasures (X), and avoids walls (#).
 * 
 * Step-by-step development logic:
 * 1. Initialize the game map as a 2D array and define the playable area
 * 2. Use nested loops to render the map in the console
 * 3. Create a game loop (while) to continuously update and display the game
 * 4. Track player position with coordinate variables
 * 5. Prevent screen flickering by hiding cursor and using Console.Clear()
 * 6. Implement player movement controls using arrow keys
 * 7. Add collision detection to prevent walking through walls
 * 8. Place collectible treasures on the map
 * 9. Implement treasure collection logic and inventory system
 */

namespace csharp_learn
{
    internal class Practice10_Practice_Game
    {
        public static void Run()
        {
            // ============================
            // GAME INITIALIZATION
            // ============================
            
            // Hide the blinking cursor for a cleaner visual experience
            Console.CursorVisible = false;
            
            // Define the game map as a 2D character array
            // '#' = walls (impassable), ' ' = empty space (walkable), 'X' = treasure (collectible)
            char[,] map =
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', },
                { '#', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', },
                { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', },
                { '#', ' ', ' ', ' ', '#', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', '#', },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', }
            };

            // Player starting position (row 6, column 6)
            // userX = row index (vertical position, top to bottom)
            // userY = column index (horizontal position, left to right)
            int userX = 6, userY = 6;
            
            // Player's inventory (bag) to store collected treasures
            // Starting with capacity of 1, will expand dynamically when items are collected
            char[] bag = new char[1];

            // ============================
            // MAIN GAME LOOP
            // ============================
            
            // Infinite loop - the game runs continuously until manually stopped
            while (true)
            {
                // ============================
                // DISPLAY INVENTORY
                // ============================
                
                // Position cursor below the map to display inventory
                Console.SetCursorPosition(0, 20);
                Console.Write("Bag: ");
                
                // Loop through the bag array and display all collected items
                for (int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                // ============================
                // RENDER THE MAP
                // ============================
                
                // Reset cursor to top-left corner before drawing the map
                Console.SetCursorPosition(0, 0);

                // Outer loop: iterate through rows (GetLength(0) returns number of rows)
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    // Inner loop: iterate through columns (GetLength(1) returns number of columns)
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        // Print each character from the map array
                        Console.Write(map[i, j]);
                    }
                    // Move to next line after completing a row
                    Console.WriteLine();
                }
                
                // ============================
                // DRAW PLAYER CHARACTER
                // ============================
                
                // Position cursor at player's location
                // NOTE: SetCursorPosition uses (column, row), but our variables are (row, column)
                // So we swap: userY is horizontal (column), userX is vertical (row)
                Console.SetCursorPosition(userY, userX);
                
                // Draw the player character '@' at the current position
                Console.Write('@');

                // ============================
                // HANDLE PLAYER INPUT
                // ============================
                
                // Wait for and capture the player's keyboard input
                // This pauses the game loop until a key is pressed
                ConsoleKeyInfo charKey = Console.ReadKey();
                
                // Process movement based on arrow key input
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        // Check if the cell above is not a wall before moving
                        // userX - 1 means one row up (decreasing row index moves up)
                        if (map[userX - 1, userY] != '#')
                        {
                            userX--; // Move player up
                        }
                        break;
                        
                    case ConsoleKey.DownArrow:
                        // Check if the cell below is not a wall before moving
                        // userX + 1 means one row down (increasing row index moves down)
                        if (map[userX + 1, userY] != '#')
                        {
                            userX++; // Move player down
                        }
                        break;
                        
                    case ConsoleKey.LeftArrow:
                        // Check if the cell to the left is not a wall before moving
                        // userY - 1 means one column left (decreasing column index moves left)
                        if (map[userX, userY - 1] != '#')
                        {
                            userY--; // Move player left
                        }
                        break;
                        
                    case ConsoleKey.RightArrow:
                        // Check if the cell to the right is not a wall before moving
                        // userY + 1 means one column right (increasing column index moves right)
                        if (map[userX, userY + 1] != '#')
                        {
                            userY++; // Move player right
                        }
                        break;
                }

                // ============================
                // TREASURE COLLECTION LOGIC
                // ============================
                
                // Check if the player's current position contains a treasure
                if (map[userX, userY] == 'X')
                {
                    // Mark the treasure as collected by replacing 'X' with 'o' on the map
                    map[userX, userY] = 'o';
                    
                    // Expand the bag array to accommodate the new item
                    // Create a temporary array with one additional slot
                    char[] tempBag = new char[bag.Length + 1];
                    
                    // Copy existing items from old bag to new bag
                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];
                    }
                    
                    // Add the collected treasure to the last position in the new bag
                    tempBag[tempBag.Length - 1] = 'X';
                    
                    // Replace the old bag with the expanded bag
                    bag = tempBag;
                }
                
                // ============================
                // REFRESH SCREEN
                // ============================
                
                // Clear the entire console to prepare for the next frame
                // This prevents visual artifacts and flickering
                // Combined with Console.ReadKey(), it ensures smooth rendering
                Console.Clear();
            }
        }
    }
}