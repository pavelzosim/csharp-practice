using System;

namespace csharp_learn
{
    // LESSON 08: Switch Statement
    // Learn when and how to use switch for cleaner multi-condition code
    internal class Lesson08_switch
    {
        public static void Run()
        {
            // ===== TOPIC: SWITCH STATEMENT =====
            // Switch is an alternative to multiple if-else statements
            // Best used when checking ONE variable against MULTIPLE specific values

            string dayOfWeek = "monday";

            // ===== BASIC SWITCH SYNTAX =====

            switch (dayOfWeek)
            {
                case "monday":
                    Console.WriteLine("Going to the gym.");
                    Console.WriteLine("Grocery shopping.");
                    break;  // CRITICAL: break prevents fall-through to next case

                case "tuesday":
                    Console.WriteLine("Attend team meeting.");
                    break;

                case "wednesday":
                    Console.WriteLine("Work on project.");
                    break;

                case "thursday":
                    Console.WriteLine("Visit family.");
                    break;

                case "friday":
                    Console.WriteLine("Team lunch.");
                    break;

                case "saturday":
                case "sunday":
                    // Multiple cases can share the same code block
                    Console.WriteLine("Relax and enjoy the weekend!");
                    break;

                default:
                    // Executes if no case matches
                    Console.WriteLine("Invalid day of the week.");
                    break;
            }

            // ===== SWITCH WITH DIFFERENT TYPES =====

            // Switch with int
            int playerChoice = 2;

            Console.WriteLine("\n=== Menu Selection ===");
            switch (playerChoice)
            {
                case 1:
                    Console.WriteLine("Start New Game");
                    break;
                case 2:
                    Console.WriteLine("Load Game");
                    break;
                case 3:
                    Console.WriteLine("Settings");
                    break;
                case 4:
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please select 1-4.");
                    break;
            }

            // Switch with char
            char grade = 'B';

            Console.WriteLine("\n=== Grade Evaluation ===");
            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Excellent!");
                    break;
                case 'B':
                    Console.WriteLine("Good job!");
                    break;
                case 'C':
                    Console.WriteLine("Average.");
                    break;
                case 'D':
                    Console.WriteLine("Needs improvement.");
                    break;
                case 'F':
                    Console.WriteLine("Failed.");
                    break;
                default:
                    Console.WriteLine("Invalid grade.");
                    break;
            }

            // ===== ADVANCED: SWITCH WITH ENUM =====

            DayType today = DayType.Friday;

            switch (today)
            {
                case DayType.Monday:
                case DayType.Tuesday:
                case DayType.Wednesday:
                case DayType.Thursday:
                    Console.WriteLine("\n⚡ It's a workday - stay focused!");
                    break;
                case DayType.Friday:
                    Console.WriteLine("\n🎉 It's Friday - almost weekend!");
                    break;
                case DayType.Saturday:
                case DayType.Sunday:
                    Console.WriteLine("\n🌴 It's the weekend - relax!");
                    break;
            }

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.WriteLine("\n=== SWITCH vs IF-ELSE: WHEN TO USE WHAT ===");

            // TIP 1: SWITCH vs IF-ELSE PERFORMANCE
            // SWITCH is FASTER for 5+ comparisons of the SAME variable
            // Compiler optimizes switch into a jump table (O(1) lookup)
            // Multiple if-else requires checking each condition sequentially (O(n))

            // INEFFICIENT - Multiple if-else for same variable:
            // if (day == "monday") { }
            // else if (day == "tuesday") { }
            // else if (day == "wednesday") { }
            // else if (day == "thursday") { }
            // else if (day == "friday") { }     // Has to check all previous conditions!

            // EFFICIENT - Switch with jump table:
            // switch (day) {
            //     case "monday": break;
            //     case "tuesday": break;
            //     ... // Compiler creates jump table - direct lookup!
            // }

            Console.WriteLine("\n⚡ PERFORMANCE COMPARISON:");
            Console.WriteLine("• Switch: O(1) - Jump table (constant time)");
            Console.WriteLine("• If-else chain: O(n) - Checks sequentially");
            Console.WriteLine("• For 3+ cases on same variable: switch is faster");

