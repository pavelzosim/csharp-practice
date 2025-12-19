using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_learn.Lessons
{
    // LESSON 20: Dictionary<TKey, TValue> Collection
    // Learn about key-value pairs for fast lookups and data mapping
    internal class Lesson20_dictionary
    {
        public static void Run()
        {
            // ===== TOPIC: DICTIONARY COLLECTION =====
            // Dictionary = Collection of KEY-VALUE pairs
            // Like a real dictionary: WORD (key) → DEFINITION (value)
            // Or phone book: NAME (key) → PHONE NUMBER (value)
            // FAST lookups by key - O(1) average performance!

            Console.WriteLine("=== DICTIONARY<TKey, TValue> COLLECTION ===\n");

            // ===== WHAT IS A DICTIONARY? =====

            Console.WriteLine("=== WHAT IS A DICTIONARY? ===\n");

            Console.WriteLine("Dictionary stores KEY-VALUE pairs:");
            Console.WriteLine("• Key: Unique identifier (like player name, user ID)");
            Console.WriteLine("• Value: Data associated with that key (like score, email)");
            Console.WriteLine();

            Console.WriteLine("Real-world analogies:");
            Console.WriteLine("• Phone book: Name → Phone number");
            Console.WriteLine("• Dictionary: Word → Definition");
            Console.WriteLine("• Game: PlayerID → PlayerData");
            Console.WriteLine("• Settings: SettingName → SettingValue");
            Console.WriteLine();

            // ===== CREATING DICTIONARIES =====

            Console.WriteLine("=== CREATING DICTIONARIES ===\n");

            // Create empty dictionary
            Dictionary<string, int> ages = new Dictionary<string, int>();
            Console.WriteLine($"Empty dictionary count: {ages.Count}");

            // Create with initial capacity (optimization)
            Dictionary<int, string> playerNames = new Dictionary<int, string>(10);
            Console.WriteLine($"Dictionary with capacity count: {playerNames.Count}");

            // Create with collection initializer
            Dictionary<string, string> capitals = new Dictionary<string, string>
            {
                { "USA", "Washington D.C." },
                { "France", "Paris" },
                { "Japan", "Tokyo" },
                { "Germany", "Berlin" }
            };
            Console.WriteLine($"Initialized dictionary count: {capitals.Count}");

            // Different key-value type combinations
            Dictionary<int, string> idToName = new Dictionary<int, string>();      // int → string
            Dictionary<string, float> itemPrices = new Dictionary<string, float>(); // string → float
            Dictionary<string, bool> settings = new Dictionary<string, bool>();    // string → bool

            Console.WriteLine();

            // ===== ADDING ELEMENTS =====

            Console.WriteLine("=== ADDING ELEMENTS ===\n");

            Dictionary<string, int> scores = new Dictionary<string, int>();

            // Method 1: Add() - throws exception if key exists
            scores.Add("Alice", 100);
            scores.Add("Bob", 85);
            scores.Add("Charlie", 92);
            Console.WriteLine($"After Add(): Count = {scores.Count}");

            // Method 2: Indexer [] - overwrites if key exists
            scores["Dave"] = 78;  // Adds new entry
            Console.WriteLine($"After []: Count = {scores.Count}");

            scores["Alice"] = 105; // Updates existing value (no exception!)
            Console.WriteLine($"Alice's new score: {scores["Alice"]}");

            // ❌ This would throw exception (key already exists)
            // scores.Add("Bob", 90); // KeyAlreadyExistsException!

            Console.WriteLine();

            // ===== ACCESSING ELEMENTS =====

            Console.WriteLine("=== ACCESSING ELEMENTS ===\n");

            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                { "Alice", "555-1234" },
                { "Bob", "555-5678" },
                { "Charlie", "555-9999" }
            };

            // Access by key using []
            string alicePhone = phoneBook["Alice"];
            Console.WriteLine($"Alice's phone: {alicePhone}");

            // ❌ UNSAFE - throws exception if key doesn't exist
            // string evePhone = phoneBook["Eve"]; // KeyNotFoundException!

            // ✅ SAFE - Check if key exists first
            if (phoneBook.ContainsKey("Bob"))
            {
                Console.WriteLine($"Bob's phone: {phoneBook["Bob"]}");
            }

            // ✅ SAFE - TryGetValue (recommended!)
            if (phoneBook.TryGetValue("Charlie", out string charliePhone))
            {
                Console.WriteLine($"Charlie's phone: {charliePhone}");
            }
            else
            {
                Console.WriteLine("Charlie not found");
            }

            // TryGetValue with non-existing key
            if (phoneBook.TryGetValue("Eve", out string evePhone))
            {
                Console.WriteLine($"Eve's phone: {evePhone}");
            }
            else
            {
                Console.WriteLine("Eve not in phone book");
            }

            Console.WriteLine();

            // ===== UPDATING ELEMENTS =====

            Console.WriteLine("=== UPDATING ELEMENTS ===\n");

            Dictionary<string, int> inventory = new Dictionary<string, int>
            {
                { "Sword", 5 },
                { "Potion", 10 },
                { "Shield", 3 }
            };

            Console.WriteLine($"Potions before: {inventory["Potion"]}");

            // Update using []
            inventory["Potion"] = 15;
            Console.WriteLine($"Potions after: {inventory["Potion"]}");

            // Update conditionally
            if (inventory.ContainsKey("Sword"))
            {
                inventory["Sword"] += 2; // Add 2 more swords
                Console.WriteLine($"Swords after adding: {inventory["Sword"]}");
            }

            Console.WriteLine();

            // ===== REMOVING ELEMENTS =====

            Console.WriteLine("=== REMOVING ELEMENTS ===\n");

            Dictionary<string, int> testDict = new Dictionary<string, int>
            {
                { "A", 10 },
                { "B", 20 },
                { "C", 30 },
                { "D", 40 }
            };

            Console.WriteLine($"Count before removal: {testDict.Count}");

            // Remove by key - returns true if removed, false if not found
            bool removed = testDict.Remove("B");
            Console.WriteLine($"Removed 'B': {removed}");
            Console.WriteLine($"Count after removal: {testDict.Count}");

            // Try removing non-existing key
            bool removed2 = testDict.Remove("Z");
            Console.WriteLine($"Removed 'Z': {removed2}");

            // Clear all elements
            testDict.Clear();
            Console.WriteLine($"Count after clear: {testDict.Count}");

            Console.WriteLine();

            // ===== CHECKING KEYS AND VALUES =====

            Console.WriteLine("=== CHECKING KEYS AND VALUES ===\n");

            Dictionary<string, int> highScores = new Dictionary<string, int>
            {
                { "Player1", 1000 },
                { "Player2", 850 },
                { "Player3", 920 }
            };

            // Check if key exists
            bool hasPlayer1 = highScores.ContainsKey("Player1");
            Console.WriteLine($"Contains 'Player1': {hasPlayer1}");

            // Check if value exists (slower - searches all values)
            bool hasScore1000 = highScores.ContainsValue(1000);
            Console.WriteLine($"Contains score 1000: {hasScore1000}");

            Console.WriteLine();

            // ===== ITERATING THROUGH DICTIONARY =====

            Console.WriteLine("=== ITERATING THROUGH DICTIONARY ===\n");

            Dictionary<string, string> countries = new Dictionary<string, string>
            {
                { "USA", "Washington D.C." },
                { "UK", "London" },
                { "Japan", "Tokyo" }
            };

            // Method 1: Iterate through KeyValuePair
            Console.WriteLine("Method 1: KeyValuePair");
            foreach (KeyValuePair<string, string> entry in countries)
            {
                Console.WriteLine($"  {entry.Key} → {entry.Value}");
            }
            Console.WriteLine();

            // Method 2: Use var for shorter syntax
            Console.WriteLine("Method 2: var (same as above)");
            foreach (var entry in countries)
            {
                Console.WriteLine($"  {entry.Key} → {entry.Value}");
            }
            Console.WriteLine();

            // Method 3: Iterate through keys only
            Console.WriteLine("Method 3: Keys only");
            foreach (string country in countries.Keys)
            {
                Console.WriteLine($"  Country: {country}");
            }
            Console.WriteLine();

            // Method 4: Iterate through values only
            Console.WriteLine("Method 4: Values only");
            foreach (string capital in countries.Values)
            {
                Console.WriteLine($"  Capital: {capital}");
            }
            Console.WriteLine();

            // ===== KEYS AND VALUES COLLECTIONS =====

            Console.WriteLine("=== KEYS AND VALUES COLLECTIONS ===\n");

            Dictionary<int, string> players = new Dictionary<int, string>
            {
                { 1, "Alice" },
                { 2, "Bob" },
                { 3, "Charlie" }
            };

            // Get all keys
            Dictionary<int, string>.KeyCollection keys = players.Keys;
            Console.WriteLine($"Keys count: {keys.Count}");
            Console.Write("Keys: ");
            foreach (int key in keys)
            {
                Console.Write(key + " ");
            }
            Console.WriteLine();

            // Get all values
            Dictionary<int, string>.ValueCollection values = players.Values;
            Console.WriteLine($"Values count: {values.Count}");
            Console.Write("Values: ");
            foreach (string value in values)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine("\n");

            // Convert to arrays
            int[] keyArray = players.Keys.ToArray();
            string[] valueArray = players.Values.ToArray();
            Console.WriteLine($"Key array length: {keyArray.Length}");
            Console.WriteLine($"Value array length: {valueArray.Length}");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: PLAYER STATS =====

            Console.WriteLine("=== PRACTICAL EXAMPLE: PLAYER STATS ===\n");

            Dictionary<string, int> playerStats = new Dictionary<string, int>();

            // Add player stats
            playerStats["Health"] = 100;
            playerStats["Mana"] = 50;
            playerStats["Strength"] = 15;
            playerStats["Defense"] = 10;

            Console.WriteLine("=== Player Stats ===");
            foreach (var stat in playerStats)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value}");
            }
            Console.WriteLine();

            // Update stats
            playerStats["Health"] -= 20; // Take damage
            playerStats["Mana"] += 10;   // Restore mana

            Console.WriteLine("=== After Combat ===");
            foreach (var stat in playerStats)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value}");
            }

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: INVENTORY SYSTEM =====

            Console.WriteLine("=== PRACTICAL EXAMPLE: INVENTORY SYSTEM ===\n");

            Dictionary<string, int> playerInventory = new Dictionary<string, int>();

            // Add items
            AddItem(playerInventory, "Health Potion", 5);
            AddItem(playerInventory, "Mana Potion", 3);
            AddItem(playerInventory, "Sword", 1);

            Console.WriteLine("Initial inventory:");
            PrintInventory(playerInventory);

            // Use item
            UseItem(playerInventory, "Health Potion", 2);

            Console.WriteLine("\nAfter using 2 Health Potions:");
            PrintInventory(playerInventory);

            // Try to use more than available
            UseItem(playerInventory, "Mana Potion", 5);

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: WORD FREQUENCY COUNTER =====

            Console.WriteLine("=== PRACTICAL EXAMPLE: WORD FREQUENCY ===\n");

            string text = "hello world hello programming world world";
            Dictionary<string, int> wordCount = CountWords(text);

            Console.WriteLine("Word frequencies:");
            foreach (var entry in wordCount)
            {
                Console.WriteLine($"  '{entry.Key}' appears {entry.Value} time(s)");
            }

            Console.WriteLine();

            // ===== GAME DEV EXAMPLES =====

            Console.WriteLine("=== GAME DEV EXAMPLES ===\n");

            // Example 1: Player lookup by ID
            Dictionary<int, string> onlinePlayers = new Dictionary<int, string>
            {
                { 101, "PlayerOne" },
                { 102, "PlayerTwo" },
                { 103, "PlayerThree" }
            };

            Console.WriteLine("Online players:");
            foreach (var player in onlinePlayers)
            {
                Console.WriteLine($"  ID {player.Key}: {player.Value}");
            }
            Console.WriteLine();

            // Example 2: Game settings
            Dictionary<string, bool> gameSettings = new Dictionary<string, bool>
            {
                { "SoundEnabled", true },
                { "MusicEnabled", true },
                { "FullScreen", false },
                { "VSync", true }
            };

            Console.WriteLine("Game settings:");
            foreach (var setting in gameSettings)
            {
                Console.WriteLine($"  {setting.Key}: {(setting.Value ? "ON" : "OFF")}");
            }
            Console.WriteLine();

            // Toggle setting
            gameSettings["MusicEnabled"] = !gameSettings["MusicEnabled"];
            Console.WriteLine($"Music toggled to: {(gameSettings["MusicEnabled"] ? "ON" : "OFF")}");

            Console.WriteLine();

            // Example 3: Item prices
            Dictionary<string, float> shopPrices = new Dictionary<string, float>
            {
                { "Health Potion", 10.5f },
                { "Mana Potion", 8.0f },
                { "Sword", 250.0f },
                { "Armor", 500.0f }
            };

            Console.WriteLine("Shop prices:");
            foreach (var item in shopPrices)
            {
                Console.WriteLine($"  {item.Key}: ${item.Value:F2}");
            }

            Console.WriteLine();

            // Example 4: Quest status tracking
            Dictionary<string, string> questStatus = new Dictionary<string, string>
            {
                { "Main Quest 1", "Completed" },
                { "Side Quest 1", "In Progress" },
                { "Main Quest 2", "Not Started" }
            };

            Console.WriteLine("Quest log:");
            foreach (var quest in questStatus)
            {
                Console.WriteLine($"  {quest.Key}: {quest.Value}");
            }

            Console.WriteLine();

            // ===== ADVANCED: DICTIONARY OF LISTS =====

            Console.WriteLine("=== ADVANCED: DICTIONARY OF LISTS ===\n");

            // Dictionary where values are lists (one-to-many relationship)
            Dictionary<string, List<string>> teamRoster = new Dictionary<string, List<string>>
            {
                { "Red Team", new List<string> { "Alice", "Bob", "Charlie" } },
                { "Blue Team", new List<string> { "Dave", "Eve", "Frank" } }
            };

            Console.WriteLine("Team rosters:");
            foreach (var team in teamRoster)
            {
                Console.WriteLine($"{team.Key}:");
                foreach (string player in team.Value)
                {
                    Console.WriteLine($"  - {player}");
                }
            }

            Console.WriteLine();

            // ===== PERFORMANCE COMPARISON =====

            Console.WriteLine("=== PERFORMANCE COMPARISON ===\n");

            Console.WriteLine("📊 Dictionary vs List for lookups:");
            Console.WriteLine();

            // List - must search through all elements (slow)
            List<string> nameList = new List<string> { "Alice", "Bob", "Charlie", "Dave" };
            Console.WriteLine("List lookup: O(n) - linear time");
            Console.WriteLine("  Must check each element until found");
            Console.WriteLine("  10,000 items = up to 10,000 checks");
            Console.WriteLine();

            // Dictionary - direct hash lookup (fast!)
            Dictionary<string, int> nameDict = new Dictionary<string, int>
            {
                { "Alice", 1 },
                { "Bob", 2 },
                { "Charlie", 3 },
                { "Dave", 4 }
            };
            Console.WriteLine("Dictionary lookup: O(1) - constant time");
            Console.WriteLine("  Direct access using hash");
            Console.WriteLine("  10,000 items = still 1 check!");

            Console.WriteLine();

            // ===== PERFORMANCE NOTES =====

            Console.WriteLine("=== PERFORMANCE ===\n");

            Console.WriteLine("⚡ Dictionary Performance:");
            Console.WriteLine("• Add/[]: O(1) - very fast");
            Console.WriteLine("• Remove: O(1) - very fast");
            Console.WriteLine("• ContainsKey: O(1) - very fast");
            Console.WriteLine("• TryGetValue: O(1) - very fast");
            Console.WriteLine("• ContainsValue: O(n) - slow (searches all values)");
            Console.WriteLine();

            Console.WriteLine("🎯 Dictionary is OPTIMIZED for fast key lookups!");
            Console.WriteLine("Use when you need to frequently find items by unique identifier");

            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use TryGetValue() instead of ContainsKey + []");
            Console.WriteLine("• Use ContainsKey() before adding with Add()");
            Console.WriteLine("• Use [] for adding/updating (no exception)");
            Console.WriteLine("• Choose appropriate key type (int, string, etc.)");
            Console.WriteLine("• Use for player data, settings, caches, lookups");
            Console.WriteLine("• Keys should be immutable (don't change after adding)");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't use [] to access non-existing keys (exception!)");
            Console.WriteLine("• Don't use Add() if key might exist (use [] instead)");
            Console.WriteLine("• Don't use ContainsValue frequently (slow)");
            Console.WriteLine("• Don't modify keys after adding to dictionary");
            Console.WriteLine("• Don't use Dictionary if order matters (use List)");

            Console.WriteLine();

            // ===== TRYGETVALUE PATTERN (BEST PRACTICE) =====

            Console.WriteLine("=== TRYGETVALUE PATTERN (RECOMMENDED) ===\n");

            Dictionary<string, int> data = new Dictionary<string, int>
            {
                { "A", 10 },
                { "B", 20 }
            };

            // ❌ BAD - Two lookups!
            Console.WriteLine("Bad pattern (2 lookups):");
            if (data.ContainsKey("A"))
            {
                int value = data["A"]; // Second lookup!
                Console.WriteLine($"  Value: {value}");
            }

            // ✅ GOOD - One lookup!
            Console.WriteLine("\nGood pattern (1 lookup):");
            if (data.TryGetValue("A", out int result))
            {
                Console.WriteLine($"  Value: {result}");
            }

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Dictionary<TKey, TValue> Features:");
            Console.WriteLine("• Stores KEY-VALUE pairs");
            Console.WriteLine("• Keys must be UNIQUE");
            Console.WriteLine("• O(1) average lookup time (very fast!)");
            Console.WriteLine("• Unordered collection (no guaranteed order)");
            Console.WriteLine("• Keys must be immutable types");

            Console.WriteLine("\n🎯 When to use Dictionary:");
            Console.WriteLine("• Player data (ID → PlayerData)");
            Console.WriteLine("• Game settings (Name → Value)");
            Console.WriteLine("• Item prices (ItemName → Price)");
            Console.WriteLine("• Caching/Memoization (Input → Result)");
            Console.WriteLine("• Translations (Word → Translation)");
            Console.WriteLine("• Any fast lookup by unique identifier");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• Dictionary<int, Player> players - player lookup by ID");
            Console.WriteLine("• Dictionary<string, Item> items - item lookup by name");
            Console.WriteLine("• Dictionary<string, bool> settings - game settings");
            Console.WriteLine("• Dictionary<string, float> prices - shop prices");
            Console.WriteLine("• Dictionary<Vector3, GameObject> grid - spatial lookup");

            Console.WriteLine("\n🔑 Key Points:");
            Console.WriteLine("• List: Index (0,1,2...) → Value");
            Console.WriteLine("• Dictionary: Custom Key → Value");
            Console.WriteLine("• List is ordered, Dictionary is not");
            Console.WriteLine("• Dictionary is much faster for lookups!");

            Console.WriteLine("\n💡 Real-world comparison:");
            Console.WriteLine("List = Looking through a stack of papers one by one");
            Console.WriteLine("Dictionary = Looking up a word in a dictionary index");
        }

        // ===== HELPER METHODS =====

        // Add item to inventory
        static void AddItem(Dictionary<string, int> inventory, string itemName, int quantity)
        {
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
                Console.WriteLine($"Added {quantity} {itemName}(s). Total: {inventory[itemName]}");
            }
            else
            {
                inventory[itemName] = quantity;
                Console.WriteLine($"Added {quantity} {itemName}(s) (new item)");
            }
        }

        // Use item from inventory
        static void UseItem(Dictionary<string, int> inventory, string itemName, int quantity)
        {
            if (inventory.TryGetValue(itemName, out int currentQuantity))
            {
                if (currentQuantity >= quantity)
                {
                    inventory[itemName] -= quantity;
                    Console.WriteLine($"Used {quantity} {itemName}(s). Remaining: {inventory[itemName]}");

                    // Remove if quantity reaches 0
                    if (inventory[itemName] == 0)
                    {
                        inventory.Remove(itemName);
                        Console.WriteLine($"{itemName} removed from inventory (depleted)");
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough {itemName}! Have {currentQuantity}, need {quantity}");
                }
            }
            else
            {
                Console.WriteLine($"{itemName} not found in inventory!");
            }
        }

        // Print inventory contents
        static void PrintInventory(Dictionary<string, int> inventory)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("  (Inventory is empty)");
                return;
            }

            foreach (var item in inventory)
            {
                Console.WriteLine($"  {item.Key}: {item.Value}");
            }
        }

        // Count word frequency
        static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            return wordCount;
        }
    }
}