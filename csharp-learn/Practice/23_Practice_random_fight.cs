using System;
using System.Security.Authentication;

namespace csharp_learn
{
    internal class Practice23_random_fight
    {
        public static void Run()
        {
            Random rand = new Random();

            float health1 = rand.Next(90, 100);
            int damage1 = rand.Next(5, 20);
            int armor1 = rand.Next(25, 65);

            float health2 = rand.Next(50, 150);
            int damage2 = rand.Next(5, 20);
            int armor2 = rand.Next(25, 65);

            Console.WriteLine($"Fighter 1 - Health: {health1}, Damage: {damage1}, Armor: {armor1}");
            Console.WriteLine($"Fighter 2 - Health: {health2}, Damage: {damage2}, Armor: {armor2}");

            while (health1 > 0 && health2 > 0)
            {
                health1 -= Convert.ToSingle(rand.Next(0, damage2 + 1)) / 100 * armor1;
                health2 -= Convert.ToSingle(rand.Next(0, damage1 + 1)) / 100 * armor2;

                Console.WriteLine("Health Fighter 1: " + health1);
                Console.WriteLine("Health Fighter 2: " + health2);
            }
            if(health1 <= 0 && health2 <= 0)
            {
                Console.WriteLine("It's a draw!");
            }
            else if (health1 <= 0)
            {
                Console.WriteLine("Fighter 2 wins!");
            }
            else
            {
                Console.WriteLine("Fighter 1 wins!");
            }    
        
        }
    }
}