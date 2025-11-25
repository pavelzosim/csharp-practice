using System;

namespace csharp_learn
{
    // LESSON 18: For Loops
    // Learn how to use for loops when the number of iterations is known
    internal class Lesson18_for
    {
        public static void Run()
        {
            // ===== TOPIC: FOR LOOP =====
            // For loop is best when you know EXACTLY how many times to iterate
            // Syntax: for (initialization; condition; increment) { code }
            // All three parts (init, condition, increment) are in ONE line

            Console.WriteLine("=== BASIC FOR LOOP ===");

            // Example 1: Count from 0 to 4
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Iteration {i}");
            }
            Console.WriteLine();

            // Example 2: Countdown from 10 to 1
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine($"Countdown: {i}");
            }
            Console.WriteLine("Blast off!\n");

            // Example 3: Count by 2s (even numbers)
            Console.WriteLine("=== INCREMENT BY 2 ===");
            for (int i = 0; i <= 10; i += 2)
            {
                Console.WriteLine($"Even number: {i}");
            }
            Console.WriteLine();

            // ===== FOR LOOP WITH ARRAYS =====

            Console.WriteLine("=== FOR LOOP WITH ARRAYS ===");

            string[] players = { "Alice", "Bob", "Charlie", "Diana" };

            // Iterate through array using index
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"Player {i + 1}: {players[i]}");
            }
            Console.WriteLine();

            // Calculate sum of array
            int[] scores = { 10, 25, 30, 15, 20 };
            int totalScore = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                totalScore += scores[i];
            }
            Console.WriteLine($"Total score: {totalScore}\n");

            // ===== NESTED FOR LOOPS =====

            Console.WriteLine("=== NESTED FOR LOOPS ===");

            // Multiplication table (3x3)
            Console.WriteLine("Multiplication Table:");
            for (int row = 1; row <= 3; row++)
            {
                for (int col = 1; col <= 3; col++)
                {
                    Console.Write($"{row * col}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Pattern printing
            Console.WriteLine("Triangle Pattern:");
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // ===== BREAK AND CONTINUE IN FOR LOOPS =====

            Console.WriteLine("=== BREAK STATEMENT ===");
            // Find first number divisible by 7
            for (int i = 1; i <= 50; i++)
            {
                if (i % 7 == 0)
                {
                    Console.WriteLine($"First number divisible by 7: {i}");
                    break;  // Exit loop immediately
                }
            }
            Console.WriteLine();

            Console.WriteLine("=== CONTINUE STATEMENT ===");
            // Print only odd numbers from 1 to 10
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    continue;  // Skip even numbers
                }
                Console.WriteLine($"Odd number: {i}");
            }
            Console.WriteLine();

            // ===== DIFFERENT FOR LOOP VARIATIONS =====

            Console.WriteLine("=== FOR LOOP VARIATIONS ===");

            // Multiple variables in for loop
            for (int i = 0, j = 10; i < 5; i++, j--)
            {
                Console.WriteLine($"i = {i}, j = {j}");
            }
            Console.WriteLine();

            // Infinite for loop (with break)
            int count = 0;
            for (; ; )  // All three parts optional (same as while(true))
            {
                Console.WriteLine($"Infinite loop iteration: {count}");
                count++;
                if (count >= 3)
                {
                    break;
                }
            }
            Console.WriteLine();

            // ===== FOREACH LOOP (For Collections) =====

            Console.WriteLine("=== FOREACH LOOP ===");

            string[] fruits = { "Apple", "Banana", "Cherry", "Date" };

            // foreach - simpler when you don't need index
            foreach (string fruit in fruits)
            {
                Console.WriteLine($"Fruit: {fruit}");
            }
            Console.WriteLine();

            // ===== FOR vs WHILE vs FOREACH COMPARISON =====

            Console.WriteLine("=== LOOP COMPARISON ===");

            int[] numbers = { 1, 2, 3, 4, 5 };

            // FOR - Best when you need index
            Console.WriteLine("Using FOR (with index):");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Index {i}: {numbers[i]}");
            }

            // FOREACH - Best when you don't need index
            Console.WriteLine("\nUsing FOREACH (no index):");
            foreach (int num in numbers)
            {
                Console.WriteLine($"Value: {num}");
            }

            // WHILE - Best for unknown iterations
            Console.WriteLine("\nUsing WHILE (condition-based):");
            int index = 0;
            while (index < numbers.Length)
            {
                Console.WriteLine($"Index {index}: {numbers[index]}");
                index++;
            }
            Console.WriteLine();

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.WriteLine("=== FOR LOOP BEST PRACTICES ===");

            // TIP 1: CACHE ARRAY LENGTH - CRITICAL FOR PERFORMANCE!
            // INEFFICIENT - Length property called EVERY iteration:
            // for (int i = 0; i < array.Length; i++) { }  // Slow for large arrays

            // EFFICIENT - Length cached before loop:
            int[] largeArray = new int[1000];
            int length = largeArray.Length;  // Read once
            for (int i = 0; i < length; i++)
            {
                // largeArray[i] = i;
            }
            // PERFORMANCE GAIN: ~10-20% faster for large arrays

            // TIP 2: PREFIX vs POSTFIX INCREMENT
            // For simple int loops, both are equal:
            // for (int i = 0; i < 10; i++) { }   // Same speed
            // for (int i = 0; i < 10; ++i) { }   // Same speed

            // For complex iterators (collections), prefix is faster:
            // for (auto it = list.begin(); it != list.end(); ++it) { }  // Faster
            // TIP: Use ++i as general best practice

            // TIP 3: AVOID CALCULATIONS IN LOOP CONDITION
            // INEFFICIENT - Function called every iteration:
            // for (int i = 0; i < GetMaxValue(); i++) { }  // GetMaxValue() called 1000 times!

            // EFFICIENT - Calculate once before loop:
            // int maxValue = GetMaxValue();
            // for (int i = 0; i < maxValue; i++) { }  // Called once

            // TIP 4: DON'T MODIFY LOOP VARIABLE INSIDE LOOP
            // CONFUSING - Hard to debug:
            // for (int i = 0; i < 10; i++) {
            //     i += 2;  // BAD - Unclear how many iterations
            // }

            // CLEAR - Use while or different increment:
            // for (int i = 0; i < 10; i += 3) { }  // Clear increment by 3

            // TIP 5: GAME DEV - LOOP OPTIMIZATION
            // GAME DEV: Loops often run EVERY FRAME - optimization critical!

            // INEFFICIENT - Allocates memory every frame:
            // for (int i = 0; i < enemies.Length; i++) {
            //     Vector3 direction = new Vector3();  // SLOW - 1000 allocations per frame!
            //     direction = CalculateDirection(enemies[i]);
            // }

            // EFFICIENT - Reuse objects:
            // Vector3 direction = new Vector3();  // Allocate once
            // for (int i = 0; i < enemies.Length; i++) {
            //     direction = CalculateDirection(enemies[i]);  // Reuse - no allocation
            // }

            // TIP 6: NESTED LOOPS - WATCH COMPLEXITY!
            // WARNING: Nested loops multiply iterations
            // for (int i = 0; i < 1000; i++) {          // 1000 iterations
            //     for (int j = 0; j < 1000; j++) {      // 1,000,000 total!
            //         // This runs 1 MILLION times!
            //     }
            // }
            // Time complexity: O(n²) - Can be very slow!

            // TIP 7: REVERSE ITERATION (Sometimes faster)
            // Forward iteration:
            // for (int i = 0; i < length; i++) { }

            // Reverse iteration (slightly faster - counts down to 0):
            // for (int i = length - 1; i >= 0; i--) { }
            // Why faster? Comparison with 0 is faster than comparison with variable

            // TIP 8: FOREACH vs FOR PERFORMANCE
            // FOREACH: Cleaner code, slightly slower (creates iterator)
            // FOR: Faster (direct array access), but need to manage index

            // Use FOREACH when: Readability matters, small collections
            // Use FOR when: Performance critical, need index, large arrays

            Console.WriteLine("\n⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• Cache array.Length before loop (10-20% faster)");
            Console.WriteLine("• Use ++i as best practice (faster for iterators)");
            Console.WriteLine("• Don't call functions in loop condition");
            Console.WriteLine("• Avoid allocations inside loops (especially game loops)");
            Console.WriteLine("• Watch nested loop complexity O(n²)");

            Console.WriteLine("\n🚀 GAME DEV OPTIMIZATION:");
            Console.WriteLine("• Pre-allocate objects before loops (reuse, don't create)");
            Console.WriteLine("• Cache frequently accessed properties");
            Console.WriteLine("• Use for over foreach for performance-critical code");
            Console.WriteLine("• Reverse loops (i >= 0) slightly faster than forward");
            Console.WriteLine("• Break early when possible (don't iterate unnecessarily)");

            Console.WriteLine("\n✅ BEST PRACTICES SUMMARY:");
            Console.WriteLine("• Use FOR when iterations count is KNOWN");
            Console.WriteLine("• Use FOREACH when you don't need index (cleaner)");
            Console.WriteLine("• Use WHILE when iterations count is UNKNOWN");
            Console.WriteLine("• Cache loop conditions (length, max values)");
            Console.WriteLine("• Avoid modifying loop variable inside loop body");
            Console.WriteLine("• Use break to exit early, continue to skip iteration");
            Console.WriteLine("• Watch nested loop complexity");

            Console.WriteLine("\n📋 WHEN TO USE WHICH LOOP:");
            Console.WriteLine("• FOR: Arrays, counting 0-N, need index");
            Console.WriteLine("• FOREACH: Collections, don't need index, readability");
            Console.WriteLine("• WHILE: Unknown iterations, condition-based");
            Console.WriteLine("• DO-WHILE: Need at least one iteration");

            Console.WriteLine("\n🎮 GAME DEV USE CASES:");
            Console.WriteLine("• Update all enemies: for (int i = 0; i < enemies.Length; i++)");
            Console.WriteLine("• Process inventory: foreach (Item item in inventory)");
            Console.WriteLine("• Spawn waves: for (int wave = 1; wave <= 10; wave++)");
            Console.WriteLine("• Particle systems: for (int i = particleCount - 1; i >= 0; i--)");

            Console.WriteLine("\n❌ COMMON MISTAKES:");
            Console.WriteLine("• Not caching array.Length (slow for large arrays)");
            Console.WriteLine("• Calling expensive functions in loop condition");
            Console.WriteLine("• Allocating objects inside high-frequency loops");
            Console.WriteLine("• Modifying loop variable inside loop body");
            Console.WriteLine("• Ignoring nested loop complexity O(n²)");
        }
    }
}