using System;

namespace csharp_learn
{
    // LESSON 18: While Loops
    // Learn how to repeat code while a condition is true
    internal class Lesson18_while
    {
        public static void Run()
        {
            // ===== TOPIC: WHILE LOOP =====
            // While loop repeats code block as long as condition is TRUE
            // Syntax: while (condition) { code }
            // Condition is checked BEFORE each iteration

            Console.WriteLine("=== BASIC WHILE LOOP ===");

            // Example 1: Simple countdown
            int count = 5;
            while (count > 0)
            {
                Console.WriteLine($"Countdown: {count}");
                count--;  // CRITICAL: Must modify variable or loop runs forever!
            }
            Console.WriteLine("Blast off!\n");

            // Example 2: Birthday wishes based on age
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            int wishes = age;
            while (wishes > 0)
            {
                Console.WriteLine($"Happy Birthday! ({wishes} wishes left)");
                wishes--;
            }
            Console.WriteLine();

            // ===== DO-WHILE LOOP (Executes at least once) =====

            Console.WriteLine("=== DO-WHILE LOOP ===");

            // do-while checks condition AFTER iteration
            // Guarantees code runs AT LEAST ONCE
            int attempts = 0;
            string password;

            do
            {
                Console.Write("Enter password (hint: 'admin'): ");
                password = Console.ReadLine();
                attempts++;

                if (password != "admin")
                {
                    Console.WriteLine("Wrong password! Try again.\n");
                }

            } while (password != "admin" && attempts < 3);

            if (password == "admin")
            {
                Console.WriteLine("Access granted!\n");
            }
            else
            {
                Console.WriteLine("Too many attempts. Access denied!\n");
            }

            // ===== WHILE vs DO-WHILE COMPARISON =====

            Console.WriteLine("=== WHILE vs DO-WHILE ===");

            // WHILE - may NOT execute at all
            int x = 10;
            while (x < 5)
            {
                Console.WriteLine("This will NEVER print");  // Condition false from start
            }

            // DO-WHILE - executes AT LEAST ONCE
            int y = 10;
            do
            {
                Console.WriteLine("This prints ONCE even though condition is false");
            } while (y < 5);  // Condition checked AFTER first iteration

            Console.WriteLine();

            // ===== INFINITE LOOP (With break) =====

            Console.WriteLine("=== INFINITE LOOP WITH BREAK ===");

            // Infinite loop with manual exit
            int score = 0;
            while (true)  // Runs forever unless broken
            {
                Console.Write("Enter score (or -1 to quit): ");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == -1)
                {
                    break;  // Exit loop immediately
                }

                score += input;
                Console.WriteLine($"Total score: {score}");
            }
            Console.WriteLine($"Final score: {score}\n");

            // ===== CONTINUE STATEMENT (Skip iteration) =====

            Console.WriteLine("=== CONTINUE STATEMENT ===");

            // Print only odd numbers from 1 to 10
            int number = 0;
            while (number < 10)
            {
                number++;

                if (number % 2 == 0)
                {
                    continue;  // Skip rest of iteration for even numbers
                }

                Console.WriteLine($"Odd number: {number}");
            }
            Console.WriteLine();

            // ===== NESTED WHILE LOOPS =====

            Console.WriteLine("=== NESTED LOOPS ===");

            // Multiplication table
            int i = 1;
            while (i <= 3)
            {
                int j = 1;
                while (j <= 3)
                {
                    Console.Write($"{i * j}\t");
                    j++;
                }
                Console.WriteLine();
                i++;
            }
            Console.WriteLine();

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.WriteLine("=== WHILE LOOP BEST PRACTICES ===");

            // TIP 1: WHILE vs FOR LOOP
            // Use WHILE when: iterations count is UNKNOWN (user input, file reading)
            // Use FOR when: iterations count is KNOWN (0 to 10, array length)

            // WHILE - Unknown iterations:
            // while (player.IsAlive()) { UpdateGame(); }

            // FOR - Known iterations:
            // for (int i = 0; i < 10; i++) { ProcessElement(i); }

            // TIP 2: AVOID INFINITE LOOPS - CRITICAL!
            // WRONG - Infinite loop (count never changes):
            // int count = 0;
            // while (count < 10) {
            //     Console.WriteLine(count);  // count never incremented - INFINITE!
            // }

