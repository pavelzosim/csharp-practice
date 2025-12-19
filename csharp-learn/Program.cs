using System;
using System.Linq;
using System.Reflection;

namespace csharp_learn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var allTypes = Assembly.GetExecutingAssembly().GetTypes();

            // Filter only classes that have a public static Run() method
            var runnableTypes = allTypes
                .Where(t => t.IsClass &&
                            t.GetMethod("Run", BindingFlags.Public | BindingFlags.Static) != null)
                .ToList();

            // Group by namespace
            var lessons = runnableTypes
                .Where(t => t.Namespace?.Contains("Lessons") == true)
                .OrderBy(t => t.Name)
                .ToList();

            var practice = runnableTypes
                .Where(t => t.Namespace?.Contains("Practice") == true)
                .OrderBy(t => t.Name)
                .ToList();

            var other = runnableTypes
                .Where(t => !(t.Namespace?.Contains("Lessons") == true || t.Namespace?.Contains("Practice") == true))
                .OrderBy(t => t.Name)
                .ToList();

            // Build combined list for indexing
            var indexedList = lessons.Concat(practice).Concat(other).ToList();

            Console.WriteLine("=== LESSONS ===");
            for (int i = 0; i < lessons.Count; i++)
                Console.WriteLine($"{i + 1}. {lessons[i].Name}");

            Console.WriteLine("\n=== PRACTICE ===");
            for (int i = 0; i < practice.Count; i++)
                Console.WriteLine($"{lessons.Count + i + 1}. {practice[i].Name}");

            if (other.Count > 0)
            {
                Console.WriteLine("\n=== OTHER ===");
                for (int i = 0; i < other.Count; i++)
                    Console.WriteLine($"{lessons.Count + practice.Count + i + 1}. {other[i].Name}");
            }

            Console.WriteLine("\nEnter the number to run:");
            if (int.TryParse(Console.ReadLine(), out int choice) &&
                choice > 0 && choice <= indexedList.Count)
            {
                var selectedType = indexedList[choice - 1];
                var runMethod = selectedType.GetMethod("Run", BindingFlags.Public | BindingFlags.Static);
                runMethod?.Invoke(null, null);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
