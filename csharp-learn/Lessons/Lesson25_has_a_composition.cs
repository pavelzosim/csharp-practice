using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_learn.Lessons
{
    // LESSON 25: HAS-A Relationship (Composition)
    // Learn about object composition - when one class contains another class
    internal class Lesson25_has_a_composition
    {
        public static void Run()
        {
            // ===== TOPIC: HAS-A RELATIONSHIP (COMPOSITION) =====
            // Composition = When one class CONTAINS another class as a field/property
            // "HAS-A" relationship: Car HAS-A Engine, Person HAS-A Address
            // Think: Objects can be made up of other objects

            Console.WriteLine("=== HAS-A RELATIONSHIP (COMPOSITION) ===\n");

            // ===== WHAT IS COMPOSITION? =====

            Console.WriteLine("=== WHAT IS COMPOSITION? ===\n");

            Console.WriteLine("Composition (HAS-A) = One object CONTAINS another object:");
            Console.WriteLine("• A Car HAS-A Engine");
            Console.WriteLine("• A Person HAS-A Address");
            Console.WriteLine("• A Task HAS-A Performer (worker assigned to it)");
            Console.WriteLine("• A Board HAS many Tasks");
            Console.WriteLine();

            Console.WriteLine("Why use composition?");
            Console.WriteLine("• Reusability - use same objects in different contexts");
            Console.WriteLine("• Organization - group related data together");
            Console.WriteLine("• Flexibility - easily swap or modify components");
            Console.WriteLine("• Real-world modeling - mirrors real relationships");
            Console.WriteLine();

            // ===== EXAMPLE: TASK MANAGEMENT SYSTEM =====

            Console.WriteLine("=== TASK MANAGEMENT SYSTEM ===\n");

            // Create performers (workers)
            Performer alice = new Performer("Alice");
            Performer bob = new Performer("Bob");
            Performer charlie = new Performer("Charlie");

            Console.WriteLine("Created performers:");
            Console.WriteLine($"  - {alice.Name}");
            Console.WriteLine($"  - {bob.Name}");
            Console.WriteLine($"  - {charlie.Name}");
            Console.WriteLine();

            // Create tasks and assign performers to them
            // Task HAS-A Performer (composition!)
            Task task1 = new Task(alice, "Implement login feature");
            Task task2 = new Task(bob, "Fix database bug");
            Task task3 = new Task(charlie, "Write documentation");

            Console.WriteLine("Created tasks:");
            task1.ShowInfo();
            task2.ShowInfo();
            task3.ShowInfo();

            // Create task board containing multiple tasks
            // Board HAS-A collection of Tasks (composition!)
            Task[] allTasks = { task1, task2, task3 };
            Board projectBoard = new Board(allTasks);

            Console.WriteLine("=== PROJECT BOARD ===");
            projectBoard.ShowAllTasks();

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: PLAYER WITH INVENTORY =====

            Console.WriteLine("=== GAME DEV: PLAYER WITH INVENTORY ===\n");

            // Create items
            Item sword = new Item("Iron Sword", 1, 25);
            Item potion = new Item("Health Potion", 5, 0);
            Item shield = new Item("Wooden Shield", 1, 15);

            // Create inventory containing items
            // Inventory HAS-A list of Items
            Inventory playerInventory = new Inventory(10);
            playerInventory.AddItem(sword);
            playerInventory.AddItem(potion);
            playerInventory.AddItem(shield);

            // Create player with inventory
            // Player HAS-A Inventory (composition!)
            Player player = new Player("Hero", playerInventory);
            player.ShowInfo();

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: CAR WITH ENGINE =====

            Console.WriteLine("=== CAR WITH ENGINE ===\n");

            // Create engine
            Engine v8Engine = new Engine("V8", 450);
            Engine electricEngine = new Engine("Electric", 300);

            // Create cars with engines
            // Car HAS-A Engine (composition!)
            Car sportsCar = new Car("Ferrari", v8Engine);
            Car electricCar = new Car("Tesla", electricEngine);

            sportsCar.ShowInfo();
            sportsCar.Start();
            Console.WriteLine();

            electricCar.ShowInfo();
            electricCar.Start();

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: QUEST WITH REWARD =====

            Console.WriteLine("=== QUEST WITH REWARD ===\n");

            // Create rewards
            Reward goldReward = new Reward("Gold", 100);
            Reward xpReward = new Reward("Experience", 500);

            // Create quest with reward
            // Quest HAS-A Reward (composition!)
            Quest mainQuest = new Quest("Defeat Dragon", "Slay the ancient dragon", goldReward);
            Quest sideQuest = new Quest("Help Farmer", "Find lost sheep", xpReward);

            mainQuest.ShowInfo();
            mainQuest.Complete();
            Console.WriteLine();

            sideQuest.ShowInfo();
            sideQuest.Complete();

            Console.WriteLine();

            // ===== MULTIPLE COMPOSITION LEVELS =====

            Console.WriteLine("=== MULTIPLE COMPOSITION LEVELS ===\n");

            // Complex composition: Team -> Members -> Equipment
            Equipment helmet = new Equipment("Steel Helmet", 50);
            Equipment armor = new Equipment("Plate Armor", 100);

            TeamMember warrior = new TeamMember("Warrior", helmet, armor);
            TeamMember mage = new TeamMember("Mage", new Equipment("Wizard Hat", 30), new Equipment("Robe", 40));

            Team adventureTeam = new Team("Dragon Slayers");
            adventureTeam.AddMember(warrior);
            adventureTeam.AddMember(mage);

            adventureTeam.ShowTeamInfo();

            Console.WriteLine();

            // ===== COMPOSITION vs INHERITANCE =====

            Console.WriteLine("=== COMPOSITION vs INHERITANCE ===\n");

            Console.WriteLine("COMPOSITION (HAS-A):");
            Console.WriteLine("• Car HAS-A Engine");
            Console.WriteLine("• Player HAS-A Inventory");
            Console.WriteLine("• Task HAS-A Performer");
            Console.WriteLine("• Flexible - can change components at runtime");
            Console.WriteLine();

            Console.WriteLine("INHERITANCE (IS-A) - Lesson 26:");
            Console.WriteLine("• Dog IS-A Animal");
            Console.WriteLine("• Warrior IS-A Player");
            Console.WriteLine("• SportsCar IS-A Car");
            Console.WriteLine("• Fixed - inheritance structure set at compile time");
            Console.WriteLine();

            Console.WriteLine("When to use COMPOSITION:");
            Console.WriteLine("✅ When object contains/owns another object");
            Console.WriteLine("✅ When you need flexibility to change parts");
            Console.WriteLine("✅ When relationship is 'has' or 'contains'");
            Console.WriteLine("✅ When you want to reuse components");

            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use composition for HAS-A relationships");
            Console.WriteLine("• Initialize composed objects in constructor");
            Console.WriteLine("• Make composed objects private (encapsulation)");
            Console.WriteLine("• Provide methods to interact with composed objects");
            Console.WriteLine("• Use composition over inheritance when possible");
            Console.WriteLine("• Think 'what does this object CONTAIN?'");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't expose composed objects directly (breaks encapsulation)");
            Console.WriteLine("• Don't create circular references (A has B, B has A)");
            Console.WriteLine("• Don't forget to initialize composed objects");
            Console.WriteLine("• Don't use inheritance when composition is more appropriate");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Key Concepts:");
            Console.WriteLine("• Composition = One class contains another class");
            Console.WriteLine("• HAS-A relationship (not IS-A)");
            Console.WriteLine("• Objects made up of other objects");
            Console.WriteLine("• More flexible than inheritance");
            Console.WriteLine("• Pass objects as constructor parameters");

            Console.WriteLine("\n🎯 Real-World Examples:");
            Console.WriteLine("• Car HAS Engine, Wheels, Transmission");
            Console.WriteLine("• House HAS Rooms, Doors, Windows");
            Console.WriteLine("• Computer HAS CPU, RAM, Hard Drive");
            Console.WriteLine("• Book HAS Author, Publisher, Pages");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• Player HAS Inventory (items)");
            Console.WriteLine("• Quest HAS Reward (gold, XP)");
            Console.WriteLine("• Task HAS Performer (worker)");
            Console.WriteLine("• Team HAS Members (characters)");
            Console.WriteLine("• Weapon HAS Stats (damage, durability)");

            Console.WriteLine("\n💡 Remember:");
            Console.WriteLine("'Favor composition over inheritance'");
            Console.WriteLine("Composition is more flexible and easier to change!");

            Console.WriteLine("\n🔜 Next Topics:");
            Console.WriteLine("• Inheritance (IS-A relationship)");
            Console.WriteLine("• Polymorphism (method overriding)");
            Console.WriteLine("• Abstract classes and interfaces");
        }

        // ===== NESTED CLASSES =====

        // Performer class - represents a worker
        class Performer
        {
            public string Name;

            public Performer(string name)
            {
                Name = name;
            }
        }

        // Task class - HAS-A Performer (composition)
        class Task
        {
            public Performer Worker;    // Task HAS-A Performer
            public string Description;

            public Task(Performer worker, string description)
            {
                Worker = worker;
                Description = description;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Task: {Description}");
                Console.WriteLine($"  Assigned to: {Worker.Name}");
            }
        }

        // Board class - HAS many Tasks (composition)
        class Board
        {
            public Task[] Tasks;  // Board HAS-A collection of Tasks

            public Board(Task[] tasks)
            {
                Tasks = tasks;
            }

            public void ShowAllTasks()
            {
                Console.WriteLine("All tasks on board:");
                for (int i = 0; i < Tasks.Length; i++)
                {
                    Console.WriteLine($"\n{i + 1}.");
                    Tasks[i].ShowInfo();
                }
            }
        }

        // ===== GAME DEV EXAMPLES =====

        // Item class
        class Item
        {
            public string Name;
            public int Quantity;
            public int Value;

            public Item(string name, int quantity, int value)
            {
                Name = name;
                Quantity = quantity;
                Value = value;
            }
        }

        // Inventory class - HAS many Items
        class Inventory
        {
            private List<Item> _items;
            private int _maxSlots;

            public Inventory(int maxSlots)
            {
                _items = new List<Item>();
                _maxSlots = maxSlots;
            }

            public void AddItem(Item item)
            {
                if (_items.Count < _maxSlots)
                {
                    _items.Add(item);
                    Console.WriteLine($"Added {item.Name} to inventory");
                }
                else
                {
                    Console.WriteLine("Inventory is full!");
                }
            }

            public void ShowInventory()
            {
                Console.WriteLine("\n=== Inventory ===");
                foreach (Item item in _items)
                {
                    Console.WriteLine($"  {item.Name} x{item.Quantity} (Value: {item.Value})");
                }
            }
        }

        // Player class - HAS-A Inventory (composition)
        class Player
        {
            private string _name;
            private Inventory _inventory;  // Player HAS-A Inventory

            public Player(string name, Inventory inventory)
            {
                _name = name;
                _inventory = inventory;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Player: {_name}");
                _inventory.ShowInventory();
            }
        }

        // Engine class
        class Engine
        {
            public string Type;
            public int Horsepower;

            public Engine(string type, int horsepower)
            {
                Type = type;
                Horsepower = horsepower;
            }

            public void Start()
            {
                Console.WriteLine($"{Type} engine started! ({Horsepower} HP)");
            }
        }

        // Car class - HAS-A Engine (composition)
        class Car
        {
            private string _brand;
            private Engine _engine;  // Car HAS-A Engine

            public Car(string brand, Engine engine)
            {
                _brand = brand;
                _engine = engine;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Car: {_brand}");
                Console.WriteLine($"  Engine: {_engine.Type} ({_engine.Horsepower} HP)");
            }

            public void Start()
            {
                Console.Write($"{_brand} starting... ");
                _engine.Start();
            }
        }

        // Reward class
        class Reward
        {
            public string Type;
            public int Amount;

            public Reward(string type, int amount)
            {
                Type = type;
                Amount = amount;
            }

            public void Give()
            {
                Console.WriteLine($"  Received: {Amount} {Type}");
            }
        }

        // Quest class - HAS-A Reward (composition)
        class Quest
        {
            private string _title;
            private string _description;
            private Reward _reward;  // Quest HAS-A Reward
            private bool _isCompleted;

            public Quest(string title, string description, Reward reward)
            {
                _title = title;
                _description = description;
                _reward = reward;
                _isCompleted = false;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Quest: {_title}");
                Console.WriteLine($"  Description: {_description}");
                Console.WriteLine($"  Reward: {_reward.Amount} {_reward.Type}");
                Console.WriteLine($"  Status: {(_isCompleted ? "Completed" : "Active")}");
            }

            public void Complete()
            {
                if (!_isCompleted)
                {
                    _isCompleted = true;
                    Console.WriteLine($"✅ Quest '{_title}' completed!");
                    _reward.Give();
                }
            }
        }

        // Equipment class
        class Equipment
        {
            public string Name;
            public int Defense;

            public Equipment(string name, int defense)
            {
                Name = name;
                Defense = defense;
            }
        }

        // TeamMember class - HAS multiple Equipment items
        class TeamMember
        {
            private string _name;
            private Equipment _helmet;   // HAS-A Equipment
            private Equipment _armor;    // HAS-A Equipment

            public TeamMember(string name, Equipment helmet, Equipment armor)
            {
                _name = name;
                _helmet = helmet;
                _armor = armor;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"  Member: {_name}");
                Console.WriteLine($"    Helmet: {_helmet.Name} (Defense: {_helmet.Defense})");
                Console.WriteLine($"    Armor: {_armor.Name} (Defense: {_armor.Defense})");
                Console.WriteLine($"    Total Defense: {_helmet.Defense + _armor.Defense}");
            }
        }

        // Team class - HAS many TeamMembers
        class Team
        {
            private string _name;
            private List<TeamMember> _members;  // Team HAS many Members

            public Team(string name)
            {
                _name = name;
                _members = new List<TeamMember>();
            }

            public void AddMember(TeamMember member)
            {
                _members.Add(member);
            }

            public void ShowTeamInfo()
            {
                Console.WriteLine($"Team: {_name}");
                Console.WriteLine($"Members: {_members.Count}");
                foreach (TeamMember member in _members)
                {
                    member.ShowInfo();
                    Console.WriteLine();
                }
            }
        }
    }
}