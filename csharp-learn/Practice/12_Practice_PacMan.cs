using System;           // For Console input/output operations
using System.IO;        // For File.ReadAllLines to load map from file
using System.Threading; // For Thread.Sleep to control game speed
using System.Threading.Tasks; // For Task.Run to handle async key input

/*
 * PAC-MAN CONSOLE GAME - Advanced Practice
 * 
 * This game demonstrates advanced console game development concepts:
 * 
 * KEY CONCEPTS:
 * 1. File I/O - Loading game map from external text file
 * 2. 2D Arrays - Storing and manipulating game world
 * 3. Multithreading - Async key input handling (Task.Run)
 * 4. Ref parameters - Modifying variables across functions
 * 5. Game loop pattern - Continuous update and render cycle
 * 6. Collision detection - Checking walls and collectibles
 * 7. Score tracking and display
 * 8. Console cursor positioning and coloring
 * 
 * GAME MECHANICS:
 * - Player (@) moves with arrow keys
 * - Collect dots (.) to increase score
 * - Walls (#) block movement
 * - Map loaded from "pacman_map.txt"
 * 
 * IMPORTANT NOTE:
 * This implementation requires all lines in the map file to have EQUAL LENGTH.
 * For irregular maps, a different approach is needed (padding with spaces).
 */

namespace csharp_learn
{
    internal class Practice12_PacMan
    {
        public static void Run()
        {
            // ============================
            // GAME INITIALIZATION
            // ============================

            // Hide the blinking cursor for cleaner visuals
            Console.CursorVisible = false;

            // Load the game map from external text file into 2D array
            char[,] map = ReadMap("pacman_map.txt");

            // ============================
            // ASYNC INPUT HANDLING
            // ============================

            // Initialize with default key press (W key)
            // This stores the most recent key pressed by the player
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

            // Start a separate thread to continuously listen for key presses
            // This prevents blocking the main game loop while waiting for input
            // Task.Run executes code asynchronously (in parallel)
            Task.Run(() =>
            {
                // Infinite loop - always listening for player input
                while (true)
                {
                    // Wait for and capture the next key press
                    // This runs independently from the main game loop
                    pressedKey = Console.ReadKey();
                }
            });

            // ============================
            // GAME STATE VARIABLES
            // ============================

            // Pac-Man's starting position (X = horizontal, Y = vertical)
            int packmanX = 1;  // Column position (left-right)
            int packmanY = 1;  // Row position (up-down)

            // Player's current score (increases when collecting dots)
            int score = 0;

            // ============================
            // MAIN GAME LOOP
            // ============================

            // Infinite loop - game runs until manually stopped
            while (true)
            {
                // ============================
                // RENDER PHASE
                // ============================

                // Clear previous frame to prevent visual artifacts
                Console.Clear();

                // Draw the map in blue color
                Console.ForegroundColor = ConsoleColor.Blue;
                PrintMap(map);

                // Draw Pac-Man character (@) in yellow at current position
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(packmanX, packmanY);
                Console.Write("@");

                // Display score in red at top-right corner
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(32, 0);
                Console.Write($"Score: {score}");

                // ============================
                // UPDATE PHASE
                // ============================

                // Process player input and update game state
                // Uses ref to modify packmanX, packmanY, and score directly
                HandleInput(pressedKey, ref packmanX, ref packmanY, map, ref score);

                // ============================
                // FRAME DELAY
                // ============================

                // Pause for 1 second (1000 milliseconds) between frames
                // Controls game speed - lower value = faster movement
                // NOTE: 1 second is very slow! Consider reducing to 100-200ms
                Thread.Sleep(1000);
            }
        }

        // ============================
        // READ MAP FROM FILE
        // ============================

        /// <summary>
        /// Loads game map from text file and converts to 2D character array
        /// </summary>
        /// <param name="path">Path to map file (currently unused - hardcoded to "pacman_map.txt")</param>
        /// <returns>2D char array representing the game world</returns>
        private static char[,] ReadMap(string path)
        {
            // Read all lines from the map file into string array
            // Each line becomes one element in the array
            string[] file = File.ReadAllLines("pacman_map.txt");

            // Create 2D array with dimensions:
            // - Width (X): Longest line length in file
            // - Height (Y): Number of lines in file
            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            // Convert string array to 2D char array
            // Outer loop: Iterate through columns (X-axis)
            for (int x = 0; x < map.GetLength(0); x++)
            {
                // Inner loop: Iterate through rows (Y-axis)
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    // Copy character from file[row][column] to map[column, row]
                    // Note: We swap X and Y here for proper map orientation
                    map[x, y] = file[y][x];
                }
            }

