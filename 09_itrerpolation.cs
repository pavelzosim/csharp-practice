using System;

namespace CSLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = 40;
            string name = "John";

            Console.WriteLine("Name: " + name + ", Age: " + age); // String concatenation
            Console.WriteLine($"Name: {name}, Age: {age}"); // String interpolation
        }
    }
}