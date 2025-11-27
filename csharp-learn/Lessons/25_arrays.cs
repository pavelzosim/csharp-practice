using System;

namespace csharp_learn
{
    // LESSON 25: Arrays
    // Learn how to store multiple values of the same type in a single variable
    internal class Lesson25_arrays
    {
        public static void Run()
        {
            // ===== TOPIC: ARRAYS =====
            // Array is a collection of elements of the SAME type
            // Fixed size - cannot grow or shrink after creation
            // Zero-indexed - first element is at index 0

            Console.WriteLine("=== ARRAY BASICS ===\n");

            // ===== DECLARING AND CREATING ARRAYS =====

            // Method 1: Declare with new keyword and size
            int[] numbers = new int[5];  // Creates array with 5 elements (all initialized to 0)
            Console.WriteLine($"Default value: {numbers[0]}");  // Prints 0
            Console.WriteLine($"Array length: {numbers.Length}");  // Prints 5

            // Method 2: Declare and initialize with values
            string[] players = { "Alice", "Bob", "Charlie", "Diana" };
            Console.WriteLine($"Players array length: {players.Length}");  // Prints 4

            // Method 3: Declare with new keyword and initializer
            double[] scores = new double[] { 95.5, 87.3, 92.1, 88.9 };
            Console.WriteLine($"First score: {scores[0]}");  // Prints 95.5

            Console.WriteLine();

            // ===== ACCESSING ARRAY ELEMENTS =====

            Console.WriteLine("=== ACCESSING ELEMENTS ===\n");

            int[] cucumbers = new int[10];
            Console.WriteLine($"Default value at index 0: {cucumbers[0]}");  // 0 (default for int)

            // Setting individual elements
            cucumbers[0] = 5;
            cucumbers[3] = 3;
            cucumbers[7] = 13;
            cucumbers[9] = 99;

            Console.WriteLine($"Value at index 0: {cucumbers[0]}");
            Console.WriteLine($"Value at index 3: {cucumbers[3]}");
            Console.WriteLine($"Value at index 7: {cucumbers[7]}");
            Console.WriteLine($"Value at index 9: {cucumbers[9]}");

            // WARNING: Index out of bounds
            // Console.WriteLine(cucumbers[10]);  // ERROR! Index 10 doesn't exist (max is 9)

            Console.WriteLine();

            // ===== POPULATING ARRAYS WITH LOOPS =====

            Console.WriteLine("=== POPULATING ARRAYS ===\n");

            // Fill array with values using for loop
            for (int i = 0; i < cucumbers.Length; i++)
            {
                cucumbers[i] = i * 10;  // 0, 10, 20, 30, 40, ...
            }

            // Display array contents
            Console.WriteLine("Array contents after loop:");
            for (int i = 0; i < cucumbers.Length; i++)
            {
                Console.WriteLine($"cucumbers[{i}] = {cucumbers[i]}");
            }

            Console.WriteLine();

            // ===== ITERATING ARRAYS: FOR vs FOREACH =====

            Console.WriteLine("=== FOR vs FOREACH ===\n");

            string[] fruits = { "Apple", "Banana", "Cherry", "Date", "Elderberry" };

            // Method 1: FOR loop (with index)
            Console.WriteLine("Using FOR loop:");
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.WriteLine($"Index {i}: {fruits[i]}");
            }

            Console.WriteLine();

            // Method 2: FOREACH loop (no index, cleaner)
            Console.WriteLine("Using FOREACH loop:");
            foreach (string fruit in fruits)
            {
                Console.WriteLine($"Fruit: {fruit}");
            }

            Console.WriteLine();

            // ===== ARRAY OPERATIONS =====

            Console.WriteLine("=== ARRAY OPERATIONS ===\n");

            int[] values = { 45, 23, 67, 12, 89, 34, 56 };

            // Find sum
            int sum = 0;
            foreach (int value in values)
            {
                sum += value;
            }
            Console.WriteLine($"Sum of all values: {sum}");

            // Find average
            double average = (double)sum / values.Length;
            Console.WriteLine($"Average: {average:F2}");

