using System;

namespace csharp_learn
{
    // LESSON 15: Logical Operators
    // Learn how to combine multiple conditions using AND (&&), OR (||), and NOT (!)
    internal class Lesson15_logical_operators
    {
        public static void Run()
        {
            // ===== TOPIC: LOGICAL OPERATORS =====
            // Logical operators combine multiple boolean expressions
            // Used extensively in conditions, game logic, and decision-making

            // ===== OPERATOR 1: AND (&&) - Both conditions must be TRUE =====

            Console.WriteLine("=== LOGICAL AND (&&) TRUTH TABLE ===");
            Console.WriteLine("x | y | x && y");
            Console.WriteLine("1 | 1 |   1    ← Both true = true");
            Console.WriteLine("1 | 0 |   0    ← One false = false");
            Console.WriteLine("0 | 1 |   0    ← One false = false");
            Console.WriteLine("0 | 0 |   0    ← Both false = false");

            // Example: Player must have BOTH money AND required level
            int money = 500;
            int level = 10;

            if (money >= 500 && level >= 10)
            {
                Console.WriteLine("\n&& Example: You have enough money AND level!");
            }

            // ===== OPERATOR 2: OR (||) - At least ONE condition must be TRUE =====

            Console.WriteLine("\n=== LOGICAL OR (||) TRUTH TABLE ===");
            Console.WriteLine("x | y | x || y");
            Console.WriteLine("1 | 1 |   1    ← Both true = true");
            Console.WriteLine("1 | 0 |   1    ← One true = true");
            Console.WriteLine("0 | 1 |   1    ← One true = true");
            Console.WriteLine("0 | 0 |   0    ← Both false = false");

            // Example: Player can buy if they have EITHER money OR high level
            if (money >= 500 || level > 9)
            {
                Console.WriteLine("\n|| Example: You can buy the sword!");
                Console.WriteLine("(You have enough money OR high enough level)");
            }
            else
            {
                Console.WriteLine("\n|| Example: You cannot buy the sword.");
            }

            // ===== OPERATOR 3: NOT (!) - Inverts the boolean value =====

            bool isAlive = true;
            bool isDead = !isAlive;     // NOT operator - flips true to false

            Console.WriteLine($"\n=== LOGICAL NOT (!) ===");
            Console.WriteLine($"isAlive = {isAlive}");
            Console.WriteLine($"!isAlive (isDead) = {isDead}");

            // Practical example
            if (!isDead)    // Same as: if (isAlive == true)
            {
                Console.WriteLine("Player is alive!");
            }

            // ===== COMBINING MULTIPLE OPERATORS =====

            int health = 50;
            bool hasShield = true;
            bool hasPotion = false;

            // Complex condition: (Health low OR no shield) AND has potion
            if ((health < 30 || !hasShield) && hasPotion)
            {
                Console.WriteLine("\nUse health potion!");
            }
            else if (health < 30 && !hasPotion)
            {
                Console.WriteLine("\nDanger! Low health and no potions!");
            }
            else
            {
                Console.WriteLine("\nYou're doing fine.");
            }

            // ===== PRACTICAL EXAMPLES =====

            // Example 1: Access control
            bool isAdmin = false;
            bool isOwner = true;

            if (isAdmin || isOwner)
            {
                Console.WriteLine("\nAccess granted: You have permissions.");
            }

            // Example 2: Game logic - can player attack?
            int stamina = 20;
            int ammo = 5;
            bool weaponEquipped = true;

            if (weaponEquipped && (stamina > 10 || ammo > 0))
            {
                Console.WriteLine("\nYou can attack!");
            }

            // Example 3: Range checking
            int temperature = 25;

            if (temperature >= 18 && temperature <= 30)
            {
                Console.WriteLine($"\nTemperature {temperature}°C is comfortable.");
            }

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            // TIP 1: SHORT-CIRCUIT EVALUATION ★ CRITICAL FOR PERFORMANCE!
            // && stops checking if FIRST condition is false
            // || stops checking if FIRST condition is true

            // EXAMPLE - SHORT-CIRCUIT PREVENTS ERROR:
            int[] array = { 1, 2, 3 };
            int index = 5;

            // SAFE - index check happens first, prevents array access error:
            if (index >= 0 && index < array.Length && array[index] > 0)
            {
                // array[index] is NEVER accessed if index is out of bounds
            }

            // UNSAFE - would crash if order reversed:
            // if (array[index] > 0 && index < array.Length) // ERROR!

            // TIP 2: ORDER YOUR CONDITIONS FOR PERFORMANCE
            // Put FASTER/CHEAPER checks first
            // Put MORE LIKELY TO FAIL checks first

            // INEFFICIENT - expensive check first:
            // if (ExpensiveDatabaseCall() && cheapBoolVariable) { }

            // EFFICIENT - cheap check first (may skip expensive call):
            // if (cheapBoolVariable && ExpensiveDatabaseCall()) { }

            // TIP 3: GAME DEV - CONDITION ORDERING
            // INEFFICIENT:
            // if (enemy.CalculatePathToPlayer() && enemy.IsInRange()) { }

            // EFFICIENT - check simple distance first:
            // if (enemy.IsInRange() && enemy.CalculatePathToPlayer()) { }

            // TIP 4: AVOID REDUNDANT COMPARISONS
            // REDUNDANT:
            // if (x == true) { }        // Just use: if (x) { }
            // if (x == false) { }       // Just use: if (!x) { }

            // CLEAN:
            // if (isAlive) { }          // Clear and concise
            // if (!isAlive) { }         // Clear and concise

            // TIP 5: USE PARENTHESES FOR CLARITY
            // CONFUSING:
            // if (a || b && c) { }      // Which is evaluated first?

            // CLEAR:
            // if (a || (b && c)) { }    // Explicit order (AND has higher priority)
            // if ((a || b) && c) { }    // Different meaning - be explicit!

            // TIP 6: BITWISE vs LOGICAL OPERATORS
            // && and || are LOGICAL (short-circuit, for bool)
            // & and | are BITWISE (no short-circuit, for int/flags)

            // LOGICAL - stops at first false:
            // if (CheckSomething() && CheckExpensive()) { } // CheckExpensive may not run

            // BITWISE - always evaluates both:
            // if (CheckSomething() & CheckExpensive()) { }  // Both ALWAYS run - rarely needed

            Console.WriteLine("\n⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• && and || use SHORT-CIRCUIT evaluation");
            Console.WriteLine("• && stops if first condition is FALSE");
            Console.WriteLine("• || stops if first condition is TRUE");
            Console.WriteLine("• Put CHEAPER conditions first");
            Console.WriteLine("• Put MORE LIKELY TO FAIL conditions first");

            Console.WriteLine("\n🚀 GAME DEV OPTIMIZATION:");
            Console.WriteLine("• Check simple conditions before expensive ones");
            Console.WriteLine("• Example: if (isInRange && CalculatePath()) - range first!");
            Console.WriteLine("• Avoid recalculating same condition multiple times");
            Console.WriteLine("• Cache complex boolean results");

            Console.WriteLine("\n✅ BEST PRACTICES:");
            Console.WriteLine("• Use parentheses for complex conditions (clarity)");
            Console.WriteLine("• Avoid redundant == true or == false");
            Console.WriteLine("• Order conditions: cheap first, expensive last");
            Console.WriteLine("• Use short-circuit to prevent errors (null checks, array bounds)");
            Console.WriteLine("• Use descriptive variable names (isAlive, hasPermission)");

            Console.WriteLine("\n📋 COMMON PATTERNS:");
            Console.WriteLine("• Null check: if (obj != null && obj.IsValid())");
            Console.WriteLine("• Range check: if (x >= min && x <= max)");
            Console.WriteLine("• Permission check: if (isAdmin || isOwner)");
            Console.WriteLine("• Safety check: if (array != null && index < array.Length)");
        }
    }
}