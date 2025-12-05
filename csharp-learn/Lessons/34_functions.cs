using System;

namespace csharp_learn
{
    // LESSON 34: Functions (Methods)
    // Learn how to organize code into reusable blocks with parameters and return values
    internal class Lesson34_functions
    {
        public static void Run()
        {
            // ===== TOPIC: FUNCTIONS (METHODS) =====
            // Function = reusable block of code that performs specific task
            // Also called "methods" in C#
            // Benefits: Code reuse, organization, readability, easier debugging

            Console.WriteLine("=== FUNCTION BASICS ===\n");

            // ===== CALLING FUNCTIONS =====

            // Function with no parameters
            SayHello();

            // Function with parameters
            Greet("Alice");
            Greet("Bob");

            // Function with multiple parameters
            DisplayInfo("Charlie", 25);

            Console.WriteLine();

            // ===== FUNCTIONS WITH RETURN VALUES =====

            Console.WriteLine("=== FUNCTIONS WITH RETURN VALUES ===\n");

            // Function returns value - capture in variable
            int result = Sum(10, 20);
            Console.WriteLine($"Sum(10, 20) = {result}");

            // Or use directly
            Console.WriteLine($"Sum(5, 15) = {Sum(5, 15)}");

            // Function with calculations
            double avg = CalculateAverage(80, 90, 75);
            Console.WriteLine($"Average of 80, 90, 75 = {avg:F2}");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLES =====

            Console.WriteLine("=== PRACTICAL EXAMPLES ===\n");

            // Error messages with colors
            WriteError("File not found!");
            WriteWarning("Low disk space.");
            WriteSuccess("Operation completed successfully.");

            Console.WriteLine();

            // Math operations
            int max = FindMax(42, 17);
            Console.WriteLine($"Max of 42 and 17: {max}");

            int min = FindMin(42, 17);
            Console.WriteLine($"Min of 42 and 17: {min}");

            // Check if number is even
            bool isEven = IsEven(10);
            Console.WriteLine($"Is 10 even? {isEven}");

            Console.WriteLine();

            // ===== FUNCTION OVERLOADING =====

            Console.WriteLine("=== FUNCTION OVERLOADING ===\n");

            // Same function name, different parameters
            int sum2 = Add(5, 10);
            double sum3 = Add(5.5, 10.3);
            int sum4 = Add(1, 2, 3);

            Console.WriteLine($"Add(5, 10) = {sum2}");
            Console.WriteLine($"Add(5.5, 10.3) = {sum3}");
            Console.WriteLine($"Add(1, 2, 3) = {sum4}");

            Console.WriteLine();

            // ===== OPTIONAL PARAMETERS (DEFAULT VALUES) =====

            Console.WriteLine("=== OPTIONAL PARAMETERS (DEFAULT VALUES) ===\n");

            // Optional parameters allow calling function without specifying all arguments
            // Default values are used when argument is not provided

            // Example 1: Simple optional parameter
            PrintMessage("Hello");                  // Uses default prefix "LOG"
            PrintMessage("Hello", "INFO");          // Custom prefix "INFO"
            PrintMessage("Error occurred", "ERROR"); // Custom prefix "ERROR"

            Console.WriteLine();

            // Example 2: Multiple optional parameters
            DrawBox("Welcome");                     // Default width (20)
            DrawBox("Welcome", 30);                 // Custom width (30)
            DrawBox("Game Over", 40);               // Custom width (40)

            Console.WriteLine();

            // Example 3: Game dev - spawn enemy with optional parameters
            SpawnEnemy("Goblin");                           // Default position (0, 0), default health (100)
            SpawnEnemy("Dragon", 50.0f, 30.0f);            // Custom position, default health
            SpawnEnemy("Boss", 100.0f, 50.0f, 500);        // All parameters specified

            Console.WriteLine();

            // Example 4: Calculate damage with optional armor and multiplier
            int damage1 = CalculateDamageWithDefaults(100);                    // No armor, no multiplier
            int damage2 = CalculateDamageWithDefaults(100, 25);               // With armor, no multiplier
            int damage3 = CalculateDamageWithDefaults(100, 25, 1.5f);         // With armor and multiplier

            Console.WriteLine($"Damage (no armor, no mult): {damage1}");
            Console.WriteLine($"Damage (with armor 25): {damage2}");
            Console.WriteLine($"Damage (armor 25, mult 1.5x): {damage3}");

            Console.WriteLine();

            // Example 5: Named arguments with optional parameters
            // You can specify parameters by name in any order
            Console.WriteLine("=== NAMED ARGUMENTS ===");
            CreatePlayer(name: "Hero", level: 5, health: 150);
            CreatePlayer(health: 200, name: "Warrior", level: 10);  // Different order
            CreatePlayer(name: "Mage");                              // Only name, rest use defaults

            Console.WriteLine();

            // Example 6: Mix required and optional parameters
            PrintPlayerStats("Knight", 10);                      // Required only
            PrintPlayerStats("Archer", 8, 120);                 // With optional health
            PrintPlayerStats("Wizard", 15, 80, 200);            // With health and mana

            Console.WriteLine();

            // Example 7: Boolean optional parameters (flags)
            SaveGame("save1.dat");                              // Don't overwrite
            SaveGame("save2.dat", overwrite: true);             // Overwrite if exists
            SaveGame("save3.dat", overwrite: true, compress: true);  // Overwrite and compress

            Console.WriteLine();

            // Example 8: Optional color parameter for console output
            PrintColored("This is default color");
            PrintColored("This is green", ConsoleColor.Green);
            PrintColored("This is red", ConsoleColor.Red);
            PrintColored("This is cyan", ConsoleColor.Cyan);

            Console.WriteLine();

            // ===== OUT PARAMETERS =====

            Console.WriteLine("=== OUT PARAMETERS ===\n");

            // Function returns multiple values via out
            int quotient, remainder;
            Divide(17, 5, out quotient, out remainder);
            Console.WriteLine($"17 / 5 = {quotient} remainder {remainder}");

            // Parse with TryParse pattern (uses out)
            string input = "123";
            if (TryParseInt(input, out int parsed))
            {
                Console.WriteLine($"Parsed: {parsed}");
            }
            else
            {
                Console.WriteLine("Failed to parse");
            }

            Console.WriteLine();

            // ===== REF PARAMETERS =====

            Console.WriteLine("=== REF PARAMETERS ===\n");

            // ref passes variable by reference (can modify original)
            int number = 10;
            Console.WriteLine($"Before: {number}");
            MultiplyByTwo(ref number);
            Console.WriteLine($"After: {number}");  // Changed!

            Console.WriteLine();

            // ===== GAME DEV EXAMPLES =====

            Console.WriteLine("=== GAME DEV EXAMPLES ===\n");

            // Calculate damage with critical hit
            int baseDamage = 50;
            bool critical = true;
            int totalDamage = CalculateDamage(baseDamage, critical);
            Console.WriteLine($"Damage: {totalDamage} (Critical: {critical})");

            // Check if player is in range
            float playerX = 10.5f, playerY = 5.2f;
            float enemyX = 12.0f, enemyY = 6.0f;
            bool inRange = IsInRange(playerX, playerY, enemyX, enemyY, 3.0f);
            Console.WriteLine($"Enemy in range: {inRange}");

            // Apply damage to health
            int health = 100;
            ApplyDamage(ref health, 25);
            Console.WriteLine($"Health after damage: {health}");

            Console.WriteLine();

            // ===== RECURSIVE FUNCTIONS =====

            Console.WriteLine("=== RECURSIVE FUNCTIONS ===\n");

            // Function calls itself
            int factorial = Factorial(5);
            Console.WriteLine($"Factorial of 5: {factorial}");

            int fib = Fibonacci(7);
            Console.WriteLine($"Fibonacci(7): {fib}");

            Console.WriteLine();

            // ===== PARAMS KEYWORD (VARIABLE ARGUMENTS) =====

            Console.WriteLine("=== PARAMS KEYWORD ===\n");

            // params allows passing variable number of arguments
            int sum5 = SumAll(1, 2, 3);
            int sum6 = SumAll(10, 20, 30, 40, 50);
            int sum7 = SumAll(5);  // Can pass just one

            Console.WriteLine($"SumAll(1, 2, 3) = {sum5}");
            Console.WriteLine($"SumAll(10, 20, 30, 40, 50) = {sum6}");
            Console.WriteLine($"SumAll(5) = {sum7}");

            Console.WriteLine();

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.WriteLine("=== OPTIONAL PARAMETERS BEST PRACTICES ===\n");

            // TIP 1: OPTIONAL PARAMETERS MUST BE LAST
            // CORRECT:
            // static void Func(int required, int optional = 10) { }

            // WRONG - Compiler error:
            // static void Func(int optional = 10, int required) { }

            // TIP 2: USE MEANINGFUL DEFAULTS
            // GOOD: static void SetVolume(float volume = 0.5f) { }  // 50% default
            // BAD: static void SetVolume(float volume = 0.0f) { }   // Confusing default

            // TIP 3: AVOID TOO MANY OPTIONAL PARAMETERS
            // Too many optional parameters = confusing
            // Consider using parameter object or builder pattern instead

            // TIP 4: NAMED ARGUMENTS FOR CLARITY
            // When many parameters, use named arguments
            // UNCLEAR: CreateEnemy(10, 20, 100, true, false, 5.0f);
            // CLEAR: CreateEnemy(x: 10, y: 20, health: 100, isHostile: true);

            // TIP 5: OPTIONAL PARAMETERS AND OVERLOADING
            // Can't have both optional parameter and overload with same signature
            // Choose one approach

            Console.WriteLine("⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• Small functions (<10 lines) may be inlined by compiler");
            Console.WriteLine("• Avoid recursion for performance-critical code (use loops)");
            Console.WriteLine("• Pass large structs by ref to avoid copying");
            Console.WriteLine("• Use out for multiple return values (no tuple allocation)");
            Console.WriteLine("• Static functions slightly faster (no 'this' pointer)");
            Console.WriteLine("• Optional parameters have NO runtime cost (resolved at compile-time)");

            Console.WriteLine("\n🚀 GAME DEV OPTIMIZATION:");
            Console.WriteLine("• Don't allocate in frequently called functions (Update)");
            Console.WriteLine("• Cache calculations in functions called every frame");
            Console.WriteLine("• Use ref for large structs (Vector3, Matrix)");
            Console.WriteLine("• Inline simple math functions (mark with [MethodImpl])");
            Console.WriteLine("• Avoid recursion in real-time code (stack overflow risk)");

            Console.WriteLine("\n✅ BEST PRACTICES SUMMARY:");
            Console.WriteLine("• Use descriptive, verb-based names");
            Console.WriteLine("• Keep functions small (one task, <20 lines)");
            Console.WriteLine("• Limit parameters to 3-4 maximum");
            Console.WriteLine("• Prefer return values over out parameters");
            Console.WriteLine("• Use early returns to reduce nesting");
            Console.WriteLine("• Document complex functions with comments");
            Console.WriteLine("• Avoid side effects (modifying global state)");
            Console.WriteLine("• Make functions pure when possible (same input = same output)");
            Console.WriteLine("• Use optional parameters for common default values");
            Console.WriteLine("• Optional parameters must come AFTER required parameters");

            Console.WriteLine("\n📋 FUNCTION SYNTAX:");
            Console.WriteLine("• No return: static void FunctionName(params) { }");
            Console.WriteLine("• With return: static Type FunctionName(params) { return value; }");
            Console.WriteLine("• Optional param: static void Func(int x = 10) { }");
            Console.WriteLine("• Multiple optional: static void Func(int x = 10, bool y = true) { }");
            Console.WriteLine("• Named arguments: Func(y: false, x: 20);");
            Console.WriteLine("• Out param: static void Func(out int result) { result = 5; }");
            Console.WriteLine("• Ref param: static void Func(ref int value) { value *= 2; }");
            Console.WriteLine("• Params: static int Sum(params int[] nums) { }");
            Console.WriteLine("• Overloading: Same name, different parameters");

            Console.WriteLine("\n🎮 GAME DEV USE CASES:");
            Console.WriteLine("• Spawn enemy: SpawnEnemy(type, x = 0, y = 0, health = 100)");
            Console.WriteLine("• Play sound: PlaySound(clip, volume = 1.0f, loop = false)");
            Console.WriteLine("• Create particle: CreateParticle(pos, color = white, size = 1.0f)");
            Console.WriteLine("• Load level: LoadLevel(index, transition = true, saveProgress = true)");
            Console.WriteLine("• Show message: ShowMessage(text, duration = 3.0f, color = white)");

            Console.WriteLine("\n❌ COMMON MISTAKES:");
            Console.WriteLine("• Forgetting to return a value in non-void function");
            Console.WriteLine("• Too many parameters (use objects instead)");
            Console.WriteLine("• Optional parameters before required ones (compiler error)");
            Console.WriteLine("• Modifying global state (side effects)");
            Console.WriteLine("• Not handling edge cases (divide by zero, null checks)");
            Console.WriteLine("• Deep recursion without base case (stack overflow)");
            Console.WriteLine("• Creating functions that do too many things");
            Console.WriteLine("• Poor naming (calc, func, temp)");
            Console.WriteLine("• Too many optional parameters (confusing)");
        }