            // Find maximum
            int max = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                }
            }
            Console.WriteLine($"Maximum value: {max}");

            // Find minimum
            int min = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] < min)
                {
                    min = values[i];
                }
            }
            Console.WriteLine($"Minimum value: {min}");

            Console.WriteLine();

            // ===== MULTIDIMENSIONAL ARRAYS =====

            Console.WriteLine("=== MULTIDIMENSIONAL ARRAYS ===\n");

            // 2D Array (rectangular array)
            int[,] matrix = new int[3, 3]  // 3 rows, 3 columns
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Console.WriteLine("2D Array (Matrix):");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{matrix[row, col]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // ===== JAGGED ARRAYS (Array of Arrays) =====

            Console.WriteLine("=== JAGGED ARRAYS ===\n");

            // Jagged array - each row can have different length
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2 };           // 2 elements
            jaggedArray[1] = new int[] { 3, 4, 5 };        // 3 elements
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };     // 4 elements

            Console.WriteLine("Jagged Array:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write($"Row {i}: ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // ===== ARRAY METHODS (System.Array) =====

            Console.WriteLine("=== ARRAY METHODS ===\n");

            int[] testArray = { 5, 2, 8, 1, 9, 3, 7 };

            Console.WriteLine("Original array: " + string.Join(", ", testArray));

            // Sort array
            Array.Sort(testArray);
            Console.WriteLine("After Sort: " + string.Join(", ", testArray));

            // Reverse array
            Array.Reverse(testArray);
            Console.WriteLine("After Reverse: " + string.Join(", ", testArray));

            // Find index of element
            int searchValue = 8;
            int index = Array.IndexOf(testArray, searchValue);
            Console.WriteLine($"Index of {searchValue}: {index}");

            // Check if array contains value
            bool contains = Array.Exists(testArray, element => element == 5);
            Console.WriteLine($"Array contains 5: {contains}");

            // Clear array (set to default values)
            int[] clearTest = { 1, 2, 3, 4, 5 };
            Array.Clear(clearTest, 0, clearTest.Length);  // Clear from index 0, all elements
            Console.WriteLine("After Clear: " + string.Join(", ", clearTest));  // All zeros

            Console.WriteLine();

            // ===== COPYING ARRAYS =====

            Console.WriteLine("=== COPYING ARRAYS ===\n");

            int[] original = { 10, 20, 30, 40, 50 };

            // Method 1: Array.Copy
            int[] copy1 = new int[original.Length];
            Array.Copy(original, copy1, original.Length);
            Console.WriteLine("Copy 1: " + string.Join(", ", copy1));

            // Method 2: Clone (creates shallow copy)
            int[] copy2 = (int[])original.Clone();
            Console.WriteLine("Copy 2: " + string.Join(", ", copy2));

            // Modify copy - original unchanged
            copy1[0] = 999;
            Console.WriteLine($"Original[0]: {original[0]}");  // Still 10
            Console.WriteLine($"Copy1[0]: {copy1[0]}");        // 999

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: INVENTORY SYSTEM =====

            Console.WriteLine("=== INVENTORY SYSTEM EXAMPLE ===\n");

            string[] inventory = new string[5];
            int itemCount = 0;

            // Add items
            inventory[itemCount++] = "Sword";
            inventory[itemCount++] = "Shield";
            inventory[itemCount++] = "Potion";

            Console.WriteLine("Inventory:");
            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[i]}");
            }

            Console.WriteLine();

            // ===== BEST PRACTICES & OPTIMIZATION TIPS =====

            Console.WriteLine("=== ARRAY BEST PRACTICES ===\n");

            // TIP 1: CACHE ARRAY LENGTH - CRITICAL!
            // INEFFICIENT - Length property accessed every iteration:
            // for (int i = 0; i < array.Length; i++) { }  // Slow for large arrays

            // EFFICIENT - Cache length before loop:
            int[] largeArray = new int[1000];
            int length = largeArray.Length;  // Read once
            for (int i = 0; i < length; i++)
            {
                // Process array
            }
            // PERFORMANCE GAIN: ~10-20% faster

            // TIP 2: FOR vs FOREACH PERFORMANCE
            // FOR: Faster (direct index access), need index
            // FOREACH: Slightly slower (creates enumerator), cleaner code

            // Use FOR when: Performance critical, need index, large arrays
            // Use FOREACH when: Readability matters, don't need index

            // TIP 3: BOUNDS CHECKING
            // C# automatically checks array bounds - safe but has small cost
            // SAFE: array[i] - throws exception if out of bounds
            // UNSAFE (C++ style): No automatic checking in unsafe code

            // TIP 4: ARRAY ALLOCATION
            // Arrays are REFERENCE TYPES - stored on heap
            // Creating arrays allocates memory - expensive operation

            // GAME DEV: Pre-allocate arrays, don't create in loops!
            // INEFFICIENT:
            // for (int i = 0; i < 1000; i++) {
            //     int[] temp = new int[10];  // SLOW - 1000 allocations!
            // }

            // EFFICIENT:
            // int[] reusable = new int[10];  // Allocate once
            // for (int i = 0; i < 1000; i++) {
            //     // Reuse array
            // }

            // TIP 5: MULTIDIMENSIONAL vs JAGGED ARRAYS
            // Rectangular [,]: Better cache locality, slightly faster
            // Jagged [][]: More flexible, each row can be different size

            // For performance: Use rectangular [,] when all rows same size
            // For flexibility: Use jagged [][] when rows differ

            // TIP 6: ARRAY.COPY vs LOOP
            // Array.Copy is FASTER than manual loop (optimized native code)
            // SLOW: for (int i = 0; i < src.Length; i++) dst[i] = src[i];
            // FAST: Array.Copy(src, dst, src.Length);

            // TIP 7: ARRAY RESIZING
            // Arrays are FIXED SIZE - cannot resize!
            // To "resize": Create new array and copy (expensive!)
            // For dynamic size: Use List<T> instead

            // INEFFICIENT - Frequent resizing:
            // int[] arr = new int[10];
            // Array.Resize(ref arr, 20);  // Creates NEW array, copies all elements

            // BETTER - Use List<T>:
            // List<int> list = new List<int>();  // Dynamic size, efficient

            // TIP 8: INITIALIZATION PERFORMANCE
            // Default initialization (new int[10]) sets all to 0
            // This has a cost for large arrays
            // If you'll overwrite all values anyway, initialization is wasted

            Console.WriteLine("⚡ PERFORMANCE TIPS:");
            Console.WriteLine("• Cache array.Length before loops (10-20% faster)");
            Console.WriteLine("• FOR loop faster than FOREACH for large arrays");
            Console.WriteLine("• Pre-allocate arrays - don't create in loops!");
            Console.WriteLine("• Array.Copy faster than manual loops");
            Console.WriteLine("• Use List<T> for dynamic size needs");
            Console.WriteLine("• Rectangular arrays [,] faster than jagged [][]");

            Console.WriteLine("\n🚀 GAME DEV OPTIMIZATION:");
            Console.WriteLine("• Pre-allocate all arrays at startup (not in Update)");
            Console.WriteLine("• Reuse arrays instead of creating new ones");
            Console.WriteLine("• Use object pooling for frequently created arrays");
            Console.WriteLine("• Cache array.Length - don't recalculate each frame");
            Console.WriteLine("• Avoid Array.Resize - creates new array (slow)");
            Console.WriteLine("• For large data: Consider using unsafe arrays (advanced)");

            Console.WriteLine("\n✅ BEST PRACTICES SUMMARY:");
            Console.WriteLine("• Arrays are FIXED SIZE - plan capacity in advance");
            Console.WriteLine("• Zero-indexed - first element is [0], last is [Length-1]");
            Console.WriteLine("• Always check bounds to avoid exceptions");
            Console.WriteLine("• Use FOR when you need index, FOREACH when you don't");
            Console.WriteLine("• Cache Length property before loops");
            Console.WriteLine("• Use List<T> if size needs to change frequently");
            Console.WriteLine("• Array.Copy/Clone for copying, not manual loops");
            Console.WriteLine("• Pre-allocate arrays in games, don't create per-frame");

            Console.WriteLine("\n📋 COMMON ARRAY OPERATIONS:");
            Console.WriteLine("• Create: int[] arr = new int[10];");
            Console.WriteLine("• Initialize: int[] arr = { 1, 2, 3 };");
            Console.WriteLine("• Access: int value = arr[0];");
            Console.WriteLine("• Set: arr[0] = 5;");
            Console.WriteLine("• Length: int len = arr.Length;");
            Console.WriteLine("• Sort: Array.Sort(arr);");
            Console.WriteLine("• Reverse: Array.Reverse(arr);");
            Console.WriteLine("• Find: int index = Array.IndexOf(arr, value);");
            Console.WriteLine("• Copy: Array.Copy(src, dst, length);");
            Console.WriteLine("• Clear: Array.Clear(arr, 0, arr.Length);");

            Console.WriteLine("\n🎮 GAME DEV USE CASES:");
            Console.WriteLine("• Inventory: string[] items = new string[20];");
            Console.WriteLine("• Enemy spawns: Enemy[] enemies = new Enemy[100];");
            Console.WriteLine("• Grid/Map: int[,] map = new int[width, height];");
            Console.WriteLine("• Vertex data: float[] vertices = new float[1000];");
            Console.WriteLine("• Animation frames: Sprite[] frames = new Sprite[10];");
            Console.WriteLine("• Particle systems: Particle[] particles = new Particle[500];");

            Console.WriteLine("\n❌ COMMON MISTAKES:");
            Console.WriteLine("• Index out of bounds (accessing arr[10] when Length is 10)");
            Console.WriteLine("• Not caching Length (slow in loops)");
            Console.WriteLine("• Creating arrays inside loops (allocations)");
            Console.WriteLine("• Using arrays when List<T> would be better (dynamic size)");
            Console.WriteLine("• Forgetting arrays are zero-indexed (first is [0], not [1])");
            Console.WriteLine("• Manual copying instead of Array.Copy (slower)");
            Console.WriteLine("• Trying to resize arrays frequently (expensive)");

            Console.WriteLine("\n💡 WHEN TO USE:");
            Console.WriteLine("• Use ARRAYS when: Fixed size, performance critical, simple data");
            Console.WriteLine("• Use LIST<T> when: Dynamic size, frequent add/remove, flexibility");
            Console.WriteLine("• Use DICTIONARY when: Key-value pairs, fast lookups");
            Console.WriteLine("• Use QUEUE/STACK when: Specific order (FIFO/LIFO)");
        }
    }
}