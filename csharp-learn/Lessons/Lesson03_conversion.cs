using System;

namespace csharp_learn
{
    // LESSON 03: Type Conversion
    // Learn how to convert between different data types (strings to numbers, etc.)
    internal class Lesson03_conversion
    {
        public static void Run()
        {
            // ===== TOPIC: TYPE CONVERSION =====
            // Conversion is required when working with user input (strings) and numeric types

            string input = "15";
            int age;

            // Convert.ToInt32() - Parse string to integer
            age = Convert.ToInt32(input);   // Converting string "15" to int 15
            Console.WriteLine($"Converted age: {age}");

            // ===== COMMON CONVERSION METHODS =====

            // String to numeric types
            double pi = Convert.ToDouble("3.14");       // string → double
            float velocity = Convert.ToSingle("9.8");   // string → float
            decimal price = Convert.ToDecimal("19.99"); // string → decimal
            long timestamp = Convert.ToInt64("999999"); // string → long

            // String to other types
            bool flag = Convert.ToBoolean("true");      // string → bool
            char letter = Convert.ToChar("A");          // string → char (first character)

            Console.WriteLine($"double: {pi}");
            Console.WriteLine($"float: {velocity}");
            Console.WriteLine($"bool: {flag}");

            // ===== IMPLICIT vs EXPLICIT CONVERSION =====

            // IMPLICIT conversion (automatic, safe - no data loss)
            int smallNumber = 100;
            long bigNumber = smallNumber;       // int → long (automatic)
            double preciseNumber = smallNumber; // int → double (automatic)

            // EXPLICIT conversion (cast - potential data loss!)
            double piValue = 3.14159;
            int piInt = (int)piValue;           // double → int = 3 (fractional part lost!)

            Console.WriteLine($"\nImplicit: int {smallNumber} → long {bigNumber} (safe)");
            Console.WriteLine($"Explicit: double {piValue} → int {piInt} (data loss!)");

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            // TIP 1: USE TryParse FOR USER INPUT - SAFER!
            // Convert.ToInt32() throws EXCEPTION on invalid input - can crash program
            // int.TryParse() returns true/false - safer and faster

            // INEFFICIENT - Can crash if user enters "abc":
            // int userAge = Convert.ToInt32(Console.ReadLine());

            // EFFICIENT - Handles invalid input gracefully:
            Console.Write("\nEnter a number: ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int result))
            {
                Console.WriteLine($"Valid number: {result}");
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }

            // TIP 2: PERFORMANCE - TryParse vs Convert
            // int.TryParse() is FASTER than Convert.ToInt32() (no exceptions)
            // Use TryParse for user input, Convert for trusted data

            // TIP 3: AVOID UNNECESSARY CONVERSIONS
            // Don't convert back and forth - plan your data types
            // INEFFICIENT: int x = Convert.ToInt32(Convert.ToDouble("10"));
            // EFFICIENT: int x = Convert.ToInt32("10");

            // TIP 4: CASTING PERFORMANCE
            // Casting (explicit conversion) is very fast (compile-time operation)
            // Example: (int)floatValue is just a bit truncation

            Console.WriteLine("\n⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• Use TryParse for user input (safer & faster)");
            Console.WriteLine("• Convert.ToX() for trusted data");
            Console.WriteLine("• Casting (type)value is fastest for compatible types");

            Console.WriteLine("\n✅ BEST PRACTICES:");
            Console.WriteLine("• ALWAYS validate user input with TryParse");
            Console.WriteLine("• Use appropriate type from the start - avoid conversions");
            Console.WriteLine("• Watch for data loss in explicit conversions");
            Console.WriteLine("• TryParse is faster and safer than Convert for parsing");
        }
    }
}