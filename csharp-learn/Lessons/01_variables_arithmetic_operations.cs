using System;

namespace csharp_learn
{
    // LESSON 01: Variables and Arithmetic Operations
    // Learn about data types, variable declarations, and arithmetic operations with optimization tips
    internal class Lesson01_variables_arithmetic_operations
    {
        public static void Run()
        {
            // ===== TOPIC: INTEGER TYPES (Whole Numbers) =====

            Console.WriteLine("=== INTEGER TYPES DEMONSTRATION ===");

            // byte - unsigned 8-bit integer
            // Size: 1 byte | Range: 0 to 255
            // Use case: Small positive numbers (health, age, RGB colors, percentages)
            // Example: byte playerHealth = 100; // HP from 0 to 255
            // TIP: Perfect for values that never go negative and stay under 255
            // PERFORMANCE: Smallest integer type, best for memory-critical scenarios (large arrays)
            byte b = 255;
            Console.WriteLine($"byte: {b} | Range: 0 to 255 | Use: Health, percentages");

            // sbyte - signed 8-bit integer
            // Size: 1 byte | Range: -128 to 127
            // Use case: Small numbers with negative values (temperature, offsets, deltas)
            // Example: sbyte temperature = -40; // Temperature in Celsius
            // TIP: Rarely used in practice; byte or int are more common
            sbyte sb = -128;
            Console.WriteLine($"sbyte: {sb} | Range: -128 to 127 | Use: Temperature, offsets");

            // short - signed 16-bit integer
            // Size: 2 bytes | Range: -32,768 to 32,767
            // Use case: Coordinates in small maps, counters, inventory slots
            // Example: short posX = 1024; // X coordinate on a map
            // PERFORMANCE: Good for saving memory in large arrays while allowing negatives
            short s = -32768;
            Console.WriteLine($"short: {s} | Range: -32,768 to 32,767 | Use: Coordinates, counters");

            // ushort - unsigned 16-bit integer
            // Size: 2 bytes | Range: 0 to 65,535
            // Use case: Network ports, object IDs in small systems, character codes
            // Example: ushort port = 8080; // Server port number
            // TIP: Useful when you need 0-65K range (audio samples, small IDs)
            ushort us = 65535;
            Console.WriteLine($"ushort: {us} | Range: 0 to 65,535 | Use: Network ports, IDs");

            // int - signed 32-bit integer ★ MOST COMMONLY USED!
            // Size: 4 bytes | Range: -2,147,483,648 to 2,147,483,647
            // Use case: Default choice for integers, counters, indices, IDs, scores
            // Example: int score = 1000000; // Game score
            // TIP: Use int by default unless you have specific memory/range requirements
            // BEST PRACTICE: Modern CPUs are optimized for 32-bit operations
            // PERFORMANCE: Fastest integer arithmetic on most platforms
            int i = -2147483648;
            Console.WriteLine($"int: {i} | Range: ±2.1B | ★ DEFAULT INTEGER TYPE");

            // uint - unsigned 32-bit integer
            // Size: 4 bytes | Range: 0 to 4,294,967,295
            // Use case: Bit masks, RGBA colors, large positive numbers, hashes
            // Example: uint color = 0xFF5733FF; // RGBA color format
            // WARNING: Unsigned integers can cause bugs with subtraction (5u - 10u = huge positive!)
            // TIP: Use for bit operations and when negative values make no sense
            uint ui = 4294967295;
            Console.WriteLine($"uint: {ui} | Range: 0 to 4.3B | Use: Bit masks, colors");

            // long - signed 64-bit integer
            // Size: 8 bytes | Range: -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
            // Use case: Timestamps, file sizes, large calculations, database IDs
            // Example: long timestamp = 1699999999999; // Unix timestamp in milliseconds
            // PERFORMANCE: Slightly slower than int on 32-bit systems, equal on 64-bit
            // GAME DEV: Use for high-precision timers, large world coordinates
            long l = -9223372036854775808;
            Console.WriteLine($"long: {l} | Range: ±9.2 quintillion | Use: Timestamps, file sizes");

            // ulong - unsigned 64-bit integer
            // Size: 8 bytes | Range: 0 to 18,446,744,073,709,551,615
            // Use case: Very large positive numbers, file sizes, crypto operations
            // Example: ulong fileSize = 5368709120; // File size in bytes (5 GB)
            // TIP: Largest integer type in C#, use when other types aren't enough
            ulong ul = 18446744073709551615;
            Console.WriteLine($"ulong: {ul} | Range: 0 to 18.4 quintillion | Use: Large files, crypto");

            // ===== TOPIC: FLOATING POINT TYPES (Decimal Numbers) =====

            Console.WriteLine("\n=== FLOATING POINT TYPES DEMONSTRATION ===");

            // float - 32-bit floating point number
            // Size: 4 bytes | Precision: ~6-7 significant digits
            // Use case: 3D coordinates in games, physics (when precision isn't critical)
            // Example: float velocity = 9.8f; // Object velocity
            // TIP: ALWAYS add 'f' suffix! Without it, compiler treats it as double
            // PERFORMANCE: Faster than double on some platforms, uses half the memory
            // GAME DEV: Standard for Unity/Unreal transforms, physics, graphics
            // WARNING: Can have precision errors after ~6-7 digits
            float f = 5.7f;
            Console.WriteLine($"float: {f}f | Precision: ~6-7 digits | Use: Games, physics");

            // double - 64-bit floating point number ★ DEFAULT FOR DECIMALS
            // Size: 8 bytes | Precision: ~15-16 significant digits
            // Use case: Scientific calculations, math libraries, when precision matters
            // Example: double pi = 3.14159265358979; // Pi constant
            // TIP: Use double when precision is more important than memory/speed
            // BEST PRACTICE: Math class uses double, so it's natural for calculations
            // PERFORMANCE: On modern 64-bit CPUs, often as fast as float
            double d = 5.7;
            Console.WriteLine($"double: {d} | Precision: ~15-16 digits | ★ DEFAULT DECIMAL TYPE");

            // decimal - 128-bit high-precision decimal number
            // Size: 16 bytes | Precision: ~28-29 significant digits
            // Use case: Financial calculations, money, accounting, precise math
            // Example: decimal price = 19.99m; // Product price
            // TIP: MUST use 'm' suffix! Decimal avoids floating-point rounding errors
            // BEST PRACTICE: ALWAYS use decimal for money (never float/double!)
            // WARNING: Significantly slower than float/double (~10x), but accurate
            // GAME DEV: Rarely used in games (too slow), but perfect for shop systems
            decimal dec = 5.7m;
            Console.WriteLine($"decimal: {dec}m | Precision: ~28-29 digits | Use: Money, finance");

            // COMPARISON: float vs double vs decimal
            Console.WriteLine("\n⚡ FLOATING POINT COMPARISON:");
            Console.WriteLine("Speed:      float ≥ double >>> decimal");
            Console.WriteLine("Precision:  decimal > double > float");
            Console.WriteLine("Memory:     float < double < decimal");
            Console.WriteLine("Use float:  Games, graphics, physics");
            Console.WriteLine("Use double: Science, general math, calculations");
            Console.WriteLine("Use decimal: Money, finance, accounting");

            // ===== TOPIC: OTHER FUNDAMENTAL TYPES =====

            Console.WriteLine("\n=== OTHER TYPES DEMONSTRATION ===");

            // char - single Unicode character
            // Size: 2 bytes | Range: '\u0000' to '\uffff'
            // Use case: Individual characters, keys, letters, symbols
            // Example: char grade = 'A'; // Student grade
            // TIP: Use SINGLE quotes! Double quotes are for strings
            // PERFORMANCE: char is internally ushort (0-65535 Unicode code)
            // GAME DEV: Useful for keyboard input, text parsing, menu navigation
            char c = 'A';
            Console.WriteLine($"char: '{c}' | Size: 2 bytes | Use: Single characters");

            // string - sequence of characters (REFERENCE TYPE!)
            // Size: Dynamic | Immutable (cannot be changed after creation)
            // Use case: Text, names, messages, any textual data
            // Example: string playerName = "Steve"; // Player name
            // TIP: string is immutable! Modifying creates a NEW object in memory
            // PERFORMANCE: For frequent modifications, use StringBuilder (10-100x faster)
            // WARNING: String concatenation in loops is VERY slow (creates many objects)
            // BEST PRACTICE: Use string interpolation $\"\" instead of concatenation
            string str = "Hello, World!";
            Console.WriteLine($"string: \"{str}\" | Immutable | Use: Text data");

            // bool - boolean/logical type
            // Size: 1 byte | Values: true or false
            // Use case: Flags, conditions, states (on/off, yes/no, enabled/disabled)
            // Example: bool isAlive = true; // Is character alive?
            // TIP: Use meaningful names: isAlive, hasKey, canJump (not just "flag")
            // PERFORMANCE: Despite being 1 bit logically, stored as 1 byte for alignment
            // GAME DEV: Essential for state management, AI decisions, game logic
            bool bo = true;
            Console.WriteLine($"bool: {bo} | Size: 1 byte | Use: Flags, conditions");

            // ===== TOPIC: ARITHMETIC OPERATIONS =====

            Console.WriteLine("\n=== ARITHMETIC OPERATIONS ===");

            int a = 10;
            int b2 = 3;

            // Basic arithmetic operations
            int sum = a + b2;           // Addition: 10 + 3 = 13
            int diff = a - b2;          // Subtraction: 10 - 3 = 7
            int mult = a * b2;          // Multiplication: 10 * 3 = 30

            // DIVISION - Critical details!
            int divInt = a / b2;        // Integer division: 10 / 3 = 3 (fractional part discarded!)
            double divDouble = (double)a / b2;  // Division with decimals: 10.0 / 3 = 3.333...
                                                // TIP: Cast at least one operand to double/float for decimal result
                                                // WARNING: Division is the SLOWEST arithmetic operation (~10-40 CPU cycles)
                                                // PERFORMANCE: If dividing by power of 2, use bit shift: x / 4 → x >> 2
                                                // PERFORMANCE: Replace division with multiplication when possible: x / 5.0 → x * 0.2
                                                // GAME DEV: Pre-calculate 1/value and multiply instead of dividing repeatedly

            int remainder = a % b2;     // Modulo (remainder): 10 % 3 = 1
                                        // Use case: Check even/odd (x % 2 == 0), cyclic operations, hashing
                                        // GAME DEV: Wrap values (index % arrayLength), pattern repeating

            Console.WriteLine($"Basic Arithmetic:");
            Console.WriteLine($"{a} + {b2} = {sum}");
            Console.WriteLine($"{a} - {b2} = {diff}");
            Console.WriteLine($"{a} * {b2} = {mult}");
            Console.WriteLine($"{a} / {b2} (int) = {divInt} ← Fractional part lost!");
            Console.WriteLine($"{a} / {b2} (double) = {divDouble:F2} ← Use cast for decimals");
            Console.WriteLine($"{a} % {b2} = {remainder} ← Remainder/Modulo");

            // Compound assignment operators
            int z = 10;
            z += 5;     // z = z + 5;  → z = 15
            z -= 3;     // z = z - 3;  → z = 12
            z *= 2;     // z = z * 2;  → z = 24
            z /= 4;     // z = z / 4;  → z = 6
            z %= 5;     // z = z % 5;  → z = 1

            Console.WriteLine($"\nCompound Assignment: z started at 10, ended at {z}");

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.WriteLine($"\n⚡ PERFORMANCE TIPS:");
            Console.WriteLine($"• Division is SLOW (~10-40 cycles) - Use multiplication when possible");
            Console.WriteLine($"• Example: x / 5.0 → x * 0.2 (much faster)");
            Console.WriteLine($"• For powers of 2: x / 4 → x >> 2 (bit shift)");
            Console.WriteLine($"• Math.Pow(x, 2) → x*x (50x faster!)");
            Console.WriteLine($"• Avoid Math.Pow in game loops - pre-calculate");

            Console.WriteLine($"\n🎯 BEST PRACTICES SUMMARY:");
            Console.WriteLine($"• Use int as default integer type");
            Console.WriteLine($"• Use double as default floating point type");
            Console.WriteLine($"• Use decimal ONLY for money/finance");
            Console.WriteLine($"• Use float in Unity/Unreal (their standard)");
            Console.WriteLine($"• Use descriptive variable names (isAlive, playerHealth)");
        }
    }
}