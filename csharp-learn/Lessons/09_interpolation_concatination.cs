using System;

namespace csharp_learn
{
    // LESSON 09: String Interpolation and Concatenation
    // Learn two different ways to build text output: concatenation (+) and interpolation ($"")
    internal class Lesson09
    {
        public static void Run()
        {
            // ===== TOPIC: STRING CONCATENATION vs INTERPOLATION =====

            int age = 40;
            string name = "Pavel";
            double salary = 1234.567;
            DateTime today = DateTime.Now;

            // ===== METHOD 1: STRING CONCATENATION (Using + operator) =====

            // Basic concatenation - joining strings with + operator
            Console.WriteLine("Name: " + name + ", Age: " + age);

            // Number formatting with concatenation
            Console.WriteLine("Salary: " + salary.ToString("N2"));     // Requires explicit .ToString()

            // Date formatting with concatenation
            Console.WriteLine("Today: " + today.ToString("yyyy-MM-dd"));

            // ===== METHOD 2: STRING INTERPOLATION (Using $"" syntax) ★ RECOMMENDED =====

            // Basic interpolation - cleaner and more readable
            Console.WriteLine($"Name: {name}, Age: {age}");

            // Expressions inside interpolation - you can do calculations!
            Console.WriteLine($"Next year Age: {age + 1}");

            // Number formatting with interpolation - shorter syntax
            Console.WriteLine($"Salary: {salary:N2}");                 // Format directly inside {}

            // Date formatting with interpolation
            Console.WriteLine($"Today: {today:yyyy-MM-dd}");

            // Multi-line interpolation with @ symbol
            Console.WriteLine($@"User info:
Name = {name}
Age = {age}
Salary = {salary:N0}
Date = {today:dddd, MMMM dd}");

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            // TIP 1: INTERPOLATION vs CONCATENATION PERFORMANCE
            // For simple cases (1-3 strings), both are similar in speed
            // String interpolation is MORE READABLE and less error-prone

            // TIP 2: AVOID CONCATENATION IN LOOPS - CRITICAL!
            // INEFFICIENT - Creates new string object every iteration:
            // string result = "";
            // for (int i = 0; i < 1000; i++) {
            //     result = result + i.ToString(); // VERY SLOW!
            // }

            // EFFICIENT - Use StringBuilder for loops (10-100x faster):
            // StringBuilder sb = new StringBuilder();
            // for (int i = 0; i < 1000; i++) {
            //     sb.Append(i);
            // }
            // string result = sb.ToString();

            // TIP 3: STRING IMMUTABILITY
            // Strings are IMMUTABLE - every modification creates a NEW object
            // This is why concatenation in loops is slow (creates many objects)

            // TIP 4: COMMON FORMAT SPECIFIERS
            // {value:N2}  - Number with 2 decimal places and thousand separators: 1,234.57
            // {value:C}   - Currency: $1,234.57
            // {value:P}   - Percentage: 12.34%
            // {value:F2}  - Fixed-point with 2 decimals: 1234.57
            // {date:yyyy-MM-dd} - Date format: 2025-11-25

            Console.WriteLine("\n⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• Use interpolation ($\"\") for readability");
            Console.WriteLine("• NEVER use + or $\"\" in loops - use StringBuilder!");
            Console.WriteLine("• String concatenation in loops = 10-100x slower");

            Console.WriteLine("\n✅ BEST PRACTICES:");
            Console.WriteLine("• Prefer string interpolation over concatenation");
            Console.WriteLine("• Use StringBuilder for multiple operations or loops");
            Console.WriteLine("• Strings are immutable - each change creates new object");
        }
    }
}