using System;

namespace csharp_learn
{
    // LESSON 37: Ref and Out Parameters
    // Learn how to pass variables by reference and return multiple values from functions
    internal class Lesson37_ref_out
    {
        public static void Run()
        {
            // ===== TOPIC: REF AND OUT PARAMETERS =====
            // ref and out allow functions to modify the original variable (pass by reference)
            // Difference: ref requires initialization, out doesn't (but must be assigned in function)

            Console.WriteLine("=== REF vs OUT PARAMETERS ===\n");

            // ===== REF PARAMETERS =====

            Console.WriteLine("=== REF PARAMETERS ===\n");

            // REF requires variable to be INITIALIZED before passing
            int sum = 0;  // MUST initialize before using ref
            int x = 10, y = 20;

            Add(ref sum, x, y);
            Console.WriteLine($"Sum after Add: {sum}");  // Output: 30

            // Modify existing value with ref
            int number = 5;
            Console.WriteLine($"Before MultiplyByTwo: {number}");
            MultiplyByTwo(ref number);
            Console.WriteLine($"After MultiplyByTwo: {number}");  // Output: 10

            // Swap two values using ref
            int a = 100, b = 200;
            Console.WriteLine($"Before swap: a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After swap: a = {a}, b = {b}");  // Swapped!

            Console.WriteLine();

            // ===== OUT PARAMETERS =====

            Console.WriteLine("=== OUT PARAMETERS ===\n");

            // OUT does NOT require initialization before passing
            // Function MUST assign value to out parameter
            int result;  // NOT initialized - OK with out!

            if (TryParse("123", out result))
            {
                Console.WriteLine($"Parsed successfully: {result}");
            }
            else
            {
                Console.WriteLine("Parse failed");
            }

            // Return multiple values using out
            int quotient, remainder;  // Not initialized
            Divide(17, 5, out quotient, out remainder);
            Console.WriteLine($"17 / 5 = {quotient} remainder {remainder}");

            // Get min and max from array using out
            int[] values = { 45, 12, 89, 23, 67, 5, 91 };
            int min, max;
            GetMinMax(values, out min, out max);
            Console.WriteLine($"Array min: {min}, max: {max}");

            Console.WriteLine();

            // ===== C# 7.0: INLINE OUT VARIABLE DECLARATION =====

            Console.WriteLine("=== INLINE OUT DECLARATION (C# 7.0) ===\n");

            // Can declare variable inline (C# 7.0+)
            if (TryParse("456", out int parsed))  // Declare 'parsed' inline
            {
                Console.WriteLine($"Parsed inline: {parsed}");
            }

            // Multiple out parameters inline
            Divide(25, 7, out int q, out int r);
            Console.WriteLine($"25 / 7 = {q} remainder {r}");

            Console.WriteLine();

            // ===== REF vs OUT COMPARISON =====

            Console.WriteLine("=== REF vs OUT COMPARISON ===\n");

            // REF: Modify existing value
            int health = 100;
            ApplyDamage(ref health, 25);
            Console.WriteLine($"Health after damage: {health}");

            // OUT: Get calculated value
            int totalDamage;
            CalculateDamage(50, 1.5f, out totalDamage);
            Console.WriteLine($"Total damage: {totalDamage}");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLES =====

            Console.WriteLine("=== PRACTICAL EXAMPLES ===\n");

            // Example 1: Update player position (ref)
            float playerX = 10.0f, playerY = 5.0f;
            Console.WriteLine($"Player position: ({playerX}, {playerY})");
            MovePlayer(ref playerX, ref playerY, 3.0f, 2.0f);
            Console.WriteLine($"After move: ({playerX}, {playerY})");

            Console.WriteLine();

            // Example 2: Get success status and result (out)
            int playerScore;
            bool success = TryGetHighScore("Player1", out playerScore);
            if (success)
            {
                Console.WriteLine($"High score: {playerScore}");
            }
            else
            {
                Console.WriteLine("Player not found");
            }

            Console.WriteLine();

            // Example 3: Parse input safely (out)
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            if (SafeParse(input, out int userNumber))
            {
                Console.WriteLine($"You entered: {userNumber}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }

            Console.WriteLine();

            // ===== GAME DEV EXAMPLES =====

            Console.WriteLine("=== GAME DEV EXAMPLES ===\n");

            // Example 1: Apply buff/debuff (ref)
            int attack = 50, defense = 30;
            Console.WriteLine($"Stats before buff: Attack = {attack}, Defense = {defense}");
            ApplyBuff(ref attack, ref defense, 1.2f);
            Console.WriteLine($"Stats after buff: Attack = {attack}, Defense = {defense}");

            Console.WriteLine();

            // Example 2: Raycast hit detection (out)
            float hitX, hitY;
            bool hit = Raycast(0, 0, 1, 1, 10.0f, out hitX, out hitY);
            if (hit)
            {
                Console.WriteLine($"Raycast hit at ({hitX:F2}, {hitY:F2})");
            }
            else
            {
                Console.WriteLine("Raycast missed");
            }

            Console.WriteLine();

            // Example 3: Inventory operations (ref and out)
            int gold = 100, gems = 5;
            string itemReceived;
            bool purchased = TryPurchaseItem("Sword", ref gold, ref gems, out itemReceived);

            if (purchased)
            {
                Console.WriteLine($"Purchased: {itemReceived}");
                Console.WriteLine($"Remaining: Gold = {gold}, Gems = {gems}");
            }
            else
            {
                Console.WriteLine("Not enough resources!");
            }

            Console.WriteLine();

            // ===== MULTIPLE RETURN VALUES =====

            Console.WriteLine("=== MULTIPLE RETURN VALUES ===\n");

            // out allows returning multiple values
            int sumResult, productResult, differenceResult;
            Calculate(10, 5, out sumResult, out productResult, out differenceResult);
            Console.WriteLine($"Sum: {sumResult}, Product: {productResult}, Difference: {differenceResult}");

            // Get player stats
            int level, experience;
            float currentHealth, maxHealth;
            GetPlayerStats(out level, out experience, out currentHealth, out maxHealth);
            Console.WriteLine($"Level: {level}, XP: {experience}, HP: {currentHealth}/{maxHealth}");

            Console.WriteLine();

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.WriteLine("=== REF/OUT BEST PRACTICES ===\n");

            // TIP 1: WHEN TO USE REF vs OUT
            // Use REF when: Modifying existing value (health, position, counters)
            // Use OUT when: Returning multiple values, TryParse pattern

            // TIP 2: PERFORMANCE - REF FOR LARGE STRUCTS
            // Passing large structs by value = SLOW (copies entire struct)
            // Passing by ref = FAST (only passes 4/8 byte pointer)

            // SLOW - Copies entire struct:
            // void ProcessTransform(Transform t) { }  // Copies all Transform data

            // FAST - Passes by reference:
            // void ProcessTransform(ref Transform t) { }  // Only passes pointer

            // TIP 3: TRY-PARSE PATTERN (OUT)
            // Always use TryParse for user input instead of Parse
            // Parse throws exception on failure (slow, can crash)
            // TryParse returns false on failure (fast, safe)

            // UNSAFE:
            // int value = int.Parse(input);  // Crashes on invalid input

            // SAFE:
            // if (int.TryParse(input, out int value)) { /* use value */ }

            // TIP 4: REF PREVENTS COPYING (GAME DEV CRITICAL)
            // GAME DEV: Use ref for structs passed frequently (Vector3, Matrix, etc.)

            // SLOW - Copies Vector3 every call:
            // void UpdatePosition(Vector3 pos) { }

            // FAST - No copy:
            // void UpdatePosition(ref Vector3 pos) { }

            // TIP 5: OUT FOR MULTIPLE RETURNS
            // Before tuples (C# 7.0), out was the only way to return multiple values
            // Still useful and more performant than tuples (no allocation)

            // TIP 6: AVOID OVERUSING OUT
            // Too many out parameters = confusing
            // Consider using custom struct/class for many return values

            // CONFUSING:
            // void GetData(out int a, out int b, out int c, out int d, out int e) { }

            // BETTER:
            // struct GameData { int a, b, c, d, e; }
            // GameData GetData() { return new GameData(...); }

            Console.WriteLine("⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• ref/out pass by reference (4-8 bytes) - very fast");
            Console.WriteLine("• Use ref for large structs (Vector3, Matrix) - avoid copying");
            Console.WriteLine("• TryParse (out) faster and safer than Parse (exceptions)");
            Console.WriteLine("• out has no allocation cost (unlike tuples)");
            Console.WriteLine("• ref allows in-place modification (cache-friendly)");

            Console.WriteLine("\n🚀 GAME DEV OPTIMIZATION:");
            Console.WriteLine("• ALWAYS use ref for Vector3, Quaternion, Matrix in hot paths");
            Console.WriteLine("• Use out for TryGet patterns (TryGetComponent, etc.)");
            Console.WriteLine("• Avoid copying large structs - use ref in Update()");
            Console.WriteLine("• ref parameters enable in-place updates (no allocation)");
            Console.WriteLine("• Use out for returning success + result (bool + value)");

            Console.WriteLine("\n✅ BEST PRACTICES SUMMARY:");
            Console.WriteLine("• Use REF to modify existing values (health, position)");
            Console.WriteLine("• Use OUT to return multiple values (divide, parse)");
            Console.WriteLine("• REF requires initialization, OUT doesn't");
            Console.WriteLine("• OUT must be assigned in function before return");
            Console.WriteLine("• Use inline out declaration (C# 7.0+) for cleaner code");
            Console.WriteLine("• Prefer TryParse pattern over Parse for safety");
            Console.WriteLine("• Use ref for large structs to avoid copying");
            Console.WriteLine("• Don't overuse out - consider structs for many returns");

            Console.WriteLine("\n📋 REF vs OUT:");
            Console.WriteLine("┌─────────────┬────────────────┬────────────────┐");
            Console.WriteLine("│ Feature     │ REF            │ OUT            │");
            Console.WriteLine("├─────────────┼────────────────┼────────────────┤");
            Console.WriteLine("│ Init before │ REQUIRED       │ NOT required   │");
            Console.WriteLine("│ Assign in   │ Optional       │ REQUIRED       │");
            Console.WriteLine("│ Use case    │ Modify value   │ Return values  │");
            Console.WriteLine("│ Example     │ ref health     │ out result     │");
            Console.WriteLine("└─────────────┴────────────────┴────────────────┘");

            Console.WriteLine("\n🎮 GAME DEV USE CASES:");
            Console.WriteLine("• ref: ApplyDamage(ref health, damage)");
            Console.WriteLine("• ref: MovePlayer(ref x, ref y, dx, dy)");
            Console.WriteLine("• ref: UpdateVelocity(ref Vector3 velocity)");
            Console.WriteLine("• out: bool TryGetComponent(out Component comp)");
            Console.WriteLine("• out: Raycast(origin, dir, out RaycastHit hit)");
            Console.WriteLine("• out: bool TryPurchase(ref gold, out Item item)");

            Console.WriteLine("\n❌ COMMON MISTAKES:");
            Console.WriteLine("• Using uninitialized variable with ref (compiler error)");
            Console.WriteLine("• Forgetting to assign out parameter (compiler error)");
            Console.WriteLine("• Using ref when out is more appropriate (TryParse)");
            Console.WriteLine("• Not using ref for large structs (performance issue)");
            Console.WriteLine("• Too many out parameters (use struct instead)");
            Console.WriteLine("• Using Parse instead of TryParse (unsafe)");
        }

        // ===== REF PARAMETER EXAMPLES =====

        // Add two numbers and store in ref parameter
        static void Add(ref int sum, int x, int y)
        {
            sum = x + y;  // Modifies original variable
        }

        // Multiply value by two (modifies original)
        static void MultiplyByTwo(ref int value)
        {
            value *= 2;
        }

        // Swap two values
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // Apply damage to health (ref)
        static void ApplyDamage(ref int health, int damage)
        {
            health -= damage;
            if (health < 0) health = 0;  // Clamp to 0
        }

        // Move player position (ref)
        static void MovePlayer(ref float x, ref float y, float dx, float dy)
        {
            x += dx;
            y += dy;
        }

        // Apply buff to stats (ref)
        static void ApplyBuff(ref int attack, ref int defense, float multiplier)
        {
            attack = (int)(attack * multiplier);
            defense = (int)(defense * multiplier);
        }

        // ===== OUT PARAMETER EXAMPLES =====

        // TryParse pattern - returns success, value via out
        static bool TryParse(string text, out int result)
        {
            return int.TryParse(text, out result);
        }

        // Divide with quotient and remainder (out)
        static void Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }

        // Get min and max from array (out)
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

        // Calculate damage (out)
        static void CalculateDamage(int baseDamage, float multiplier, out int totalDamage)
        {
            totalDamage = (int)(baseDamage * multiplier);
        }

        // Try get high score (out)
        static bool TryGetHighScore(string playerName, out int score)
        {
            // Simulate database lookup
            if (playerName == "Player1")
            {
                score = 1000;
                return true;
            }

            score = 0;
            return false;
        }

        // Safe parse with validation (out)
        static bool SafeParse(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                result = 0;
                return false;
            }

            return int.TryParse(input, out result);
        }

        // Raycast simulation (out)
        static bool Raycast(float startX, float startY, float dirX, float dirY, float distance, out float hitX, out float hitY)
        {
            // Simplified raycast - always hits
            hitX = startX + dirX * distance;
            hitY = startY + dirY * distance;
            return true;  // Hit something
        }

        // Try purchase item (ref and out)
        static bool TryPurchaseItem(string itemName, ref int gold, ref int gems, out string itemReceived)
        {
            // Item costs
            const int swordCost = 50;

            if (gold >= swordCost)
            {
                gold -= swordCost;  // Deduct gold
                itemReceived = itemName;
                return true;
            }

            itemReceived = null;
            return false;
        }

        // ===== MULTIPLE OUT PARAMETERS =====

        // Calculate multiple results (out)
        static void Calculate(int a, int b, out int sum, out int product, out int difference)
        {
            sum = a + b;
            product = a * b;
            difference = a - b;
        }

        // Get player stats (out)
        static void GetPlayerStats(out int level, out int experience, out float currentHealth, out float maxHealth)
        {
            // Simulate getting stats from game state
            level = 10;
            experience = 5000;
            currentHealth = 75.5f;
            maxHealth = 100.0f;
        }
    }
}