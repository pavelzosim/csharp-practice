using System;
using System.Text;

namespace csharp_learn
{
    // LESSON 11: Console Input and Output
    // Learn how to read user input and display output in the console
    internal class Lesson11
    {
        public static void Run()
        {
            // ===== TOPIC: CONSOLE INPUT/OUTPUT =====

            // Set console encoding to support Unicode characters (Cyrillic, Chinese, etc.)
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // ===== CONSOLE OUTPUT METHODS =====

            // Console.Write() - Prints text WITHOUT newline
            Console.Write("Enter your name: ");

            // Console.WriteLine() - Prints text WITH newline at the end
            // Console.WriteLine("This moves to next line");

            // ===== CONSOLE INPUT METHODS =====

            // Console.ReadLine() - Reads entire line of text (until Enter pressed)
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");

            // Reading and converting numeric input
            int age;
            Console.Write("Enter your age: ");
            age = Convert.ToInt32(Console.ReadLine());  // Convert string to integer
            Console.WriteLine($"You are {age} years old.");

            // Console.ReadKey() - Reads single key press (doesn't show in console by default)
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();  // Waits for key press before continuing

            // ===== SAFER INPUT WITH VALIDATION =====

            Console.Write("\nEnter a number (with validation): ");
            if (int.TryParse(Console.ReadLine(), out int validatedAge))
            {
                Console.WriteLine($"Valid input: {validatedAge}");
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            // TIP 1: ALWAYS VALIDATE USER INPUT
            // Users can enter ANYTHING - always use TryParse, not Convert
            // UNSAFE:
            // int age = Convert.ToInt32(Console.ReadLine()); // Crashes on "abc"

            // SAFE:
            // if (int.TryParse(Console.ReadLine(), out int age)) { /* use age */ }

            // TIP 2: CONSOLE I/O IS SLOW
            // Reading from console is VERY slow (~1000x slower than memory access)
            // GAME DEV: Don't use Console.ReadLine() in game loops!
            // Use for: Menu systems, debug commands, tools
            // Avoid for: Per-frame operations, real-time input

            // TIP 3: UNICODE ENCODING
            // Set encoding ONCE at program start for international characters
            // Without it, Cyrillic/Chinese characters show as ???

            // TIP 4: CONSOLE.READKEY OPTIONS
            // Console.ReadKey(true);  // Hides key press (doesn't display)
            // Console.ReadKey(false); // Shows key press (default)
            // Good for: "Press any key to continue", password input

            // TIP 5: CONSOLE COLORS FOR BETTER UX
            // Console.ForegroundColor = ConsoleColor.Green;
            // Console.WriteLine("Success message");
            // Console.ResetColor(); // Reset to default

            Console.WriteLine("\n⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• Console I/O is SLOW - don't use in game loops");
            Console.WriteLine("• Use for menus, debug tools, setup - not real-time");
            Console.WriteLine("• TryParse is faster and safer than Convert");

            Console.WriteLine("\n✅ BEST PRACTICES:");
            Console.WriteLine("• ALWAYS validate user input with TryParse");
            Console.WriteLine("• Set Unicode encoding at program start");
            Console.WriteLine("• Use Console.Write for prompts (no newline)");
            Console.WriteLine("• Use Console.WriteLine for messages (with newline)");
            Console.WriteLine("• ReadKey() for pause/continue functionality");
        }
    }
}