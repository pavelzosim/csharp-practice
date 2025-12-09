using System;
using System.IO;

namespace csharp_learn
{
    internal class Practice40_PacMan
    {
        public static void Run()
        {
            Console.CursorVisible = false;

            char[,] map = ReadMap("map.txt"); // read map from file
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

            int packmanX = 1;
            int packmanY = 1;

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                DrawMap(map);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(packmanX, packmanY);
                Console.Write("@");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(32, 1);
                Console.Write(pressedKey.KeyChar);

                pressedKey = Console.ReadKey();

                HandleInput(pressedKey, ref packmanX, ref packmanY);
            }
        }
        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines("map.txt"); // read all lines from file
            char[,] map = null; // declare variable 

            for (int x = 0; x < map.GetLength(0); x++)
            
                for (int y = 0; y < map.GetLength(1); y++)
                
                    map[x, y] = file[y][x];
                    return map;
                
            
        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.Write("\n");
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int packmanX, ref int packmanY)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPackmanPositionX = packmanX + direction[0];
            int nextPackmanPositionY = packmanY + direction[1];

            if (map[nextPackmanPositionX, nextPackmanPositionY] == ' ')
            {
                packmanX = nextPackmanPositionX;
                packmanY = nextPackmanPositionY;
            }

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                packmanY -= 1;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                packmanY += 1;
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                packmanY -= 1;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                packmanY += 1;
            }
        }
        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                direction[1] = -1;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                direction[1] = 1;
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                direction[0] = -1;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                direction[0] = -1;
            }
            return direction;
        }

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (var line in lines)
                if (line.Length > maxLength)
                    maxLength = line.Length;

            return maxLength;
        }
    }
}