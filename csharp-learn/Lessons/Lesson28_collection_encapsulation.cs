using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace csharp_learn.Lessons
{
    // LESSON 28: Collection Encapsulation Problems
    // Learn about common mistakes when exposing arrays/collections and how to fix them
    internal class Lesson28_collection_encapsulation
    {
        public static void Run()
        {
            // ===== TOPIC: COLLECTION ENCAPSULATION PROBLEMS =====
            // Problem: Exposing arrays/lists breaks encapsulation!
            // Reference types can be modified from outside
            // Think: Giving someone your house keys vs letting them visit

            Console.WriteLine("=== COLLECTION ENCAPSULATION PROBLEMS ===\n");

            // ===== THE PROBLEM: REFERENCE TYPE LEAK =====

            Console.WriteLine("=== PROBLEM: REFERENCE TYPE LEAK ===\n");

            Console.WriteLine("Arrays and Lists are REFERENCE TYPES:");
            Console.WriteLine("• When you return them, you return a REFERENCE (pointer)");
            Console.WriteLine("• External code can MODIFY the internal collection");
            Console.WriteLine("• Breaks encapsulation completely!");
            Console.WriteLine();

            // ===== PROBLEM DEMONSTRATION =====

            Console.WriteLine("=== PROBLEM DEMONSTRATION ===\n");

            BadInventory badInventory = new BadInventory();
            badInventory.AddItem("Sword");
            badInventory.AddItem("Shield");
            badInventory.AddItem("Potion");

            Console.WriteLine("Initial inventory:");
            badInventory.ShowItems();
            Console.WriteLine();

            // ❌ PROBLEM: Get reference to internal array
            string[] items = badInventory.GetItems();

            Console.WriteLine("💀 External code modifies internal array:");
            items[0] = "HACKED!";
            items[1] = null;
            items[2] = "CORRUPTED!";
            Console.WriteLine();

            Console.WriteLine("Inventory after external modification:");
            badInventory.ShowItems();
            Console.WriteLine("☠️ Encapsulation BROKEN! Internal data corrupted!");
            Console.WriteLine();

            // ===== SOLUTION 1: DEFENSIVE COPY (ARRAY) =====

            Console.WriteLine("=== SOLUTION 1: DEFENSIVE COPY (Array.Clone) ===\n");

            Console.WriteLine("Return a COPY of the array, not the original:");
            Console.WriteLine("  public string[] GetItems()");
            Console.WriteLine("  {");
            Console.WriteLine("      return (string[])_items.Clone();  // Returns copy");
            Console.WriteLine("  }");
            Console.WriteLine();

            GoodInventory1 goodInventory1 = new GoodInventory1();
            goodInventory1.AddItem("Sword");
            goodInventory1.AddItem("Shield");
            goodInventory1.AddItem("Potion");

            Console.WriteLine("Initial inventory:");
            goodInventory1.ShowItems();
            Console.WriteLine();

            // ✅ SAFE: Get COPY of array
            string[] itemsCopy = goodInventory1.GetItems();

            Console.WriteLine("✅ External code modifies THE COPY:");
            itemsCopy[0] = "Modified";
            itemsCopy[1] = "Changed";
            Console.WriteLine();

            Console.WriteLine("Inventory after external modification:");
            goodInventory1.ShowItems();
            Console.WriteLine("✅ Encapsulation PROTECTED! Internal data unchanged!");
            Console.WriteLine();

            // ===== SOLUTION 2: READONLY COLLECTION =====

            Console.WriteLine("=== SOLUTION 2: READONLY COLLECTION ===\n");

            Console.WriteLine("Return read-only wrapper around collection:");
            Console.WriteLine("  private List<string> _items;");
            Console.WriteLine("  public IReadOnlyList<string> Items");
            Console.WriteLine("  {");
            Console.WriteLine("      get { return _items.AsReadOnly(); }");
            Console.WriteLine("  }");
            Console.WriteLine();

            GoodInventory2 goodInventory2 = new GoodInventory2();
            goodInventory2.AddItem("Sword");
            goodInventory2.AddItem("Shield");
            goodInventory2.AddItem("Potion");

            Console.WriteLine("Initial inventory:");
            goodInventory2.ShowItems();
            Console.WriteLine();

            // ✅ SAFE: Get read-only collection
            IReadOnlyList<string> readOnlyItems = goodInventory2.Items;

            Console.WriteLine("✅ Read-only collection:");
            Console.WriteLine($"Can read: {readOnlyItems[0]}");
            // readOnlyItems[0] = "Hacked";  // ❌ COMPILE ERROR! Read-only!
            // readOnlyItems.Add("New");     // ❌ COMPILE ERROR! No Add method!
            Console.WriteLine("Cannot modify - compilation errors!");
            Console.WriteLine();

            // ===== SOLUTION 3: IENUMERABLE (ITERATOR) =====

            Console.WriteLine("=== SOLUTION 3: IEnumerable (Iterator) ===\n");

            Console.WriteLine("Return IEnumerable - can iterate but not modify:");
            Console.WriteLine("  private List<Item> _items;");
            Console.WriteLine("  public IEnumerable<Item> Items");
            Console.WriteLine("  {");
            Console.WriteLine("      get { return _items; }");
            Console.WriteLine("  }");
            Console.WriteLine();

            GoodInventory3 goodInventory3 = new GoodInventory3();
            goodInventory3.AddItem(new Item("Sword", 250));
            goodInventory3.AddItem(new Item("Shield", 150));
            goodInventory3.AddItem(new Item("Potion", 50));

            Console.WriteLine("Initial inventory:");
            goodInventory3.ShowItems();
            Console.WriteLine();

            // ✅ SAFE: Can iterate, but cannot modify collection
            Console.WriteLine("✅ Iterating through IEnumerable:");
            foreach (Item item in goodInventory3.Items)
            {
                Console.WriteLine($"  - {item.Name} (${item.Price})");
            }
            // Cannot: goodInventory3.Items[0] = ...  // No indexer!
            // Cannot: goodInventory3.Items.Add(...)  // No Add method!
            Console.WriteLine();

            // ===== SOLUTION 4: ENCAPSULATED METHODS =====

            Console.WriteLine("=== SOLUTION 4: ENCAPSULATED METHODS ===\n");

            Console.WriteLine("Don't expose collection at all - provide methods:");
            Console.WriteLine("  public void AddItem(string item) { ... }");
            Console.WriteLine("  public bool RemoveItem(string item) { ... }");
            Console.WriteLine("  public string GetItem(int index) { ... }");
            Console.WriteLine("  public int GetItemCount() { ... }");
            Console.WriteLine();

            GoodInventory4 goodInventory4 = new GoodInventory4();
            goodInventory4.AddItem("Sword");
            goodInventory4.AddItem("Shield");
            goodInventory4.AddItem("Potion");

            Console.WriteLine("Using encapsulated methods:");
            Console.WriteLine($"Item count: {goodInventory4.GetItemCount()}");
            Console.WriteLine($"Item at index 0: {goodInventory4.GetItem(0)}");
            Console.WriteLine($"Item at index 1: {goodInventory4.GetItem(1)}");
            Console.WriteLine();

            goodInventory4.RemoveItem("Shield");
            Console.WriteLine("After removing Shield:");
            goodInventory4.ShowItems();
            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: QUEST LOG =====

            Console.WriteLine("=== GAME DEV: QUEST LOG ===\n");

            QuestLog questLog = new QuestLog();
            questLog.AddQuest(new Quest("Defeat Dragon", 1000));
            questLog.AddQuest(new Quest("Save Village", 500));
            questLog.AddQuest(new Quest("Find Artifact", 800));

            Console.WriteLine("Quest log:");
            questLog.DisplayQuests();
            Console.WriteLine();

            // ✅ SAFE: Read-only access
            Console.WriteLine("Accessing quests through read-only collection:");
            foreach (Quest quest in questLog.ActiveQuests)
            {
                Console.WriteLine($"  - {quest.Title} ({quest.Reward} gold)");
            }
            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: PARTY MEMBERS =====

            Console.WriteLine("=== GAME DEV: PARTY MEMBERS ===\n");

            Party party = new Party("Dragon Slayers");
            party.AddMember(new PartyMember("Warrior", 100));
            party.AddMember(new PartyMember("Mage", 80));
            party.AddMember(new PartyMember("Healer", 70));

            Console.WriteLine($"Party: {party.Name}");
            Console.WriteLine($"Members: {party.MemberCount}");
            party.DisplayMembers();
            Console.WriteLine();

            // Safe iteration
            Console.WriteLine("Party members (safe iteration):");
            foreach (PartyMember member in party.Members)
            {
                Console.WriteLine($"  - {member.Name} (HP: {member.Health})");
            }
            Console.WriteLine();

            // ===== COMPARISON TABLE =====

            Console.WriteLine("=== SOLUTION COMPARISON ===\n");

            Console.WriteLine("┌──────────────────┬────────────┬──────────────┬─────────────┐");
            Console.WriteLine("│ Solution         │ Safety     │ Performance  │ Flexibility │");
            Console.WriteLine("├──────────────────┼────────────┼──────────────┼─────────────┤");
            Console.WriteLine("│ Defensive Copy   │ ✅ High    │ ⚠️ Medium    │ ✅ High     │");
            Console.WriteLine("│ ReadOnly Wrapper │ ✅ High    │ ✅ Good      │ 🔄 Medium   │");
            Console.WriteLine("│ IEnumerable      │ ✅ High    │ ✅ Best      │ 🔄 Medium   │");
            Console.WriteLine("│ Methods Only     │ ✅ Highest │ ✅ Good      │ ❌ Limited  │");
            Console.WriteLine("└──────────────────┴────────────┴──────────────┴─────────────┘");
            Console.WriteLine();

            // ===== WHEN TO USE WHAT =====

            Console.WriteLine("=== WHEN TO USE EACH SOLUTION ===\n");

            Console.WriteLine("1️⃣ Defensive Copy (Array.Clone, ToArray):");
            Console.WriteLine("  ✅ Use when: Need to return array snapshot");
            Console.WriteLine("  ✅ Use when: External code needs full array access");
            Console.WriteLine("  ⚠️ Cost: Memory allocation + copying");
            Console.WriteLine();

            Console.WriteLine("2️⃣ ReadOnly Collection (AsReadOnly):");
            Console.WriteLine("  ✅ Use when: Need indexed access but no modification");
            Console.WriteLine("  ✅ Use when: Using List<T> internally");
            Console.WriteLine("  ⚠️ Note: Wrapper, not a copy");
            Console.WriteLine();

            Console.WriteLine("3️⃣ IEnumerable (Iterator):");
            Console.WriteLine("  ✅ Use when: Only need to iterate (foreach)");
            Console.WriteLine("  ✅ Use when: Maximum performance (no copy)");
            Console.WriteLine("  ✅ Best: Most common and recommended");
            Console.WriteLine();

            Console.WriteLine("4️⃣ Encapsulated Methods:");
            Console.WriteLine("  ✅ Use when: Need full control over operations");
            Console.WriteLine("  ✅ Use when: Complex validation/business logic");
            Console.WriteLine("  ⚠️ Note: More code, less flexible");
            Console.WriteLine();

            // ===== COMMON MISTAKES =====

            Console.WriteLine("=== COMMON MISTAKES ===\n");

            Console.WriteLine("❌ MISTAKE 1: Public array field");
            Console.WriteLine("  public string[] Items;  // Anyone can replace array!");
            Console.WriteLine();

            Console.WriteLine("❌ MISTAKE 2: Property returns internal array");
            Console.WriteLine("  private string[] _items;");
            Console.WriteLine("  public string[] Items { get { return _items; } }  // Leak!");
            Console.WriteLine();

            Console.WriteLine("❌ MISTAKE 3: Auto-property with collection");
            Console.WriteLine("  public List<string> Items { get; set; }  // Direct access!");
            Console.WriteLine();

            Console.WriteLine("❌ MISTAKE 4: Forgetting arrays are reference types");
            Console.WriteLine("  // Arrays/Lists are NOT copied when assigned!");
            Console.WriteLine("  var copy = originalArray;  // Same reference, not copy!");
            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Keep collections PRIVATE");
            Console.WriteLine("• Return IEnumerable<T> for iteration");
            Console.WriteLine("• Return IReadOnlyList<T> for indexed access");
            Console.WriteLine("• Use defensive copying when needed");
            Console.WriteLine("• Provide encapsulated Add/Remove methods");
            Console.WriteLine("• Validate all modifications");
            Console.WriteLine("• Document whether return value is a copy");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't expose arrays/lists as public fields");
            Console.WriteLine("• Don't return internal collections directly");
            Console.WriteLine("• Don't use auto-properties for collections");
            Console.WriteLine("• Don't forget arrays are reference types");
            Console.WriteLine("• Don't allow external code to modify internal state");
            Console.WriteLine("• Don't assume assignment creates a copy");

            Console.WriteLine();

            // ===== PERFORMANCE CONSIDERATIONS =====

            Console.WriteLine("=== PERFORMANCE CONSIDERATIONS ===\n");

            Console.WriteLine("Performance cost of each solution:");
            Console.WriteLine();

            Console.WriteLine("IEnumerable (Iterator):");
            Console.WriteLine("  • Cost: Zero (no copying)");
            Console.WriteLine("  • Speed: ⚡⚡⚡ Fastest");
            Console.WriteLine("  • Memory: ✅ No extra allocation");
            Console.WriteLine();

            Console.WriteLine("ReadOnly Wrapper:");
            Console.WriteLine("  • Cost: One wrapper object allocation");
            Console.WriteLine("  • Speed: ⚡⚡ Very fast");
            Console.WriteLine("  • Memory: ✅ Minimal (just wrapper)");
            Console.WriteLine();

            Console.WriteLine("Defensive Copy (Clone/ToArray):");
            Console.WriteLine("  • Cost: Copy entire array/list");
            Console.WriteLine("  • Speed: ⚠️ Slower (O(n) copying)");
            Console.WriteLine("  • Memory: ⚠️ Doubles memory usage");
            Console.WriteLine();

            Console.WriteLine("Recommendation: Use IEnumerable for best performance!");
            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Key Concepts:");
            Console.WriteLine("• Arrays/Lists are REFERENCE TYPES");
            Console.WriteLine("• Returning them exposes internal state");
            Console.WriteLine("• External code can modify internal collections");
            Console.WriteLine("• This BREAKS encapsulation completely");
            Console.WriteLine("• Always protect collections from external modification");

            Console.WriteLine("\n🎯 Solutions:");
            Console.WriteLine("1. Defensive Copy - Clone() or ToArray()");
            Console.WriteLine("2. ReadOnly Wrapper - AsReadOnly()");
            Console.WriteLine("3. IEnumerable - Best for iteration");
            Console.WriteLine("4. Methods Only - Full control");

            Console.WriteLine("\n💡 Golden Rule:");
            Console.WriteLine("Never expose internal collections directly!");
            Console.WriteLine("Use IEnumerable<T> or IReadOnlyList<T> for safe access.");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• Quest Log - read-only quest list");
            Console.WriteLine("• Party Members - safe iteration");
            Console.WriteLine("• Inventory - controlled add/remove");
            Console.WriteLine("• Active Buffs - time-limited effects");

            Console.WriteLine("\n🔜 Next Topics:");
            Console.WriteLine("• Polymorphism (virtual methods, overriding)");
            Console.WriteLine("• Abstract classes (incomplete base classes)");
            Console.WriteLine("• Interfaces (contracts for classes)");
            Console.WriteLine("• LINQ with collections");
        }

        // ===== NESTED CLASSES =====

        // ❌ BAD EXAMPLE: Exposes internal array
        class BadInventory
        {
            private string[] _items = new string[10];
            private int _count = 0;

            public void AddItem(string item)
            {
                if (_count < _items.Length)
                {
                    _items[_count] = item;
                    _count++;
                }
            }

            // ❌ DANGEROUS: Returns reference to internal array!
            public string[] GetItems()
            {
                return _items;  // External code can modify this!
            }

            public void ShowItems()
            {
                Console.WriteLine("Items:");
                for (int i = 0; i < _count; i++)
                {
                    Console.WriteLine($"  {i}: {_items[i]}");
                }
            }
        }

        // ✅ SOLUTION 1: Defensive copy
        class GoodInventory1
        {
            private string[] _items = new string[10];
            private int _count = 0;

            public void AddItem(string item)
            {
                if (_count < _items.Length)
                {
                    _items[_count] = item;
                    _count++;
                }
            }

            // ✅ SAFE: Returns COPY of array
            public string[] GetItems()
            {
                string[] copy = new string[_count];
                Array.Copy(_items, copy, _count);
                return copy;  // Returns copy, not original
            }

            public void ShowItems()
            {
                Console.WriteLine("Items:");
                for (int i = 0; i < _count; i++)
                {
                    Console.WriteLine($"  {i}: {_items[i]}");
                }
            }
        }

        // ✅ SOLUTION 2: ReadOnly collection
        class GoodInventory2
        {
            private List<string> _items = new List<string>();

            public void AddItem(string item)
            {
                _items.Add(item);
            }

            // ✅ SAFE: Returns read-only wrapper
            public IReadOnlyList<string> Items
            {
                get { return _items.AsReadOnly(); }
            }

            public void ShowItems()
            {
                Console.WriteLine("Items:");
                for (int i = 0; i < _items.Count; i++)
                {
                    Console.WriteLine($"  {i}: {_items[i]}");
                }
            }
        }

        // Item class for Solution 3
        class Item
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public Item(string name, int price)
            {
                Name = name;
                Price = price;
            }
        }

        // ✅ SOLUTION 3: IEnumerable (best for iteration)
        class GoodInventory3
        {
            private List<Item> _items = new List<Item>();

            public void AddItem(Item item)
            {
                _items.Add(item);
            }

            // ✅ SAFE: Returns IEnumerable (can iterate, can't modify)
            public IEnumerable<Item> Items
            {
                get { return _items; }
            }

            public void ShowItems()
            {
                Console.WriteLine("Items:");
                foreach (Item item in _items)
                {
                    Console.WriteLine($"  - {item.Name} (${item.Price})");
                }
            }
        }

        // ✅ SOLUTION 4: Encapsulated methods only
        class GoodInventory4
        {
            private List<string> _items = new List<string>();

            public void AddItem(string item)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    _items.Add(item);
                }
            }

            public bool RemoveItem(string item)
            {
                return _items.Remove(item);
            }

            public string GetItem(int index)
            {
                if (index >= 0 && index < _items.Count)
                {
                    return _items[index];
                }
                return null;
            }

            public int GetItemCount()
            {
                return _items.Count;
            }

            public void ShowItems()
            {
                Console.WriteLine("Items:");
                for (int i = 0; i < _items.Count; i++)
                {
                    Console.WriteLine($"  {i}: {_items[i]}");
                }
            }
        }

        // Quest class for game dev example
        class Quest
        {
            public string Title { get; private set; }
            public int Reward { get; private set; }

            public Quest(string title, int reward)
            {
                Title = title;
                Reward = reward;
            }
        }

        // Quest log with read-only collection
        class QuestLog
        {
            private List<Quest> _quests = new List<Quest>();

            public void AddQuest(Quest quest)
            {
                _quests.Add(quest);
                Console.WriteLine($"Quest added: {quest.Title}");
            }

            public IReadOnlyList<Quest> ActiveQuests
            {
                get { return _quests.AsReadOnly(); }
            }

            public void DisplayQuests()
            {
                for (int i = 0; i < _quests.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}. {_quests[i].Title} - {_quests[i].Reward} gold");
                }
            }
        }

        // Party member class
        class PartyMember
        {
            public string Name { get; private set; }
            public int Health { get; private set; }

            public PartyMember(string name, int health)
            {
                Name = name;
                Health = health;
            }
        }

        // Party with safe member access
        class Party
        {
            public string Name { get; private set; }
            private List<PartyMember> _members = new List<PartyMember>();

            public Party(string name)
            {
                Name = name;
            }

            public void AddMember(PartyMember member)
            {
                if (_members.Count < 4)  // Max 4 members
                {
                    _members.Add(member);
                    Console.WriteLine($"{member.Name} joined the party!");
                }
                else
                {
                    Console.WriteLine("Party is full!");
                }
            }

            public int MemberCount
            {
                get { return _members.Count; }
            }

            // Safe iteration through IEnumerable
            public IEnumerable<PartyMember> Members
            {
                get { return _members; }
            }

            public void DisplayMembers()
            {
                foreach (PartyMember member in _members)
                {
                    Console.WriteLine($"  - {member.Name} (HP: {member.Health})");
                }
            }
        }
    }
}