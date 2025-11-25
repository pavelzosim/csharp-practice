using System;

namespace csharp_learn
{
    internal class Practice13
    {
        public static void Run()
        {
        float health;
        int armor, damage;
        int percentConverter = 100;

        Console.Write("Enter hero health: ");
        health = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter hero armor: ");
        armor = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter hero damage: ");
        damage = Convert.ToInt32(Console.ReadLine());

        health -= Convert.ToSingle(damage) / percentConverter * armor ;
        Console.WriteLine($"Hero was damaged by {damage} points. Health left: {health}");
    }
}
}