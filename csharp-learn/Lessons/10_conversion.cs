using System;

namespace csharp_learn
{
    internal class Lesson10
    {
        public static void Run()
        {
            string input = "15";
            int age;

            // !!! Conversion is often required when working with user input (strings) and numeric types.
            // Convert.ToInt32(string) will parse the string into an integer.
            // For a clean experiment, you can change the input value or comment out lines
            // to test different conversions separately.

            age = Convert.ToInt32(input);   // Converting string "15" to int
            Console.WriteLine(age);         // Prints 15

            // Other useful conversions:
            double pi = Convert.ToDouble("3.14");   // string → double
            bool flag = Convert.ToBoolean("true");  // string → bool

            Console.WriteLine(pi);   // Prints 3.14
            Console.WriteLine(flag); // Prints True
        }
    }
}
