using System;

namespace csharp_learn.Lessons
{
    // LESSON 16: Method Overloading
    // Learn how to create multiple functions with the same name but different parameters
    internal class Lesson16_method_overloading
    {
        public static void Run()
        {
            // ===== TOPIC: METHOD OVERLOADING =====
            // Method Overloading = Multiple functions with the SAME NAME but DIFFERENT PARAMETERS
            // The compiler automatically chooses the correct version based on arguments

            Console.WriteLine("=== METHOD OVERLOADING ===\n");

            // ===== WHY USE METHOD OVERLOADING? =====

            Console.WriteLine("=== WHY METHOD OVERLOADING? ===\n");

            // WITHOUT overloading - need different names for each type:
            // void PrintInt(int x) { }
            // void PrintFloat(float x) { }
            // void PrintString(string x) { }
            // ❌ Confusing! Hard to remember!

            // WITH overloading - same name for similar operations:
            // void Print(int x) { }
            // void Print(float x) { }
            // void Print(string x) { }
            // ✅ Clean! Intuitive! Easy to use!

            Console.WriteLine("Overloading makes code cleaner and more intuitive");
            Console.WriteLine("One name for similar operations on different types\n");

            // ===== OVERLOADING BY TYPE =====

            Console.WriteLine("=== OVERLOADING BY TYPE ===\n");

            // Same function name, different parameter types
            // Compiler chooses based on argument type

            Print(42);              // Calls Print(int)
            Print(3.14f);           // Calls Print(float)
            Print("Hello");         // Calls Print(string)
            Print(true);            // Calls Print(bool)

            Console.WriteLine();

            // ===== OVERLOADING BY PARAMETER COUNT =====

            Console.WriteLine("=== OVERLOADING BY PARAMETER COUNT ===\n");

            // Same function name, different number of parameters

            int sum1 = Add(5, 10);              // Calls Add(int, int)
            int sum2 = Add(5, 10, 15);          // Calls Add(int, int, int)
            int sum3 = Add(5, 10, 15, 20);      // Calls Add(int, int, int, int)

            Console.WriteLine($"Add(5, 10) = {sum1}");
            Console.WriteLine($"Add(5, 10, 15) = {sum2}");
            Console.WriteLine($"Add(5, 10, 15, 20) = {sum3}");

            Console.WriteLine();

            // ===== OVERLOADING WITH DIFFERENT TYPES AND COUNTS =====

            Console.WriteLine("=== MIXED OVERLOADING ===\n");

            // Combine different types AND different counts

            Console.WriteLine($"Max(10, 20) = {Max(10, 20)}");                    // 2 ints
            Console.WriteLine($"Max(1.5f, 2.8f) = {Max(1.5f, 2.8f)}");           // 2 floats
            Console.WriteLine($"Max(5, 10, 15) = {Max(5, 10, 15)}");             // 3 ints
            Console.WriteLine($"Max(1.1f, 2.2f, 3.3f) = {Max(1.1f, 2.2f, 3.3f)}"); // 3 floats

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: SWAP =====

            Console.WriteLine("=== SWAP EXAMPLE ===\n");

            // Swap works with different types - same logical operation!

            int a = 100, b = 200;
            Console.WriteLine($"Before Swap: a = {a}, b = {b}");
            Swap(ref a, ref b);  // Calls Swap(ref int, ref int)
            Console.WriteLine($"After Swap: a = {a}, b = {b}");

            float x = 1.5f, y = 2.5f;
            Console.WriteLine($"\nBefore Swap: x = {x}, y = {y}");
            Swap(ref x, ref y);  // Calls Swap(ref float, ref float)
            Console.WriteLine($"After Swap: x = {x}, y = {y}");

            string str1 = "Hello", str2 = "World";
            Console.WriteLine($"\nBefore Swap: str1 = {str1}, str2 = {str2}");
            Swap(ref str1, ref str2);  // Calls Swap(ref string, ref string)
            Console.WriteLine($"After Swap: str1 = {str1}, str2 = {str2}");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: CALCULATE AREA =====

            Console.WriteLine("=== CALCULATE AREA ===\n");

            // Different shapes = different parameters
            // Same name (CalculateArea) = intuitive API

            double circleArea = CalculateArea(5.0);           // Circle (radius)
            double rectArea = CalculateArea(4.0, 6.0);        // Rectangle (width, height)
            double triangleArea = CalculateArea(3.0, 4.0, true); // Triangle (base, height)

            Console.WriteLine($"Circle area (r=5): {circleArea:F2}");
            Console.WriteLine($"Rectangle area (4x6): {rectArea:F2}");
            Console.WriteLine($"Triangle area (base=3, height=4): {triangleArea:F2}");

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: APPLY DAMAGE =====

            Console.WriteLine("=== GAME DEV: APPLY DAMAGE ===\n");

            // Different damage types - same function name!

            int health = 100;
            Console.WriteLine($"Initial health: {health}");

            health = ApplyDamage(health, 20);                    // Simple damage
            Console.WriteLine($"After 20 damage: {health}");

            health = ApplyDamage(health, 15, 0.5f);             // Damage with armor reduction
            Console.WriteLine($"After 15 damage (50% armor): {health}");

            health = ApplyDamage(health, 10, 0.3f, true);       // Critical hit with armor
            Console.WriteLine($"After critical 10 damage: {health}");

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: SPAWN ENEMY =====

            Console.WriteLine("=== GAME DEV: SPAWN ENEMY ===\n");

            // Different spawn methods - same function name!

            SpawnEnemy("Goblin");                           // Default position
            SpawnEnemy("Orc", 10.5f, 20.3f);               // Custom position
            SpawnEnemy("Dragon", 50.0f, 100.0f, 5);        // Position + level

            Console.WriteLine();

            // ===== OVERLOADING WITH DEFAULT VALUES =====

            Console.WriteLine("=== OVERLOADING vs DEFAULT PARAMETERS ===\n");

            // You can achieve similar results with default parameters
            // But overloading gives more control and clarity

            // Method 1: Overloading (what we've been doing)
            CreatePlayer("Hero");
            CreatePlayer("Warrior", 100);
            CreatePlayer("Mage", 80, 50);

            Console.WriteLine();

            // Method 2: Default parameters (alternative approach)
            CreateCharacter("Rogue");                      // Uses defaults
            CreateCharacter("Tank", 150);                  // Custom health
            CreateCharacter("Healer", 90, 100);           // Custom health + mana

            Console.WriteLine();

            // ===== OVERLOADING RULES =====

            Console.WriteLine("=== OVERLOADING RULES ===\n");

            // ✅ VALID OVERLOADING:
            // - Different parameter TYPES
            // - Different parameter COUNT
            // - Different parameter ORDER (not recommended)

            // ❌ INVALID OVERLOADING:
            // - Only return type differs (compiler error!)
            // - Parameter names differ (not enough!)

            // VALID:
            // void Test(int x) { }
            // void Test(float x) { }  ✅ Different type

            // VALID:
            // void Test(int x) { }
            // void Test(int x, int y) { }  ✅ Different count

            // INVALID:
            // int Test(int x) { return x; }
            // float Test(int x) { return x; }  ❌ Same signature!

            // INVALID:
            // void Test(int value) { }
            // void Test(int number) { }  ❌ Same signature!

            Console.WriteLine("✅ Valid: Different type, count, or order");
            Console.WriteLine("❌ Invalid: Only return type or parameter names differ");

            Console.WriteLine();

            // ===== COMMON OVERLOADING PATTERNS =====

            Console.WriteLine("=== COMMON PATTERNS ===\n");

            // Pattern 1: Parse/TryParse for different types
            int intValue;
            float floatValue;
            bool boolValue;

            if (Parse("42", out intValue))
                Console.WriteLine($"Parsed int: {intValue}");

            if (Parse("3.14", out floatValue))
                Console.WriteLine($"Parsed float: {floatValue}");

            if (Parse("true", out boolValue))
                Console.WriteLine($"Parsed bool: {boolValue}");

            Console.WriteLine();

            // Pattern 2: GetMinMax for different array types
            int[] intArray = { 5, 2, 8, 1, 9 };
            int minInt, maxInt;
            GetMinMax(intArray, out minInt, out maxInt);
            Console.WriteLine($"Int array min: {minInt}, max: {maxInt}");

            float[] floatArray = { 5.5f, 2.2f, 8.8f, 1.1f };
            float minFloat, maxFloat;
            GetMinMax(floatArray, out minFloat, out maxFloat);
            Console.WriteLine($"Float array min: {minFloat:F1}, max: {maxFloat:F1}");

            Console.WriteLine();

            // Pattern 3: Clamp values to range
            int clampedInt = 150;
            Clamp(ref clampedInt, 0, 100);
            Console.WriteLine($"Clamped int: {clampedInt}");

            float clampedFloat = -5.5f;
            Clamp(ref clampedFloat, 0.0f, 10.0f);
            Console.WriteLine($"Clamped float: {clampedFloat}");

            Console.WriteLine();

            // ===== REAL-WORLD EXAMPLE: LOGGER =====

            Console.WriteLine("=== LOGGER EXAMPLE ===\n");

            // Logging system with overloading - clean and flexible!

            Log("Application started");                          // Simple message
            Log("Warning", "Low memory");                        // Level + message
            Log("Error", "Connection failed", 404);              // Level + message + code
            Log("Debug", "User action", "Click", "Button1");    // Full details

            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use overloading for similar operations on different types");
            Console.WriteLine("• Keep function names consistent and meaningful");
            Console.WriteLine("• Make overloaded functions behave similarly");
            Console.WriteLine("• Use for constructors, Print, Parse, Calculate, etc.");
            Console.WriteLine("• Document each overload clearly");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't overload if functions do completely different things");
            Console.WriteLine("• Don't create too many overloads (confusing)");
            Console.WriteLine("• Don't rely only on parameter order (error-prone)");
            Console.WriteLine("• Don't mix overloading with optional parameters excessively");

            Console.WriteLine();

            // ===== PERFORMANCE NOTES =====

            Console.WriteLine("=== PERFORMANCE ===\n");

            Console.WriteLine("⚡ Performance facts:");
            Console.WriteLine("• Overloading has ZERO runtime cost");
            Console.WriteLine("• Compiler resolves at compile-time (not runtime)");
            Console.WriteLine("• Each overload is a separate function in IL code");
            Console.WriteLine("• No virtual dispatch or reflection involved");
            Console.WriteLine("• Perfect for game dev - no overhead!");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Method Overloading allows:");
            Console.WriteLine("• Same function name, different parameters");
            Console.WriteLine("• Cleaner, more intuitive API");
            Console.WriteLine("• Type-safe operations on multiple types");
            Console.WriteLine("• Flexible parameter combinations");
            Console.WriteLine("• Zero runtime performance cost");

            Console.WriteLine("\n🎯 When to use:");
            Console.WriteLine("• Print/Log functions for different types");
            Console.WriteLine("• Parse/Convert operations");
            Console.WriteLine("• Math operations (Add, Max, Min, Clamp)");
            Console.WriteLine("• Game functions (Spawn, Damage, Move)");
            Console.WriteLine("• Constructors with different initialization");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• Spawn(name) / Spawn(name, x, y) / Spawn(name, x, y, level)");
            Console.WriteLine("• Damage(amount) / Damage(amount, type) / Damage(amount, type, critical)");
            Console.WriteLine("• Play(sound) / Play(sound, volume) / Play(sound, volume, pitch)");
            Console.WriteLine("• Raycast(origin, dir) / Raycast(origin, dir, distance) / Raycast(origin, dir, distance, layerMask)");
        }

