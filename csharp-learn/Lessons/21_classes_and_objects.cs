using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_learn.Lessons
{
    // LESSON 21: Classes and Objects (OOP Basics)
    // Learn about Object-Oriented Programming - creating custom types with data and behavior
    internal class Lesson21_classes_and_objects
    {
        public static void Run()
        {
            // ===== TOPIC: CLASSES AND OBJECTS =====
            // Class = Blueprint/Template for creating objects
            // Object = Instance of a class (actual thing created from blueprint)
            // Think: Class = "Car blueprint", Object = "Your actual car"

            Console.WriteLine("=== CLASSES AND OBJECTS (OOP) ===\n");

            // ===== WHAT ARE CLASSES AND OBJECTS? =====

            Console.WriteLine("=== WHAT ARE CLASSES AND OBJECTS? ===\n");

            Console.WriteLine("CLASS = Blueprint/Template:");
            Console.WriteLine("  Like a cookie cutter - defines the shape");
            Console.WriteLine("  Contains: Properties (data) + Methods (behavior)");
            Console.WriteLine("  Example: 'Player' class defines what a player has/does");
            Console.WriteLine();

            Console.WriteLine("OBJECT = Instance of a Class:");
            Console.WriteLine("  Like an actual cookie made from the cutter");
            Console.WriteLine("  Each object has its own data");
            Console.WriteLine("  Example: player1, player2, player3 (different players)");
            Console.WriteLine();

            Console.WriteLine("Real-world analogy:");
            Console.WriteLine("  Class 'Car' = Blueprint showing engine, wheels, doors");
            Console.WriteLine("  Object 'myCar' = Actual Toyota with 150hp, 4 wheels, red color");
            Console.WriteLine("  Object 'yourCar' = Actual Honda with 180hp, 4 wheels, blue color");
            Console.WriteLine();

            // ===== CREATING FIRST OBJECT =====

            Console.WriteLine("=== CREATING YOUR FIRST OBJECT ===\n");

            // Create object from Person class (defined below)
            Person person1 = new Person();

            // Set properties (data)
            person1.Name = "Alice";
            person1.Age = 25;
            person1.IsAlive = true;

            Console.WriteLine("Created person1:");
            Console.WriteLine($"  Name: {person1.Name}");
            Console.WriteLine($"  Age: {person1.Age}");
            Console.WriteLine($"  Alive: {person1.IsAlive}");
            Console.WriteLine();

            // Call method (behavior)
            person1.Introduce();
            person1.HaveBirthday();
            person1.Introduce();

            Console.WriteLine();

            // ===== MULTIPLE OBJECTS FROM SAME CLASS =====

            Console.WriteLine("=== MULTIPLE OBJECTS (Same Class) ===\n");

            // Create multiple people from same blueprint
            Person person2 = new Person();
            person2.Name = "Bob";
            person2.Age = 30;
            person2.IsAlive = true;

            Person person3 = new Person();
            person3.Name = "Charlie";
            person3.Age = 22;
            person3.IsAlive = true;

            Console.WriteLine("Multiple people:");
            person1.Introduce();
            person2.Introduce();
            person3.Introduce();

            Console.WriteLine();

            // ===== CAR EXAMPLE =====

            Console.WriteLine("=== CAR EXAMPLE ===\n");

            // Create car objects
            Car car1 = new Car();
            car1.Brand = "Toyota";
            car1.Model = "Corolla";
            car1.Year = 2020;
            car1.Speed = 0;

            Car car2 = new Car();
            car2.Brand = "Honda";
            car2.Model = "Civic";
            car2.Year = 2021;
            car2.Speed = 0;

            // Use car methods
            car1.DisplayInfo();
            car1.Accelerate(30);
            car1.Accelerate(20);
            car1.Brake(10);
            Console.WriteLine();

            car2.DisplayInfo();
            car2.Accelerate(50);
            car2.Brake(15);

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: PLAYER CLASS =====

            Console.WriteLine("=== GAME DEV: PLAYER CLASS ===\n");

            // Create player objects
            Player player1 = new Player();
            player1.Name = "Warrior";
            player1.Health = 100;
            player1.Level = 1;
            player1.Experience = 0;

            Player player2 = new Player();
            player2.Name = "Mage";
            player2.Health = 80;
            player2.Level = 1;
            player2.Experience = 0;

            // Use player methods
            player1.ShowStats();
            Console.WriteLine();

            player2.ShowStats();
            Console.WriteLine();

            // Player actions
            Console.WriteLine("=== Combat ===");
            player1.TakeDamage(20);
            player1.Heal(10);
            player1.GainExperience(50);
            Console.WriteLine();

            player2.TakeDamage(30);
            player2.GainExperience(100); // Level up!

            Console.WriteLine();

            // ===== ENEMY CLASS EXAMPLE =====

            Console.WriteLine("=== GAME DEV: ENEMY CLASS ===\n");

            Enemy goblin = new Enemy();
            goblin.Name = "Goblin";
            goblin.Health = 50;
            goblin.Damage = 10;

            Enemy dragon = new Enemy();
            dragon.Name = "Dragon";
            dragon.Health = 200;
            dragon.Damage = 35;

            goblin.DisplayInfo();
            dragon.DisplayInfo();

            Console.WriteLine("\n=== Battle ===");
            goblin.Attack("Player");
            dragon.Attack("Village");

            Console.WriteLine();

            // ===== WEAPON CLASS EXAMPLE =====

            Console.WriteLine("=== GAME DEV: WEAPON CLASS ===\n");

            Weapon sword = new Weapon();
            sword.Name = "Iron Sword";
            sword.Damage = 25;
            sword.Durability = 100;

            Weapon bow = new Weapon();
            bow.Name = "Wooden Bow";
            bow.Damage = 15;
            bow.Durability = 80;

            sword.DisplayInfo();
            bow.DisplayInfo();

            Console.WriteLine("\n=== Using Weapons ===");
            sword.Use();
            sword.Use();
            bow.Use();

            sword.Repair(20);

            Console.WriteLine();

            // ===== INVENTORY EXAMPLE WITH OBJECTS =====

            Console.WriteLine("=== INVENTORY WITH OBJECTS ===\n");

            // Create items
            Item potion = new Item();
            potion.Name = "Health Potion";
            potion.Quantity = 5;
            potion.Price = 10.5f;

            Item sword2 = new Item();
            sword2.Name = "Steel Sword";
            sword2.Quantity = 1;
            sword2.Price = 250.0f;

            // Store in list
            List<Item> inventory = new List<Item>();
            inventory.Add(potion);
            inventory.Add(sword2);

            Console.WriteLine("Player Inventory:");
            foreach (Item item in inventory)
            {
                item.DisplayInfo();
            }

            Console.WriteLine();

            // ===== BANK ACCOUNT EXAMPLE =====

            Console.WriteLine("=== BANK ACCOUNT EXAMPLE ===\n");

            BankAccount account1 = new BankAccount();
            account1.AccountNumber = "ACC-001";
            account1.Owner = "Alice";
            account1.Balance = 1000.0f;

            account1.DisplayBalance();
            account1.Deposit(500);
            account1.Withdraw(200);
            account1.Withdraw(2000); // Not enough funds

            Console.WriteLine();

            // ===== DIFFERENCE: VALUE TYPES vs REFERENCE TYPES =====

            Console.WriteLine("=== VALUE TYPES vs REFERENCE TYPES ===\n");

            // Value type (int, float, bool) - COPIED
            int number1 = 10;
            int number2 = number1;
            number2 = 20;
            Console.WriteLine($"number1: {number1}"); // Still 10 (not affected)
            Console.WriteLine($"number2: {number2}"); // Changed to 20
            Console.WriteLine();

            // Reference type (class/object) - REFERENCED
            Person personA = new Person();
            personA.Name = "Original";
            personA.Age = 25;

            Person personB = personA; // Both point to SAME object!
            personB.Name = "Modified";
            personB.Age = 30;

            Console.WriteLine("After modifying personB:");
            Console.WriteLine($"personA: Name={personA.Name}, Age={personA.Age}"); // Also changed!
            Console.WriteLine($"personB: Name={personB.Name}, Age={personB.Age}");
            Console.WriteLine("Both variables point to the same object in memory!");

            Console.WriteLine();

            // ===== NULL - OBJECT DOESN'T EXIST =====

            Console.WriteLine("=== NULL (No Object) ===\n");

            Person personNull = null; // Variable exists, but no object assigned
            Console.WriteLine($"personNull is null: {personNull == null}");

            // ❌ This would crash! (NullReferenceException)
            // personNull.Introduce();

            // ✅ Always check for null before using
            if (personNull != null)
            {
                personNull.Introduce();
            }
            else
            {
                Console.WriteLine("Cannot call method on null object!");
            }

            Console.WriteLine();

            // ===== WHY USE CLASSES? =====

            Console.WriteLine("=== WHY USE CLASSES? ===\n");

            Console.WriteLine("WITHOUT Classes (messy!):");
            Console.WriteLine("  string player1Name = \"Alice\";");
            Console.WriteLine("  int player1Health = 100;");
            Console.WriteLine("  int player1Level = 5;");
            Console.WriteLine("  string player2Name = \"Bob\";");
            Console.WriteLine("  int player2Health = 80;");
            Console.WriteLine("  int player2Level = 3;");
            Console.WriteLine("  // Hard to manage, no organization!");
            Console.WriteLine();

            Console.WriteLine("WITH Classes (organized!):");
            Console.WriteLine("  Player player1 = new Player();");
            Console.WriteLine("  player1.Name = \"Alice\";");
            Console.WriteLine("  player1.Health = 100;");
            Console.WriteLine("  player1.Level = 5;");
            Console.WriteLine("  // Data + behavior grouped together!");

            Console.WriteLine();

            // ===== CLASS BENEFITS =====

            Console.WriteLine("=== BENEFITS OF CLASSES ===\n");

            Console.WriteLine("✅ Organization:");
            Console.WriteLine("  • Group related data together (Name, Health, Level)");
            Console.WriteLine("  • Group related behavior together (Attack, Heal, Move)");
            Console.WriteLine();

            Console.WriteLine("✅ Reusability:");
            Console.WriteLine("  • Create many objects from one class");
            Console.WriteLine("  • Player player1, player2, player3... (same template)");
            Console.WriteLine();

            Console.WriteLine("✅ Maintainability:");
            Console.WriteLine("  • Change class once, affects all objects");
            Console.WriteLine("  • Add new method → all objects get it");
            Console.WriteLine();

            Console.WriteLine("✅ Abstraction:");
            Console.WriteLine("  • Hide complex details inside methods");
            Console.WriteLine("  • player.Attack() → simple to use, complex inside");
            Console.WriteLine();

            Console.WriteLine("✅ Real-world modeling:");
            Console.WriteLine("  • Represent real things: Player, Enemy, Weapon, Item");
            Console.WriteLine("  • More intuitive and readable code");

            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use PascalCase for class names (Player, BankAccount)");
            Console.WriteLine("• Use PascalCase for properties (Name, Health, Speed)");
            Console.WriteLine("• Use PascalCase for methods (Attack, TakeDamage, DisplayInfo)");
            Console.WriteLine("• Group related data and behavior in same class");
            Console.WriteLine("• Check for null before accessing object members");
            Console.WriteLine("• Create classes for logical entities (Player, Enemy, Item)");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't create classes for everything (int age vs Age class)");
            Console.WriteLine("• Don't mix unrelated data (Player with FileSystem methods)");
            Console.WriteLine("• Don't forget to initialize objects (null errors!)");
            Console.WriteLine("• Don't make classes too large (100+ methods = too much)");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Key Concepts:");
            Console.WriteLine("• CLASS = Blueprint/Template (defines structure)");
            Console.WriteLine("• OBJECT = Instance of class (actual data)");
            Console.WriteLine("• PROPERTIES = Data/Attributes (Name, Health, Speed)");
            Console.WriteLine("• METHODS = Behavior/Actions (Attack, Move, Heal)");
            Console.WriteLine("• 'new' keyword creates new object");
            Console.WriteLine("• Classes are REFERENCE types (point to memory)");

            Console.WriteLine("\n🎯 When to use Classes:");
            Console.WriteLine("• Representing real-world entities (Player, Car, Item)");
            Console.WriteLine("• Grouping related data and behavior");
            Console.WriteLine("• Creating reusable templates");
            Console.WriteLine("• Building complex systems (Game, Banking, E-commerce)");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• Player class (Name, Health, Level, Attack(), Heal())");
            Console.WriteLine("• Enemy class (Name, Health, Damage, Attack(), Die())");
            Console.WriteLine("• Weapon class (Name, Damage, Durability, Use(), Repair())");
            Console.WriteLine("• Item class (Name, Quantity, Price, Use(), Drop())");
            Console.WriteLine("• NPC class (Name, Dialogue, Quest, Talk(), GiveQuest())");

            Console.WriteLine("\n💡 Remember:");
            Console.WriteLine("Class = Cookie Cutter (blueprint)");
            Console.WriteLine("Object = Cookie (actual thing)");
            Console.WriteLine("You need a class to create objects!");

            Console.WriteLine("\n🔜 Next Topics:");
            Console.WriteLine("• Constructors (better object initialization)");
            Console.WriteLine("• Properties (getters/setters for data protection)");
            Console.WriteLine("• Encapsulation (hiding internal details)");
            Console.WriteLine("• Inheritance (creating specialized classes)");
        }

        // ВСЕ классы переместить ВНУТРЬ
        class Person
        {
            // Properties (data/attributes)
            public string Name;
            public int Age;
            public bool IsAlive;

            // Methods (behavior/actions)
            public void Introduce()
            {
                Console.WriteLine($"Hi, I'm {Name} and I'm {Age} years old.");
            }

            public void HaveBirthday()
            {
                Age++;
                Console.WriteLine($"{Name} had a birthday! Now {Age} years old.");
            }
        }

        // Car class
        class Car
        {
            // Properties
            public string Brand;
            public string Model;
            public int Year;
            public int Speed;

            // Methods
            public void DisplayInfo()
            {
                Console.WriteLine($"Car: {Year} {Brand} {Model}, Speed: {Speed} km/h");
            }

            public void Accelerate(int increase)
            {
                Speed += increase;
                Console.WriteLine($"{Brand} {Model} accelerated! Speed: {Speed} km/h");
            }

            public void Brake(int decrease)
            {
                Speed -= decrease;
                if (Speed < 0) Speed = 0;
                Console.WriteLine($"{Brand} {Model} braked! Speed: {Speed} km/h");
            }
        }

        // Player class (game dev)
        class Player
        {
            // Properties
            public string Name;
            public int Health;
            public int MaxHealth = 100;
            public int Level;
            public int Experience;

            // Methods
            public void ShowStats()
            {
                Console.WriteLine($"=== {Name} ===");
                Console.WriteLine($"Level: {Level}");
                Console.WriteLine($"Health: {Health}/{MaxHealth}");
                Console.WriteLine($"Experience: {Experience}");
            }

            public void TakeDamage(int damage)
            {
                Health -= damage;
                if (Health < 0) Health = 0;
                Console.WriteLine($"{Name} took {damage} damage! Health: {Health}/{MaxHealth}");

                if (Health == 0)
                {
                    Console.WriteLine($"{Name} has been defeated!");
                }
            }

            public void Heal(int amount)
            {
                Health += amount;
                if (Health > MaxHealth) Health = MaxHealth;
                Console.WriteLine($"{Name} healed {amount} HP! Health: {Health}/{MaxHealth}");
            }

            public void GainExperience(int xp)
            {
                Experience += xp;
                Console.WriteLine($"{Name} gained {xp} XP! Total XP: {Experience}");

                // Level up at 100 XP
                if (Experience >= 100)
                {
                    Level++;
                    Experience = 0;
                    MaxHealth += 10;
                    Health = MaxHealth;
                    Console.WriteLine($"🎉 {Name} leveled up to Level {Level}! Max Health increased!");
                }
            }
        }

        // Enemy class
        class Enemy
        {
            // Properties
            public string Name;
            public int Health;
            public int Damage;

            // Methods
            public void DisplayInfo()
            {
                Console.WriteLine($"Enemy: {Name} (HP: {Health}, Damage: {Damage})");
            }

            public void Attack(string target)
            {
                Console.WriteLine($"{Name} attacks {target} for {Damage} damage!");
            }
        }

        // Weapon class
        class Weapon
        {
            // Properties
            public string Name;
            public int Damage;
            public int Durability;

            // Methods
            public void DisplayInfo()
            {
                Console.WriteLine($"Weapon: {Name} (Damage: {Damage}, Durability: {Durability}%)");
            }

            public void Use()
            {
                if (Durability > 0)
                {
                    Durability -= 10;
                    Console.WriteLine($"Used {Name}! Durability: {Durability}%");

                    if (Durability <= 0)
                    {
                        Console.WriteLine($"{Name} is broken!");
                    }
                }
                else
                {
                    Console.WriteLine($"{Name} is broken and cannot be used!");
                }
            }

            public void Repair(int amount)
            {
                Durability += amount;
                if (Durability > 100) Durability = 100;
                Console.WriteLine($"Repaired {Name}! Durability: {Durability}%");
            }
        }

        // Item class
        class Item
        {
            // Properties
            public string Name;
            public int Quantity;
            public float Price;

            // Methods
            public void DisplayInfo()
            {
                Console.WriteLine($"  {Name} x{Quantity} (${Price:F2} each)");
            }
        }

        // BankAccount class
        class BankAccount
        {
            // Properties
            public string AccountNumber;
            public string Owner;
            public float Balance;

            // Methods
            public void DisplayBalance()
            {
                Console.WriteLine($"Account: {AccountNumber} ({Owner})");
                Console.WriteLine($"Balance: ${Balance:F2}");
            }

            public void Deposit(float amount)
            {
                Balance += amount;
                Console.WriteLine($"Deposited ${amount:F2}. New balance: ${Balance:F2}");
            }

            public void Withdraw(float amount)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${Balance:F2}");
                }
                else
                {
                    Console.WriteLine($"Insufficient funds! Balance: ${Balance:F2}, Requested: ${amount:F2}");
                }
            }
        }
    }
}