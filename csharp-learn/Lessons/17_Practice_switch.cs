using System;
using System.Security.Authentication;

namespace csharp_learn
{
    internal class Practice17_switch
    {
        public static void Run()
        {
            float goldInWallet;
            float silverInWallet;

            int silverToGoldRate = 60, goldToSilverRate = 75;

            float exchangeCurrencyCount;

            string desiredOperation;

            Console.WriteLine("Welcome to exchange office!");

            Console.Write("Enter ballance of the gold: ");
            goldInWallet = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter ballance of the silver: ");
            silverInWallet = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Choose operation.");
            Console.WriteLine("1 - Exchance gold to silver");
            Console.WriteLine("2 - Exchance silver to gold");
            Console.Write("Your Choose: ");
            desiredOperation = Console.ReadLine();

            switch (desiredOperation)
            {
                case "1":
                    Console.WriteLine("Exchange gold to silver");
                    Console.Write("Amount of exchange? ");
                    exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                    
                    if(goldInWallet >= exchangeCurrencyCount)
                    {
                        goldInWallet -= exchangeCurrencyCount;
                        silverInWallet += exchangeCurrencyCount / goldToSilverRate;
                    }
                    else
                    {
                        Console.WriteLine("Wrong amount of gold");
                    }
                    break;

                case "2":
                    Console.WriteLine("Exchange silver to gold");
                    Console.Write("Amount of exchange? ");
                    exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                    
                    if (silverInWallet >= exchangeCurrencyCount)
                    {
                        silverInWallet -= exchangeCurrencyCount;
                        goldInWallet += exchangeCurrencyCount / silverToGoldRate;  // Fixed!
                    }
                    else
                    {
                        Console.WriteLine("Wrong amount of silver.");
                    }
                    break;

                default:
                    Console.WriteLine("Wrong operation.");
                    break;
            }
            Console.WriteLine($"Your Balance: {goldInWallet} gold," + $" {silverInWallet} silver.");
        }
    }
}