using System;

namespace csharp_learn
{
    internal class Lesson12
    {
        public static void Run()
        {
            int i = 0;
            // !!! Increment and Decrement Operators have higher priority than most other operators.

            // For a clean experiment, comment out extra operations below
            // so that i is not recalculated before testing increments/decrements.
            // Example: keep only Console.WriteLine(i++); or Console.WriteLine(++i);

            // i++;   // Post-increment
            // ++i;   // Pre-increment
            // --i;   // Pre-decrement

            Console.WriteLine(i);    // Prints 0

            // Post-increment: value is used first, then incremented
            Console.WriteLine(i++);  // Prints 0, then i becomes 1

            // Pre-increment: value is incremented first, then used
            Console.WriteLine(++i);  // i becomes 2, then prints 2
        }
    }
}
