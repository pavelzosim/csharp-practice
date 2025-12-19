using System;

namespace csharp_learn
{
    // LESSON 11: Random Number Generation
    // Learn how to generate random numbers for games, simulations, and randomized behavior
    internal class Lesson11_random
    {
        public static void Run()
        {
            // ===== TOPIC: RANDOM CLASS =====
            // Random class generates pseudo-random numbers
            // Used for: dice rolls, loot drops, enemy spawns, procedural generation

            // Create Random object (do this ONCE, not in loops!)
            Random random = new Random();

            // ===== BASIC RANDOM NUMBER GENERATION =====

            Console.WriteLine("=== BASIC RANDOM NUMBERS ===");

            // random.Next() - generates random integer
            int anyNumber = random.Next();  // 0 to int.MaxValue (2,147,483,647)
            Console.WriteLine($"Random int: {anyNumber}");

            // random.Next(max) - generates 0 to max-1
            int diceRoll = random.Next(6);  // 0, 1, 2, 3, 4, or 5
            Console.WriteLine($"Dice roll (0-5): {diceRoll}");

            // random.Next(min, max) - generates min to max-1
            int realDice = random.Next(1, 7);  // 1, 2, 3, 4, 5, or 6
            Console.WriteLine($"Real dice (1-6): {realDice}");

            // random.NextDouble() - generates 0.0 to 1.0 (exclusive)
            double percentage = random.NextDouble();  // 0.0 to 0.999...
            Console.WriteLine($"Random percentage: {percentage:P2}");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLES =====

            Console.WriteLine("=== PRACTICAL RANDOM EXAMPLES ===");

            // Example 1: Coin flip
            int coinFlip = random.Next(0, 2);  // 0 or 1
            string coinResult = (coinFlip == 0) ? "Heads" : "Tails";
            Console.WriteLine($"Coin flip: {coinResult}");

            // Example 2: Random damage (50 to 100)
            int damage = random.Next(50, 101);  // 50-100 inclusive
            Console.WriteLine($"Attack damage: {damage}");

            // Example 3: Critical hit chance (20%)
            double critChance = random.NextDouble();
            bool isCritical = critChance < 0.20;  // 20% chance
            Console.WriteLine($"Critical hit: {isCritical} (roll: {critChance:P2})");

            // Example 4: Random float in range (0.5 to 2.5)
            float multiplier = (float)(random.NextDouble() * 2.0 + 0.5);  // 0.5 to 2.5
            Console.WriteLine($"Damage multiplier: {multiplier:F2}x");

            // Example 5: Random element from array
            string[] lootTable = { "Sword", "Shield", "Potion", "Gold", "Armor" };
            int randomIndex = random.Next(lootTable.Length);
            string loot = lootTable[randomIndex];
            Console.WriteLine($"Random loot drop: {loot}");

            Console.WriteLine();

            // ===== INTERACTIVE RANDOM DEMONSTRATION =====

            Console.WriteLine("=== INTERACTIVE RANDOM GENERATOR ===");
            Console.WriteLine("Press any key to generate random numbers (Esc to exit)");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                // Generate random number between 1 and 100
                int randomValue = random.Next(1, 101);
                Console.WriteLine($"Random number (1-100): {randomValue}");
            }

            Console.WriteLine();

            // ===== WEIGHTED RANDOM (Probability) =====

            Console.WriteLine("=== WEIGHTED RANDOM (LOOT RARITY) ===");

            // Simulate loot drops with different rarities
            for (int i = 0; i < 10; i++)
            {
                double roll = random.NextDouble();
                string rarity;

                // Weighted probabilities:
                // Common: 60%, Rare: 25%, Epic: 10%, Legendary: 5%
                if (roll < 0.60)
                {
                    rarity = "Common";
                }
                else if (roll < 0.85)  // 0.60 + 0.25
                {
                    rarity = "Rare";
                }
                else if (roll < 0.95)  // 0.85 + 0.10
                {
                    rarity = "Epic";
                }
                else
                {
                    rarity = "Legendary";
                }

                Console.WriteLine($"Drop {i + 1}: {rarity} (roll: {roll:F3})");
            }

            Console.WriteLine();

            // ===== RANDOM WITHOUT REPETITION (Shuffle) =====

            Console.WriteLine("=== SHUFFLE ARRAY (Fisher-Yates) ===");

            int[] deck = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            Console.WriteLine("Original deck: " + string.Join(", ", deck));

            // Fisher-Yates shuffle algorithm
            for (int i = deck.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                // Swap deck[i] and deck[j]
                int temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }

            Console.WriteLine("Shuffled deck: " + string.Join(", ", deck));
            Console.WriteLine();

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.WriteLine("=== RANDOM BEST PRACTICES ===");

            // TIP 1: CREATE RANDOM ONCE - CRITICAL!
            // WRONG - Creates new Random in loop:
            // for (int i = 0; i < 10; i++) {
            //     Random r = new Random();  // BAD - Same seed, same numbers!
            //     Console.WriteLine(r.Next());
            // }

