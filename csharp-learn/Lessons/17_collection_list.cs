using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_learn.Lessons
{
    // LESSON 17: List<T> Collection
    // Learn about dynamic arrays (lists) that can grow and shrink automatically 
    // More flexible than fixed-size arrays
    internal class Lesson17_collection_list
    {
        public static void Run()
        {
            // ===== TOPIC: LIST COLLECTION =====
            // List<T> is a DYNAMIC array - size changes automatically
            // Unlike arrays (int[]) which have FIXED size

            Console.WriteLine("=== LIST<T> COLLECTION ===\n");

            // ===== CREATING LISTS =====

            Console.WriteLine("=== CREATING LISTS ===\n");

            // Create empty list (size = 0)
            List<int> numbers = new List<int>();
            Console.WriteLine($"Empty list count: {numbers.Count}");

            // Create list with initial capacity (optimization - not size!)
            List<int> numbersWithCapacity = new List<int>(10); // Reserve space for 10 elements
            Console.WriteLine($"List with capacity count: {numbersWithCapacity.Count}"); // Still 0!

            // Create list with initial values (collection initializer)
            List<int> scores = new List<int> { 100, 85, 92, 78 };
            Console.WriteLine($"Initialized list count: {scores.Count}");

            // List can store any type
            List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
            List<float> prices = new List<float> { 19.99f, 45.50f, 12.30f };
            List<bool> flags = new List<bool> { true, false, true };

            Console.WriteLine();

            // ===== ADDING ELEMENTS =====

            Console.WriteLine("=== ADDING ELEMENTS ===\n");

            List<int> myNumbers = new List<int>();

            // Add single element to the END of list
            myNumbers.Add(10);
            myNumbers.Add(20);
            myNumbers.Add(30);
            Console.WriteLine($"After Add: Count = {myNumbers.Count}"); // Count = 3

            // Add element at specific position (index)
            myNumbers.Insert(1, 15); // Insert 15 at index 1 (shifts others right)
            Console.Write("After Insert(1, 15): ");
            PrintList(myNumbers); // 10, 15, 20, 30

            // Add multiple elements at once (AddRange)
            myNumbers.AddRange(new int[] { 40, 50, 60 });
            Console.Write("After AddRange: ");
            PrintList(myNumbers); // 10, 15, 20, 30, 40, 50, 60

            Console.WriteLine();

            // ===== ACCESSING ELEMENTS =====

            Console.WriteLine("=== ACCESSING ELEMENTS ===\n");

            List<string> fruits = new List<string> { "Apple", "Banana", "Cherry", "Date" };

            // Access by index (like arrays)
            Console.WriteLine($"First fruit: {fruits[0]}");      // Apple
            Console.WriteLine($"Last fruit: {fruits[fruits.Count - 1]}"); // Date

            // Modify element by index
            fruits[1] = "Blueberry";
            Console.Write("After modification: ");
            PrintList(fruits);

            // Get element safely (avoid IndexOutOfRangeException)
            int index = 10;
            if (index >= 0 && index < fruits.Count)
            {
                Console.WriteLine(fruits[index]);
            }
            else
            {
                Console.WriteLine($"Index {index} is out of range!");
            }

            Console.WriteLine();

            // ===== REMOVING ELEMENTS =====

            Console.WriteLine("=== REMOVING ELEMENTS ===\n");

            List<int> testList = new List<int> { 10, 20, 30, 40, 50, 30 };
            Console.Write("Original: ");
            PrintList(testList);

            // Remove by VALUE (removes first occurrence)
            testList.Remove(30);
            Console.Write("After Remove(30): ");
            PrintList(testList); // 10, 20, 40, 50, 30 (removed first 30)

            // Remove by INDEX
            testList.RemoveAt(0);
            Console.Write("After RemoveAt(0): ");
            PrintList(testList); // 20, 40, 50, 30

            // Remove range of elements
            testList.RemoveRange(1, 2); // Remove 2 elements starting from index 1
            Console.Write("After RemoveRange(1, 2): ");
            PrintList(testList); // 20, 30

            // Clear all elements
            testList.Clear();
            Console.WriteLine($"After Clear: Count = {testList.Count}");

            Console.WriteLine();

            // ===== SEARCHING ELEMENTS =====

            Console.WriteLine("=== SEARCHING ELEMENTS ===\n");

            List<string> players = new List<string> { "Alice", "Bob", "Charlie", "Alice", "Dave" };

            // Check if element exists
            bool hasAlice = players.Contains("Alice");
            Console.WriteLine($"Contains 'Alice': {hasAlice}");

            // Find index of element (first occurrence)
            int aliceIndex = players.IndexOf("Alice");
            Console.WriteLine($"IndexOf 'Alice': {aliceIndex}"); // 0

            // Find last index of element
            int lastAliceIndex = players.LastIndexOf("Alice");
            Console.WriteLine($"LastIndexOf 'Alice': {lastAliceIndex}"); // 3

            // Element not found returns -1
            int eveIndex = players.IndexOf("Eve");
            Console.WriteLine($"IndexOf 'Eve': {eveIndex}"); // -1

            Console.WriteLine();

            // ===== SORTING AND REVERSING =====

            Console.WriteLine("=== SORTING AND REVERSING ===\n");

            List<int> unsorted = new List<int> { 45, 12, 89, 23, 5, 67 };
            Console.Write("Original: ");
            PrintList(unsorted);

            // Sort in ascending order
            unsorted.Sort();
            Console.Write("After Sort(): ");
            PrintList(unsorted); // 5, 12, 23, 45, 67, 89

            // Reverse the list
            unsorted.Reverse();
            Console.Write("After Reverse(): ");
            PrintList(unsorted); // 89, 67, 45, 23, 12, 5

            // Sort strings alphabetically
            List<string> words = new List<string> { "Zebra", "Apple", "Mango", "Banana" };
            words.Sort();
            Console.Write("Sorted words: ");
            PrintList(words);

            Console.WriteLine();

            // ===== ITERATING THROUGH LIST =====

            Console.WriteLine("=== ITERATING THROUGH LIST ===\n");

            List<int> values = new List<int> { 10, 20, 30, 40, 50 };

            // Method 1: for loop (with index)
            Console.Write("for loop: ");
            for (int i = 0; i < values.Count; i++)
            {
                Console.Write(values[i] + " ");
            }
            Console.WriteLine();

            // Method 2: foreach loop (no index, read-only)
            Console.Write("foreach loop: ");
            foreach (int value in values)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            // Method 3: ForEach with lambda (advanced)
            Console.Write("ForEach lambda: ");
            values.ForEach(v => Console.Write(v + " "));
            Console.WriteLine();

            Console.WriteLine();

            // ===== USEFUL METHODS =====

            Console.WriteLine("=== USEFUL METHODS ===\n");

            List<int> data = new List<int> { 5, 2, 8, 1, 9, 3 };

            // Count: Number of elements
            Console.WriteLine($"Count: {data.Count}");

            // Min and Max (requires System.Linq)
            Console.WriteLine($"Min: {data.Min()}");
            Console.WriteLine($"Max: {data.Max()}");

            // Sum and Average (requires System.Linq)
            Console.WriteLine($"Sum: {data.Sum()}");
            Console.WriteLine($"Average: {data.Average():F2}");

            // ToArray: Convert list to array
            int[] dataArray = data.ToArray();
            Console.WriteLine($"Converted to array, length: {dataArray.Length}");

            Console.WriteLine();

            // ===== LIST vs ARRAY =====

            Console.WriteLine("=== LIST vs ARRAY COMPARISON ===\n");

            // ARRAY - FIXED SIZE
            int[] fixedArray = new int[3];
            fixedArray[0] = 10;
            fixedArray[1] = 20;
            fixedArray[2] = 30;
            // fixedArray[3] = 40; // ❌ ERROR! Index out of range

            Console.WriteLine($"Array size: {fixedArray.Length} (FIXED)");

            // LIST - DYNAMIC SIZE
            List<int> dynamicList = new List<int>();
            dynamicList.Add(10);
            dynamicList.Add(20);
            dynamicList.Add(30);
            dynamicList.Add(40); // ✅ OK! Automatically grows
            dynamicList.Add(50);

            Console.WriteLine($"List size: {dynamicList.Count} (DYNAMIC)");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLES =====

            Console.WriteLine("=== PRACTICAL EXAMPLES ===\n");

            // Example 1: Shopping cart
            List<string> cart = new List<string>();
            cart.Add("Laptop");
            cart.Add("Mouse");
            cart.Add("Keyboard");
            Console.WriteLine($"Cart items: {cart.Count}");
            cart.Remove("Mouse");
            Console.WriteLine($"After removing Mouse: {cart.Count}");

            Console.WriteLine();

            // Example 2: High scores
            List<int> highScores = new List<int> { 1000, 850, 920, 780, 950 };
            highScores.Sort();
            highScores.Reverse(); // Descending order
            Console.WriteLine("Top 3 High Scores:");
            for (int i = 0; i < 3 && i < highScores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {highScores[i]}");
            }

            Console.WriteLine();

            // Example 3: Player inventory
            List<string> inventory = new List<string> { "Sword", "Shield", "Potion" };
            Console.WriteLine("=== INVENTORY ===");
            PrintList(inventory);

            // Add item
            inventory.Add("Helmet");
            Console.WriteLine("Added Helmet");

            // Check if has item
            if (inventory.Contains("Potion"))
            {
                Console.WriteLine("You have a Potion!");
                inventory.Remove("Potion");
                Console.WriteLine("Used Potion");
            }

            Console.WriteLine("Final inventory:");
            PrintList(inventory);

            Console.WriteLine();

            // ===== GAME DEV EXAMPLES =====

            Console.WriteLine("=== GAME DEV EXAMPLES ===\n");

            // Example 1: Enemy spawner
            List<string> enemies = new List<string>();
            enemies.Add("Goblin");
            enemies.Add("Orc");
            enemies.Add("Dragon");
            Console.WriteLine($"Spawned {enemies.Count} enemies");

            // Example 2: Active buffs
            List<string> activeBuffs = new List<string> { "Speed", "Strength", "Shield" };
            Console.Write("Active buffs: ");
            PrintList(activeBuffs);

            // Remove expired buff
            activeBuffs.RemoveAt(0);
            Console.Write("After buff expires: ");
            PrintList(activeBuffs);

            Console.WriteLine();

            // ===== PERFORMANCE NOTES =====

            Console.WriteLine("=== PERFORMANCE TIPS ===\n");

            Console.WriteLine("⚡ Performance considerations:");
            Console.WriteLine("• Add() is fast (O(1) amortized)");
            Console.WriteLine("• Insert() is slow (O(n) - shifts elements)");
            Console.WriteLine("• Remove() is slow (O(n) - searches + shifts)");
            Console.WriteLine("• RemoveAt() is medium (O(n) - shifts only)");
            Console.WriteLine("• Access by index is fast (O(1))");
            Console.WriteLine("• Contains() is slow (O(n) - searches all)");
            Console.WriteLine("• Sort() is medium (O(n log n))");

            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use List<T> when size is unknown or changes frequently");
            Console.WriteLine("• Initialize with capacity if you know approximate size");
            Console.WriteLine("• Use foreach for read-only iteration");
            Console.WriteLine("• Use for loop when you need index");
            Console.WriteLine("• Check Count before accessing elements");
            Console.WriteLine("• Use Contains() before Remove() to avoid errors");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't use List<T> if size is always fixed (use array)");
            Console.WriteLine("• Don't modify list while iterating with foreach");
            Console.WriteLine("• Don't use Insert(0, ...) frequently (very slow)");
            Console.WriteLine("• Don't forget to check bounds when accessing by index");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 List<T> Features:");
            Console.WriteLine("• Dynamic size (grows/shrinks automatically)");
            Console.WriteLine("• Type-safe (List<int>, List<string>, etc.)");
            Console.WriteLine("• Zero-indexed (first element at index 0)");
            Console.WriteLine("• Rich API (Add, Remove, Sort, Contains, etc.)");
            Console.WriteLine("• Part of System.Collections.Generic namespace");

            Console.WriteLine("\n🎯 Common Use Cases:");
            Console.WriteLine("• Shopping carts, inventories, player lists");
            Console.WriteLine("• High scores, leaderboards");
            Console.WriteLine("• Enemy spawners, active buffs/debuffs");
            Console.WriteLine("• Quest logs, dialogue options");
            Console.WriteLine("• Any collection with unknown or changing size");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• List<Enemy> enemies = new List<Enemy>();");
            Console.WriteLine("• List<Item> inventory = new List<Item>();");
            Console.WriteLine("• List<Player> onlinePlayers = new List<Player>();");
            Console.WriteLine("• List<Quest> activeQuests = new List<Quest>();");
            Console.WriteLine("• List<Vector3> waypoints = new List<Vector3>();");
        }

        // Helper method to print list elements
        static void PrintList<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("(empty)");
                return;
            }

            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}