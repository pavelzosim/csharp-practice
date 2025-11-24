using System;

namespace csharp_learn
{
    internal class Lesson09
    {
        static void Main(string[] args)
        {
            int age = 40;
            string name = "Pavel";

            Console.WriteLine("Name: " + name + ", Age: " + age); // String concatenation
            Console.WriteLine($"Name: {name}, Age: {age}"); // String interpolation
        }
    }
}