            // TIP 2: WHEN TO USE SWITCH
            Console.WriteLine("\n✅ USE SWITCH WHEN:");
            Console.WriteLine("• Checking ONE variable against MULTIPLE specific values");
            Console.WriteLine("• You have 3+ possible values to check");
            Console.WriteLine("• Values are constants (strings, int, char, enum)");
            Console.WriteLine("• Code readability matters (switch is cleaner)");
            Console.WriteLine("• Examples: Menu systems, state machines, command parsing");

            // TIP 3: WHEN TO USE IF-ELSE
            Console.WriteLine("\n✅ USE IF-ELSE WHEN:");
            Console.WriteLine("• Checking DIFFERENT variables (if x > 5 && y < 10)");
            Console.WriteLine("• Using RANGES (if age >= 18 && age < 65)");
            Console.WriteLine("• Complex boolean expressions (if isAlive && hasAmmo)");
            Console.WriteLine("• Only 1-2 conditions to check");
            Console.WriteLine("• Examples: Range checks, multiple variable logic");

            // TIP 4: COMMON SWITCH MISTAKES
            Console.WriteLine("\n❌ COMMON MISTAKES:");
            Console.WriteLine("• Forgetting 'break' - causes fall-through bug!");
            Console.WriteLine("• Using switch for ranges - use if-else instead");
            Console.WriteLine("• Not including 'default' case - always handle unexpected values");

            // TIP 5: GAME DEV USAGE
            Console.WriteLine("\n🎮 GAME DEV APPLICATIONS:");
            Console.WriteLine("• State machines (Idle, Walking, Jumping, Attacking)");
            Console.WriteLine("• Input handling (W, A, S, D keys)");
            Console.WriteLine("• Menu navigation (Start, Load, Settings, Quit)");
            Console.WriteLine("• Item types (Weapon, Armor, Potion, Key)");
            Console.WriteLine("• AI behavior states (Patrol, Chase, Attack, Flee)");

            // TIP 6: SWITCH PERFORMANCE IN GAMES
            // GAME DEV: Switch is excellent for state machines
            // State machines run EVERY FRAME - switch optimization matters!

            // Example: Character state machine
            // enum CharacterState { Idle, Walk, Run, Jump, Attack }
            // switch (currentState) {
            //     case CharacterState.Idle: UpdateIdle(); break;
            //     case CharacterState.Walk: UpdateWalk(); break;
            //     case CharacterState.Run: UpdateRun(); break;
            //     ... // Jump table = fast state lookup every frame!
            // }

            Console.WriteLine("\n🚀 OPTIMIZATION TIPS:");
            Console.WriteLine("• Switch compiles to jump table (very fast!)");
            Console.WriteLine("• Perfect for state machines in game loops");
            Console.WriteLine("• Use enum instead of string for even better performance");
            Console.WriteLine("• Compiler optimizes switch better than if-else chains");

            Console.WriteLine("\n📋 BEST PRACTICES SUMMARY:");
            Console.WriteLine("• ALWAYS include 'break' after each case");
            Console.WriteLine("• ALWAYS include 'default' case for safety");
            Console.WriteLine("• Use switch for 3+ constant value checks");
            Console.WriteLine("• Use if-else for ranges, multiple variables, complex logic");
            Console.WriteLine("• Prefer enum over string/int for type safety");
            Console.WriteLine("• Group related cases (weekend days together)");

            // ===== COMPARISON EXAMPLE: SWITCH vs IF-ELSE =====

            Console.WriteLine("\n=== CODE COMPARISON ===");

            int score = 85;

            // WRONG - Don't use switch for ranges:
            // switch (score) {  // Can't do: case >= 90
            //     case 90: ... // Only checks exact value!
            // }

            // CORRECT - Use if-else for ranges:
            if (score >= 90)
            {
                Console.WriteLine("Grade: A");
            }
            else if (score >= 80)
            {
                Console.WriteLine("Grade: B");
            }
            else if (score >= 70)
            {
                Console.WriteLine("Grade: C");
            }
            else
            {
                Console.WriteLine("Grade: F");
            }

            // CORRECT - Use switch for exact values:
            string command = "attack";
            switch (command)
            {
                case "attack":
                    Console.WriteLine("\nExecuting attack command!");
                    break;
                case "defend":
                    Console.WriteLine("\nRaising shield!");
                    break;
                case "heal":
                    Console.WriteLine("\nUsing potion!");
                    break;
                default:
                    Console.WriteLine("\nUnknown command!");
                    break;
            }
        }
    }

    // Enum for advanced switch example
    enum DayType
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}