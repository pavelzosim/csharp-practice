using System;

namespace csharp_learn
{
    internal class Lesson09
    {
        public static void Run()
        {
            int age = 40;
            string name = "Pavel";
            double salary = 1234.567;
            DateTime today = DateTime.Now;

            // !!! String concatenation and string interpolation are two different ways to build text output.
            // Concatenation is simple but less readable for complex cases.
            // Interpolation is more powerful: supports formatting, expressions, and multi-line strings.

            // For a clean experiment, comment out some lines below
            // to see the difference between concatenation and interpolation separately.

            // 1. Basic concatenation
            Console.WriteLine("Name: " + name + ", Age: " + age);

            // 2. Basic interpolation
            Console.WriteLine($"Name: {name}, Age: {age}");

            // 3. Expressions inside interpolation
            Console.WriteLine($"Next year Age: {age + 1}");

            // 4. Number formatting
            Console.WriteLine("Salary: " + salary.ToString("N2"));     // Concatenation with ToString
            Console.WriteLine($"Salary: {salary:N2}");                 // Interpolation with format

            // 5. Date formatting
            Console.WriteLine("Today: " + today.ToString("yyyy-MM-dd"));
            Console.WriteLine($"Today: {today:yyyy-MM-dd}");

            // 6. Multi-line interpolation
            Console.WriteLine($@"User info:
Name = {name}
Age = {age}
Salary = {salary:N0}
Date = {today:dddd, MMMM dd}");
        }
    }
}