        // ===== OVERLOADING BY TYPE =====

        // Print different types - same function name!
        static void Print(int value)
        {
            Console.WriteLine($"[INT] {value}");
        }

        static void Print(float value)
        {
            Console.WriteLine($"[FLOAT] {value:F2}");
        }

        static void Print(string value)
        {
            Console.WriteLine($"[STRING] {value}");
        }

        static void Print(bool value)
        {
            Console.WriteLine($"[BOOL] {value}");
        }

        // ===== OVERLOADING BY PARAMETER COUNT =====

        // Add 2 numbers
        static int Add(int a, int b)
        {
            return a + b;
        }

        // Add 3 numbers (OVERLOAD)
        static int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Add 4 numbers (OVERLOAD)
        static int Add(int a, int b, int c, int d)
        {
            return a + b + c + d;
        }

        // ===== OVERLOADING: MAX FUNCTION =====

        // Max of 2 integers
        static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        // Max of 2 floats (OVERLOAD - different type)
        static float Max(float a, float b)
        {
            return a > b ? a : b;
        }

        // Max of 3 integers (OVERLOAD - different count)
        static int Max(int a, int b, int c)
        {
            int max = a;
            if (b > max) max = b;
            if (c > max) max = c;
            return max;
        }

        // Max of 3 floats (OVERLOAD - different type AND count)
        static float Max(float a, float b, float c)
        {
            float max = a;
            if (b > max) max = b;
            if (c > max) max = c;
            return max;
        }

