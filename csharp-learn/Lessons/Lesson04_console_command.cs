using System;
using System.Text;

namespace csharp_learn
{
    // LESSON 04: Console Input and Output
    // Learn how to read user input, display output, and control console appearance
    internal class Lesson04_console_command
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

            Console.WriteLine("\nPress any key to continue to advanced features...");
            Console.ReadKey();

            // ===== CONSOLE.CLEAR() - Clear Screen =====

            Console.Clear();  // Clears all text from console window

            Console.WriteLine("=== CONSOLE.CLEAR() DEMONSTRATION ===");
            Console.WriteLine("The screen was just cleared!");
            Console.WriteLine("All previous text is now gone.\n");

            // Use case: Clear screen between menu options, start fresh section
            Console.WriteLine("Press any key to see more examples...");
            Console.ReadKey();

            // ===== CONSOLE COLORS =====

            Console.Clear();
            Console.WriteLine("=== CONSOLE COLORS ===\n");

            // Change text color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Success message in green!");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Error message in red!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️  Warning message in yellow!");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ℹ️  Info message in cyan!");

            // Reset to default color
            Console.ResetColor();
            Console.WriteLine("Back to default color.\n");

            // Change background color
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("White text on dark blue background!");
            Console.ResetColor();

            Console.WriteLine("\nPress any key for cursor positioning demo...");
            Console.ReadKey();

            // ===== CONSOLE.SETCURSORPOSITION() - Position Control =====

            Console.Clear();
            Console.WriteLine("=== CONSOLE.SETCURSORPOSITION() DEMONSTRATION ===\n");

            // Console.SetCursorPosition(left, top)
            // left = column (X coordinate, 0-based)
            // top = row (Y coordinate, 0-based)

            // Draw at specific positions
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("This is at position (0, 2)");

            Console.SetCursorPosition(10, 4);
            Console.WriteLine("This is at position (10, 4)");

            Console.SetCursorPosition(20, 6);
            Console.WriteLine("This is at position (20, 6)");

            Console.SetCursorPosition(0, 8);
            Console.WriteLine("\nPress any key to see a box drawing...");
            Console.ReadKey();

            // ===== DRAWING SIMPLE BOX WITH CURSOR POSITIONING =====

            Console.Clear();
            Console.WriteLine("=== DRAWING BOX WITH CURSOR POSITIONING ===\n");

            int boxLeft = 10;
            int boxTop = 3;
            int boxWidth = 40;
            int boxHeight = 10;

            // Draw top border
            Console.SetCursorPosition(boxLeft, boxTop);
            Console.Write("╔" + new string('═', boxWidth - 2) + "╗");

            // Draw middle rows
            for (int i = 1; i < boxHeight - 1; i++)
            {
                Console.SetCursorPosition(boxLeft, boxTop + i);
                Console.Write("║" + new string(' ', boxWidth - 2) + "║");
            }

            // Draw bottom border
            Console.SetCursorPosition(boxLeft, boxTop + boxHeight - 1);
            Console.Write("╚" + new string('═', boxWidth - 2) + "╝");

            // Draw text inside box
            Console.SetCursorPosition(boxLeft + 8, boxTop + 3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("WELCOME TO THE GAME!");
            Console.ResetColor();

            Console.SetCursorPosition(boxLeft + 12, boxTop + 5);
            Console.Write("Press any key...");

            Console.SetCursorPosition(0, boxTop + boxHeight + 2);
            Console.ReadKey();

            // ===== LOADING BAR ANIMATION =====

            Console.Clear();
            Console.WriteLine("=== LOADING BAR ANIMATION ===\n");

            Console.SetCursorPosition(0, 3);
            Console.Write("Loading: [");
            int barLength = 30;
            int barLeft = 10;
            int barTop = 3;

            for (int i = 0; i <= barLength; i++)
            {
                Console.SetCursorPosition(barLeft + i, barTop);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("█");
                Console.ResetColor();

                // Show percentage
                Console.SetCursorPosition(barLeft + barLength + 2, barTop);
                Console.Write($"] {i * 100 / barLength}%");

                System.Threading.Thread.Sleep(50);  // Delay for animation
            }

            Console.SetCursorPosition(0, 5);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Loading complete!");
            Console.ResetColor();

            Console.WriteLine("\nPress any key for menu demo...");
            Console.ReadKey();

            // ===== INTERACTIVE MENU WITH CURSOR POSITIONING =====

            Console.Clear();
            Console.WriteLine("=== INTERACTIVE MENU (Use Arrow Keys, Enter to select) ===\n");

            string[] menuOptions = { "Start Game", "Load Game", "Settings", "Exit" };
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                // Draw menu options
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.SetCursorPosition(5, 3 + i * 2);

                    if (i == selectedIndex)
                    {
                        // Highlight selected option
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"► {menuOptions[i]}  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"  {menuOptions[i]}  ");
                    }
                }

                // Read key
                key = Console.ReadKey(true).Key;