            // CORRECT - Create once, reuse:
            // Random random = new Random();  // Create ONCE
            // for (int i = 0; i < 10; i++) {
            //     Console.WriteLine(random.Next());  // Reuse
            // }

            // TIP 2: UNDERSTANDING Next(min, max)
            // random.Next(1, 7) generates: 1, 2, 3, 4, 5, 6 (NOT 7!)
            // max is EXCLUSIVE (not included)
            // For dice: random.Next(1, 7) ← 7 is NOT included

            // TIP 3: RANDOM DOUBLE TO RANGE
            // Generate random float between min and max:
            // float min = 10.5f, max = 20.5f;
            // float value = (float)(random.NextDouble() * (max - min) + min);

            // TIP 4: PERCENTAGE CHANCE
            // 30% chance to drop item:
            // if (random.NextDouble() < 0.30) { DropItem(); }

            // TIP 5: RANDOM BOOLEAN
            // 50/50 chance:
            // bool coinFlip = random.Next(2) == 0;
            // Or with custom probability (70% true):
            // bool weighted = random.NextDouble() < 0.70;

            // TIP 6: GAME DEV - SEEDED RANDOM
            // Use seed for reproducible randomness (procedural generation)
            Random seededRandom = new Random(12345);  // Same seed = same sequence
            int value1 = seededRandom.Next(100);
            int value2 = seededRandom.Next(100);
            Console.WriteLine($"Seeded random (12345): {value1}, {value2}");

            // Create another with same seed - produces SAME sequence!
            Random seededRandom2 = new Random(12345);
            int value3 = seededRandom2.Next(100);
            int value4 = seededRandom2.Next(100);
            Console.WriteLine($"Same seed again: {value3}, {value4}");
            Console.WriteLine($"Values match: {value1 == value3 && value2 == value4}");
            Console.WriteLine();

            // TIP 7: AVOID MODULO BIAS
            // BIASED - Not evenly distributed:
            // int biased = Math.Abs(random.Next()) % 10;  // Some numbers more likely

            // CORRECT - Use Next(max):
            // int correct = random.Next(10);  // Evenly distributed

            // TIP 8: THREAD SAFETY
            // Random is NOT thread-safe!
            // For multi-threading, use ThreadLocal<Random> or lock

            Console.WriteLine("⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• Create Random ONCE (not in loops) - same seed = same numbers");
            Console.WriteLine("• NextDouble() is faster than Next() for float calculations");
            Console.WriteLine("• Use Next(max) instead of % modulo (avoids bias)");
            Console.WriteLine("• Cache Random instance - don't create repeatedly");

            Console.WriteLine("\n🚀 GAME DEV OPTIMIZATION:");
            Console.WriteLine("• Store Random as static field (global access)");
            Console.WriteLine("• Use seeded Random for procedural generation (reproducible)");
            Console.WriteLine("• Pre-calculate probabilities before loops");
            Console.WriteLine("• Avoid creating Random in Update() or per-frame code");

            Console.WriteLine("\n✅ BEST PRACTICES SUMMARY:");
            Console.WriteLine("• Create Random object ONCE, reuse it");
            Console.WriteLine("• Remember: Next(min, max) - max is EXCLUSIVE");
            Console.WriteLine("• Use NextDouble() for percentages and probabilities");
            Console.WriteLine("• Use seeded Random for reproducible results");
            Console.WriteLine("• Use Next(max) not % modulo (better distribution)");
            Console.WriteLine("• Random is NOT thread-safe - use locks if needed");

            Console.WriteLine("\n📋 COMMON RANDOM PATTERNS:");
            Console.WriteLine("• Dice roll (1-6): random.Next(1, 7)");
            Console.WriteLine("• Coin flip: random.Next(2) == 0");
            Console.WriteLine("• Percentage chance: random.NextDouble() < 0.30");
            Console.WriteLine("• Random float (min-max): NextDouble() * (max - min) + min");
            Console.WriteLine("• Random array element: array[random.Next(array.Length)]");

            Console.WriteLine("\n🎮 GAME DEV USE CASES:");
            Console.WriteLine("• Loot drops: Weighted random with rarity tiers");
            Console.WriteLine("• Critical hits: if (random.NextDouble() < critChance)");
            Console.WriteLine("• Damage variance: random.Next(minDmg, maxDmg + 1)");
            Console.WriteLine("• Enemy spawns: random.Next(spawnPoints.Length)");
            Console.WriteLine("• Procedural generation: new Random(seed) for maps");
            Console.WriteLine("• Shuffle deck: Fisher-Yates algorithm");

            Console.WriteLine("\n❌ COMMON MISTAKES:");
            Console.WriteLine("• Creating new Random() in loops (same seed!)");
            Console.WriteLine("• Forgetting max is EXCLUSIVE: Next(1, 6) = 1-5, not 1-6!");
            Console.WriteLine("• Using % modulo instead of Next(max) (bias)");
            Console.WriteLine("• Not understanding NextDouble() range: 0.0 to 0.999..., NOT 1.0");
            Console.WriteLine("• Using Random in multi-threaded code without locks");
        }
    }
}