        // ===== OVERLOADING: SWAP =====

        // Swap integers
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // Swap floats (OVERLOAD)
        static void Swap(ref float a, ref float b)
        {
            float temp = a;
            a = b;
            b = temp;
        }

        // Swap strings (OVERLOAD)
        static void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        // ===== OVERLOADING: CALCULATE AREA =====

        // Circle area (1 parameter = radius)
        static double CalculateArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        // Rectangle area (2 parameters = width, height)
        static double CalculateArea(double width, double height)
        {
            return width * height;
        }

        // Triangle area (3 parameters = base, height, isTriangle flag)
        static double CalculateArea(double baseLength, double height, bool isTriangle)
        {
            if (isTriangle)
                return 0.5 * baseLength * height;
            return 0;
        }

        // ===== GAME DEV: APPLY DAMAGE =====

        // Simple damage
        static int ApplyDamage(int health, int damage)
        {
            health -= damage;
            return health < 0 ? 0 : health;
        }

        // Damage with armor reduction (OVERLOAD)
        static int ApplyDamage(int health, int damage, float armorReduction)
        {
            int finalDamage = (int)(damage * (1 - armorReduction));
            health -= finalDamage;
            return health < 0 ? 0 : health;
        }

        // Damage with armor and critical hit (OVERLOAD)
        static int ApplyDamage(int health, int damage, float armorReduction, bool isCritical)
        {
            int finalDamage = (int)(damage * (1 - armorReduction));
            if (isCritical)
                finalDamage *= 2;  // Double damage on crit

            health -= finalDamage;
            return health < 0 ? 0 : health;
        }