        // ===== BASIC FUNCTIONS =====

        // Function with no parameters, no return value
        static void SayHello()
        {
            Console.WriteLine("Hello, World!");
        }

        // Function with one parameter, no return value
        static void Greet(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        // Function with multiple parameters
        static void DisplayInfo(string name, int age)
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }

        // ===== FUNCTIONS WITH RETURN VALUES =====

        // Function that returns integer
        static int Sum(int x, int y)
        {
            return x + y;  // return keyword sends value back
        }

        // Function that returns double
        static double CalculateAverage(int a, int b, int c)
        {
            return (a + b + c) / 3.0;
        }

        // Function that returns bool
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // ===== PRACTICAL UTILITY FUNCTIONS =====

        // Display error message in red
        static void WriteError(string text)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ ERROR: {text}");
            Console.ForegroundColor = defaultColor;
        }

        // Display warning in yellow
        static void WriteWarning(string text)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"⚠️  WARNING: {text}");
            Console.ForegroundColor = defaultColor;
        }

        // Display success in green
        static void WriteSuccess(string text)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✅ SUCCESS: {text}");
            Console.ForegroundColor = defaultColor;
        }

        // Find maximum of two numbers
        static int FindMax(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Find minimum of two numbers
        static int FindMin(int a, int b)
        {
            return (a < b) ? a : b;
        }

        // ===== FUNCTION OVERLOADING =====

        // Add two integers
        static int Add(int a, int b)
        {
            return a + b;
        }

        // Add two doubles (overload)
        static double Add(double a, double b)
        {
            return a + b;
        }

        // Add three integers (overload)
        static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // ===== OPTIONAL PARAMETERS (EXPANDED EXAMPLES) =====

        // Example 1: Simple optional parameter
        // prefix parameter has default value "LOG"
        // If not provided, "LOG" is used automatically
        static void PrintMessage(string message, string prefix = "LOG")
        {
            Console.WriteLine($"[{prefix}] {message}");
        }

        // Example 2: Multiple optional parameters
        // width has default value 20
        static void DrawBox(string text, int width = 20)
        {
            string border = new string('=', width);
            Console.WriteLine(border);
            Console.WriteLine(text.PadLeft((width + text.Length) / 2));
            Console.WriteLine(border);
        }

        // Example 3: Game dev - spawn enemy with optional position and health
        // Default position is (0, 0), default health is 100
        static void SpawnEnemy(string enemyType, float x = 0.0f, float y = 0.0f, int health = 100)
        {
            Console.WriteLine($"Spawned {enemyType} at ({x}, {y}) with {health} HP");
        }

        // Example 4: Calculate damage with optional armor and multiplier
        // armor defaults to 0 (no armor)
        // multiplier defaults to 1.0f (no multiplier)
        static int CalculateDamageWithDefaults(int baseDamage, int armor = 0, float multiplier = 1.0f)
        {
            int damageAfterArmor = baseDamage - armor;
            if (damageAfterArmor < 0) damageAfterArmor = 0;
            return (int)(damageAfterArmor * multiplier);
        }

        // Example 5: Create player with optional parameters
        // level defaults to 1, health defaults to 100
        static void CreatePlayer(string name, int level = 1, int health = 100)
        {
            Console.WriteLine($"Created player: {name}, Level: {level}, Health: {health}");
        }

        // Example 6: Print player stats with optional health and mana
        // health defaults to 100, mana defaults to 50
        static void PrintPlayerStats(string name, int level, int health = 100, int mana = 50)
        {
            Console.WriteLine($"{name} - Level: {level}, Health: {health}, Mana: {mana}");
        }

        // Example 7: Save game with optional flags
        // overwrite defaults to false
        // compress defaults to false
        static void SaveGame(string filename, bool overwrite = false, bool compress = false)
        {
            string mode = overwrite ? "Overwriting" : "Creating new";
            string compression = compress ? "with compression" : "without compression";
            Console.WriteLine($"{mode} save file '{filename}' {compression}");
        }

        // Example 8: Print colored text with optional color
        // color defaults to White
        static void PrintColored(string text, ConsoleColor color = ConsoleColor.White)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }

        // ===== OUT PARAMETERS =====

        // Return multiple values using out
        static void Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }

        // TryParse pattern (returns bool, value via out)
        static bool TryParseInt(string text, out int result)
        {
            return int.TryParse(text, out result);
        }

        // ===== REF PARAMETERS =====

        // Modify parameter passed by reference
        static void MultiplyByTwo(ref int value)
        {
            value *= 2;  // Modifies original variable
        }

        // Swap two values
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // ===== GAME DEV FUNCTIONS =====

        // Calculate damage with critical hit
        static int CalculateDamage(int baseDamage, bool isCritical)
        {
            if (isCritical)
            {
                return baseDamage * 2;  // Double damage on crit
            }
            return baseDamage;
        }

        // Check if two points are within range
        static bool IsInRange(float x1, float y1, float x2, float y2, float range)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);
            return distance <= range;
        }

        // Apply damage to health (modifies via ref)
        static void ApplyDamage(ref int health, int damage)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;  // Clamp to 0
            }
        }

        // ===== RECURSIVE FUNCTIONS =====

        // Factorial using recursion
        // 5! = 5 * 4 * 3 * 2 * 1 = 120
        static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;  // Base case
            }
            return n * Factorial(n - 1);  // Recursive call
        }

        // Fibonacci sequence
        // 0, 1, 1, 2, 3, 5, 8, 13, 21...
        static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return n;  // Base case
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);  // Recursive
        }

        // ===== PARAMS KEYWORD =====

        // Variable number of arguments
        static int SumAll(params int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }
    }
}