            return map;
        }

        // ============================
        // RENDER MAP TO CONSOLE
        // ============================

        /// <summary>
        /// Draws the entire game map to the console
        /// </summary>
        /// <param name="map">2D char array representing game world</param>
        private static void PrintMap(char[,] map)
        {
            // Iterate through rows (Y-axis, top to bottom)
            for (int y = 0; y < map.GetLength(1); y++)
            {
                // Iterate through columns (X-axis, left to right)
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    // Print each character at current position
                    Console.Write(map[x, y]);
                }
                // Move to next line after completing a row
                Console.Write("\n");
            }
        }

        // ============================
        // HANDLE PLAYER INPUT
        // ============================

        /// <summary>
        /// Processes player input and updates Pac-Man's position
        /// Handles collision detection with walls and dot collection
        /// </summary>
        /// <param name="pressedKey">Most recent key press from player</param>
        /// <param name="packmanX">Current X position (modified by ref)</param>
        /// <param name="packmanY">Current Y position (modified by ref)</param>
        /// <param name="map">Game world for collision checking</param>
        /// <param name="score">Current score (modified by ref when collecting dots)</param>
        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int packmanX, ref int packmanY, char[,] map, ref int score)
        {
            // ============================
            // CALCULATE MOVEMENT DIRECTION
            // ============================

            // Get movement vector based on pressed key
            // Returns [deltaX, deltaY] - how much to move in each axis
            int[] direction = GetDirection(pressedKey);

            // Calculate next position by adding direction to current position
            int nextPackmanPositionX = packmanX + direction[0];
            int nextPackmanPositionY = packmanY + direction[1];

            // ============================
            // COLLISION DETECTION
            // ============================

            // Check what character is at the next position
            char nextCell = map[nextPackmanPositionX, nextPackmanPositionY];

            // Only move if next cell is empty space ' ' or collectible dot '.'
            if (nextCell == ' ' || nextCell == '.')
            {
                // ============================
                // UPDATE POSITION
                // ============================

                // Move Pac-Man to new position
                packmanX = nextPackmanPositionX;
                packmanY = nextPackmanPositionY;

                // ============================
                // COLLECT DOT
                // ============================

                // If stepped on a dot, increase score and remove dot from map
                if (nextCell == '.')
                {
                    score++;  // Increment score
                    map[nextPackmanPositionX, nextPackmanPositionY] = ' ';  // Replace dot with empty space
                }
            }
            // If nextCell is '#' (wall) or any other character, movement is blocked
        }

        // ============================
        // CONVERT KEY PRESS TO DIRECTION
        // ============================

        /// <summary>
        /// Converts arrow key press into movement vector
        /// </summary>
        /// <param name="pressedKey">Key pressed by player</param>
        /// <returns>Array [deltaX, deltaY] representing movement direction</returns>
        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            // Initialize direction vector [X-axis, Y-axis]
            // [0, 0] means no movement
            int[] direction = { 0, 0 };

            // Check which arrow key was pressed and set direction accordingly

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                direction[1] = -1;  // Move up (decrease Y coordinate)
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                direction[1] = 1;   // Move down (increase Y coordinate)
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                direction[0] = -1;  // Move left (decrease X coordinate)
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                direction[0] = 1;   // Move right (increase X coordinate)
            }

            return direction;
        }

        // ============================
        // FIND LONGEST LINE IN FILE
        // ============================

        /// <summary>
        /// Finds the maximum line length in the map file
        /// Used to determine the width of the 2D array
        /// </summary>
        /// <param name="lines">Array of strings from map file</param>
        /// <returns>Length of the longest line</returns>
        private static int GetMaxLengthOfLine(string[] lines)
        {
            // Start with length of first line as initial max
            int maxLength = lines[0].Length;

            // Iterate through all lines to find the longest
            foreach (var line in lines)
            {
                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }

            return maxLength;
        }
    }
}