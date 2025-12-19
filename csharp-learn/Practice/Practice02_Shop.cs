using System;

namespace csharp_learn
{
    internal class Practice02_Shop
    {
        public static void Run()
        {
            int money, food;
            int foodUnitPrice = 10;
            bool isAbleToBuy;

            Console.WriteLine("Welcome to the Shop! Todays food price is " + foodUnitPrice + " money.");
            Console.Write("Enter your available money: ");
            money = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the amount of food you want to buy: ");
            food = Convert.ToInt32(Console.ReadLine());

            isAbleToBuy = money >= food * foodUnitPrice; // Check if the user has enough money
            food *= Convert.ToInt32(isAbleToBuy); // If able to buy, keep the food amount; otherwise set to 0
            money -= food * foodUnitPrice;

            Console.WriteLine($"You got {food} food items, money left is {money}. ");

        }
    }
}