        // ===== GAME DEV: SPAWN ENEMY =====

        // Spawn at default position
        static void SpawnEnemy(string name)
        {
            Console.WriteLine($"Spawned {name} at default position (0, 0)");
        }

        // Spawn at custom position (OVERLOAD)
        static void SpawnEnemy(string name, float x, float y)
        {
            Console.WriteLine($"Spawned {name} at position ({x:F1}, {y:F1})");
        }

        // Spawn at custom position with level (OVERLOAD)
        static void SpawnEnemy(string name, float x, float y, int level)
        {
            Console.WriteLine($"Spawned {name} (Level {level}) at position ({x:F1}, {y:F1})");
        }

        // ===== OVERLOADING: CREATE PLAYER =====

        // Name only
        static void CreatePlayer(string name)
        {
            Console.WriteLine($"Created player: {name} (HP: 100, Mana: 50)");
        }

        // Name + health (OVERLOAD)
        static void CreatePlayer(string name, int health)
        {
            Console.WriteLine($"Created player: {name} (HP: {health}, Mana: 50)");
        }

        // Name + health + mana (OVERLOAD)
        static void CreatePlayer(string name, int health, int mana)
        {
            Console.WriteLine($"Created player: {name} (HP: {health}, Mana: {mana})");
        }

        // ===== DEFAULT PARAMETERS ALTERNATIVE =====

        // Alternative approach using default parameters
        static void CreateCharacter(string name, int health = 100, int mana = 50)
        {
            Console.WriteLine($"Created character: {name} (HP: {health}, Mana: {mana})");
        }

        // ===== OVERLOADING: PARSE =====

        // Parse to int
        static bool Parse(string text, out int result)
        {
            return int.TryParse(text, out result);
        }

        // Parse to float (OVERLOAD)
        static bool Parse(string text, out float result)
        {
            return float.TryParse(text, out result);
        }

        // Parse to bool (OVERLOAD)
        static bool Parse(string text, out bool result)
        {
            return bool.TryParse(text, out result);
        }

        // ===== OVERLOADING: GETMINMAX =====

        // Get min/max from int array
        static void GetMinMax(int[] array, out int min, out int max)
        {
            min = array[0];
            max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }
        }

        // Get min/max from float array (OVERLOAD)
        static void GetMinMax(float[] array, out float min, out float max)
        {
            min = array[0];
            max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }
        }

        // ===== OVERLOADING: CLAMP =====

        // Clamp int
        static void Clamp(ref int value, int min, int max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
        }

        // Clamp float (OVERLOAD)
        static void Clamp(ref float value, float min, float max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
        }

        // ===== OVERLOADING: LOGGER =====

        // Simple message
        static void Log(string message)
        {
            Console.WriteLine($"[INFO] {message}");
        }

        // Level + message (OVERLOAD)
        static void Log(string level, string message)
        {
            Console.WriteLine($"[{level}] {message}");
        }

        // Level + message + code (OVERLOAD)
        static void Log(string level, string message, int errorCode)
        {
            Console.WriteLine($"[{level}] {message} (Code: {errorCode})");
        }

        // Full details (OVERLOAD)
        static void Log(string level, string message, string action, string target)
        {
            Console.WriteLine($"[{level}] {message} - Action: {action}, Target: {target}");
        }
    }
}