            // CORRECT - Loop will terminate:
            // int count = 0;
            // while (count < 10) {
            //     Console.WriteLine(count);
            //     count++;  // MUST modify condition variable!
            // }

            // TIP 3: LOOP PERFORMANCE OPTIMIZATION
            // INEFFICIENT - Recalculates array.Length every iteration:
            // while (index < array.Length) { }  // Length property called repeatedly

            // EFFICIENT - Cache length before loop:
            // int length = array.Length;
            // while (index < length) { }  // Length read once

            // TIP 4: GAME DEV - LOOP OPTIMIZATION
            // GAME DEV: Don't allocate memory inside loops (runs every frame!)

            // INEFFICIENT - Creates new object every iteration:
            // while (isRunning) {
            //     Vector3 position = new Vector3(x, y, z);  // SLOW - allocates memory
            // }

            // EFFICIENT - Reuse object:
            // Vector3 position = new Vector3();  // Allocate once
            // while (isRunning) {
            //     position.Set(x, y, z);  // Reuse - no allocation
            // }

            // TIP 5: COMPLEX CONDITIONS - CACHE THEM
            // INEFFICIENT - Expensive calculation every iteration:
            // while (enemy.CalculateDistanceToPlayer() < 10) { }

            // EFFICIENT - Calculate once per iteration:
            // float distance = enemy.CalculateDistanceToPlayer();
            // while (distance < 10) {
            //     // ... game logic ...
            //     distance = enemy.CalculateDistanceToPlayer();  // Update at end
            // }

            // TIP 6: BREAK vs RETURN
            // break - exits ONLY the current loop
            // return - exits the ENTIRE function

            // TIP 7: WHILE TRUE PATTERN
            // while (true) with break is common for game loops:
            // while (true) {
            //     ProcessInput();
            //     UpdateGame();
            //     Render();
            //     if (shouldQuit) break;
            // }

            Console.WriteLine("\n⚡ PERFORMANCE COMPARISON:");
            Console.WriteLine("• FOR loop: Best for known iterations (0 to N)");
            Console.WriteLine("• WHILE loop: Best for unknown iterations (until condition)");
            Console.WriteLine("• DO-WHILE: When you need at least ONE iteration");
            Console.WriteLine("• Cache loop conditions - don't recalculate each iteration");

            Console.WriteLine("\n🚀 GAME DEV OPTIMIZATION:");
            Console.WriteLine("• NEVER allocate objects inside game loops");
            Console.WriteLine("• Cache distances, lengths before loop");
            Console.WriteLine("• Use while (true) for main game loop with break");
            Console.WriteLine("• Avoid expensive calculations in loop condition");

            Console.WriteLine("\n✅ BEST PRACTICES SUMMARY:");
            Console.WriteLine("• ALWAYS modify loop variable to avoid infinite loops");
            Console.WriteLine("• Use while for UNKNOWN iterations, for for KNOWN");
            Console.WriteLine("• Use do-while when code must run AT LEAST ONCE");
            Console.WriteLine("• Cache expensive conditions outside loop");
            Console.WriteLine("• Use break to exit loop, continue to skip iteration");
            Console.WriteLine("• Avoid allocations inside loops (especially game loops)");

            Console.WriteLine("\n❌ COMMON MISTAKES:");
            Console.WriteLine("• Forgetting to modify condition variable (infinite loop)");
            Console.WriteLine("• Allocating memory inside high-frequency loops");
            Console.WriteLine("• Expensive calculations in loop condition");
            Console.WriteLine("• Using while for known iterations (use for instead)");

            Console.WriteLine("\n📋 WHEN TO USE WHICH LOOP:");
            Console.WriteLine("• WHILE: Reading file until EOF, player alive, user input");
            Console.WriteLine("• DO-WHILE: Menu systems, password input, 'try again' logic");
            Console.WriteLine("• FOR: Arrays, counting 0-N, known iterations");
            Console.WriteLine("• FOREACH: Collections, when index not needed");

            Console.WriteLine("\n🎮 GAME DEV USE CASES:");
            Console.WriteLine("• Main game loop: while (isRunning) { Update(); Render(); }");
            Console.WriteLine("• Player input: do { GetInput(); } while (!validInput);");
            Console.WriteLine("• Enemy search: while (distance > attackRange) { MoveCloser(); }");
            Console.WriteLine("• Spawn enemies: while (spawnCount < maxEnemies) { Spawn(); }");
        }
    }
}