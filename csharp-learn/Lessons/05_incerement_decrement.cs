using System;

namespace csharp_learn
{
    // LESSON 05: Increment and Decrement Operators
    // Learn the difference between prefix (++i) and postfix (i++) operators
    internal class Lesson05_incerement_decrement
    {
        public static void Run()
        {
            // ===== TOPIC: INCREMENT (++) AND DECREMENT (--) =====

            int i = 0;
            Console.WriteLine($"Starting value: i = {i}");

            // ===== POST-INCREMENT (i++) =====
            // Returns CURRENT value, THEN increments
            Console.WriteLine($"\nPost-increment i++:");
            Console.WriteLine($"Value returned: {i++}");  // Prints 0, then i becomes 1
            Console.WriteLine($"After operation: i = {i}"); // i is now 1

            // ===== PRE-INCREMENT (++i) =====
            // Increments FIRST, THEN returns new value
            Console.WriteLine($"\nPre-increment ++i:");
            Console.WriteLine($"Value returned: {++i}");  // i becomes 2, then prints 2
            Console.WriteLine($"After operation: i = {i}"); // i is still 2

            // ===== POST-DECREMENT (i--) =====
            // Returns CURRENT value, THEN decrements
            Console.WriteLine($"\nPost-decrement i--:");
            Console.WriteLine($"Value returned: {i--}");  // Prints 2, then i becomes 1
            Console.WriteLine($"After operation: i = {i}"); // i is now 1

            // ===== PRE-DECREMENT (--i) =====
            // Decrements FIRST, THEN returns new value
            Console.WriteLine($"\nPre-decrement --i:");
            Console.WriteLine($"Value returned: {--i}");  // i becomes 0, then prints 0
            Console.WriteLine($"After operation: i = {i}"); // i is still 0

            // ===== PRACTICAL EXAMPLES =====

            // In for loops - both work the same when value isn't used
            Console.WriteLine($"\nFor loop example:");
            for (int j = 0; j < 3; j++)    // or ++j - same result in loops
            {
                Console.WriteLine($"Loop iteration: {j}");
            }

            // When value is used - ORDER MATTERS!
            int[] numbers = { 10, 20, 30 };
            int index = 0;

            Console.WriteLine($"\nPost-increment in array access:");
            Console.WriteLine($"numbers[index++] = {numbers[index++]}"); // Gets numbers[0], then index = 1
            Console.WriteLine($"Current index: {index}");

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            // TIP 1: PREFIX (++i) vs POSTFIX (i++)
            // For simple variables (int, long), modern compilers optimize both equally
            // HOWEVER, for complex objects (iterators), prefix is faster

            // In loops - when value is NOT used:
            // for (int i = 0; i < 10; ++i) { }  ← Slightly better practice
            // for (int i = 0; i < 10; i++) { }  ← Works the same for int

            // TIP 2: PERFORMANCE WITH OBJECTS
            // For objects/iterators, prefix (++i) avoids creating temporary copy
            // SLOWER: iterator++  (creates copy of iterator, then increments)
            // FASTER: ++iterator  (increments directly, no copy)

            // TIP 3: USE COMPOUND OPERATORS FOR CLARITY
            // If incrementing by more than 1, use += for clarity
            // UNCLEAR: i++; i++; i++;
            // CLEAR: i += 3;

            // TIP 4: AVOID COMPLEX EXPRESSIONS
            // CONFUSING: x = i++ + ++i;  // Hard to understand, order-dependent
            // CLEAR: i += 2; x = i;      // Explicit and readable

            // TIP 5: GAME DEV USAGE
            // Counters: frameCount++; score += 10;
            // Array iteration: currentIndex++; enemies[--count];
            // Ammo: if (ammo-- > 0) { Shoot(); }  // Check and decrement in one line

            Console.WriteLine("\n⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• For int/long, ++i and i++ are equally fast");
            Console.WriteLine("• For objects/iterators, prefer ++i (no temporary copy)");
            Console.WriteLine("• In for loops: use ++i as best practice");

            Console.WriteLine("\n✅ BEST PRACTICES:");
            Console.WriteLine("• Use ++i in for loops (general best practice)");
            Console.WriteLine("• Understand post/pre difference when value is used");
            Console.WriteLine("• Avoid complex expressions with multiple ++/--");
            Console.WriteLine("• Use += for increments larger than 1");
        }
    }
}