                // Update selection
                if (key == ConsoleKey.UpArrow && selectedIndex > 0)
                {
                    selectedIndex--;
                }
                else if (key == ConsoleKey.DownArrow && selectedIndex < menuOptions.Length - 1)
                {
                    selectedIndex++;
                }

            } while (key != ConsoleKey.Enter);

            Console.SetCursorPosition(0, 3 + menuOptions.Length * 2 + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You selected: {menuOptions[selectedIndex]}");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to see cursor properties...");
            Console.ReadKey();

            // ===== CURSOR PROPERTIES =====

            Console.Clear();
            Console.WriteLine("=== CURSOR PROPERTIES ===\n");

            // Get current cursor position
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            Console.WriteLine($"Current cursor position: Left={currentLeft}, Top={currentTop}");

            // Cursor visibility
            Console.WriteLine("\nHiding cursor for 2 seconds...");
            Console.CursorVisible = false;
            System.Threading.Thread.Sleep(2000);
            Console.CursorVisible = true;
            Console.WriteLine("Cursor visible again!");

            // Window properties
            Console.WriteLine($"\nConsole window size: {Console.WindowWidth} x {Console.WindowHeight}");
            Console.WriteLine($"Buffer size: {Console.BufferWidth} x {Console.BufferHeight}");

            Console.WriteLine("\nPress any key for best practices...");
            Console.ReadKey();

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.Clear();
            Console.WriteLine("=== CONSOLE BEST PRACTICES & OPTIMIZATION ===\n");

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

            // TIP 3: SETCURSORPOSITION PERFORMANCE
            // SetCursorPosition is EXPENSIVE (~100x slower than Write)
            // INEFFICIENT - Sets position for every character:
            // for (int i = 0; i < 100; i++) {
            //     Console.SetCursorPosition(i, 0);
            //     Console.Write("X");  // SLOW - 100 position changes
            // }

            // EFFICIENT - Build string, set position once:
            // string line = new string('X', 100);
            // Console.SetCursorPosition(0, 0);
            // Console.Write(line);  // FAST - 1 position change

            // TIP 4: CLEAR SCREEN WISELY
            // Console.Clear() is slow - don't call every frame
            // Use for: Menu transitions, major screen changes
            // Avoid for: Updating small parts (use SetCursorPosition instead)

            // TIP 5: UNICODE ENCODING
            // Set encoding ONCE at program start for international characters
            // Without it, Cyrillic/Chinese/box-drawing characters show as ???

            // TIP 6: CONSOLE.READKEY OPTIONS
            // Console.ReadKey(true);  // Hides key press (doesn't display)
            // Console.ReadKey(false); // Shows key press (default)
            // Good for: "Press any key to continue", password input, menu navigation

            // TIP 7: CURSOR VISIBILITY
            // Hide cursor during animations or when not needed
            // Console.CursorVisible = false;  // Hide
            // Console.CursorVisible = true;   // Show

            // TIP 8: BUFFER VS WINDOW SIZE
            // Buffer can be larger than window (scrollable)
            // Window is what you see on screen
            // Changing buffer size can cause flickering

            Console.WriteLine("⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• Console I/O is SLOW - don't use in game loops");
            Console.WriteLine("• SetCursorPosition is expensive - minimize calls");
            Console.WriteLine("• Build strings first, then write once");
            Console.WriteLine("• Don't Clear() every frame - use selective updates");
            Console.WriteLine("• TryParse is faster and safer than Convert");

            Console.WriteLine("\n🚀 GAME DEV OPTIMIZATION:");
            Console.WriteLine("• Use Console for menus, NOT for game rendering");
            Console.WriteLine("• For games, use graphics libraries (Unity, MonoGame)");
            Console.WriteLine("• Console is great for: Debug tools, text adventures, menus");
            Console.WriteLine("• Avoid: High-frequency updates, real-time rendering");

            Console.WriteLine("\n✅ BEST PRACTICES SUMMARY:");
            Console.WriteLine("• ALWAYS validate user input with TryParse");
            Console.WriteLine("• Set Unicode encoding at program start");
            Console.WriteLine("• Use Console.Write for prompts (no newline)");
            Console.WriteLine("• Use Console.WriteLine for messages (with newline)");
            Console.WriteLine("• Use ReadKey(true) for menu navigation");
            Console.WriteLine("• Clear() for major transitions, SetCursorPosition for updates");
            Console.WriteLine("• Hide cursor during animations (CursorVisible = false)");
            Console.WriteLine("• Minimize SetCursorPosition calls - batch your writes");

            Console.WriteLine("\n📋 COMMON CONSOLE METHODS:");
            Console.WriteLine("• Console.Write() - Output without newline");
            Console.WriteLine("• Console.WriteLine() - Output with newline");
            Console.WriteLine("• Console.ReadLine() - Read string input");
            Console.WriteLine("• Console.ReadKey() - Read single key");
            Console.WriteLine("• Console.Clear() - Clear entire screen");
            Console.WriteLine("• Console.SetCursorPosition(x, y) - Move cursor");
            Console.WriteLine("• Console.ForegroundColor - Set text color");
            Console.WriteLine("• Console.BackgroundColor - Set background color");
            Console.WriteLine("• Console.ResetColor() - Reset to defaults");
            Console.WriteLine("• Console.CursorVisible - Show/hide cursor");

            Console.WriteLine("\n🎮 GAME DEV USE CASES:");
            Console.WriteLine("• Menu systems: SetCursorPosition + colors");
            Console.WriteLine("• Loading screens: Progress bars with SetCursorPosition");
            Console.WriteLine("• Text adventures: Clear() between scenes");
            Console.WriteLine("• Debug consoles: Colored output (errors in red)");
            Console.WriteLine("• Turn-based games: Update specific areas with cursor");

            Console.WriteLine("\n❌ COMMON MISTAKES:");
            Console.WriteLine("• Calling Clear() every frame (very slow)");
            Console.WriteLine("• SetCursorPosition in tight loops (expensive)");
            Console.WriteLine("• Not validating input (crashes on invalid data)");
            Console.WriteLine("• Forgetting ResetColor() (colors persist)");
            Console.WriteLine("• Not hiding cursor during animations");
            Console.WriteLine("• Using Console for real-time games (too slow)");

            Console.WriteLine("\n\n✅ Lesson 11 Complete! Press any key to exit...");
            Console.ReadKey();
        }
    }
}