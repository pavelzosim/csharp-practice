using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_learn.Lessons
{
    // LESSON 22: Fields and Access Modifiers (Encapsulation)
    // Learn about data protection, encapsulation, and controlling access to class members
    internal class Lesson22_fields_access_modificators
    {
        public static void Run()
        {
            // ===== TOPIC: FIELDS AND ACCESS MODIFIERS =====
            // Access Modifiers control WHO can access class members (fields, methods)
            // Encapsulation = Hiding internal details, exposing only what's necessary
            // Think: Car - you use steering wheel (public), but engine internals are hidden (private)

            Console.WriteLine("=== FIELDS AND ACCESS MODIFIERS ===\n");

            // ===== WHAT ARE ACCESS MODIFIERS? =====

            Console.WriteLine("=== WHAT ARE ACCESS MODIFIERS? ===\n");

            Console.WriteLine("Access Modifiers define VISIBILITY of class members:");
            Console.WriteLine();
            Console.WriteLine("• public    - accessible EVERYWHERE (no restrictions)");
            Console.WriteLine("• private   - accessible ONLY inside the class (default for fields)");
            Console.WriteLine("• protected - accessible in class and derived classes");
            Console.WriteLine("• internal  - accessible within same assembly/project");
            Console.WriteLine();

            Console.WriteLine("Real-world analogy (Car):");
            Console.WriteLine("• public:    Steering wheel, gas pedal (anyone can use)");
            Console.WriteLine("• private:   Engine internals, transmission (hidden, protected)");
            Console.WriteLine("• You drive the car without knowing HOW the engine works!");
            Console.WriteLine();

            // ===== PROBLEM: PUBLIC FIELDS (NO PROTECTION) =====

            Console.WriteLine("=== PROBLEM: PUBLIC FIELDS ===\n");

            PublicPlayer badPlayer = new PublicPlayer();
            badPlayer.Name = "Hero";
            badPlayer.Health = 100;
            badPlayer.Level = 1;

            Console.WriteLine("Initial state:");
            badPlayer.ShowStats();
            Console.WriteLine();

            // ❌ PROBLEM: Anyone can set invalid values!
            Console.WriteLine("Setting INVALID values (no protection):");
            badPlayer.Health = -50;        // Negative health? Makes no sense!
            badPlayer.Level = 999;         // Level 999 instantly? Cheating!
            badPlayer.Name = "";           // Empty name? Invalid!

            Console.WriteLine("After invalid changes:");
            badPlayer.ShowStats();
            Console.WriteLine("☠️ Data is corrupted! No validation!");

            Console.WriteLine();

            // ===== SOLUTION: PRIVATE FIELDS + PUBLIC METHODS =====

            Console.WriteLine("=== SOLUTION: PRIVATE FIELDS + METHODS ===\n");

            ProtectedPlayer goodPlayer = new ProtectedPlayer("Warrior", 100, 1);

            Console.WriteLine("Initial state:");
            goodPlayer.ShowStats();
            Console.WriteLine();

            // ✅ SAFE: Methods validate data
            Console.WriteLine("Trying INVALID operations (protected):");
            goodPlayer.TakeDamage(-50);    // Can't heal with negative damage!
            goodPlayer.TakeDamage(150);    // Takes damage, but doesn't go below 0
            goodPlayer.SetLevel(999);      // Rejected - too high!
            goodPlayer.SetLevel(5);        // Accepted - valid range
            // goodPlayer.health = -50;    // ❌ COMPILE ERROR! health is private

            Console.WriteLine();
            goodPlayer.ShowStats();

            Console.WriteLine();

            // ===== ACCESS MODIFIER EXAMPLES =====

            Console.WriteLine("=== ACCESS MODIFIER EXAMPLES ===\n");

            BankAccount account = new BankAccount("Alice", 1000);

            // ✅ Can access public members
            account.DisplayInfo();
            Console.WriteLine();

            // ✅ Can use public methods
            account.Deposit(500);
            account.Withdraw(200);

            // ❌ CANNOT access private fields directly
            // account.balance = 999999; // COMPILE ERROR! balance is private
            // account.owner = "";       // COMPILE ERROR! owner is private

            Console.WriteLine();

            // ===== PRIVATE FIELDS NAMING CONVENTION =====

            Console.WriteLine("=== PRIVATE FIELDS NAMING CONVENTION ===\n");

            Console.WriteLine("Common naming styles for private fields:");
            Console.WriteLine();
            Console.WriteLine("Style 1: Underscore prefix (recommended)");
            Console.WriteLine("  private int _health;");
            Console.WriteLine("  private string _name;");
            Console.WriteLine();

            Console.WriteLine("Style 2: camelCase (also common)");
            Console.WriteLine("  private int health;");
            Console.WriteLine("  private string name;");
            Console.WriteLine();

            Console.WriteLine("Style 3: PascalCase + this. (less common)");
            Console.WriteLine("  private int Health;");
            Console.WriteLine("  this.Health = value;");
            Console.WriteLine();

            Console.WriteLine("✅ This lesson uses underscore prefix (_health, _name)");

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: PLAYER CLASS =====

            Console.WriteLine("=== GAME DEV: PLAYER CLASS ===\n");

            Player player = new Player("Knight", 150);
            player.ShowStats();
            Console.WriteLine();

            Console.WriteLine("=== Combat Simulation ===");
            player.TakeDamage(30);
            player.Heal(20);
            player.TakeDamage(200); // Overkill damage
            Console.WriteLine();

            player.ShowStats();

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: WEAPON CLASS =====

            Console.WriteLine("=== GAME DEV: WEAPON CLASS ===\n");

            Weapon sword = new Weapon("Iron Sword", 25, 100);
            sword.DisplayInfo();
            Console.WriteLine();

            Console.WriteLine("=== Using Weapon ===");
            sword.Use();
            sword.Use();
            sword.Use();
            Console.WriteLine();

            sword.DisplayInfo();
            sword.Repair(30);
            sword.DisplayInfo();

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: INVENTORY ITEM =====

            Console.WriteLine("=== GAME DEV: INVENTORY ITEM ===\n");

            InventoryItem potion = new InventoryItem("Health Potion", 5, 10.5f);
            potion.DisplayInfo();
            Console.WriteLine();

            Console.WriteLine("=== Using Items ===");
            potion.Use(2);
            potion.Use(3);
            potion.Use(5); // Try to use more than available
            Console.WriteLine();

            potion.DisplayInfo();
            potion.AddQuantity(10);
            potion.DisplayInfo();

            Console.WriteLine();

            // ===== GETTER AND SETTER METHODS =====

            Console.WriteLine("=== GETTER AND SETTER METHODS ===\n");

            Enemy enemy = new Enemy("Goblin", 50, 10);
            enemy.DisplayInfo();
            Console.WriteLine();

            // Get values through getter methods
            Console.WriteLine($"Enemy name: {enemy.GetName()}");
            Console.WriteLine($"Enemy health: {enemy.GetHealth()}");
            Console.WriteLine($"Enemy damage: {enemy.GetDamage()}");
            Console.WriteLine();

            // Set values through setter methods (with validation)
            enemy.SetHealth(60);
            enemy.SetDamage(15);
            Console.WriteLine("After modifications:");
            enemy.DisplayInfo();

            Console.WriteLine();

            // ===== READONLY FIELDS =====

            Console.WriteLine("=== READONLY FIELDS ===\n");

            GameConfig config = new GameConfig("My Game", "1.0.0");
            config.DisplayInfo();
            Console.WriteLine();

            // ✅ Can read through getter
            Console.WriteLine($"Game Name: {config.GetGameName()}");
            Console.WriteLine($"Version: {config.GetVersion()}");
            Console.WriteLine();

            // ❌ Cannot change readonly fields after creation
            // config.gameName = "New Name"; // COMPILE ERROR! readonly
            Console.WriteLine("Readonly fields cannot be changed after initialization!");

            Console.WriteLine();

            // ===== CONST vs READONLY =====

            Console.WriteLine("=== CONST vs READONLY ===\n");

            Constants.DisplayConstants();
            Console.WriteLine();

            Console.WriteLine("Difference:");
            Console.WriteLine("• const    - compile-time constant, must be initialized at declaration");
            Console.WriteLine("• readonly - runtime constant, can be initialized in constructor");
            Console.WriteLine("• const    - implicitly static (use ClassName.CONSTANT)");
            Console.WriteLine("• readonly - can be instance-specific");

            Console.WriteLine();

            // ===== ENCAPSULATION BENEFITS =====

            Console.WriteLine("=== ENCAPSULATION BENEFITS ===\n");

            Console.WriteLine("✅ Data Protection:");
            Console.WriteLine("  • Prevent invalid values (negative health, empty names)");
            Console.WriteLine("  • Ensure data consistency");
            Console.WriteLine("  • Example: Health always between 0 and MaxHealth");
            Console.WriteLine();

            Console.WriteLine("✅ Control Access:");
            Console.WriteLine("  • Decide what can be read/written");
            Console.WriteLine("  • Example: Allow reading balance, but not directly setting it");
            Console.WriteLine();

            Console.WriteLine("✅ Internal Changes:");
            Console.WriteLine("  • Change implementation without breaking external code");
            Console.WriteLine("  • Example: Change health storage from int to float");
            Console.WriteLine();

            Console.WriteLine("✅ Validation:");
            Console.WriteLine("  • Add checks when setting values");
            Console.WriteLine("  • Example: Level must be between 1 and 100");
            Console.WriteLine();

            Console.WriteLine("✅ Business Logic:");
            Console.WriteLine("  • Enforce rules through methods");
            Console.WriteLine("  • Example: Can't withdraw more than balance");

            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Make fields PRIVATE by default");
            Console.WriteLine("• Provide PUBLIC methods to access/modify data (getters/setters)");
            Console.WriteLine("• Validate data in setter methods");
            Console.WriteLine("• Use meaningful names (_health, _maxHealth, _isAlive)");
            Console.WriteLine("• Use readonly for values that shouldn't change");
            Console.WriteLine("• Group related fields together");
            Console.WriteLine("• Document why fields are public if they are");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't make everything public (breaks encapsulation)");
            Console.WriteLine("• Don't allow invalid data (negative health, empty names)");
            Console.WriteLine("• Don't expose internal implementation details");
            Console.WriteLine("• Don't use public fields for complex data (use methods)");
            Console.WriteLine("• Don't forget to validate in setter methods");

            Console.WriteLine();

            // ===== COMMON PATTERNS =====

            Console.WriteLine("=== COMMON PATTERNS ===\n");

            Console.WriteLine("Pattern 1: Private Field + Public Methods");
            Console.WriteLine("  private int _health;");
            Console.WriteLine("  public int GetHealth() { return _health; }");
            Console.WriteLine("  public void SetHealth(int value) { ... validation ... }");
            Console.WriteLine();

            Console.WriteLine("Pattern 2: Private Field + Public Property (Lesson 23)");
            Console.WriteLine("  private int _health;");
            Console.WriteLine("  public int Health");
            Console.WriteLine("  {");
            Console.WriteLine("      get { return _health; }");
            Console.WriteLine("      set { ... validation ... }");
            Console.WriteLine("  }");
            Console.WriteLine();

            Console.WriteLine("Pattern 3: Constructor Initialization");
            Console.WriteLine("  private string _name;");
            Console.WriteLine("  public Player(string name)");
            Console.WriteLine("  {");
            Console.WriteLine("      _name = name;");
            Console.WriteLine("  }");

            Console.WriteLine();

            // ===== ACCESS MODIFIER COMPARISON =====

            Console.WriteLine("=== ACCESS MODIFIER COMPARISON ===\n");

            Console.WriteLine("┌────────────┬─────────────┬──────────────┬─────────────┐");
            Console.WriteLine("│ Modifier   │ Same Class  │ Derived Class│ Outside     │");
            Console.WriteLine("├────────────┼─────────────┼──────────────┼─────────────┤");
            Console.WriteLine("│ public     │ ✅ Yes      │ ✅ Yes       │ ✅ Yes      │");
            Console.WriteLine("│ private    │ ✅ Yes      │ ❌ No        │ ❌ No       │");
            Console.WriteLine("│ protected  │ ✅ Yes      │ ✅ Yes       │ ❌ No       │");
            Console.WriteLine("│ internal   │ ✅ Yes      │ ✅ Yes*      │ ❌ No**     │");
            Console.WriteLine("└────────────┴─────────────┴──────────────┴─────────────┘");
            Console.WriteLine("* if in same assembly");
            Console.WriteLine("** outside assembly/project");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Key Concepts:");
            Console.WriteLine("• Access Modifiers control visibility (public, private, protected)");
            Console.WriteLine("• private = accessible only within the class");
            Console.WriteLine("• public = accessible everywhere");
            Console.WriteLine("• Encapsulation = hiding internal details");
            Console.WriteLine("• Use private fields + public methods for safety");
            Console.WriteLine("• readonly = can only be set once (in constructor)");
            Console.WriteLine("• const = compile-time constant");

            Console.WriteLine("\n🎯 Why use private fields?");
            Console.WriteLine("• Data protection (prevent invalid values)");
            Console.WriteLine("• Data validation (check before setting)");
            Console.WriteLine("• Control access (decide what's readable/writable)");
            Console.WriteLine("• Flexibility (change implementation later)");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• private int _health; → protected, validated through methods");
            Console.WriteLine("• private float _balance; → can't be directly modified");
            Console.WriteLine("• private string _password; → hidden, not accessible");
            Console.WriteLine("• readonly string _gameId; → set once, never changes");

            Console.WriteLine("\n💡 Golden Rule:");
            Console.WriteLine("Make everything PRIVATE by default.");
            Console.WriteLine("Only make PUBLIC what absolutely needs to be accessible!");

            Console.WriteLine("\n🔜 Next Topics:");
            Console.WriteLine("• Properties (better getters/setters with get/set syntax)");
            Console.WriteLine("• Auto-properties (shorthand for simple properties)");
            Console.WriteLine("• Property validation and computed properties");
        }

        // Классы внутри
        class PublicPlayer
        {
            public string Name;
            public int Health;
            public int Level;

            public void ShowStats()
            {
                Console.WriteLine($"Name: {Name}, Health: {Health}, Level: {Level}");
            }
        }

        class ProtectedPlayer
        {
            // Private fields (hidden from outside)
            private string _name;
            private int _health;
            private int _maxHealth;
            private int _level;

            // Constructor to initialize
            public ProtectedPlayer(string name, int health, int level)
            {
                _name = name;
                _health = health;
                _maxHealth = health;
                _level = level;
            }

            // Public method to display stats
            public void ShowStats()
            {
                Console.WriteLine($"Name: {_name}, Health: {_health}/{_maxHealth}, Level: {_level}");
            }

            // Public method with validation
            public void TakeDamage(int damage)
            {
                if (damage < 0)
                {
                    Console.WriteLine("Cannot take negative damage!");
                    return;
                }

                _health -= damage;
                if (_health < 0) _health = 0;
                Console.WriteLine($"{_name} took {damage} damage. Health: {_health}/{_maxHealth}");
            }

            // Public method to set level with validation
            public void SetLevel(int level)
            {
                if (level < 1 || level > 100)
                {
                    Console.WriteLine($"Invalid level {level}! Must be between 1 and 100.");
                    return;
                }

                _level = level;
                Console.WriteLine($"{_name} is now level {_level}");
            }
        }

        // Bank Account example
        class BankAccount
        {
            // Private fields
            private string _owner;
            private float _balance;

            // Constructor
            public BankAccount(string owner, float initialBalance)
            {
                _owner = owner;
                _balance = initialBalance;
            }

            // Public methods (controlled access)
            public void DisplayInfo()
            {
                Console.WriteLine($"Account Owner: {_owner}");
                Console.WriteLine($"Balance: ${_balance:F2}");
            }

            public void Deposit(float amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Deposit amount must be positive!");
                    return;
                }

                _balance += amount;
                Console.WriteLine($"Deposited ${amount:F2}. New balance: ${_balance:F2}");
            }

            public void Withdraw(float amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Withdrawal amount must be positive!");
                    return;
                }

                if (amount > _balance)
                {
                    Console.WriteLine($"Insufficient funds! Balance: ${_balance:F2}");
                    return;
                }

                _balance -= amount;
                Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${_balance:F2}");
            }
        }

        // Player class (game dev)
        class Player
        {
            // Private fields
            private string _name;
            private int _health;
            private int _maxHealth;

            // Constructor
            public Player(string name, int maxHealth)
            {
                _name = name;
                _maxHealth = maxHealth;
                _health = maxHealth;
            }

            // Public methods
            public void ShowStats()
            {
                Console.WriteLine($"Player: {_name}");
                Console.WriteLine($"Health: {_health}/{_maxHealth}");
            }

            public void TakeDamage(int damage)
            {
                _health -= damage;
                if (_health < 0) _health = 0;

                Console.WriteLine($"{_name} took {damage} damage! Health: {_health}/{_maxHealth}");

                if (_health == 0)
                {
                    Console.WriteLine($"💀 {_name} has been defeated!");
                }
            }

            public void Heal(int amount)
            {
                if (_health == 0)
                {
                    Console.WriteLine($"{_name} is dead and cannot be healed!");
                    return;
                }

                _health += amount;
                if (_health > _maxHealth) _health = _maxHealth;
                Console.WriteLine($"{_name} healed {amount} HP! Health: {_health}/{_maxHealth}");
            }
        }

        // Weapon class
        class Weapon
        {
            private string _name;
            private int _damage;
            private int _durability;

            public Weapon(string name, int damage, int durability)
            {
                _name = name;
                _damage = damage;
                _durability = durability;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Weapon: {_name} (Damage: {_damage}, Durability: {_durability}%)");
            }

            public void Use()
            {
                if (_durability <= 0)
                {
                    Console.WriteLine($"{_name} is broken and cannot be used!");
                    return;
                }

                _durability -= 10;
                if (_durability < 0) _durability = 0;

                Console.WriteLine($"Used {_name} for {_damage} damage! Durability: {_durability}%");

                if (_durability == 0)
                {
                    Console.WriteLine($"⚠️ {_name} has broken!");
                }
            }

            public void Repair(int amount)
            {
                _durability += amount;
                if (_durability > 100) _durability = 100;
                Console.WriteLine($"Repaired {_name}! Durability: {_durability}%");
            }
        }

        // Inventory Item class
        class InventoryItem
        {
            private string _name;
            private int _quantity;
            private float _price;

            public InventoryItem(string name, int quantity, float price)
            {
                _name = name;
                _quantity = quantity;
                _price = price;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"{_name} x{_quantity} (${_price:F2} each, Total: ${_quantity * _price:F2})");
            }

            public void Use(int amount)
            {
                if (amount > _quantity)
                {
                    Console.WriteLine($"Not enough {_name}! Have {_quantity}, need {amount}");
                    return;
                }

                _quantity -= amount;
                Console.WriteLine($"Used {amount} {_name}. Remaining: {_quantity}");
            }

            public void AddQuantity(int amount)
            {
                _quantity += amount;
                Console.WriteLine($"Added {amount} {_name}. Total: {_quantity}");
            }
        }

        // Enemy class with getters/setters
        class Enemy
        {
            private string _name;
            private int _health;
            private int _damage;

            public Enemy(string name, int health, int damage)
            {
                _name = name;
                _health = health;
                _damage = damage;
            }

            // Getter methods
            public string GetName() { return _name; }
            public int GetHealth() { return _health; }
            public int GetDamage() { return _damage; }

            // Setter methods with validation
            public void SetHealth(int health)
            {
                if (health < 0)
                {
                    Console.WriteLine("Health cannot be negative!");
                    return;
                }
                _health = health;
            }

            public void SetDamage(int damage)
            {
                if (damage < 0)
                {
                    Console.WriteLine("Damage cannot be negative!");
                    return;
                }
                _damage = damage;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Enemy: {_name} (HP: {_health}, Damage: {_damage})");
            }
        }

        // Readonly example
        class GameConfig
        {
            // Readonly fields - can only be set in constructor
            private readonly string _gameName;
            private readonly string _version;

            public GameConfig(string gameName, string version)
            {
                _gameName = gameName;
                _version = version;
            }

            public string GetGameName() { return _gameName; }
            public string GetVersion() { return _version; }

            public void DisplayInfo()
            {
                Console.WriteLine($"Game: {_gameName}");
                Console.WriteLine($"Version: {_version}");
                Console.WriteLine("(These values are readonly and cannot be changed)");
            }
        }

        // Constants example
        class Constants
        {
            // Const - compile-time constants
            public const int MAX_PLAYERS = 100;
            public const float GRAVITY = 9.81f;
            public const string GAME_VERSION = "1.0.0";

            // Readonly - runtime constants
            public readonly int MaxLevel = 100;

            public static void DisplayConstants()
            {
                Console.WriteLine("Constants:");
                Console.WriteLine($"  MAX_PLAYERS: {MAX_PLAYERS}");
                Console.WriteLine($"  GRAVITY: {GRAVITY}");
                Console.WriteLine($"  GAME_VERSION: {GAME_VERSION}");
            }
        }
    }
}