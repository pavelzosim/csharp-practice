using System;
using System.Security.Authentication;

namespace csharp_learn
{
    internal class Practice38_Practice_Healthbar
    {
        public static void Run()
        {
            int health = 5, maxHealth = 10;
            int mana = 7, maxMana = 10;

            while (true)
            {
                DrawBar(health, maxHealth, ConsoleColor.Red, 0);
                DrawBar(mana, maxMana, ConsoleColor.Blue, 1);

                Console.SetCursorPosition(0, 5);
                Console.Write("Enter value for health (0-10): ");
                health += Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter value for mana (0-10): ");
                mana += Convert.ToInt32(Console.ReadLine());
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void DrawBar(int value, int maxValue, ConsoleColor color, int position, char symbol = '_')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(0, position);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.WriteLine(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += symbol;
            }

            Console.Write(bar + ']');
        }
    }
}