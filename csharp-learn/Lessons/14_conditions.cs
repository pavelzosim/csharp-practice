using System;

namespace csharp_learn
{
    // LESSON 14: Conditional Statements (if/else/else if)
    // Learn how to make decisions in your code based on conditions
    internal class Lesson14_conditionss
    {
        public static void Run()
        {
            // ===== TOPIC: IF/ELSE/ELSE IF STATEMENTS =====
            // Conditional statements allow your program to execute different code based on conditions
            // Syntax: if (condition) { code } else if (condition) { code } else { code }

            int age;
            Console.Write("Enter your age: ");
            age = Convert.ToInt32(Console.ReadLine());

            // Check age category with multiple conditions
            if (age >= 65)
            {
                Console.WriteLine("You are a senior citizen.");
                Console.WriteLine("Special discount available!");
            }
            else if (age >= 18)
            {
                Console.WriteLine("You are an adult.");
                Console.WriteLine("Want to join the club?");
            }
            else if (age >= 13)
            {
                Console.WriteLine("You are a teenager.");
                Console.WriteLine("Teen programs are available for you.");
            }
            else if (age >= 0)
            {
                int yearsRemaining = 18 - age;
                Console.WriteLine("You are a minor.");
                Console.WriteLine("Come back when you are older. After " + yearsRemaining + " years.");

                // TIP: String interpolation ($"") is faster and more readable than concatenation (+)
                // Better: Console.WriteLine($"Come back when you are older. After {yearsRemaining} years.");
            }
            else
            {
                Console.WriteLine("Invalid age entered.");
            }

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            // TIP 1: ORDER MATTERS FOR PERFORMANCE
            // Put the most likely conditions first to avoid unnecessary checks
            // The CPU can predict branches better when common cases come first

            // TIP 2: ELSE IF vs MULTIPLE IFs
            // INEFFICIENT - ALL conditions are checked even when first is true:
            // if (age >= 18) { /* adult */ }
            // if (age >= 13) { /* teen - STILL CHECKED! */ }
            // if (age >= 0)  { /* child - STILL CHECKED! */ }

            // EFFICIENT - Stops checking after first match:
            // if (age >= 18) { /* adult */ }
            // else if (age >= 13) { /* teen - SKIPPED if age >= 18 */ }
            // else if (age >= 0)  { /* child - SKIPPED if previous matched */ }

            // TIP 3: AVOID COMPLEX CALCULATIONS IN CONDITIONS
            // GAME DEV TIP: Don't calculate inside if statements repeatedly
            // INEFFICIENT:
            // if (player.health / player.maxHealth < 0.25f) { /* low health */ }
            // if (player.health / player.maxHealth < 0.5f)  { /* medium health */ }

            // EFFICIENT - Calculate once, reuse:
            // float healthPercent = player.health / player.maxHealth;
            // if (healthPercent < 0.25f) { /* low health */ }
            // else if (healthPercent < 0.5f) { /* medium health */ }

            // TIP 4: MULTIPLICATION IS FASTER THAN DIVISION
            // If possible, use multiplication instead of division
            // SLOWER:  if (value / 2 > 10) { }
            // FASTER:  if (value * 0.5f > 10) { } or if (value > 20) { }

            // TIP 5: COMPARISON OPERATORS PERFORMANCE
            // ==, !=, <, >, <=, >= are very fast (single CPU instruction)
            // Use them freely, but avoid unnecessary complexity

            // TIP 6: EARLY RETURN PATTERN
            // In functions, return early to avoid nested conditions
            // This makes code more readable and can be faster
        }
    }
}